using CoreLayer.Entities.ComplaintHerbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Seeds
{
    public class SeedComplaintHerbs : IEntityTypeConfiguration<ComplaintHerb>
    {

        public void Configure(EntityTypeBuilder<ComplaintHerb> builder)
        {
            builder.HasData(new ComplaintHerb { Id = 1, ComplaintId=1, HerbId=1, IsActive=true, IsDeleted=false },
                new ComplaintHerb { Id = 2, ComplaintId = 1, HerbId = 2, IsActive = true, IsDeleted = false },
                new ComplaintHerb { Id = 3, ComplaintId = 2, HerbId = 3, IsActive = true, IsDeleted = false },
                new ComplaintHerb { Id = 4, ComplaintId = 2, HerbId = 4, IsActive = true, IsDeleted = false },
                new ComplaintHerb { Id = 5, ComplaintId = 3, HerbId = 5, IsActive = true, IsDeleted = false },
                new ComplaintHerb { Id = 6, ComplaintId = 3, HerbId = 6, IsActive = true, IsDeleted = false },
                new ComplaintHerb { Id = 7, ComplaintId = 4, HerbId = 7, IsActive = true, IsDeleted = false },
                new ComplaintHerb { Id = 8, ComplaintId = 4, HerbId = 8, IsActive = true, IsDeleted = false },
                new ComplaintHerb { Id = 9, ComplaintId = 5, HerbId = 5, IsActive = true, IsDeleted = false },
                new ComplaintHerb { Id = 10, ComplaintId = 5, HerbId = 4, IsActive = true, IsDeleted = false },
                new ComplaintHerb { Id = 11, ComplaintId = 3, HerbId = 3, IsActive = true, IsDeleted = false },
                new ComplaintHerb { Id = 12, ComplaintId = 2, HerbId = 2, IsActive = true, IsDeleted = false });
        }
    }
}
