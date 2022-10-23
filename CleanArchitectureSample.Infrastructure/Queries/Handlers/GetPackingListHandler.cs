using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Application.Queries;
using CleanArchitectureSample.Infrastructure.Ef.Contexts;
using CleanArchitectureSample.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Infrastructure.Queries.Handlers
{
    internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
    {
        private readonly ReadDbContext _context;

        public GetPackingListHandler(ReadDbContext context)
        {
            _context = context;
        }

        public async Task<PackingListDto?> Handle(GetPackingList query)
        {
            var packingList = await _context.PackingLists
                .AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Name == query.Name);

            if (packingList == null)
            {
                return null;
            }

            return packingList.AsDto();
        }
    }
}
