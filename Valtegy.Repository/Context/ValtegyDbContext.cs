using Microsoft.EntityFrameworkCore;

namespace Valtegy.Repository.Context
{
    public class ValtegyDbContext : DbContext
    {
        public DbSet<Domain.Entities.Activities> Activities { get; set; }
        public DbSet<Domain.Entities.Notification> Notifications { get; set; }
        public ValtegyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
