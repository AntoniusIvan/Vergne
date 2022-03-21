using EMQV.Models.Master;
using EMQV.Data;
using KumonRPages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KumonRPages.Pages.Admin.Role
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;

        public IndexModel(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public List<Microsoft.AspNetCore.Identity.IdentityRole> roles { get; set; }

        public IActionResult OnGetAsync()
        {


            var tempRoles = _roleManager.Roles.ToList();
            roles = tempRoles;

            //if (_roleManager != null)
            //{
            //    var tempRole = _roleManager.Roles.ToList();
            //    role = tempRole;
            //}
            //else
            //{

            //}

            return Page();

            //Category = await _context.Category.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            var contact = await _context.Category.FindAsync(id);

            if (contact != null)
            {
                _context.Category.Remove(contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
