using CoreLayer.Entities.ComplaintHerbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configurations
{
    public class ComplaintHerbConfiguration : IEntityTypeConfiguration<ComplaintHerb>
    {
        public void Configure(EntityTypeBuilder<ComplaintHerb> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Complaint).WithMany(x => x.ComplaintHerbs).HasForeignKey(x => x.ComplaintId);
            builder.HasOne(x => x.Herb).WithMany(x => x.ComplaintHerbs).HasForeignKey(x => x.HerbId);
            builder.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
