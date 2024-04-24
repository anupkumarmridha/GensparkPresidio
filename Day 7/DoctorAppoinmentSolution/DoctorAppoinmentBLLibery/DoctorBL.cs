using DoctorAppoinmentDALLibery;
using DoctorAppoinmentModelLibery;

namespace DoctorAppoinmentBLLibery
{
    public class DoctorBL : IDoctorService

    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorBL(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            ValidateDoctor(doctor);

            return _doctorRepository.Add(doctor);
        }

        public bool DeleteDoctor(int id)
        {
            var doctor = _doctorRepository.Get(id);
            if (doctor == null)
            {
                throw new DoctorNotFoundException($"Doctor with ID {id} not found.");
            }
            return _doctorRepository.Delete(id) != null;
        }

        public Doctor GetDoctorById(int id)
        {
            var doctor = _doctorRepository.Get(id);
            if (doctor == null)
            {
                throw new DoctorNotFoundException($"Doctor with ID {id} not found.");
            }
            return doctor;
        }

        public List<Doctor> SearchDoctors(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentException("Keyword cannot be null or empty.", nameof(keyword));
            }

            // Search doctors by name containing the keyword
            return _doctorRepository.GetAll().Where(d => d.Name.Contains(keyword)).ToList();
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            if (_doctorRepository.Get(doctor.Id) == null)
            {
                throw new DoctorNotFoundException($"Doctor with ID {doctor.Id} not found.");
            }

            ValidateDoctor(doctor);

            return _doctorRepository.Update(doctor);
        }

        private void ValidateDoctor(Doctor doctor)
        {
            if (string.IsNullOrWhiteSpace(doctor.Name))
            {
                throw new ArgumentException("Doctor name cannot be null or empty.", nameof(doctor));
            }

            if (string.IsNullOrWhiteSpace(doctor.Specialization))
            {
                throw new ArgumentException("Doctor specialization cannot be null or empty.", nameof(doctor));
            }

            if (!IsValidGender(doctor.Gender))
            {
                throw new ArgumentException("Invalid gender.", nameof(doctor));
            }

            if (doctor.DateOfBirth > DateTime.Now)
            {
                throw new ArgumentException("Invalid date of birth (cannot be in the future).", nameof(doctor));
            }
        }

        private bool IsValidGender(string gender)
        {
            return gender == "Male" || gender == "Female";
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            if (doctors == null || doctors.Count == 0)
            {
                throw new Exception("No doctors available.");
            }
            return doctors;
        }
    }
}
