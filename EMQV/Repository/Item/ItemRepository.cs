using Dapper;
using EMQV.Data;
using EMQV.Models.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace EMQV.Repository.Item
{
    public class ItemRepository : IItemRepository
    {
        private IDbConnection db;
        public ItemRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public bool HaveData()
        {
            var sql = @"SELECT CASE WHEN EXISTS(SELECT 1 FROM dbo.Item) THEN 0 ELSE 1 END AS IsEmpty";

            var tempQuery1 = db.Query<bool>(sql).FirstOrDefault();

            bool tempBool1 = false;

            //return db.Query<EMQV.Models.Master.Item>(sql, new { @ItemId = "" }).Single();
            return tempBool1;
        }
        public List<EMQV.Models.Master.Item> GetRepAll()
        {
            //var sql = @"SELECT * FROM Item 
            //            WHERE IsDeleted = 0";
            //return db.Query<EMQV.Models.Master.Item>(sql).ToList();

            string sql2 = @"select TOP 500 A.ItemID, A.Code, A.IsAvailable, A.Name, A.Image
                                    , A.UnitPrice1
			                        , CASE 
				                        WHEN B.CategoryID IS NULL THEN '000'
				                        ELSE B.CategoryID
				                        END AS CategoryID
			                        , CASE 
				                        WHEN B.Name IS NULL THEN 'DbValNul'
				                        ELSE B.Name
			                        End As Name
			                        , CASE 
				                        WHEN C.BrandID IS NULL THEN '000'
				                        ELSE C.BrandID
				                        END AS BrandID
			                        , CASE 
				                        WHEN C.Name IS NULL THEN 'DbValNul'
				                        ELSE C.Name
			                        End As Name
                        from dbo.Item A
	                        left join dbo.Category B on A.CategoryID = B.CategoryID
	                        left join dbo.Brand C on A.BrandID = C.BrandID
                        WHERE A.IsDeleted = 0";

            var people = db.Query<EMQV.Models.Master.Item, EMQV.Models.Master.Category, EMQV.Models.Master.Brand, EMQV.Models.Master.Item>
                (sql2, (item, Category, Brand) =>
                {
                    item.Category = Category;
                    item.Brand = Brand;
                    return item;
                }, splitOn: "CategoryID,BrandID");

            var sql = @"SELECT * FROM Item 
                        WHERE IsDeleted = 0";
            //return db.Query<EMQV.Models.Master.Item>(sql).ToList();
            return people.ToList();
        }
        public EMQV.Models.Master.Item GetSelectedFor(EMQV.Models.Master.Item item)
        {
            string sql2 = String.Format(@"select TOP 1 A.ItemID, A.Code, A.IsAvailable, A.Name, A.Image
                                    , A.UnitPrice1
			                        , CASE 
				                        WHEN B.CategoryID IS NULL THEN '000'
				                        ELSE B.CategoryID
				                        END AS CategoryID
			                        , CASE 
				                        WHEN B.Name IS NULL THEN 'DbValNul'
				                        ELSE B.Name
			                        End As Name
			                        , CASE 
				                        WHEN C.BrandID IS NULL THEN '000'
				                        ELSE C.BrandID
				                        END AS BrandID
			                        , CASE 
				                        WHEN C.Name IS NULL THEN 'DbValNul'
				                        ELSE C.Name
			                        End As Name
                        from dbo.Item A
	                        left join dbo.Category B on A.CategoryID = B.CategoryID
	                        left join dbo.Brand C on A.BrandID = C.BrandID
                        WHERE A.IsDeleted = 0  AND A.ItemID = {0}", item.ItemID);

            var people = db.Query<EMQV.Models.Master.Item, EMQV.Models.Master.Category, EMQV.Models.Master.Brand, EMQV.Models.Master.Item>
                (sql2, (item, Category, Brand) =>
                {
                    item.Category = Category;
                    item.Brand = Brand;
                    return item;
                }, splitOn: "CategoryID,BrandID");

            //var sql = @"SELECT * FROM Item 
            //            WHERE IsDeleted = 0";
            return people.FirstOrDefault();
        }
        public EMQV.Models.Master.Item FindMaxID(string id)
        {
            var sql = @"SELECT TOP 1 *
                        FROM dbo.Item
                                WHERE IsDeleted = 0
                        ORDER BY CAST(RIGHT(ItemID, LEN(ItemID) - 2) AS int) DESC";
            return db.Query<EMQV.Models.Master.Item>(sql, new { @ItemId = id }).Single();
        }


        public EMQV.Models.Master.Item Add(EMQV.Models.Master.Item item)
        {

            var sql = @"SELECT TOP 1 *
                                                FROM dbo.Item
                                                WHERE IsDeleted = 0
                                                ORDER BY CAST(RIGHT(ItemID,LEN(ItemID)-2) AS int) DESC";

            EMQV.Models.Master.Item tempQuery1 = db.Query<EMQV.Models.Master.Item>(sql).FirstOrDefault();

            if (tempQuery1 != null)
            {
                int amount = 0;
                int tempIteger;
                tempIteger = tempQuery1.ItemID.Length - 2;

                if (int.TryParse(tempQuery1.ItemID.Substring(tempQuery1.ItemID.Length - tempIteger), out amount))
                {
                    item.ItemID = "01" + (amount + 1).ToString();
                    item.IsDeleted = false;
                    item.ModifiedDate = DateTime.Now;
                }
            }
            else
            {
                item.ItemID = "011";
                item.IsDeleted = false;
                item.ModifiedDate = DateTime.Now;
            }

            var sql1 = "INSERT INTO Item (ItemID, Name, IsFood, IsBeverage, IsDeleted, ModifiedDate) VALUES (@ItemID, @Name, @IsFood, @IsBeverage, @IsDeleted, @ModifiedDate)";

            db.Execute(sql1, item);

            return item;
        }

        public EMQV.Models.Master.Item Update(EMQV.Models.Master.Item item)
        {
            var sql = @"UPDATE Item SET Barcode = @Barcode
                        , BrandID = @BrandID
                        , CategoryID = @CategoryID
                        , Code = @Code
                        , GRIR = @GRIR
                        , IsActive = @IsActive
                        , IsBuyable = @IsBuyableInput
                        , IsAvailable = @IsAvailableInput
                        , Length = @Length
                        , ModifiedDate = GETDATE()
                        , Name = @Name, Notes = @Notes
                        , Unit1 = @Unit1
                        , UnitPrice1 = @UnitPrice1
                        , Image = @Image
                        WHERE ItemID = @ItemID";
            db.Execute(sql, item);
            return item;
        }

        public EMQV.Models.Master.Item Find(string id)
        {
            var sql = @"SELECT * FROM Item 
                        WHERE IsDeleted = 0 AND ItemId = @ItemId
                       ";
            return db.Query<EMQV.Models.Master.Item>(sql, new { @ItemId = id }).Single();
        }


        public void Remove(string id)
        {
            //var sql = "DELETE FROM Item WHERE ItemId = @Id";
            //db.Execute(sql, new { id });


            var sql = @"UPDATE Item SET IsDeleted = 1
                        WHERE ItemID = @ItemID";
            db.Execute(sql, id);
            
        }

        public List<EMQV.Models.Master.Item> SelectAllApi()
        {

            var sql = @"SELECT 
                            Name
                            ,Code
                            ,IsAvailable
                            ,UnitPrice1
                            ,ItemID
                            --Custom1 = x.Custom1
                            --Custom2 = x.Custom2,
                            --Custom3 = x.Custom3,
                            --Custom4 = x.Custom4,
                            --Decmdf1 = x.Decmdf1,
                            --Decmdf2 = x.Decmdf2,
                            --Decmdf3 = x.Decmdf3,
                            --ModifiedDate = x.ModifiedDate,
                            --IsDeleted = x.IsDeleted
                        FROM Item WHERE IsDeleted = 0
                    ";

            return db.Query<EMQV.Models.Master.Item>(sql).ToList();
        }

        public List<EMQV.Models.Master.Item> SelectTry2()
        {
            var sql = @"SELECT 
                            Name,
                            Code,
                            IsAvailable,
                            UnitPrice1,
                            ItemID
                        FROM Item WHERE IsDeleted = 0
                    ";
            var seeker3 = db.Query<EMQV.Models.Master.Item>(sql).ToList();

            //IList objList = (IList)seeker3;

            //List<EMQV.Models.Master.Item> list = db.Query<EMQV.Models.Master.Item>(sql).ToList();

            //// copy across all params
            //var list2 = list.Select(a => new AgentModel { ID = a.ID, Name = a.Name }).ToList();


            return db.Query<EMQV.Models.Master.Item>(sql).ToList();
        }

    }
}
