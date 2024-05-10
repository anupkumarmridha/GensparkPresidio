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

        public DateTime SolvedDate { get; set; }
        public bool IsSolved { get; set; } = false;
        public string? RequestRaiserComment { get; set; }
        public string? SolutionFeedback { get; set; }

        public ICollection<SolutionFeedback> Feedbacks { get; set; }

    }
}
