using ISSUES_TRACKING_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ISSUES_TRACKING_API.Data
{
    public class IssuesTrackingDbContext : DbContext
    {
        public IssuesTrackingDbContext(DbContextOptions<IssuesTrackingDbContext> options) : base(options) { 
        }

        public DbSet<PriorityIssue> PriorityIssues { get; set; } = null!;
        public DbSet<StatusIssue> StatusIssues { get; set; } = null!;
        public DbSet<Issue> Issues { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>()
                .HasOne(i => i.StatusIssue)
                .WithMany(s => s.Issues)
                .HasForeignKey(i => i.IdStatusIssue)
                .HasConstraintName("FK_STATUS_ISSUE")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.PriorityIssue)
                .WithMany(p => p.Issues)
                .HasForeignKey(i => i.IdPriorityIssue)
                .HasConstraintName("FK_PRIORITY_ISSUE")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
