using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifyAPI.Local;

namespace Smallify
{
    public partial class MainForm : Form
    {
        SpotifyLocalAPI _spotify = new SpotifyLocalAPI();
        SpotifyAPI.Local.Models.StatusResponse _spotifyStatus = new SpotifyAPI.Local.Models.StatusResponse();
        bool isPlaying = false;
        string nowPlayingName = null;

        public MainForm()
        {
            InitializeComponent();
            _spotify.Connect();
            _spotifyStatus = _spotify.GetStatus();

            isPlaying = _spotifyStatus.Playing ? true : false;
            UpdateTrackInfo();

            tUpdate.Start();
        }

        // Click & drag borderless window
        private bool isResizing = false;
        private Point clickPoint = new Point(0, 0);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // MOUSE DOWN :: 
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Cursor.Equals(Cursors.SizeWE))
            {
                // Mouse is down and cursor is set to resize
                isResizing = true;
                clickPoint = e.Location;
            }
            else if (e.Button == MouseButtons.Left && !isResizing)
            {
                // Triggered on any object that doesnt't have a Click/Button-Like function to allow dragging
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        // MOUSE UP :: No resize possible
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            isResizing = false;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            // While mosue moving either handle cursor types in order to resize or carry out a resize
            if (!isResizing)
            {
                bool resize_x = e.X > (this.Width - 8);

                if (resize_x)
                {
                    this.Cursor = Cursors.SizeWE;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                if (this.Cursor.Equals(Cursors.SizeWE))
                {
                    this.Size = new Size(this.Size.Width + (e.Location.X - this.clickPoint.X), this.Size.Height);
                }

                clickPoint = e.Location;
            }
        }

        // BUTTON CLOSE/EXIT :: Set mouse hover image
        private void pbtnClose_MouseHover(object sender, EventArgs e)
        {
            pbtnClose.Image = Properties.Resources.close_hover;
        }

        // BUTTON CLOSE/EXIT :: Set mouse leave image (Default state)
        private void pbtnClose_MouseLeave(object sender, EventArgs e)
        {
            pbtnClose.Image = Properties.Resources.close_default;
        }

        // BUTTON CLOSE/EXIT :: Action, exit application
        private void pbtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // BUTTON TRACK SKIP :: Set mouse hover image
        private void pbtnSkip_MouseHover(object sender, EventArgs e)
        {
            pbtnSkip.Image = Properties.Resources.skip_hover;
        }

        // BUTTON TRACK SKIP :: Set mouse leave image (Default state)
        private void pbtnSkip_MouseLeave(object sender, EventArgs e)
        {
            pbtnSkip.Image = Properties.Resources.skip_default;
        }

        // BUTTON TRACK SKIP :: Action, skip track
        private void pbtnSkip_Click(object sender, EventArgs e)
        {
            _spotify.Skip();
        }

        // BUTTON TRACK PREVIOUS :: Set mouse hover image
        private void pbtnPrevious_MouseHover(object sender, EventArgs e)
        {
            pbtnPrevious.Image = Properties.Resources.previous_hover;
        }

        // BUTTON TRACK PREVIOUS :: Set mouse leave image (Default state)
        private void pbtnPrevious_MouseLeave(object sender, EventArgs e)
        {
            pbtnPrevious.Image = Properties.Resources.previous_default;
        }

        // BUTTON TRACK PREVIOUS :: Action, previous track
        private void pbtnPrevious_Click(object sender, EventArgs e)
        {
            _spotify.Previous();
        }

        // BUTTON TRACK PAUSE/PLAY :: Set mouse hover image
        private void pbtnPause_MouseHover(object sender, EventArgs e)
        {
            pbtnPause.Image = isPlaying ? Properties.Resources.pause_hover : Properties.Resources.play_hover;
        }

        // BUTTON TRACK PAUSE/PLAY :: Set mouse leave image (Default state)
        private void pbtnPause_MouseLeave(object sender, EventArgs e)
        {
            pbtnPause.Image = isPlaying ? Properties.Resources.pause_default : Properties.Resources.play_default;
        }

        // BUTTON TRACK PAUSE/PLAY :: Action, pause/skip track
        private void pbtnPause_Click(object sender, EventArgs e)
        {
            var model = _spotify.GetStatus();

            // Execute based on current playing state
            if (model.Playing)
            {
                _spotify.Pause();
                isPlaying = false;
            }
            else
            {
                _spotify.Play();
                isPlaying = true;
            }

            // Change image to the opposite of the current playing state (eg. If playing show pause button...)
            pbtnPause.Image = isPlaying ? Properties.Resources.pause_hover : Properties.Resources.play_hover;
        }

        // UPDATE TIMER :: Update displayed information
        private void tUpdate_Tick(object sender, EventArgs e)
        {
            // Get current status from Spotify
            _spotifyStatus = _spotify.GetStatus();

            // Update Track Info (Album art, track name, track artist) -> If new information is required
            UpdateTrackInfo();

            // IF PLAYING, get current times of Track and update now playing time bar
            if (isPlaying)
            {
                int trackLength = _spotifyStatus.Track.Length;
                int trackPosition = (int)_spotifyStatus.PlayingPosition;
                float trackStep = (float)this.Width / trackLength;
                float barWidth = trackPosition * trackStep;

                pBoxPlayBar.Width = (int)barWidth;
            }
        }

        private void UpdateTrackInfo()
        {
            // IF 'stored' currently playing is not equal to the track that is currently playing by Spotify -> Update info
            if (nowPlayingName != _spotifyStatus.Track.TrackResource.Name)
            {
                lblTrack.Text = _spotifyStatus.Track.TrackResource.Name;
                lblArtist.Text = _spotifyStatus.Track.ArtistResource.Name;
                pBoxAlbumArt.Image = _spotifyStatus.Track.GetAlbumArt(SpotifyAPI.Local.Enums.AlbumArtSize.Size160);

                nowPlayingName = _spotifyStatus.Track.TrackResource.Name;
            }
        }
    }
}
