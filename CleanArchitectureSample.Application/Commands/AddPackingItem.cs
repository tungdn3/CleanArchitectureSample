using CleanArchitectureSample.Domain.ValueObjects;
using CleanArchitectureSample.Shared.Abstractions.Commands;

namespace CleanArchitectureSample.Application.Commands
{
    public record AddPackingItem(PackingListId Id, string ItemName, ushort Quantity): ICommand;
}
