using DoctorConsoleApp.Models;

namespace DoctorConsoleApp
{
    internal class Program
    {

        /// <summary>
        /// Read only non numeric string from the console
        /// </summary>
        /// <param name="fieldName">Provide fieldName as string</param>
        /// <returns></returns>
        string ReadNonNumericStringFromConsole(string fieldName)
        {
            string input;
            do
            {
                Console.WriteLine($"Please enter {fieldName}:");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.Any(char.IsDigit))
                {
                    Console.WriteLine($"{fieldName} cannot be empty or contain numbers. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(input) || input.Any(char.IsDigit));

            return input;
        }

        /// <summary>
        /// Read Positive Integer only from the Console
        /// </summary>
        /// <param name="fieldName">Provide fieldName as string</param>
        /// <returns></returns>
        int ReadPositiveIntegerFromConsole(string fieldName)
        {
            int value;
            Console.WriteLine($"Please enter {fieldName}:");
            while(!int.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.WriteLine($"Invalid input for {fieldName}! Please enter a positive integer.");
            }
            return value;
        }



        /// <summary>
        /// Create Doctor object by taking input from console
        /// </summary>
        /// <param name="id">Provide Id as int</param>
        /// <returns></returns>
        Doctor CreateDoctorByTakingDetailsFromConsole(int id)
        {
            Doctor doctor = new(id);
            doctor.Name = ReadNonNumericStringFromConsole("Name");
            doctor.Age = ReadPositiveIntegerFromConsole("Age");
            doctor.ExperienceInYears = ReadPositiveIntegerFromConsole("Experience in years");
            doctor.Qualification = ReadNonNumericStringFromConsole("Qualification");
            doctor.Speciality = ReadNonNumericStringFromConsole("Speciality");
            return doctor;
        }



        static void Main(string[] args)
        {
            Program program = new();
            int n;
            Console.WriteLine("Please enter number of Doctors Details you want to add: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Invalid number! Please enter a valid number > 0:");
            }
            Doctor[] doctors = new Doctor[n];
            for (int i = 0; i < n; i++)
            {
                doctors[i]=program.CreateDoctorByTakingDetailsFromConsole(100+i);
            }

            for(int i = 0;i < doctors.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Details of Doctor Id {doctors[i].Id} ");
                doctors[i].DisplayDetails();
            }

        }
    }
}
