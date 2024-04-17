using DoctorAppoinmentModelLibery;
using System.Security.Cryptography.X509Certificates;

namespace DoctorAppoinmentDALLibery
{
    public class DoctorRepository
    {
        private readonly Repository<int, Doctor> _repository;

        public DoctorRepository()
        {
            _repository = new Repository<int, Doctor>();
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            return _repository.Add(doctor);
        }

        public Doctor DeleteDoctor(int id)
        {
            return _repository.Delete(id);
        }

        public Doctor GetDoctor(int id)
        {
            return _repository.Get(id);
        }

        public List<Doctor> GetAllDoctors()
        {
            return _repository.GetAll();
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            return _repository.Update(doctor);
        }
    }
}
