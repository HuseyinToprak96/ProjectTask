using CoreLayer.Entities.ComplaintHerbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities.HerbEntity
{
    public class Herb:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<ComplaintHerb> ComplaintHerbs { get; set; }
    }
}
