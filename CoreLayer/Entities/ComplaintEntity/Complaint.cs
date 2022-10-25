using CoreLayer.Entities.ComplaintHerbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities.ComplaintEntity
{
    public class Complaint:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ComplaintHerb> ComplaintHerbs { get; set; }
    }
}
