using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using EMQV.Repository.Brand;
using EMQV.Repository.Category;
using EMQV.Repository.Item;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KumonRPages.Pages.Admin.Item
{
    public class EditModel : PageModel
    {
        private readonly IItemRepository _compItemRepo;
        private readonly ICategoryRepository _comCategoryRepo;
        private readonly IBrandRepository _comBrandRepo;
        private IWebHostEnvironment _he;

        public EditModel(IItemRepository compItemRepo, ICategoryRepository compCategoryRepository
                            , IBrandRepository comBrandRepo, IWebHostEnvironment he)
        {
            _compItemRepo = compItemRepo;
            _comCategoryRepo = compCategoryRepository;
            _comBrandRepo = comBrandRepo;
            _he = he;
        }

        [BindProperty]
        public EMQV.Models.Master.Item item { get; set; }
        public IFormFile image { get; set; }
        public async Task OnGet(string id)
        {
            ViewData["CategoryID"] = new SelectList(_comCategoryRepo.GetAll().ToList(), "CategoryID", "Name");
            ViewData["BrandID"] = new SelectList(_comBrandRepo.GetAll().ToList(), "BrandID", "Name");


            if (id == null)
            {
                //"notfound";//return NotFound();
            }

            item = _compItemRepo.Find(id);
            //Item = _db.Item.Include(c => c.Category).Include(c => c.Brand)
            //    .FirstOrDefault(c => c.ItemID == id);

            //Item = await _db.Item.FindAsync(id);

        }

        public IActionResult OnPost(string id)
        {
            EMQV.Models.Master.Item testRaw22 = new EMQV.Models.Master.Item();

            int tempInt1 = 0;

            //_compItemRepo.Update(item);

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    image.CopyTo(new FileStream(name, FileMode.Create));
                    item.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    item.Image = "Images/noimage.PNG";
                }
                _compItemRepo.Update(item);

                //await _db.SaveChangesAsync();
                return RedirectToPage();
            }

            return RedirectToPage();
        }
    }
}
