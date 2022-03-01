using ThinklogicAssessment.Domain.Events;

namespace ThinklogicAssessment.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEventsByDateAsync(DateTime date);

        Task SaveEventAsync(Event eventData);
    }
}
