namespace ISSUES_TRACKING_API.ApiModels
{
    public class IssueApiModel
    {
        public int IdIssue { get; set; }
        public string Title { get; set; } = null!;
        public string DescriptionIssue { get; set; } = null!;
        public int IdStatusIssue { get; set; }
        public string? StatusIssue { get; set; }
        public int IdPriorityIssue { get; set; }
        public string? PriorityIssue { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? ResolveUser { get; set; }
        public DateTime? ResolveDate { get; set; }
    }
}
