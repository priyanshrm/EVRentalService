using EVRentalEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRentalDAL.Repositories
{
    public interface IBookingRepository
    {
        Dictionary<string, object> AddBooking(BookingModel booking);
        Dictionary<string, object> GetAllBooking();
        Dictionary<string, object> GetBookingById(int id);
        Dictionary<string, object> DeleteAllBooking();
        Dictionary<string, object> DeleteBookingById(int id);
        Dictionary<string, object> UpdateBooking(BookingModel booking);
    }
}
