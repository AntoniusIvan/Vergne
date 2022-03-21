using DevExpress.Utils;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using EMQV;
using EMQV.Models;
using EMQV.Win.BaseControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kumon.Win.Helper
{
    public class M2oduleHelper
    {
        private List<Module> modules = new List<Module>();

        private Module activeModule;

        public Type DefaultModule;

        public event BringToFrontHandle BringToFront;

        public event MergedRibbonHandle MergedRibbon;

        public event MergedRibbonStatusBarHandle MergedRibbonStatusBar;

        public event ObjectClickEventHandle ObjectClick;
        public void AddModule(System.Type type)
        {
            if (this.Modules == null || this.modules.Exists((Predicate<Module>)(x => x.GetType() == type)))
                return;
            this.modules.Add((Module)Activator.CreateInstance(type));
        }

        public void ClearModules(OfficeNavigationBar officeNavigationBar)
        {
            foreach (Module module in this.modules)
            {
                if (module.ViewControl != null)
                {
                    ViewSource viewControl = module.ViewControl as ViewSource;
                    if ((viewControl != null) && !viewControl.IsDisposed)
                    {
                        viewControl.Dispose();
                    }
                    module.ViewControl = null;
                }
                if (module.TabControl != null)
                {
                    (module.TabControl as XtraTabControl).Dispose();
                    module.TabControl = null;
                }
            }
            this.modules.Clear();
            this.activeModule = null;
            this.DefaultModule = null;
        }

        private void CloseTab(object sender, EventArgs e)
        {
            XtraTabControl objA = sender as XtraTabControl;
            if (!ReferenceEquals(objA, null))
            {
                XtraTabPage page = (e as ClosePageButtonEventArgs).Page as XtraTabPage;
                if (!ReferenceEquals(page, null))
                {
                    FormSource tag = page.Tag as FormSource;
                    if (!ReferenceEquals(tag, null))
                    {
                        tag.Dispose();
                        objA.TabPages.Remove(page);
                        objA.SelectedTabPageIndex = 0;
                        if (objA.TabPages.Count <= 1)
                        {
                            objA.ShowTabHeader = DefaultBoolean.False;
                        }
                    }
                }
            }
        }

        public void CreateModules(OfficeNavigationBar officeNavigationBar)
        {
            foreach (Module module in this.modules)
            {
                if (!Utility.CurrentUser.IsAdministrator && !string.IsNullOrEmpty(module.Role.Trim().ToUpper()))
                {
                    if (Utility.CurrentUser.RoleDetail.ContainsKey(module.Role.Trim().ToUpper()))
                    {
                        string str = Utility.CurrentUser.RoleDetail[module.Role.Trim().ToUpper()];
                        if (!str.Contains("V") && !str.Contains("1"))
                            continue;
                    }
                    else
                        continue;
                }
                NavigationBarItem navigationBarItem = new NavigationBarItem();
                navigationBarItem.Text = module.Title;
                navigationBarItem.Tag = (object)module;
                officeNavigationBar.Items.Add(navigationBarItem);
                if (this.DefaultModule == (System.Type)null)
                {
                    this.DefaultModule = module.GetType();
                    officeNavigationBar.SelectedItem = navigationBarItem;
                    this.LoadModule(module);
                }
            }
        }



        public void LoadModule(Module module)
        {
            if ((this.activeModule != null) && (this.activeModule.ViewControl != null))
            {
                (this.activeModule.ViewControl as ViewSource).Visible = false;
            }
            this.activeModule = module;
            if ((module.ViewControl == null) && (module.ViewType != null))
            {
                module.ViewControl = Activator.CreateInstance(module.ViewType);
                if (module.ViewControl != null)
                {
                    (module.ViewControl as ViewSource).LoadView();
                    (module.ViewControl as ViewSource).Module = module;
                    (module.ViewControl as ViewSource).ObjectClick += new ViewSource.ObjectClickEventHandle(this.OnObjectClick);
                }
            }
            ViewSource viewControl = module.ViewControl as ViewSource;
            if (viewControl != null)
            {
                viewControl.Visible = true;
                if ((viewControl.SelectedRibbon != null) && (this.MergedRibbon != null))
                {
                    this.MergedRibbon(this, viewControl.SelectedRibbon);
                }
                if ((viewControl.SelectedStatus != null) && (this.MergedRibbonStatusBar != null))
                {
                    this.MergedRibbonStatusBar(this, viewControl.SelectedStatus);
                }
            }
            if (module.TabControl == null)
            {
                XtraTabControl control = new XtraTabControl
                {
                    ShowTabHeader = DefaultBoolean.False,
                    ClosePageButtonShowMode = ClosePageButtonShowMode.InAllTabPageHeaders
                };
                control.CloseButtonClick += new EventHandler(this.CloseTab);
                if (viewControl != null)
                {
                    XtraTabPage page = control.TabPages.Add();
                    page.Text = ConstStrings.Dashboard;
                    page.ShowCloseButton = DefaultBoolean.False;
                    viewControl.SelectedPanel.Parent = page;
                    viewControl.SelectedPanel.Dock = DockStyle.Fill;
                }
                module.TabControl = control;
            }
            if ((module.TabControl != null) && (viewControl != null))
            {
                if (this.BringToFront != null)
                {
                    this.BringToFront(module, viewControl);
                }
                viewControl.RefreshView();
            }
        }

        private void OnObjectClick(ViewSource view, string code, string id)
        {
            if (this.ObjectClick == null)
                return;
            this.ObjectClick(view, code, id);
        }

        public List<Module> Modules
        {
            get
            {
                return this.modules;
            }
        }

        internal Module ActiveModule
        {
            get
            {
                return this.activeModule;
            }
        }

        public ModuleHelper()
        {
            this.modules = new List<Module>();
        }

        public delegate void BringToFrontHandle(Module module, ViewSource view);

        public delegate void CloseTabPageHandle(XtraTabPage page);

        public delegate void MergedRibbonHandle(object sender, RibbonControl ribbon);

        public delegate void MergedRibbonStatusBarHandle(object sender, RibbonStatusBar ribbonStatusBar);

        public delegate void ObjectClickEventHandle(ViewSource view, string code, string id);
    }
}
