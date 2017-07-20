using SpotifyAPI.Local.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smallify
{


    public partial class Player_Bar : Form
    {
        SmallifyManager sManager;

        // Border size to resize the form
        const int edge = 5;

        // Override Window Processes
        // (FormBorderStyle:None) Resizable window / Click & Drag to move form
        protected override void WndProc(ref Message m)
        {
            const UInt32 WM_NCHITTEST = 0x0084;
            const UInt32 WM_MOUSEMOVE = 0x0200;

            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;
            const UInt32 HTBOTTOMRIGHT = 17;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTTOP = 12;
            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;

            const int RESIZE_HANDLE_SIZE = 10;
            bool handled = false;
            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                Dictionary<UInt32, Rectangle> boxes = new Dictionary<UInt32, Rectangle>() {
                    { HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    { HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    { HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    { HTRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE)},
                    { HTTOPRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    { HTTOP, new Rectangle(RESIZE_HANDLE_SIZE, 0, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    { HTTOPLEFT, new Rectangle(0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    { HTLEFT, new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE) }
                };

                foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes)
                {
                    if (hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }
            }
            if (!handled)
            {
                base.WndProc(ref m);
            }
        }

        // "sub-classing" create wrapper .NET classes
        // Effectively makes the control "transparent" to the mouse - this allows the actual form to pick up mouse messages used for resizing
        class MouseFilter : NativeWindow
        {
            private Form form;
            public MouseFilter(Form form, Control child)
            {
                this.form = form;
                this.AssignHandle(child.Handle);
            }
            protected override void WndProc(ref Message m)
            {
                const int wmNcHitTest = 0x84;
                const int htTransparent = -1;

                if (m.Msg == wmNcHitTest)
                {
                    var pos = new Point(m.LParam.ToInt32());
                    if (pos.X < this.form.Left + edge ||
                        pos.Y < this.form.Top + edge ||
                        pos.X > this.form.Right - edge ||
                        pos.Y > this.form.Bottom - edge)
                    {
                        m.Result = new IntPtr(htTransparent);
                        return;
                    }
                }
                base.WndProc(ref m);
            }
        }

        // Mouse Filter Instance for every control that gets close to the window edge
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            subClassChildren(this.Controls);
        }

        // Control chrildren close to the window edge
        private void subClassChildren(Control.ControlCollection ctls)
        {
            foreach (Control ctl in ctls)
            {
                var rc = this.RectangleToClient(this.RectangleToScreen(ctl.DisplayRectangle));
                if (rc.Left < edge || rc.Right > this.ClientSize.Width - edge ||
                    rc.Top < edge || rc.Bottom > this.ClientSize.Height - edge)
                {
                    new MouseFilter(this, ctl);
                }
                subClassChildren(ctl.Controls);
            }
        }

        // Click & Drag the form to move
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
  
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MoveForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // SMALLIFY - PLAYER BAR
        public Player_Bar()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.smallify_icon;

            // Initialise Smallify Manager
            sManager = new SmallifyManager();

            // Initialise Play|Pause Media control state
            Btn_PlayPause.Image = sManager.isTrackPlaying ? Properties.Resources.pause_default : Properties.Resources.play_default;

            // Initialise Track information and album art
            SetTrackInformaiton();

            Timer_Update.Start();
        }

        // Update Timer
        private void Timer_Update_Tick(object sender, EventArgs e)
        {
            sManager.UpdateTrack();

            // IF PLAYING, get current times of Track and update now playing time bar
            if (sManager.isTrackPlaying)
            {
                SetTrackInformaiton();
            }

        }

        private void SetTrackInformaiton()
        {
            Label_Track.Text = sManager.currentTrack.TrackResource.Name;
            Label_Artist.Text = sManager.currentTrack.ArtistResource.Name;
            PB_AlbumArt.Image = sManager.currentAlbumArt;
            PB_ProgressBar.Width = sManager.TimeToPixels(this.Width);
        }

        // PLAY|PAUSE : Mouse "Enter" state
        private void Btn_PlayPause_MouseEnter(object sender, EventArgs e)
        {
            Btn_PlayPause.Image = sManager.isTrackPlaying ? Properties.Resources.pause_hover : Properties.Resources.play_hover;
        }

        // PLAY|PAUSE : Mouse "Leave" state
        private void Btn_PlayPause_MouseLeave(object sender, EventArgs e)
        {
            Btn_PlayPause.Image = sManager.isTrackPlaying ? Properties.Resources.pause_default : Properties.Resources.play_default;
        }

        // PLAY|PAUSE : Mouse "Click"
        private void Btn_PlayPause_Click(object sender, EventArgs e)
        {
            sManager.PlayPause();

            // Change image to the opposite of the current playing state (eg. If playing show pause button...)
            Btn_PlayPause.Image = sManager.isTrackPlaying ? Properties.Resources.pause_hover : Properties.Resources.play_hover;
        }

        // NEXT : Mouse "Enter" state
        private void Btn_Next_MouseEnter(object sender, EventArgs e)
        {
            Btn_Next.Image = Properties.Resources.skip_hover;
        }

        // NEXT : Mouse "Leave" state
        private void Btn_Next_MouseLeave(object sender, EventArgs e)
        {
            Btn_Next.Image = Properties.Resources.skip_default;
        }

        // NEXT : Mouse "Click"
        private void Btn_Next_Click(object sender, EventArgs e)
        {
            sManager.Next();
        }

        // PREVIOUS : Mouse "Enter" state
        private void Btn_Previous_MouseEnter(object sender, EventArgs e)
        {
            Btn_Previous.Image = Properties.Resources.previous_hover;
        }

        // PREVIOUS : Mouse "Leave" state
        private void Btn_Previous_MouseLeave(object sender, EventArgs e)
        {
            Btn_Previous.Image = Properties.Resources.previous_default;
        }

        // PREVIOUS : Mouse "Click"
        private void Btn_Previous_Click(object sender, EventArgs e)
        {
            sManager.Previous();
        }

        // EXIT APPLICATON : Mouse "Enter" state
        private void Btn_Exit_MouseEnter(object sender, EventArgs e)
        {
            Btn_Exit.Image = Properties.Resources.close_hover;
        }

        // EXIT APPLICATON : Mouse "Leave" state
        private void Btn_Exit_MouseLeave(object sender, EventArgs e)
        {
            Btn_Exit.Image = Properties.Resources.close_default;
        }

        // EXIT APPLICATON : Mouse "Click"
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Player_Bar_Resize(object sender, EventArgs e)
        {
            PB_AlbumArt.Width = PB_AlbumArt.Height;
        }

        private void CMenu_Item1_Click(object sender, EventArgs e)
        {
            if (CMenu_Item1.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
    }
}
