using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<Webinar> Webinars { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
