using CVBASESWISS.Model;
using Domino;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVBASESWISS
{
    public partial class Form1 : Form
    {
        public static DateTime D1;
        public static DateTime D2;
        public static DateTime D3;

        public Form1()
        {
            InitializeComponent();

            DbCVBASE soft = new DbCVBASE();
            dsParameter.dsOption = soft.CV_DOCUSIGN.FirstOrDefault();

            if (Token.getAUTHO() == false)
            {
                swichDatasetToolStripMenuItem2.Enabled = false;
                parameterToolStripMenuItem.Enabled = false;
                mailingToolStripMenuItem.Enabled = false;
            }
            else
            {
                swichDatasetToolStripMenuItem2.Enabled = true;
                parameterToolStripMenuItem.Enabled = true;
                mailingToolStripMenuItem.Enabled = true;
            }
            //if (Token.getISA() == false) parameterToolStripMenuItem.Enabled = false;
            var dataco = "";
            int isco2 = Token.getisCO();
            if (soft.CV_DATASET.Where(a => a.ID_USERS == isco2).Count() != 0)
            {
                dataco = soft.CV_DATASET.Where(a => a.ID_USERS == isco2).FirstOrDefault().DATASETCV;

                if (!String.IsNullOrEmpty(dataco))
                {
                    MessageBox.Show("You are connected to the " + dataco + " data set!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Please define the data set!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            remplir(String.Empty);

            label5.Text = DateTime.Now.ToShortDateString();

            label7.Text = "Number of records in the Database : " + soft.CV_CVBASE.Count().ToString();

            var auth = "NOT AUTHORISED";
            if(Token.getAUTHO() == true)
                auth = "AUTHORISED";
            label8.Text = auth;

            var getCo = Token.getisCO();
            var isco = soft.CV_USERS.Where(a => a.ID_USERS == getCo).FirstOrDefault().LOGIN;
            label6.Text = "User : " + isco;
        }
        public Form1(bool auths)
        {
            InitializeComponent();

            DbCVBASE soft = new DbCVBASE();
            dsParameter.dsOption = soft.CV_DOCUSIGN.FirstOrDefault();

            if (Token.getAUTHO() == false)
            {
                swichDatasetToolStripMenuItem2.Enabled = false;
                //  parameterToolStripMenuItem.Enabled = false;
                mailingToolStripMenuItem.Enabled = false;
            }
            else
            {
                swichDatasetToolStripMenuItem2.Enabled = true;
                //   parameterToolStripMenuItem.Enabled = true;
                mailingToolStripMenuItem.Enabled = true;
            }
            //     if (Token.getISA() == false) parameterToolStripMenuItem.Enabled = false;
            var dataco = "";
            int isco2 = Token.getisCO();
            remplir(String.Empty);

            label5.Text = DateTime.Now.ToShortDateString();

            label7.Text = "Number of records in the Database : " + soft.CV_CVBASE.Count().ToString();

            var auth = "NOT AUTHORISED";
            if (Token.getAUTHO() == true)
                auth = "AUTHORISED";
            label8.Text = auth;

            var getCo = Token.getisCO();
            var isco = soft.CV_USERS.Where(a => a.ID_USERS == getCo).FirstOrDefault().LOGIN;
            label6.Text = "User : " + isco;
        }
        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Token.getAUTHO() == true && Token.getISA() == true)
            {
                Frm_User frm = new Frm_User();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Your current status does not authorise the action" + "\n\n" + "Please contact Admin!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_cvadd frm = new Frm_cvadd();
            frm.ShowDialog();
            remplir(String.Empty);
          
            /*if (frm.ShowDialog() == DialogResult.OK)
            {
                remplir(String.Empty);
            }*/
        }

        public void remplir(string search)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                label7.Text = "Number of records in the Database : " + soft.CV_CVBASE.Count().ToString();

                DataTable table = new DataTable();
                table.Columns.Clear();

                table.Columns.Add("ID");
                table.Columns.Add("Status");
                table.Columns.Add("Date of creation");
                table.Columns.Add("Date of CV");
                table.Columns.Add("Last Name");
                table.Columns.Add("First Name");
                table.Columns.Add("Birthday");
                table.Columns.Add("Age");
                table.Columns.Add("Given age");
                table.Columns.Add("Gender");
                table.Columns.Add("Nationality");
                table.Columns.Add("Level");
                table.Columns.Add("Category");
                /*table.Columns.Add("Adress1");
                table.Columns.Add("Zip code");
                table.Columns.Add("Town");
                table.Columns.Add("Country");*/
                table.Columns.Add("Phone mobile");
                table.Columns.Add("Phone Land line");
                table.Columns.Add("@Mail1");
                //table.Columns.Add("Person of ref.");

                table.Columns["Date of creation"].DataType = System.Type.GetType("System.DateTime");
                table.Columns["Date of CV"].DataType = System.Type.GetType("System.DateTime");
                table.Columns["Birthday"].DataType = System.Type.GetType("System.DateTime");

                table.Rows.Clear();

                if (String.IsNullOrEmpty(search))
                {
                    if (soft.CV_CVBASE.Count() != 0)
                    {
                        foreach (var x in soft.CV_CVBASE.OrderBy(a => a.LastName).ToList())
                        {
                            var id = x.IDCV;

                            var stat = "ALIVE";
                            if (x.Sleep == true)
                                stat = "SLEEP";

                            var dateCreate = "";
                            if (x.DateSave != null)
                                D1 = x.DateSave.Value;

                            var dateCV = "";
                            if (x.DateCV != null)
                                D2 = x.DateCV.Value;

                            var Lastname = x.LastName;

                            var Firstname = x.FirstName;

                            var BD = "";
                            var age = "";
                            if (x.BirthDay != null)
                            {
                                D3 = x.BirthDay.Value;

                                var dtNo = DateTime.Now;

                                var years = (dtNo.Year - x.BirthDay.Value.Year - (DateTime.Now.Month < x.BirthDay.Value.Month ? 1 : (DateTime.Now.Month == x.BirthDay.Value.Month && DateTime.Now.Day < x.BirthDay.Value.Day) ? 1 : 0));

                                age = years.ToString();
                            }

                            var givenAge = "0";
                            if (x.GivenAge != null)
                                givenAge = x.GivenAge.ToString();
                            //if (x.DateSave != null && x.BirthDay == null)
                            //{
                            //    var dtNo = DateTime.Now;

                            //    var years = (dtNo.Year - x.DateSave.Value.Year - (DateTime.Now.Month < x.DateSave.Value.Month ? 1 : (DateTime.Now.Month == x.DateSave.Value.Month && DateTime.Now.Day < x.DateSave.Value.Day) ? 1 : 0));

                            //    givenAge = years.ToString();
                            //}

                            var gender = "";
                            if (x.IDGender != null && x.IDGender != 0)
                            {
                                var gend = soft.CV_GENDER.Where(a => a.IDGender == x.IDGender).FirstOrDefault();

                                gender = gend.Gender;
                            }

                            var nation = "";
                            if (x.IDNationality != null && x.IDNationality != 0)
                            {
                                var natio = soft.CV_NATIONS.Where(a => a.IDCountry == x.IDNationality).FirstOrDefault();

                                nation = natio.Country;
                            }

                            var junS = "";
                            if (x.IDJunSenior != null && x.IDJunSenior != 0)
                            {
                                var country = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == x.IDJunSenior).FirstOrDefault();

                                junS = country.JunSenior;
                            }

                            var catE = "";
                            if (x.IDCat != null && x.IDCat != 0)
                            {
                                var cat = soft.CV_CATEGORY.Where(a => a.IDCat == x.IDCat).FirstOrDefault();

                                catE = cat.Category;
                            }

                            //var ad1 = x.Adress1;

                            //var zip = x.ZipCode;

                            //var town = x.Town;

                            /*var countr = "";
                            if (x.IDCountry != null && x.IDCountry != 0)
                            {
                                var country = soft.CV_NATIONS.Where(a => a.IDCountry == x.IDCountry).FirstOrDefault();

                                countr = country.Country;
                            }*/

                            var mobil = x.MobilPhone;

                            var landline = x.LandlinePhone;

                            var mail = x.Email1;

                            /*var persRef = "";
                            if (x.IDPersRef != null && x.IDPersRef != 0)
                            {
                                var pers = soft.CV_EMPLOYEE.Where(a => a.IDPersRef == x.IDPersRef).FirstOrDefault();

                                persRef = pers.PersRef;
                            }*/

                            table.Rows.Add(id, stat, D1, D2, Lastname, Firstname, D3, age, givenAge, gender, nation, junS, catE,/* ad1, zip, town, countr,*/ mobil, landline, mail/*, persRef*/);
                        }
                    }
                }
                else
                {
                    if (soft.CV_CVBASE.Count() != 0)
                    {
                        foreach (var x in soft.CV_CVBASE.OrderBy(a => a.LastName).ToList())
                        {
                            var id = x.IDCV.ToString();

                            var stat = "ALIVE";
                            if (x.Sleep == true)
                                stat = "SLEEP";

                            var dateCreate = "";
                            if (x.DateSave != null)
                                D1 = x.DateSave.Value;

                            var dateCV = "";
                            if (x.DateCV != null)
                                D2 = x.DateCV.Value;

                            var Lastname = "";
                            if(x.LastName != null)
                                Lastname = x.LastName;

                            var Firstname = "";
                            if(x.FirstName != null)
                                Firstname = x.FirstName;

                            var BD = "";
                            var age = "";
                            if (x.BirthDay != null)
                            {
                                D3 = x.BirthDay.Value;

                                var dtNo = DateTime.Now;

                                var years = (dtNo.Year - x.BirthDay.Value.Year - (DateTime.Now.Month < x.BirthDay.Value.Month ? 1 : (DateTime.Now.Month == x.BirthDay.Value.Month && DateTime.Now.Day < x.BirthDay.Value.Day) ? 1 : 0));

                                age = years.ToString();
                            }

                            var givenAge = "";
                            if (x.DateSave != null && x.BirthDay == null)
                            {
                                var dtNo = DateTime.Now;

                                var years = (dtNo.Year - x.DateSave.Value.Year - (DateTime.Now.Month < x.DateSave.Value.Month ? 1 : (DateTime.Now.Month == x.DateSave.Value.Month && DateTime.Now.Day < x.DateSave.Value.Day) ? 1 : 0));

                                givenAge = years.ToString();
                            }

                            var gender = "";
                            if (x.IDGender != null && x.IDGender != 0)
                            {
                                var gend = soft.CV_GENDER.Where(a => a.IDGender == x.IDGender).FirstOrDefault();

                                gender = gend.Gender;
                            }

                            var nation = "";
                            if (x.IDNationality != null && x.IDNationality != 0)
                            {
                                var natio = soft.CV_NATIONS.Where(a => a.IDCountry == x.IDNationality).FirstOrDefault();

                                nation = natio.Country;
                            }

                            var junS = "";
                            if (x.IDJunSenior != null && x.IDJunSenior != 0)
                            {
                                var country = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == x.IDJunSenior).FirstOrDefault();

                                junS = country.JunSenior;
                            }

                            var catE = "";
                            if (x.IDCat != null && x.IDCat != 0)
                            {
                                var cat = soft.CV_CATEGORY.Where(a => a.IDCat == x.IDCat).FirstOrDefault();

                                catE = cat.Category;
                            }

                            /*var ad1 = "";
                            if(x.Adress1 != null)
                                ad1 = x.Adress1;

                            var zip = "";
                            if(x.ZipCode != null)
                                zip = x.ZipCode;

                            var town = "";
                            if(x.Town != null)
                                town = x.Town;

                            var countr = "";
                            if (x.IDCountry != null && x.IDCountry != 0)
                            {
                                var country = soft.CV_NATIONS.Where(a => a.IDCountry == x.IDCountry).FirstOrDefault();

                                countr = country.Country;
                            }*/

                            var mobil = "";
                            if(x.MobilPhone != null)
                                mobil = x.MobilPhone;

                            var landline = "";
                            if(x.LandlinePhone != null)
                                landline = x.LandlinePhone;

                            var mail = "";
                            if(x.Email1 != null)
                                mail = x.Email1;

                            /*var persRef = "";
                            if (x.IDPersRef != null && x.IDPersRef != 0)
                            {
                                var pers = soft.CV_EMPLOYEE.Where(a => a.IDPersRef == x.IDPersRef).FirstOrDefault();

                                persRef = pers.PersRef;
                            }*/

                            if (id.ToUpper().Contains(search.ToUpper()) || stat.ToUpper().Contains(search.ToUpper()) || dateCreate.ToUpper().Contains(search.ToUpper()) || dateCV.ToUpper().Contains(search.ToUpper()) || Lastname.ToUpper().Contains(search.ToUpper()) || Firstname.ToUpper().Contains(search.ToUpper()) || BD.ToUpper().Contains(search.ToUpper()) || age.ToUpper().Contains(search.ToUpper()) || givenAge.ToUpper().Contains(search.ToUpper())
                                || gender.ToUpper().Contains(search.ToUpper()) || nation.ToUpper().Contains(search.ToUpper()) || junS.ToUpper().Contains(search.ToUpper()) || catE.ToUpper().Contains(search.ToUpper()) || mobil.ToUpper().Contains(search.ToUpper())
                                || landline.ToUpper().Contains(search.ToUpper()) || mail.ToUpper().Contains(search.ToUpper()))
                            {
                                table.Rows.Add(id, stat, D1, D2, Lastname, Firstname, D3, age, givenAge, gender, nation, junS, catE/*, ad1, zip, town, countr, */, mobil, landline, mail/*, persRef*/);
                            }
                        }
                    }
                }

                gridListe.DataSource = table;

                gridListe.Columns[0].Visible = false;

                //gridListe.Columns[2].DefaultCellStyle.Format = "dd-MM-yyyy";
                //gridListe.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy";
                //gridListe.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";

                var dataco = "";
                int isco = Token.getisCO();
                if (soft.CV_DATASET.Where(a => a.ID_USERS == isco).Count() != 0)
                {
                    dataco = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;

                    if (!String.IsNullOrEmpty(dataco))
                    {
                        //MessageBox.Show("You are connected to the " + dataco + " data set!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        label2.Text = "You are connected to the " + dataco + " data set.";
                        label2.ForeColor = Color.LimeGreen;
                    }
                    else
                    {
                        //MessageBox.Show("Please define the data set!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        label2.Text = "Data set undefined.";
                        label2.ForeColor = Color.Tomato;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    remplir(textBox1.Text);
                }
                else
                {
                    remplir(String.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Dash frm = new Frm_Dash();
            frm.ShowDialog();
        }

        private void dataSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Search frm = new Frm_Search();
            frm.ShowDialog();
        }

        private void swichDatasetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_DATAWH frm = new Frm_DATAWH();
            frm.ShowDialog();
        }

        private void jUNIORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_RankingJ frm = new Frm_RankingJ();
            frm.ShowDialog();
        }

        private void sENIORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_RankingS frm = new Frm_RankingS();
            frm.ShowDialog();
        }

        private void rankingDiplomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_RankDipl frm = new Frm_RankDipl();
            frm.ShowDialog();
        }

        private void setupCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_SetupCat frm = new Frm_SetupCat();
            frm.ShowDialog();
        }

        private void gridListe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                var name = gridListe.CurrentRow.Cells[4].Value.ToString();

                if (!String.IsNullOrEmpty(name))
                {
                    var isCV = soft.CV_CVBASE.Where(a => a.LastName == name).FirstOrDefault();

                    int isco = Token.getisCO();
                    var iscoJun = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;

                    if(!String.IsNullOrEmpty(iscoJun))
                    {
                        var idJunSen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == iscoJun).FirstOrDefault().IDJunSenior;

                        if (soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior == "ALL")
                        {
                            Frm_cvadd frm = new Frm_cvadd();

                            frm.textPrenom.Focus();

                            frm.InitialCVNEW();
                            frm.fromform = true;
                            frm.DetailsCV(name);

                            frm.ShowDialog();

                            remplir(String.Empty);
                        }
                        else
                        {
                            //Original//
                            var isJUn = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior;
                            //CV//
                            var isFOrCv = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == isCV.IDJunSenior).FirstOrDefault().JunSenior;
                            if (isFOrCv.ToUpper().Contains(isJUn.ToUpper()))
                            {
                                Frm_cvadd frm = new Frm_cvadd();

                                frm.textPrenom.Focus();

                                frm.InitialCVNEW();
                                frm.DetailsCV(name);

                                frm.ShowDialog();

                                remplir(String.Empty);
                            }
                            else
                                MessageBox.Show("The selected CV is not from the chosen Level", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void cCMAILToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CC frm = new Frm_CC();
            frm.ShowDialog();
        }

        private void superAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_UserAUTHO frm = new Frm_UserAUTHO();
            frm.ShowDialog();

            if (Token.getAUTHO() == false)
            {
                swichDatasetToolStripMenuItem2.Enabled = false;
                //  parameterToolStripMenuItem.Enabled = false;
                mailingToolStripMenuItem.Enabled = false;
            }
            else
            {
                swichDatasetToolStripMenuItem2.Enabled = true;
                //   parameterToolStripMenuItem.Enabled = true;
                mailingToolStripMenuItem.Enabled = true;
            }
        }

        private void datasetConnexionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_CCMAIL frm = new Frm_CCMAIL();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DbCVBASE soft = new DbCVBASE();
                    var dataco = "";
                    int isco = Token.getisCO();
                    if (soft.CV_DATASET.Where(a => a.ID_USERS == isco).Count() != 0)
                    {
                        dataco = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;

                        if (!String.IsNullOrEmpty(dataco))
                        {
                            //MessageBox.Show("You are connected to the " + dataco + " data set!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            label2.Text = "You are connected to the " + dataco + " data set.";
                            label2.ForeColor = Color.LimeGreen;
                        }
                        else
                        {
                            //MessageBox.Show("Please define the data set!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            label2.Text = "Data set undefined.";
                            label2.ForeColor = Color.Tomato;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
              //  remplir(String.Empty);
            }
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
                remplir(String.Empty);
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_MODELM frm = new Frm_MODELM();
            frm.ShowDialog();
        }

        private void rEQUESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                List<string> elem = new List<string>();
                List<string> elemOUTMAIL = new List<string>();
                List<string> elemALREADY = new List<string>();

                var dateNow = DateTime.Now;

                if (soft.CV_BATCH.Count() != 0)
                {
                    var isbatch = soft.CV_BATCH.FirstOrDefault();
                    if (isbatch.LOT == null)
                        MessageBox.Show("Initialize the number of e-mails per batch", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        int perBatch = isbatch.LOT.Value;
                        //GET ALL CV//
                        string message = Interaction.InputBox("If the CV is older than 12 months then I send a \n request for update by E-mail. Then press OK. \n Otherwise, please change the value : \n Cancel to stop the process.", "CVBASE", "12", -1, -1);
                        if (!String.IsNullOrEmpty(message))
                        {
                            int i = 0;
                            int j = 0;
                            int m = 0;
                            int ismatch = 0;
                          
                            int nomail = 0;
                            int already = 0;
                            int limites = int.Parse(message);
                            if (soft.CV_CVBASE.Count() != 0)
                            {
                                foreach (var x in soft.CV_CVBASE.ToList())
                                {
                                    if (x.DateCV != null)
                                    {
                                        int nb = 0;
                                        var dt2 = dateNow;
                                        if (x.DateCV.Value.Month > dt2.Month)
                                            nb += x.DateCV.Value.Month - dt2.Month;
                                        else if (x.DateCV.Value.Month < dt2.Month)
                                            nb += (12 - x.DateCV.Value.Month) + dt2.Month;
                                        nb += Math.Abs((x.DateCV.Value.Year - dt2.Year) * 12);

                                        //CHECK IF CV OK//
                                        if (nb >= limites)
                                        {
                                            ismatch++;
                                            
                                            if (soft.CV_DOCDATECOMM.Where(a => a.IDCV == x.IDCV).Count() != 0)
                                            {
                                                var isDT = soft.CV_DOCDATECOMM.Where(a => a.IDCV == x.IDCV).FirstOrDefault();
                                                if (isDT.UpdateCV == null)
                                                {
                                                    i++;
                                                   
                                                    if (!elem.Contains(x.LastName))
                                                        elem.Add(x.LastName);
                                                }
                                                else
                                                {
                                                    m++;
                                                    if (!elemALREADY.Contains(x.LastName))
                                                        elemALREADY.Add(x.LastName);
                                                }
                                            }
                                            else
                                            {
                                                i++;
                                                
                                                if (!elem.Contains(x.LastName))
                                                    elem.Add(x.LastName);
                                            }
                                            if (String.IsNullOrEmpty(x.Email1) && String.IsNullOrEmpty(x.Email2))
                                            {
                                                j++;
                                                elem.Remove(x.LastName);
                                            }
                                        }
                                        else
                                        {
                                           
                                            if (soft.CV_DOCDATECOMM.Where(a => a.IDCV == x.IDCV).Count() != 0)
                                            {
                                                var isDT = soft.CV_DOCDATECOMM.Where(a => a.IDCV == x.IDCV).FirstOrDefault();
                                                if (isDT.UpdateCV != null)
                                                {
                                                    m++;
                                                    already++;
                                                    if (!elemALREADY.Contains(x.LastName))
                                                        elemALREADY.Add(x.LastName);
                                                    if (elem.Contains(x.LastName))
                                                        elem.Remove(x.LastName);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ismatch++;
                                        i++;
                                        
                                        if (!elem.Contains(x.LastName))
                                        {
                                            elem.Add(x.LastName);
                                            if (String.IsNullOrEmpty(x.Email1) && String.IsNullOrEmpty(x.Email2))
                                            {
                                                j++;
                                          
                                                elem.Remove(x.LastName);
                                            }
                                        }

                                        if (soft.CV_DOCDATECOMM.Where(a => a.IDCV == x.IDCV).Count() != 0)
                                        {
                                            var isDT = soft.CV_DOCDATECOMM.Where(a => a.IDCV == x.IDCV).FirstOrDefault();
                                            if (isDT.UpdateCV != null)
                                            {
                                                m++;
                                                already++;
                                              //  ismatch--;
                                                if (!elemALREADY.Contains(x.LastName))
                                                    elemALREADY.Add(x.LastName);
                                                if (elem.Contains(x.LastName))
                                                    elem.Remove(x.LastName);




                                                if (String.IsNullOrEmpty(x.Email1) && String.IsNullOrEmpty(x.Email2))
                                                {
                                                    j++;
                                                    nomail++;
                                                    elem.Remove(x.LastName);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            //i = total number of CV to generate//
                            if (i > 0)
                            {
                                //int k = 0;
                                int l = 0;
                                //int t = 0;
                                string messaka = "We found " + ismatch + " people to send an email to.\n\n Do you want to proceed?";

                                if (j > 0)
                                {
                                    messaka = "We have found " + ismatch + " persons to e-mail out of which " + j + " with no e-mail address.\n\n Do you want to proceed?";
                                    if (m > 0)
                                        messaka = "We have found " + ismatch + " persons to e-mail to out of which " + j + " with no e-mail address and " + m + " with an ongoing update process.\n\n Do you want to proceed?";
                                }
                                else
                                {
                                    if (m > 0)
                                        messaka = "We have found " + i + " persons to e-mail to out address and " + m + " with an ongoing update process.\n\n Do you want to proceed?";
                                }

                                string caption = "CVBASE";
                                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                DialogResult resultA;
                                resultA = MessageBox.Show(messaka, caption, buttons);
                                if (resultA == System.Windows.Forms.DialogResult.Yes)
                                {
                                    string mesA = "0";
                                //    int nnb = ismatch - j - m;
                                    int nnb = elem.Count();
                                    int nbBach = nnb / perBatch;
                                    int modulonbBach = nnb % perBatch;

                                    if (nnb <= 0)
                                        MessageBox.Show("0 message in the mailbox", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else if (nbBach == 0)
                                    {
                                        var ct = elem.Count();
                                        mesA = "We have found " + ct + " emails to generate \n\n Do you want to generate?";
                                        string captionB = "CVBASE";
                                        MessageBoxButtons buttonsB = MessageBoxButtons.YesNo;
                                        DialogResult resultB;

                                        // Displays the MessageBox.
                                        resultB = MessageBox.Show(mesA, captionB, buttonsB);

                                        if (resultB == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            foreach (var x in elem.OrderBy(a => a).ToList())
                                            {
                                                var isCV = soft.CV_CVBASE.Where(a => a.LastName == x).FirstOrDefault();

                                              
                                                //GET THE SENDTO MAIL//
                                                var sendTo = "";
                                                if (!String.IsNullOrEmpty(isCV.Email1))
                                                    sendTo = isCV.Email1;
                                                else
                                                    sendTo = isCV.Email2;

                                               

                                                if (!String.IsNullOrEmpty(isCV.Email1) || !String.IsNullOrEmpty(isCV.Email2))
                                                {
                                                    l++;
                                                    var cc = "";
                                                    string bbdy = "";
                                                    string dsbody = "";
                                                    string ds = "";
                                                    if (soft.CV_CCMAIL.Count() != 0)
                                                    {
                                                        var isCC = soft.CV_CCMAIL.FirstOrDefault();
                                                        if (!String.IsNullOrEmpty(isCC.CCMAIL))
                                                            cc = soft.CV_CCMAIL.FirstOrDefault().CCMAIL;

                                                        if (!String.IsNullOrEmpty(isCC.MDLMAIL))
                                                            bbdy = soft.CV_CCMAIL.FirstOrDefault().MDLMAIL;
                                                        //if (!String.IsNullOrEmpty(isCC.RETMAIL))
                                                        //    dsbody = soft.CV_CCMAIL.FirstOrDefault().RETMAIL;
                                                        if (!String.IsNullOrEmpty(isCC.DSPF))
                                                            ds = soft.CV_CCMAIL.FirstOrDefault().DSPF;
                                                    }

                                                    bbdy = bbdy.Replace("NBMANC", limites.ToString());

                                                    var salutation = "Mrs.";
                                                    if (isCV.Title == true)
                                                        salutation = "Mr.";

                                                    string docusign = "";

                                                    if (!String.IsNullOrEmpty(ds))
                                                    {
                                                        docusign = $"{ds}" +
                                                           $"&title1={salutation} {isCV.FirstName + " " + isCV.LastName}" +
                                                           $"&title2={salutation} {isCV.FirstName + " " + isCV.LastName}" +
                                                           $"&Signer_UserName={isCV.FirstName + " " + isCV.LastName}" +
                                                           $"&Signer_Email={sendTo}" +
                                                           $"&month={limites}" +
                                                           $"&date={dateNow.ToString("dd-MM-yyyy")}";
                                                        docusign = docusign.Replace(" ", "%20");
                                                        /*docusign = $"${ds}" + System.Uri.EscapeDataString(
                                                            $"&title1=${salutation} ${isCV.FirstName + " " + isCV.LastName}" +
                                                            $"&title2=${salutation} ${isCV.FirstName + " " + isCV.LastName}" +
                                                            $"&Signer_UserName=${isCV.FirstName + " " + isCV.LastName}" +
                                                            $"&Signer_Email=${sendTo}" +
                                                            $"&month=${limites}" +
                                                            $"&date=${dateNow.ToString("dd-MM-yyyy")}");*/
                                                        //docusign = $"<a href=\"{docusign}\"> Review and sign the document | DocuSign </a>";
                                                        //dsbody += "\n\n" + docusign;
                                                    }
                                                    //else dsbody = "";

                                                    bbdy = bbdy.Replace("DSLINK", docusign);
                                                    var body = "Dear " + salutation + " " + isCV.FirstName + " " + isCV.LastName + "," + "\n\n" + bbdy + "\n\n" + dsbody;


                                                    dynamic Notes = null;
                                                    object db = null;
                                                    dynamic WorkSpace = null;
                                                    dynamic UIdoc = null;
                                                    string userName = null;
                                                    string MailDbName = null;

                                                    Notes = Activator.CreateInstance(Type.GetTypeFromProgID("Notes.NotesSession"));
                                                    userName = Notes.userName;
                                                    MailDbName = userName.Substring(0, 1) + userName.Substring(userName.Length - ((userName.Length - (userName.IndexOf(" ", 0) + 1)))) + ".nsf";
                                                    db = Notes.GetDataBase(null, MailDbName);
                                                    WorkSpace = Activator.CreateInstance(Type.GetTypeFromProgID("Notes.NotesUIWorkspace"));
                                                    WorkSpace.ComposeDocument("", "", "Memo");
                                                    UIdoc = WorkSpace.currentdocument;
                                                    string Recipient = sendTo;
                                                    string CCD = cc;
                                                    UIdoc.FieldSetText("EnterSendTo", Recipient);
                                                    UIdoc.FieldSetText("EnterCopyTo", CCD);
                                                    string Subject = "Request for CV update";
                                                    UIdoc.FieldSetText("Subject", Subject);
                                                    UIdoc.GotoField("Body");
                                                    UIdoc.INSERTTEXT(body);
                                                    UIdoc = null;
                                                    WorkSpace = null;
                                                    db = null;
                                                    Notes = null;
                                                    MessageBox.Show("Message " + l + " on " + nnb + " in the mailbox ready to go", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    if (soft.CV_DOCDATECOMM.Where(a => a.IDCV == isCV.IDCV).Count() != 0)
                                                    {
                                                        var isDaocD = soft.CV_DOCDATECOMM.Where(a => a.IDCV == isCV.IDCV).FirstOrDefault();
                                                        isDaocD.UpdateCV = dateNow.Date;
                                                        soft.SaveChanges();
                                                    }
                                                    else
                                                    {
                                                        var newDaocD = new CV_DOCDATECOMM
                                                        {
                                                            UpdateCV = dateNow.Date,
                                                            IDCV = isCV.IDCV
                                                        };
                                                        soft.CV_DOCDATECOMM.Add(newDaocD);
                                                        soft.SaveChanges();
                                                    }
                                                    //INSERT HISTORY//
                                                    var newHUR = new CV_HISTOUR
                                                    {
                                                        FirstName = isCV.FirstName,
                                                        LastName = isCV.LastName,
                                                        Date = dateNow.Date,
                                                        Mail = sendTo,
                                                        IDCV = isCV.IDCV
                                                    };
                                                    soft.CV_HISTOUR.Add(newHUR);
                                                    soft.SaveChanges();

                                                    if(!String.IsNullOrEmpty(docusign)) SaveMailDocusign(sendTo, isCV, dateNow, docusign);
                                                }
                                                else
                                                {
                                                    if (!elemOUTMAIL.Contains(x))
                                                    {
                                                        elemOUTMAIL.Add(x);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (modulonbBach == 0)
                                        {
                                            mesA = "We have found " + nbBach + " batchs of " + perBatch + " CV to generate.\n\n Do you want to process?";
                                            int total = nbBach;
                                            int lj = 0;
                                            //int kj = 1;
                                            string captionC = "CVBASE";
                                            MessageBoxButtons buttonsC = MessageBoxButtons.YesNo;
                                            DialogResult resultC;
                                            // Displays the MessageBox.
                                            resultC = MessageBox.Show(mesA, captionC, buttonsC);

                                            if (resultC == System.Windows.Forms.DialogResult.Yes)
                                            {
                                                for (var xx = 1; xx <= total; xx++)
                                                {
                                                    mesA = "Do you want to generate the batch n° " + xx + "?";
                                                    int kj = 1;

                                                    string captionB = "CVBASE";
                                                    MessageBoxButtons buttonsB = MessageBoxButtons.YesNo;
                                                    DialogResult resultB;
                                                    // Displays the MessageBox.
                                                    resultB = MessageBox.Show(mesA, captionB, buttonsB);

                                                    if (resultB == System.Windows.Forms.DialogResult.Yes)
                                                    {
                                                        if (kj <= perBatch)
                                                        {
                                                            foreach (var x in elem.OrderBy(a => a).ToList())
                                                            {
                                                                if (kj <= perBatch)
                                                                {
                                                                    var isCV = soft.CV_CVBASE.Where(a => a.LastName == x).FirstOrDefault();

                                                                    if (soft.CV_DOCDATECOMM.Where(a => a.IDCV == isCV.IDCV).Count() != 0)
                                                                    {
                                                                        var isDaocD = soft.CV_DOCDATECOMM.Where(a => a.IDCV == isCV.IDCV).FirstOrDefault();
                                                                        isDaocD.UpdateCV = dateNow.Date;
                                                                        soft.SaveChanges();
                                                                    }
                                                                    else
                                                                    {
                                                                        var newDaocD = new CV_DOCDATECOMM
                                                                        {
                                                                            UpdateCV = dateNow.Date,
                                                                            IDCV = isCV.IDCV
                                                                        };
                                                                        soft.CV_DOCDATECOMM.Add(newDaocD);
                                                                        soft.SaveChanges();
                                                                    }
                                                                    //GET THE SENDTO MAIL//
                                                                    var sendTo = "";
                                                                    if (!String.IsNullOrEmpty(isCV.Email1))
                                                                        sendTo = isCV.Email1;
                                                                    else
                                                                        sendTo = isCV.Email2;



                                                                    if (!String.IsNullOrEmpty(isCV.Email1) || !String.IsNullOrEmpty(isCV.Email2))
                                                                    {
                                                                        lj++;
                                                                        var cc = "";
                                                                        string bbdy = "";
                                                                        string dsbody = "";
                                                                        string ds = "";
                                                                        if (soft.CV_CCMAIL.Count() != 0)
                                                                        {
                                                                            var isCC = soft.CV_CCMAIL.FirstOrDefault();
                                                                            if (!String.IsNullOrEmpty(isCC.CCMAIL))
                                                                                cc = soft.CV_CCMAIL.FirstOrDefault().CCMAIL;

                                                                            if (!String.IsNullOrEmpty(isCC.MDLMAIL))
                                                                                bbdy = soft.CV_CCMAIL.FirstOrDefault().MDLMAIL;
                                                                            //if (!String.IsNullOrEmpty(isCC.RETMAIL))
                                                                            //    dsbody = soft.CV_CCMAIL.FirstOrDefault().RETMAIL;
                                                                            if (!String.IsNullOrEmpty(isCC.DSPF))
                                                                                ds = soft.CV_CCMAIL.FirstOrDefault().DSPF;
                                                                        }

                                                                        bbdy = bbdy.Replace("NBMANC", limites.ToString());

                                                                        var salutation = "Mrs.";
                                                                        if (isCV.Title == true)
                                                                            salutation = "Mr.";

                                                                        string docusign = "";

                                                                        if (!String.IsNullOrEmpty(ds))
                                                                        {
                                                                            docusign = $"{ds}" +
                                                                               $"&title1={salutation} {isCV.FirstName + " " + isCV.LastName}" +
                                                                               $"&title2={salutation} {isCV.FirstName + " " + isCV.LastName}" +
                                                                               $"&Signer_UserName={isCV.FirstName + " " + isCV.LastName}" +
                                                                               $"&Signer_Email={sendTo}" +
                                                                               $"&month={limites}" +
                                                                               $"&date={dateNow.ToString("dd-MM-yyyy")}";
                                                                            docusign = docusign.Replace(" ", "%20");
                                                                            /*docusign = $"${ds}" + System.Uri.EscapeDataString(
                                                                                $"&title1=${salutation} ${isCV.FirstName + " " + isCV.LastName}" +
                                                                                $"&title2=${salutation} ${isCV.FirstName + " " + isCV.LastName}" +
                                                                                $"&Signer_UserName=${isCV.FirstName + " " + isCV.LastName}" +
                                                                                $"&Signer_Email=${sendTo}" +
                                                                                $"&month=${limites}" +
                                                                                $"&date=${dateNow.ToString("dd-MM-yyyy")}");*/
                                                                            //docusign = $"<a href=\"{docusign}\"> Review and sign the document | DocuSign </a>";
                                                                            //dsbody += "\n\n" + docusign;
                                                                        }
                                                                        //else dsbody = "";

                                                                        bbdy = bbdy.Replace("DSLINK", docusign);
                                                                        //var body = "Dear " + salutation + " " + isCV.FirstName + " " + isCV.LastName + "," + "\n\n" + bbdy;
                                                                        var body = "Dear " + salutation + " " + isCV.FirstName + " " + isCV.LastName + "," + "\n\n" + bbdy + "\n\n" + dsbody;


                                                                        dynamic Notes = null;
                                                                        object db = null;
                                                                        dynamic WorkSpace = null;
                                                                        dynamic UIdoc = null;
                                                                        string userName = null;
                                                                        string MailDbName = null;
                                                                        Notes = Activator.CreateInstance(Type.GetTypeFromProgID("Notes.NotesSession"));
                                                                        userName = Notes.userName;
                                                                        MailDbName = userName.Substring(0, 1) + userName.Substring(userName.Length - ((userName.Length - (userName.IndexOf(" ", 0) + 1)))) + ".nsf";
                                                                        db = Notes.GetDataBase(null, MailDbName);
                                                                        WorkSpace = Activator.CreateInstance(Type.GetTypeFromProgID("Notes.NotesUIWorkspace"));
                                                                        WorkSpace.ComposeDocument("", "", "Memo");
                                                                        UIdoc = WorkSpace.currentdocument;
                                                                        string Recipient = sendTo;
                                                                        string CCD = cc;
                                                                        UIdoc.FieldSetText("EnterSendTo", Recipient);
                                                                        UIdoc.FieldSetText("EnterCopyTo", CCD);
                                                                        string Subject = "Request for CV update";
                                                                        UIdoc.FieldSetText("Subject", Subject);
                                                                        UIdoc.GotoField("Body");
                                                                        UIdoc.INSERTTEXT(body);
                                                                        UIdoc = null;
                                                                        WorkSpace = null;
                                                                        db = null;
                                                                        Notes = null;

                                                                        MessageBox.Show("Message " + lj + " on " + nnb + " in the mailbox ready to go", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                                        //INSERT HISTORY//
                                                                        var newHUR = new CV_HISTOUR
                                                                        {
                                                                            FirstName = isCV.FirstName,
                                                                            LastName = isCV.LastName,
                                                                            Date = dateNow.Date,
                                                                            Mail = sendTo,
                                                                            IDCV = isCV.IDCV
                                                                        };
                                                                        soft.CV_HISTOUR.Add(newHUR);
                                                                        soft.SaveChanges();

                                                                        if (!String.IsNullOrEmpty(docusign)) SaveMailDocusign(sendTo, isCV, dateNow, docusign);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (!elemOUTMAIL.Contains(x))
                                                                        {
                                                                            elemOUTMAIL.Add(x);
                                                                        }
                                                                    }
                                                                    elem.Remove(x);
                                                                    kj++;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                              
                                            }
                                        }
                                        else
                                        {
                                            mesA = "We have found : \n\n" + nbBach + " batchs of " + perBatch + " CV to generate \n" + "And 1 batch of " + modulonbBach + " CV to generate.\n\n Do you want to process?";

                                            int total = nbBach;
                                            int lj = 0;
                                            //int kj = 1;
                                            string captionC = "CVBASE";
                                            MessageBoxButtons buttonsC = MessageBoxButtons.YesNo;
                                            DialogResult resultC;
                                            // Displays the MessageBox.
                                            resultC = MessageBox.Show(mesA, captionC, buttonsC);

                                            if (resultC == System.Windows.Forms.DialogResult.Yes)
                                            {
                                                for (var xx = 1; xx <= total; xx++)
                                                {
                                                    mesA = "Do you want to generate the batch n° " + xx + "?";
                                                    int kj = 1;

                                                    string captionB = "CVBASE";
                                                    MessageBoxButtons buttonsB = MessageBoxButtons.YesNo;
                                                    DialogResult resultB;
                                                    // Displays the MessageBox.
                                                    resultB = MessageBox.Show(mesA, captionB, buttonsB);

                                                    if (resultB == System.Windows.Forms.DialogResult.Yes)
                                                    {
                                                        if (kj <= perBatch)
                                                        {
                                                            foreach (var x in elem.OrderBy(a => a).ToList())
                                                            {
                                                                if (kj <= perBatch)
                                                                {
                                                                    var isCV = soft.CV_CVBASE.Where(a => a.LastName == x).FirstOrDefault();


                                                                    //GET THE SENDTO MAIL//
                                                                    var sendTo = "";
                                                                    if (!String.IsNullOrEmpty(isCV.Email1))
                                                                        sendTo = isCV.Email1;
                                                                    else
                                                                        sendTo = isCV.Email2;



                                                                    if (!String.IsNullOrEmpty(isCV.Email1) || !String.IsNullOrEmpty(isCV.Email2))
                                                                    {
                                                                        lj++;
                                                                        var cc = "";
                                                                        string bbdy = "";
                                                                        string dsbody = "";
                                                                        string ds = "";
                                                                        if (soft.CV_CCMAIL.Count() != 0)
                                                                        {
                                                                            var isCC = soft.CV_CCMAIL.FirstOrDefault();
                                                                            if (!String.IsNullOrEmpty(isCC.CCMAIL))
                                                                                cc = soft.CV_CCMAIL.FirstOrDefault().CCMAIL;

                                                                            if (!String.IsNullOrEmpty(isCC.MDLMAIL))
                                                                                bbdy = soft.CV_CCMAIL.FirstOrDefault().MDLMAIL;
                                                                            //if (!String.IsNullOrEmpty(isCC.RETMAIL))
                                                                            //    dsbody = soft.CV_CCMAIL.FirstOrDefault().RETMAIL;
                                                                            if (!String.IsNullOrEmpty(isCC.DSPF))
                                                                                ds = soft.CV_CCMAIL.FirstOrDefault().DSPF;
                                                                        }

                                                                        bbdy = bbdy.Replace("NBMANC", limites.ToString());

                                                                        var salutation = "Mrs.";
                                                                        if (isCV.Title == true)
                                                                            salutation = "Mr.";

                                                                        string docusign = "";

                                                                        if (!String.IsNullOrEmpty(ds))
                                                                        {
                                                                            docusign = $"{ds}" +
                                                                               $"&title1={salutation} {isCV.FirstName + " " + isCV.LastName}" +
                                                                               $"&title2={salutation} {isCV.FirstName + " " + isCV.LastName}" +
                                                                               $"&Signer_UserName={isCV.FirstName + " " + isCV.LastName}" +
                                                                               $"&Signer_Email={sendTo}" +
                                                                               $"&month={limites}" +
                                                                               $"&date={dateNow.ToString("dd-MM-yyyy")}";
                                                                            docusign = docusign.Replace(" ", "%20");
                                                                            /*docusign = $"${ds}" + System.Uri.EscapeDataString(
                                                                                $"&title1=${salutation} ${isCV.FirstName + " " + isCV.LastName}" +
                                                                                $"&title2=${salutation} ${isCV.FirstName + " " + isCV.LastName}" +
                                                                                $"&Signer_UserName=${isCV.FirstName + " " + isCV.LastName}" +
                                                                                $"&Signer_Email=${sendTo}" +
                                                                                $"&month=${limites}" +
                                                                                $"&date=${dateNow.ToString("dd-MM-yyyy")}");*/
                                                                            //docusign = $"<a href=\"{docusign}\"> Review and sign the document | DocuSign </a>";
                                                                            //dsbody += "\n\n" + docusign;
                                                                        }
                                                                        //else dsbody = "";

                                                                        bbdy = bbdy.Replace("DSLINK", docusign);
                                                                        //var body = "Dear " + salutation + " " + isCV.FirstName + " " + isCV.LastName + "," + "\n\n" + bbdy;
                                                                        var body = "Dear " + salutation + " " + isCV.FirstName + " " + isCV.LastName + "," + "\n\n" + bbdy + "\n\n" + dsbody;

                                                                        dynamic Notes = null;
                                                                        object db = null;
                                                                        dynamic WorkSpace = null;
                                                                        dynamic UIdoc = null;
                                                                        string userName = null;
                                                                        string MailDbName = null;
                                                                        Notes = Activator.CreateInstance(Type.GetTypeFromProgID("Notes.NotesSession"));

                                                                        userName = Notes.userName;
                                                                        MailDbName = userName.Substring(0, 1) + userName.Substring(userName.Length - ((userName.Length - (userName.IndexOf(" ", 0) + 1)))) + ".nsf";
                                                                        db = Notes.GetDataBase(null, MailDbName);
                                                                        WorkSpace = Activator.CreateInstance(Type.GetTypeFromProgID("Notes.NotesUIWorkspace"));
                                                                        WorkSpace.ComposeDocument("", "", "Memo");
                                                                        UIdoc = WorkSpace.currentdocument;
                                                                        string Recipient = sendTo;
                                                                        string CCD = cc;
                                                                        UIdoc.FieldSetText("EnterSendTo", Recipient);
                                                                        UIdoc.FieldSetText("EnterCopyTo", CCD);
                                                                        string Subject = "Request for CV update";
                                                                        UIdoc.FieldSetText("Subject", Subject);

                                                                        UIdoc.GotoField("Body");
                                                                        UIdoc.INSERTTEXT(body);
                                                                        UIdoc = null;
                                                                        WorkSpace = null;
                                                                        db = null;
                                                                        Notes = null;
                                                                        MessageBox.Show("Message " + lj + " on " + nnb + " in the mailbox ready to go", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                                        if (soft.CV_DOCDATECOMM.Where(a => a.IDCV == isCV.IDCV).Count() != 0)
                                                                        {
                                                                            var isDaocD = soft.CV_DOCDATECOMM.Where(a => a.IDCV == isCV.IDCV).FirstOrDefault();
                                                                            isDaocD.UpdateCV = dateNow.Date;
                                                                            soft.SaveChanges();
                                                                        }
                                                                        else
                                                                        {
                                                                            var newDaocD = new CV_DOCDATECOMM
                                                                            {
                                                                                UpdateCV = dateNow.Date,
                                                                                IDCV = isCV.IDCV
                                                                            };
                                                                            soft.CV_DOCDATECOMM.Add(newDaocD);
                                                                            soft.SaveChanges();
                                                                        }
                                                                        //INSERT HISTORY//
                                                                        var newHUR = new CV_HISTOUR
                                                                        {
                                                                            FirstName = isCV.FirstName,
                                                                            LastName = isCV.LastName,
                                                                            Date = dateNow.Date,
                                                                            Mail = sendTo,
                                                                            IDCV = isCV.IDCV
                                                                        };
                                                                        soft.CV_HISTOUR.Add(newHUR);
                                                                        soft.SaveChanges();

                                                                        if (!String.IsNullOrEmpty(docusign)) SaveMailDocusign(sendTo, isCV, dateNow, docusign);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (!elemOUTMAIL.Contains(x))
                                                                        {
                                                                            elemOUTMAIL.Add(x);
                                                                        }
                                                                    }

                                                                    kj++;
                                                                    elem.Remove(x);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                  
                                                }


                                                ///here
                                                var nameOUT = "";
                                                if (elemOUTMAIL != null)
                                                {
                                                    foreach (var x in elemOUTMAIL.OrderBy(a => a).ToList())
                                                    {
                                                        var iSS = soft.CV_CVBASE.Where(a => a.LastName == x).FirstOrDefault();
                                                        nameOUT += x + " " + iSS.FirstName + "\n";
                                                    }
                                                }
                                                var nameAL = "";
                                                if (elemALREADY != null)
                                                {
                                                    foreach (var x in elemALREADY.OrderBy(a => a).ToList())
                                                    {
                                                        var iSS = soft.CV_CVBASE.Where(a => a.LastName == x).FirstOrDefault();
                                                        var updateMM = "";
                                                        if (soft.CV_DOCDATECOMM.Where(a => a.IDCV == iSS.IDCV).Count() != 0)
                                                        {
                                                            var ii = soft.CV_DOCDATECOMM.Where(a => a.IDCV == iSS.IDCV).FirstOrDefault();
                                                            if (!String.IsNullOrEmpty(ii.UpdateCV.ToString()))
                                                            {
                                                                updateMM = ii.UpdateCV.Value.ToShortDateString();
                                                            }
                                                        }
                                                        nameAL += x + " " + iSS.FirstName + " last request : " + updateMM + "\n";
                                                    }
                                                }
                                                if (!String.IsNullOrEmpty(nameOUT))
                                                {
                                                    MessageBox.Show("We have found " + j + " CV with no e-mail address : \n\n" + nameOUT, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }

                                                if (!String.IsNullOrEmpty(nameAL))
                                                {
                                                    MessageBox.Show("We have found " + m + " CV with a pending request for CV update process : \n\n" + nameAL, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                }
                                                //here
                                            }
                                        }
                                    }
                                }
                            }
                            else
                                MessageBox.Show("We have found 0 CV for the update request", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Initialize the number of e-mails per batch", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Open HCL Notes please");
            }
        }


        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_HistoriUr frm = new Frm_HistoriUr();
            frm.ShowDialog();
        }

        private void nbMailInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Batch frm = new Frm_Batch();
            frm.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            timer1.Stop();
        }

        private void authenticationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Token.getAUTHO() == true && Token.getISA() == true) new Frm_DSParameter().ShowDialog();
        }

        private void modelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Token.getAUTHO() == true && Token.getISA() == true) new Frm_DSModel().ShowDialog();
        }

        private void SaveMailDocusign(string sendTo, CV_CVBASE isCV,DateTime dateNow, string docusign)
        {
            
            DbCVBASE soft = new DbCVBASE();
            var doc = soft.DS_SIGN.Where(x => x.IDCV == isCV.IDCV).FirstOrDefault();
            if (doc != null)
            {
                doc.REQUEST = dateNow.Date;
                soft.SaveChanges();
            }
            else
            {
                var newdoc = new DS_SIGN
                {
                    REQUEST = dateNow.Date,
                    IDCV = isCV.IDCV,
                    LINK = docusign
                };
                soft.DS_SIGN.Add(newdoc);
                soft.SaveChanges();
            }
            
        }

        private void cCMailAddressCVUpdateMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_CC frm = new Frm_CC();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dsParameter.DateAuth != null)
            {
                if(DateTime.Compare(dsParameter.DateAuth,DateTime.Now) < 0) dsParameter.GetAuth();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
