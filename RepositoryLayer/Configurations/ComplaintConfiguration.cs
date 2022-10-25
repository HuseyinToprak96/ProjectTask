using CoreLayer.Entities.ComplaintEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configurations
{
    public class ComplaintConfiguration : IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
