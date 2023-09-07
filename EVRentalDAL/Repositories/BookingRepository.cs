using EVRentalEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRentalDAL.Repositories
{
    public class BookingRepository: IBookingRepository
    {
        private readonly EVRentalDbContext _db;

        public BookingRepository(EVRentalDbContext dbContext)
        {
            _db = dbContext;
        }

        public Dictionary<string, object> AddBooking(BookingModel booking)
        {
            var response = new Dictionary<string, object>();

            try
            {
                _db.booking.Add(booking);
                _db.SaveChanges();
                response["message"] = "inserted";
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;

        }

        public Dictionary<string, object> GetAllBooking()
        {
            var response = new Dictionary<string, object>();

            try
            {
                List<BookingModel> bookings = _db.booking.ToList();
                response["message"] = bookings;
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;
        }

        public Dictionary<string, object> GetBookingById(int id)
        {
            var response = new Dictionary<string, object>();

            try
            {
                BookingModel booking = _db.booking.Find(id);
                response["message"] = booking;
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;
        }

        public Dictionary<string, object> DeleteAllBooking()
        {
            var response = new Dictionary<string, object>();
            try
            {
                var bookings = _db.booking.ToList();
                foreach (var item in bookings)
                {
                    _db.booking.Remove(item);
                }
                _db.SaveChanges();
                var newBookings = _db.booking.ToList();
                response["message"] = newBookings;
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;
        }


        public Dictionary<string, object> DeleteBookingById(int id)
        {
            var response = new Dictionary<string, object>();
            try
            {
                BookingModel booking = _db.booking.Find(id);
                if (booking != null)
                {
                    _db.booking.Remove(booking);
                    _db.SaveChanges();
                    response["message"] = booking;
                }
                else
                {
                    response["message"] = "User Id not found";
                }
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;
        }

        public Dictionary<string, object> UpdateBooking(BookingModel booking)
        {
            var response = new Dictionary<string, object>();
            try
            {
                BookingModel book = _db.booking.Find(booking.bookingId);
                if (booking != null)
                {
                    _db.Entry(booking).State = EntityState.Modified; //update statement
                    _db.SaveChanges();
                    response["message"] = booking;
                }
                else
                {
                    response["message"] = "User Id not found";
                }
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;

        }
    }
}
