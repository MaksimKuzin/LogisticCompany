﻿using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View("Role");
        }
        [HttpPost]
        public IActionResult SelectRole(string role)
        {
            HttpContext.Session.SetString("UserRole", role);
            return RedirectToAction("Index", "Home");
        }
    }
}
