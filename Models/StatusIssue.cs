using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISSUES_TRACKING_API.Models
{
    [Table("STATUS_ISSUE")]
    public class StatusIssue
    {
        [Key]
        [Column("ID_STATUS_ISSUE")]
        public int IdStatusIssue { get; set; }

        [Column("DESCRIPTION_STATUS", TypeName = "NVARCHAR(25)")]
        public string DescriptionStatus { get; set; } = null!;

        public ICollection<Issue>? Issues { get; set; }
    }
}
