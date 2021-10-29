using System.ComponentModel.DataAnnotations.Schema;

namespace officeNow_api.Models
{
    public class WorkStationTags
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("WorkStation")]
        public long WorkStationId { get; set; }
        public Tags Tag { get; set; }
    }
}
