using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Repositories.Interfaces;
using DoctorAppoinmentAPI.Services.Interfaces;

namespace DoctorAppoinmentAPI.Services.Classes
{
    public class DoctorService:IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;
        public DoctorService(IDoctorRepository doctorRepository, IUserRepository userRepository)
        {
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _doctorRepository.GetAll();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _doctorRepository.GetById(id);
        }

        public async Task<Doctor> AddDoctor(int userId, string specialization)
        {
            var user = await _userRepository.GetById(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Check if the user has the Doctor role
            if (user.UserRole != Role.Doctor)
            {
                throw new Exception("User does not have the Doctor role");
            }

            // Create the doctor entity
            var doctor = new Doctor
            {
                UserId = userId,
                Specialization = specialization,
                User= user
            };

            // Add the doctor to the repository
            return await _doctorRepository.Add(doctor);
        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            return await _doctorRepository.Update(doctor);
        }

        public async Task<Doctor> DeleteDoctor(int id)
        {
            return await _doctorRepository.Delete(id);
        }
    }
}
