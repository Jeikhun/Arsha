using Arsha.Models;
using Microsoft.EntityFrameworkCore;

namespace Arsha.Context
{
    public class ArshaDbContext:DbContext
    {

        public DbSet<Service> Services { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioCategory> portfolioCategories { get; set; }
        public ArshaDbContext(DbContextOptions<ArshaDbContext> options):base(options)
        {
                
        }
    }
}
