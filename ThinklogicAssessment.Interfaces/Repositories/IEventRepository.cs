using ThinklogicAssessment.Domain.Events;

namespace ThinklogicAssessment.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEventsByDateAsync(DateTime date, CancellationToken ct);

        Task SaveEventAsync(Event eventData, CancellationToken ct);
    }
}
