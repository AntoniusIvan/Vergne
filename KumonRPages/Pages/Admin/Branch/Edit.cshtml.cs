using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using EMQV.Repository.Branch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KumonRPages.Pages.Admin.Branch
{
    public class EditModel : PageModel
    {
        private readonly IBranchRepository _compRepo;
        public EditModel(IBranchRepository compRepo)
        {
            _compRepo = compRepo;
        }

        [BindProperty]
        public EMQV.Models.Master.Branch branch { get; set; }
        public async Task<IActionResult> OnGet(string id)
        {

            branch = _compRepo.Find(id);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            EMQV.Models.Master.Branch testRaw22 = new EMQV.Models.Master.Branch();

            int tempInt1 = 0;

            _compRepo.Update(branch);

            return Page();
        }
    }
}
