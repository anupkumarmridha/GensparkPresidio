using MovieBookingBLLibery.Interfaces;
using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingBLLibery.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public Payment Add(Payment entity)
        {
            if (entity == null || entity.Booking == null || entity.User == null || entity.Amount <= 0 || entity.PaymentTime == DateTime.MinValue)
            {
                throw new ArgumentException("Invalid payment details.");
            }
            return _paymentRepository.Add(entity);
        }

        public bool Delete(int id)
        {
            Payment paymentToDelete = GetById(id);
            if (paymentToDelete == null)
            {
                return false;
            }
            return _paymentRepository.Delete(id);
        }

        public List<Payment> GetAll()
        {
            return _paymentRepository.GetAll();
        }

        public Payment GetById(int id)
        {
            return _paymentRepository.GetById(id);
        }

        public List<Payment> GetPaymentsByBooking(int bookingId)
        {
            return _paymentRepository.GetPaymentsByBooking(bookingId);
        }

        public List<Payment> GetPaymentsByCustomer(int userId)
        {
            return _paymentRepository.GetPaymentsByCustomer(userId);
        }

        public List<Payment> GetPaymentsByStatus(PaymentStatus status)
        {
            return _paymentRepository.GetPaymentsByStatus(status);
        }

        public Payment Update(Payment entity)
        {
            if (GetById(entity.Id) == null)
            {
                throw new KeyNotFoundException($"Payment with ID {entity.Id} not found.");
            }
            return _paymentRepository.Update(entity);
        }
    }
}
