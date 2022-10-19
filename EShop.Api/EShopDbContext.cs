using EShop.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EShop.Api
{
    public class EShopDbContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=www.facehand.cn,30023;Database=Master;User Id=sa;Password=Zztx!234;");
        }
    }
}
