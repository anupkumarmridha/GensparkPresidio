using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRManagementSystemModelLibery
{
    public class CTS : Employee, IGovtRules
    {
        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            CompanyName = "CTS";
        }

        public double EmployeePF(double basicSalary)
        {
            double employeeContribution = basicSalary * 0.0367;
            double companyContribution = basicSalary * 0.0833;
            return employeeContribution + companyContribution;
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted > 20)
                return 3 * basicSalary;
            else if (serviceCompleted > 10)
                return 2 * basicSalary;
            else if (serviceCompleted > 5)
                return basicSalary;
            else
                return 0;
        }

        public void LeaveDetails()
        {
            Console.WriteLine("1 day of Casual Leave per month" +
                "\n12 days of Sick Leave per year" +
                "\n10 days of Privilege Leave per year");
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
