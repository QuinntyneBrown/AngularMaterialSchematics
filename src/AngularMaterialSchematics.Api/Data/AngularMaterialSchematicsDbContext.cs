using AngularMaterialSchematics.Api.Models;
using AngularMaterialSchematics.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AngularMaterialSchematics.Api.Data
{
    public class AngularMaterialSchematicsDbContext: DbContext, IAngularMaterialSchematicsDbContext
    {
        public DbSet<Contact> Contacts { get; private set; }
        public AngularMaterialSchematicsDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AngularMaterialSchematicsDbContext).Assembly);
        }
        
    }
}
