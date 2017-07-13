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

        public MainForm()
        {
            InitializeComponent();
            _spotify.Connect();
            _spotifyStatus = _spotify.GetStatus();

            isPlaying = _spotifyStatus.Playing ? true : false;

            lblTrack.Text = _spotifyStatus.Track.TrackResource.Name;
            lblArtist.Text = _spotifyStatus.Track.ArtistResource.Name;
            pictureBox1.Image = _spotifyStatus.Track.GetAlbumArt(SpotifyAPI.Local.Enums.AlbumArtSize.Size160);

            tUpdate.Start();
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
            _spotifyStatus = _spotify.GetStatus();

            isPlaying = _spotifyStatus.Playing ? true : false;

            lblTrack.Text = _spotifyStatus.Track.TrackResource.Name;
            lblArtist.Text = _spotifyStatus.Track.ArtistResource.Name;
            pictureBox1.Image = _spotifyStatus.Track.GetAlbumArt(SpotifyAPI.Local.Enums.AlbumArtSize.Size160);
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
            _spotifyStatus = _spotify.GetStatus();

            isPlaying = _spotifyStatus.Playing ? true : false;

            lblTrack.Text = _spotifyStatus.Track.TrackResource.Name;
            lblArtist.Text = _spotifyStatus.Track.ArtistResource.Name;
            pictureBox1.Image = _spotifyStatus.Track.GetAlbumArt(SpotifyAPI.Local.Enums.AlbumArtSize.Size160);
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

            _spotifyStatus = _spotify.GetStatus();

            isPlaying = _spotifyStatus.Playing ? true : false;

            lblTrack.Text = _spotifyStatus.Track.TrackResource.Name;
            lblArtist.Text = _spotifyStatus.Track.ArtistResource.Name;
            pictureBox1.Image = _spotifyStatus.Track.GetAlbumArt(SpotifyAPI.Local.Enums.AlbumArtSize.Size160);
        }

        private void tUpdate_Tick(object sender, EventArgs e)
        {
            _spotifyStatus = _spotify.GetStatus();

            int trackLength = _spotifyStatus.Track.Length;
            int trackPosition = (int)_spotifyStatus.PlayingPosition;
            float trackStep = (float)MainForm.ActiveForm.Width / trackLength;
            float barWidth = trackPosition * trackStep;

            pBoxPlayBar.Width = (int)barWidth;


        }
    }
}
