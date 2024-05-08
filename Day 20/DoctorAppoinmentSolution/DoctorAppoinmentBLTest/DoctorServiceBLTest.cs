using DoctorAppoinmentBLLibery;
using DoctorAppoinmentDALLibery;
using DoctorAppoinmentModelLibery.Model;

namespace DoctorAppoinmentBLTest
{
    public class DoctorServiceBLTest
    {
        private IDoctorRepository _doctorRepository;
        private IDoctorService _doctorService;
        [SetUp]
        public void Setup()
        {
            _doctorRepository = new DoctorRepository(new DBDoctorAppoinmentContext());
            _doctorService = new DoctorBL(_doctorRepository);
        }

        [Test]
        public void AddDoctor_ValidDoctor_ReturnsDoctor()
        {
            // Arrange
            var doctor = new Doctor
            {
                Name = "John Doe",
                Email = "john@gmail.com",
                Specialization = "Cardiology",
                Gender = "Male",
                DateOfBirth = new DateTime(1985, 5, 15)
            };

            // Act
            Doctor savedDoctor = _doctorService.AddDoctor(doctor);
            //Console.WriteLine(savedDoctor);
            // Assert
            Assert.IsNotNull(savedDoctor);
        }

        [Test]
        public void AddDoctor_NullDoctor_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _doctorService.AddDoctor(null));
        }

        [Test]
        public void DeleteDoctor_ExistingDoctor_ReturnsTrue()
        {
            // Arrange
            var doctor = new Doctor
            {
                Name = "Jane Smith",
                Specialization = "Pediatrics",
                Email = "jane@gmail.com",
                Gender = "Female",
                DateOfBirth = new DateTime(1978, 10, 25)
            };
            Doctor savedDoctor = _doctorService.AddDoctor(doctor);

            //Console.WriteLine(savedDoctor.ToString());
            // Act
            bool result = _doctorService.DeleteDoctor(savedDoctor.Id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteDoctor_NonExistingDoctor_ThrowsDoctorNotFoundException()
        {
            // Arrange, Act & Assert
            Assert.Throws<DoctorNotFoundException>(() => _doctorService.DeleteDoctor(9999));
        }

        [Test]
        public void GetDoctorById_ExistingDoctor_ReturnsDoctor()
        {
            // Arrange
            var doctor = new Doctor
            {
                Name = "David Brown",
                Specialization = "Orthopedics",
                Gender = "Male",
                DateOfBirth = new DateTime(1970, 8, 20)
            };
            Doctor savedDoctor = _doctorService.AddDoctor(doctor);

            // Act
            var retrievedDoctor = _doctorService.GetDoctorById(savedDoctor.Id);

            // Assert
            Assert.IsNotNull(retrievedDoctor);
            Assert.AreEqual(savedDoctor.Id, retrievedDoctor.Id);
        }

        [Test]
        public void GetDoctorById_NonExistingDoctor_ThrowsDoctorNotFoundException()
        {
            // Arrange, Act & Assert
            Assert.Throws<DoctorNotFoundException>(() => _doctorService.GetDoctorById(9999));
        }

        [Test]
        public void SearchDoctors_ExistingKeyword_ReturnsMatchingDoctors()
        {
            // Arrange
            var doctor1 = new Doctor
            {
                Name = "Michael Jordan",
                Specialization = "Dermatology",
                Gender = "Male",
                DateOfBirth = new DateTime(1965, 3, 12)
            };
            var doctor2 = new Doctor
            {
                Name = "Emily Parker",
                Specialization = "Psychiatry",
                Gender = "Female",
                DateOfBirth = new DateTime(1980, 7, 8)
            };
            _doctorService.AddDoctor(doctor1);
            _doctorService.AddDoctor(doctor2);

            // Act
            List<Doctor> searchResult = _doctorService.SearchDoctors("Emily");

            // Assert
            Assert.IsNotNull(searchResult);
            Assert.AreEqual(1, searchResult.Count);
            Assert.AreEqual("Emily Parker", searchResult[0].Name);
        }

        [Test]
        public void SearchDoctors_NonExistingKeyword_ReturnsEmptyList()
        {
            // Act
            List<Doctor> searchResult = _doctorService.SearchDoctors("NonExistingName");

            // Assert
            Assert.IsNotNull(searchResult);
            Assert.AreEqual(0, searchResult.Count);
        }

        [Test]
        public void UpdateDoctor_ExistingDoctor_ReturnsUpdatedDoctor()
        {
            // Arrange
            var doctor = new Doctor
            {
                Name = "John Smith",
                Email = "Jhon@gmail.com",
                Specialization = "Neurology",
                Gender = "Male",
                DateOfBirth = new DateTime(1975, 6, 18)
            };
            Doctor savedDoctor = _doctorService.AddDoctor(doctor);
            Assert.IsNotNull(savedDoctor);
            Assert.AreEqual("John Smith", savedDoctor.Name);
            
            doctor.Name = "Updated Name";
            var updatedDoctor = _doctorService.UpdateDoctor(doctor);

            // Assert
            Assert.IsNotNull(updatedDoctor);
            Assert.AreEqual("Updated Name", updatedDoctor.Name);
        }

        [Test]
        public void UpdateDoctor_NonExistingDoctor_ThrowsDoctorNotFoundException()
        {
            // Arrange
            var doctor = new Doctor
            {
                Id = 9999,
                Name = "Non Existing Doctor",
                Email = "doctor@gmail.com",
                Specialization = "Neurology",
                Gender = "Male",
                DateOfBirth = new DateTime(1975, 6, 18)
            };

            // Act & Assert
            Assert.Throws<DoctorNotFoundException>(() => _doctorService.UpdateDoctor(doctor));
        }

        [Test]
        public void UpdateDoctor_NullDoctor_ThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _doctorService.UpdateDoctor(null));
        }

        [Test]
        public void GetAllDoctors_ReturnsNonEmptyList()
        {
            // Arrange
            var doctor1 = new Doctor
            {
                Name = "John Doe",
                Email = "john@gmail.com",
                Specialization = "Cardiology",
                Gender = "Male",
                DateOfBirth = new DateTime(1985, 5, 15)
            };
            var doctor2 = new Doctor
            {
                Name = "Emily Parker",
                Email = "emily@gmail.com",
                Specialization = "Pediatrics",
                Gender = "Female",
                DateOfBirth = new DateTime(1978, 10, 25)
            };
            _doctorService.AddDoctor(doctor1);
            _doctorService.AddDoctor(doctor2);

            // Act
            List<Doctor> doctors = _doctorService.GetAllDoctors();

            // Assert
            Assert.IsNotNull(doctors);
            Assert.IsNotEmpty(doctors);
        }

        [Test]
        public void GetAllDoctors_ThrowsException()
        {
            var exception = Assert.Throws<Exception>(() => _doctorService.GetAllDoctors());
            Assert.AreEqual("No doctors available.", exception.Message);
        }
    }

}