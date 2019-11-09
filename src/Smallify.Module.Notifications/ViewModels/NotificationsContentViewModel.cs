using Prism.Events;
using Prism.Mvvm;
using Smallify.Core.Events.Notifications;
using System.Collections.ObjectModel;

namespace Smallify.Module.Notifications.ViewModels
{
    internal class NotificationsContentViewModel : BindableBase
    {
        public ObservableCollection<string> Notifications { get; }

        public NotificationsContentViewModel(IEventAggregator eventAggregator)
        {
            Notifications = new ObservableCollection<string>();

            eventAggregator.GetEvent<OnNotificationCreatedEvent>()?.Subscribe(message => Notifications.Add(message));
        }
    }
}
