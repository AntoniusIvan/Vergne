using EMQV.Models;
using EMQV.Win.Helper;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMQV;
//System.Windows.Forms.Form

namespace Kumon.Win.BaseControl
{
    public partial class SimpleFormSource : FormSource
    {
        public string Oid;
        protected bool isConfirm = false;
        protected string printCode;

        public event EventHandler Saved;
        public SimpleFormSource()
        {
            InitializeComponent();
            if ((WfApplication.Instance != null) && !WfApplication.Instance.IsCustomize)
            {
                this.lc.AllowCustomization = false;
            }
        }

        public virtual void AfterDelete()
        {
        }

        protected virtual void AfterSave()
        {
        }

        private void bbiHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new HistoryForm
            //{
            //    Oid = this.Oid,
            //    moduleName = base.ModuleName
            //}.ShowDialog();
        }
        protected void CheckDuplicate(string fieldID, string fieldCode, string tableName, string code)
        {
            if (Utility.FindObject(fieldID, tableName, string.Format("IsDeleted = 0 AND {0} = '{2}' AND {1} <> '{3}'", new object[] { fieldCode, fieldID, code, this.Oid }), "", "", "", 
                    ,""//Utility.DBConnection
                    , null, -1) != null)
            {
                throw new Exception(ConstStrings.Duplicate);
            }
        }

        private bool CheckValidateData()
        {
            return this.ValidateData();
        }

        public virtual SqlConnection DBConnection()
        {
            return null;
        }

        public virtual void DeleteData()
        {
        }

