using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Direo.Models
{
    public class Category
    {
        [MaxLength(50)]
        public string Id { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage ="Name cannot exceed 100 characters")]
        public string Name { get; set; }

        public List<Place> Places { get; set; }
    }
}
