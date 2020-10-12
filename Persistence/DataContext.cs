using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistence
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Value> Values { get; set; }

        public DbSet<Activity> Activities { get; set; }

        #region LOGGING CONFIGURATION
        // https://stackoverflow.com/questions/58259520/iloggerfactory-does-not-contain-a-definition-for-addconsole
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
                .HasData(
                    new Value { Id = 1, Name = "Value 001" },
                    new Value { Id = 2, Name = "Value 002" },
                    new Value { Id = 3, Name = "Value 003" }
                );
        }
    }
}
