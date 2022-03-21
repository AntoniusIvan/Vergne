using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using EMQV.Repository.SubCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KumonRPages.Pages.Admin.SubCategory
{
    public class IndexModel : PageModel
    {
        private readonly ISubCategoryRepository _compRepo;

        public IndexModel(ISubCategoryRepository compRepo)
        {
            _compRepo = compRepo;
        }

        [BindProperty]
        public IEnumerable<EMQV.Models.Master.SubCategory> subCategories { get; set; }
        public IActionResult OnGet()
        {
            subCategories = _compRepo.GetAll();

            return Page();
            //SubCategories = _compRepo.GetAll();
            //return "";
            //return Task();
        }


        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            //var contact = await _db.SubCategory.FindAsync(id);

            //if (contact != null)
            //{
            //    _db.SubCategory.Remove(contact);
            //    await _db.SaveChangesAsync();
            //}
            _compRepo.Remove(id);

            //return RedirectToPage();
            return RedirectToPage("./Index");
        }
    }
}
