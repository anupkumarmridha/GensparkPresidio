using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Models.DBModels
{
    [Index(nameof(Email), IsUnique = true)]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }

        public string Role { get; set; } = "User";

        public virtual ICollection<Request>? RequestsRaised { get; set; }//No effect on the table
        public virtual ICollection<Request>? RequestsClosed { get; set; }//No effect on the table
        public virtual ICollection<RequestSolution>? SolutionsProvided { get; set; }
        public virtual ICollection<SolutionFeedback>? FeedbacksGiven { get; set; }
    }
}
