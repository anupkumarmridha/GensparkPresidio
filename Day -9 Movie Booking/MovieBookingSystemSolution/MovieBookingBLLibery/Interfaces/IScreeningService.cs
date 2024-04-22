using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingBLLibery.Interfaces
{
    public interface IScreeningService:IRepository<Screening>
    {
        List<Screening> GetScreeningsByDate(DateTime date);
        List<Screening> GetScreeningsByMovie(int movieId);
        List<Screening> GetScreeningsWithAvailableSeats(int minSeats);
        List<Screening> GetScreeningsByMovieAndTime(int movieId, DateTime startTime);
    }
}
