using CupApplication.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CupApplication.Data.Controllers
{
    [Authorize(Roles = "admin")]
    public class WorkingSessionController : Controller
    {
        private readonly IWorkingSession _workingSession;

        public WorkingSessionController(IWorkingSession workingSession)
        {
            _workingSession = workingSession;
        }
        [Route("Table7")]
        public ViewResult Table()
        {
            return View(_workingSession.GetAllWorkingSessionsContent());
        }
    }
}
