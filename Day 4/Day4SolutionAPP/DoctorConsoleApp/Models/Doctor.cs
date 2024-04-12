namespace DoctorConsoleApp.Models
{
    internal class Doctor
    {

        public int Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int ExperienceInYears { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }

        public Doctor(int id) => Id = id;

        /// <summary>
        /// Constractor to create a Doctor object
        /// </summary>
        /// <param name="id">Provide id as int</param>
        /// <param name="name">Provide Name as string</param>
        /// <param name="age">Provide Age as int</param>
        /// <param name="experienceInYears">Provide ExperienceInYears as int</param>
        /// <param name="qualification">Provide Qualification as string</param>
        /// <param name="speciality">Provide speciality as string</param>
        public Doctor(int id, string name, int age, int experienceInYears, string qualification, string speciality):this(id)
        {
            Name = name;
            Age = age;
            ExperienceInYears = experienceInYears;
            Qualification = qualification;
            Speciality = speciality;
        }

        /// <summary>
        /// Display the Doctor details
        /// </summary>
        public void DisplayDetails()
        {
            Console.WriteLine();
            Console.WriteLine($"Doctor ID:\t{Id}");
            Console.WriteLine($"Name:\t\t{Name}");
            Console.WriteLine($"Age:\t\t{Age}");
            Console.WriteLine($"Experience:\t{ExperienceInYears} years");
            Console.WriteLine($"Qualification:\t{Qualification}");
            Console.WriteLine($"Speciality:\t{Speciality}");
        }
    }
}