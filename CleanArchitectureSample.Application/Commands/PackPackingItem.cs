using CleanArchitectureSample.Domain.ValueObjects;
using CleanArchitectureSample.Shared.Abstractions.Commands;

namespace CleanArchitectureSample.Application.Commands
{
    public record PackPackingItem(PackingListId Id, string ItemName): ICommand;
}
