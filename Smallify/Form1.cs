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

        private void btnSkip_Click(object sender, EventArgs e)
        {
            _spotify.Skip();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _spotify.Previous();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var model = _spotify.GetStatus();

            label1.Text = model.Track.TrackResource.Name + " - " + model.Track.ArtistResource.Name;
        }
    }
}
