using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AzureFunctionExample.ResourceAccess.DataAccess
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Order> Order { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
               .HasMany(o => o.Orders)
               .WithOne(p => p.Person)
               .HasForeignKey(o => o.PersonID);
        }

        public static OrderDbContext GetInstance(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<OrderDbContext>().UseSqlServer(connectionString);
            return new OrderDbContext(builder.Options);
        }
    }
}
