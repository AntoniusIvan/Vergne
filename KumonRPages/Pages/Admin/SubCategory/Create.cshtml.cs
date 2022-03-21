using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using EMQV.Repository.SubCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KumonRPages.Pages.Admin.SubCategory
{
    public class CreateModel : PageModel
    {
        private readonly ISubCategoryRepository _compRepo;
        public CreateModel(ISubCategoryRepository compRepo)
        {
            _compRepo = compRepo;
        }
        //bind property jadi tidak usah lempar parameter di OnPost
        [BindProperty]
        public EMQV.Models.Master.SubCategory subCategory { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            EMQV.Models.Master.SubCategory testRaw22 = new EMQV.Models.Master.SubCategory();

            int tempInt1 = 0;

            bool tempComp = _compRepo.HaveData();

            if (tempComp)
            {
                subCategory.SubCategoryID = "011";
                subCategory.IsDeleted = false;
                subCategory.ModifiedDate = DateTime.Now;
            }
            else
            {
                _compRepo.Add(subCategory);
            }

            //tempInt1 = 
            return RedirectToPage("./Index");
            //EMQV.Models.Master.SubCategory testRaw22 = new EMQV.Models.Master.SubCategory();
            //using (_compRepo)
            //{
            //    var tempSubCategory = _db.SubCategory.ToList();
            //    int countDbSubCategory = tempSubCategory.Count;
            //    if (countDbSubCategory == 0)
            //    {
            //        subCategory.SubCategoryID = "011";
            //        subCategory.IsDeleted = false;
            //        subCategory.ModifiedDate = DateTime.Now;
            //    }
            //    else
            //    {
            //        EMQV.Models.Master.SubCategory testRaw21 = new EMQV.Models.Master.SubCategory();
            //        testRaw21 = _db.SubCategory
            //                            //.FromSqlRaw("SELECT TOP 1 CAST(RIGHT(SubCategoryID,LEN(SubCategoryID)-2) AS int) " +
            //                            .FromSqlRaw(@"SELECT TOP 1 *
            //                                    FROM dbo.SubCategory
            //                                    WHERE IsDeleted = 0
            //                                    ORDER BY CAST(RIGHT(SubCategoryID,LEN(SubCategoryID)-2) AS int) DESC ")
            //                            .ToList()[0];

            //        if (testRaw21 != null)
            //        {
            //            int amount;
            //            int tempIteger;
            //            tempIteger = testRaw21.SubCategoryID.Length - 2;
            //            if (int.TryParse(testRaw21.SubCategoryID.Substring(testRaw21.SubCategoryID.Length - tempIteger), out amount))
            //            {
            //                subCategory.SubCategoryID = "01" + (amount + 1).ToString();
            //                subCategory.IsDeleted = false;
            //                subCategory.ModifiedDate = DateTime.Now;
            //            }
            //            //Brand.BrandID = int.TryParse(Brand.BrandID.Substring(Brand.BrandID.Length - 2));

            //        }
            //        else
            //        {
            //            subCategory.SubCategoryID = "011";
            //            subCategory.IsDeleted = false;
            //            subCategory.ModifiedDate = DateTime.Now;
            //        }
            //    }
            //    _db.SubCategory.Add(subCategory);
            //    await _db.SaveChangesAsync();
            //    TempData["save"] = "SubCategory has been saved";
            //    return Page();
            //}
        }
    }
}
