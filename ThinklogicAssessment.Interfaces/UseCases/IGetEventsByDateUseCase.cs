using ThinklogicAssessment.Domain.Dtos;

namespace ThinklogicAssessment.Interfaces.UseCases
{
    public interface IGetEventsByDateUseCase
    {
        Task<IEnumerable<EventDto>> GetEventsByDateAsync(DateTime date);
    }
}
