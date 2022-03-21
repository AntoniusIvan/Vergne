using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KumonRPages.Pages.Admin.Brand
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public IEnumerable<EMQV.Models.Master.Brand> Brands { get; set; }
        public async Task OnGet()
        {
            Brands = await _db.Brand.ToListAsync();
        }


        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            var contact = await _db.Brand.FindAsync(id);

            if (contact != null)
            {
                _db.Brand.Remove(contact);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
