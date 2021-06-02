using AngularMaterialSchematics.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace AngularMaterialSchematics.Api.Interfaces
{
    public interface IAngularMaterialSchematicsDbContext
    {
        DbSet<Contact> Contacts { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
