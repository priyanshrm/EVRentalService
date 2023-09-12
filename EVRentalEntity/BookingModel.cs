using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVRentalEntity
{
    public class BookingModel

    {
        [Key]

        public int bookingId { get; set; }

        [ForeignKey("userId")]
        public int userId { get; set; }
        public UserModel User { get; set; }

        [ForeignKey("vehicleId")]
        public int vehicleId { get; set; }
        public EVModel EV { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endtime { get; set; }

        public double totalCost { get; set; }

        public string status { get; set; }

    }
}