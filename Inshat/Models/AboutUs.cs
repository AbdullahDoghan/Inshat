using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inshat.Models
{
    public class AboutUs
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

    }
}
