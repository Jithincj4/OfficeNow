using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace officeNow_api.Models
{
    public class UserTags
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        public Tags Tag { get; set; }
    }
}
