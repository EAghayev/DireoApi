using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Direo.Models
{
    public class UserLike
    {
        [MaxLength(50)]
        public string Id { get; set; }

        [MaxLength(50)]
        public string UserId { get; set; }

        [MaxLength(50)]
        public string PlaceId { get; set; }

        public User User { get; set; }

        public Place Place { get; set; }
    }
}
