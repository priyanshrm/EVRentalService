using EVRentalEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EVRentalDAL
{
    public class EVRentalDbContext:DbContext
    {
        public EVRentalDbContext(DbContextOptions<EVRentalDbContext> options) : base(options)
        {
        }
        public DbSet<BookingModel> booking { get; set; }

        public DbSet<EVModel> ev { get; set; }

        public DbSet<UserModel> user { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingModel>()
                .HasOne(b => b.UserModel)        // Booking has one user
                .WithMany(a => a.Bookings)       // User has many bookings
                .HasForeignKey(b => b.userId);   // Foreign key property


            modelBuilder.Entity<BookingModel>()
                .HasOne(b => b.EVModel)
                .WithMany(a => a.Bookings)
                .HasForeignKey(b => b.vehicleId);

            base.OnModelCreating(modelBuilder);
        }
        */


    }
}
