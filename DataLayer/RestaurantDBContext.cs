using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class RestaurantDBContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set;}    
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RestaurantCartItem> RestaurantCartItems { get; set; }

        public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options) : base(options) { }


        public class RestaurantDBContextFactory : IDesignTimeDbContextFactory<RestaurantDBContext>
        {
            public RestaurantDBContext CreateDbContext(string[] args)
            {
                var otionsBuilder = new DbContextOptionsBuilder<RestaurantDBContext>();
                otionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDbRestaurant;Trusted_Connection=True; MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));
                return new RestaurantDBContext(otionsBuilder.Options);
            }
        }
    }
}
