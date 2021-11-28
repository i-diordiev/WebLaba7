using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using WebLaba7.Data;
using WebLaba7.Models;
using WebLaba7.Models.ViewModels;

namespace WebLaba7.Controllers
{
    public class MedicineController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MedicineController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET
        public IActionResult Index()
        {
            IEnumerable<Medicine> medicineList = _db.Medicines;
            
            return View(medicineList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Medicines.Find(id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Medicines.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Medicines.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            MedicineVM viewmodel = new MedicineVM();
            
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MedicineVM vm)
        {
            if (ModelState.IsValid)
            {
                _db.Medicines.Add(vm.Medicine);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}