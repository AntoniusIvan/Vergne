using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kumon.Win
{
    partial class WfApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WfApplication));
            this.officeNavigationBar = new DevExpress.XtraBars.Navigation.OfficeNavigationBar();
            this.pmMain = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bbiServer = new DevExpress.XtraBars.BarButtonItem();
            this.bbiConfig = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLicense = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBackup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUpload = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClear = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLogin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLogout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDesign = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCustomize = new DevExpress.XtraBars.BarButtonItem();
            this.modulesContainer = new DevExpress.XtraEditors.XtraUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeNavigationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.pmMain;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiBackup,
            this.bbiUpload,
            this.bbiChangePassword,
            this.bbiLogin,
            this.bbiLogout,
            this.bbiExit,
            this.bbiLicense,
            this.bbiServer,
            this.bbiConfig,
            this.bbiClear,
            this.bbiSaveLayout,
            this.bbiDesign,
            this.bbiCustomize});
            this.ribbon.Margin = new System.Windows.Forms.Padding(14);
            this.ribbon.MaxItemId = 27;
            this.ribbon.QuickToolbarItemLinks.Add(this.bbiLogin);
            this.ribbon.QuickToolbarItemLinks.Add(this.bbiLogout);
            this.ribbon.QuickToolbarItemLinks.Add(this.bbiChangePassword, true);
            this.ribbon.QuickToolbarItemLinks.Add(this.bbiExit, true);
            this.ribbon.QuickToolbarItemLinks.Add(this.bbiClear, true);
            this.ribbon.QuickToolbarItemLinks.Add(this.bbiSaveLayout);
            this.ribbon.QuickToolbarItemLinks.Add(this.bbiDesign);
            // 
            // 
            // 
            this.ribbon.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbon.SearchEditItem.EditWidth = 150;
            this.ribbon.SearchEditItem.Id = -5000;
            this.ribbon.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.Size = new System.Drawing.Size(1077, 86);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // officeNavigationBar
            // 
            this.officeNavigationBar.AllowDrag = true;
            this.officeNavigationBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.officeNavigationBar.Location = new System.Drawing.Point(0, 448);
            this.officeNavigationBar.Margin = new System.Windows.Forms.Padding(6);
            this.officeNavigationBar.MinimumSize = new System.Drawing.Size(0, 41);
            this.officeNavigationBar.Name = "officeNavigationBar";
            this.officeNavigationBar.OptionsPeekFormButtonPanel.AllowGlyphSkinning = true;
            this.officeNavigationBar.OptionsPeekFormButtonPanel.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.officeNavigationBar.OptionsPeekFormButtonPanel.ShowButtonPanel = true;
            this.officeNavigationBar.PeekFormSize = new System.Drawing.Size(250, 350);
            this.officeNavigationBar.Size = new System.Drawing.Size(1077, 86);
            this.officeNavigationBar.TabIndex = 2;
            this.officeNavigationBar.Text = "officeNavigationBar";
            this.officeNavigationBar.SelectedItemChanged += new DevExpress.XtraBars.Navigation.NavigationBarItemClickEventHandler(this.OfficeNavigationBar_SelectedItemChanged);
            // 
            // pmMain
            // 
            this.pmMain.ItemLinks.Add(this.bbiServer);
            this.pmMain.ItemLinks.Add(this.bbiConfig);
            this.pmMain.ItemLinks.Add(this.bbiLicense);
            this.pmMain.ItemLinks.Add(this.bbiBackup);
            this.pmMain.ItemLinks.Add(this.bbiUpload);
            this.pmMain.ItemLinks.Add(this.bbiClear);
            this.pmMain.ItemLinks.Add(this.bbiChangePassword);
            this.pmMain.ItemLinks.Add(this.bbiLogin);
            this.pmMain.ItemLinks.Add(this.bbiLogout);
            this.pmMain.ItemLinks.Add(this.bbiExit);
            this.pmMain.ItemLinks.Add(this.bbiSaveLayout);
            this.pmMain.ItemLinks.Add(this.bbiDesign);
            this.pmMain.ItemLinks.Add(this.bbiCustomize);
            this.pmMain.Name = "pmMain";
            this.pmMain.Ribbon = this.ribbon;
            // 
            // bbiServer
            // 
            this.bbiServer.Caption = "bbiServer";
            this.bbiServer.Id = 17;
            this.bbiServer.Name = "bbiServer";
            this.bbiServer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiServer_ItemClick);
            // 
            // bbiConfig
            // 
            this.bbiConfig.Caption = "bbiConfig";
            this.bbiConfig.Id = 15;
            this.bbiConfig.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiConfig.ImageOptions.Image")));
            this.bbiConfig.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiConfig.ImageOptions.LargeImage")));
            this.bbiConfig.Name = "bbiConfig";
            this.bbiConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiConfig_ItemClick);
            // 
            // bbiLicense
            // 
            this.bbiLicense.Caption = "bbiLicense";
            this.bbiLicense.Id = 16;
            this.bbiLicense.Name = "bbiLicense";
            this.bbiLicense.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLicense_ItemClick);
            // 
            // bbiBackup
            // 
            this.bbiBackup.Caption = "bbiBackup";
            this.bbiBackup.Id = 14;
            this.bbiBackup.Name = "bbiBackup";
            this.bbiBackup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBackup_ItemClick);
            // 
            // bbiUpload
            // 
            this.bbiUpload.Caption = "bbiUpload";
            this.bbiUpload.Id = 18;
            this.bbiUpload.Name = "bbiUpload";
            this.bbiUpload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUpload_ItemClick);
            // 
            // bbiClear
            // 
            this.bbiClear.Id = 19;
            this.bbiClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClear.ImageOptions.Image")));
            this.bbiClear.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiClear.ImageOptions.LargeImage")));
            this.bbiClear.Name = "bbiClear";
            this.bbiClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClearLayout_ItemClick);
            // 
            // bbiChangePassword
            // 
            this.bbiChangePassword.Caption = "biChange Password";
            this.bbiChangePassword.Id = 20;
            this.bbiChangePassword.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiChangePassword.ImageOptions.SvgImage")));
            this.bbiChangePassword.Name = "bbiChangePassword";
            this.bbiChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChangePassword_ItemClick);
            // 
            // bbiLogin
            // 
            this.bbiLogin.Caption = "biLogin";
            this.bbiLogin.Id = 21;
            this.bbiLogin.ImageOptions.SvgImage = global::EMQV.Win.Properties.Resources.NewContact;
            this.bbiLogin.Name = "bbiLogin";
            this.bbiLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLogin_ItemClick);
            // 
            // bbiLogout
            // 
            this.bbiLogout.Caption = "biLogout";
            this.bbiLogout.Id = 22;
            this.bbiLogout.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiLogout.ImageOptions.SvgImage")));
            this.bbiLogout.Name = "bbiLogout";
            this.bbiLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLogout_ItemClick);
            // 
            // bbiExit
            // 
            this.bbiExit.Caption = "biExit";
            this.bbiExit.Id = 23;
            this.bbiExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExit.ImageOptions.SvgImage")));
            this.bbiExit.Name = "bbiExit";
            this.bbiExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExit_ItemClick);
            // 
            // bbiSaveLayout
            // 
            this.bbiSaveLayout.Id = 24;
            this.bbiSaveLayout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSaveLayout.ImageOptions.Image")));
            this.bbiSaveLayout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSaveLayout.ImageOptions.LargeImage")));
            this.bbiSaveLayout.Name = "bbiSaveLayout";
            this.bbiSaveLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveLayout_ItemClick);
            // 
            // bbiDesign
            // 
            this.bbiDesign.Id = 25;
            this.bbiDesign.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDesign.ImageOptions.Image")));
            this.bbiDesign.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDesign.ImageOptions.LargeImage")));
            this.bbiDesign.Name = "bbiDesign";
            this.bbiDesign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDesign_ItemClick);
            // 
            // bbiCustomize
            // 
            this.bbiCustomize.Id = 26;
            this.bbiCustomize.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCustomize.ImageOptions.Image")));
            this.bbiCustomize.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiCustomize.ImageOptions.LargeImage")));
            this.bbiCustomize.Name = "bbiCustomize";
            this.bbiCustomize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCustomize_ItemClick);
            // 
            // modulesContainer
            // 
            this.modulesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modulesContainer.Location = new System.Drawing.Point(0, 86);
            this.modulesContainer.Margin = new System.Windows.Forms.Padding(4);
            this.modulesContainer.Name = "modulesContainer";
            this.modulesContainer.Size = new System.Drawing.Size(1077, 362);
            this.modulesContainer.TabIndex = 3;
            // 
            // WfApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 570);
            this.Controls.Add(this.modulesContainer);
            this.Controls.Add(this.officeNavigationBar);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "WfApplication";
            this.Text = "WfApplication";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.officeNavigationBar, 0);
            this.Controls.SetChildIndex(this.modulesContainer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeNavigationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu pmMain;
        private DevExpress.XtraBars.BarButtonItem bbiChangePassword;
        private DevExpress.XtraBars.BarButtonItem bbiLogin;
        private DevExpress.XtraBars.BarButtonItem bbiLogout;
        private DevExpress.XtraBars.BarButtonItem bbiExit;
        private DevExpress.XtraBars.BarButtonItem bbiBackup;
        private DevExpress.XtraBars.BarButtonItem bbiUpload;
        private DevExpress.XtraBars.Navigation.OfficeNavigationBar officeNavigationBar;
        private DevExpress.XtraEditors.XtraUserControl modulesContainer;
        private DevExpress.XtraBars.BarButtonItem bbiLicense;
        private DevExpress.XtraBars.BarButtonItem bbiServer;
        private DevExpress.XtraBars.BarButtonItem bbiConfig;
        private DevExpress.XtraBars.BarButtonItem bbiClear;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiDesign;
        private DevExpress.XtraBars.BarButtonItem bbiCustomize;
        //private DevExpress.XtraBars.Navigation.NavigationBarItem navigationBarItem1;
        //private DevExpress.XtraBars.Navigation.NavigationBarItem navigationBarItem2;
    }
}