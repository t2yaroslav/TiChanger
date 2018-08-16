
using Microsoft.EntityFrameworkCore;

namespace TIC.Data
{
    public abstract class DataContextBase : IDataContext
    {
        protected DataContextBase(DbContextOptions options) : base(options)
        {
        }

//        public DbSet<HangfireJobSettings> HangfireJobSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new MetadataConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new ColorConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new PasswordHistoryConfiguration());
        }
    }
}