using System.ComponentModel.DataAnnotations;

namespace EmployeeRequestTrackerAPI.Models.DBModels
{
    public class Request
    {
        [Key]
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; } = "Open";
        public int RequestRaisedBy { get; set; }

        public Employee RaisedByEmployee { get; set; }

        public int? RequestClosedBy { get; set; }


        public Employee RequestClosedByEmployee { get; set; }
        public ICollection<RequestSolution> RequestSolutions { get; set; }

        public Request(string requestMessage, int requestRaisedBy)
        {
            RequestMessage = requestMessage;
            RequestRaisedBy = requestRaisedBy;
        }
    }
}
