using Ardalis.Specification;

namespace ExclusiveCarsWAndW.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
