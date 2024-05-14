using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Repositories.Interfaces;
using DoctorAppoinmentAPI.Services.Interfaces;
namespace DoctorAppoinmentAPI.Services.Classes
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;

        public PatientService(IPatientRepository patientRepository, IUserRepository userRepository)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await _patientRepository.GetAll();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _patientRepository.GetById(id);
        }

        public async Task<Patient> AddPatient(int userId)
        {
            // Retrieve the associated user
            var user = await _userRepository.GetById(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Check if the user has the Patient role
            if (user.UserRole != Role.Patient)
            {
                throw new Exception("User does not have the Patient role");
            }

            // Create the patient entity
            var patient = new Patient
            {
                UserId = userId,
                User=user
            };

            // Add the patient to the repository
            return await _patientRepository.Add(patient);
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            return await _patientRepository.Update(patient);
        }

        public async Task<Patient> DeletePatient(int id)
        {
            return await _patientRepository.Delete(id);
        }
    }
}
