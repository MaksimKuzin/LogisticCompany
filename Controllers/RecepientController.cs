using LogisticCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.Controllers
{
    public class RecepientController : Controller
    {
        LCDBContext _db = new LCDBContext();
        public IActionResult Index()
        {
            var model = _db.Recepients.AsEnumerable();
            return View("RecepientsList", model);
        }
        public IActionResult Create()
        {
            var model = new Recepient();
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Create(Recepient recepient)
        {
            _db.Recepients.Add(recepient);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var model = _db.Recepients.FirstOrDefault(x => x.Id == id);
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Edit(Recepient recepient)
        {
            _db.Recepients.Update(recepient);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var recepient = _db.Recepients.FirstOrDefault(x => x.Id == id);
            _db.Remove(recepient);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
