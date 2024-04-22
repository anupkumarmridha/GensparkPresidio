using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingDALLibery.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public List<Booking> GetBookingsByCustomer(int customerId)
        {
            return _data.Values.Where(booking => booking.Customer.Id == customerId).ToList();
        }

        public List<Booking> GetBookingsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _data.Values.Where(booking => booking.BookingTime >= startDate && booking.BookingTime <= endDate).ToList();
        }

        public List<Booking> GetBookingsByMovie(int movieId)
        {
            return _data.Values.Where(booking => booking.Movie.Id == movieId).ToList();
        }
    }
}
