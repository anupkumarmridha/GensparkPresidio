using EmployeeRequestTrackerAPI.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Contexts
{
    public class RequestTrackerContext : DbContext
    {
        public RequestTrackerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>().HasKey(r => r.RequestNumber);
            modelBuilder.Entity<SolutionFeedback>().HasKey(r => r.FeedbackId);

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RaisedByEmployee)
               .WithMany(e => e.RequestsRaised)
               .HasForeignKey(r => r.RequestRaisedBy)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RequestClosedByEmployee)
               .WithMany(e => e.RequestsClosed)
               .HasForeignKey(r => r.RequestClosedBy)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RequestSolution>()
            .HasOne(rs => rs.RequestRaised)
            .WithMany(r => r.RequestSolutions)
            .HasForeignKey(rs => rs.RequestId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

            modelBuilder.Entity<RequestSolution>()
                .HasOne(rs => rs.SolvedByEmployee)
                .WithMany(e => e.SolutionsProvided)
                .HasForeignKey(rs => rs.SolvedBy)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<SolutionFeedback>()
            .HasOne(sf => sf.Solution)
            .WithMany(s => s.Feedbacks)
            .HasForeignKey(sf => sf.SolutionId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
            modelBuilder.Entity<SolutionFeedback>()
              .HasOne(sf => sf.FeedbackByEmployee)
              .WithMany(e => e.FeedbacksGiven)
              .HasForeignKey(sf => sf.FeedbackBy)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired();
        }
    }
}