        protected virtual void DoSave(bool isClose, bool isNew)
        {
            string oid = this.Oid;
            try
            {
                if (this.CheckValidateData() && (!this.isConfirm || (XtraMessageBox.Show(base.FindForm(), ConstStrings.SaveQuestion, ConstStrings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)))
                {
                    BaseModel.DBConnection = this.DBConnection();
                    if (ReferenceEquals(BaseModel.DBConnection, null))
                    {
                        BaseModel.DBConnection = Utility.DBConnection;
                    }
                    if (BaseModel.DBConnection != null)
                    {
                        if (BaseModel.DBConnection.State != ConnectionState.Open)
                        {
                            BaseModel.DBConnection.Open();
                        }
                        BaseModel.DBTransaction = BaseModel.DBConnection.BeginTransaction();
                    }
                    this.Oid = this.SaveData();
                    this.SaveUDF();
                    this.AfterSave();
                    if (BaseModel.DBConnection != null)
                    {
                        BaseModel.DBTransaction.Commit();
                    }
                    this.OnSaved();
                    if (!string.IsNullOrEmpty(this.printCode))
                    {
                        object obj2 = Utility.FindObject("Value", "SystemConfig", "Code = 'PrintCode'", "", "", "", Utility.DBConnection, null, -1);
                        string printCodeSufix = "";
                        if ((obj2 != null) && (obj2 != DBNull.Value))
                        {
                            printCodeSufix = obj2.ToString();
                        }
                        if (XtraMessageBox.Show(base.FindForm(), ConstStrings.PrintQuestion, ConstStrings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string[] separator = new string[] { "," };
                            foreach (string str3 in this.printCode.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                            {
                                Utility.PrintManager.Print(str3, printCodeSufix, this.Oid, "", "", false);
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(base.moduleName))
                    {
                        BaseModel.DBConnection = Utility.DBConnection;
                        if (BaseModel.DBConnection != null)
                        {
                            if (BaseModel.DBConnection.State != ConnectionState.Open)
                            {
                                BaseModel.DBConnection.Open();
                            }
                            BaseModel.DBTransaction = BaseModel.DBConnection.BeginTransaction();
                        }
                        DefaultModel.UserLog(string.IsNullOrEmpty(oid) ? 0 : 1, base.ModuleName, base.tableLog, this.Oid);
                        if (BaseModel.DBConnection != null)
                        {
                            BaseModel.DBTransaction.Commit();
                        }
                    }
                    if (!isClose && !isNew)
                    {
                        XtraMessageBox.Show(base.FindForm(), ConstStrings.Saved, ConstStrings.Information, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.LoadData();
                    }
                    else if (isClose)
                    {
                        base.DialogResult = DialogResult.OK;
                        base.Close();
                    }
                    else if (isNew)
                    {
                        this.Oid = "";
                        this.NewData();
                    }
                }
            }
            catch (Exception exception)
            {
                if ((BaseModel.DBTransaction != null) && (BaseModel.DBTransaction.Connection != null))
                {
                    BaseModel.DBTransaction.Rollback();
                }
                this.Oid = oid;
                XtraMessageBox.Show(base.FindForm(), exception.Message, ConstStrings.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                if ((BaseModel.DBConnection != null) && (BaseModel.DBConnection.State != ConnectionState.Closed))
                {
                    BaseModel.DBConnection.Close();
                }
            }
        }

        private BaseEdit GetEditor(string name)
        {
            //foreach (object control in lc.Controls)
            //{

            //    if (!enumerator.MoveNext())
            //    {
            //        break;
            //    }
            //    object current = enumerator.Current;
            //    if (current.GetType().IsSubclassOf(typeof(BaseEdit)))
            //    {
            //        BaseEdit objA = current as BaseEdit;
            //        if (!ReferenceEquals(objA, null) && (objA.Name == string.Format("udf{0}", name)))
            //        {
            //            return objA;
            //        }
            //    }
            //}
            //return (BaseEdit)null;
            foreach (DataRow dataRow in lc1.Root.Items)
            {
                if (dataRow.GetType().IsSubclassOf(typeof(BaseEdit)) ) {//&& dataRow.Name == string.Format("udf{0}", (object)name)){
                    BaseEdit baseEdit = new BaseEdit();
                    return baseEdit;
                }
            }
            return (BaseEdit)null;
            //using (IEnumerator enumerator = this.lc1.Root.Items.GetEnumerator())
            //{
            //    while (true)
            //    {
            //        if (!enumerator.MoveNext())
            //        {
            //            break;
            //        }
            //        object current = enumerator.Current;
            //        if (current.GetType() == typeof(LayoutControlItem))
            //        {
            //            LayoutControlItem objA = current as LayoutControlItem;
            //            if (!ReferenceEquals(objA, null) && (objA.Name == lciName))
            //            {
            //                return objA;
            //            }
            //        }
            //    }
            //}
            //return null;
        }

        protected override void InitForm()
        {
            this.ButtonRePrint.Visible = false;
            if (string.IsNullOrEmpty(this.Oid))
            {
                this.bbiHistory.Visibility = BarItemVisibility.Never;
                this.NewData();
            }
            else
            {
                this.bbiHistory.Visibility = BarItemVisibility.Always;
                this.sbRePrint.Visible = !string.IsNullOrEmpty(this.printCode);
                this.sbNext.Visible = false;
                this.LoadData();
            }
            base.SetFormChangedEventHandler(this.lc);
            this.SetPolicy();
        }

        public virtual void LoadData()
        {
        }

        internal override void LoadUDF()
        {
            if (!string.IsNullOrEmpty(base.moduleName))
            {
                try
                {
                    DataTable table = Utility.GetObjects("*", "UDF", string.Format("IsDeleted = 0 AND Name = '{0}' AND Type = '{1}'", base.moduleName.Replace(" ", ""), base.moduleType), "", "", "", BaseModel.DBConnection, BaseModel.DBTransaction, 0);
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        DataRow objA = Utility.GetObject("*", string.Format("UDF_{0}", base.moduleName.Replace(" ", "")), string.Format("Oid = '{0}'", this.Oid), "", "", "", Utility.DBConnection, null);
                        if (!ReferenceEquals(objA, null))
                        {
                            foreach (DataRow row2 in table.Rows)
                            {
                                BaseEdit editor = this.GetEditor(row2["FieldName"].ToString());
                                if (!ReferenceEquals(editor, null))
                                {
                                    editor.EditValue = objA[row2["FieldName"].ToString()];
                                }
                            }
                        }
                    }
                }
                catch (Exception exception1)
                {
                    if (exception1.HResult == -2146232060)
                    {
                        Utility.CreateTableUDF();
                        this.LoadUDF();
                    }
                }
            }
        }

        public virtual void NewData()
        {
        }

        internal void OnSaved()
        {
            if (this.Saved != null)
            {
                this.Saved(this, new EventArgs());
            }
        }

        protected ValidationRule RuleIsNotBlank()
        {
            return new ConditionValidationRule
            {
                ConditionOperator = ConditionOperator.IsNotBlank,
                ErrorText = ConstStrings.RuleIsNotBlankWarning,
                ErrorType = ErrorType.Critical
            };
        }

        protected virtual string SaveData()
        {
            return "";
        }

        private void SaveUDF()
        {
            if (!string.IsNullOrEmpty(base.ModuleName))
            {
                try
                {
                    foreach (DataRow row in Utility.GetObjects("*", "UDF", string.Format("IsDeleted = 0 AND Name = '{0}' AND Type = '{1}'", base.moduleName.Replace(" ", ""), base.moduleType), "", "", "", BaseModel.DBConnection, BaseModel.DBTransaction, 0).Rows)
                    {
                        BaseEdit editor = this.GetEditor(row["FieldName"].ToString());
                        if (!ReferenceEquals(editor, null))
                        {
                            DefaultModel.InsertUpdateUDF(row["Name"].ToString(), row["FieldName"].ToString(), editor.EditValue, this.Oid);
                        }
                    }
                }
                catch (Exception exception1)
                {
                    if (exception1.HResult == -2146232060)
                    {
                        Utility.CreateTableUDF();
                        this.LoadUDF();
                    }
                }
            }
        }
        private void sbCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void sbNext_Click(object sender, EventArgs e)
        {
            this.DoSave(false, true);
        }

        internal void sbRePrint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.printCode))
            {
                object obj2 = Utility.FindObject("Value", "SystemConfig", "Code = 'PrintCode'", "", "", "", Utility.DBConnection, null, -1);
                string printCodeSufix = "";
                if ((obj2 != null) && (obj2 != DBNull.Value))
                {
                    printCodeSufix = obj2.ToString();
                }
                if (XtraMessageBox.Show(base.FindForm(), ConstStrings.PrintQuestion, ConstStrings.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string[] separator = new string[] { "," };
                    foreach (string str2 in this.printCode.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                    {
                        Utility.PrintManager.Print(str2, printCodeSufix, this.Oid, "", "", false);
                    }
                }
            }
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            this.DoSave(true, false);
        }

        protected override void SetImage()
        {
            this.sbNext.Image = ImagesHelper.GetImage("MIT.Images.Next", ImageSize.Small16, null);
            this.sbSave.Image = ImagesHelper.GetImage("MIT.Images.Save", ImageSize.Small16, null);
            this.sbCancel.Image = ImagesHelper.GetImage("MIT.Images.Cancel", ImageSize.Small16, null);
            this.sbRePrint.Image = ImagesHelper.GetImage("MIT.Images.Print", ImageSize.Small16, null);
        }

        protected override void SetLanguage()
        {
            this.bbiHistory.Caption = ConstStrings.History;
            this.sbNext.Text = ConstStrings.BtnNext;
            this.sbSave.Text = ConstStrings.BtnSave;
            this.sbCancel.Text = ConstStrings.BtnCancel;
            this.sbRePrint.Text = ConstStrings.RePrint;
        }

        protected virtual void SetPolicy()
        {
            if (!string.IsNullOrEmpty(base.role))
            {
                bool flag = false;
                bool flag2 = false;
                base.role = base.role.Trim().ToUpper();
                if (Utility.CurrentUser.RoleDetail.ContainsKey(base.role))
                {
                    string str = Utility.CurrentUser.RoleDetail[base.role];
                    flag = str.Contains("A");
                    flag2 = str.Contains("E");
                }
                if (Utility.CurrentUser.IsAdministrator)
                {
                    flag = flag2 = true;
                }
                if (!flag && string.IsNullOrEmpty(this.Oid))
                {
                    this.sbSave.Visible = false;
                    this.sbNext.Visible = false;
                }
                if (!flag2 && !string.IsNullOrEmpty(this.Oid))
                {
                    this.sbSave.Visible = false;
                    this.sbNext.Visible = false;
                }
            }
        }

        internal override void SetSize()
        {
            if (this.lc.PreferredSize.Height <= 0x3e8)
            {
                base.Height = this.lc.PreferredSize.Height + 70;
            }
        }

        protected virtual bool ValidateData()
        {
            return this.ValidationProvider.Validate();
        }

        protected SimpleButton ButtonRePrint
        {
            get
            {
                return this.sbRePrint;
            }
        }

        protected SimpleButton ButtonNext
        {
            get
            {
                return this.sbNext;
            }
        }

        protected SimpleButton ButtonSave
        {
            get
            {
                return this.sbSave;
            }
        }

        protected SimpleButton ButtonCancel
        {
            get
            {
                return this.sbCancel;
            }
        }

        internal PanelControl ButtonPanel
        {
            get
            {
                return this.panelControl1;
            }
        }

        protected DXValidationProvider ValidationProvider
        {
            get
            {
                return this.dxValidationProvider;
            }
        }
    }
}
