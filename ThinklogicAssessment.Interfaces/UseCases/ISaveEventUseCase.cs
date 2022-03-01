using ThinklogicAssessment.Domain.Dtos;

namespace ThinklogicAssessment.Interfaces.UseCases
{
    public interface ISaveEventUseCase
    {
        Task SaveEventAsync(EventDto eventDto);
    }
}
