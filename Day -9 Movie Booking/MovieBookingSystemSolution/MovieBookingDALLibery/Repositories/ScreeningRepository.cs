using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingDALLibery.Repositories
{
    public class ScreeningRepository : BaseRepository<Screening>, IScreeningRepository
    {
        public List<Screening> GetScreeningsByMovieAndTime(int movieId, DateTime startTime)
        {
            return _data.Values
                .Where(screening => screening.Movie.Id == movieId && screening.StartTime == startTime)
                .ToList();
        }
        public List<Screening> GetScreeningsByDate(DateTime date)
        {
            return _data.Values.Where(screening => screening.StartTime.Date == date.Date).ToList();
        }

        public List<Screening> GetScreeningsByMovie(int movieId)
        {
            return _data.Values.Where(screening => screening.Movie.Id == movieId).ToList();
        }

        public List<Screening> GetScreeningsWithAvailableSeats(int minSeats)
        {
            return _data.Values.Where(screening => screening.AvailableSeats >= minSeats).ToList();
        }
    }
}
