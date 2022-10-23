using CleanArchitectureSample.Domain.Consts;
using CleanArchitectureSample.Shared.Abstractions.Commands;

namespace CleanArchitectureSample.Application.Commands
{
    public record CreatePackingListWithItems(Guid Id, string Name, ushort Days, Gender Gender, LocalizationWriteModel Localization)
        : ICommand;

    public record LocalizationWriteModel(string City, string Country);
}
