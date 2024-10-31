using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.Controllers
{
    public class CourierController : Controller
    {
        public IActionResult Index()
        {
            return View("CouriersList");
        }
    }
}
