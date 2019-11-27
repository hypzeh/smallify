namespace Smallify.Core.Spotify.Models
{
    public class PlaybackResponse : BasicResponse
    {
        public bool IsPlaying { get; }
        public int Progress { get; }
        public Track Track { get; }

        public PlaybackResponse(string errorMessage) : base(errorMessage)
        {
            IsPlaying = false;
            Progress = 0;
            Track = new Track();
        }

        public PlaybackResponse(bool isPlaying, int progress, Track track) : base()
        {
            IsPlaying = isPlaying;
            Progress = progress;
            Track = track;
        }
    }
}
