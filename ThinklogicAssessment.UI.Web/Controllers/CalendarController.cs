using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

        public async Task<IActionResult> Index()
        {
            var events = await _getEventsByDateUseCase.GetEventsByDateAsync(DateTime.Now);

            return View(events);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
