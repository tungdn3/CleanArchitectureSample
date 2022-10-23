using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Shared.Abstractions.Queries;

namespace CleanArchitectureSample.Application.Queries
{
    public record GetPackingList(string Name) : IQuery<PackingListDto>;
}
