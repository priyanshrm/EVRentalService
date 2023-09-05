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
        
    }
}
