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

namespace EMQV.Repository.Brand
{
    public class BrandRepository : IBrandRepository
    {
        private IDbConnection db;
        public BrandRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public bool HaveData()
        {
            var sql = @"SELECT CASE WHEN EXISTS(SELECT 1 FROM dbo.Brand) THEN 0 ELSE 1 END AS IsEmpty";

            var tempQuery1 = db.Query<bool>(sql).FirstOrDefault();

            bool tempBool1 = false;

            //return db.Query<EMQV.Models.Master.Brand>(sql, new { @BrandId = "" }).Single();
            return tempBool1;
        }
        public List<EMQV.Models.Master.Brand> GetAll()
        {
            var sql = "SELECT * FROM Brand";
            return db.Query<EMQV.Models.Master.Brand>(sql).ToList();
        }
        public EMQV.Models.Master.Brand FindMaxID(string id)
        {
            var sql = @"SELECT TOP 1 *
                        FROM dbo.Brand
                                WHERE IsDeleted = 0
                        ORDER BY CAST(RIGHT(BrandID, LEN(BrandID) - 2) AS int) DESC";
            return db.Query<EMQV.Models.Master.Brand>(sql, new { @BrandId = id }).Single();
        }


        public EMQV.Models.Master.Brand Add(EMQV.Models.Master.Brand brand)
        {

            var sql = @"SELECT TOP 1 *
                                                FROM dbo.Brand
                                                WHERE IsDeleted = 0
                                                ORDER BY CAST(RIGHT(BrandID,LEN(BrandID)-2) AS int) DESC";

            EMQV.Models.Master.Brand tempQuery1 = db.Query<EMQV.Models.Master.Brand>(sql).FirstOrDefault();

            if (tempQuery1 != null)
            {
                int amount = 0;
                int tempIteger;
                tempIteger = tempQuery1.BrandID.Length - 2;

                if (int.TryParse(tempQuery1.BrandID.Substring(tempQuery1.BrandID.Length - tempIteger), out amount))
                {
                    brand.BrandID = "01" + (amount + 1).ToString();
                    brand.IsDeleted = false;
                    brand.ModifiedDate = DateTime.Now;
                }
            }
            else
            {
                brand.BrandID = "011";
                brand.IsDeleted = false;
                brand.ModifiedDate = DateTime.Now;
            }

            var sql1 = @"INSERT INTO Brand (BrandID, Code, Name
                        , Address1, Address2, Address3
                        , IsDeleted, ModifiedDate
                        , Phone, CityID, Position, PIC
                        ) 
                        VALUES (@BrandID, @Code, @Name
                        , @Address1, @Address2, @Address3
                        , @IsDeleted, @ModifiedDate
                        , @Phone, @CityID, @Position, @PIC
                        ) ";

            db.Execute(sql1, brand);

            return brand;

        }

        public EMQV.Models.Master.Brand Update(EMQV.Models.Master.Brand brand)
        {
            var sql = @"UPDATE Brand SET Code = @Code, Name = @Name
                    , Address1 = @Address1, Address2 = @Address2, Address3 = @Address3
                    , ModifiedDate = GETDATE()
                    , Phone = @Phone, Position = @Position, PIC = @PIC
                     WHERE BrandID = @BrandID";


            db.Execute(sql, brand);

            return brand;
        }

        public EMQV.Models.Master.Brand Find(string id)
        {
            var sql = "SELECT * FROM Brand WHERE BrandID = @BrandID";
            return db.Query<EMQV.Models.Master.Brand>(sql, new { @BrandID = id }).Single();
        }


        public void Remove(int id)
        {
            var sql = "DELETE FROM Brand WHERE BrandId = @Id";
            db.Execute(sql, new { id });
        }
    }
}
