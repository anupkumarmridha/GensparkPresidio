using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingModelLibery
{
    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed
    }
    public class Payment
    {
        public int Id { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime PaymentTime { get; private set; }
        public Booking Booking { get; private set; }
        public User User { get; private set; }
        public Payment(int id, decimal amount, PaymentStatus status, DateTime paymentTime, Booking booking, User user)
        {
            Id = id;
            Amount = amount;
            Status = status;
            PaymentTime = paymentTime;
            Booking = booking;
            User = user;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Payment ID: {Id}");
            sb.AppendLine($"Amount: ${Amount}");
            sb.AppendLine($"Status: {Status}");
            sb.AppendLine($"Payment Time: {PaymentTime}");

            if (Booking != null)
            {
                sb.AppendLine("Booking Details:");
                sb.AppendLine($"- Booking ID: {Booking.Id}");
                sb.AppendLine($"- Movie: {Booking.Movie.Title}");
                sb.AppendLine($"- Screening Time: {Booking.Screening.StartTime}");
                sb.AppendLine($"- Number of Tickets: {Booking.NumberOfTickets}");
                sb.AppendLine($"- Total Cost: ${Booking.TotalCost}");
            }
            else
            {
                sb.AppendLine("No booking details available.");
            }

            if (User != null)
            {
                sb.AppendLine("User Details:");
                sb.AppendLine($"- User ID: {User.Id}");
                sb.AppendLine($"- Username: {User.Username}");
                // Add other user details if needed
            }
            else
            {
                sb.AppendLine("No user details available.");
            }

            return sb.ToString();
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
