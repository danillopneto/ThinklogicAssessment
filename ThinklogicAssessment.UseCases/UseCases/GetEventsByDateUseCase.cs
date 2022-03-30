using AutoMapper;
using ThinklogicAssessment.Domain.Dtos;
using ThinklogicAssessment.Interfaces.Repositories;
using ThinklogicAssessment.Interfaces.UseCases;

namespace ThinklogicAssessment.UseCases.UseCases
{
    public class GetEventsByDateUseCase : IGetEventsByDateUseCase
    {
        private readonly IEventRepository _eventRepository;

        private readonly IMapper _mapper;

        public GetEventsByDateUseCase(IEventRepository eventRepository,
                                      IMapper mapper)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<EventDto>> GetEventsByDateAsync(DateTime date, CancellationToken ct)
        {
            var events = await _eventRepository.GetEventsByDateAsync(date, ct);
            return _mapper.Map<IEnumerable<EventDto>>(events);
        }
    }
}
