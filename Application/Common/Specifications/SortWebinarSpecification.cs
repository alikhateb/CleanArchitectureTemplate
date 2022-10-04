﻿using Application.Abstractions;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Common.Specifications;

public sealed class SortWebinarSpecification : Specification<Webinar>
{
    public SortWebinarSpecification(Expression<Func<Webinar, object>> orderBy)
    {
        ApplyOrderBy(orderBy);
    }
}