namespace ThinklogicAssessment.Domain.Dtos
{
    public class EventDto
    {
        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }
    }
}
