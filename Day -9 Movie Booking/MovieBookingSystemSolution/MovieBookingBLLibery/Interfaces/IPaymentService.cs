using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingBLLibery.Interfaces
{
    public interface IPaymentService:IRepository<Payment>
    {
        List<Payment> GetPaymentsByBooking(int bookingId);
        List<Payment> GetPaymentsByCustomer(int userId);
        List<Payment> GetPaymentsByStatus(PaymentStatus status);
    }
}
