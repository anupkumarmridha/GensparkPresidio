using MovieBookingBLLibery.Interfaces;
using MovieBookingBLLibery.Services;
using MovieBookingModelLibery;
using MovieBookingPLLibery.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingPLLibery.ConsoleServices
{
    public class ConsoleOperations : IConsoleOpeartions
    {
        public void DisplayBookingMenu()
        {
            Console.WriteLine("Booking Menu:");
            Console.WriteLine("1. View Screenings");
            Console.WriteLine("2. Book Tickets");
            Console.WriteLine("3. Update Booking");
            Console.WriteLine("4. Cancel Booking");
            Console.WriteLine("5. View All Bookings");
            Console.WriteLine("6. View Booking Details");
            Console.WriteLine("7. Back to Main Menu");
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Book Tickets");
            Console.WriteLine("2. Manage User");
            Console.WriteLine("3. Manage Movies");
            Console.WriteLine("4. Manage Screening");
            Console.WriteLine("5. Exit");
        }

        public void DisplayMovieManagementMenu()
        {
            Console.WriteLine("Movie Management Menu:");
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. Get movie by Id");
            Console.WriteLine("3. Get All Movie");
            Console.WriteLine("4. Delete Movie");
            Console.WriteLine("5. Back to Main Menu");
        }

        public void DisplayMovieSearchMenu()
        {
            Console.WriteLine("Movie Search Menu:");
            Console.WriteLine("1. Search by Duration");
            Console.WriteLine("2. Search by Genre");
            Console.WriteLine("3. Search by Screening Time");
            Console.WriteLine("4. Search by Title");
            Console.WriteLine("5. Back to Main Menu");
        }
        public void DisplayMovies(IMovieService movieService)
        {

            try
            {
            Console.WriteLine("Movies:");
            List<Movie> movies = movieService.GetAll();
                if (movies != null && movies.Count > 0)
                {
                    Console.WriteLine("All movies:");
                    foreach (var movie in movies)
                    {
                        Console.WriteLine(movie.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No movies found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayUserManagementMenu()
        {
            Console.WriteLine("User Management Menu:");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Get User by Id");
            Console.WriteLine("3. GetAll users");
            Console.WriteLine("4. Back to Main Menu");
        }

        public int GetUserChoice(int minChoice, int maxChoice)
        {
            int choice;
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < minChoice || choice > maxChoice)
                {
                    Console.WriteLine($"Invalid input! Please enter a number between {minChoice} and {maxChoice}.");
                }
                else
                {
                    break;
                }
            }
            return choice;
        }

        private User BuildUserFromConsole()
        {
            string username = GetValidStringInput("Enter User username: ");
            string email = GetValidStringInput("Enter user email: ");
            return new User(username, email);
        }
        
       
        public int GetValidIntegerInput(string prompt)
        {
            int result;
            bool isValidInput = false;
            do
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out result);

                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            } while (!isValidInput);

            return result;
        }
        public string GetValidStringInput(string prompt)
        {
            string userInput;

            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Invalid input. Please enter a non-empty string.");
                }
            } while (string.IsNullOrWhiteSpace(userInput));

            return userInput;
        }

        public void RegisterUser(IUserService userService)
        {
            try
            {
                User newUser = BuildUserFromConsole();
                User savedUser = userService.Add(newUser);
                if (savedUser != null)
                {
                    Console.WriteLine("User Added Success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllUser(IUserService userService)
        {
            try
            {
                List<User> users = userService.GetAll();
                if (users.Count > 0)
                {
                    Console.WriteLine("All Users:");
                    foreach (var user in users)
                    {
                        Console.WriteLine(user.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No users found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateUser(IUserService userService)
        {
            throw new NotImplementedException();
        }

        private Movie BuildMovieFromConsole()
        {
            Console.WriteLine("Adding a New Movie");
            string title = GetValidStringInput("Enter the movie title: ");
            string genre = GetValidStringInput("Enter the movie genre: ");
            int duration = GetValidIntegerInput("Enter the movie duration (in minutes): ");
            return new Movie(title, genre, duration);
        }
        public void AddMovie(IMovieService movieService)
        {
            Movie newMovie = BuildMovieFromConsole();

            try
            {
                movieService.Add(newMovie);    
                Console.WriteLine("Movie added successfully!");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateMovie(IMovieService movieService)
        {
            try
            {
                int movieId = GetValidIntegerInput("Enter the ID of the movie to update: ");
                Movie existingMovie = movieService.GetById(movieId);
                if (existingMovie == null)
                {
                    Console.WriteLine("Movie not found.");
                    return;
                }

                Console.WriteLine("Enter updated movie details:");
                string title = GetValidStringInput("Title: ");
                string genre = GetValidStringInput("Genre: ");
                int duration = GetValidIntegerInput("Duration (in minutes): ");

                // Update the existing movie
                existingMovie.SetTitle(title);
                existingMovie.SetGenre(genre);
                existingMovie.SetDuration(duration);

                // Call the service to update the movie
                movieService.Update(existingMovie);

                Console.WriteLine("Movie updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void DeleteMovie(IMovieService movieService)
        {
            try
            {
                int id = GetValidIntegerInput("Enter the ID of the movie to delete: ");
                bool success = movieService.Delete(id);

                if (success)
                {
                    Console.WriteLine("Movie deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void GetALLMovie(IMovieService movieService)
        {
            try
            {
                List<Movie> movies = movieService.GetAll();

                if (movies.Count == 0)
                {
                    Console.WriteLine("No movies found.");
                }
                else
                {
                    foreach (var movie in movies)
                    {
                        Console.WriteLine(movie.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public Movie GetMovieById(IMovieService movieService)
        {
            try
            {
                int id = GetValidIntegerInput("Enter the ID of the movie: ");
                Movie movie = movieService.GetById(id);

                if (movie != null)
                {
                    Console.WriteLine(movie.ToString());
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                    return null;
                }
                return movie;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
        public Movie GetMovieByTitle(IMovieService movieService)
        {
            try
            {
                string title = GetValidStringInput("Enter the movie title: ");
                Movie movie= movieService.GetMovieByTitle(title);
                if(movie == null)
                {
                    return null;
                }
                return movie;

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void GetMoviesByDuration(IMovieService movieService)
        {
            throw new NotImplementedException();
        }

        public void GetMoviesByGenre(IMovieService movieService)
        {
            try
            {
                string genre = GetValidStringInput("Enter movie genre: ");
                List<Movie> movies = movieService.GetMoviesByGenre(genre);
                if (movies.Count == 0)
                {
                    Console.WriteLine("No movies found with the specified title.");
                }
                else
                {
                    for (int i = 0; i < movies.Count; i++)
                    {
                        Console.WriteLine($"Movie {i + 1}:");
                        Console.WriteLine(movies[i].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void GetMoviesByScreeningTime(IMovieService movieService)
        {
            try
            {
                DateTime screeningTime = GetValidDateTimeInput("Enter screening time (YYYY-MM-DD HH:MM): ");
                List<Movie> movies = movieService.GetMoviesByScreeningTime(screeningTime);
                if (movies.Count == 0)
                {
                    Console.WriteLine("No movies found with the specified title.");
                }
                else
                {
                    for (int i = 0; i < movies.Count; i++)
                    {
                        Console.WriteLine($"Movie {i + 1}:");
                        Console.WriteLine(movies[i].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void GetMoviesByTitle(IMovieService movieService)
        {
            try
            {
                string title = GetValidStringInput("Enter movie title: ");
                List<Movie> movies = movieService.GetMoviesByTitle(title);
                if (movies.Count == 0)
                {
                    Console.WriteLine("No movies found with the specified title.");
                }
                else
                {
                    for (int i = 0; i < movies.Count; i++)
                    {
                        Console.WriteLine($"Movie {i + 1}:");
                        Console.WriteLine(movies[i].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void DisplayScreeningManagementMenu()
        {
            Console.WriteLine("Screening Management Menu:");
            Console.WriteLine("1. Add Screening");
            Console.WriteLine("2. Update Screening");
            Console.WriteLine("3. Delete Screening");
            Console.WriteLine("4. GetAll Screening");
            Console.WriteLine("5. Get Screening by Movie");
            Console.WriteLine("6. Get Screening by Date");
            Console.WriteLine("7. Back to Main Menu");
        }
        private Screening BuildScreeningFromConsole(IMovieService movieService)
        {
            Console.WriteLine("Enter Screening Details:");
            Movie movie = GetMovieByTitle(movieService);
            DateTime startTime = GetValidDateTimeInput("Enter Screening Start Time (YYYY-MM-DD HH:MM): ");
            int availableSeats = GetValidIntegerInput("Enter Available Seats: ");
            decimal ticketPrice = GetValidDecimalInput("Enter Ticket Price: ");

            // Create a new Screening object
            Screening newScreening = new Screening(startTime, availableSeats, ticketPrice, movie);
            return newScreening;
        }
        private DateTime GetValidDateTimeInput(string prompt)
        {
            DateTime result;
            bool isValidInput = false;
            do
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                isValidInput = DateTime.TryParse(userInput, out result);

                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid date and time (YYYY-MM-DD HH:MM).");
                }
            } while (!isValidInput);

            return result;
        }
        private decimal GetValidDecimalInput(string prompt)
        {
            decimal result;
            bool isValidInput = false;
            do
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                isValidInput = decimal.TryParse(userInput, out result);

                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                }
            } while (!isValidInput);

            return result;
        }
        public void AddScreening(IMovieService movieService, IScreeningService screeningService)
        {
            try
            {
                Screening newScreening = BuildScreeningFromConsole(movieService);
                screeningService.Add(newScreening);

                if (newScreening != null)
                {
                    Console.WriteLine("Screening added successfully!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void UpdateScreening(IScreeningService screeningService)
        {
            throw new NotImplementedException();
        }

        public void DeleteScreening(IScreeningService screeningService)
        {
            try
            {
                int screeningId = GetValidIntegerInput("Enter the ID of the screening to delete: ");
                if (screeningService.Delete(screeningId))
                {
                    Console.WriteLine("Screening deleted successfully!");
                }
                else
                {
                    Console.WriteLine($"Screening with ID {screeningId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void GetALLScreening(IScreeningService screeningService)
        {
            try
            {
                List<Screening> screenings = screeningService.GetAll();
                if (screenings.Count == 0)
                {
                    Console.WriteLine("No screenings available.");
                }
                else
                {
                    Console.WriteLine("All Screenings:");
                    foreach (var screening in screenings)
                    {
                        Console.WriteLine(screening.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void GetScreeningsByDate(IScreeningService screeningService)
        {
            try
            {
                DateTime date = GetValidDateTimeInput("Enter the date (YYYY-MM-DD): ");
                List<Screening> screenings = screeningService.GetScreeningsByDate(date);

                if (screenings.Count == 0)
                {
                    Console.WriteLine("No screenings found for the specified date.");
                }
                else
                {
                    Console.WriteLine($"Screenings for {date.ToShortDateString()}:");
                    foreach (var screening in screenings)
                    {
                        Console.WriteLine(screening.ToString());
                       
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void GetScreeningsWithAvailableSeats(IScreeningService screeningService)
        {
            try
            {
                int minSeats = GetValidIntegerInput("Enter the minimum number of available seats: ");
                List<Screening> screenings = screeningService.GetScreeningsWithAvailableSeats(minSeats);
                if (screenings.Count == 0)
                {
                    Console.WriteLine("No screenings with available seats.");
                }
                else
                {
                    Console.WriteLine($"Screenings with Available Seats (Minimum Seats: {minSeats}):");
                    foreach (var screening in screenings)
                    {
                        Console.WriteLine(screening.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void GetScreeningsByMovie(IScreeningService screeningService)
        {
            try
            {
                int movieId = GetValidIntegerInput("Enter the movie Id: ");
                List<Screening> screenings = screeningService.GetScreeningsByMovie(movieId);

                if (screenings.Count == 0)
                {
                    Console.WriteLine($"No screenings found for the movie '{movieId}'.");
                }
                else
                {
                    Console.WriteLine($"Screenings for the movie '{movieId}':");
                    foreach (var screening in screenings)
                    {
                        Console.WriteLine(screening.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void GetUserById(IUserService userService)
        {
            try
            {
                int userId = GetValidIntegerInput("Enter the ID of the user: ");
                User user = userService.GetById(userId);
                if (user != null)
                {
                    Console.WriteLine("User Details:");
                    Console.WriteLine(user.ToString());
                }
                else
                {
                    Console.WriteLine($"User with ID {userId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DeleteUser(IUserService userService)
        {
            try
            {
                int userId = GetValidIntegerInput("Enter the ID of the user to delete: ");
                if (userService.Delete(userId))
                {
                    Console.WriteLine("User deleted successfully!");
                }
                else
                {
                    Console.WriteLine($"User with ID {userId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private Booking BuildBookingFromConsole(IUserService userService, IMovieService movieService, IScreeningService screeningService, IPaymentService paymentService)
        {
            Console.WriteLine("Enter Booking Details:");

            User user = null;
            while (user == null)
            {
                string username = GetValidStringInput("Enter customer username: ");
                try
                {
                    user = userService.GetUserByUsername(username);
                    if (user == null)
                    {
                        Console.WriteLine("User not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving user: {ex.Message}");
                }
            }

            Movie movie = null;
            while (movie == null)
            {
                string movieTitle = GetValidStringInput("Enter movie title: ");
                try
                {
                    movie = movieService.GetMovieByTitle(movieTitle);
                    if (movie == null)
                    {
                        Console.WriteLine("Movie not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving movie: {ex.Message}");
                }
            }

            // Get screening by movie and time
            Screening screening = null;
            while (screening == null)
            {
                DateTime startTime = GetValidDateTimeInput("Enter screening start time (YYYY-MM-DD HH:MM): ");
                try
                {
                    List<Screening> screenings = screeningService.GetScreeningsByMovieAndTime(movie.Id, startTime);
                    if (screenings == null || screenings.Count == 0)
                    {
                        Console.WriteLine("No screening found for the specified movie and time.");
                        continue;
                    }
                    screening = screenings[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving screening: {ex.Message}");
                }
            }

            int numberOfTickets = 0;
            while (numberOfTickets <= 0)
            {
                numberOfTickets = GetValidIntegerInput("Enter number of tickets: ");
                if (numberOfTickets <= 0)
                {
                    Console.WriteLine("Number of tickets must be greater than zero.");
                }
            }

            decimal totalCost = screening.TicketPrice * numberOfTickets;

            // Prompt for payment details
            Console.WriteLine("Enter Payment Details:");
            decimal paymentAmount = totalCost; 
            PaymentStatus paymentStatus = PaymentStatus.Pending;
            DateTime paymentTime = DateTime.Now;

            
            Payment newPayment = new Payment(0, paymentAmount, paymentStatus, paymentTime, null, user);
            Booking newBooking = new Booking(0, user, movie, screening, numberOfTickets, totalCost, DateTime.Now, newPayment);

            return newBooking;
        }
        public void AddBooking(IBookingService bookingService, IUserService userService, IMovieService movieService,IScreeningService screeningService, IPaymentService paymentService)
        {
            Booking newBooking = BuildBookingFromConsole(userService, movieService, screeningService, paymentService);
            if (newBooking != null)
            {
                bookingService.Add(newBooking);
                Console.WriteLine("Booking added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add booking.");
            }
        }

        public void UpdateBooking(IBookingService BookingService)
        {
            throw new NotImplementedException();
        }

        public void DeleteBooking(IBookingService bookingService)
        {
            try
            {
                int bookingId = GetValidIntegerInput("Enter the ID of the booking to delete: ");
                if (bookingService.Delete(bookingId))
                {
                    Console.WriteLine("Booking deleted successfully!");
                }
                else
                {
                    Console.WriteLine($"Booking with ID {bookingId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void GetALLBooking(IBookingService bookingService)
        {
            try
            {
                List<Booking> bookings = bookingService.GetAll();
                if (bookings.Count > 0)
                {
                    Console.WriteLine("All Bookings:");
                    foreach (var booking in bookings)
                    {
                        Console.WriteLine(booking.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No bookings found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void GetBookingById(IBookingService bookingService)
        {
            try
            {
                int bookingId = GetValidIntegerInput("Enter the ID of the booking: ");
                Booking booking = bookingService.GetById(bookingId);
                if (booking != null)
                {
                    Console.WriteLine("Booking Details:");
                    Console.WriteLine(booking.ToString());
                }
                else
                {
                    Console.WriteLine($"Booking with ID {bookingId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
