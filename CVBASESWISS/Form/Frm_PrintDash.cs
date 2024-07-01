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
    public partial class Frm_PrintDash : Form
    {
        public Frm_PrintDash()
        {
            InitializeComponent();
        }

        private void Frm_PrintDash_Load(object sender, EventArgs e)
        {
            try
            {
                ok();

                okParam();

                // TODO: cette ligne de code charge les données dans la table 'CVBASEDataSet.CV_PRINTDASH'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
                this.CV_PRINTDASHTableAdapter.Fill(this.CVBASEDataSet.CV_PRINTDASH);
                // TODO: cette ligne de code charge les données dans la table 'CVBASEDataSet.CV_PRINTDASH'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

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

                if (soft.CV_PRINTDASH.Count() != 0)
                {
                    var isDash = soft.CV_PRINTDASH.FirstOrDefault();

                    Microsoft.Reporting.WinForms.ReportParameter[] rParam = new Microsoft.Reporting.WinForms.ReportParameter[]
                    {
                        new Microsoft.Reporting.WinForms.ReportParameter("CAT", isDash.CATNB),
                        new Microsoft.Reporting.WinForms.ReportParameter("NOTSET", isDash.CATNOTSETUP),
                        new Microsoft.Reporting.WinForms.ReportParameter("MALE", isDash.CVMALE),
                        new Microsoft.Reporting.WinForms.ReportParameter("FEMALE", isDash.CVFEMALE),
                        new Microsoft.Reporting.WinForms.ReportParameter("OTHER", isDash.CVOTHER),
                        new Microsoft.Reporting.WinForms.ReportParameter("CV", isDash.CVNB),
                        new Microsoft.Reporting.WinForms.ReportParameter("ALIVE", isDash.CVALIVE),
                        new Microsoft.Reporting.WinForms.ReportParameter("SLEEPING", isDash.CVSLEEP),
                        new Microsoft.Reporting.WinForms.ReportParameter("JUN", isDash.CVJUN),
                        new Microsoft.Reporting.WinForms.ReportParameter("JUNLFA", isDash.CVJUNLFA),
                        new Microsoft.Reporting.WinForms.ReportParameter("SEN", isDash.CVSEN),
                        new Microsoft.Reporting.WinForms.ReportParameter("SENLFA", isDash.CVSENLFA),
                        //new Microsoft.Reporting.WinForms.ReportParameter("TBD", isDash.CVTBD)
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

        public void ok()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                var mal = soft.CV_GENDER.Where(a => a.Gender == "Male").FirstOrDefault().IDGender;
                var fem = soft.CV_GENDER.Where(a => a.Gender == "Female").FirstOrDefault().IDGender;
                var oth = soft.CV_GENDER.Where(a => a.Gender == "Other").FirstOrDefault().IDGender;

                var jun = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "Junior").FirstOrDefault().IDJunSenior;
                var junLfa = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "Junior LFA").FirstOrDefault().IDJunSenior;
                var sen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "Senior").FirstOrDefault().IDJunSenior;
                var senLfa = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "Senior LFA").FirstOrDefault().IDJunSenior;
                //var Tbd = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "TBD").FirstOrDefault().IDJunSenior;

                //COUNT//
                var cat = soft.CV_CATEGORY.Count();
                var catNotSetUp = soft.CV_CATEGORY.Where(a => a.ISOK != true).Count();
                var nbcv = soft.CV_CVBASE.Count();
                var cvAlive = soft.CV_CVBASE.Where(a => a.Sleep == null || a.Sleep == false).Count();
                var cvslepp = soft.CV_CVBASE.Where(a => a.Sleep == true).Count();
                var nbMal = soft.CV_CVBASE.Where(a => a.IDGender == mal).Count();
                var nbFem = soft.CV_CVBASE.Where(a => a.IDGender == fem).Count();
                var nbOth = soft.CV_CVBASE.Where(a => a.IDGender == oth).Count();
                var nbJUN = soft.CV_CVBASE.Where(a => a.IDJunSenior == jun).Count();
                var nbJUNLFA = soft.CV_CVBASE.Where(a => a.IDJunSenior == junLfa).Count();
                var nbSEN = soft.CV_CVBASE.Where(a => a.IDJunSenior == sen).Count();
                var nbSENLFA = soft.CV_CVBASE.Where(a => a.IDJunSenior == senLfa).Count();
                //var nbTBD = soft.CV_CVBASE.Where(a => a.IDJunSenior == Tbd).Count();

                foreach (var x in soft.CV_CATEGORY.OrderBy(a => a.Category).ToList())
                {
                    var alive = soft.CV_CVBASE.Where(a => a.IDCat == x.IDCat && (a.Sleep == null || a.Sleep == false)).Count().ToString();

                    var sleep = soft.CV_CVBASE.Where(a => a.IDCat == x.IDCat && a.Sleep == true).Count().ToString();

                    var male = soft.CV_CVBASE.Where(a => a.IDCat == x.IDCat && a.IDGender == mal).Count().ToString();

                    var fema = soft.CV_CVBASE.Where(a => a.IDCat == x.IDCat && a.IDGender == fem).Count().ToString();

                    var othe = soft.CV_CVBASE.Where(a => a.IDCat == x.IDCat && a.IDGender == oth).Count().ToString();

                    var NnbJUN = soft.CV_CVBASE.Where(a => a.IDCat == x.IDCat && a.IDJunSenior == jun).Count().ToString();
                    var NnbJUNLFA = soft.CV_CVBASE.Where(a => a.IDCat == x.IDCat && a.IDJunSenior == junLfa).Count().ToString();
                    var NnbSEN = soft.CV_CVBASE.Where(a => a.IDCat == x.IDCat && a.IDJunSenior == sen).Count().ToString();
                    var NnbSENLFA = soft.CV_CVBASE.Where(a => a.IDCat == x.IDCat && a.IDJunSenior == senLfa).Count().ToString();
                    //var NnbTBD = soft.CV_CVBASE.Where(a => a.IDCat == x.IDCat && a.IDJunSenior == null).Count();

                    if (alive == "0")
                        alive = "";
                    if (sleep == "0")
                        sleep = "";
                    if (male == "0")
                        male = "";
                    if (fema == "0")
                        fema = "";
                    if (othe == "0")
                        othe = "";
                    if (NnbJUN == "0")
                        NnbJUN = "";
                    if (NnbJUNLFA == "0")
                        NnbJUNLFA = "";
                    if (NnbSEN == "0")
                        NnbSEN = "";
                    if (NnbSENLFA == "0")
                        NnbSENLFA = "";


                    var newImpress = new CV_PRINTDASH
                    {
                        CAT = x.Category,
                        ALIVE = alive,
                        SLEEP = sleep,
                        MALE = male,
                        FEMALE = fema,
                        OTHER = othe,
                        JUNIOR = NnbJUN,
                        JUNIOLFA = NnbJUNLFA,
                        SENIOR = NnbSEN,
                        SENIORLFA = NnbSENLFA,
                        //TBD = NnbTBD.ToString(),

                        //COUNT//
                        CATNB = cat.ToString(),
                        CATNOTSETUP = catNotSetUp.ToString(),
                        CVNB = nbcv.ToString(),
                        CVALIVE = cvAlive.ToString(),
                        CVSLEEP = cvslepp.ToString(),
                        CVMALE = nbMal.ToString(),
                        CVFEMALE = nbFem.ToString(),
                        CVOTHER = nbOth.ToString(),
                        CVJUN = nbJUN.ToString(),
                        CVJUNLFA = nbJUNLFA.ToString(),
                        CVSEN = nbSEN.ToString(),
                        CVSENLFA = nbSENLFA.ToString(),
                        //CVTBD = nbTBD.ToString()
                    };

                    soft.CV_PRINTDASH.Add(newImpress);
                    soft.SaveChanges();
                }

                //this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Frm_PrintDash_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if(soft.CV_PRINTDASH.Count() != 0)
                {
                    foreach(var x in soft.CV_PRINTDASH.ToList())
                    {
                        soft.CV_PRINTDASH.Remove(x);
                        soft.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
