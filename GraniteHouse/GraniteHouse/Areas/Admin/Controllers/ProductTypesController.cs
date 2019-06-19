using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraniteHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {

        private readonly ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }
        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.productTypes.ToList());
        }
        //Get Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        //POST create action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Add(productTypes);
                Message = "Product Type has been added successfully";
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = await _db.productTypes.FindAsync(id);

            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        //POST edit action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductTypes productTypes)
        {
            if (id != productTypes.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(productTypes);
                Message = "Product Type has been updated successfully";
                await _db.SaveChangesAsync();



                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }
        
        //Get Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = await _db.productTypes.FindAsync(id);

            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        //POST edit action method
        //public async Task<IActionResult>Delete(int? id)
        // {
        //     var productType =await _db.productTypes.FindAsync(id);
        //     _db.productTypes.Remove(productType);

        //     await _db.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = await _db.productTypes.FindAsync(id);

            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        //POST edit action method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

                var productType = await _db.productTypes.FindAsync(id);
                _db.productTypes.Remove(productType);
                Message = "Product Type has been updated successfully";
                await _db.SaveChangesAsync();



                return RedirectToAction(nameof(Index));
        }
    }
}