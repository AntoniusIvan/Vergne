using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KumonRPages.Pages.Admin.Product
{
    public class DetailModel : PageModel
    {
        private ApplicationDbContext _db;
        private IWebHostEnvironment _he;

        public DetailModel(ApplicationDbContext db, IWebHostEnvironment he)
        {
            _db = db;
            _he = he;
        }

        [BindProperty]
        public EMQV.Models.Master.Item Item { get; set; }
        [BindProperty]
        public IFormFile image { get; set; }
        public async Task OnGet(string id)
        {
            //Item = await _db.Item.FindAsync(id);
            ViewData["CategoryID"] = new SelectList(_db.Category.ToList(), "CategoryID", "Name");
            ViewData["BrandID"] = new SelectList(_db.Brand.ToList(), "BrandID", "Name");
            if (id == null)
            {
                //"notfound";//return NotFound();
            }

            //var product = _db.Item.Include(c => c.Category).Include(c => c.Brand)
            //    .FirstOrDefault(c => c.ItemID == id);
            Item = _db.Item.Include(c => c.Category).Include(c => c.Brand)
                .FirstOrDefault(c => c.ItemID == id);

            
            //if (product == null)
            //{
                //Brand = await _db.Brand.FindAsync(id);
                //return NotFound();
            //}

            //return View(product);
        }

        public async Task<IActionResult> OnPost()
        {
            //if (ModelState.IsValid)
            //{
            //    var ItemFromDb = await _db.Item.FindAsync(Item.ItemID);

            //    ItemFromDb.Name = Item.Name;
            //    ItemFromDb.Barcode = Item.Barcode;Z
            //    ItemFromDb.Code = Item.Code;
            //    ItemFromDb.Unit1 = Item.Unit1;
            //    ItemFromDb.GRIR = Item.GRIR;
            //    ItemFromDb.IsActiveInput = Item.IsActiveInput;
            //    ItemFromDb.UnitPrice1 = Item.UnitPrice1;
            //    ItemFromDb.Image = Item.Image;
            //    ItemFromDb.CategoryID = Item.CategoryID;
            //    ItemFromDb.BrandID = Item.BrandID;
            //    ItemFromDb.Notes = Item.Notes;
            //    ItemFromDb.ModifiedDate = Item.ModifiedDate;
            //    ItemFromDb.Length = Item.Length;

            //    await _db.SaveChangesAsync();

            //    return RedirectToPage("Index");
            //}

            //return RedirectToPage();
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    Item.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    Item.Image = "Images/noimage.PNG";
                }
                var ItemFromDb = await _db.Item.FindAsync(Item.ItemID);

                ItemFromDb.Name = Item.Name;
                ItemFromDb.Barcode = Item.Barcode;
                ItemFromDb.Code = Item.Code;
                ItemFromDb.Unit1 = Item.Unit1;
                ItemFromDb.GRIR = Item.GRIR;
                ItemFromDb.IsActiveInput = Item.IsActiveInput;
                ItemFromDb.UnitPrice1 = Item.UnitPrice1;
                ItemFromDb.Image = Item.Image;
                ItemFromDb.CategoryID = Item.CategoryID;
                ItemFromDb.BrandID = Item.BrandID;
                ItemFromDb.Notes = Item.Notes;
                ItemFromDb.ModifiedDate = Item.ModifiedDate;
                ItemFromDb.Length = Item.Length;

                //db item update bikin error ini
                //_db.Item.Update(Item);
                await _db.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToPage();
            }

            return RedirectToPage();
            //return View(item);
        }
    }
}
