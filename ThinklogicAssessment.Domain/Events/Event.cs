using ThinklogicAssessment.Core.Domain;

namespace ThinklogicAssessment.Domain.Events
{
    public class Event : BaseEntity
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public void UpdateInfo(Event eventData)
        {
            StartDate = eventData.StartDate;
            EndDate = eventData.EndDate;
            Title = eventData.Title;
            Location = eventData.Location;
            Description = eventData.Description;
        }
    }
}
