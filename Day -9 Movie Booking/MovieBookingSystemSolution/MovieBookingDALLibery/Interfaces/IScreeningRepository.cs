using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingDALLibery.Interfaces
{
    public interface IScreeningRepository : IRepository<Screening>
    {
        List<Screening> GetScreeningsByMovie(int movieId);
        List<Screening> GetScreeningsByDate(DateTime date);
        List<Screening> GetScreeningsWithAvailableSeats(int minSeats);
        List<Screening> GetScreeningsByMovieAndTime(int movieId, DateTime startTime);
    }
}
