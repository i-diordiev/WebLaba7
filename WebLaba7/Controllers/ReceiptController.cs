using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebLaba7.Data;
using WebLaba7.Models;
using WebLaba7.Models.ViewModels;

namespace WebLaba7.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ReceiptController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET
        public IActionResult Index()
        {
            IEnumerable<Receipt> receiptsList = _db.Receipts;
            
            return View(receiptsList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Receipts.Find(id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Receipts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Receipts.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ReceiptVM viewmodel = new ReceiptVM();
            
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReceiptVM vm)
        {
            if (ModelState.IsValid)
            {
                _db.Receipts.Add(vm.Receipt);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}