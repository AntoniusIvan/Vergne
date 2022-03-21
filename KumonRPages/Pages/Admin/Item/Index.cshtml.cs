using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using EMQV.Repository.Item;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KumonRPages.Pages.Admin.Item
{
    public class IndexModel : PageModel
    {
        private readonly IItemRepository _compRepo;

        public IndexModel(IItemRepository compRepo)
        {
            _compRepo = compRepo;
        }

        [BindProperty]
        public IEnumerable<EMQV.Models.Master.Item> items { get; set; }
        //public async Task OnGet()
        public IActionResult OnGet()
        {
            //Items = await _db.Item.Take(25).ToListAsync();
            var tempUNSUNS = _compRepo.GetRepAll();

            items = tempUNSUNS;

            return Page();
        }


        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            //var contact = await _db.Item.FindAsync(id);

            //if (contact != null)
            //{
            //    _db.Item.Remove(contact);
            //    await _db.SaveChangesAsync();
            //}
            _compRepo.Remove(id);

            return RedirectToPage();
        }
    }
}
