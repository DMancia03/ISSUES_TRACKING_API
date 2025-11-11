using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISSUES_TRACKING_API.Models
{
    [Table("PRIORITY_ISSUE")]
    public class PriorityIssue
    {
        [Key]
        [Column("ID_PRIORITY_ISSUE")]
        public int IdPriorityIssue { get; set; }

        [Column("DESCRIPTION_PRIORITY", TypeName = "NVARCHAR(25)")]
        public string DescriptionPriority { get; set; } = null!;

        public ICollection<Issue>? Issues { get; set; }
    }
}
