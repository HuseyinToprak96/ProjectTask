using CoreLayer.Entities;
using CoreLayer.Entities.ComplaintEntity;
using CoreLayer.Entities.ComplaintHerbEntity;
using CoreLayer.Entities.HerbEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace RepositoryLayer.IdentityDBContext
{
    public class IdentityDbContext:IdentityDbContext<CoreLayer.Entities.UserEntity.UserApp>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {

        }
        public DbSet<Herb> Herbs { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintHerb> ComplaintHerbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferences)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferences.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReferences.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferences)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferences.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReferences).Property(x => x.CreatedDate).IsModified = false;
                                entityReferences.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }


            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
