using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Batch24.Models;

namespace Shopping_Batch24.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDBContext _context;
        public ProductController(AppDBContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            //eager loading
            var objProductList = _context.Products
                .Where(u => u.IsActive == true)
                .Include(u => u.Category)
                .ToList();
            return View(objProductList);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product model)
        {
            try
            {
                _context.Products.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var Product = _context.Products.Find(id);
            return View(Product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product Product)
        {
            try
            {
                _context.Products.Update(Product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.Products.Find(id);
            data.IsActive = false;
            _context.Products.Update(data);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

    
