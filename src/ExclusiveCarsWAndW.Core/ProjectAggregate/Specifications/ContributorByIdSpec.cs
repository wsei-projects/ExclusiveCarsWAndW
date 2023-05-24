using Ardalis.Specification;
using ExclusiveCarsWAndW.Core.ContributorAggregate;

namespace ExclusiveCarsWAndW.Core.ProjectAggregate.Specifications;

public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  public ContributorByIdSpec(int contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
