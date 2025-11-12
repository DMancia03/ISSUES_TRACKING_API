using ISSUES_TRACKING_API.Models;

namespace ISSUES_TRACKING_API.IRepositories
{
    public interface IIssueRepository
    {
        public List<Issue> GetAllIssuesSimple();
        public List<Issue> GetAllIssuesWithNavigations();
        public Issue? GetIssue(int id);
        public void AddIssue(Issue issue);
        public void UpdateIssue(Issue issue);
    }
}
