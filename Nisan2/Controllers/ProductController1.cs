using Microsoft.AspNetCore.Mvc;
using Nisan2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Nisan2.Controllers
{
    public class ProductController : Controller
    {
        // Geçici ürün listesi
        private static List<Product> products = new List<Product>();

        // Ürün Listeleme
        public IActionResult Index()
        {
            return View(products);
        }

        // Ürün Detayı
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // Yeni Ürün Ekleme (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Ürün Ekleme (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return RedirectToAction(nameof(Index));
        }

        // Ürün Güncelleme (GET)
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // Ürün Güncelleme (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Stock = updatedProduct.Stock;

            return RedirectToAction(nameof(Index));
        }

        // Ürün Silme
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                products.Remove(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
