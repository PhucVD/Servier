using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Business.Models.Categories
{
    public class RegionModel
    {
        public int RegionID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "This value cannot be longer than 100 characters.")]
        [Display(Name = "Region Name")]
        public string RegionName { get; set; }

        public int? Rank { get; set; }

        public string Note { get; set; }
    }
}
