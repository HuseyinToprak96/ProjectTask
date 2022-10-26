using CoreLayer.Entities.ComplaintEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RepositoryLayer.Seeds
{
    public class SeedComplaint : IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            builder.HasData(new Complaint { Id=1,Name="Kansızlık", IsActive = true, IsDeleted = false } ,
                new Complaint { Id = 2, Name = "Vitamin Eksikliği", IsActive = true, IsDeleted = false },
                new Complaint { Id = 3, Name = "Demir Eksikliği", IsActive = true, IsDeleted = false },
                new Complaint { Id = 4, Name = "Yüksek Tansiyon", IsActive = true, IsDeleted = false },
                new Complaint { Id = 5, Name = "Düşük Tansiyon", IsActive = true, IsDeleted = false });
        }
    }
}
