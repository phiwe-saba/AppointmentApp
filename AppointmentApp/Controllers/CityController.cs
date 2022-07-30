using AppointmentApp.Data;
using AppointmentApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class CityController : Controller
    {
        private readonly AppointmentDbContext _db;

        public CityController(AppointmentDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<City> cityList = _db.Cities;
            return View(cityList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                _db.Cities.Add(city);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var cityValue = _db.Cities.Find(id);

            if(cityValue == null)
            {
                return NotFound();
            }

            return View(cityValue);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                _db.Cities.Update(city);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var cityValue = _db.Cities.Find(id);

            if(cityValue == null)
            {
                return NotFound();
            }

            return View(cityValue);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCity(int? id)
        {
            var cityValue = _db.Cities.Find(id);

            if(cityValue == null)
            {
                return NotFound();
            }

            _db.Cities.Remove(cityValue);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
