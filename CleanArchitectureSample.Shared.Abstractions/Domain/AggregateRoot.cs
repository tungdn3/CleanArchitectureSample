namespace CleanArchitectureSample.Shared.Abstractions.Domain
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }

        public int Version { get; protected set; }

        private bool _versionIncremented;

        private readonly List<IDomainEvent> _events = new();

        public IEnumerable<IDomainEvent> Events => _events;

        protected void IncreaseVersion()
        {
            if (_versionIncremented)
            {
                return;
            }

            Version++;
            _versionIncremented = true;
        }

        protected void AddEvent(IDomainEvent @event)
        {
            if (!_events.Any() && !_versionIncremented)
            {
                Version++;
                _versionIncremented = true;
                _events.Add(@event);
            }
        }

        public void ClearEvents() => _events.Clear();
    }
}
