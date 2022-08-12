using AppointmentApp.Data;
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
            
            IEnumerable<Suburb> suburbList = _db.Suburbs;
            return View(suburbList);
        }

        //GET
        public IActionResult Create()
        {
            ViewBag.CityId = new SelectList(_db.Cities, "CityId", "CityName");

            //ViewBag.Cities = new SelectList(_db.Cities, "Cityid", "CityName");
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SuburbName, PostalCode, CityId")] Suburb suburb)
        {
            if (ModelState.IsValid)
            {
                _db.Suburbs.Add(suburb);
                _db.SaveChanges();
                TempData["success"] = "City created successfully";
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(_db.Cities, "Cityid", "CityName");
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
