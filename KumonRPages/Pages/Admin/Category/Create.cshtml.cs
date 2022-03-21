using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMQV.Data;
using KumonRPages.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using Microsoft.EntityFrameworkCore;
using EMQV;

namespace KumonRPages.Pages.Admin.Category
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EMQV.Models.Master.Category category { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            EMQV.Models.Master.Category testRaw22 = new EMQV.Models.Master.Category();
            using (_db)
            {
                var tempCategory = _db.Category.ToList();
                int countDbCategory = tempCategory.Count;
                if (countDbCategory == 0)
                {
                    category.CategoryID = "011";
                    category.IsDeleted = false;
                    category.ModifiedDate = DateTime.Now;
                }
                else
                {
                    EMQV.Models.Master.Category testRaw21 = new EMQV.Models.Master.Category();
                    if (DatabaseType.MariaDb == DatabaseType.MariaDb)
                    {
                        testRaw21 = _db.Category
                                        .FromSqlRaw(@"SELECT *
                                                FROM Category
                                                WHERE IsDeleted = 0
                                                ORDER BY CAST(RIGHT(CategoryID,LENGTH(CategoryID)-2) AS int) DESC 
                                                LIMIT 1")
                                        .ToList()[0];
                    }
                    else
                    {
                        testRaw21 = _db.Category
                                        .FromSqlRaw(@"SELECT TOP 1 *
                                                FROM dbo.Category
                                                WHERE IsDeleted = 0
                                                ORDER BY CAST(RIGHT(CategoryID,LEN(CategoryID)-2) AS int) DESC ")
                                        .ToList()[0];
                    }

                    if (testRaw21 != null)
                    {
                        int amount;
                        int tempIteger;
                        if (testRaw21.CategoryID == null)
                        {
                            return RedirectToPage("./Index");
                        }
                        else
                        {

                            tempIteger = testRaw21.CategoryID.Length - 2;
                            if (int.TryParse(testRaw21.CategoryID.Substring(testRaw21.CategoryID.Length - tempIteger), out amount))
                            {
                                category.CategoryID = "01" + (amount + 1).ToString();
                                category.IsDeleted = false;
                                category.ModifiedDate = DateTime.Now;
                            }
                        }
                        //Category.CategoryID = int.TryParse(Category.CategoryID.Substring(Category.CategoryID.Length - 2));

                    }
                    else
                    {
                        category.CategoryID = "011";
                        category.IsDeleted = false;
                        category.ModifiedDate = DateTime.Now;
                    }
                }
                _db.Category.Add(category);
                await _db.SaveChangesAsync();
                TempData["save"] = "Category has been saved";
                //return Page();
                return RedirectToPage("./Index");
            }
        }
    }
}