namespace Domain.Commons.Contracts;


public interface IEntity<TId>
{
    TId Id { get; }
}