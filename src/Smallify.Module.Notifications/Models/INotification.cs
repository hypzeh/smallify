using System;

namespace Smallify.Module.Notifications.Models
{
	public interface INotification
	{
		DateTimeOffset TimeStamp { get; }

		string Message { get; }
	}
}