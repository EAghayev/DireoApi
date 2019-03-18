using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Direo.Models
{
    public class PlaceTag
    {
        [MaxLength(50)]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string TagId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PlaceId { get; set; }

        public Tag Tag { get; set; }

        public Place Place { get; set; }
    }
}
