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
using EMQV.Win.Helper;
using Kumon.Win.Helper;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Kumon.Win.BaseControl
{
    public partial class FormSource : RibbonForm
    {

        protected string moduleName;
        protected string moduleType;
        protected string role;

        internal LayoutControl lc1;
        internal LayoutControl lc2;
        internal LayoutControl lc3;

        internal byte[] layout1;
        internal byte[] layout2;
        internal byte[] layout3;

        internal GridControl grid1;
        internal GridControl grid2;
        internal GridControl grid3;
        
        internal byte[] gridLayout1;
        internal byte[] gridLayout2;
        internal byte[] gridLayout3;

        internal DataTable tableLog;
        private string lastValue;
        public BaseEdit firstController;

        protected bool isFixSize = true;

        public FormSource()
        {
            this.InitializeComponent();
            this.moduleType = "";
            if ((WfApplication.Instance == null) || !WfApplication.Instance.IsCustomize)
            {
                this.bbiClear.Visibility = BarItemVisibility.Never;
                this.bbiDesign.Visibility = BarItemVisibility.Never;
                this.bbiSaveLayout.Visibility = BarItemVisibility.Never;
                this.bbiUDF.Visibility = BarItemVisibility.Never;
            }
        }

        private void bbiClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ClearFormLayout();
        }
        private void bbiDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DesignColumn();
        }

        private void bbiSaveLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.SaveFormLayout();
        }

        private void bbiUDF_ItemClick(object sender, ItemClickEventArgs e)
        {
            //UDFList list = new UDFList();
            //list.SetData(this.moduleName, this.moduleType);
            //list.ShowDialog(base.FindForm());
        }

        internal void ClearFormLayout()
        {
            //if (!string.IsNullOrEmpty(this.ModuleName))
            //{
            //    DataRow moduleLayout = Utility.GetModuleLayout(this.moduleName, this.moduleType);
            //    string moduleLayoutID = "";
            //    if (moduleLayout != null)
            //    {
            //        moduleLayoutID = moduleLayout["ModuleLayoutID"].ToString();
            //    }
            //    if (ReferenceEquals(BaseModel.DBConnection, null))
            //    {
            //        BaseModel.DBConnection = Utility.DBConnection;
            //    }
            //    if (BaseModel.DBConnection != null)
            //    {
            //        if (BaseModel.DBConnection.State != ConnectionState.Open)
            //        {
            //            BaseModel.DBConnection.Open();
            //        }
            //        BaseModel.DBTransaction = BaseModel.DBConnection.BeginTransaction();
            //    }
            //    DefaultModel.DeleteModuleLayout(moduleLayoutID);
            //    if (BaseModel.DBConnection != null)
            //    {
            //        BaseModel.DBTransaction.Commit();
            //    }
            //    XtraMessageBox.Show(base.FindForm(), "Clear layout Succeed", ConstStrings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
        }

        public virtual void DesignColumn()
        {
        }
        private void Form_GotFocus(object sender, EventArgs e)
        {
        }

        private void FormBase_EditValueChanged(object sender, EventArgs e)
        {
            if (!ReferenceEquals(this.lastValue, null))
            {
                BaseEdit objA = sender as BaseEdit;
                if (!ReferenceEquals(objA, null) && (this.lastValue != objA.Text))
                {
                    string str = string.Empty;
                    bool flag4 = false;
                    char[] chArray = objA.Name.ToCharArray();
                    int index = 0;
                    while (true)
                    {
                        if (index >= chArray.Length)
                        {
                            str = str.Trim();
                            string text = objA.Text;
                            if (sender.GetType() == typeof(CheckEdit))
                            {
                                text = (sender as CheckEdit).Checked.ToString();
                            }
                            DataRow[] rowArray = this.tableLog.Select(string.Format("ControlName = '{0}'", str));
                            if ((rowArray != null) && (rowArray.Length != 0))
                            {
                                rowArray[0]["NewValue"] = text;
                            }
                            else
                            {
                                object[] values = new object[] { DateTime.Now, str, this.lastValue, text };
                                this.tableLog.Rows.Add(values);
                            }
                            break;
                        }
                        char ch = chArray[index];
                        if (ch.ToString() == ch.ToString().ToUpper())
                        {
                            flag4 = true;
                            str = str + " ";
                        }
                        if (flag4)
                        {
                            str = str + ch.ToString();
                        }
                        index++;
                    }
                }
            }
        }

        private LayoutControlItem GetLCI(string lciName)
        {
            //foreach (object obj in (CollectionBase)this.lc1.Root.Items)
            //{
            //    if (obj.GetType() == typeof(LayoutControlItem) && (LayoutControlItem) layoutControlItem && layoutControlItem.Name == lciName)
            //         return layoutControlItem;
            //}
            //return (LayoutControlItem)null;
            foreach (object obj in (CollectionBase)this.lc1.Root.Items)
            {
                LayoutControlItem layoutControlItem = new LayoutControlItem();
                if(obj.GetType() == typeof(LayoutControlItem) && obj is LayoutControlItem && layoutControlItem.Name == lciName)
                {
                    return layoutControlItem;
                }
            }

             return null;
        }

        protected virtual void InitForm()
        {
        }

        public void LoadForm()
        {
            this.tableLog = new DataTable();
            this.tableLog.Columns.Add("TransDate", typeof(DateTime));
            this.tableLog.Columns.Add("ControlName", typeof(string));
            this.tableLog.Columns.Add("OldValue", typeof(string));
            this.tableLog.Columns.Add("NewValue", typeof(string));
            this.SetLanguage();
            this.SetImage();
            this.InitForm();
            this.RestoreUDF();
            this.RestoreFormLayout();
            this.LoadUDF();
        }

        internal virtual void LoadUDF()
        {
        }

        protected void LockEditor(ButtonEdit lue)
        {
            lue.Properties.ReadOnly = true;
            lue.Properties.Buttons.Clear();
        }

        protected void LockEditor(SimpleButton sb)
        {
            sb.Enabled = false;
        }

        protected void LockEditor(TextEdit te)
        {
            te.Properties.ReadOnly = true;
        }

        protected void LockEditor(GridColumn col)
        {
            col.OptionsColumn.AllowFocus = false;
            col.OptionsColumn.AllowEdit = false;
            col.OptionsColumn.TabStop = false;
            col.OptionsColumn.ReadOnly = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!base.DesignMode)
            {
                this.Text = ConstStrings.AppTitle;
                if (!string.IsNullOrEmpty(this.moduleName))
                {
                    this.Text = string.Format("{0} - {1}", ConstStrings.AppTitle, this.moduleName);
                }
                base.Icon = ImagesHelper.AppIcon;
                this.SetSize();
                if (base.Owner != null)
                {
                    if (!this.isFixSize)
                    {
                        base.Height = (base.Owner.Height * 3) / 4;
                        base.Width = (base.Owner.Width * 3) / 4;
                    }
                    base.Left = base.Owner.Left + ((base.Owner.Width - base.Width) / 2);
                    base.Top = base.Owner.Top + ((base.Owner.Height - base.Height) / 2);
                }
                this.LoadForm();
            }
        }

        internal void RestoreFormLayout()
        {
            //if (!string.IsNullOrEmpty(this.ModuleName))
            //{
            //    DataRow moduleLayout = Utility.GetModuleLayout(this.moduleName, this.moduleType);
            //    if (!ReferenceEquals(moduleLayout, null))
            //    {
            //        this.layout1 = moduleLayout["Layout1"] as byte[];
            //        this.layout2 = moduleLayout["Layout2"] as byte[];
            //        this.layout3 = moduleLayout["Layout3"] as byte[];
            //        this.gridLayout1 = moduleLayout["GridLayout1"] as byte[];
            //        this.gridLayout2 = moduleLayout["GridLayout2"] as byte[];
            //        this.gridLayout3 = moduleLayout["GridLayout3"] as byte[];
            //        if ((this.lc1 != null) && (this.layout1 != null))
            //        {
            //            this.SetLayout(this.lc1, this.layout1);
            //        }
            //        if ((this.lc2 != null) && (this.layout2 != null))
            //        {
            //            this.SetLayout(this.lc2, this.layout2);
            //        }
            //        if ((this.lc3 != null) && (this.layout3 != null))
            //        {
            //            this.SetLayout(this.lc3, this.layout3);
            //        }
            //        if ((this.grid1 != null) && (this.gridLayout1 != null))
            //        {
            //            this.SetLayout(this.grid1, this.gridLayout1);
            //        }
            //        if ((this.grid2 != null) && (this.gridLayout2 != null))
            //        {
            //            this.SetLayout(this.grid2, this.gridLayout2);
            //        }
            //        if ((this.grid3 != null) && (this.gridLayout3 != null))
            //        {
            //            this.SetLayout(this.grid3, this.gridLayout3);
            //        }
            //        this.SetSize();
            //    }
            //}
        }

        private void RestoreUDF()
        {
            //try
            //{
            //    if (string.IsNullOrEmpty(this.moduleName) || string.IsNullOrEmpty(this.moduleType))
            //        return;
            //    DataTable objects = Utility.GetObjects("*", "UDF", string.Format("IsDeleted = 0 AND Name = '{0}' AND Type = '{1}'", (object)this.moduleName, (object)this.moduleType), "", "", "", Utility.DBConnection);
            //    if (this.lc1 == null)
            //        return;
            //    foreach (DataRow row in (InternalDataCollectionBase)objects.Rows)
            //    {
            //        BaseEdit baseEdit = (BaseEdit)null;
            //        switch (row["DataType"].ToString())
            //        {
            //            case "BOOL":
            //                baseEdit = (BaseEdit)new CheckEdit();
            //                baseEdit.Text = row["FieldName"].ToString();
            //                break;
            //            case "DATETIME":
            //                baseEdit = (BaseEdit)new DateEdit();
            //                (baseEdit as DateEdit).Properties.DisplayFormat.FormatType = (baseEdit as DateEdit).Properties.EditFormat.FormatType = FormatType.Custom;
            //                (baseEdit as DateEdit).Properties.DisplayFormat.FormatString = (baseEdit as DateEdit).Properties.EditFormat.FormatString = "dd MMM yyy";
            //                break;
            //            case "DECIMAL":
            //            case "DOUBLE":
            //                baseEdit = (BaseEdit)new CalcEdit();
            //                (baseEdit as CalcEdit).Properties.DisplayFormat.FormatType = (baseEdit as CalcEdit).Properties.EditFormat.FormatType = FormatType.Custom;
            //                (baseEdit as CalcEdit).Properties.DisplayFormat.FormatString = (baseEdit as CalcEdit).Properties.EditFormat.FormatString = "#,##0.##";
            //                break;
            //            case "INT":
            //                baseEdit = (BaseEdit)new SpinEdit();
            //                (baseEdit as SpinEdit).Properties.DisplayFormat.FormatType = (baseEdit as SpinEdit).Properties.EditFormat.FormatType = FormatType.Custom;
            //                (baseEdit as SpinEdit).Properties.DisplayFormat.FormatString = (baseEdit as SpinEdit).Properties.EditFormat.FormatString = "#,##0.##";
            //                break;
            //            case "LOOKUP":
            //                baseEdit = (BaseEdit)new LookUpEdit();
            //                EditorHelper.CreateLookUpEdit((LookUpEditBase)(baseEdit as LookUpEdit), (RepositoryItemCollection)null, row["FieldID"].ToString(), row["Display"].ToString(), row["TableName"].ToString(), row["Condition"].ToString(), row["OrderBy"].ToString(), Utility.DBConnection);
            //                break;
            //            case "STRING":
            //                baseEdit = (BaseEdit)new TextEdit();
            //                break;
            //        }
            //        baseEdit.Name = string.Format("udf{0}", row["FieldName"]);
            //        this.lc1.Controls.Add((Control)baseEdit);
            //        if (this.GetLCI(row["FieldName"].ToString()) == null)
            //        {
            //            LayoutControlItem layoutControlItem = new LayoutControlItem();
            //            layoutControlItem.Control = (Control)baseEdit;
            //            layoutControlItem.Name = string.Format("udf{0}", row["FieldName"]);
            //            layoutControlItem.Text = string.Format("{0} :", row["FieldName"]);
            //            if (row["DataType"].ToString() == "BOOL")
            //                layoutControlItem.TextVisible = false;
            //            this.lc1.Root.Add((BaseLayoutItem)layoutControlItem);
            //            layoutControlItem.HideToCustomization();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.HResult != -2146232060)
            //        return;
            //    Utility.CreateTableUDF();
            //    this.LoadUDF();
            //}
        }

        internal void SaveFormLayout()
        {
            //string str;
            //if (!string.IsNullOrEmpty(this.ModuleName))
            //{
            //    DataRow moduleLayout = Utility.GetModuleLayout(this.moduleName, this.moduleType);
            //    str = "";
            //    if (moduleLayout != null)
            //    {
            //        str = moduleLayout["ModuleLayoutID"].ToString();
            //    }
            //    this.layout1 = null;
            //    if (this.lc1 != null)
            //    {
            //        try
            //        {
            //            MemoryStream stream = new MemoryStream();
            //            this.lc1.SaveLayoutToStream(stream);
            //            this.layout1 = stream.ToArray();
            //        }
            //        catch (Exception)
            //        {
            //        }
            //    }
            //}
            //else
            //{
            //    return;
            //}
            //this.layout2 = null;
            //if (this.lc2 != null)
            //{
            //    try
            //    {
            //        MemoryStream stream = new MemoryStream();
            //        this.lc2.SaveLayoutToStream(stream);
            //        this.layout2 = stream.ToArray();
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //this.layout3 = null;
            //if (this.lc3 != null)
            //{
            //    try
            //    {
            //        MemoryStream stream = new MemoryStream();
            //        this.lc3.SaveLayoutToStream(stream);
            //        this.layout3 = stream.ToArray();
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //this.gridLayout1 = null;
            //if (this.grid1 != null)
            //{
            //    MemoryStream stream = new MemoryStream();
            //    try
            //    {
            //        this.grid1.MainView.SaveLayoutToStream(stream);
            //        this.gridLayout1 = stream.ToArray();
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //this.gridLayout2 = null;
            //if (this.grid2 != null)
            //{
            //    try
            //    {
            //        MemoryStream stream = new MemoryStream();
            //        this.grid2.MainView.SaveLayoutToStream(stream);
            //        this.gridLayout2 = stream.ToArray();
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //this.gridLayout3 = null;
            //if (this.grid3 != null)
            //{
            //    try
            //    {
            //        MemoryStream stream = new MemoryStream();
            //        this.grid3.MainView.SaveLayoutToStream(stream);
            //        this.gridLayout3 = stream.ToArray();
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //if (ReferenceEquals(BaseModel.DBConnection, null))
            //{
            //    BaseModel.DBConnection = Utility.DBConnection;
            //}
            //if (BaseModel.DBConnection != null)
            //{
            //    if (BaseModel.DBConnection.State != ConnectionState.Open)
            //    {
            //        BaseModel.DBConnection.Open();
            //    }
            //    BaseModel.DBTransaction = BaseModel.DBConnection.BeginTransaction();
            //}
            //DefaultModel.InsertUpdateModuleLayout(this.ModuleName, this.moduleType, this.layout1, this.layout2, this.layout3, this.gridLayout1, this.gridLayout2, this.gridLayout3, str);
            //if (BaseModel.DBConnection != null)
            //{
            //    BaseModel.DBTransaction.Commit();
            //}
            //XtraMessageBox.Show(base.FindForm(), "Layout Changed", ConstStrings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        

        private void sbClose_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }
        protected void SetFormChangedEventHandler(Control ctl)
        {
            if (ctl.GetType() == typeof(LayoutControl))
            {
                if (ReferenceEquals(this.lc1, null))
                {
                    this.lc1 = ctl as LayoutControl;
                }
                else if (ReferenceEquals(this.lc2, null))
                {
                    this.lc2 = ctl as LayoutControl;
                }
                else if (ReferenceEquals(this.lc3, null))
                {
                    this.lc3 = ctl as LayoutControl;
                }
            }
            if (ctl.GetType().IsSubclassOf(typeof(BaseEdit)))
            {
                ((BaseEdit)ctl).EditValueChanged += new EventHandler(this.FormBase_EditValueChanged);
                ((BaseEdit)ctl).GotFocus += new EventHandler(this.Form_GotFocus);
                if (ctl.GetType() == typeof(DateEdit))
                {
                    ((DateEdit)ctl).Properties.DisplayFormat.FormatString = "dd MMM yyy";
                    ((DateEdit)ctl).Properties.DisplayFormat.FormatType = FormatType.Custom;
                    ((DateEdit)ctl).Properties.EditFormat.FormatString = "dd MMM yyy";
                    ((DateEdit)ctl).Properties.EditFormat.FormatType = FormatType.Custom;
                    ((DateEdit)ctl).Properties.EditMask = "dd MMM yyy";
                    ((DateEdit)ctl).Properties.Mask.MaskType = MaskType.DateTime;
                }
                if (ReferenceEquals(this.firstController, null))
                {
                    this.firstController = ctl as BaseEdit;
                }
            }
            else if (!(ctl.GetType() == typeof(GridControl)))
            {
                if (ctl.GetType() == typeof(XtraTabControl))
                {
                    (ctl as XtraTabControl).TabStop = false;
                    foreach (XtraTabPage page in ((XtraTabControl)ctl).TabPages)
                    {
                        foreach (Control control in page.Controls)
                        {
                            this.SetFormChangedEventHandler(control);
                        }
                    }
                }
                else
                {
                    foreach (Control control2 in ctl.Controls)
                    {
                        this.SetFormChangedEventHandler(control2);
                    }
                }
            }
            else
            {
                if (ReferenceEquals(this.grid1, null))
                {
                    this.grid1 = ctl as GridControl;
                }
                else if (ReferenceEquals(this.lc2, null))
                {
                    this.grid2 = ctl as GridControl;
                }
                else if (ReferenceEquals(this.grid3, null))
                {
                    this.grid3 = ctl as GridControl;
                }
                if (((GridControl)ctl).MainView.GetType() == typeof(GridView))
                {
                    GridView mainView = ((GridControl)ctl).MainView as GridView;
                    mainView.LostFocus += new EventHandler(this.view_LostFocus);
                    mainView.CellValueChanged += new CellValueChangedEventHandler(this.view_CellValueChanged);
                    mainView.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.view_FocusedColumnChanged);
                    mainView.FocusedRowChanged += new FocusedRowChangedEventHandler(this.view_FocusedRowChanged);
                }
                else if (((GridControl)ctl).MainView.GetType() == typeof(BandedGridView))
                {
                    BandedGridView mainView = ((GridControl)ctl).MainView as BandedGridView;
                    mainView.LostFocus += new EventHandler(this.view_LostFocus);
                    mainView.CellValueChanged += new CellValueChangedEventHandler(this.view_CellValueChanged);
                    mainView.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.view_FocusedColumnChanged);
                    mainView.FocusedRowChanged += new FocusedRowChangedEventHandler(this.view_FocusedRowChanged);
                }
            }
        }

        protected virtual void SetImage()
        {
        }

        protected virtual void SetLanguage()
        {
        }

        private void SetLayout(GridControl gc, byte[] layout)
        {
            if (((gc != null) && (layout != null)) && (layout.Length != 0))
            {
                MemoryStream stream = new MemoryStream(layout);
                stream.Seek(0L, SeekOrigin.Begin);
                gc.MainView.RestoreLayoutFromStream(stream);
            }
        }

        private void SetLayout(LayoutControl lc, byte[] layout)
        {
            if ((lc != null) && (layout != null))
            {
                if (string.IsNullOrEmpty(this.moduleName))
                {
                    lc.AllowCustomization = false;
                }
                if (layout.Length != 0)
                {
                    MemoryStream stream = new MemoryStream(layout);
                    stream.Seek(0L, SeekOrigin.Begin);
                    lc.RestoreLayoutFromStream(stream);
                }
            }
        }

        internal virtual void SetSize()
        {
        }

        private void view_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (!ReferenceEquals(e.Column, null))
            {
                string str = string.Empty;
                bool flag = false;
                char[] chArray = e.Column.Name.ToCharArray();
                int index = 0;
                while (true)
                {
                    if (index >= chArray.Length)
                    {
                        str = str.Trim();
                        GridView view = sender as GridView;
                        str = string.Format("Row {0}, Columns {1}", view.FocusedRowHandle, str);
                        if (!ReferenceEquals(view.GetFocusedDataRow(), null))
                        {
                            DataRow[] rowArray = this.tableLog.Select(string.Format("ControlName = '{0}'", str));
                            if ((rowArray != null) && (rowArray.Length != 0))
                            {
                                rowArray[0]["NewValue"] = e.Value.ToString();
                            }
                            else
                            {
                                object[] values = new object[] { DateTime.Now, str, this.lastValue, (e.Value == null) ? "" : e.Value.ToString() };
                                this.tableLog.Rows.Add(values);
                            }
                        }
                        break;
                    }
                    char ch = chArray[index];
                    if (ch.ToString() == ch.ToString().ToUpper())
                    {
                        flag = true;
                        str = str + " ";
                    }
                    if (flag)
                    {
                        str = str + ch.ToString();
                    }
                    index++;
                }
            }
        }

        private void view_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            DataRow focusedDataRow = (sender as GridView).GetFocusedDataRow();
            if (!ReferenceEquals(focusedDataRow, null) && (!ReferenceEquals(e.FocusedColumn, null) && (!string.IsNullOrEmpty(e.FocusedColumn.FieldName.Trim()) && ((focusedDataRow[e.FocusedColumn.FieldName] != null) && (focusedDataRow[e.FocusedColumn.FieldName] != DBNull.Value)))))
            {
                this.lastValue = focusedDataRow[e.FocusedColumn.FieldName].ToString();
            }
        }

        private void view_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;
            DataRow focusedDataRow = view.GetFocusedDataRow();
            if (!ReferenceEquals(focusedDataRow, null) && (!ReferenceEquals(view.FocusedColumn, null) && !string.IsNullOrEmpty(view.FocusedColumn.FieldName.Trim())))
            {
                this.lastValue = focusedDataRow[view.FocusedColumn.FieldName].ToString();
            }
        }

        private void view_LostFocus(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.EditingValue != null)
                {
                    this.view_CellValueChanged(sender, new CellValueChangedEventArgs(view.FocusedRowHandle, view.FocusedColumn, view.EditingValue));
                }
            }
            catch (Exception)
            {
            }
        }
        public string ModuleName
        {
            get
            {
                return this.moduleName;
            }
        }

        public string Role
        {
            get
            {
                return this.role;
            }
        }

        public LayoutControl SelectedLayoutControl { get; set; }



    }
}
