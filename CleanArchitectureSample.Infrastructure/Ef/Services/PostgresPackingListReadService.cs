using CleanArchitectureSample.Application.Services;
using CleanArchitectureSample.Infrastructure.Ef.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Infrastructure.Ef.Services
{
    internal sealed class PostgresPackingListReadService : IPackingListReadService
    {
        private readonly ReadDbContext _context;

        public PostgresPackingListReadService(ReadDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByName(string name)
        {
            return await _context.PackingLists.AnyAsync(x => x.Name == name);
        }
    }
}
