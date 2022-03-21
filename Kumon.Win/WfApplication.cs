using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using EMQV.Win.BaseControl;
using EMQV.Win.Helper;
using Kumon.Win;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EMQV;
using EMQV.Models;
using Kumon.Win.Helper;
using System.Reflection;
using Kumon.Win.BaseControl;

namespace Kumon.Win
{
    public partial class WfApplication : SourceApplication
    {

        protected ModuleHelper moduleHelper;
        private static WfApplication instance;
        public bool IsCustomize;
        public WfApplication()
        {
            InitializeComponent();
            this.IsCustomize = false;
            instance = this;
        }

        protected virtual void AfterLogin()
        {
        }

        protected virtual void AfterLogout()
        {
        }

        private void bbiBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            //COMMENTED 2021-01-06 11:12
            //new BackupForm().ShowDialog();
        }

        private void bbiChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            //COMMENTED 2021-01-06 11:13
            //using (ChangePasswordForm form = new ChangePasswordForm())
            //{
            //    if (form.ShowDialog(this) == DialogResult.OK)
            //    {
            //        Utility.CurrentUser.Logout();
            //        this.SetControl(Utility.CurrentUser.IsLogged);
            //        this.bbiLogin_ItemClick(sender, e);
            //    }
            //}
        }

        private void bbiClearLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            EMQV.Models.Module activeModule = ModuleHelper.ActiveModule;
            if (!ReferenceEquals(activeModule, null) && (activeModule.ViewControl != null))
            {
                ViewSource viewControl = activeModule.ViewControl as ViewSource;
                if (viewControl != null)
                {
                    viewControl.ClearLayout();
                }
            }
        }

        private void bbiConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            //COMMENTED 2021-01-06 11:14
            new ConfigForm().ShowDialog();
        }

        protected void bbiCustomize_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.IsCustomize = !this.IsCustomize;
            if (this.IsCustomize)
            {
                this.bbiClear.Visibility = BarItemVisibility.Always;
                this.bbiSaveLayout.Visibility = BarItemVisibility.Always;
                this.bbiDesign.Visibility = BarItemVisibility.Always;
            }
            else
            {
                this.bbiClear.Visibility = BarItemVisibility.Never;
                this.bbiSaveLayout.Visibility = BarItemVisibility.Never;
                this.bbiDesign.Visibility = BarItemVisibility.Never;
            }
            this.bbiCustomize.Caption = this.IsCustomize ? "Done Customize" : "Customize";
        }

        protected void bbiDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
            EMQV.Models.Module activeModule = this.ModuleHelper.ActiveModule;
            if (!ReferenceEquals(activeModule, null) && (activeModule.ViewControl != null))
            {
                ViewSource viewControl = activeModule.ViewControl as ViewSource;
                if (viewControl != null)
                {
                    viewControl.DesignColumn();
                }
            }
        }

        protected void bbiExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show(base.FindForm(), ConstStrings.ExitApplication, ConstStrings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Utility.CurrentUser.Logout();
                base.DialogResult = DialogResult.Cancel;
                base.Close();
            }
        }

        protected void bbiLicense_ItemClick(object sender, ItemClickEventArgs e)
        {
            // COMMENTED 2021-01-06 11:16
            //if (new LicenseForm().ShowDialog() == DialogResult.OK)
            //{
            //    base.RefreshLicense();
            //}
        }
        protected void bbiLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            //COMMENTED ai 2021-05-27 using (LoginForm form = new LoginForm())
            using (LoginAiForm form = new LoginAiForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (moduleHelper.Modules != null)
                    {

                    }
                    this.SetControl(Utility.CurrentUser.IsLogged);
                }
            }

        }

        protected void bbiLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show(base.FindForm(), ConstStrings.LogoutApplication, ConstStrings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Utility.CurrentUser.Logout();
                this.SetControl(Utility.CurrentUser.IsLogged);
                this.bbiLogin_ItemClick(sender, e);
            }
        }

        private void bbiSaveLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            EMQV.Models.Module activeModule = this.ModuleHelper.ActiveModule;
            if (!ReferenceEquals(activeModule, null) && (activeModule.ViewControl != null))
            {
                ViewSource viewControl = activeModule.ViewControl as ViewSource;
                if (viewControl != null)
                {
                    viewControl.SaveFormLayout();
                }
            }
        }

        private void bbiServer_ItemClick(object sender, ItemClickEventArgs e)
        {
            // COMMENTED 2021-01-06 11:16
            //new ServerForm().ShowDialog();
        }

        private void bbiUpload_ItemClick(object sender, ItemClickEventArgs e)
        {
            //COMMENTED 2021-01-06 11:37
            //new UploadForm().ShowDialog();
        }

        public virtual FormSource GetForm(params object[] obj)
        {
            return null;
        }

        public virtual ViewSource GetView(params object[] obj)
        {
            return null;
        }

        protected override void InitForm()
        {
            if (this.DesignMode)
                return;
            if (this.moduleHelper == null)
                this.moduleHelper = new ModuleHelper();
            this.ModuleHelper.MergedRibbon += new ModuleHelper.MergedRibbonHandle(this.ModuleHelper_MergedRibbon);
            this.ModuleHelper.MergedRibbonStatusBar += new ModuleHelper.MergedRibbonStatusBarHandle(this.ModuleHelper_MergedRibbonStatusBar);
            //this.ModuleHelper.BringToFront += new ModuleHelper.BringToFrontHandle(this.ModuleHelper_BringToFront);

            //COMMENTED ON 2020-12-31 04:49 //UNCOMMENTED ON 2020-01-01 07:39
            this.SetControl(Utility.CurrentUser.IsLogged);
            this.bbiLogin_ItemClick((object)this, (ItemClickEventArgs)null);
        }

        private void ModuleHelper_BringToFront(EMQV.Models.Module module, ViewSource e)
        {
            XtraTabControl tabControl = module.TabControl as XtraTabControl;
            if (!ReferenceEquals(tabControl, null))
            {
                tabControl.Parent = this.modulesContainer;
                tabControl.Dock = DockStyle.Fill;
                tabControl.BringToFront();
            }
        }

        private void ModuleHelper_MergedRibbon(object sender, RibbonControl e)
        {
            this.Ribbon.MergeRibbon(e);
        }

        private void ModuleHelper_MergedRibbonStatusBar(object sender, RibbonStatusBar e)
        {
            this.Ribbon.StatusBar.MergeStatusBar(e);
        }

        private void OfficeNavigationBar_SelectedItemChanged(object sender, NavigationBarItemEventArgs e)
        {
            EMQV.Models.Module tag = e.Item.Tag as EMQV.Models.Module;
            if (!ReferenceEquals(tag, null))
            {
                this.Ribbon.UnMergeRibbon();
                this.Ribbon.StatusBar.UnMergeStatusBar();
                this.ModuleHelper.LoadModule(tag);
            }
        }

        protected virtual void RegisterModules()
        {

        }

        protected void SetControl(bool isLogged)
        {
            this.bbiBackup.Enabled = isLogged;
            this.bbiUpload.Enabled = isLogged;
            if (moduleHelper.Modules != null)
            {

            }
            this.bbiChangePassword.Enabled = isLogged;
            this.bbiLogin.Enabled = !isLogged;
            this.bbiLogout.Enabled = isLogged;
            base.bsiUser.Caption = isLogged ? string.Format("{0} ({1})", Utility.CurrentUser.Username, Utility.CurrentUser.FullName) : "";
            base.bsiServer.Caption = isLogged ? Utility.Server : "";
            base.bsiDatabase.Caption = isLogged ? Utility.Database : "";
            base.RibbonStatusBar.Visible = isLogged;
            this.officeNavigationBar.Visible = isLogged;
            this.SetPolicy(isLogged);
            if (isLogged)
            {
                this.AfterLogin();
            }
            else
            {
                this.AfterLogout();
            }
        }

        protected override void SetImage()
        {
            ImagesHelper.SetBarButtonImage((BarItem)this.bbiServer, "EMQV.Images.Server", (Assembly)null);
            ImagesHelper.SetBarButtonImage((BarItem)this.bbiLicense, "EMQV.Images.License", (Assembly)null);
            ImagesHelper.SetBarButtonImage((BarItem)this.bbiBackup, "EMQV.Images.BackUp", (Assembly)null);
            ImagesHelper.SetBarButtonImage((BarItem)this.bbiUpload, "EMQV.Images.Upload", (Assembly)null);
            ImagesHelper.SetBarButtonImage((BarItem)this.bbiChangePassword, "EMQV.Images.ChangePassword", (Assembly)null);
            ImagesHelper.SetBarButtonImage((BarItem)this.bbiLogin, "EMQV.Images.Login", (Assembly)null);
            ImagesHelper.SetBarButtonImage((BarItem)this.bbiLogout, "EMQV.Images.Logout", (Assembly)null);
            ImagesHelper.SetBarButtonImage((BarItem)this.bbiExit, "EMQV.Images.Exit", (Assembly)null);
        }

        protected override void SetLanguage()
        {
            this.bbiServer.Caption = ConstStrings.Server;
            this.bbiConfig.Caption = ConstStrings.Config;
            this.bbiLicense.Caption = ConstStrings.License;
            this.bbiBackup.Caption = ConstStrings.Backup;
            this.bbiUpload.Caption = ConstStrings.Upload;
            this.bbiChangePassword.Caption = ConstStrings.ChangePassword;
            this.bbiClear.Caption = ConstStrings.ClearLayout;
            this.bbiLogin.Caption = ConstStrings.Login;
            this.bbiLogout.Caption = ConstStrings.Logout;
            this.bbiExit.Caption = ConstStrings.Exit;
        }

        private void SetPolicy(bool isLogged)
        {
            this.officeNavigationBar.BeginUpdate();
            if (!isLogged)
            {
                this.officeNavigationBar.Items.Clear();
                this.ModuleHelper.ClearModules(this.officeNavigationBar);
                this.Ribbon.UnMergeRibbon();
                this.Ribbon.StatusBar.UnMergeStatusBar();
                this.modulesContainer.Controls.Clear();
            }
            else
            {
                if (moduleHelper.Modules != null)
                {

                }
                this.RegisterModules();
                if(moduleHelper.Modules != null)
                {

                }
                this.ModuleHelper.CreateModules(this.officeNavigationBar);
            }
            this.officeNavigationBar.EndUpdate();
        }

        protected ModuleHelper ModuleHelper
        {
            get
            {
                return this.moduleHelper;
            }
        }
        protected OfficeNavigationBar BottomBar
        {
            get
            {
                return this.officeNavigationBar;
            }
        }

        public static WfApplication Instance
        {
            get
            {
                return WfApplication.instance;
            }
        }
    }
}
