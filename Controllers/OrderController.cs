using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.Controllers
{
    public class OrderController : Controller
    {
        LCDBContext _db = new LCDBContext();
        public IActionResult Index()
        {
            var model = _db.Orders.AsEnumerable();
            return View("OrdersList", model);
        }
    }
}
