using CleanArchitectureSample.Domain.ValueObjects;
using CleanArchitectureSample.Shared.Abstractions.Commands;

namespace CleanArchitectureSample.Application.Commands
{
    public record RemovePackingItem(PackingListId Id, string ItemName): ICommand;
}
