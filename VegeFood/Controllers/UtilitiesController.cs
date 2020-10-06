using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace VegeFood.Controllers
{
    public class UtilitiesController : Controller
    {
        [Route("/utilities/calendar")]
        [HttpGet]
        public async Task<IActionResult> Calendar()
        {
            return View();
        }
    }
}
