using ISSUES_TRACKING_API.ApiModels;
using ISSUES_TRACKING_API.IRepositories;
using ISSUES_TRACKING_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISSUES_TRACKING_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssueController : ControllerBase
    {
        protected IIssueRepository _issueRepo;
        protected IStatusIssueRepository _status;
        protected IPriorityIssueRepository _priority;

        public IssueController(IIssueRepository issue, IStatusIssueRepository status, IPriorityIssueRepository priority)
        {
            _issueRepo = issue;
            _status = status;
            _priority = priority;
        }

        [HttpGet(Name = "GetIssues")]
        public IActionResult Get()
        {
            List<IssueApiModel> issuesList = _issueRepo.GetAllIssuesWithNavigations().Select(i => new IssueApiModel()
            {
                IdIssue = i.IdIssue,
                Title = i.Title,
                DescriptionIssue = i.DescriptionIssue,
                IdStatusIssue = i.StatusIssue.IdStatusIssue,
                StatusIssue = i.StatusIssue.DescriptionStatus,
                IdPriorityIssue = i.PriorityIssue.IdPriorityIssue,
                PriorityIssue = i.PriorityIssue.DescriptionPriority,
                CreateUser = i.CreateUser,
                CreateDate = i.CreateDate,
                ResolveUser = i.ResolveUser,
                ResolveDate = i.ResolveDate
            }).ToList();

            return Ok(issuesList);
        }

        [HttpPost(Name = "CreateIssue")]
        public IActionResult CreateIssue([FromBody] IssueApiModel issue)
        {
            int idStatusOpen = _status.GetStatusForOpen();

            if(idStatusOpen == 0)
            {
                return NotFound();
            }

            Issue newIssue = new Issue() { 
                Title = issue.Title,
                DescriptionIssue = issue.DescriptionIssue,
                IdStatusIssue = idStatusOpen,
                IdPriorityIssue = issue.IdPriorityIssue,
                CreateUser = "system",
                CreateDate = DateTime.Now
            };

            _issueRepo.AddIssue(newIssue);

            return Ok();
        }

        [HttpPut("{IdIssue}", Name = "ResolvedIssue")]
        public IActionResult ResolvedIssue(int IdIssue)
        {
            var issue = _issueRepo.GetIssue(IdIssue);

            if (issue == null)
            {
                return NotFound();
            }

            issue.IdStatusIssue = _status.GetStatusForResolved();

            if(issue.IdStatusIssue == 0)
            {
                return NotFound();
            }

            issue.ResolveUser = "system";
            issue.ResolveDate = DateTime.Now;

            _issueRepo.UpdateIssue(issue);

            return Ok();
        }
    }
}
