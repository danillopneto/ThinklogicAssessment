using Microsoft.AspNetCore.Mvc;

namespace ThinklogicAssessment.UI.Web.Controllers
{
    public abstract class ThinklogicBaseController<TController> : Controller
    {
        protected readonly ILogger<TController> _logger;

        protected ThinklogicBaseController(ILogger<TController> logger)
        {
            _logger = logger;
        }

        [HttpPost("GetCalendarAsync")]
        public IActionResult GetCalendarAsync(DateTime date, int increment)
        {
            try
            {
                var nextDate = date.AddMonths(increment);
                return PartialView("CalendarComponent/_Calendar", nextDate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to get a calendar.");
                throw;
            }
        }
    }
}
