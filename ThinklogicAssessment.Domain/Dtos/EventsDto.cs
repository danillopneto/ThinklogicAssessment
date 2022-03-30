namespace ThinklogicAssessment.Domain.Dtos
{
    public class EventsDto
    {
        public DateTime? CurrentDate { get; set; }

        public IEnumerable<EventDto> Events { get; set; }
    }
}
