using Microsoft.EntityFrameworkCore;

using TEK.Core.Entity;

namespace TEK.Core.ResourceAccess.EF
{
    public class DataContext : DbContext
    {
		public DbSet<Company> Companies { get; set; }

		public DbSet<OrderHeader> OrderHeaders { get; set; }

        public DbSet<ConfigValue> ConfigValues { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Company>().HasIndex(x => x.Name).IsUnique();
			modelBuilder.Entity<OrderHeader>().HasIndex(x => x.Number).IsUnique();

			base.OnModelCreating(modelBuilder);
		}
	}
}