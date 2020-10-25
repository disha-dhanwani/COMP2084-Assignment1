/***
 * CONTROLLERS
 * STUDENT NAME: DISHA DHANWANI
 * STUDENT NUMBER: 200434069
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SneakerBoxStore.Data;
using SneakerBoxStore.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

/***
 *Creating the Controller for Sneakers
 */

namespace SneakerBoxStore.Controllers
{
    public class SneakersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SneakersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sneakers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sneakers.Include(s => s.BrandCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sneakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sneaker = await _context.Sneakers
                .Include(s => s.BrandCategory)
                .FirstOrDefaultAsync(m => m.SneakerId == id);
            if (sneaker == null)
            {
                return NotFound();
            }

            return View(sneaker);
        }

        // GET: Sneakers/Create
        public IActionResult Create()
        {
            ViewData["BrandCategoryId"] = new SelectList(_context.BrandCategories, "BrandCategoryId", "BrandName");
            return View();
        }

        // POST: Sneakers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SneakerId,BrandCategoryId,ModelName,ReleaseYear,Description,Material,Price,InStock")] Sneaker sneaker, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                //Validation for adding photos to the create form.
                //Check for a photo and upload
                if (Image.Length > 0)
                {
                    //get a temp location of the upload file
                    var tempFile = Path.GetTempFileName();

                    //create a unique name using a global unique ID (GUID)
                    var fileName = Guid.NewGuid() + "-" + Image.FileName;

                    //set the destination - dynamic - PATH and file name - one slah is not recognised as a path.
                    var uploadPath = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot\\img\\sneaker_upload\\" + fileName;

                    //using a STREAM to create a new file
                    using var stream = new FileStream(uploadPath, FileMode.Create);
                    await Image.CopyToAsync(stream);

                    //Add unique file name as the photo property of the new Product object
                    sneaker.Image = fileName;

                }


                _context.Add(sneaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandCategoryId"] = new SelectList(_context.BrandCategories, "BrandCategoryId", "BrandName", sneaker.BrandCategoryId);
            return View(sneaker);
        }

        // GET: Sneakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sneaker = await _context.Sneakers.FindAsync(id);
            if (sneaker == null)
            {
                return NotFound();
            }
            ViewData["BrandCategoryId"] = new SelectList(_context.BrandCategories, "BrandCategoryId", "BrandName", sneaker.BrandCategoryId);
            return View(sneaker);
        }

        // POST: Sneakers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SneakerId,BrandCategoryId,ModelName,ReleaseYear,Description,Material,Price,InStock")] Sneaker sneaker, IFormFile Image)
        {
            if (id != sneaker.SneakerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Check for a photo and upload
                    if (Image.Length > 0)
                    {
                        //get a temp location of the upload file
                        var tempFile = Path.GetTempFileName();

                        //create a unique name using a global unique ID (GUID)
                        var fileName = Guid.NewGuid() + "-" + Image.FileName;

                        //set the destination - dynamic - PATH and file name - one slah is not recognised as a path.
                        var uploadPath = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot\\img\\sneaker_upload\\" + fileName;

                        //using a STREAM to create a new file
                        using var stream = new FileStream(uploadPath, FileMode.Create);
                        await Image.CopyToAsync(stream);

                        //Add unique file name as the photo property of the new Product object
                        sneaker.Image = fileName;

                    }

                    _context.Update(sneaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SneakerExists(sneaker.SneakerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandCategoryId"] = new SelectList(_context.BrandCategories, "BrandCategoryId", "BrandName", sneaker.BrandCategoryId);
            return View(sneaker);
        }

        // GET: Sneakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sneaker = await _context.Sneakers
                .Include(s => s.BrandCategory)
                .FirstOrDefaultAsync(m => m.SneakerId == id);
            if (sneaker == null)
            {
                return NotFound();
            }

            return View(sneaker);
        }

        // POST: Sneakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sneaker = await _context.Sneakers.FindAsync(id);
            _context.Sneakers.Remove(sneaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SneakerExists(int id)
        {
            return _context.Sneakers.Any(e => e.SneakerId == id);
        }
    }
}
