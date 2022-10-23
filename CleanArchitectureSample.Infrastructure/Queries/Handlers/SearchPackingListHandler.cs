using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Application.Queries;
using CleanArchitectureSample.Infrastructure.Ef.Contexts;
using CleanArchitectureSample.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Infrastructure.Queries.Handlers
{
    internal sealed class SearchPackingListHandler : IQueryHandler<SearchPackingList, IEnumerable<PackingListDto>>
    {
        private readonly ReadDbContext _context;

        public SearchPackingListHandler(ReadDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PackingListDto>> Handle(SearchPackingList query)
        {
            var dbQuery = _context.PackingLists
                .AsNoTracking()
                .Include(x => x.Items)
                .AsQueryable();

            if (!string.IsNullOrEmpty(query.SearchText))
            {
                dbQuery = dbQuery.Where(x => EF.Functions.ILike(x.Name, $"%{query.SearchText}%"));
            }

            var models = await dbQuery.ToListAsync();
            return models.Select(x => x.AsDto());
        }
    }
}
