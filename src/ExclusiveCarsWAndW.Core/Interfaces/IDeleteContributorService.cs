using Ardalis.Result;

namespace ExclusiveCarsWAndW.Core.Interfaces;

public interface IDeleteContributorService
{
    public Task<Result> DeleteContributor(int contributorId);
}
