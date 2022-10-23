using CleanArchitectureSample.Domain.Consts;
using CleanArchitectureSample.Domain.ValueObjects;

namespace CleanArchitectureSample.Domain.Policies
{
    public record PolicyData(TravelDays Days, Gender Gender, Temperature Temperature, Localization Localization);
}
