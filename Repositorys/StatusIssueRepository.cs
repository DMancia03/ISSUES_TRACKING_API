using ISSUES_TRACKING_API.Data;
using ISSUES_TRACKING_API.IRepositories;
using ISSUES_TRACKING_API.Models;

namespace ISSUES_TRACKING_API.Repositorys
{
    public class StatusIssueRepository : IStatusIssueRepository
    {
        protected IssuesTrackingDbContext _db;

        public StatusIssueRepository(IssuesTrackingDbContext db)
        {
            _db = db;
        }

        public List<StatusIssue> GetAllStatusIssues()
        {
            return _db.StatusIssues.ToList();
        }

        public StatusIssue? GetStatusIssue(int id)
        {
            return _db.StatusIssues.Find(id);
        }

        public int GetStatusForResolved()
        {
            var status = _db.StatusIssues.Where(s => s.DescriptionStatus == "Resolved").FirstOrDefault();
           
            return status != null ? status.IdStatusIssue : 0;
        }

        public int GetStatusForOpen()
        {
            var status = _db.StatusIssues.Where(s => s.DescriptionStatus == "Open").FirstOrDefault();

            return status != null ? status.IdStatusIssue : 0;
        }
    }
}
