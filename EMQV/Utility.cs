using Dapper;
using EMQV.Interface;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMQV
{
    public class Utility
    {

        public static BaseCurrentUser CurrentUser;
        public static IPrintManager PrintManager;
        public static string Server;
        public static string Database;



        public static object FindObject(string field, string tableName, string condition, string groupBy, string having, string orderBy, string connString)//, SqlConnection conn, SqlTransaction trans = null, int timeout = -1)
        {

            object obj2 = null;
            bool flag = false;

            string sql = "";




            if (!field.Trim().ToUpper().StartsWith("TOP 1"))
            {

                if (DatabaseType.MariaDb == DatabaseType.MariaDb)
                {
                }
                else
                {
                    field = string.Format("TOP 1 {0}", field);
                }
            }
            sql = string.Format("SELECT {0}", field);
            if (!string.IsNullOrEmpty(tableName))
            {
                sql = string.Format("{0} FROM {1}", sql, tableName);
            }
            if (!string.IsNullOrEmpty(condition))
            {
                sql = string.Format("{0} WHERE {1}", sql, condition);
            }
            if (!string.IsNullOrEmpty(groupBy))
            {
                sql = string.Format("{0} GROUP BY {1}", sql, groupBy);
            }
            if (!string.IsNullOrEmpty(having))
            {
                sql = string.Format("{0} HAVING {1}", sql, condition);
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                sql = string.Format("{0} ORDER BY {1}", sql, orderBy);
            }


            if (!field.Trim().ToUpper().StartsWith("TOP 1"))
            {
                if (DatabaseType.MariaDb == DatabaseType.MariaDb)
                {
                    sql = string.Format("{0} LIMIT 1", sql);
                }
                else
                {

                }
            }

            //using (var connection = new SqlConnection(GlobalConfig.GetConnectionString()))
            //{
            //    var orderDetail = connection.Query(sql).FirstOrDefault();

            //    //FiddleHelper.WriteTable(orderDetail);
            //}
            
            using (var conexao = new MySqlConnection(connString))
            {
                var tempObj1 = conexao.Query(sql).AsList();
                return tempObj1;
            }

            return obj2;
        }

        //public static DataRow GetModuleLayout(string moduleName, string moduleType)
        //{
        //    DataRow moduleLayout;
        //    try
        //    {
        //        //moduleLayout = GetObject("*", "ModuleLayout", string.Format("IsDeleted = 0 AND Name = '{0}' AND Type = '{1}' AND UserID = '{2}'", moduleName, moduleType, CurrentUser.Oid), "", "", "", DBConnection, null);
        //    }
        //    catch (Exception exception1)
        //    {
        //        if (exception1.HResult != -2146232060)
        //        {
        //            moduleLayout = null;
        //        }
        //        else
        //        {
        //            //Sudah dibuat di EF Core 6 table module
        //            //CreateTableModuleLayout();
        //            moduleLayout = GetModuleLayout(moduleName, moduleType);
        //        }
        //    }
        //    return moduleLayout;
        //}
    }
}
