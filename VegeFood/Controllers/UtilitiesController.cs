using Microsoft.AspNetCore.Mvc;

namespace VegeFood.Controllers
{
    public class UtilitiesController : Controller
    {
        [Route("/utilities/calendar")]
        [HttpGet]
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
