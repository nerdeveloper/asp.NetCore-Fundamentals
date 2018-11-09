using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace odetofood.Entities
{

   
    public class OdeToFoodDB: IdentityDbContext<User>
    {

        public OdeToFoodDB(DbContextOptions options) : base(options)
        {
            this.Users.Where
        } 
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
