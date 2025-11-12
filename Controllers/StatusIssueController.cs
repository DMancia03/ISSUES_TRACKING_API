using ISSUES_TRACKING_API.ApiModels;
using ISSUES_TRACKING_API.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ISSUES_TRACKING_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusIssueController : ControllerBase
    {
        protected IStatusIssueRepository _status;

        public StatusIssueController(IStatusIssueRepository status)
        {
            _status = status;
        }

        [HttpGet(Name = "GetStatusIssues")]
        public IActionResult Get()
        {
            List<StatusIssueApiModel> statusLists = _status.GetAllStatusIssues().Select(s => new StatusIssueApiModel()
            {
                IdStatusIssue = s.IdStatusIssue,
                DescriptionStatus = s.DescriptionStatus
            }).ToList();

            return Ok(statusLists);
        }
    }
}
