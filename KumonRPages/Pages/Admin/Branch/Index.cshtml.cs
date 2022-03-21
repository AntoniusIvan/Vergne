using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using EMQV.Repository.Branch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KumonRPages.Pages.Admin.Branch
{
    public class IndexModel : PageModel
    {
        private readonly IBranchRepository _compRepo;

        public IndexModel(IBranchRepository compRepo)
        {
            _compRepo = compRepo;
        }

        [BindProperty]
        public IEnumerable<EMQV.Models.Master.Branch> branchs { get; set; }
        public IActionResult OnGet()
        {
            branchs = _compRepo.GetAll();

            return Page();
            //SubCategories = _compRepo.GetAll();
            //return "";
            //return Task();
        }


        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            //var contact = await _db.Branch.FindAsync(id);

            //if (contact != null)
            //{
            //    _db.Branch.Remove(contact);
            //    await _db.SaveChangesAsync();
            //}

            return RedirectToPage();
        }
    }
}
