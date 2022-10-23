using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.ValueObjects;
using CleanArchitectureSample.Shared.Abstractions.Domain;

namespace CleanArchitectureSample.Domain.Events
{
    public record PackingItemPacked(PackingList PackingList, PackingItem PackingItem) : IDomainEvent;
}
