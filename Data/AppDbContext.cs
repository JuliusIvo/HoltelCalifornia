using HotelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(o => new
            {
                o.OrderId
            });

            modelBuilder.Entity<User>().HasKey(u => new
            {
                u.UserId

            });
            modelBuilder.Entity<Room>().HasKey(r => new
            {
                r.RoomId          
            });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }
}
