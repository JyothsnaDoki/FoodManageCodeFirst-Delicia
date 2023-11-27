using FoodManageCodeFirst.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodManageCodeFirst.Models
{
    public class FoodManagementContext : DbContext
    {
        public FoodManagementContext(DbContextOptions<FoodManagementContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public DbSet<Booking> Booking { get; set; }
       
        public DbSet<feed> Feed { get; set; }


    }
}


