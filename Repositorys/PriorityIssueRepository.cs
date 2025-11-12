using ISSUES_TRACKING_API.Data;
using ISSUES_TRACKING_API.IRepositories;
using ISSUES_TRACKING_API.Models;

namespace ISSUES_TRACKING_API.Repositorys
{
    public class PriorityIssueRepository : IPriorityIssueRepository
    {
        protected IssuesTrackingDbContext _db;

        public PriorityIssueRepository(IssuesTrackingDbContext db)
        {
            _db = db;
        }

        public List<PriorityIssue> GetAllPriorityIssues()
        {
            return _db.PriorityIssues.ToList();
        }

        public PriorityIssue? GetPriorityIssue(int id)
        {
            return _db.PriorityIssues.Find(id);
        }
    }
}
