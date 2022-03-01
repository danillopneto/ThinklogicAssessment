using Microsoft.EntityFrameworkCore;
using ThinklogicAssessment.Domain.Events;
using ThinklogicAssessment.Infra.Contexts;
using ThinklogicAssessment.Interfaces.Repositories;

namespace ThinklogicAssessment.Infra.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationContext _applicationContext;

        public EventRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IEnumerable<Event>> GetEventsByDateAsync(DateOnly date) => await _applicationContext.Events.Where(e => e.StartDate == date)
                                                                                                                     .AsNoTracking()
                                                                                                                     .ToListAsync();

        public async Task SaveEventAsync(Event eventData)
        {
            var currentEvent = await _applicationContext.Events.FirstOrDefaultAsync(e => e.Id == eventData.Id);
            if (currentEvent is null)
            {
                await _applicationContext.Events.AddAsync(eventData);
            }
            else
            {
                currentEvent.UpdateInfo(eventData);
            }

            await _applicationContext.SaveChangesAsync();
        }
    }
}
