using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThinklogicAssessment.Domain.Dtos;
using ThinklogicAssessment.Interfaces.UseCases;
using ThinklogicAssessment.Models;

namespace ThinklogicAssessment.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IGetEventsByDateUseCase _getEventsByDateUseCase;

        private readonly ILogger<CalendarController> _logger;

        private readonly ISaveEventUseCase _saveEventUseCase;

        public CalendarController(ILogger<CalendarController> logger,
                                  IGetEventsByDateUseCase getEventsByDateUseCase,
                                  ISaveEventUseCase saveEventUseCase)
        {
            _logger = logger;
            _getEventsByDateUseCase = getEventsByDateUseCase ?? throw new ArgumentNullException(nameof(getEventsByDateUseCase));
            _saveEventUseCase = saveEventUseCase ?? throw new ArgumentNullException(nameof(saveEventUseCase));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Index(DateTime? currentDate, CancellationToken ct)
        {
            var events = await _getEventsByDateUseCase.GetEventsByDateAsync(currentDate ?? DateTime.Now, ct);
            var model = new EventsDto { CurrentDate = currentDate, Events = events };
            return View(model);
        }

        [HttpGet("GetEventsByDayAsync")]
        public async Task<IActionResult> GetEventsByDayAsync(DateTime date, CancellationToken ct)
        {
            var events = await _getEventsByDateUseCase.GetEventsByDateAsync(date, ct);

            return PartialView("_Events", events);
        }

        [HttpPost("GetCalendarAsync")]
        public IActionResult GetCalendarAsync(DateTime date, int increment)
        {
            try
            {
                var nextDate = date.AddMonths(increment);
                return PartialView("_Calendar", nextDate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to get a calendar.");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(EventDto eventDto, CancellationToken ct)
        {
            try
            {
                await _saveEventUseCase.SaveEventAsync(eventDto, ct);

                return RedirectToAction(nameof(Index), new { currentDate = eventDto.StartDate });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to save an event: {event}.", eventDto?.Title);
                throw;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
