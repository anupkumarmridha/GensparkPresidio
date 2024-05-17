using System.ComponentModel.DataAnnotations;

namespace EmployeeRequestTrackerAPI.Models.DBModels
{
    public class RequestSolution
    {
        [Key]
        public int SolutionId { get; set; }

        public int RequestId { get; set; }

        public Request RequestRaised { get; set; }

        public string SolutionDescription { get; set; }

        public int SolvedBy { get; set; }

        public Employee SolvedByEmployee { get; set; }

        public DateTime SolvedDate { get; set; } = DateTime.Now;
        public bool IsSolved { get; set; } = false;
        public virtual string? RequestRaiserComment { get; set; }
        public virtual string? SolutionFeedback { get; set; }

        public ICollection<SolutionFeedback> Feedbacks { get; set; }

        public RequestSolution(string solutionDescription, int requestId, int solvedBy)
        {
            SolutionDescription = solutionDescription;
            RequestId = requestId;
            SolvedBy = solvedBy;
        }
    }
}
