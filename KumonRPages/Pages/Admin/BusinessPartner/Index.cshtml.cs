using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KumonRPages.Pages.Admin.BusinessPartner
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<EMQV.Models.Master.BusinessPartner> BusinessPartners { get; set; }
        public async Task OnGet()
        {
            BusinessPartners = await _db.BusinessPartner.ToListAsync();
        }


        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            var contact = await _db.BusinessPartner.FindAsync(id);

            if (contact != null)
            {
                _db.BusinessPartner.Remove(contact);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
