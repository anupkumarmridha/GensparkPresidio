using HRManagementSystemModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem
{
    internal class EmployeeBenifits
    {
        public void ShowEmployeeBenifits(IGovtRules govtRules, double BasicSalary, float ServiceCompleted)
        {
            govtRules.EmployeePF(BasicSalary);
            govtRules.LeaveDetails();
            govtRules.GratuityAmount(ServiceCompleted, BasicSalary);
        }
    }
}
