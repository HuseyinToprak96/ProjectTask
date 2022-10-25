using CoreLayer.Entities.ComplaintEntity;
using CoreLayer.Entities.HerbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities.ComplaintHerbEntity
{
    public class ComplaintHerb:BaseEntity
    {
        public int? ComplaintId { get; set; }
        public int? HerbId { get; set; }
        public Complaint Complaint { get; set; }
        public Herb Herb { get; set; }
    }
}
