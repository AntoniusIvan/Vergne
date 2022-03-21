using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KumonRPages.Pages.Admin.BusinessPartner
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public EMQV.Models.Master.BusinessPartner BusinessPartner { get; set; }
        public async Task OnGet(string businessPartnerID)
        {
            BusinessPartner = await _db.BusinessPartner.FindAsync(businessPartnerID);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BusinessPartnerFromDb = await _db.BusinessPartner.FindAsync(BusinessPartner.BusinessPartnerID);

                BusinessPartnerFromDb.Code = BusinessPartner.Code;
                BusinessPartnerFromDb.Name = BusinessPartner.Name;
                BusinessPartnerFromDb.BusinessPartnerID = BusinessPartner.BusinessPartnerID;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
