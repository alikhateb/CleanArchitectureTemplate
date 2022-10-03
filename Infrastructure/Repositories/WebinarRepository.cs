using Application.Common.Repositories;
using Domain.Entity;
using Infrastructure.Abstractions;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class WebinarRepository : Repository<Webinar>, IWebinarRepository
    {
        public WebinarRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
