using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Infrastructure.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseSqlServer(
                "Server=.;Database=clean_architecture_test;Trusted_Connection=True;",
                builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)
                );

            return new ApplicationDbContext(builder.Options);
        }
    }
}
