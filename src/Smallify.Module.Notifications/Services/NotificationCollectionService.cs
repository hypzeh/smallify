using Prism.Events;
using Smallify.Core.Events.Notifications;
using System.Collections.ObjectModel;

namespace Smallify.Module.Notifications.Services
{
    internal class NotificationCollectionService
    {
        public ObservableCollection<string> Notifications { get; }

        public NotificationCollectionService(IEventAggregator eventAggregator)
        {
            Notifications = new ObservableCollection<string>();

            eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Subscribe(OnNotificationCreatedEvent);
        }

        private void OnNotificationCreatedEvent(string notification)
        {
            Notifications.Add(notification);
        }
    }
}
