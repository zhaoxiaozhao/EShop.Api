using EShop.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShop.Api
{
    public class EShopDbContext: DbContext
    {
        public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
