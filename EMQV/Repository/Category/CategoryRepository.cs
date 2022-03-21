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

namespace EMQV.Repository.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private IDbConnection db;
        public CategoryRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public bool HaveData()
        {
            var sql = @"SELECT CASE WHEN EXISTS(SELECT 1 FROM dbo.Category) THEN 0 ELSE 1 END AS IsEmpty";

            var tempQuery1 = db.Query<bool>(sql).FirstOrDefault();

            bool tempBool1 = false;

            //return db.Query<EMQV.Models.Master.Category>(sql, new { @CategoryId = "" }).Single();
            return tempBool1;
        }
        public List<EMQV.Models.Master.Category> GetAll()
        {
            var sql = "SELECT * FROM Category";
            return db.Query<EMQV.Models.Master.Category>(sql).ToList();
        }
        public EMQV.Models.Master.Category FindMaxID(string id)
        {
            var sql = @"SELECT TOP 1 *
                        FROM dbo.Category
                                WHERE IsDeleted = 0
                        ORDER BY CAST(RIGHT(CategoryID, LEN(CategoryID) - 2) AS int) DESC";
            return db.Query<EMQV.Models.Master.Category>(sql, new { @CategoryId = id }).Single();
        }


        public EMQV.Models.Master.Category Add(EMQV.Models.Master.Category category)
        {

            var sql = @"SELECT TOP 1 *
                                                FROM dbo.Category
                                                WHERE IsDeleted = 0
                                                ORDER BY CAST(RIGHT(CategoryID,LEN(CategoryID)-2) AS int) DESC";

            EMQV.Models.Master.Category tempQuery1 = db.Query<EMQV.Models.Master.Category>(sql).FirstOrDefault();

            if (tempQuery1 != null)
            {
                int amount = 0;
                int tempIteger;
                tempIteger = tempQuery1.CategoryID.Length - 2;

                if (int.TryParse(tempQuery1.CategoryID.Substring(tempQuery1.CategoryID.Length - tempIteger), out amount))
                {
                    category.CategoryID = "01" + (amount + 1).ToString();
                    category.IsDeleted = false;
                    category.ModifiedDate = DateTime.Now;
                }
            }
            else
            {
                category.CategoryID = "011";
                category.IsDeleted = false;
                category.ModifiedDate = DateTime.Now;
            }

            var sql1 = @"INSERT INTO Category (CategoryID, Code, Name
                        , Address1, Address2, Address3
                        , IsDeleted, ModifiedDate
                        , Phone, CityID, Position, PIC
                        ) 
                        VALUES (@CategoryID, @Code, @Name
                        , @Address1, @Address2, @Address3
                        , @IsDeleted, @ModifiedDate
                        , @Phone, @CityID, @Position, @PIC
                        ) ";

            db.Execute(sql1, category);

            return category;

        }

        public EMQV.Models.Master.Category Update(EMQV.Models.Master.Category category)
        {
            var sql = @"UPDATE Category SET Code = @Code, Name = @Name
                    , Address1 = @Address1, Address2 = @Address2, Address3 = @Address3
                    , ModifiedDate = GETDATE()
                    , Phone = @Phone, Position = @Position, PIC = @PIC
                     WHERE CategoryID = @CategoryID";


            db.Execute(sql, category);

            return category;
        }

        public EMQV.Models.Master.Category Find(string id)
        {
            var sql = "SELECT * FROM Category WHERE CategoryID = @CategoryID";
            return db.Query<EMQV.Models.Master.Category>(sql, new { @CategoryID = id }).Single();
        }


        public void Remove(int id)
        {
            var sql = "DELETE FROM Category WHERE CategoryId = @Id";
            db.Execute(sql, new { id });
        }
    }
}
