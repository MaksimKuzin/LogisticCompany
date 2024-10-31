using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View("OrdersList");
        }
    }
}
