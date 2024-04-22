using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingDALLibery.Interfaces
{
    public interface IMovieRepository:IRepository<Movie>
    {
        Movie GetMovieByTitle(string title);
        List<Movie> GetMoviesByGenre(string genre);
        List<Movie> GetMoviesByDuration(int duration);
        List<Movie> GetMoviesByTitle(string title);
        List<Movie> GetMoviesByScreeningTime(DateTime screeningTime);
    }
}
