using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV;
using EMQV.Models.Master;
using EMQV.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KumonRPages.Pages.Admin.Brand
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        //bind property jadi tidak usah lempar parameter di OnPost
        [BindProperty]
        public EMQV.Models.Master.Brand brand { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {

            EMQV.Models.Master.Brand testRaw22 = new EMQV.Models.Master.Brand();
            using (_db)
            {
                var tempBrand = _db.Brand.ToList();
                int countDbBrand = tempBrand.Count;
                if (countDbBrand == 0)
                {
                    brand.BrandID = "011";
                    brand.IsDeleted = false;
                    brand.ModifiedDate = DateTime.Now;
                }
                else
                {
                    EMQV.Models.Master.Brand testRaw21 = new EMQV.Models.Master.Brand();

                    if (DatabaseType.MariaDb == DatabaseType.MariaDb)
                    {
                        testRaw21 = _db.Brand
                        //.FromSqlRaw("SELECT TOP 1 CAST(RIGHT(BrandID,LEN(BrandID)-2) AS int) " +
                        .FromSqlRaw(@"SELECT *
                                                FROM Brand
                                                WHERE IsDeleted = 0
                                                ORDER BY CAST(RIGHT(BrandID,LENGTH(BrandID)-2) AS int) DESC
                                                LIMIT 1")
                        .ToList()[0];
                    }
                    else
                    {
                        testRaw21 = _db.Brand
                                        //.FromSqlRaw("SELECT TOP 1 CAST(RIGHT(BrandID,LEN(BrandID)-2) AS int) " +
                                        .FromSqlRaw(@"SELECT TOP 1 *
                                                FROM dbo.Brand
                                                WHERE IsDeleted = 0
                                                ORDER BY CAST(RIGHT(BrandID,LEN(BrandID)-2) AS int) DESC ")
                                        .ToList()[0];
                    }

                    if (testRaw21 != null)
                    {
                        int amount;
                        int tempIteger;
                        tempIteger = testRaw21.BrandID.Length - 2;
                        if (int.TryParse(testRaw21.BrandID.Substring(testRaw21.BrandID.Length - tempIteger), out amount))
                        {
                            brand.BrandID = "01" + (amount + 1).ToString();
                            brand.IsDeleted = false;
                            brand.ModifiedDate = DateTime.Now;
                        }
                        //Brand.BrandID = int.TryParse(Brand.BrandID.Substring(Brand.BrandID.Length - 2));

                    }
                    else
                    {
                        brand.BrandID = "011";
                        brand.IsDeleted = false;
                        brand.ModifiedDate = DateTime.Now;
                    }
                }
                _db.Brand.Add(brand);
                await _db.SaveChangesAsync();
                TempData["save"] = "Brand has been saved";
                return Page();
            }
        }
    }
}
