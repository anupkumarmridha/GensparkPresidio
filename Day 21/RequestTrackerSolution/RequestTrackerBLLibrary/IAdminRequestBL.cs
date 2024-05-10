using RequestTrackerModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    internal interface IAdminRequestBL
    {
        public Task<RequestSolution> AddRequestSolutionByAdmin(int requestId, string SolutionDescription);
        public Task<bool> MarkedRequestCloseByAdmin(int requestId);
    }
}
