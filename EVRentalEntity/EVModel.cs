using System.ComponentModel.DataAnnotations;

namespace EVRentalEntity
{
    public class EVModel
    {
        [Key]
        public int vehicleId { get; set; }
        public string make { get; set; }

        public string model { get; set; }

        public int year { get; set; }

        public double batteryCapacity { get; set; }

        public double chargingTime { get; set; }

        public double rentalPrice { get; set; }

       // public ICollection<BookingModel>? Bookings { get; set; }

    }
}