using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class WebinarRepository : Repository<Webinar>, IWebinarRepository
{
    public WebinarRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}