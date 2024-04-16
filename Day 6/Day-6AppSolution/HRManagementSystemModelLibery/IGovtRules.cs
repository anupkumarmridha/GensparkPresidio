using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystemModelLibery
{
    public interface IGovtRules
    {
        double EmployeePF(double basicSalary);
        void LeaveDetails();
        double GratuityAmount(float serviceCompleted, double basicSalary);
    }
}
