using System.ComponentModel.DataAnnotations;

namespace EVRentalEntity
{
    public class UserModel
    {
        [Key]

        public int userId { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string firstName { get; set; }     

        public string lastName { get; set; }    

        public long phone { get; set; }
        //public ICollection<BookingModel>? Bookings { get; set; }
    }
}
