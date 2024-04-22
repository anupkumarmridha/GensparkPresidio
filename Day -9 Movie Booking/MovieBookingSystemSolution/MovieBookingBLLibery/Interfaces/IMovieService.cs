using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingBLLibery.Interfaces
{
    public interface IMovieService:IMovieRepository
    {

        List<Movie> GetMoviesByDuration(int duration);
        List<Movie> GetMoviesByGenre(string genre);
        List<Movie> GetMoviesByScreeningTime(DateTime screeningTime);
        List<Movie> GetMoviesByTitle(string title);
    }
}
