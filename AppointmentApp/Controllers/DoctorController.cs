using AppointmentApp.Data;
using AppointmentApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly AppointmentDbContext _db;
        public DoctorController(AppointmentDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Doctor> doctorsList = _db.Doctors;
            return View();
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _db.Doctors.Add(doctor);
                _db.SaveChanges();
                TempData["success"] = "Details added successfully";
                return RedirectToAction("Index");
            }
            return View(doctor);
        }
    }
}
