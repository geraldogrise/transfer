using BR.ITAU.TRANSFER.API.Domain.Events;
using System;

namespace BR.ITAU.TRANSFER.API.Domain.Notifications
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public NotificationType Type { get; private set; }

        public DomainNotification(NotificationType type, string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Type = type;
            Key = key;
            Value = value;
        }
    }
}
