using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingDALLibery.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        List<Payment> GetPaymentsByCustomer(int customerId);
        List<Payment> GetPaymentsByBooking(int bookingId);
        List<Payment> GetPaymentsByStatus(PaymentStatus status);
    }
}
