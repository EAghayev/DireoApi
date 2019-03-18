using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Direo.Models
{
    public class Place
    {
        [MaxLength(50)]
        public string Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public string Desc { get; set; }

        [Column(TypeName ="money")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(150, ErrorMessage = "Facebook cannot exceed 150 characters")]
        public string Facebook { get; set; }

        [MaxLength(150, ErrorMessage = "Instagram cannot exceed 150 characters")]
        public string Instagram { get; set; }

        [MaxLength(50, ErrorMessage = "Phone cannot exceed 50 characters")]
        public string Phone { get; set; }

        [MaxLength(150, ErrorMessage = "Website cannot exceed 150 characters")]
        public string Website { get; set; }

        [MaxLength(150, ErrorMessage = "Address cannot exceed 150 characters")]
        public string Address { get; set; }

        [MaxLength(150, ErrorMessage = "Twitter cannot exceed 150 characters")]
        public string Twitter { get; set; }

        [MaxLength(150, ErrorMessage = "Youtube cannot exceed 150 characters")]
        public string Youtube { get; set; }

        [MaxLength(100)]
        public string Lat { get; set; }

        [MaxLength(100)]
        public string Lon { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserId { get; set; }

        public List<PlaceTag> PlaceTags { get; set; }

        public User User { get; set; }

        public Category Category { get; set; }

        public List<PlaceStatus> PlaceStatuses { get; set; }

        public List<WorkHour> WorkHours { get; set; }

        public List<UserLike> UserLikes { get; set; }
    }
}
