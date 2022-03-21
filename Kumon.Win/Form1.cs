//using EMQV.Win;
using EMQV;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kumon.Win
{
    public partial class Form1 : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }
        public class ConnectionStrings
        {
            public string DefaultConnection { get; set; }
            public string MariaDbConnectionString { get; set; }

        }

        private IConfigurationRoot _configuration;
        private string _connection { get { return Microsoft
                           .Extensions
                           .Configuration
                           .ConfigurationExtensions
                           .GetConnectionString(_configuration, "MariaDbConnectionString"); ; } }
        public Form1()
        {
            InitializeComponent();
        }

        private void sbFindObject_Click(object sender, EventArgs e)
        {

            var mySettings = Program.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
            string tempString1 = "";
            if (DatabaseType.MariaDb == DatabaseType.MariaDb)
            {
                tempString1 = mySettings.MariaDbConnectionString;
            }
            else
            {
                tempString1 = mySettings.DefaultConnection;
            }

            dynamic obj = Utility.FindObject("BranchID, Address1", "Branch", "BranchID = '013'", "", "", "",tempString1);

            List<dynamic> list = obj;
            teResultFindObject.EditValue = obj[0].BranchID;
        }

        private void sbGetObject_Click(object sender, EventArgs e)
        {
            teResultGetObject.EditValue = teGetObject.EditValue;
        }

        private void sbGetObjects_Click(object sender, EventArgs e)
        {
            teResultGetObjects.EditValue = teGetObjects.EditValue;
        }
    }
}
