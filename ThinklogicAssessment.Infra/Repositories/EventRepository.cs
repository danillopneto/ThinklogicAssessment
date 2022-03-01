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

        public async Task<IEnumerable<Event>> GetEventsByDateAsync(DateTime date, CancellationToken ct) => await _applicationContext.Events.Where(e => e.StartDate.Date == date.Date)
                                                                                                                                    .AsNoTracking()
                                                                                                                                    .ToListAsync(ct);

        public async Task SaveEventAsync(Event eventData, CancellationToken ct)
        {
            var currentEvent = await _applicationContext.Events.FirstOrDefaultAsync(e => e.Id == eventData.Id, ct);
            if (currentEvent is null)
            {
                await _applicationContext.Events.AddAsync(eventData, ct);
            }
            else
            {
                currentEvent.UpdateInfo(eventData);
            }

            await _applicationContext.SaveChangesAsync(ct);
        }
    }
}
