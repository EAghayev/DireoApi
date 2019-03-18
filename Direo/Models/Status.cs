using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Direo.Models
{
    public class Status
    {
        [MaxLength(50)]
        public string Id { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Name cannot exceed 50 characters")]
        public string Name { get; set; }

        public List<PlaceStatus> PlaceStatuses { get; set; }
    }
}
