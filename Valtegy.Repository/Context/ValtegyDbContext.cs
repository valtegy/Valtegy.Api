using Microsoft.EntityFrameworkCore;

namespace Valtegy.Repository.Context
{
    public class ValtegyDbContext : DbContext
    {
        public DbSet<Domain.Entities.Activities> Activities { get; set; }
        public DbSet<Domain.Entities.Notification> Notifications { get; set; }
        public DbSet<Domain.Entities.ActivityType> ActivityType { get; set; }
        public DbSet<Domain.Entities.StatusActivity> StatusActivity { get; set; }
        public ValtegyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
