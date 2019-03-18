using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Direo.Models
{
    public class PlaceStatus
    {
        [MaxLength(50)]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string PlaceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string StatusId { get; set; }

        public Place Place { get; set; }

        public Status Status { get; set; }
    }
}
