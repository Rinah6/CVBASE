namespace CVBASESWISS
{
    partial class Frm_PrintSearch
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PrintSearch));
            this.CV_PRINTSEARCHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CVBASEDataSet1 = new CVBASESWISS.CVBASEDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CV_PRINTSEARCHTableAdapter = new CVBASESWISS.CVBASEDataSet1TableAdapters.CV_PRINTSEARCHTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CV_PRINTSEARCHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVBASEDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // CV_PRINTSEARCHBindingSource
            // 
            this.CV_PRINTSEARCHBindingSource.DataMember = "CV_PRINTSEARCH";
            this.CV_PRINTSEARCHBindingSource.DataSource = this.CVBASEDataSet1;
            // 
            // CVBASEDataSet1
            // 
            this.CVBASEDataSet1.DataSetName = "CVBASEDataSet1";
            this.CVBASEDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetSEARCH";
            reportDataSource1.Value = this.CV_PRINTSEARCHBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CVBASESWISS.Prints.ReportSearch.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(684, 661);
            this.reportViewer1.TabIndex = 0;
            // 
            // CV_PRINTSEARCHTableAdapter
            // 
            this.CV_PRINTSEARCHTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_PrintSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.MinimumSize = new System.Drawing.Size(700, 700);
            this.Name = "Frm_PrintSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print Search";
            this.Load += new System.EventHandler(this.Frm_PrintSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CV_PRINTSEARCHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVBASEDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CV_PRINTSEARCHBindingSource;
        private CVBASEDataSet1 CVBASEDataSet1;
        private CVBASEDataSet1TableAdapters.CV_PRINTSEARCHTableAdapter CV_PRINTSEARCHTableAdapter;
    }
}