using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KumonRPages.Pages.Admin.Role
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public EMQV.Models.Master.Category Category { get; set; }
        public async Task OnGet(string id)
        {
            Category = await _db.Category.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CategoryFromDb = await _db.Category.FindAsync(Category.CategoryID);

                CategoryFromDb.Name = Category.Name;

                await _db.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return RedirectToPage();
        }
    }
}
