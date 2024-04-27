﻿using Domain.Shared;

namespace Domain;

public abstract class DomainEvent : IEvent
{
    public DateTime TriggeredOn { get; protected set; } = DateTime.UtcNow;
}
