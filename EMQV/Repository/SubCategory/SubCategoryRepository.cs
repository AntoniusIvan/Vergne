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

namespace EMQV.Repository.SubCategory
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private IDbConnection db;
        public SubCategoryRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public bool HaveData()
        {
            var sql = @"SELECT CASE WHEN EXISTS(SELECT 1 FROM dbo.SubCategory) THEN 0 ELSE 1 END AS IsEmpty";

            var tempQuery1 = db.Query<bool>(sql).FirstOrDefault();

            bool tempBool1 = false;

            //return db.Query<EMQV.Models.Master.SubCategory>(sql, new { @SubCategoryId = "" }).Single();
            return tempBool1;
        }
        public List<EMQV.Models.Master.SubCategory> GetAll()
        {
            var sql = "SELECT * FROM SubCategory Where IsDeleted = 0";
            return db.Query<EMQV.Models.Master.SubCategory>(sql).ToList();
        }
        public EMQV.Models.Master.SubCategory FindMaxID(string id)
        {
            var sql = @"SELECT TOP 1 *
                        FROM dbo.SubCategory
                                WHERE IsDeleted = 0
                        ORDER BY CAST(RIGHT(SubCategoryID, LEN(SubCategoryID) - 2) AS int) DESC";
            return db.Query<EMQV.Models.Master.SubCategory>(sql, new { @SubCategoryId = id }).Single();
        }


        public EMQV.Models.Master.SubCategory Add(EMQV.Models.Master.SubCategory subCategory)
        {

            var sql = @"SELECT TOP 1 *
                                                FROM dbo.SubCategory
                                                WHERE IsDeleted = 0
                                                ORDER BY CAST(RIGHT(SubCategoryID,LEN(SubCategoryID)-2) AS int) DESC";

            EMQV.Models.Master.SubCategory tempQuery1 = db.Query<EMQV.Models.Master.SubCategory>(sql).FirstOrDefault();

            if (tempQuery1 != null)
            {
                int amount = 0;
                int tempIteger;
                tempIteger = tempQuery1.SubCategoryID.Length - 2;

                if (int.TryParse(tempQuery1.SubCategoryID.Substring(tempQuery1.SubCategoryID.Length - tempIteger), out amount))
                {
                    subCategory.SubCategoryID = "01" + (amount + 1).ToString();
                    subCategory.IsDeleted = false;
                    subCategory.ModifiedDate = DateTime.Now;
                }
            }
            else
            {
                subCategory.SubCategoryID = "011";
                subCategory.IsDeleted = false;
                subCategory.ModifiedDate = DateTime.Now;
            }

            var sql1 = "INSERT INTO SubCategory (SubCategoryID, Name, IsFood, IsBeverage, IsDeleted, ModifiedDate) VALUES (@SubCategoryID, @Name, @IsFood, @IsBeverage, @IsDeleted, @ModifiedDate)";


            //var id = db.Query<string>(sql1, subCategory).Single();

            //var id = db.Execute(sql1, subCategory);
            db.Execute(sql1, subCategory);

            //subCategory.SubCategoryID = id;

            return subCategory;
            //testRaw21 = _db.SubCategory
            //                    //.FromSqlRaw("SELECT TOP 1 CAST(RIGHT(SubCategoryID,LEN(SubCategoryID)-2) AS int) " +
            //                    .FromSqlRaw(@"SELECT TOP 1 *
            //                                    FROM dbo.SubCategory
            //                                    WHERE IsDeleted = 0
            //                                    ORDER BY CAST(RIGHT(SubCategoryID,LEN(SubCategoryID)-2) AS int) DESC ")
            //                    .ToList()[0];

            //var sql = "INSERT INTO SubCategory (Name, IsDeleted, ModifiedDate) VALUES (@Name, @IsDeleted, @ModifiedDate)";
            //var id = db.Query<string>(sql, subCategory).Single();

            // select


            //subCategory.SubCategoryID = id;
            //subCategory.IsDeleted = ;
            //subCategory.SubCategoryID = id;
            //return subCategory;
        }

        public EMQV.Models.Master.SubCategory Update(EMQV.Models.Master.SubCategory subCategory)
        {
            var sql = "UPDATE SubCategory SET Name = @name, Address = @Address, CIty = @City, State = @State, PostalCode = @PostalCode WHERE CompanyId = @CompanyId";
            db.Execute(sql, subCategory);
            return subCategory;
        }

        public EMQV.Models.Master.SubCategory Find(int id)
        {
            var sql = "SELECT * FROM Companies WHERE SubCategoryId = @SubCategoryId";
            return db.Query<EMQV.Models.Master.SubCategory>(sql, new { @SubCategoryId = id }).Single();
        }


        public void Remove(string id)
        {
            //var sql = "DELETE FROM SubCategory WHERE SubCategoryId = @Id";
            //db.Execute(sql, new { id });


            var sql = @"UPDATE SubCategory SET IsDeleted = 1
                        WHERE SubCategoryID = @SubCategoryID";
            db.Query(sql, new { @SubCategoryId = id }).Single();
        }
    }
}
