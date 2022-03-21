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
    public class CreateModel : PageModel
    {
        private readonly IBranchRepository _compRepo;
        public CreateModel(IBranchRepository compRepo)
        {
            _compRepo = compRepo;
        }
        //bind property jadi tidak usah lempar parameter di OnPost
        [BindProperty]
        public EMQV.Models.Master.Branch branch { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            EMQV.Models.Master.Branch testRaw22 = new EMQV.Models.Master.Branch();

            int tempInt1 = 0;

            bool tempComp = _compRepo.HaveData();

            if (!tempComp)
            {
                branch.BranchID = "011";
                branch.IsDeleted = false;
                branch.ModifiedDate = DateTime.Now;
                _compRepo.Add(branch);
            }
            else
            {
                _compRepo.Add(branch);
            }

            return Page();
        }
    }
}
