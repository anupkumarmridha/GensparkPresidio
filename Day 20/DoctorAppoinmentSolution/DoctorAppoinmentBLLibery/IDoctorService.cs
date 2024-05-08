using DoctorAppoinmentModelLibery.Model;

namespace DoctorAppoinmentBLLibery
{
    public interface IDoctorService
    {
        Doctor AddDoctor(Doctor doctor);
        Doctor GetDoctorById(int id);
        Doctor UpdateDoctor(Doctor doctor);
        bool DeleteDoctor(int id);
        List<Doctor> GetAllDoctors();
        List<Doctor> SearchDoctors(string keyword);
    }
}
