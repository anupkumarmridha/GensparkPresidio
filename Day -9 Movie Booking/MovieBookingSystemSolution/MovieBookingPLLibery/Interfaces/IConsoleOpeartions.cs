using MovieBookingBLLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingPLLibery.Interfaces
{
    public interface IConsoleOpeartions
    {
        void DisplayMainMenu();
        void DisplayBookingMenu();
        void DisplayUserManagementMenu();
        void DisplayMovieManagementMenu();
        int GetUserChoice(int minChoice, int maxChoice);

        void RegisterUser(IUserService userService);
        void GetAllUser(IUserService userService);
        void UpdateUser(IUserService userService);
        void GetUserById(IUserService userService);
        void DeleteUser(IUserService userService);

        /// <summary>
        /// related to movies operations
        /// </summary>
        /// <param name="screeningService"></param>
        void AddMovie(IMovieService movieService);
        void UpdateMovie(IMovieService movieService);
        void DeleteMovie(IMovieService movieService);
        void GetALLMovie(IMovieService movieService);
        Movie GetMovieById(IMovieService movieService);
        void GetMoviesByDuration(IMovieService movieService);
        void GetMoviesByGenre(IMovieService movieService);
        void GetMoviesByScreeningTime(IMovieService movieService);
        void GetMoviesByTitle(IMovieService movieService);
        
        /// <summary>
        /// related to screening operations
        /// </summary>
        /// <param name="screeningService"></param>
        void AddScreening(IMovieService movieService, IScreeningService screeningService);
        void UpdateScreening(IScreeningService screeningService);
        void DeleteScreening(IScreeningService screeningService);
        void GetALLScreening(IScreeningService screeningService);
        void GetScreeningsByDate(IScreeningService screeningService);
        void GetScreeningsWithAvailableSeats(IScreeningService screeningService);
        void GetScreeningsByMovie(IScreeningService screeningService);

        /// <summary>
        /// For Booking Operations
        /// </summary>
        /// <param name="movieService"></param>
        void AddBooking(IBookingService BookingServic, IUserService userService, IMovieService movieService, IScreeningService screeningService);
        void UpdateBooking(IBookingService BookingService);
        void DeleteBooking(IBookingService mBookingervice);
        void GetALLBooking(IBookingService BookingService);
        void GetBookingById(IBookingService BookingService);

    }
}
