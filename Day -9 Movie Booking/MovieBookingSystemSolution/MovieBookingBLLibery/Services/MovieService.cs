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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public Movie Add(Movie entity)
        {
            if (_movieRepository.GetAll().Exists(m => m.Title.Equals(entity.Title, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Movie with title '{entity.Title}' already exists.");
            }
            return _movieRepository.Add(entity);
        }

        public bool Delete(int id)
        {
            Movie movieToDelete = GetById(id);
            if (movieToDelete == null)
            {
                return false;
            }
            return _movieRepository.Delete(id);
        }

        public List<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public Movie GetMovieByTitle(string title)
        {
            return _movieRepository.GetMovieByTitle(title);
        }

        public List<Movie> GetMoviesByDuration(int duration)
        {
            return _movieRepository.GetMoviesByDuration(duration);
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            return _movieRepository.GetMoviesByGenre(genre);
        }

        public List<Movie> GetMoviesByScreeningTime(DateTime screeningTime)
        {
            return _movieRepository.GetMoviesByScreeningTime(screeningTime);
        }

        public List<Movie> GetMoviesByTitle(string title)
        {
            return _movieRepository.GetMoviesByTitle(title);
        }

        public Movie Update(Movie entity)
        {
            if (GetById(entity.Id) == null)
            {
                throw new KeyNotFoundException($"Movie with ID {entity.Id} not found.");
            }
            return _movieRepository.Update(entity);
        }
    }
}
