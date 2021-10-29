using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace officeNow_api.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [ForeignKey("UserRole")]
        public long RoleId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserRealName { get; set; }
        [ForeignKey("Location")]
        public long UserLocationId { get; set; }

        public UserRole UserRole { get; set; }
        public Location UserLocation { get; set; }

        public  ICollection<UserTags> UserTags{ get; set; }

    }
}
