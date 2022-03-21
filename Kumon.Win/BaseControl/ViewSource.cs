using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;
using EMQV.Win.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EMQV;
using System.Linq;
using System.Collections.Generic;
using EMQV.Models;
using Kumon.Win.BaseControl;

namespace EMQV.Win.BaseControl
{
    public partial class ViewSource : XtraUserControl
    {
        public Module Module;
        private List<FormSource> formCollection;

        public event ObjectClickEventHandle ObjectClick;
        public ViewSource()
        {
            InitializeComponent();
        }

        private void bbi_ItemClick(object sender, ItemClickEventArgs e)
        {
            //COMMENTED 2021-01-06 11:18
            BarItem objA = e.Item;
            if (!ReferenceEquals(objA, null) && (objA.Tag != null))
            {
                ViewerForm form = new ViewerForm();
                form.LoadLayout(objA.Tag.ToString());
                form.Show(this);
            }
        }
        public void ClearLayout()
        {
            XtraTabControl tabControl = this.Module.TabControl as XtraTabControl;
            if (!ReferenceEquals(tabControl, null) && !ReferenceEquals(tabControl.SelectedTabPage, null))
            {
                if (tabControl.SelectedTabPage.Tag == null)
                {
                    this.ClearViewLayout();
                }
                else
                {
                    (tabControl.SelectedTabPage.Tag as FormSource).ClearFormLayout();
                }
            }
        }

        protected virtual void ClearViewLayout()
        {
        }

        public void DesignColumn()
        {
            XtraTabControl tabControl = this.Module.TabControl as XtraTabControl;
            if (!ReferenceEquals(tabControl, null) && (!ReferenceEquals(tabControl.SelectedTabPage, null) && (tabControl.SelectedTabPage.Tag != null)))
            {
                (tabControl.SelectedTabPage.Tag as FormSource).DesignColumn();
            }
        }
        private void FormDisposed(object sender, EventArgs e)
        {
            FormSource objA = sender as FormSource;
            if (!ReferenceEquals(objA, null))
            {
                this.formCollection.Remove(objA);
            }
        }
        public virtual void InitView()
        {
        }
        protected void LoadReport(BarSubItem bsiReport, string groupName)
        {
            //TRIAL SUB BAR
            //BarManager barManager = new BarManager();
            //barManager.Form = this;
            // Prevent excessive updates while adding and customizing bars and bar items.
            // The BeginUpdate must match the EndUpdate method.
            //barManager.BeginUpdate();

            //BarSubItem subMenuFile = new BarSubItem(barManager, "File");
            //BarSubItem subMenuEdit = new BarSubItem(barManager, "Edit");
            //BarSubItem subMenuView = new BarSubItem(barManager, "View");

            //BarButtonItem buttonCut = new BarButtonItem(barManager, "Cut");
            //BarButtonItem buttonViewOutput = new BarButtonItem(barManager, "Output");
            //BarButtonItem buttonTry1 = new BarButtonItem(barManager, "Try1");
            //BarButtonItem buttonTry2 = new BarButtonItem(barManager, "Try2");

            DataTable tempTable1 = Utility.TableReport;
            DataTable tempTable2 = Utility.TableReport;
            if (tempTable1 == null)
            {
                return;
            }
            else if(tempTable1.Rows.Count<=0 ){
                return;
            }
            else
            {
                
            }
                //foreach (DataRow row in tempTable1.Rows)
                //{
                //                object value = row["ColumnName"];
                //                if (value == DBNull.Value)
                //        // do something
                //    else
                //        // do something else
                //}
                //TRIAL LINQ
                DataTable tempTable0 = tempTable1.Rows.Cast<DataRow>().OrderBy(x => x["Seq"]).Select(x => x).CopyToDataTable();
            DataTable tempTable4 = tempTable0;

            //NEW DATA TABLE, ADD COLLUMN GROUP REPORT
            DataTable tempTable3 = new DataTable();
            tempTable3.Clear();
            tempTable3.Columns.Add("GroupReport");

            List<ClassRptDoc> groupReports = new List<ClassRptDoc>();
            var test3 = new ClassRptDoc();
            foreach (DataRow row in tempTable0.Rows)
            {
                //ADD ROW
                DataRow workRow = tempTable3.NewRow();
                workRow["GroupReport"] = row["GroupReport"].ToString();
                tempTable3.Rows.Add(workRow);

                test3 = new ClassRptDoc { Name = row["Name"].ToString(), GroupReport = row["GroupReport"].ToString() };
                groupReports.Add(test3);
            }
            var results = from p in groupReports
                          group p.GroupReport by p.GroupReport into g
                          select new { Name = g.Key, GroupReport = g.ToList() };

            tempTable0 = ConvertToDataTable(results);

            //JIKA TIDAK NULL
            if (!ReferenceEquals(tempTable0, null))
            {
                bsiReport.Glyph = ImagesHelper.GetImage("EMQV.Images.GroupReport", ImageSize.Small16, typeof(ConstStrings).Assembly);
                bsiReport.LargeGlyph = ImagesHelper.GetImage("EMQV.Images.GroupReport", ImageSize.Large32, typeof(ConstStrings).Assembly);
                string str = "";
                BarSubItem item = null;
                bsiReport.ItemLinks.Clear();

                //bsiReport.ItemLinks.Add(subMenuEdit, false);
                ////1
                //subMenuEdit.ItemLinks.Add(buttonViewOutput, false);
                //subMenuEdit.ItemLinks.Add(buttonCut, false);
                //subMenuEdit.ItemLinks.Add(buttonTry1, false);
                //subMenuEdit.ItemLinks.Add(buttonTry2, false);
                //buttonViewOutput.ItemClick += new ItemClickEventHandler(this.bbi_ItemClick);
                foreach (DataRow row in tempTable0.Rows)
                {
                    //var temptable50 = LoopForAddList(groupReports, test3);
                    tempTable2 = tempTable4.Rows.Cast<DataRow>().Where(y => y["GroupReport"].ToString() == row["Name"].ToString()).Select(y => y).CopyToDataTable();
                    //var results = from p in groupReports
                    //              group p.GroupReport by p.GroupReport into g
                    //              select new { Name = g.Key, GroupReport = g.ToList() };

                    bool flag2 = false;


                    if (str != row["GroupReport"].ToString())
                    {
                        item = new BarSubItem
                        {
                            Caption = row["Name"].ToString(),
                            Glyph = ImagesHelper.GetImage("EMQV.Images.GroupReport", ImageSize.Small16, typeof(ConstStrings).Assembly),
                            LargeGlyph = ImagesHelper.GetImage("EMQV.Images.GroupReport", ImageSize.Large32, typeof(ConstStrings).Assembly)
                        };
                        //this.ribbon.Items.Add(item);//2
                        bsiReport.ItemLinks.Add(item, false);//Convert.ToBoolean(row["IsBeginGroup"]));
                        //subMenuEdit.ItemLinks.Add(buttonViewOutput, false);

                    }
                    foreach (DataRow dataRow in tempTable2.Rows)
                    {
                        if (Utility.CurrentUser.RoleDetail.ContainsKey(dataRow["ReportDocumentID"].ToString()))
                        {
                            flag2 = Utility.CurrentUser.RoleDetail[dataRow["ReportDocumentID"].ToString()] == "V";
                        }
                        if (Utility.CurrentUser.IsAdministrator)
                        {
                            flag2 = true;
                        }
                        if (flag2)
                        {
                            BarButtonItem item2 = new BarButtonItem
                            {
                                Caption = dataRow["Name"].ToString(),
                                Glyph = ImagesHelper.GetImage("EMQV.Images.Report", ImageSize.Small16, typeof(ConstStrings).Assembly),
                                LargeGlyph = ImagesHelper.GetImage("EMQV.Images.Report", ImageSize.Large32, typeof(ConstStrings).Assembly),
                                Tag = dataRow["ReportDocumentID"].ToString()
                            };
                            //Saat Report di click
                            item2.ItemClick += new ItemClickEventHandler(this.bbi_ItemClick);
                            this.ribbon.Items.Add(item2);
                            bool beginGroup = false;
                            //bool beginGroup = true;
                            if ((dataRow["IsBegin"] != null) && (dataRow["IsBegin"] != DBNull.Value))
                            {
                                beginGroup = Convert.ToBoolean(dataRow["IsBegin"]);
                            }


                            item.ItemLinks.Add(item2, beginGroup);
                        }
                    }
                }
            }
        }

