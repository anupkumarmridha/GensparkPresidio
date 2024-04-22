using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingDALLibery.Interfaces
{
    public interface IBookingRepository:IRepository<Booking>
    {
        List<Booking> GetBookingsByCustomer(int customerId);
        List<Booking> GetBookingsByMovie(int movieId);
        List<Booking> GetBookingsByDateRange(DateTime startDate, DateTime endDate);
    }
}
