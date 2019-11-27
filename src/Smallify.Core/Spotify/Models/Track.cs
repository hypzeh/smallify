namespace Smallify.Core.Spotify.Models
{
    public class Track
    {
        public string Name { get; }
        public string Artist { get; }
        public string Album { get; }
        public string AlbumArt { get; }
        public int Duration { get; }

        public Track()
        {
            Name = string.Empty;
            Artist = string.Empty;
            Album = string.Empty;
            AlbumArt = string.Empty;
            Duration = 0;
        }

        public Track(string name, string artist, string album, string albumArt, int duration)
        {
            Name = name;
            Artist = artist;
            Album = album;
            AlbumArt = albumArt;
            Duration = duration;
        }
    }
}
