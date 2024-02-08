using System;

namespace Domain.Core.Events
{
    public class StoredEvent : Event
    {
        public StoredEvent(Event theEvent, string data, string user, int? userId, string userEmail)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            User = user;
            UserId = userId;
            UserEmail = userEmail;
        }

        public StoredEvent()
        {
        }

        public Guid Id { get; private set; }

        public string Data { get; }

        public string User { get; }
        public int? UserId { get; }
        public string UserEmail { get; }
    }
}