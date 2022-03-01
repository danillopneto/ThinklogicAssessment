using AutoMapper;
using ThinklogicAssessment.Domain.Dtos;
using ThinklogicAssessment.Domain.Events;

namespace ThinklogicAssessment.UseCases.Automappers
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>();
        }
    }
}
