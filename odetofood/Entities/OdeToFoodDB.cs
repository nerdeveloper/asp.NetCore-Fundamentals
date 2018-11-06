using System;
using Microsoft.EntityFrameworkCore;

namespace odetofood.Entities
{

   
    public class OdeToFoodDB: DbContext
    {

        public OdeToFoodDB(DbContextOptions options) : base(options)
        {

        } 
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
