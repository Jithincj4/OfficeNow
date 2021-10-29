using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace officeNow_api.Models
{
    public class WorkStation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [ForeignKey("Location")]
        public long CompanyLocationId { get; set; }
        [Required]
        public long SeatNo { get; set; }
   
        public Location CompanyLocation { get; set; }
        public ICollection<WorkStationTags> Tags { get; set; }
    }
  
}
