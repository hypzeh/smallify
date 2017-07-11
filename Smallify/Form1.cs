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
    public partial class Form1 : Form
    {
        SpotifyLocalAPI _spotify = new SpotifyLocalAPI();
        bool isPlaying = false;

        public Form1()
        {
            InitializeComponent();
            _spotify.Connect();

            var model = _spotify.GetStatus();
            isPlaying = model.Playing ? true : false;

            label1.Text = model.Track.TrackResource.Name + " - " + model.Track.ArtistResource.Name;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var model = _spotify.GetStatus();

            label1.Text = model.Track.TrackResource.Name + " - " + model.Track.ArtistResource.Name;
            isPlaying = model.Playing ? true : false;
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
    }
}
