using EVRentalDAL.Repositories;
using EVRentalEntity;
using EVRentalEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVRentalBusiness.Service
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IElectricVehicleRepository _electricVehicleRepository;
        private readonly IUserRepository _userRepository;

        public BookingService(IBookingRepository bookingRepository, 
            IElectricVehicleRepository electricVehicleRepository, 
            IUserRepository userRepository)
        {
            _bookingRepository = bookingRepository;
            _electricVehicleRepository = electricVehicleRepository;
            _userRepository = userRepository;
        }

        public Dictionary<string, object> AddBooking(BookingModel booking)
        {
            var response = new Dictionary<string, object>();
            try
            {
                bool result = _bookingRepository.IsBookingTimeSlotAvailable(booking);
                if (result)
                    return _bookingRepository.AddBooking(booking);
                else
                    response["message"] = "The selected time slot is not available for booking.";
            }
            catch (Exception ex)
            {
                response["message"] = ex.Message;
            }
            return response;

        }
    }
}
