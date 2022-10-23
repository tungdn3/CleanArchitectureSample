using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.Repositories;
using CleanArchitectureSample.Domain.ValueObjects;
using CleanArchitectureSample.Infrastructure.Ef.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Infrastructure.Ef.Repositories
{
    internal sealed class PostgresPackingListRepository : IPackingListRepository
    {
        private readonly WriteDbContext _context;

        public PostgresPackingListRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task Add(PackingList packingList)
        {
            _context.PackingLists.Add(packingList);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(PackingList packingList)
        {
            _context.PackingLists.Remove(packingList);
            await _context.SaveChangesAsync();
        }

        public async Task<PackingList?> Get(PackingListId id)
        {
            return await _context.PackingLists
                .Include("_items")
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(PackingList packingList)
        {
            _context.PackingLists.Update(packingList);
            await _context.SaveChangesAsync();
        }
    }
}
