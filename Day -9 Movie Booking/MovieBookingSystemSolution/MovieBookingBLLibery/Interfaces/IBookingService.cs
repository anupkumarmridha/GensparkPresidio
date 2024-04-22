using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingBLLibery.Interfaces
{
    public interface IBookingService:IRepository<Booking>
    {
        List<Booking> GetBookingsByCustomer(int customerId);
        List<Booking> GetBookingsByDateRange(DateTime startDate, DateTime endDate);
        List<Booking> GetBookingsByMovie(int movieId);
    }
}
