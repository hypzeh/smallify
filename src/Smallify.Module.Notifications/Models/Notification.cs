using System;

namespace Smallify.Module.Notifications.Models
{
	public class Notification : INotification
	{
		public Notification(string message)
		{
			TimeStamp = DateTimeOffset.UtcNow;
			Message = message;
		}

		public DateTimeOffset TimeStamp { get; }

		public string Message { get; }
	}
}
