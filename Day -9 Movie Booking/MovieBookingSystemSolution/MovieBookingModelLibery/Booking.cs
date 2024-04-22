using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingModelLibery
{
    public class Booking
    {
        public int Id { get; private set; }
        public User Customer { get; private set; }
        public Movie Movie { get; private set; }
        public Screening Screening { get; private set; }
        public int NumberOfTickets { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime BookingTime { get; private set; }
        public Payment Payment { get; private set; }

        public Booking(int id, User customer, Movie movie, Screening screening, int numberOfTickets, decimal totalCost, DateTime bookingTime, Payment payment)
        {
            Id = id;
            Customer = customer;
            Movie = movie;
            Screening = screening;
            NumberOfTickets = numberOfTickets;
            TotalCost = totalCost;
            BookingTime = bookingTime;
            Payment = payment;
        }
        public override string ToString()
        {
            return $"Booking ID: {Id}\n" +
                   $"Customer: {Customer.Username}\n" +
                   $"Movie: {Movie.Title}\n" +
                   $"Screening Time: {Screening.StartTime}\n" +
                   $"Number of Tickets: {NumberOfTickets}\n" +
                   $"Total Cost: {TotalCost}\n" +
                   $"Booking Time: {BookingTime}\n";
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
