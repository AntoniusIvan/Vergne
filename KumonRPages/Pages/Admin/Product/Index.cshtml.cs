using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KumonRPages.Pages.Admin.Product
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _he;

        public IndexModel(ApplicationDbContext db, IWebHostEnvironment he)
        {
            _db = db;
            _he = he;
        }

        [BindProperty]
        public IEnumerable<EMQV.Models.Master.Item> Items { get; set; }
        public async Task OnGet()
        {
            Items = _db.Item.Include(c => c.Category).Include(f => f.Brand).ToList();//.Take(25).ToListAsync();
        }


        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            var contact = await _db.Item.FindAsync(id);

            if (contact != null)
            {
                _db.Item.Remove(contact);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
