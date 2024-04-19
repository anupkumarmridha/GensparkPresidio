using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibery
{
    public class DuplicateDepartmentIDException:Exception
    {
        string msg;
        public DuplicateDepartmentIDException()
        {
            string msg = "Department id already exist!";
        }
        public override string Message=>msg;
    }
}
