using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingPLLibery.Interfaces
{
    internal interface IUtility
    {
      
        Booking BookTickets(Movie selectedMovie);
        void DisplayBookingConfirmation(Booking booking);
        void DisplayBookingsByCustomer(List<Booking> bookings);
        void DisplayBookingsByMovie(List<Booking> bookings);
        void DisplayBookingsByDateRange(List<Booking> bookings);
        void DisplayPaymentsByBooking(List<Payment> payments);
        void DisplayPaymentsByCustomer(List<Payment> payments);
        void DisplayPaymentsByStatus(List<Payment> payments);
        User Login();
        User Register();
        DateTime SelectScreeningTime(List<DateTime> screeningTimes);
        int EnterNumberOfTickets();
        Movie SelectMovie(List<Movie> movies);
    }
}
