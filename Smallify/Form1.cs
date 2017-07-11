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

        public Form1()
        {
            InitializeComponent();
            _spotify.Connect();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var model = _spotify.GetStatus();

            label1.Text = model.Track.TrackResource.Name + " - " + model.Track.ArtistResource.Name;
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
    }
}
