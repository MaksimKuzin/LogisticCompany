using LogisticCompany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Create()
        {
            var model = new Order();
            ViewBag.Recepients = _db.Recepients.ToList();
            ViewBag.Couriers = _db.Couriers.ToList();
            ViewBag.Transports = _db.Transports.ToList();
            ViewBag.Warehouses = _db.Warehouses.ToList();
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Create(Order order, List<int> warehouses)
        {
            if (warehouses != null)
            {
                foreach (var warehouse in warehouses)
                {
                    order.Warehouses.Add(_db.Warehouses.FirstOrDefault(x => x.Id == warehouse));
                }
            }
            else order.Warehouses = null;
            order.OrderDate = DateTime.Now;
            _db.Orders.Add(order);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var model = _db.Orders.FirstOrDefault(x => x.Id == id);
            ViewBag.Recepients = _db.Recepients.ToList();
            ViewBag.Couriers = _db.Couriers.ToList();
            ViewBag.Transports = _db.Transports.ToList();
            ViewBag.Warehouses = _db.Warehouses.ToList();
            return View("CreateOrUpdate", model);
        }
        [HttpPost]
        public IActionResult Edit(Order order, List<int> warehouses)
        {
            var existingOrder = _db.Orders.Include(o => o.Warehouses).FirstOrDefault(o => o.Id == order.Id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.Warehouses.Clear();

            if (warehouses != null && warehouses.Any())
            {
                var selectedWarehouses = _db.Warehouses.Where(w => warehouses.Contains(w.Id)).ToList();
                foreach (var warehouse in selectedWarehouses)
                {
                    existingOrder.Warehouses.Add(warehouse);
                }
            }
            existingOrder.Sender = order.Sender;
            existingOrder.RecepientId = order.RecepientId;
            existingOrder.CourierId = order.CourierId;
            existingOrder.DeliveryDate = order.DeliveryDate;
            existingOrder.TransportId = order.TransportId;
            existingOrder.Price = order.Price;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var order = _db.Orders.FirstOrDefault(x => x.Id == id);
            _db.Orders.Remove(order);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CorpDiscount(int orderId)
        {
            _db.ApplyDiscountToOrder(orderId);
            return RedirectToAction("Index");
        }
    }
}
