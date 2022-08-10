﻿using AppointmentApp.Data;
using AppointmentApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppointmentApp.Controllers
{
    public class SuburbController : Controller
    {
        private readonly AppointmentDbContext _db;

        public SuburbController(AppointmentDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<City> cityList = new List<City>();
            cityList = (from city in _db.Cities select city).ToList();
            cityList.Insert(0, new City { CityId = 0, CityName = "Select city" });
            ViewBag.ListOfCities = cityList;
            IEnumerable<Suburb> suburbList = _db.Suburbs;

            
            return View(suburbList);
        }

        //GET
        public IActionResult Create()
        {
            
            List<City> cityList = new List<City>();
            cityList = (from city in _db.Cities select city).ToList();
            cityList.Insert(0, new City { CityId = 0, CityName = "Select city" });
            ViewBag.ListOfCities = cityList;

            
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Suburb suburb)
        {
            //if (city.CityId == 0)
            //{
            //    TempData["error"] = "City is not selected";
            //}
            //int cityValue = city.CityId;
            //ViewBag.SelectedValue = city.CityName;

            //List<City> cityList = new List<Models.City>();
            //cityList = (from cities in _db.Cities select city).ToList();
            //cityList.Insert(0, new City { CityId = 0, CityName = "Select city" });
            //ViewBag.ListOfCities = cityList;

            //var cityList = (from city in _db.Cities
            //                select new SelectListItem()
            //                {
            //                    Text = city.CityName,
            //                    Value = city.CityId.ToString(),
            //                }).ToList();

            //cityList.Insert(0, new SelectListItem()
            //{
            //    Text = "Select city",
            //    Value = String.Empty
            //});

            //ViewBag.listOfCities = cityList;

            if (ModelState.IsValid)
            {
                _db.Suburbs.Add(suburb);
                _db.SaveChanges();
                TempData["success"] = "City created successfully";
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(_db.Cities, "CityId", "CityName", suburb.CityId);
            return View(suburb);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var suburbValue = _db.Suburbs.Find(id);

            if (suburbValue == null)
            {
                return NotFound();
            }

            return View(suburbValue);
        }

        //POST
        public IActionResult Edit(Suburb suburb)
        {
            if (ModelState.IsValid)
            {
                _db.Suburbs.Update(suburb);
                _db.SaveChanges();
                TempData["success"] = "Suburb updated successfully";
                return RedirectToAction("Index");
            }
            return View(suburb);
        }
    }
}
