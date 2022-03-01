using Microsoft.EntityFrameworkCore;
using ThinklogicAssessment.Domain.Events;

namespace ThinklogicAssessment.Infra.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        {
        }
    }
}
