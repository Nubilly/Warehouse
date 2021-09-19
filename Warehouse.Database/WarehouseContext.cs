using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Warehouse.Database.Tables;

namespace Warehouse.Database
{
    public class WarehouseContext : IdentityDbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Bin>? Bins { get; set; }
        public DbSet<Item>? Items { get; set; }
    }
}