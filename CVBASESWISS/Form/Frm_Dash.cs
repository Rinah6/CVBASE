using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CVBASESWISS
{
    public partial class Frm_Dash : Form
    {
        public Frm_Dash()
        {
            InitializeComponent();

            UpdateCV();
        }

        public void UpdateCV()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                textBox1.Text = "0"; textBox2.Text = "0"; textBox3.Text = "0"; textBox4.Text = "0"; textBox5.Text = "0"; textBox6.Text = "0";
                textBox7.Text = "0"; textBox8.Text = "0"; textBox9.Text = "0"; textBox10.Text = "0"; textBox11.Text = "0"; textBox12.Text = "0";
                //textBox13.Text = "0";

                var cat = soft.CV_CATEGORY.Count();
                textBox1.Text = cat.ToString();
                var catNotSetUp = soft.CV_CATEGORY.Where(a => a.ISOK != true).Count();
                textBox2.Text = catNotSetUp.ToString();


                var nbcv = soft.CV_CVBASE.Count();
                textBox3.Text = nbcv.ToString();
                var cvAlive = soft.CV_CVBASE.Where(a => a.Sleep == null || a.Sleep == false).Count();
                textBox4.Text = cvAlive.ToString();
                var slepp = soft.CV_CVBASE.Where(a => a.Sleep == true).Count();
                textBox5.Text = slepp.ToString();
                
                var mal = soft.CV_GENDER.Where(a => a.Gender == "Male").FirstOrDefault().IDGender;
                var fem = soft.CV_GENDER.Where(a => a.Gender == "Female").FirstOrDefault().IDGender;
                var oth = soft.CV_GENDER.Where(a => a.Gender == "Other").FirstOrDefault().IDGender;

                var nbMal = soft.CV_CVBASE.Where(a => a.IDGender == mal).Count();
                var nbFem = soft.CV_CVBASE.Where(a => a.IDGender == fem).Count();
                var nbOth = soft.CV_CVBASE.Where(a => a.IDGender == oth).Count();

                textBox6.Text = nbMal.ToString();
                textBox7.Text = nbFem.ToString();
                textBox8.Text = nbOth.ToString();

                var jun = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "Junior").FirstOrDefault().IDJunSenior;
                var junLfa = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "Junior LFA").FirstOrDefault().IDJunSenior;
                var sen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "Senior").FirstOrDefault().IDJunSenior;
                var senLfa = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "Senior LFA").FirstOrDefault().IDJunSenior;
                //var Tbd = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "TBD").FirstOrDefault().IDJunSenior;

                var nbJUN = soft.CV_CVBASE.Where(a => a.IDJunSenior == jun).Count();
                var nbJUNLFA = soft.CV_CVBASE.Where(a => a.IDJunSenior == junLfa).Count();
                var nbSEN = soft.CV_CVBASE.Where(a => a.IDJunSenior == sen).Count();
                var nbSENLFA = soft.CV_CVBASE.Where(a => a.IDJunSenior == senLfa).Count();
                //var nbTBD = soft.CV_CVBASE.Where(a => a.IDJunSenior == null).Count();

                textBox9.Text = nbJUN.ToString();
                textBox10.Text = nbJUNLFA.ToString();
                textBox11.Text = nbSEN.ToString();
                textBox12.Text = nbSENLFA.ToString();
                //textBox13.Text = nbTBD.ToString();

                //Grid//
                DataTable table = new DataTable();
                table.Columns.Clear();

                table.Columns.Add("Category");
                table.Columns.Add("Alive");
                table.Columns.Add("Sleeping");
                table.Columns.Add("Male");
                table.Columns.Add("Female");
                table.Columns.Add("Other");
                table.Columns.Add("Junior");
                table.Columns.Add("J. LFA");
                table.Columns.Add("Senior");
                table.Columns.Add("S. LFA");
                //table.Columns.Add("TBD");

                table.Rows.Clear();

                foreach(var x in soft.CV_CATEGORY.OrderBy(a => a.Category).ToList())
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

                    table.Rows.Add(x.Category, alive.ToString(), sleep.ToString(), male.ToString(), fema.ToString(), othe.ToString(), 
                        NnbJUN.ToString(), NnbJUNLFA.ToString(), NnbSEN.ToString(), NnbSENLFA.ToString()/*, NnbTBD.ToString()*/);
                }

                gridListe.DataSource = table;

                var nbcvAS = cvAlive + slepp;

                var nbcvMFO = nbMal + nbFem + nbOth;

                if (nbcv != nbcvAS)
                    label14.Visible = true;
                if (nbcv != nbcvMFO)
                    label15.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(gridListe.Rows.Count != 0)
                {
                    Frm_PrintDash frm = new Frm_PrintDash();
                    frm.ShowDialog();
                }
                else
                    MessageBox.Show("Nothing to print!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
