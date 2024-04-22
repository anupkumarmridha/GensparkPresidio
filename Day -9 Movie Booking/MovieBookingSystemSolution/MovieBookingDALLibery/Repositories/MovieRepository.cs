using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingDALLibery.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public Movie GetMovieByTitle(string title)
        {
            return _data.Values.FirstOrDefault(movie => movie.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public List<Movie> GetMoviesByDuration(int duration)
        {
            return _data.Values.Where(movie => movie.Duration == duration).ToList();
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            var genreToLower = genre.ToLower(); // Case-insensitive comparison
            return _data.Values.Where(movie => movie.Genre.ToLower() == genreToLower).ToList();
        }

        public List<Movie> GetMoviesByScreeningTime(DateTime screeningTime)
        {
            return _data.Values.Where(movie => movie.Screenings.Any(screening => screening.StartTime == screeningTime)).ToList();
        }

        public List<Movie> GetMoviesByTitle(string title)
        {
            var titleToLower = title.ToLower(); // Case-insensitive comparison
            return _data.Values.Where(movie => movie.Title.ToLower().Contains(titleToLower)).ToList();
        }
    }
 }
