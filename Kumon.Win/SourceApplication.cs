using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;
using EMQV.Models;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Kumon.Win.Helper;

namespace Kumon.Win
{
    public partial class SourceApplication : RibbonForm
    {
        public SourceApplication()
        {
            this.InitializeComponent();
        }


        protected virtual void InitForm()
        {
        }


        //protected internal RibbonStatusBar TeamCRibbonStatusBarompeting { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;
            this.Text = ConstStrings.AppTitle;
            this.Icon = ImagesHelper.AppIcon;
            this.SetLanguage();
            this.SetImage();
            this.bsiUser.Caption = "";
            this.RefreshLicense();
            this.InitForm();
        }

        protected void RefreshLicense()
        {
            //object obj = Utility.FindObject("CMNMCrypo", "License", "", "", "", "", Utility.DBConnection, (SqlTransaction)null, -1);
            //if (obj == null || obj == DBNull.Value || Utility.Decrypt(obj.ToString()) == "")
            //    this.bsiLicense.Caption = ConstStrings.Demo;
            //else
            //    this.bsiLicense.Caption = Utility.Decrypt(obj.ToString());

            // COMMENTED ON 2020-12-31 04:49
            //object obj2 = Utility.FindObject("CMNMCrypo", "License", "", "", "", "", Utility.DBConnection, null, -1);
            //this.bsiLicense.Caption = (((obj2 != null) && (obj2 != DBNull.Value)) && (Utility.Decrypt(obj2.ToString()) != "")) ? Utility.Decrypt(obj2.ToString()) : ConstStrings.Demo;
        }
        private void ribbon_Merge(object sender, RibbonMergeEventArgs e)
        {
            foreach (BarItemLink itemLink in (ReadOnlyCollectionBase)this.Ribbon.StatusBar.ItemLinks)
                itemLink.BeginGroup = true;
        }
        protected virtual void SetImage()
        {
        }
        protected virtual void SetLanguage()
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.bsiTime.Caption = string.Format("{0:dd MMM yyy HH:mm:ss}", (object)DateTime.Now);
        }

        protected internal DevExpress.XtraBars.Ribbon.RibbonStatusBar RibbonStatusBar
        {
            get
            {
                return this.ribbonStatusBar;
            }
        }

    }

}