        public virtual void LoadView()
        {
            this.SetLanguage();
            this.RestoreViewLayout();
            this.SetImage();
            this.InitView();
            this.formCollection = new List<FormSource>();
        }

        public void OnObjectClick(string code, string id)
        {
            if (this.ObjectClick == null)
                return;
            this.ObjectClick(this, code, id);
        }

        protected void OpenForm(FormSource form)
        {
            FormSource form1 = WfApplication.Instance.GetForm((object)form.GetType().FullName);
            if (form1 != null)
            {
                form.Dispose();
                form = form1;
            }
            foreach (FormSource form2 in this.formCollection)
            {
                if (form2.ModuleName == form.ModuleName)
                {
                    form2.BringToFront();
                    form2.Focus();
                    return;
                }
            }
            this.formCollection.Add(form);
            form.Disposed += new EventHandler(this.FormDisposed);
            form.Show(this.pnlModule);
        }
        protected void OpenView(FormSource form)
        {
            object[] objArray1 = new object[] { form.GetType().FullName };
            FormSource base2 = WfApplication.Instance.GetForm(objArray1);
            if (base2 != null)
            {
                form.Dispose();
                form = base2;
            }
            XtraTabControl tabControl = this.Module.TabControl as XtraTabControl;
            if (!ReferenceEquals(tabControl, null))
            {
                XtraTabPage tag = null;
                using (List<FormSource>.Enumerator enumerator = this.formCollection.GetEnumerator())
                {
                    while (true)
                    {
                        if (!enumerator.MoveNext())
                        {
                            break;
                        }
                        FormSource current = enumerator.Current;
                        if (current.ModuleName == form.ModuleName)
                        {
                            tag = current.Tag as XtraTabPage;
                            if (tag != null)
                            {
                                tabControl.SelectedTabPage = tag;
                            }
                            return;
                        }
                    }
                }
                tabControl.ShowTabHeader = DefaultBoolean.True;
                tag = tabControl.TabPages.Add();
                tag.Text = form.ModuleName;
                tag.Tag = form;
                form.LoadForm();
                form.Tag = tag;
                form.Disposed += new EventHandler(this.FormDisposed);
                if (form.SelectedLayoutControl != null)
                {
                    form.SelectedLayoutControl.Parent = tag;
                }
                tabControl.SelectedTabPage = tag;
                this.formCollection.Add(form);
            }
        }

