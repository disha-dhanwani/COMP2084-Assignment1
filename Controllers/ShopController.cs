using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SneakerBoxStore.Data;
using SneakerBoxStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerBoxStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.BrandCategories.OrderBy(c => c.BrandName).ToList();

            return View(categories);
        }

        //GET: /Shop/Browse/3
        public IActionResult Browse(int id)
        {
            var products = _context.Sneakers.Include(p => p.BrandCategory).Where(p => p.BrandCategoryId == id).OrderBy(p => p.ModelName).ToList();
            //ViewBag.BrandCategory = products[0].BrandCategory.BrandName;
            ViewBag.BrandCategory = _context.BrandCategories.Find(id).BrandName.ToString();
            return View(products);
        }

        //POST: /Shop/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int SneakerId, int Quantity, int Size)
        {
            var price = _context.Sneakers.Find(SneakerId).Price;
            
            int customerId = 2;

            var cart = new ShoppingCart
            {
                SneakerId = SneakerId,
                Quantity = Quantity,
                CustomerId = customerId,
                DateAdded = DateTime.Now.ToString(),
                Price = price,
                SneakerSize = Size
            };

            //save to the carts table in db
            _context.ShoppingCarts.Add(cart);
            _context.SaveChanges();

            return RedirectToAction("Cart");

        }

        private int GetCustomerId()
        {
            if(HttpContext.Session.GetInt32("CustomerId") == null)
            {
                HttpContext.Session.SetInt32("CustomerId", int.Parse(Guid.NewGuid().ToString()));
            }

            return (int)HttpContext.Session.GetInt32("CustomerId");
        }


    }
}
