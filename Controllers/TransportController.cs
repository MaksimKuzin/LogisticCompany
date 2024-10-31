using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.Controllers
{
    public class TransportController : Controller
    {
        public IActionResult Index()
        {
            return View("TransportsList");
        }
    }
}
