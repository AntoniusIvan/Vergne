using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace EMQV.Win.BaseControl
{
    partial class ViewSource
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.pnlModule = new DevExpress.XtraEditors.PanelControl();
            this.ribbon.BeginInit();
            this.pnlModule.BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            BarItem[] items = new BarItem[] { this.ribbon.ExpandCollapseItem };
            this.ribbon.Items.AddRange(items);
            this.ribbon.Location = new Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.Size = new Size(0x2f9, 0x2f);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new Point(0, 0x191);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new Size(0x2f9, 0x1b);
            // 
            // pnlModule
            // 
            this.pnlModule.BorderStyle = BorderStyles.NoBorder;
            this.pnlModule.Dock = DockStyle.Fill;
            this.pnlModule.Location = new Point(0, 0x2f);
            this.pnlModule.Name = "pnlModule";
            this.pnlModule.Size = new Size(0x2f9, 0x162);
            this.pnlModule.TabIndex = 2;
            // 
            // ViewSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.pnlModule);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "ViewSource";
            base.Size = new Size(0x2f9, 0x1ac);
            this.ribbon.EndInit();
            this.pnlModule.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        protected DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        protected DevExpress.XtraEditors.PanelControl pnlModule;
    }
}

