using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Direo.Models
{
    public enum Case
    {
       Active=0,
       Deleted=1,
       Frozen=2
    }
    public class User
    {
        [MaxLength(50)]
        public string Id { get; set; }
        
        [Required]
        [MaxLength(100,ErrorMessage = "Fullname cannot exceed 100 characters")]
        public string Fullname { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(100, ErrorMessage = "Password cannot exceed 100 characters")]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Token { get; set; }

        public bool Gender { get; set; }

        [MaxLength(100)]
        public string Profile { get; set; }

        [MaxLength(50, ErrorMessage = "Phone cannot exceed 50 characters")]
        public string Phone { get; set; }

        [MaxLength(150, ErrorMessage = "Website cannot exceed 150 characters")]
        public string Website { get; set; }
       
        [MaxLength(150, ErrorMessage = "Address cannot exceed 150 characters")]
        public string Address { get; set; }

        [MaxLength(150, ErrorMessage = "Twitter cannot exceed 150 characters")]
        public string Twitter { get; set; }

        [MaxLength(150, ErrorMessage = "Google+ cannot exceed 150 characters")]
        public string Google { get; set; }

        [MaxLength(150, ErrorMessage = "Youtube cannot exceed 150 characters")]
        public string Youtube { get; set; }

        [MaxLength(150, ErrorMessage = "Linkedin cannot exceed 150 characters")]
        public string Linkedin { get; set; }

        public DateTime CreatedAt { get; set; }

        [Column(TypeName ="tinyint")]
        public Case Status { get; set; }

        public string About { get; set; }

        public List<Place> Places { get; set; }

        public List<UserLike> UserLikes { get; set; }
    }
}
