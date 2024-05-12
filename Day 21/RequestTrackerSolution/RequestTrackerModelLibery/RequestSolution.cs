using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibery
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

        public DateTime SolvedDate { get; set; }=DateTime.Now;
        public bool IsSolved { get; set; } = false;
        public string? RequestRaiserComment { get; set; }
        public string? SolutionFeedback { get; set; }

        public ICollection<SolutionFeedback> Feedbacks { get; set; }

        public RequestSolution(string solutionDescription, int requestId, int solvedBy)
        {
            SolutionDescription = solutionDescription;
            RequestId = requestId;
            SolvedBy = solvedBy;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"SolutionId: {SolutionId}");
            sb.AppendLine($"SolutionDescription: {SolutionDescription}");
            sb.AppendLine($"SolvedBy: {SolvedBy}");
            sb.AppendLine($"IsSolved: {IsSolved}");

            // Check if RequestRaiserComment is available
            if (RequestRaiserComment != null)
            {
                sb.AppendLine($"RequestRaiserComment: {RequestRaiserComment}");
            }
            else
            {
                sb.AppendLine("RequestRaiserComment: No comment");
            }

            return sb.ToString();
        }
    }
}
