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
using EMQV;
using MySql.Data.MySqlClient;

namespace EMQV.Repository.Branch
{
    public class BranchRepository : IBranchRepository
    {

        private IConfiguration _configuratess;
        private string _conexion { get { return _configuratess.GetConnectionString("MariaDbConnectionString"); } }


        public BranchRepository(IConfiguration config)
        {
            _configuratess = config;
        }
        public bool HaveData()
        {
            bool tempQuery1 = false;
            int tempInt1 = 0;
            using (var conexao = new MySqlConnection(_conexion))
            {
                tempInt1 = conexao.Query<int>("SELECT COUNT(*) FROM Branch").FirstOrDefault();
                //var tempQuery1 = conexao.Query<EMQV.Models.Master.Branch>("SELECT CASE WHEN EXISTS(SELECT 1 FROM Branch) THEN 0 ELSE 1 END AS IsEmpty");
                if(tempInt1 == 0)
                {
                    tempQuery1 = false;
                }
                else
                {
                    tempQuery1 = true;
                }
            }

            return tempQuery1;
        }
        public IEnumerable<EMQV.Models.Master.Branch> GetAll()
        {
            using (var conexao = new MySqlConnection(_conexion))
            {
                return conexao.Query<EMQV.Models.Master.Branch>("SELECT * from Branch");
            }
        }
        public EMQV.Models.Master.Branch FindMaxID(string id)
        {

            return new EMQV.Models.Master.Branch();
        }


        public EMQV.Models.Master.Branch Add(EMQV.Models.Master.Branch branch)
        {
            var tempObj1 = branch;
            using (var conexao = new MySqlConnection(_conexion))
            {
                var temp = conexao.Query<EMQV.Models.Master.Branch>("SELECT * from Branch");

            }
            var sql = "";
            if (DatabaseType.MariaDb == DatabaseType.MariaDb)
            {

                sql = @"SELECT *
                                                FROM Branch
                                                WHERE IsDeleted = 0
                                                ORDER BY CAST(RIGHT(BranchID,LENGTH(BranchID)-2) AS int) DESC
                                                LIMIT 1";
            }
            else
            {
                sql = @"SELECT TOP 1 *
                                                FROM Branch
                                                WHERE IsDeleted = 0
                                                ORDER BY CAST(RIGHT(BranchID,LEN(BranchID)-2) AS int) DESC";
            }

            using (var conexao = new MySqlConnection(_conexion))
            {
                tempObj1 = conexao.Query<EMQV.Models.Master.Branch>(sql).FirstOrDefault();
                //var tempQuery1 = conexao.Query<EMQV.Models.Master.Branch>("SELECT CASE WHEN EXISTS(SELECT 1 FROM Branch) THEN 0 ELSE 1 END AS IsEmpty");
            }

            if (tempObj1 != null)
            {
                int amount = 0;
                int tempIteger;
                tempIteger = tempObj1.BranchID.Length - 2;

                if (int.TryParse(tempObj1.BranchID.Substring(tempObj1.BranchID.Length - tempIteger), out amount))
                {
                    branch.BranchID = "01" + (amount + 1).ToString();
                    branch.IsDeleted = false;
                    branch.ModifiedDate = DateTime.Now;
                }
            }
            else
            {
                branch.BranchID = "011";
                branch.IsDeleted = false;
                branch.ModifiedDate = DateTime.Now;
            }

            var sql1 = @"INSERT INTO Branch (BranchID, Code, Name
                        , Address1, Address2, Address3
                        , IsDeleted, ModifiedDate
                        , Phone, CityID, Position, PIC
                        ) 
                        VALUES (@BranchID, @Code, @Name
                        , @Address1, @Address2, @Address3
                        , @IsDeleted, @ModifiedDate
                        , @Phone, @CityID, @Position, @PIC
                        ) ";

            using (var conexao = new MySqlConnection(_conexion))
            {
                conexao.Execute(sql1, branch);
            }

            return branch;


        }

        public EMQV.Models.Master.Branch Update(EMQV.Models.Master.Branch branch)
        {

            return branch;
        }

        public EMQV.Models.Master.Branch Find(string id)
        {
            return new EMQV.Models.Master.Branch();
        }


        public void Remove(int id)
        {

        }
    }
}
