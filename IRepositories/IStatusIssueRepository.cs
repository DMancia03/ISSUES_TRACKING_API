using ISSUES_TRACKING_API.Models;

namespace ISSUES_TRACKING_API.IRepositories
{
    public interface IStatusIssueRepository
    {
        public List<StatusIssue> GetAllStatusIssues();
        public StatusIssue? GetStatusIssue(int id);
        public int GetStatusForResolved();
    }
}
