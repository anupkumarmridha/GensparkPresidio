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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public Booking Add(Booking entity)
        {
            // Check if the customer associated with the booking exists
            if (entity.Customer == null)
            {
                throw new ArgumentException("Customer cannot be null when adding a booking.");
            }

            // Check if the movie associated with the booking exists
            if (entity.Movie == null)
            {
                throw new ArgumentException("Movie cannot be null when adding a booking.");
            }

            // Check if the screening associated with the booking exists
            if (entity.Screening == null)
            {
                throw new ArgumentException("Screening cannot be null when adding a booking.");
            }
            return _bookingRepository.Add(entity);
        }

        public bool Delete(int id)
        {
            Booking bookingToDelete = GetById(id);
            if (bookingToDelete == null)
            {
                return false;
            }
            return _bookingRepository.Delete(id);
        }

        public List<Booking> GetAll()
        {
            return _bookingRepository.GetAll();
        }

        public List<Booking> GetBookingsByCustomer(int customerId)
        {
            return _bookingRepository.GetBookingsByCustomer(customerId);
        }

        public List<Booking> GetBookingsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _bookingRepository.GetBookingsByDateRange(startDate, endDate);
        }

        public List<Booking> GetBookingsByMovie(int movieId)
        {
            return _bookingRepository.GetBookingsByMovie(movieId);
        }

        public Booking GetById(int id)
        {
            return _bookingRepository.GetById(id);
        }

        public Booking Update(Booking entity)
        {
            if (_bookingRepository.GetById(entity.Id) == null)
            {
                throw new KeyNotFoundException($"Booking with ID {entity.Id} not found.");
            }
            return _bookingRepository.Update(entity);
        }
    }
}
