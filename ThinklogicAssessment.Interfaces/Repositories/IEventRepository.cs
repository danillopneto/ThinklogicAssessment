using ThinklogicAssessment.Domain.Events;

namespace ThinklogicAssessment.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEventsByDateAsync(DateOnly date);

        Task SaveEventAsync(Event eventData);
    }
}
