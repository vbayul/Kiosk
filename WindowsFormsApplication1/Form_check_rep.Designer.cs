﻿namespace WindowsFormsApplication1
{
    partial class Form_check_rep
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.checkTableAdapter1 = new WindowsFormsApplication1.kioskDataSetTableAdapters.checkTableAdapter();
            this.kioskDataSet1 = new WindowsFormsApplication1.kioskDataSet();
            this.check_goodsTableAdapter1 = new WindowsFormsApplication1.kioskDataSetTableAdapters.check_goodsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.kioskDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowGotoPageButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.ShowTextSearchButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(913, 475);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // checkTableAdapter1
            // 
            this.checkTableAdapter1.ClearBeforeFill = true;
            // 
            // kioskDataSet1
            // 
            this.kioskDataSet1.DataSetName = "kioskDataSet";
            this.kioskDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // check_goodsTableAdapter1
            // 
            this.check_goodsTableAdapter1.ClearBeforeFill = true;
            // 
            // Form_check_rep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 475);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "Form_check_rep";
            this.Text = "Печать чека";
            this.Load += new System.EventHandler(this.Form_check_rep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kioskDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private kioskDataSetTableAdapters.checkTableAdapter checkTableAdapter1;
        private kioskDataSet kioskDataSet1;
        private kioskDataSetTableAdapters.check_goodsTableAdapter check_goodsTableAdapter1;
    }
}