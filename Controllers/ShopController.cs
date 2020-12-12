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
            
            var customerId = GetCustomerId();

            var cartItem = _context.Carts.SingleOrDefault(c => c.SneakerId == SneakerId && c.CustomerId == customerId);

            //If the specified product is not present in the cart, add it to cart (create new cart object)
            //Else, just update the quantity of that product in the cart.
            if (cartItem == null)
            {
                var cart = new Cart
                {
                    SneakerId = SneakerId,
                    Quantity = Quantity,
                    CustomerId = customerId,
                    DateCreated = DateTime.Now,
                    Price = price,
                    Size = Size
                };

                //save to the carts table in db
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }
            else
            {
                cartItem.Quantity += Quantity;
                _context.Carts.Update(cartItem);
                _context.SaveChanges();
            }

            return RedirectToAction("Cart");

        }

        private string GetCustomerId()
        {
            if(HttpContext.Session.GetString("CustomerId") == null)
            {
                HttpContext.Session.SetString("CustomerId", Guid.NewGuid().ToString());
            }

            return HttpContext.Session.GetString("CustomerId");
        }

        //GET: /Shop/Cart
        public IActionResult Cart()
        {
            var cartItems = _context.Carts.Include(c => c.Sneaker).Where(c => c.CustomerId == HttpContext.Session.GetString("CustomerId"));

            //calculate the total number of items in cart
            var numberOfItems = (from c in cartItems
                                 select c.Quantity).Sum();
            HttpContext.Session.SetInt32("NumberOfItems", numberOfItems);
            
            return View(cartItems);
        }

        //GET: /Shop/RemoveFromCart/3 (any id)
        public IActionResult RemoveFromCart(int id)
        {
            //Find the item and then remove it from cart. Redirect user back to Cart.
            var cartItem = _context.Carts.Find(id);
            if(cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Cart");
        }

        //Checkout forms

        //GET: /Shop/Checkout
        public IActionResult Checkout()
        {
            return View();
        }


    }
}
