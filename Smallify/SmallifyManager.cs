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
        public string currentTrackName;
        public string currentArtistName;
        public Bitmap currentLargeCover;
        public int currentTrackPosition;
        public int currentTrackLength;
        public bool isTrackPlaying;


        private static SpotifyLocalAPI _spotify;
        private static StatusResponse _spotifyStatus;
        private Track _currentTrack;
        private bool _isAdPlaying;


        public SmallifyManager()
        {
            _spotify = new SpotifyLocalAPI();
            _spotifyStatus = new StatusResponse();

            // Initialise default values for Track informaiton
            currentTrackName = "Track";
            currentArtistName = "Artist";
            currentLargeCover = Properties.Resources.icon_smallify;

            // IF Spotify is NOT running, run Spotify
            if (!SpotifyLocalAPI.IsSpotifyRunning())
            {
                SpotifyLocalAPI.RunSpotify();
                Thread.Sleep(TimeSpan.FromSeconds(5));
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

            // Get Spotify status & Set Spotify Events
            _spotifyStatus = _spotify.GetStatus();
            _spotify.OnTrackChange += _spotify_OnTrackChange;
            _spotify.OnPlayStateChange += _spotify_OnPlayStateChange;
            _spotify.OnTrackTimeChange += _spotify_OnTrackTimeChange;

            _spotify.ListenForEvents = true;

            // Update Track Information
            UpdateTrack();
        }

        public void PlayPause()
        {
            if (isTrackPlaying)
            {
                isTrackPlaying = false;
                _spotify.Pause();
            }
            else
            {
                isTrackPlaying = true;
                _spotify.Play();
            }
        }

        public void Skip()
        {
            isTrackPlaying = true;
            _spotify.Skip();
        }

        public void Previous()
        {
            isTrackPlaying = true;
            _spotify.Previous();
        }

        private void _spotify_OnTrackChange(object sender, TrackChangeEventArgs e)
        {
            if (_isAdPlaying)
            {
                return;
            }

            UpdateTrack();
        }

        private void _spotify_OnPlayStateChange(object sender, PlayStateEventArgs e)
        {
            if (_isAdPlaying)
            {
                return;
            }

            isTrackPlaying = e.Playing;

            UpdateTrack();
        }

        private void _spotify_OnTrackTimeChange(object sender, TrackTimeChangeEventArgs e)
        {
            if (_isAdPlaying)
            {
                return;
            }

            currentTrackPosition = (int)e.TrackTime;
        }

        private async void UpdateTrack()
        {
            // Get Spotify status as response
            StatusResponse spotifyStatus = _spotify.GetStatus();

            // IF status or track is null
            if (spotifyStatus == null || spotifyStatus.Track == null)
            {
                // Assume an Advert is playing
                //_currentTrack = null;
                _isAdPlaying = true;
                return;
            }
            else
            {
                // ELSE make sure to update "isAdPlaying" status in the case track is resumed after an advert
                _isAdPlaying = false;
            }

            // Update current Track & get Track album cover art
            _currentTrack = spotifyStatus.Track;
            currentLargeCover = await _currentTrack.GetAlbumArtAsync(AlbumArtSize.Size640);

            // IF the updated Track is not null
            if (_currentTrack != null)
            {
                // Save Track information
                currentTrackName = _currentTrack.TrackResource.Name;
                currentArtistName = _currentTrack.ArtistResource.Name;
                currentTrackLength = _currentTrack.Length;
                currentTrackPosition = (int)spotifyStatus.PlayingPosition;
            }
        }

        /*
        public int TimeToPixels(int maxWidth)
        {
            int trackLength = currentTrack.Length;
            int trackPosition = (int)_spotifyStatus.PlayingPosition;
            float trackStep = (float)maxWidth / trackLength;
            float barWidth = trackPosition * trackStep;

            return (int)barWidth;
        }
        */

    }
}
