using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.Controllers
{
    public class RecepientController : Controller
    {
        public IActionResult Index()
        {
            return View("RecepientsList");
        }
    }
}
