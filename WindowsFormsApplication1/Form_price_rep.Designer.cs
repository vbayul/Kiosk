﻿namespace WindowsFormsApplication1
{
    partial class Form_price_rep
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
            this.kioskDataSet1 = new WindowsFormsApplication1.kioskDataSet();
            this.pricelistTableAdapter1 = new WindowsFormsApplication1.kioskDataSetTableAdapters.pricelistTableAdapter();
            this.settingTableAdapter1 = new WindowsFormsApplication1.kioskDataSetTableAdapters.settingTableAdapter();
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
            this.crystalReportViewer1.ShowExportButton = false;
            this.crystalReportViewer1.ShowGotoPageButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.ShowTextSearchButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1158, 530);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // kioskDataSet1
            // 
            this.kioskDataSet1.DataSetName = "kioskDataSet";
            this.kioskDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pricelistTableAdapter1
            // 
            this.pricelistTableAdapter1.ClearBeforeFill = true;
            // 
            // settingTableAdapter1
            // 
            this.settingTableAdapter1.ClearBeforeFill = true;
            // 
            // Form_price_rep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 530);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "Form_price_rep";
            this.Text = "Ценники";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kioskDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private kioskDataSet kioskDataSet1;
        private kioskDataSetTableAdapters.pricelistTableAdapter pricelistTableAdapter1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private kioskDataSetTableAdapters.settingTableAdapter settingTableAdapter1;
    }
}