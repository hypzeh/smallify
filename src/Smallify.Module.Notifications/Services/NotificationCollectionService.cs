using Prism.Events;
using Smallify.Core.Events.Notifications;
using Smallify.Module.Notifications.Models;
using System.Collections.ObjectModel;

namespace Smallify.Module.Notifications.Services
{
    internal class NotificationCollectionService
    {
        public ObservableCollection<Notification> Notifications { get; }

        public NotificationCollectionService(IEventAggregator eventAggregator)
        {
            Notifications = new ObservableCollection<Notification>();

            eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Subscribe(OnNotificationCreatedEvent_Published);
        }

        private void OnNotificationCreatedEvent_Published(string notification)
        {
            Notifications.Add(new Notification(notification));
        }
    }
}
