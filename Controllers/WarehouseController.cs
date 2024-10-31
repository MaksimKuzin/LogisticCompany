using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.Controllers
{
    public class WarehouseController : Controller
    {
        public IActionResult Index()
        {
            return View("WarehousesList");
        }
    }
}
