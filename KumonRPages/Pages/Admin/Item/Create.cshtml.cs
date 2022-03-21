using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMQV.Models.Master;
using EMQV.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KumonRPages.Pages.Admin.Item
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
        public EMQV.Models.Master.Item item { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {

            EMQV.Models.Master.Item testRaw22 = new EMQV.Models.Master.Item();
            using (_db)
            {
                var tempItem = _db.Item.ToList();
                int countDbItem = tempItem.Count;
                if (countDbItem == 0)
                {
                    item.ItemID = "011";
                    item.IsDeleted = false;
                    item.ModifiedDate = DateTime.Now;
                }
                else
                {
                    EMQV.Models.Master.Item testRaw21 = new EMQV.Models.Master.Item();
                    testRaw21 = _db.Item
                                        //.FromSqlRaw("SELECT TOP 1 CAST(RIGHT(ItemID,LEN(ItemID)-2) AS int) " +
                                        .FromSqlRaw(@"SELECT TOP 1 *
                                                FROM dbo.Item
                                                WHERE IsDeleted = 0
                                                ORDER BY CAST(RIGHT(ItemID,LEN(ItemID)-2) AS int) DESC ")
                                        .ToList()[0];

                    if (testRaw21 != null)
                    {
                        int amount;
                        int tempIteger;
                        tempIteger = testRaw21.ItemID.Length - 2;
                        if (int.TryParse(testRaw21.ItemID.Substring(testRaw21.ItemID.Length - tempIteger), out amount))
                        {
                            item.ItemID = "01" + (amount + 1).ToString();
                            item.IsDeleted = false;
                            item.ModifiedDate = DateTime.Now;
                        }
                        //Item.ItemID = int.TryParse(Item.ItemID.Substring(Item.ItemID.Length - 2));

                    }
                    else
                    {
                        item.ItemID = "011";
                        item.IsDeleted = false;
                        item.ModifiedDate = DateTime.Now;
                    }
                }
                _db.Item.Add(item);
                await _db.SaveChangesAsync();
                TempData["save"] = "Item has been saved";
                return Page();
            }
        }
    }
}
