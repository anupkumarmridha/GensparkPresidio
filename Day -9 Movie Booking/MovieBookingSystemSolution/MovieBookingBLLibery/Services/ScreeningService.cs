using MovieBookingBLLibery.Interfaces;
using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingBLLibery.Services
{
    public class ScreeningService : IScreeningService
    {
        private readonly IScreeningRepository _screeningRepository;

        public ScreeningService(IScreeningRepository screeningRepository)
        {
            _screeningRepository = screeningRepository;
        }

        private bool IsScreeningTimeConflict(Screening screening)
        {
            List<Screening> screeningsForMovie = _screeningRepository.GetScreeningsByMovie(screening.Movie.Id);
            foreach (var existingScreening in screeningsForMovie)
            {
                if (existingScreening.Id != screening.Id && existingScreening.StartTime == screening.StartTime)
                {
                    return true;
                }
            }

            return false;
        }

        public Screening Add(Screening entity)
        {
            if (IsScreeningTimeConflict(entity))
            {
                throw new InvalidOperationException($"Screening time conflicts with existing screenings.");
            }
            return _screeningRepository.Add(entity);
        }

        public bool Delete(int id)
        {
            Screening screeningToDelete = GetById(id);
            if (screeningToDelete == null)
            {
                return false;
            }
            return _screeningRepository.Delete(id);
        }

        public List<Screening> GetAll()
        {
            return _screeningRepository.GetAll();
        }

        public Screening GetById(int id)
        {
            return _screeningRepository.GetById(id);
        }

        public List<Screening> GetScreeningsByDate(DateTime date)
        {
            return _screeningRepository.GetScreeningsByDate(date);
        }

        public List<Screening> GetScreeningsByMovie(int movieId)
        {
            return _screeningRepository.GetScreeningsByMovie(movieId);
        }

        public List<Screening> GetScreeningsWithAvailableSeats(int minSeats)
        {
            return _screeningRepository.GetScreeningsWithAvailableSeats(minSeats);
        }

        public Screening Update(Screening entity)
        {
            if (GetById(entity.Id) == null)
            {
                throw new KeyNotFoundException($"Screening with ID {entity.Id} not found.");
            }

            if (IsScreeningTimeConflict(entity))
            {
                throw new InvalidOperationException($"Screening time conflicts with existing screenings.");
            }
            return _screeningRepository.Update(entity);
        }

        public List<Screening> GetScreeningsByMovieAndTime(int id, DateTime startTime)
        {
            return _screeningRepository.GetScreeningsByMovieAndTime(id, startTime);
        }
    }
}
