using Domain.Entities;

namespace Application.Common.Specifications.WebinarSpecifications;

public sealed class FindWebinarByIdSpecification : Specification<Webinar>
{
    public FindWebinarByIdSpecification(Guid id)
    {
        ApplyCriteria(webinar => webinar.Id == id);
    }
}