namespace Smallify.Core.Spotify.Models
{
    public abstract class BasicResponse
    {
        public string ErrorMessage { get; }

        protected BasicResponse()
        {
            ErrorMessage = string.Empty;
        }

        protected BasicResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public bool HasError()
        {
            return !string.IsNullOrEmpty(ErrorMessage);
        }
    }
}
