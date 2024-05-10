using RequestTrackerModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class AdminRequestBL : IAdminRequestBL
    {
        public Task<RequestSolution> AddRequestSolutionByAdmin(int requestId, string SolutionDescription)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkedRequestCloseByAdmin(int requestId)
        {
            throw new NotImplementedException();
        }
    }
}
