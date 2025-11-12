using ISSUES_TRACKING_API.Data;
using ISSUES_TRACKING_API.IRepositories;
using ISSUES_TRACKING_API.Models;

namespace ISSUES_TRACKING_API.Repositorys
{
    public class IssueRepository : IIssueRepository
    {
        protected IssuesTrackingDbContext _db;

        public IssueRepository(IssuesTrackingDbContext db)
        {
            _db = db;
        }

        public List<Issue> GetAllIssuesSimple()
        {
            return _db.Issues.ToList();
        }

        public List<Issue> GetAllIssuesWithNavigations()
        {
            return (from i in _db.Issues
                    join s in _db.StatusIssues on i.IdStatusIssue equals s.IdStatusIssue
                    join p in _db.PriorityIssues on i.IdPriorityIssue equals p.IdPriorityIssue
                    select new Issue
                    {
                        IdIssue = i.IdIssue,
                        Title = i.Title,
                        DescriptionIssue = i.DescriptionIssue,
                        IdStatusIssue = i.IdStatusIssue,
                        IdPriorityIssue = i.IdPriorityIssue,
                        CreateUser = i.CreateUser,
                        CreateDate = i.CreateDate,
                        ResolveUser = i.ResolveUser,
                        ResolveDate = i.ResolveDate,
                        StatusIssue = s,
                        PriorityIssue = p
                    }).ToList();
        }

        public Issue? GetIssue(int id)
        {
            return _db.Issues.Find(id);
        }

        public void AddIssue(Issue issue)
        {
            _db.Issues.Add(issue);
            _db.SaveChanges();
        }

        public void UpdateIssue(Issue issue)
        {
            _db.Issues.Update(issue);
            _db.SaveChanges();
        }
    }
}
