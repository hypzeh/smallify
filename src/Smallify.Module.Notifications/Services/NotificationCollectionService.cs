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
            Notifications = new ObservableCollection<Notification>()
            {
                new Notification("this is a test"),
                new Notification("yet another test..."),
                new Notification("yet another test1..."),
                new Notification("yet another test2..."),
                new Notification("yet another test3..."),
                new Notification("yet another test4..."),
                new Notification("yet another test5..."),
                new Notification("yet another test6..."),
                new Notification("yet another test7..."),
                new Notification("yet another test8..."),
                new Notification("yet another test9..."),
                new Notification("yet another test10..."),
                new Notification("yet another test11..."),
                new Notification("yet another test12..."),
                new Notification("yet another test13..."),
                new Notification("yet another test14..."),
                new Notification("yet another test15..."),
                new Notification("yet another test16..."),
                new Notification("yet another test17..."),
                new Notification("yet another test18..."),
                new Notification("yet another test19..."),
                new Notification("yet another test20..."),
                new Notification("yet another test21..."),
            };

            eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Subscribe(OnNotificationCreatedEvent);
        }

        private void OnNotificationCreatedEvent(string notification)
        {
            Notifications.Add(new Notification(notification));
        }
    }
}
