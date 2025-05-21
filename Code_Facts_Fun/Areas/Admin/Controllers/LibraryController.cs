using Microsoft.AspNetCore.Mvc;
using Code.DataAccess.Repository.IRepository;
using Code.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Code_Facts_Fun.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LibraryController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public LibraryController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
    public IActionResult Index()
        {
            List<Product> productsList = _unitofwork.product.GetAll().ToList();
            return View(productsList);

        }
        [HttpGet]
    public IActionResult Create()
        {
            IEnumerable<SelectListItem> ClipsList = _unitofwork.clips.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            //ViewBag.Clips = ClipsList;
            ViewData["Clips"] = ClipsList;
            return View();
        }
        [HttpPost]
    public IActionResult Create(Product product)
        {
            product.Id = 0;
            product.Price = 0;
            product.ISBN = "Wasrwes123";
            if (ModelState.IsValid)
            {
                _unitofwork.product.Add(product);
                _unitofwork.Save();
                TempData["success"] = "The product added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? prodcut = _unitofwork.product.Get(u => u.Id == id);
            if(prodcut == null)
            {
                return NotFound();
            }
            return View(prodcut);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.product.Update(product);
                _unitofwork.Save();
                TempData["update"] = "The product was updated successully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            Product? product = _unitofwork.product.Get(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? product = _unitofwork.product.Get(x => x.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            _unitofwork.product.Delete(product);
            _unitofwork.Save();
            TempData["delete"] = "The product was deleted successfully";
            return RedirectToAction("Index");
        }

        public IActionResult GetAll()
        {
            List<Product> products = _unitofwork.product.GetAll().ToList();
            return View(products.OrderByDescending(x => x.Id));
        }

    }   
}
