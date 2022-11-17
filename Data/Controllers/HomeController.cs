using Microsoft.AspNetCore.Mvc;

namespace TestAspNetWeb3.Data.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
