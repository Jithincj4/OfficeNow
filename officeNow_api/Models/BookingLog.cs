using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace officeNow_api.Models
{
    public class BookingLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string BookedDate { get; set; }
        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }
        [Required]
        [ForeignKey("WorkStation")]
        public long WorkStationId { get; set; }


        public User BookedUser { get; set; }
        public WorkStation WorkStation { get; set; }
    }
}
