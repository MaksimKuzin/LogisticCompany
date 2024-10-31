using LogisticCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.Controllers
{
    public class WarehouseController : Controller
    {
        LCDBContext _db = new LCDBContext();
        public IActionResult Index()
        {
            var model = _db.Warehouses.AsEnumerable();
            return View("WarehousesList", model);
        }
        public IActionResult Create()
        {
            var model = new Warehouse();
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Create(Warehouse warehouse)
        {
            _db.Warehouses.Add(warehouse);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var model = _db.Warehouses.FirstOrDefault(x => x.Id == id);
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Edit(Warehouse warehouse)
        {
            _db.Warehouses.Update(warehouse);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var warehouse = _db.Warehouses.FirstOrDefault(x => x.Id == id);
            _db.Warehouses.Remove(warehouse);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
