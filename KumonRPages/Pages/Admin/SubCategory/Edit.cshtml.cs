using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KumonRPages.Pages.Admin.SubCategory
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public EMQV.Models.Master.SubCategory SubCategory { get; set; }
        public async Task OnGet(string id)
        {
            SubCategory = await _db.SubCategory.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var SubCategoryFromDb = await _db.SubCategory.FindAsync(SubCategory.SubCategoryID);

                SubCategoryFromDb.Name = SubCategory.Name;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
