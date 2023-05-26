using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cars.Domain;

namespace Cars.Application.Interfaces
{
    public interface ICarsDbContext
    {
        DbSet<Car> Car { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
