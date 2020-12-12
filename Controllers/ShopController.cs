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
        //public IActionResult AddToCart(int SneakerId, int Quantity, string Size)
        //{
        //    var price = _context.Sneakers.Find(SneakerId).Price;

        //    var customerId = "test customer id";

        //    var cart = new ShoppingCart
        //    {
        //        SneakerId = SneakerId,
        //        Quantity = Quantity,
        //        CustomerId = customerId,
        //        DateAdded = DateTime.Now
        //    }

        //}

    }
}
