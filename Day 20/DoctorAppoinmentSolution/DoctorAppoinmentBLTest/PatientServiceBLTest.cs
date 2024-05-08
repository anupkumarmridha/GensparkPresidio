using DoctorAppoinmentBLLibery;
using DoctorAppoinmentDALLibery;
using DoctorAppoinmentModelLibery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentBLTest
{
    public class PatientServiceBLTest
    {
        private IPatientRepository _patientRepository;
        private IPatientService _patientService;
        [SetUp]
        public void Setup()
        {
            _patientRepository = new PatientRepository(new DBDoctorAppoinmentContext());
            _patientService = new PatientBL(_patientRepository);
        }
        [Test]
        public void AddPatient_ValidPatient_ReturnsPatient()
        {
            // Arrange
            var patient = new Patient
            {
                Name = "Minati Mridha",
                Email = "minati@gmail.com",
                Gender = "Female",
                DateOfBirth = new DateTime(1985, 5, 15)
            };
            // Act
            Patient savedPatient = _patientService.AddPatient(patient);
            // Assert
            Assert.IsNotNull(savedPatient);
        }
        [Test]
        public void AddPatient_NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _patientService.AddPatient(null));
        }
        [Test]
        public void DeletePatient_ExistingPatient_ReturnsTrue()
        {
            // Arrange
            var patient = _patientService.GetPatientById(2);
            // Act
            bool result = _patientService.DeletePatient(patient.Id);
            Assert.IsTrue(result);
        }
    }
}
