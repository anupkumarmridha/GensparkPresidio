using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingModelLibery
{
    public class Screening
    {
        public int Id { get; private set; }
        public DateTime StartTime { get; private set; }
        public int AvailableSeats { get; private set; }
        public decimal TicketPrice { get; private set; }
        public Movie Movie { get; private set; }

        public Screening(DateTime startTime, int availableSeats, decimal ticketPrice, Movie movie)
        {
            Id = 0;
            StartTime = startTime;
            AvailableSeats = availableSeats;
            TicketPrice = ticketPrice;
            Movie = movie;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Screening ID: {Id}");
            sb.AppendLine($"Start Time: {StartTime}");
            sb.AppendLine($"Available Seats: {AvailableSeats}");
            sb.AppendLine($"Ticket Price: ${TicketPrice}");

            if (Movie != null)
            {
                sb.AppendLine("Movie Details:");
                sb.AppendLine($"- Movie ID: {Movie.Id}");
                sb.AppendLine($"- Title: {Movie.Title}");
                sb.AppendLine($"- Genre: {Movie.Genre}");
                sb.AppendLine($"- Duration: {Movie.Duration} minutes");
            }
            else
            {
                sb.AppendLine("No movie details available.");
            }

            return sb.ToString();
        }

        public void UpdateAvailableSeats(int seats)
        {
            AvailableSeats = seats;
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
