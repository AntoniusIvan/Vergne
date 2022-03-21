using DevExpress.XtraBars;

namespace Kumon.Win
{
    partial class SourceApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceApplication));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.bsiLicense = new DevExpress.XtraBars.BarStaticItem();
            this.bhiIcon = new DevExpress.XtraBars.BarHeaderItem();
            this.bsiLeftFooter = new DevExpress.XtraBars.BarStaticItem();
            this.bsiServer = new DevExpress.XtraBars.BarStaticItem();
            this.bsiDatabase = new DevExpress.XtraBars.BarStaticItem();
            this.bsiTime = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bsiUser,
            this.bsiLicense,
            this.bhiIcon,
            this.bsiLeftFooter,
            this.bsiServer,
            this.bsiDatabase,
            this.bsiTime});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1068, 75);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.Merge += new DevExpress.XtraBars.Ribbon.RibbonMergeEventHandler(this.ribbon_Merge);
            // 
            // bsiUser
            // 
            this.bsiUser.Caption = "u";
            this.bsiUser.Id = 1;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiLicense
            // 
            this.bsiLicense.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiLicense.Caption = "l";
            this.bsiLicense.Id = 2;
            this.bsiLicense.Name = "bsiLicense";
            this.bsiLicense.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bhiIcon
            // 
            this.bhiIcon.Caption = "barHeaderItem1";
            this.bhiIcon.Id = 3;
            this.bhiIcon.Name = "bhiIcon";
            // 
            // bsiLeftFooter
            // 
            this.bsiLeftFooter.Caption = "barStaticItem1";
            this.bsiLeftFooter.Id = 4;
            this.bsiLeftFooter.Name = "bsiLeftFooter";
            this.bsiLeftFooter.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiServer
            // 
            this.bsiServer.Caption = "s";
            this.bsiServer.Glyph = ((System.Drawing.Image)(resources.GetObject("bsiServer.Glyph")));
            this.bsiServer.Id = 6;
            this.bsiServer.Name = "bsiServer";
            this.bsiServer.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiDatabase
            // 
            this.bsiDatabase.Caption = "d";
            this.bsiDatabase.Id = 7;
            this.bsiDatabase.Name = "bsiDatabase";
            this.bsiDatabase.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiTime
            // 
            this.bsiTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiTime.Caption = "18 Aug 2020 04:45:01";
            this.bsiTime.Id = 8;
            this.bsiTime.Name = "bsiTime";
            this.bsiTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiTime);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiLicense, true);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiServer, true);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiDatabase, true);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 512);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1068, 48);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // SourceApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 560);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SourceApplication";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "SourceApplication";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarHeaderItem bhiIcon;
        private DevExpress.XtraBars.BarStaticItem bsiLeftFooter;
        protected DevExpress.XtraBars.BarStaticItem bsiUser;
        protected DevExpress.XtraBars.BarStaticItem bsiLicense;
        protected DevExpress.XtraBars.BarStaticItem bsiServer;
        protected DevExpress.XtraBars.BarStaticItem bsiDatabase;
        private DevExpress.XtraBars.BarStaticItem bsiTime;
        private System.Windows.Forms.Timer timer;
        //private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        //private DevExpress.XtraBars.BarButtonItem bbiClear;
        //private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        //protected DevExpress.XtraBars.BarButtonItem bbiDesign;
        //protected DevExpress.XtraBars.BarButtonItem bbiUDF;
        //private DevExpress.XtraBars.BarSubItem barSubItem1;
    }
}

