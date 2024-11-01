using LogisticCompany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LogisticCompany.Controllers
{
    public class CourierController : Controller
    {
        LCDBContext _db = new LCDBContext();
        public IActionResult Index()
        {
            var model = _db.Couriers.AsEnumerable();
            return View("CouriersList",model);
        }
        public IActionResult Create()
        {
            var model = new Courier();
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Create(Courier courier, string birthDate, string endWorkTime, string startWorkTime, string employmentDate)
        {
            courier.BirthDate = DateOnly.Parse(birthDate);
            courier.EndWorkTime = TimeOnly.Parse(endWorkTime);
            courier.StartWorkTime = TimeOnly.Parse(startWorkTime);
            courier.EmploymentDate = DateOnly.Parse(employmentDate);
            _db.Couriers.Add(courier);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var model = _db.Couriers.FirstOrDefault(x => x.Id == id);
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Edit(Courier courier, string birthDate, string endWorkTime, string startWorkTime, string employmentDate)
        {
            courier.BirthDate = DateOnly.Parse(birthDate);
            courier.EndWorkTime = TimeOnly.Parse(endWorkTime);
            courier.StartWorkTime = TimeOnly.Parse(startWorkTime);
            courier.EmploymentDate = DateOnly.Parse(employmentDate);
            _db.Couriers.Update(courier);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var courier = _db.Couriers.FirstOrDefault(x => x.Id == id);
            _db.Couriers.Remove(courier);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Search(string searchString)
        {
            if (searchString == null || searchString.IsNullOrEmpty())
                return RedirectToAction("Index");
            var model = _db.Couriers.Where(x => x.FIO.Contains(searchString));
            return View("CouriersList", model);
        }
    }
}
