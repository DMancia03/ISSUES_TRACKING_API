using ISSUES_TRACKING_API.Models;

namespace ISSUES_TRACKING_API.IRepositories
{
    public interface IPriorityIssueRepository
    {
        public List<PriorityIssue> GetAllPriorityIssues();
        public PriorityIssue? GetPriorityIssue(int id);
    }
}
