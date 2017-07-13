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

        private void pbtnClose_MouseHover(object sender, EventArgs e)
        {
            pbtnClose.Image = Properties.Resources.close_hover;
        }

        private void pbtnClose_MouseLeave(object sender, EventArgs e)
        {
            pbtnClose.Image = Properties.Resources.close_default;
        }

        private void pbtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void pbtnSkip_MouseHover(object sender, EventArgs e)
        {
            pbtnSkip.Image = Properties.Resources.skip_hover;
        }

        private void pbtnSkip_MouseLeave(object sender, EventArgs e)
        {
            pbtnSkip.Image = Properties.Resources.skip_default;
        }

        private void pbtnSkip_Click(object sender, EventArgs e)
        {
            _spotify.Skip();
        }

        private void pbtnPrevious_MouseHover(object sender, EventArgs e)
        {
            pbtnPrevious.Image = Properties.Resources.previous_hover;
        }

        private void pbtnPrevious_MouseLeave(object sender, EventArgs e)
        {
            pbtnPrevious.Image = Properties.Resources.previous_default;
        }

        private void pbtnPrevious_Click(object sender, EventArgs e)
        {
            _spotify.Previous();
        }

        private void pbtnPause_MouseHover(object sender, EventArgs e)
        {
            pbtnPause.Image = isPlaying ? Properties.Resources.pause_hover : Properties.Resources.play_hover;
        }

        private void pbtnPause_MouseLeave(object sender, EventArgs e)
        {
            pbtnPause.Image = isPlaying ? Properties.Resources.pause_default : Properties.Resources.play_default;
        }

        private void pbtnPause_Click(object sender, EventArgs e)
        {
            var model = _spotify.GetStatus();

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
            pbtnPause.Image = isPlaying ? Properties.Resources.pause_hover : Properties.Resources.play_hover;
        }

        private void tUpdate_Tick(object sender, EventArgs e)
        {
            _spotifyStatus = _spotify.GetStatus();
            UpdateTrackInfo();
            

            int trackLength = _spotifyStatus.Track.Length;
            int trackPosition = (int)_spotifyStatus.PlayingPosition;
            float trackStep = (float)this.Width / trackLength;
            float barWidth = trackPosition * trackStep;

            pBoxPlayBar.Width = (int)barWidth;
        }

        private void UpdateTrackInfo()
        {
            _spotifyStatus = _spotify.GetStatus();

            if (nowPlayingName != _spotifyStatus.Track.TrackResource.Name)
            {
                lblTrack.Text = _spotifyStatus.Track.TrackResource.Name;
                lblArtist.Text = _spotifyStatus.Track.ArtistResource.Name;
                pBoxAlbumArt.Image = _spotifyStatus.Track.GetAlbumArt(SpotifyAPI.Local.Enums.AlbumArtSize.Size160);

                nowPlayingName = _spotifyStatus.Track.TrackResource.Name;
            }
        }





        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
