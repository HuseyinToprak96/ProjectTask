using CoreLayer.Entities.HerbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configurations
{
    public class HerbConfiguration : IEntityTypeConfiguration<Herb>
    {
        public void Configure(EntityTypeBuilder<Herb> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Image).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