        public virtual void RefreshView()
        {
        }

        public virtual void Reload(string code)
        {
        }
        protected virtual void RestoreViewLayout()
        {
        }
        public void SaveFormLayout()
        {
            XtraTabControl tabControl = this.Module.TabControl as XtraTabControl;
            if (!ReferenceEquals(tabControl, null) && !ReferenceEquals(tabControl.SelectedTabPage, null))
            {
                if (tabControl.SelectedTabPage.Tag == null)
                {
                    this.SaveViewLayout();
                }
                else
                {
                    (tabControl.SelectedTabPage.Tag as FormSource).SaveFormLayout();
                }
            }
        }
        protected virtual void SaveViewLayout()
        {
        }

        public virtual void SetImage()
        {
        }
        public virtual void SetLanguage()
        {
        }

        protected void SetLayout(GridControl gc, byte[] layout)
        {
            if (((gc != null) && (layout != null)) && (layout.Length != 0))
            {
                MemoryStream stream = new MemoryStream(layout);
                stream.Seek(0L, SeekOrigin.Begin);
                gc.MainView.RestoreLayoutFromStream(stream);
            }
        }

        protected void SetLayout(LayoutControl lc, byte[] layout)
        {
            if (((lc != null) && (layout != null)) && (layout.Length != 0))
            {
                MemoryStream stream = new MemoryStream(layout);
                stream.Seek(0L, SeekOrigin.Begin);
                lc.RestoreLayoutFromStream(stream);
            }
        }

        protected void SetPolicy(BarButtonItem item, string role)
        {
            if (!string.IsNullOrEmpty(role))
            {
                bool flag = false;
                role = role.Trim().ToUpper();
                if (Utility.CurrentUser.RoleDetail.ContainsKey(role))
                {
                    flag = Utility.CurrentUser.RoleDetail[role].Contains("V");
                }
                if (Utility.CurrentUser.IsAdministrator)
                {
                    flag = true;
                }
                if ((Utility.TableModule != null) && (Utility.TableModule.Rows.Count != 0))
                {
                    DataRow[] rowArray = Utility.TableModule.Select(string.Format("Code = '{0}'", role));
                    if (rowArray.Length == 0)
                    {
                        flag = false;
                    }
                    else if (Convert.ToBoolean(rowArray[0]["IsDeleted"]))
                    {
                        flag = false;
                    }
                    if (!flag)
                    {
                        item.Visibility = BarItemVisibility.Never;
                    }
                }
                if (!flag)
                {
                    RibbonPageGroupItemLinkCollection links = item.Links[0].Links as RibbonPageGroupItemLinkCollection;
                    bool flag10 = true;
                    foreach (object obj2 in links)
                    {
                        BarButtonItemLink objA = obj2 as BarButtonItemLink;
                        if (!ReferenceEquals(objA, null) && (objA.Item.Visibility == BarItemVisibility.Always))
                        {
                            flag10 = false;
                            break;
                        }
                    }
                    if (flag10)
                    {
                        links.PageGroup.Visible = false;
                    }
                }
            }
        }


        public RibbonControl SelectedRibbon { get; set; }

        public RibbonStatusBar SelectedStatus { get; set; }

        public PanelControl SelectedPanel { get; set; }


        public delegate void ObjectClickEventHandle(ViewSource view, string code, string id);

        class ClassRptDoc
        {
            //public string ReportDocumentID { get; set; }
            public string Name { get; set; }
            //public bool IsBegin { get; set; }
            //public bool IsBeginGroup { get; set; }
            public string GroupReport { get; set; }
        }
        List<ClassRptDoc> LoopForAddList(List<ClassRptDoc> test1, ClassRptDoc test2)
        {
            //ClassRptDoc test4 = new ClassRptDoc { PersonID = 2, car = "Audi" };
            List<ClassRptDoc> persons = new List<ClassRptDoc>();
            persons.Add(test2);
            //persons.AddRange((IEnumerable<ClassPerson>)test2);
            //persons.AddRange((IEnumerable<ClassPerson>)test3);

            return persons;


        }
        DataTable ConvertToDataTable<TSource>(IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt = new DataTable();
            dt.Columns.AddRange(
              props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray()
            );

            source.ToList().ForEach(
              i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt;
        }
    }
}
