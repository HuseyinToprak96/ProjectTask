using CoreLayer.Dtos.Complaint;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos.Herb
{
    public class HerbDto
    {
        [NotMapped]
        public string EncrypedId { get; set; }
        public int Id { get; set; }
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        public string Image { get; set; }
    }
}
