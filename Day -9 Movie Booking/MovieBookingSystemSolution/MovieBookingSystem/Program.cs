using MovieBookingBLLibery.Interfaces;
using MovieBookingBLLibery.Services;
using MovieBookingDALLibery.Repositories;
using MovieBookingModelLibery;
using MovieBookingPLLibery.ConsoleServices;
using MovieBookingPLLibery.Interfaces;

namespace MovieBookingSystem
{
    internal class Program
    {
        static void HandleBookTickets(ConsoleOperations consoleOperations,BookingService bookingService, UserService userService,MovieService movieService,ScreeningService screeningService)
        {
            bool exit = false;
            while (!exit)
            {
                consoleOperations.DisplayBookingMenu();
                int bookingMenuChoice = consoleOperations.GetUserChoice(1, 8);
                switch (bookingMenuChoice)
                {
                    case 1:
                        consoleOperations.GetALLScreening(screeningService);
                        break;
                    case 2:
                        consoleOperations.AddBooking(bookingService, userService, movieService, screeningService);
                        break;
                    case 3:
                        // Update Booking
                        // Implement logic to update an existing booking
                        break;
                    case 4:
                        consoleOperations.DeleteBooking(bookingService);
                        break;
                    case 5:
                        consoleOperations.GetALLBooking(bookingService);
                        break;
                    case 6:
                        consoleOperations.GetBookingById(bookingService);
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void HandleManageScreenings(ConsoleOperations consoleOperations, ScreeningService screeningService, MovieService movieService)
        {
            bool exit = false;
            while (!exit)
            {
                consoleOperations.DisplayScreeningManagementMenu();
                int screeningMenuChoice = consoleOperations.GetUserChoice(1, 8);

                switch (screeningMenuChoice)
                {
                    case 1:
                        consoleOperations.AddScreening(movieService, screeningService);
                        break;
                    case 2:
                        Console.WriteLine("Not implemented yet");
                        break;
                    case 3:
                        consoleOperations.DeleteScreening(screeningService);
                        break;
                    case 4:
                        consoleOperations.GetALLScreening(screeningService);
                        break;
                    case 5:
                        consoleOperations.GetScreeningsByMovie(screeningService);
                        break;
                    case 6:
                        consoleOperations.GetScreeningsByDate(screeningService);
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void HandleManageMovies(ConsoleOperations consoleOperations, MovieService movieService)
        {
            bool exit = false;
            while (!exit)
            {
                consoleOperations.DisplayMovieManagementMenu();
                int movieMenuChoice = consoleOperations.GetUserChoice(1, 6);

                switch (movieMenuChoice)
                {
                    case 1:
                        consoleOperations.AddMovie(movieService);
                        break;
                    case 2:
                        consoleOperations.GetMovieById(movieService);
                        break;
                    case 3:
                        consoleOperations.GetALLMovie(movieService);
                        break;
                    case 4:
                        consoleOperations.DeleteMovie(movieService);
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void HandleManageUser(ConsoleOperations consoleOperations, UserService userService)
        {
            bool exit = false;
            while (!exit)
            {
                consoleOperations.DisplayUserManagementMenu();
                int userMenuChoice = consoleOperations.GetUserChoice(1, 5);

                switch (userMenuChoice)
                {
                    case 1:
                        consoleOperations.RegisterUser(userService);
                        break;
                    case 2:
                        consoleOperations.GetUserById(userService);
                        break; 
                    case 3:
                        consoleOperations.GetAllUser(userService);
                        break;
                    
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            MovieRepository movieRepository = new MovieRepository();
            UserRepository userRepository = new UserRepository();
            ScreeningRepository screeningRepository = new ScreeningRepository();
            BookingRepository bookingRepository = new BookingRepository();
            MovieService movieService = new MovieService(movieRepository);
            UserService userService = new UserService(userRepository);
            ScreeningService screeningService = new ScreeningService(screeningRepository);
            BookingService bookingService = new BookingService(bookingRepository);

            ConsoleOperations consoleOperations = new ConsoleOperations();

            bool isRunning = true;
            while (isRunning)
            {
                consoleOperations.DisplayMainMenu();
                int mainMenuChoice = consoleOperations.GetUserChoice(1, 6);

                switch (mainMenuChoice)
                {
                    case 1:
                        HandleBookTickets(consoleOperations, bookingService,userService, movieService, screeningService);
                        break;
                    case 2:
                        HandleManageUser(consoleOperations, userService);
                        break;
                    case 3:
                         HandleManageMovies(consoleOperations, movieService);
                        break;
                    case 4:
                        HandleManageScreenings(consoleOperations, screeningService, movieService);
                        break;
                    case 5:
                        isRunning = false;
                        break;
                }
            }

            Console.WriteLine("Thank you for using the movie booking system. Goodbye!");
        }
    }
}
