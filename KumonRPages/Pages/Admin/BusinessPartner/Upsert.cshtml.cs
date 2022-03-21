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
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public EMQV.Models.Master.BusinessPartner BusinessPartner { get; set; }
        public async Task<IActionResult> OnGet(string businessPartnerID)
        {
            BusinessPartner = new EMQV.Models.Master.BusinessPartner();
            if(businessPartnerID == null)
            {
                //create
                return Page();
            }

            //update
            BusinessPartner = await _db.BusinessPartner.FirstOrDefaultAsync(u => u.BusinessPartnerID == businessPartnerID);
            if (BusinessPartner == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(BusinessPartner.BusinessPartnerID))
                {
                    _db.BusinessPartner.Add(BusinessPartner);
                }
                else
                {
                    _db.BusinessPartner.Update(BusinessPartner);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
