using SpotifyAPI.Local;
using SpotifyAPI.Local.Enums;
using SpotifyAPI.Local.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smallify
{
    public class SmallifyManager
    {
        public Track currentTrack;
        public Bitmap currentAlbumArt;
        public bool isAdPlaying;
        public bool isTrackPlaying;


        private static SpotifyLocalAPI _spotify;
        private static StatusResponse _spotifyStatus;

        // Smallify Manager
        public SmallifyManager()
        {
            _spotify = new SpotifyLocalAPI();
            _spotifyStatus = new StatusResponse();

            // IF Spotify is NOT running, run Spotify
            if (!SpotifyLocalAPI.IsSpotifyRunning())
            {
                SpotifyLocalAPI.RunSpotify();
                Thread.Sleep(5000);
            }

            // Attempt to connect with Spotify
            if (!_spotify.Connect())
            {
                // IF no connection made notify the user and ask to retry
                while (true)
                {
                    string msg = "Smallify couldn't connect to Spotify" +
                                    "\n\nDo you wish to retry?";
                    DialogResult dialogResult = MessageBox.Show(msg, "Connection Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // Retry to connect with Spotify
                        if (_spotify.Connect())
                        {
                            // IF connected with Spotify move on, else loop back round
                            break;
                        }  
                    }
                    else
                    {
                        // User refused to retry, close application
                        Application.Exit();
                        return;
                    }  
                }
            }

            // Get Spotify status
            _spotifyStatus = _spotify.GetStatus(); 
        }

        public async void UpdateTrack()
        {
            // Get Spotify status as response
            _spotifyStatus = _spotify.GetStatus();
            if (_spotifyStatus == null || _spotifyStatus.Track == null)
            {
                // IF status or track is null then assume an advert is playing
                isAdPlaying = true;
                return;
            }
            else
            {
                isAdPlaying = false;
            }
            
            // Get Track information and album art
            currentTrack = _spotifyStatus.Track;
            currentAlbumArt = await currentTrack.GetAlbumArtAsync(AlbumArtSize.Size640);
        }
    }
}
