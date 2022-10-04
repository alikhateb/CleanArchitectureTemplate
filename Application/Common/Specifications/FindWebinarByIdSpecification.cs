using Application.Abstractions;
using Domain.Entities;

namespace Application.Common.Specifications;

public sealed class FindWebinarByIdSpecification : Specification<Webinar>
{
    public FindWebinarByIdSpecification(Guid id)
    {
        ApplyCriteria(webinar => webinar.Id == id);
    }
}