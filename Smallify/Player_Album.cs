using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smallify
{
    public partial class Player_Album : Form
    {
        private static SmallifyManager _smallifyManger;

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

        public Player_Album()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.smallify_icon;
        }

        // FORM LOAD
        private void Player_Album_Load(object sender, EventArgs e)
        {
            // Initialise Smallify Manager
            _smallifyManger = new SmallifyManager();

            // Initialise Play|Pause Media control state
            //Btn_PlayPause.Image = _smallifyManger.isTrackPlaying ? Properties.Resources.pause_default : Properties.Resources.play_default;

            // Initialise Album art
            this.BackgroundImage = _smallifyManger.currentLargeCover;

            Timer_Update.Start();
        }

        private void Timer_Update_Tick(object sender, EventArgs e)
        {
            // Update Album Art
            this.BackgroundImage = _smallifyManger.currentLargeCover;

            // Calculate progress bar width
            float trackStep = (float)this.Width / _smallifyManger.currentTrackLength;
            float barWidth = _smallifyManger.currentTrackPosition * trackStep;
            PB_ProgressBar.Width = (int)barWidth;
        }

        private void Player_Album_Resize(object sender, EventArgs e)
        {

        }

        private void aotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aotToolStripMenuItem.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void barToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Player_Bar()).Show();
            
            this.Hide();
        }
    }
}
