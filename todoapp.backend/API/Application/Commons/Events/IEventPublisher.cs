using Application.Commons.Interfaces;
using Domain.Primitives;

namespace Application.Commons.Events;

public interface IEventPublisher : ITransientService
{
    Task PublishAsync(DomainEvent @event);
}
