using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISSUES_TRACKING_API.Models
{
    [Table("ISSUE")]
    public class Issue
    {
        [Key]
        [Column("ID_ISSUE")]
        public int IdIssue { get; set; }

        [Column("TITLE", TypeName = "NVARCHAR(100)")]
        public string Title { get; set; } = null!;

        [Column("DESCRIPTION_ISSUE", TypeName = "NVARCHAR(500)")]
        public string DescriptionIssue { get; set; } = null!;

        [Column("ID_STATUS_ISSUE")]
        public int IdStatusIssue { get; set; }

        [Column("ID_PRIORITY_ISSUE")]
        public int IdPriorityIssue { get; set; }

        [Column("CREATE_USER", TypeName = "NVARCHAR(50)")]
        public string CreateUser { get; set; } = null!;

        [Column("CREATE_DATE", TypeName = "DATETIME")]
        public DateTime CreateDate { get; set; }

        [Column("RESOLVE_USER", TypeName = "NVARCHAR(50)")]
        public string ResolveUser { get; set; } = null!;

        [Column("RESOLVE_DATE", TypeName = "DATETIME")]
        public DateTime ResolveDate { get; set; }

        public StatusIssue? StatusIssue { get; set; }
        public PriorityIssue? PriorityIssue { get; set; }
    }
}
