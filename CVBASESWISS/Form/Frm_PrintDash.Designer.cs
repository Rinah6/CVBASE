namespace CVBASESWISS
{
    partial class Frm_PrintDash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PrintDash));
            this.CV_PRINTDASHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CVBASEDataSet = new CVBASESWISS.CVBASEDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CV_PRINTDASHTableAdapter = new CVBASESWISS.CVBASEDataSetTableAdapters.CV_PRINTDASHTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CV_PRINTDASHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVBASEDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // CV_PRINTDASHBindingSource
            // 
            this.CV_PRINTDASHBindingSource.DataMember = "CV_PRINTDASH";
            this.CV_PRINTDASHBindingSource.DataSource = this.CVBASEDataSet;
            // 
            // CVBASEDataSet
            // 
            this.CVBASEDataSet.DataSetName = "CVBASEDataSet";
            this.CVBASEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetDAsh";
            reportDataSource1.Value = this.CV_PRINTDASHBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CVBASESWISS.Prints.ReportDash.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(684, 661);
            this.reportViewer1.TabIndex = 0;
            // 
            // CV_PRINTDASHTableAdapter
            // 
            this.CV_PRINTDASHTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_PrintDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.MinimumSize = new System.Drawing.Size(700, 700);
            this.Name = "Frm_PrintDash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_PrintDash_FormClosed);
            this.Load += new System.EventHandler(this.Frm_PrintDash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CV_PRINTDASHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVBASEDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CV_PRINTDASHBindingSource;
        private CVBASEDataSet CVBASEDataSet;
        private CVBASEDataSetTableAdapters.CV_PRINTDASHTableAdapter CV_PRINTDASHTableAdapter;
    }
}