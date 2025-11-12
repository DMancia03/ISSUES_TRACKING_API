using ISSUES_TRACKING_API.ApiModels;
using ISSUES_TRACKING_API.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ISSUES_TRACKING_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriorityIssueController : ControllerBase
    {
        protected IPriorityIssueRepository _priority;

        public PriorityIssueController(IPriorityIssueRepository priority)
        {
            _priority = priority;
        }

        [HttpGet(Name = "GetPrioritysIssues")]
        public IActionResult Get()
        {
            List<PriorityIssueApiModel> prioritysList = _priority.GetAllPriorityIssues().Select(p => new PriorityIssueApiModel()
            {
                IdPriorityIssue = p.IdPriorityIssue,
                DescriptionPriority = p.DescriptionPriority
            }).ToList();

            return Ok(prioritysList);
        }
    }
}
