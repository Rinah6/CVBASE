using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVBASESWISS
{
    public partial class Frm_PrintSearch : Form
    {
        public Frm_PrintSearch()
        {
            InitializeComponent();
        }

        private void Frm_PrintSearch_Load(object sender, EventArgs e)
        {
            try
            {
                okParam();

                // TODO: cette ligne de code charge les données dans la table 'CVBASEDataSet1.CV_PRINTSEARCH'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
                this.CV_PRINTSEARCHTableAdapter.Fill(this.CVBASEDataSet1.CV_PRINTSEARCH);
                // TODO: cette ligne de code charge les données dans la table 'CVBASEDataSet1.CV_PRINTSEARCH'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void okParam()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (soft.CV_PRINTSEARCH.Count() != 0)
                {
                    var isDash = soft.CV_PRINTSEARCH.FirstOrDefault();

                    Microsoft.Reporting.WinForms.ReportParameter[] rParam = new Microsoft.Reporting.WinForms.ReportParameter[]
                    {
                        new Microsoft.Reporting.WinForms.ReportParameter("CAT", isDash.CAT),
                        new Microsoft.Reporting.WinForms.ReportParameter("TECHF", isDash.TECHFIELD),
                        new Microsoft.Reporting.WinForms.ReportParameter("JUNSEN", isDash.JUNSEN),
                        new Microsoft.Reporting.WinForms.ReportParameter("DIPL", isDash.DIPL),
                        new Microsoft.Reporting.WinForms.ReportParameter("SPECS", isDash.SPEC),
                        new Microsoft.Reporting.WinForms.ReportParameter("LANG", isDash.LANG),
                        new Microsoft.Reporting.WinForms.ReportParameter("REGION", isDash.REGION),
                        new Microsoft.Reporting.WinForms.ReportParameter("GENDER", isDash.GENDER),
                        new Microsoft.Reporting.WinForms.ReportParameter("NATION", isDash.NATION),
                        new Microsoft.Reporting.WinForms.ReportParameter("CR1", isDash.CR1),
                        new Microsoft.Reporting.WinForms.ReportParameter("CR2", isDash.CR2),
                        new Microsoft.Reporting.WinForms.ReportParameter("CR3", isDash.CR3),
                        new Microsoft.Reporting.WinForms.ReportParameter("V1", isDash.V1),
                        new Microsoft.Reporting.WinForms.ReportParameter("V2", isDash.V2),
                        new Microsoft.Reporting.WinForms.ReportParameter("V3", isDash.V3),

                        new Microsoft.Reporting.WinForms.ReportParameter("FOUND", isDash.FOUND)
                    };

                    reportViewer1.LocalReport.SetParameters(rParam);
                    //reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
