using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Shared.Abstractions.Queries;

namespace CleanArchitectureSample.Application.Queries
{
    public record SearchPackingList(string SearchText) : IQuery<IEnumerable<PackingListDto>>;
}
