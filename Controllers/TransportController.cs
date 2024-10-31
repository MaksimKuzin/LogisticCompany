using LogisticCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.Controllers
{
    public class TransportController : Controller
    {
        LCDBContext _db = new LCDBContext();
        public IActionResult Index()
        {
            var model = _db.Tranports.AsEnumerable();
            return View("TransportsList", model);
        }
        public IActionResult Create()
        {
            var model = new Tranport();
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Create(Tranport tranport, string registrationDate)
        {
            tranport.RegistrationDate = DateOnly.Parse(registrationDate);
            _db.Tranports.Add(tranport);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var model = _db.Tranports.FirstOrDefault(x => x.Id == id);
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Edit(Tranport tranport, string registrationDate)
        {
            tranport.RegistrationDate = DateOnly.Parse(registrationDate);
            _db.Tranports.Update(tranport);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var transport = _db.Tranports.FirstOrDefault(x => x.Id == id);
            _db.Tranports.Remove(transport);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
