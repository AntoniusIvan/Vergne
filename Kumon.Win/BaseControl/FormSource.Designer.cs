using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout.Utils;
using System.Drawing;

namespace Kumon.Win.BaseControl
{
    partial class FormSource
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSource));
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiClear = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDesign = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUDF = new DevExpress.XtraBars.BarButtonItem();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiClear,
            this.bbiSaveLayout,
            this.bbiDesign,
            this.bbiUDF});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(6);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1310, 41);
            this.ribbon.Toolbar.ItemLinks.Add(this.bbiClear);
            this.ribbon.Toolbar.ItemLinks.Add(this.bbiSaveLayout);
            this.ribbon.Toolbar.ItemLinks.Add(this.bbiDesign);
            this.ribbon.Toolbar.ItemLinks.Add(this.bbiUDF);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // bbiClear
            // 
            this.bbiClear.Caption = "Clear Layout";
            this.bbiClear.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiClear.Glyph")));
            this.bbiClear.Id = 1;
            this.bbiClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiClear.LargeGlyph")));
            this.bbiClear.Name = "bbiClear";
            this.bbiClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClear_ItemClick);
            // 
            // bbiSaveLayout
            // 
            this.bbiSaveLayout.Caption = "Save Layout";
            this.bbiSaveLayout.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiSaveLayout.Glyph")));
            this.bbiSaveLayout.Id = 2;
            this.bbiSaveLayout.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiSaveLayout.LargeGlyph")));
            this.bbiSaveLayout.Name = "bbiSaveLayout";
            this.bbiSaveLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveLayout_ItemClick);
            // 
            // bbiDesign
            // 
            this.bbiDesign.Caption = "bbiDesign";
            this.bbiDesign.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDesign.Glyph")));
            this.bbiDesign.Id = 3;
            this.bbiDesign.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDesign.LargeGlyph")));
            this.bbiDesign.Name = "bbiDesign";
            this.bbiDesign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDesign_ItemClick);
            // 
            // bbiUDF
            // 
            this.bbiUDF.Caption = "bbiUDF";
            this.bbiUDF.Id = 4;
            this.bbiUDF.Name = "bbiUDF";
            this.bbiUDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUDF_ItemClick);
            // 
            // sbClose
            // 
            this.sbClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbClose.Location = new System.Drawing.Point(-150, -44);
            this.sbClose.Margin = new System.Windows.Forms.Padding(6);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(150, 44);
            this.sbClose.TabIndex = 1;
            this.sbClose.Text = "Close";
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // FormOldSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 678);
            this.Controls.Add(this.sbClose);
            this.Controls.Add(this.ribbon);
            this.Name = "FormOldSource";
            this.Ribbon = this.ribbon;
            this.Text = "FormSource";
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DXValidationProvider dxValidationProvider;
        protected RibbonControl ribbon;
        private SimpleButton sbClose;
        private BarButtonItem bbiClear;
        private BarButtonItem bbiSaveLayout;
        protected BarButtonItem bbiDesign;
        protected BarButtonItem bbiUDF;
    }
}