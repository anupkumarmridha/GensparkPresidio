using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystemModelLibery
{
    public class Accenture : Employee, IGovtRules
    {
        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            CompanyName = "Accenture";
        }
        public double EmployeePF(double basicSalary)
        {
            return basicSalary * 0.12;
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }

        public void LeaveDetails()
        {
            Console.WriteLine("2 days of Casual Leave per month" +
                "\n5 days of Sick Leave per year" +
                "\n5 days of Privilege Leave per year");
        }

        public override void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();

            Console.WriteLine("Company Name: " + CompanyName);

            // Check if the employee class implements IGovtRules
            if (this is IGovtRules govtEmployee)
            {
                Console.WriteLine("Employee PF: " + govtEmployee.EmployeePF(BasicSalary));
                Console.WriteLine("Leave Details:");
                govtEmployee.LeaveDetails();
                Console.WriteLine("Gratuity Amount: " + govtEmployee.GratuityAmount(ServiceCompleted, BasicSalary));
            }
        }
    }
}
