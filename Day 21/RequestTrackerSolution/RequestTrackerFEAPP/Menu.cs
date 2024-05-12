using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    internal class Menu
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
        }

        public static void DisplayEmployeeMenu()
        {
            Console.WriteLine("1. View Request");
            Console.WriteLine("2. Add Request");
            Console.WriteLine("3. Update Request");
            Console.WriteLine("4. Delete Request");
            Console.WriteLine("5. View Solution");
            Console.WriteLine("6. Add Solution");
            Console.WriteLine("7. Update Solution");
            Console.WriteLine("8. Delete Solution");
            Console.WriteLine("9. View Feedback");
            Console.WriteLine("10. Add Feedback");
            Console.WriteLine("11. Update Feedback");
            Console.WriteLine("12. Delete Feedback");
            Console.WriteLine("13. Logout");
        }

        public static void DisplayAdminMenu()
        {
            Console.WriteLine("1. View Request");
            Console.WriteLine("2. Add Request");
            Console.WriteLine("3. Update Request");
            Console.WriteLine("4. Delete Request");
            Console.WriteLine("5. View Solution");
            Console.WriteLine("6. Add Solution");
            Console.WriteLine("7. Update Solution");
            Console.WriteLine("8. Delete Solution");
            Console.WriteLine("9. View Feedback");
            Console.WriteLine("10. Add Feedback");
            Console.WriteLine("11. Update Feedback");
            Console.WriteLine("12. Delete Feedback");
            Console.WriteLine("13. View Employee");
            Console.WriteLine("14. Add Employee");
            Console.WriteLine("15. Update Employee");
            Console.WriteLine("16. Delete Employee");
            Console.WriteLine("17. Logout");
        }
    }
}
