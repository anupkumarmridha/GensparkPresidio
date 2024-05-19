using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual ICollection<Request> RequestsRaised { get; set; }//No effect on the table
        [JsonIgnore]
        public virtual ICollection<Request> RequestsClosed { get; set; }//No effect on the table
        [JsonIgnore]
        public virtual ICollection<RequestSolution> SolutionsProvided { get; set; }
        [JsonIgnore]
        public virtual ICollection<SolutionFeedback> FeedbacksGiven { get; set; }
    }
}
