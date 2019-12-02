namespace Smallify.Core.Spotify.Models
{
    public class ProfileResponse : BasicResponse
    {
        public string DisplayName { get; }
        public string Username { get; }

        public ProfileResponse(string errorMessage) : base(errorMessage)
        {
            DisplayName = string.Empty;
            Username = string.Empty;
        }

        public ProfileResponse(string displayName, string username) : base()
        {
            DisplayName = displayName;
            Username = username;
        }
    }
}
