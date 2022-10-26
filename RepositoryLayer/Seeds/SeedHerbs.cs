using CoreLayer.Entities.HerbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Seeds
{
    public class SeedHerbs : IEntityTypeConfiguration<Herb>
    {
        public void Configure(EntityTypeBuilder<Herb> builder)
        {
            builder.HasData(new Herb { Id = 1, Name = "Bitki 1", Description = "Açıklama 1", Image = "images/56f0229e-691b-496f-9132-d086bf8e3929papatya.jpg", IsActive = true, IsDeleted = false},
                new Herb { Id = 2, Name = "Bitki 2", Description = "Açıklama 2", Image = "images/25ad7ac7-23ad-44f6-bdf2-68b091540076indir.jfif", IsActive = true, IsDeleted = false},
                new Herb {Id=3, Name="Bitki 3", Description="Açıklama 3", Image= "images/56f0229e-691b-496f-9132-d086bf8e3929papatya.jpg", IsActive = true, IsDeleted = false},
                new Herb { Id = 4, Name = "Bitki 4", Description = "Açıklama 4", Image = "images/25ad7ac7-23ad-44f6-bdf2-68b091540076indir.jfif", IsActive = true, IsDeleted = false},
                new Herb { Id = 5, Name = "Bitki 5", Description = "Açıklama 5", Image = "images/56f0229e-691b-496f-9132-d086bf8e3929papatya.jpg", IsActive = true, IsDeleted = false},
                new Herb { Id = 6, Name = "Bitki 6", Description = "Açıklama 6", Image = "images/25ad7ac7-23ad-44f6-bdf2-68b091540076indir.jfif", IsActive = true, IsDeleted = false },
                new Herb { Id = 7, Name = "Bitki 7", Description = "Açıklama 7", Image = "images/56f0229e-691b-496f-9132-d086bf8e3929papatya.jpg", IsActive = true, IsDeleted = false },
                new Herb { Id = 8, Name = "Bitki 8", Description = "Açıklama 8", Image = "images/25ad7ac7-23ad-44f6-bdf2-68b091540076indir.jfif", IsActive = true, IsDeleted = false});
        }
    }
}
