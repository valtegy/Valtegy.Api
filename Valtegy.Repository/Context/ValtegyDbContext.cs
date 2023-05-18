using Microsoft.EntityFrameworkCore;

namespace Valtegy.Repository.Context
{
    public class ValtegyDbContext : DbContext
    {
        public DbSet<Domain.Entities.Activities> Activities { get; set; }
        public DbSet<Domain.Entities.Users> Users { get; set; }
        public ValtegyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
