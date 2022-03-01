using AutoMapper;
using ThinklogicAssessment.Domain.Dtos;
using ThinklogicAssessment.Domain.Events;
using ThinklogicAssessment.Interfaces.Repositories;
using ThinklogicAssessment.Interfaces.UseCases;

namespace ThinklogicAssessment.UseCases.UseCases
{
    public class SaveEventUseCase : ISaveEventUseCase
    {
        private readonly IEventRepository _eventRepository;

        private readonly IMapper _mapper;

        public SaveEventUseCase(IEventRepository eventRepository,
                                IMapper mapper)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task SaveEventAsync(EventDto eventDto)
        {
            var eventData = _mapper.Map<Event>(eventDto);
            await _eventRepository.SaveEventAsync(eventData);
        }
    }
}
