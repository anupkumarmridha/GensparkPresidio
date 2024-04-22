using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingDALLibery.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public List<Payment> GetPaymentsByBooking(int bookingId)
        {
            return _data.Values.Where(payment => payment.Booking.Id == bookingId).ToList();
        }

        public List<Payment> GetPaymentsByCustomer(int userId)
        {
            return _data.Values.Where(payment => payment.User.Id == userId).ToList();
        }

        public List<Payment> GetPaymentsByStatus(PaymentStatus status)
        {
            return _data.Values.Where(payment => payment.Status == status).ToList();
        }
    }
}
