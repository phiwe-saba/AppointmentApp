﻿using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
