using System;

namespace Smallify.Module.Notifications.Models
{
    internal class Notification
    {
        public string Message { get; }
        public DateTimeOffset Timestamp { get; }

        public Notification(string message)
        {
            Message = message;
            Timestamp = DateTimeOffset.UtcNow;
        }
    }
}
