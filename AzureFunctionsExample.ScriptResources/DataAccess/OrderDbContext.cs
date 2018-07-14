using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AzureFunctionsExample.ScriptResources.DataAccess
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<OrderDbContext>(null);
        }
        
        public DbSet<Person> Person { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
               .HasMany(o => o.Orders)
               .WithRequired(p => p.Person)
               .HasForeignKey(o => o.PersonID);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
