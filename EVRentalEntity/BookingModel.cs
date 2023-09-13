using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace EVRentalEntity
{
    public class BookingModel

    {
        [Key]
        public int bookingId { get; set; }
        public int userId { get; set; }
        //public UserModel UserModel { get; set; } 
        public int vehicleId { get; set; }
        //public EVModel EVModel { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endtime { get; set; }

        public double totalCost { get; set; }

        public string status { get; set; }

    }
}