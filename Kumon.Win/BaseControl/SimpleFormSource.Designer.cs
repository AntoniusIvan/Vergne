using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kumon.Win.BaseControl
{
    partial class SimpleFormSource
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.sbRePrint = new DevExpress.XtraEditors.SimpleButton();
            this.sbSave = new DevExpress.XtraEditors.SimpleButton();
            this.sbNext = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lc = new DevExpress.XtraLayout.LayoutControl();
            this.lcg = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.bbiHistory = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiHistory});
            this.ribbon.Margin = new System.Windows.Forms.Padding(14);
            this.ribbon.Size = new System.Drawing.Size(874, 41);
            this.ribbon.Toolbar.ItemLinks.Add(this.bbiHistory);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.sbRePrint);
            this.panelControl1.Controls.Add(this.sbSave);
            this.panelControl1.Controls.Add(this.sbNext);
            this.panelControl1.Controls.Add(this.sbCancel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 628);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(874, 67);
            this.panelControl1.TabIndex = 3;
            // 
            // sbRePrint
            // 
            this.sbRePrint.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.sbRePrint.Location = new Point(0x182, 11);
            this.sbRePrint.Margin = new System.Windows.Forms.Padding(6);
            this.sbRePrint.Name = "sbRePrint";
            this.sbRePrint.Size = new Size(150, 0x2c);
            this.sbRePrint.TabIndex = 7;
            this.sbRePrint.Text = "simpleButton3";
            this.sbRePrint.Click += new System.EventHandler(this.sbRePrint_Click);
            // 
            // sbSave
            // 
            this.sbSave.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.sbSave.Location = new Point(0x224, 11);
            this.sbSave.Margin = new System.Windows.Forms.Padding(6);
            this.sbSave.Name = "sbSave";
            this.sbSave.Size = new Size(150, 0x2c);
            this.sbSave.TabIndex = 5;
            this.sbSave.Text = "simpleButton2";
            this.sbSave.Click += new System.EventHandler(this.sbSave_Click);
            // 
            // sbNext
            // 
            this.sbNext.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.sbNext.Location = new Point(0x182, 11);
            this.sbNext.Margin = new System.Windows.Forms.Padding(6);
            this.sbNext.Name = "sbNext";
            this.sbNext.Size = new Size(150, 0x2c);
            this.sbNext.TabIndex = 4;
            this.sbNext.Text = "simpleButton4";
            this.sbNext.Click += new System.EventHandler(this.sbNext_Click);
            // 
            // sbCancel
            // 
            this.sbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbCancel.Location = new Point(710, 11);
            this.sbCancel.Margin = new System.Windows.Forms.Padding(6);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new Size(150, 0x2c);
            this.sbCancel.TabIndex = 6;
            this.sbCancel.Text = "simpleButton1";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // lc
            // 
            this.lc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lc.Location = new System.Drawing.Point(0, 41);
            this.lc.Margin = new System.Windows.Forms.Padding(6);
            this.lc.Name = "lc";
            this.lc.Root = this.lcg;
            this.lc.Size = new System.Drawing.Size(874, 587);
            this.lc.TabIndex = 8;
            this.lc.Text = "layoutControl1";
            // 
            // lcg
            // 
            this.lcg.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcg.GroupBordersVisible = false;
            this.lcg.Location = new System.Drawing.Point(0, 0);
            this.lcg.Name = "lcg";
            this.lcg.OptionsItemText.TextToControlDistance = 5;
            this.lcg.Size = new System.Drawing.Size(874, 587);
            this.lcg.TextVisible = false;
            // 
            // bbiHistory
            // 
            this.bbiHistory.Caption = "bbiHistory";
            this.bbiHistory.Id = 4;
            this.bbiHistory.Name = "bbiHistory";
            this.bbiHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHistory_ItemClick);
            // 
            // SimpleFormSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 695);
            this.Controls.Add(this.lc);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleFormSource";
            this.Text = "SimpleFormSource";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.lc, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PanelControl panelControl1;
        private SimpleButton sbNext;
        private SimpleButton sbSave;
        private SimpleButton sbCancel;
        private SimpleButton sbRePrint;
        protected LayoutControl lc;
        protected LayoutControlGroup lcg;
        private DXValidationProvider dxValidationProvider;
        private BarButtonItem bbiHistory;
    }
}