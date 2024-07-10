using CVBASESWISS.Model;
using CVBASESWISS.Properties;
using DocuSign.eSign.Api;
using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DocuSign.eSign.Client.Auth.OAuth.UserInfo;

namespace CVBASESWISS
{
    public partial class Frm_cvadd : Form
    {
       // string name = "";
        List<String> itmName = new List<String>();
        bool updated = new bool();
        public bool fromform = new bool();
        public bool isnew = true;
        bool checkcat = false;
        bool checknote = false;
        public Frm_cvadd()
        {
            InitializeComponent();

            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += tabControl1_DrawItem;

            this.DialogResult = DialogResult.Cancel;
            if (Token.getAUTHO() == true)
            {
                saveToolStripMenuItem1.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
            DbCVBASE soft = new DbCVBASE();
            //LastName//
            itmName.Add("");
            int isco = Token.getisCO();
            var iscoJun = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;

            if(!String.IsNullOrEmpty(iscoJun))
            {
                var idJunSen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == iscoJun).FirstOrDefault().IDJunSenior;

                if (soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior == "ALL")
                {
                    if (soft.CV_CVBASE.Count() != 0)
                    {
                        foreach (var x in soft.CV_CVBASE.Select(a => a.LastName).OrderBy(a => a).ToList())
                        {
                            itmName.Add(x);
                        }
                    }
                }
                else
                {
                    var isForDataSet = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior;
                    foreach (var x in soft.CV_JUNSENIOR.Where(a => a.JunSenior.ToUpper().Contains(isForDataSet.ToUpper())).ToList())
                    {
                        foreach (var y in soft.CV_CVBASE.Where(a => a.IDJunSenior == x.IDJunSenior).Select(a => a.LastName).OrderBy(a => a).ToList())
                        {
                            itmName.Add(y);
                        }
                    }
                }
            }
            comboName.DataSource = itmName;

            //Gender//
            List<String> itmGender = new List<String>();
            itmGender.Add("");
            if (soft.CV_GENDER.Count() != 0)
            {
                foreach (var x in soft.CV_GENDER.Select(a => a.Gender).OrderBy(a => a).ToList())
                {
                    itmGender.Add(x);
                }
            }
            comboGender.DataSource = itmGender;

            //Nationality and Country and comboCountry1 and comboCountry1//
            List<String> itmNat1 = new List<String>(); List<String> itmNat2 = new List<String>(); List<String> itmNat3 = new List<String>(); List<String> itmNat4 = new List<String>();
            itmNat1.Add(""); itmNat2.Add(""); itmNat3.Add(""); itmNat4.Add("");
            if (soft.CV_NATIONS.Count() != 0)
            {
                foreach (var x in soft.CV_NATIONS.Select(a => a.Country).OrderBy(a => a).ToList())
                {
                    itmNat1.Add(x); itmNat2.Add(x); itmNat3.Add(x); itmNat4.Add(x);
                }
            }
            comboNationality.DataSource = itmNat1;
            comboCountry.DataSource = itmNat2;
            comboCountry1.DataSource = itmNat3;
            comboCountry2.DataSource = itmNat4;

            //TOWN//
            List<String> itmTOWN = new List<String>();
            itmTOWN.Add("");
            if (soft.CV_TOWNS.Count() != 0)
            {
                foreach (var x in soft.CV_TOWNS.Select(a => a.TOWN).OrderBy(a => a).ToList())
                {
                    itmTOWN.Add(x);
                }
            }
            comboTOWN.DataSource = itmTOWN;

            //Category and comboPosTarget//
            List<String> itmCat1 = new List<String>(); List<String> itmCat2 = new List<String>();
            itmCat1.Add(""); itmCat2.Add("");
            if (soft.CV_CATEGORY.Count() != 0)
            {
                foreach (var x in soft.CV_CATEGORY.Select(a => a.Category).OrderBy(a => a).ToList())
                {
                    itmCat1.Add(x); itmCat2.Add(x);
                }
            }
            comboCat.DataSource = itmCat1;
            comboPosTarget.DataSource = itmCat2;

            //Pers TPH and comboMainSup1 and comboMainSup2 and comboEmplMet1 and comboEmplMet2 and comboEmplMet3//
            List<String> itmPersTPH1 = new List<String>(); List<String> itmPersTPH2 = new List<String>(); List<String> itmPersTPH3 = new List<String>();
            List<String> itmPersTPH4 = new List<String>(); List<String> itmPersTPH5 = new List<String>(); List<String> itmPersTPH6 = new List<String>();
            itmPersTPH1.Add(""); itmPersTPH2.Add(""); itmPersTPH3.Add(""); itmPersTPH4.Add(""); itmPersTPH5.Add(""); itmPersTPH6.Add("");
            if (soft.CV_EMPLOYEE.Count() != 0)
            {
                foreach (var x in soft.CV_EMPLOYEE.Select(a => a.PersRef).OrderBy(a => a).ToList())
                {
                    itmPersTPH1.Add(x); itmPersTPH2.Add(x); itmPersTPH3.Add(x); itmPersTPH4.Add(x); itmPersTPH5.Add(x); itmPersTPH6.Add(x);
                }
            }
            comboPersTPH.DataSource = itmPersTPH1;
            comboMainSup1.DataSource = itmPersTPH2;
            comboMainSup2.DataSource = itmPersTPH3;
            comboEmplMet1.DataSource = itmPersTPH4;
            comboEmplMet2.DataSource = itmPersTPH5;
            comboEmplMet3.DataSource = itmPersTPH6;

            //JunSenior//
            List<String> itmJS1 = new List<String>(); List<String> itmJS2 = new List<String>(); List<String> itmJS3 = new List<String>();
            itmJS1.Add(""); itmJS2.Add(""); itmJS3.Add("");
            if (soft.CV_JUNSENIOR.Where(a => a.JunSenior != "ALL").Count() != 0)
            {
                foreach (var x in soft.CV_JUNSENIOR.Where(a => a.JunSenior != "ALL").Select(a => a.JunSenior).OrderBy(a => a).ToList())
                {
                    itmJS1.Add(x); itmJS2.Add(x); itmJS3.Add(x);
                }
            }
            comboJunSenior.DataSource = itmJS1;
            comboJunSen1.DataSource = itmJS2;
            comboJunSen2.DataSource = itmJS3;

            //Documents//
            List<String> itmDoc1 = new List<String>();
            List<String> itmDoc2 = new List<String>();
            List<String> itmDoc3 = new List<String>();
            List<String> itmDoc4 = new List<String>();
            List<String> itmDoc5 = new List<String>();
            List<String> itmDoc6 = new List<String>();
            itmDoc1.Add("");
            itmDoc2.Add("");
            itmDoc3.Add("");
            itmDoc4.Add("");
            itmDoc5.Add(""); itmDoc6.Add("");
            if (soft.CV_DOCUMENT.Count() != 0)
            {
                foreach (var x in soft.CV_DOCUMENT.Select(a => a.Docum).OrderBy(a => a).ToList())
                {
                    itmDoc1.Add(x);
                    itmDoc2.Add(x);
                    itmDoc3.Add(x);
                    itmDoc4.Add(x);
                    itmDoc5.Add(x);
                    itmDoc6.Add(x);
                }
            }
            comboDoc1.DataSource = itmDoc1;
            comboDoc2.DataSource = itmDoc2;
            comboDoc3.DataSource = itmDoc3;
            comboDoc4.DataSource = itmDoc4;
            comboDoc5.DataSource = itmDoc5;
            //comboDoc6.DataSource = itmDoc6;

            //comboDoc6.Text = "Data retention authorisation";
            comboDoc6.Text = "Personal Data Retention Authorisation";

            //Diplome//
            List<String> itmDipl1 = new List<String>();
            List<String> itmDipl2 = new List<String>();
            List<String> itmDipl3 = new List<String>();
            itmDipl1.Add("");
            itmDipl2.Add("");
            itmDipl3.Add("");
            if (soft.CV_DIPLOMA.Count() != 0)
            {
                foreach (var x in soft.CV_DIPLOMA.Select(a => a.Diploma).OrderBy(a => a).ToList())
                {
                    itmDipl1.Add(x);
                    itmDipl2.Add(x);
                    itmDipl3.Add(x);
                }
            }
            comboDipl1.DataSource = itmDipl1;
            comboDipl2.DataSource = itmDipl2;
            comboDipl3.DataSource = itmDipl3;

            //Speciality//
            List<String> itmSp1 = new List<String>();
            List<String> itmSp2 = new List<String>();
            List<String> itmSp3 = new List<String>();
            itmSp1.Add("");
            itmSp2.Add("");
            itmSp3.Add("");
            if (soft.CV_SPECIALITY.Count() != 0)
            {
                foreach (var x in soft.CV_SPECIALITY.Select(a => a.Speciality).OrderBy(a => a).ToList())
                {
                    itmSp1.Add(x);
                    itmSp2.Add(x);
                    itmSp3.Add(x);
                }
            }
            comboSpecDipl1.DataSource = itmSp1;
            comboSpecDipl2.DataSource = itmSp2;
            comboSpecDipl3.DataSource = itmSp3;

            //Graduate//
            List<String> itmGra1 = new List<String>(); List<String> itmGra2 = new List<String>(); List<String> itmGra3 = new List<String>();
            itmGra1.Add(""); itmGra2.Add(""); itmGra3.Add("");
            if (soft.CV_GRADUATE.Count() != 0)
            {
                foreach (var x in soft.CV_GRADUATE.Select(a => a.Graduate).OrderBy(a => a).ToList())
                {
                    itmGra1.Add(x);
                    itmGra2.Add(x);
                    itmGra3.Add(x);
                }
            }
            comboPostGrad1.DataSource = itmGra1;
            comboPostGrad2.DataSource = itmGra2;
            comboPostGrad3.DataSource = itmGra3;

            //Language//
            List<String> itmLa1 = new List<String>(); List<String> itmLa2 = new List<String>(); List<String> itmLa3 = new List<String>();
            List<String> itmLa4 = new List<String>(); List<String> itmLa5 = new List<String>(); List<String> itmLa6 = new List<String>();
            itmLa1.Add(""); itmLa2.Add(""); itmLa3.Add(""); itmLa4.Add(""); itmLa5.Add(""); itmLa6.Add("");
            if (soft.CV_LANGUAGE.Count() != 0)
            {
                foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                {
                    itmLa1.Add(x); itmLa2.Add(x); itmLa3.Add(x); itmLa4.Add(x); itmLa5.Add(x); itmLa6.Add(x);
                }
            }
            comboLang1.DataSource = itmLa1;
            comboLang2.DataSource = itmLa2;
            comboLang3.DataSource = itmLa3;
            comboLang4.DataSource = itmLa4;
            comboLangReport1.DataSource = itmLa5;
            comboLangReport2.DataSource = itmLa6;

            //Language LEVEL//
            List<String> itmLal1 = new List<String>(); List<String> itmLal2 = new List<String>(); List<String> itmLal3 = new List<String>(); List<String> itmLal4 = new List<String>();
            List<String> itmLal5 = new List<String>(); List<String> itmLal6 = new List<String>(); List<String> itmLal7 = new List<String>(); List<String> itmLal8 = new List<String>();
            itmLal1.Add(""); itmLal2.Add(""); itmLal3.Add(""); itmLal4.Add(""); itmLal5.Add(""); itmLal6.Add(""); itmLal7.Add(""); itmLal8.Add("");
            if (soft.CV_WRSPLEVEL.Count() != 0)
            {
                foreach (var x in soft.CV_WRSPLEVEL.Select(a => a.WrSp).OrderBy(a => a).ToList())
                {
                    itmLal1.Add(x); itmLal2.Add(x); itmLal3.Add(x); itmLal4.Add(x); itmLal5.Add(x); itmLal6.Add(x); itmLal7.Add(x); itmLal8.Add(x);
                }
            }
            comboLangW1.DataSource = itmLal1;
            comboLangS1.DataSource = itmLal2;
            comboLangW2.DataSource = itmLal3;
            comboLangS2.DataSource = itmLal4;
            comboLangW3.DataSource = itmLal5;
            comboLangS3.DataSource = itmLal6;
            comboLangW4.DataSource = itmLal7;
            comboLangS4.DataSource = itmLal8;

            //TECH FIELD//
            List<String> itmTF1 = new List<String>(); List<String> itmTF2 = new List<String>(); List<String> itmTF3 = new List<String>();
            List<String> itmTF4 = new List<String>(); List<String> itmTF5 = new List<String>();
            itmTF1.Add(""); itmTF2.Add(""); itmTF3.Add(""); itmTF4.Add(""); itmTF5.Add("");
            if (soft.CV_TECHNICFIELD.Count() != 0)
            {
                foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                {
                    itmTF1.Add(x); itmTF2.Add(x); itmTF3.Add(x); itmTF4.Add(x); itmTF5.Add(x);
                }
            }
            comboTechField1.DataSource = itmTF1;
            comboTechField2.DataSource = itmTF2;
            comboTechField3.DataSource = itmTF3;
            comboDomExp1.DataSource = itmTF4;
            comboDomExp2.DataSource = itmTF5;

            //REGION//
            List<String> itmRe1 = new List<String>(); List<String> itmRe2 = new List<String>(); List<String> itmRe3 = new List<String>();
            itmRe1.Add(""); itmRe2.Add(""); itmRe3.Add("");
            if (soft.CV_REGION.Count() != 0)
            {
                foreach (var x in soft.CV_REGION.Select(a => a.Region).OrderBy(a => a).ToList())
                {
                    itmRe1.Add(x); itmRe2.Add(x); itmRe3.Add(x);
                }
            }
            comboRegion1.DataSource = itmRe1;
            comboRegion2.DataSource = itmRe2;
            comboRegion3.DataSource = itmRe3;

            //UNIT//
            List<String> itmUnt1 = new List<String>(); List<String> itmUnt2 = new List<String>();
            itmUnt1.Add(""); itmUnt2.Add("");
            if (soft.CV_UNIT.Count() != 0)
            {
                foreach (var x in soft.CV_UNIT.Select(a => a.Unit).OrderBy(a => a).ToList())
                {
                    itmUnt1.Add(x); itmUnt2.Add(x);
                }
            }
            comboSCHI1.DataSource = itmUnt1;
            comboSCHI2.DataSource = itmUnt2;

            //ROLE//
            List<String> itmRol1 = new List<String>(); List<String> itmRol2 = new List<String>();
            itmRol1.Add(""); itmRol2.Add("");
            if (soft.CV_ROLE.Count() != 0)
            {
                foreach (var x in soft.CV_ROLE.Select(a => a.Role).OrderBy(a => a).ToList())
                {
                    itmRol1.Add(x); itmRol2.Add(x);
                }
            }
            comboRole1.DataSource = itmRol1;
            comboRole2.DataSource = itmRol2;

            //CLIENT//
            List<String> itmClt1 = new List<String>(); List<String> itmClt2 = new List<String>();
            itmClt1.Add(""); itmClt2.Add("");
            if (soft.CV_CLIENT.Count() != 0)
            {
                foreach (var x in soft.CV_CLIENT.Select(a => a.Client).OrderBy(a => a).ToList())
                {
                    itmClt1.Add(x); itmClt2.Add(x);
                }
            }
            comboClt1.DataSource = itmClt1;
            comboClt2.DataSource = itmClt2;

            //Global appreciation//
            List<String> itmGlA = new List<String>();
            itmGlA.Add("");
            if (soft.CV_GAPPREC.Count() != 0)
            {
                foreach (var x in soft.CV_GAPPREC.Select(a => a.GApprec).OrderBy(a => a).ToList())
                {
                    itmGlA.Add(x);
                }
            }
            comboGlobAppr.DataSource = itmGlA;

            //eProfile//
            List<String> itmep1 = new List<String>();
            List<String> itmep2 = new List<String>();
            List<String> itmep3 = new List<String>();
            itmep1.Add("");
            itmep2.Add("");
            itmep3.Add("");
            if (soft.CV_EPROFIL.Count() != 0)
            {
                foreach (var x in soft.CV_EPROFIL.Select(a => a.EProfile).OrderBy(a => a).ToList())
                {
                    itmep1.Add(x);
                    itmep2.Add(x);
                    itmep3.Add(x);
                }
            }
            ep1.DataSource = itmep1;
            ep2.DataSource = itmep2;
            ep3.DataSource = itmep3;

            //Online chat//
            List<String> itmol1 = new List<String>();
            List<String> itmol2 = new List<String>();
            List<String> itmol3 = new List<String>();
            itmol1.Add("");
            itmol2.Add("");
            itmol3.Add("");
            if (soft.CV_ONCHATPLAT.Count() != 0)
            {
                foreach (var x in soft.CV_ONCHATPLAT.Select(a => a.OnlineChat).OrderBy(a => a).ToList())
                {
                    itmol1.Add(x);
                    itmol2.Add(x);
                    itmol3.Add(x);
                }
            }
            oc1.DataSource = itmol1;
            oc2.DataSource = itmol2;
            oc3.DataSource = itmol3;

            //TEST//
            /*List<String> TEST = new List<String>();
            TEST.Add("");
            if (soft.CV_TEST.Count() != 0)
            {
                foreach (var x in soft.CV_TEST.Select(a => a.Test).OrderBy(a => a).ToList())
                {
                    TEST.Add(x);
                }
            }
            comboTestDone.DataSource = TEST;*/

            //PLACE//
            List<String> itmepa1 = new List<String>();
            List<String> itmepa2 = new List<String>();
            List<String> itmepa3 = new List<String>();
            List<String> itmepg1 = new List<String>();
            List<String> itmepg2 = new List<String>();
            List<String> itmepg3 = new List<String>();
            itmepa1.Add("");
            itmepa2.Add("");
            itmepa3.Add("");
            itmepg1.Add("");
            itmepg2.Add("");
            itmepg3.Add("");
            
                
            if (soft.CV_PLACE.Count() != 0)
            {
                foreach (var x in soft.CV_PLACE.Select(a => a.Place).OrderBy(a => a).ToList())
                {
                    itmepa1.Add(x);
                    itmepa2.Add(x);
                    itmepa3.Add(x);
                    itmepg1.Add(x);
                    itmepg2.Add(x);
                    itmepg3.Add(x);
                }
            }
            comboDiplP1.DataSource = itmepa1;
            comboDiplP2.DataSource = itmepa2;
            comboDiplP3.DataSource = itmepa3;
            comboPostGradP1.DataSource = itmepg1;
            comboPostGradP2.DataSource = itmepg2;
            comboPostGradP3.DataSource = itmepg3;

            comboName.Focus();
            comboName.Text = null;
            textDateCreate.Text = DateTime.Now.ToShortDateString();

            ToolTip tool = new ToolTip();

            tool.SetToolTip(checkNoteGlobal, "When on, browse according to the ranking of the last search");
            tool.SetToolTip(checkCat, "When on, browse according to alphabetic order in the same category");
            tool.SetToolTip(textPrenom, "Best to enter is small letters");
            tool.SetToolTip(textdateCV, "Date found on the CV. It is supposed to be the age of the CV");
            tool.SetToolTip(textMobilPhone, "++ before number to avoid numeric format");
            tool.SetToolTip(textMobilPhone2, "++ before number to avoid numeric format");
            tool.SetToolTip(textLandlinePhone, "++ before number to avoid numeric format");
            tool.SetToolTip(textdateBirthDay, "Enter Date format dd/mm/yyyy");
            tool.SetToolTip(textdateInterview, "Enter Date format dd/mm/yyyy");
         //   tool.SetToolTip(textdateLastRequest, "Enter Date format dd/mm/yyyy");
            tool.SetToolTip(textDateCreate, "Date creation of the CV");
            tool.SetToolTip(textdateSDWork1, "Enter Date format dd/mm/yyyy");
            tool.SetToolTip(textdateSDWork2, "Enter Date format dd/mm/yyyy");
            tool.SetToolTip(textVisitSPMUComm, "Enter Date format dd/mm/yyyy");

            InitialCVNEW();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // This event is called once for each tab button in your tab control

            // First paint the background with a color based on the current tab

            // e.Index is the index of the tab in the TabPages collection.
            switch (e.Index)
            {
                case 0:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, 138, 178)), e.Bounds);
                    break;
                case 1:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(191, 50, 39)), e.Bounds);
                    break;
                case 2:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(235, 215, 163)), e.Bounds);
                    break;
                case 3:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(82, 107, 98)), e.Bounds);
                    break;
                case 4:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(178, 198, 84)), e.Bounds);
                    break;
                case 5:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(198, 150, 150)), e.Bounds);
                    break;
                case 6:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(142, 138, 130)), e.Bounds);
                    break;
                default:
                    break;
            }

            // Then draw the current tab button text 
            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-2, -2);
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.HighlightText, paddedBounds);
        }

        private void LaunchWeblink(string url)
        {
            Process.Start(url);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in textPrenom.Text)
            { textPrenom.Text = ti.ToTitleCase(textPrenom.Text.ToLower()); }

            textPrenom.Select(textPrenom.Text.Length, 0);
        }

        private void comboName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = e.KeyChar.ToString().ToUpper();
            char[] ch = str.ToCharArray();
            e.KeyChar = ch[0];

            char entrer = e.KeyChar;
       /*     if (Char.IsDigit(entrer))
            {
                ValidateCV();
            }*/
        }

        private void comboShortListed_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*e.Handled = true;*/
        }

        private void textNoteGlobal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBonusDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 && entrer != 48 && entrer != 49 && entrer != 50 && entrer != 51)
            {
                e.Handled = true;
            }
        }

        private void textScoreDipGen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textScoreDipl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textScoreDipl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox36_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox41_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox43_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox39_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox45_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox49_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox47_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textAgeCalc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textGivenAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32)
            {
                e.Handled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Token.getAUTHO() == false)
                MessageBox.Show("Your current status does not authorise the action" + "\n\n" + "Please contact Admin", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                previousToolStripMenuItem.Enabled = false;
                nextToolStripMenuItem.Enabled = false;
                isnew = true;
                updated = false;
                comboName.Focus();
                comboName.Text = null;
                checkNoteGlobal.Checked = false;
                InitialCVNEW();
             //   EnableFalseCV();
            }
        }

        public void InitialCVNEW()
        {
          
            textSkype.Text = "";

            //Note autom//
            textNoteGlobal.Text = "0";
            textBonusDoc.Text = "0";
            textScoreDipGen.Text = "0";
            textTFScore.Text = "0";
            textRScore.Text = "0";

            textCRScore1.Text = "0";
            textCRScore2.Text = "0";
            textCRScore3.Text = "0";
            textCRScore4.Text = "0";

            textDailyFees.Text = "0.00";
            textScoreDipl1.Text = "0";
            textScoreDipl2.Text = "0";
            textScoreDipl3.Text = "0";

            textTFYears1.Text = "0";
            textTFYears2.Text = "0";
            textTFYears3.Text = "0";

            textRYears1.Text = "0";
            textRYears2.Text = "0";
            textRYears3.Text = "0";

            textCRYears1.Text = "0";
            textCRYears2.Text = "0";
            textCRYears3.Text = "0";
            textCRYears4.Text = "0";
            textCRYears5.Text = "0";

            textDurWeek1.Text = "0";
            textDurWeek2.Text = "0";

            textDailyFeePaid1.Text = "0.00";
            textDailyFeePaid2.Text = "0.00";

            labelNAMEOFPERS.Text = null;
            labelCVALIVSLEEP.Text = null;

            //textDateCreate.Text = null;
            checkWEB.Checked = false;

            checkSleep.Checked = false;
            textdateCV.Text = null;
            textPrenom.Text = null;

            //checkNoteGlobal.Checked = false;

            comboGender.Text = null;
            textdateBirthDay.Text = null;
            textAdress1.Text = null;
            textZipCode.Text = null;

            comboNationality.Text = null;
            textAgeCalc.Text = null;
            textAdress2.Text = null;
            comboTOWN.Text = null;

            comboCat.Text = null;
       //     checkCat.Checked = false;
            textGivenAge.Text = null;

            comboCountry.Text = null;

            textMobilPhone.Text = null;
            textMail1.Text = null;
            comboPersTPH.Text = null;

            textLandlinePhone.Text = null;
            textMail2.Text = null;

            textdateInterview.Text = null;
            comboShortListed.Text = null;
            comboJunSenior.Text = null;

            textComCV.Text = null;
         //   checkAutoSave.Checked = false;

            comboDoc1.Text = null;
            comboDoc2.Text = null;
            comboDoc3.Text = null;
            comboDoc4.Text = null;
            comboDoc5.Text = null;
            comboDoc6.Text = "Data retention authorisation";
            //comboDoc6.Text = null;
            textDocLink1.Text = null;
            textDocLink2.Text = null;
            textDocLink3.Text = null;
            textDocLink4.Text = null;
            textDocLink5.Text = null;
            textDocLink6.Text = null;
            textdateLastRequest.Text = null;

            textComBonus.Text = null;

            comboDipl1.Text = null;
            comboDipl2.Text = null;
            comboDipl3.Text = null;

            comboSpecDipl1.Text = null;
            comboSpecDipl2.Text = null;
            comboSpecDipl3.Text = null;

            comboDiplP1.Text = null;
            comboDiplP2.Text = null;
            comboDiplP3.Text = null;

            comboPostGrad1.Text = null;
            comboPostGrad2.Text = null;
            comboPostGrad3.Text = null;

            comboPostGradP1.Text = null;
            comboPostGradP2.Text = null;
            comboPostGradP3.Text = null;

            comboLang1.Text = null;
            comboLangW1.Text = null;
            comboLangS1.Text = null;
            comboLang2.Text = null;
            comboLangW2.Text = null;
            comboLangS2.Text = null;
            comboLang3.Text = null;
            comboLangW3.Text = null;
            comboLangS3.Text = null;
            comboLang4.Text = null;
            comboLangW4.Text = null;
            comboLangS4.Text = null;

            comboTechField1.Text = null;
            comboTechField2.Text = null;
            comboTechField3.Text = null;

            comboRegion1.Text = null;
            comboRegion2.Text = null;
            comboRegion3.Text = null;

            label78.Text = "No criteria defined in the tuning page";
            label75.Text = "No criteria defined in the tuning page";
            label73.Text = "No criteria defined in the tuning page";
            label79.Text = "No criteria defined in the tuning page";
            label119.Text = "No criteria defined in the tuning page";

            //textCRYears1.Enabled = false;
            //textCRYears2.Enabled = false;
            //textCRYears3.Enabled = false;
            //textCRYears4.Enabled = false;
            //textCRYears5.Enabled = false;

            textINTLExpComm.Text = null;

            textdateSDWork1.Text = null;
            comboSCHI1.Text = null;
            comboRole1.Text = null;
            comboJunSen1.Text = null;
            comboMainSup1.Text = null;
            textAppr1.Text = null;
            comboClt1.Text = null;
            comboDomExp1.Text = null;
            comboCountry1.Text = null;
            comboLangReport1.Text = null;
            comboLFA1.Text = null;
            textLink1.Text = null;

            textdateSDWork2.Text = null;
            comboSCHI2.Text = null;
            comboRole2.Text = null;
            comboJunSen2.Text = null;
            comboMainSup2.Text = null;
            textAppr2.Text = null;
            comboClt2.Text = null;
            comboDomExp2.Text = null;
            comboCountry2.Text = null;
            comboLangReport2.Text = null;
            comboLFA2.Text = null;
            textLink2.Text = null;

            textExpSWISSComm.Text = null;

            textdateVisitSPMU.Text = null;
            comboPosTarget.Text = null;
            comboEmplMet1.Text = null;
            comboTestDone.Text = "0";
            comboEmplMet2.Text = null;
            comboGlobAppr.Text = null;
            comboEmplMet3.Text = null;
            textVisitSPMUComm.Text = null;

            textSleepComment.Text = null;
            comboTitle.Text = null;
            textAdress3.Text = null;
            textMobilPhone2.Text = null;

            textWhy.Text = null;

            textDiplY1.Text = "";
            textDiplY2.Text = "";
            textDiplY3.Text = "";

            textPostGradY1.Text = "";
            textPostGradY2.Text = "";
            textPostGradY3.Text = "";

            ep1.Text = null;
            ep2.Text = null;
            ep3.Text = null;

            epl1.Text = null;
            epl2.Text = null;
            epl3.Text = null;

            eplw1.Text = null;
            eplw2.Text = null;
            eplw3.Text = null;

            oc1.Text = null;
            oc2.Text = null;
            oc3.Text = null;

            ocl1.Text = null;
            ocl2.Text = null;
            ocl3.Text = null;

            ocla1.Text = null;
            ocla2.Text = null;
            ocla3.Text = null;
        }

        public void EnableTrueCV()
        {
            textPrenom.Enabled = true;
            comboTitle.Enabled = true;
            tabControl1.Enabled = true;
            textSkype.Enabled = true;

            labelNAMEOFPERS.Enabled = true;
            labelCVALIVSLEEP.Enabled = true;

            checkSleep.Enabled = true;
            dateCV.Enabled = true;
            textdateCV.Enabled = true;
            textPrenom.Enabled = true;

            textNoteGlobal.Enabled = true;
            checkNoteGlobal.Enabled = true;

            comboGender.Enabled = true;
            dateBirthDay.Enabled = true;
            textdateBirthDay.Enabled = true;
            textAdress1.Enabled = true;
            textZipCode.Enabled = true;

            comboNationality.Enabled = true;
            textAdress2.Enabled = true;
            comboTOWN.Enabled = true;

            comboCat.Enabled = true;
            checkCat.Enabled = true;
            textGivenAge.Enabled = true;
            comboCountry.Enabled = true;

            textMobilPhone.Enabled = true;
            textMail1.Enabled = true;
            comboPersTPH.Enabled = true;

            textLandlinePhone.Enabled = true;
            textMail2.Enabled = true;

            textDailyFees.Enabled = true;
            dateInterview.Enabled = true;
            textdateInterview.Enabled = true;
            comboShortListed.Enabled = true;
            comboJunSenior.Enabled = true;

            textComCV.Enabled = true;
        //    checkAutoSave.Enabled = true;

            comboTitle.Enabled = true;
            textAdress3.Enabled = true;
            textMobilPhone2.Enabled = true;
        }

        public void EnableFalseCV()
        {
            tabControl1.Enabled = false;
            textSkype.Enabled = false;
            textPrenom.Enabled = false;
            comboTitle.Enabled = false;
            labelNAMEOFPERS.Enabled = false;
            labelCVALIVSLEEP.Enabled = false;

            checkSleep.Enabled = false;
            dateCV.Enabled = false;
            textdateCV.Enabled = false;
            textPrenom.Text = null;
            textPrenom.Enabled = false;
           
            textNoteGlobal.Enabled = false;
            checkNoteGlobal.Enabled = false;

            comboGender.Enabled = false;
            dateBirthDay.Enabled = false;
            textdateBirthDay.Enabled = false;
            textAdress1.Enabled = false;
            textZipCode.Enabled = false;

            comboNationality.Enabled = false;
            textAdress2.Enabled = false;
            comboTOWN.Enabled = false;

            comboCat.Enabled = false;
            checkCat.Enabled = false;
            textGivenAge.Enabled = false;
            comboCountry.Enabled = false;

            textMobilPhone.Enabled = false;
            textMail1.Enabled = false;
            comboPersTPH.Enabled = false;

            textLandlinePhone.Enabled = false;
            textMail2.Enabled = false;

            textDailyFees.Enabled = false;
            dateInterview.Enabled = false;
            textdateInterview.Enabled = false;
            comboShortListed.Enabled = false;
            comboJunSenior.Enabled = false;

            textComCV.Enabled = false;
          //  checkAutoSave.Enabled = false;

            comboTitle.Enabled = false;
            textAdress3.Enabled = false;
            textMobilPhone2.Enabled = false;
        //    AllValue();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Token.getAUTHO() == false)
                    MessageBox.Show("Your current status does not authorise the deletion of CV" + "\n\n" + "Please contact Admin", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (comboName.Text == "")
                        MessageBox.Show("Select the CV to delete", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        string message = "You are going to permanently delete the CV of : " + "\n" + textPrenom.Text + " " + comboName.Text;
                        string caption = "CVBASE";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.
                        result = MessageBox.Show(message, caption, buttons);

                        DbCVBASE soft = new DbCVBASE();

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            //Function DELETE CV//
                            if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text && a.FirstName == textPrenom.Text).Count() != 0)
                            {
                                var cvForDelete = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text && a.FirstName == textPrenom.Text).FirstOrDefault();

                                //Function delete others//

                                //DOC//
                                if (soft.CV_DOC.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_DOC.Where(a => a.IDCV == cvForDelete.IDCV).ToList())
                                    {
                                        //var docForDelete = soft.CV_DOC.Where(a => a.IDCV == x.IDCV).FirstOrDefault();
                                        soft.CV_DOC.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //DOCDATECOM//
                                if (soft.CV_DOCDATECOMM.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_DOCDATECOMM.Where(a => a.IDCV == cvForDelete.IDCV).ToList())
                                    {
                                        soft.CV_DOCDATECOMM.Remove(x);
                                        soft.SaveChanges();
                                    }

                                }

                                //EDUC//
                                if (soft.CV_EDUC.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_EDUC.Where(a => a.IDCV == cvForDelete.IDCV).ToList())
                                    {
                                        soft.CV_EDUC.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //GRAD//
                                if (soft.CV_GRAD.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_GRAD.Where(a => a.IDCV == cvForDelete.IDCV).ToList())
                                    {
                                        soft.CV_GRAD.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //LANGUAGE//
                                if (soft.CV_WRSP.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_WRSP.Where(a => a.IDCV == cvForDelete.IDCV).ToList())
                                    {
                                        soft.CV_WRSP.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //INTLEXPTECH//
                                if (soft.CV_INTLEXPTECH.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_INTLEXPTECH.Where(a => a.IDCV == cvForDelete.IDCV).ToList())
                                    {
                                        soft.CV_INTLEXPTECH.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //INTLREGEXP//
                                if (soft.CV_INTLREGEXP.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_INTLREGEXP.Where(a => a.IDCV == cvForDelete.IDCV).ToList())
                                    {
                                        soft.CV_INTLREGEXP.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //INTLCOMMENTS//
                                if (soft.CV_INTLCOMMENT.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_INTLCOMMENT.Where(a => a.IDCV == cvForDelete.IDCV).ToList())
                                    {
                                        soft.CV_INTLCOMMENT.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //NOTECRITERIA//
                                if (soft.CV_NOTECRITERIA.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_NOTECRITERIA.Where(a => a.IDCV == cvForDelete.IDCV).ToList())
                                    {
                                        soft.CV_NOTECRITERIA.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //EXPSWTPH//
                                if (soft.CV_EXPSWTPH.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_EXPSWTPH.Where(a => a.IDCV == cvForDelete.IDCV).ToList())
                                    {
                                        soft.CV_EXPSWTPH.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //EXPCOMMENT//
                                if (soft.CV_EXPCOMMENT.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    var ExpForDelete = soft.CV_EXPCOMMENT.Where(a => a.IDCV == cvForDelete.IDCV).FirstOrDefault();
                                    soft.CV_EXPCOMMENT.Remove(ExpForDelete);
                                    soft.SaveChanges();
                                }

                                //VISITPMU//
                                if (soft.CV_VISITSPMU.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    var VisitForDelete = soft.CV_VISITSPMU.Where(a => a.IDCV == cvForDelete.IDCV).FirstOrDefault();
                                    soft.CV_VISITSPMU.Remove(VisitForDelete);
                                    soft.SaveChanges();
                                }

                                //Eprofil//
                                if (soft.CV_EPRO.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    var epForDelete = soft.CV_EPRO.Where(a => a.IDCV == cvForDelete.IDCV).FirstOrDefault();
                                    soft.CV_EPRO.Remove(epForDelete);
                                    soft.SaveChanges();
                                }

                                //Eprofil Web link//
                                if (soft.CV_EPROWL.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    var epwForDelete = soft.CV_EPROWL.Where(a => a.IDCV == cvForDelete.IDCV).FirstOrDefault();
                                    soft.CV_EPROWL.Remove(epwForDelete);
                                    soft.SaveChanges();
                                }

                                //ON chat//
                                if (soft.CV_ONCHAT.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    var onchatForDelete = soft.CV_ONCHAT.Where(a => a.IDCV == cvForDelete.IDCV).FirstOrDefault();
                                    soft.CV_ONCHAT.Remove(onchatForDelete);
                                    soft.SaveChanges();
                                }

                                //ON chat avatar//
                                if (soft.CV_ONCHATAVA.Where(a => a.IDCV == cvForDelete.IDCV).Count() != 0)
                                {
                                    var onchatavaForDelete = soft.CV_ONCHATAVA.Where(a => a.IDCV == cvForDelete.IDCV).FirstOrDefault();
                                    soft.CV_ONCHATAVA.Remove(onchatavaForDelete);
                                    soft.SaveChanges();
                                }

                                //Function delete CV//
                                soft.CV_CVBASE.Remove(cvForDelete);
                                soft.SaveChanges();
                            }


                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                            //LastName//
                            List<String> itmName = new List<String>();
                        itmName.Add("");
                        int isco = Token.getisCO();
                        var iscoJun = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;
                        var idJunSen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == iscoJun).FirstOrDefault().IDJunSenior;

                        if (soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior == "ALL")
                        {
                            if (soft.CV_CVBASE.Count() != 0)
                            {
                                foreach (var x in soft.CV_CVBASE.Select(a => a.LastName).OrderBy(a => a).ToList())
                                {
                                    itmName.Add(x);
                                }
                            }
                            comboName.DataSource = itmName;
                            comboName.SelectedItem = "";
                        }
                        else
                        {
                            var isForDataSet = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior;
                            foreach (var x in soft.CV_JUNSENIOR.Where(a => a.JunSenior.ToUpper().Contains(isForDataSet.ToUpper())).ToList())
                            {
                                foreach (var y in soft.CV_CVBASE.Where(a => a.IDJunSenior == x.IDJunSenior).Select(a => a.LastName).OrderBy(a => a).ToList())
                                {
                                    itmName.Add(y);
                                }
                            }
                            comboName.DataSource = itmName;
                            comboName.SelectedItem = "";

                            if(!comboJunSenior.Text.ToUpper().Contains(isForDataSet.ToUpper()))
                            {
                                comboName.Focus();
                                comboName.Text = null;
                                checkNoteGlobal.Checked = false;
                                InitialCVNEW();
                                comboName.SelectedItem = "";
                            }
                        }
                            comboName.Focus();
                            comboName.Text = null;
                            InitialCVNEW();

                            EnableFalseCV();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dateBirthDay_Validated(object sender, EventArgs e)
        {
            var dtNo = DateTime.Now;

            var years = (dtNo.Year - dateBirthDay.Value.Year - (DateTime.Now.Month < dateBirthDay.Value.Month ? 1 : (DateTime.Now.Month == dateBirthDay.Value.Month && DateTime.Now.Day < dateBirthDay.Value.Day) ? 1 : 0));

            textAgeCalc.Text = years.ToString();


            textGivenAge.Enabled = false;
            textGivenAge.Text = "0";
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(textdateBirthDay.Text))
                    {
                        if (!String.IsNullOrEmpty(comboName.Text))
                        {
                            if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                            {
                                var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                                DateTime birth = dateBirthDay.Value.Date;

                                isForModif.DateCV = birth;

                                soft.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboName_Validated(object sender, EventArgs e)
        {
        
           DbCVBASE soft = new DbCVBASE();
           if (!String.IsNullOrEmpty(comboName.Text))
            {
                if (!itmName.Contains(comboName.Text) && soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                {
                    int isco = Token.getisCO();
                    var elem = "";
                    if (soft.CV_DATASET.Where(a => a.ID_USERS == isco).Count() != 0)
                    {
                        var isColab = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;
                        if (!String.IsNullOrEmpty(isColab))
                            elem = "The CV exist but you are connected to the " + isColab + " Data set";
                        else
                            elem = "The CV exist but data set undefined";
                    }

                    MessageBox.Show(elem, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboName.Text == Current)
                {
               //     var elem = "The CV is already open";
              //      MessageBox.Show(elem, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (testLoad)
                {
                    //InitialCVNEW();
                 //   if(!isnew)
                   ValidateCV();
                  
                }
                  
            }
        }

        public void ValidateCV()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (!String.IsNullOrEmpty(comboName.Text)&&(comboName.Text != Current))
                {
                  //  textPrenom.Focus();

                    if ((soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0) )
                    {
                        //Affichage détails//

                        DetailsCV(comboName.Text);
                    }
                
                    else
                    {
                        if (Token.getAUTHO() == true)
                        {
                            string caption = "CVBASE";
                            string message = "";
                            checkupdate();
                            MessageBoxButtons buttons = new MessageBoxButtons();
                            DialogResult result;
                            if (isnew == true && updated == false)
                            {
                                message = "Creation of a new CV?";
                                buttons = MessageBoxButtons.YesNo;
                                result = MessageBox.Show(message, caption, buttons);
                                if (result == System.Windows.Forms.DialogResult.Yes)
                                {
                                    previousToolStripMenuItem.Enabled = false;
                                    nextToolStripMenuItem.Enabled = false;
                                    InitialCVNEW();
                                    EnableTrueCV();
                                    //  textPrenom.Focus();
                                    Current = comboName.Text;
                                    textDateCreate.Text = DateTime.Now.Date.ToShortDateString();
                                    updated = false;
                                    isnew = true;
                                    textPrenom.Focus();
                                    AllValue();
                                }
                                else
                                {
                                    comboName.Text = Current;
                                }
                            }
                            else
                            {
                                message = "Creation of a new CV \n\n Do you want to empty all fields?";
                                buttons = MessageBoxButtons.YesNoCancel;

                                updated = false;
                                isnew = true;
                                // Displays the MessageBox.
                                result = MessageBox.Show(message, caption, buttons);

                                if (result == System.Windows.Forms.DialogResult.No)
                                {


                                    Current = comboName.Text;
                                    textDateCreate.Text = DateTime.Now.Date.ToShortDateString();
                                    labelNAMEOFPERS.Text = "";
                                    textPrenom.Focus();
                                    AllValue();


                                }
                                else if (result == System.Windows.Forms.DialogResult.Yes)
                                {

                                    InitialCVNEW();
                                    EnableTrueCV();
                                    Current = comboName.Text;
                                    textPrenom.Focus();
                                    textDateCreate.Text = DateTime.Now.Date.ToShortDateString();
                                    AllValue();


                                }
                                else
                                {
                                    comboName.Text = Current;
                                    textPrenom.Focus();
                                }
                            }
                        }
                        else
                        {
                            comboName.Text = Current;
                            MessageBox.Show("Your current status does not authorise the action" + "\n\n" + "Please contact Admin", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                   }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        string Current = "`*";


        public void AllValue()
        {
            updated = false;
            AllTextBox = new Dictionary<string, string>();
            AllComboBox = new Dictionary<string, string>();
            AllCheckBox = new Dictionary<string, CheckState>();

            AllTextBox1 = new Dictionary<string, string>();
            AllComboBox1 = new Dictionary<string, string>();

            var tbox = this.Controls.OfType<TextBox>().ToList();
            var combol = this.Controls.OfType<ComboBox>().ToList();
            var check = this.Controls.OfType<CheckBox>().ToList();
            foreach (TabPage t in tabControl1.TabPages)
            {
                foreach (Control c in t.Controls)
                {
                    if (c is GroupBox)
                    {
                        foreach (Control cc in c.Controls)
                        {
                            if (cc is TextBox)
                            {
                                if (!AllTextBox1.ContainsKey(cc.Name)) AllTextBox1.Add(cc.Name, cc.Text);
                            }
                            if (cc is ComboBox)
                            {
                                if (!AllComboBox1.ContainsKey(cc.Name)) AllComboBox1.Add(cc.Name, cc.Text);
                            }
                        }
                    }
                }
            }   
            foreach (var item in tbox)
            {
                if (!AllTextBox.ContainsKey(item.Name)) AllTextBox.Add(item.Name, item.Text);
            }
            AllTextBox.Add(textExpSWISSComm.Name, textExpSWISSComm.Text);

            foreach (var item in combol)
            {
                if (!AllComboBox.ContainsKey(item.Name)) AllComboBox.Add(item.Name, item.Text);
            }
            foreach (var item in check)
            {
                if (!AllCheckBox.ContainsKey(item.Name)) AllCheckBox.Add(item.Name, item.CheckState);
            }
        }
        public void DetailsCV(string LastName)
        {

            try
            {
                
                isnew = false;
                DbCVBASE soft = new DbCVBASE();

                InitialCVNEW();
                EnableTrueCV();
                if (checknote == true)
                    checkNoteGlobal.Checked = true;
                if (checkcat == true)                   
                    checkCat.Checked = true;                   
                var FirstCV = soft.CV_CVBASE.Where(a => a.LastName == LastName).FirstOrDefault();
                labelNAMEOFPERS.Text = FirstCV.LastName + " " + FirstCV.FirstName;
                Current = FirstCV.LastName;
                comboName.TabStop = false;
                labelCVALIVSLEEP.Text = "ALIVE";
                labelCVALIVSLEEP.ForeColor = System.Drawing.Color.LimeGreen;
                checkSleep.Checked = false;
                if (FirstCV.Sleep == true)
                {
                    labelCVALIVSLEEP.Text = "SLEEPING";
                    labelCVALIVSLEEP.ForeColor = System.Drawing.Color.Tomato;
                    checkSleep.Checked = true;
                }
                checkWEB.Checked = false;
                if (FirstCV.WEB == true)
                    checkWEB.Checked = true;

                textdateCV.Text = null;
                if (FirstCV.DateCV != null)
                    textdateCV.Text = FirstCV.DateCV.Value.ToShortDateString();

                textDateCreate.Text = null;
                if (FirstCV.DateSave != null)
                    textDateCreate.Text = FirstCV.DateSave.Value.ToShortDateString();

                comboName.Text = FirstCV.LastName;
                textPrenom.Text = FirstCV.FirstName;

                textSkype.Text = FirstCV.Skype;

                comboGender.Text = null;
                if (FirstCV.IDGender != null && FirstCV.IDGender != 0 && soft.CV_GENDER.Where(a => a.IDGender == FirstCV.IDGender).Count() != 0)
                {
                    var gend = soft.CV_GENDER.Where(a => a.IDGender == FirstCV.IDGender).FirstOrDefault();
                    comboGender.Text = gend.Gender;
                }
                textdateBirthDay.Text = null;
                textAgeCalc.Text = null;
                if (FirstCV.BirthDay != null)
                {
                    var dtNo = DateTime.Now;
                    var years = (dtNo.Year - FirstCV.BirthDay.Value.Year - (DateTime.Now.Month < FirstCV.BirthDay.Value.Month ? 1 : (DateTime.Now.Month == FirstCV.BirthDay.Value.Month && DateTime.Now.Day < FirstCV.BirthDay.Value.Day) ? 1 : 0));
                    textAgeCalc.Text = years.ToString();
                    textdateBirthDay.Text = FirstCV.BirthDay.Value.ToShortDateString();
                    textGivenAge.Enabled = false;
                }

                textAdress1.Text = FirstCV.Adress1;
                textZipCode.Text = FirstCV.ZipCode;

                comboNationality.Text = null;
                if (FirstCV.IDNationality != null && FirstCV.IDNationality != 0 && soft.CV_NATIONS.Where(a => a.IDCountry == FirstCV.IDNationality).Count() != 0)
                {
                    var natio = soft.CV_NATIONS.Where(a => a.IDCountry == FirstCV.IDNationality).FirstOrDefault();
                    comboNationality.Text = natio.Country;
                      
                }

                textGivenAge.Text = null;
                if (FirstCV.DateSave != null && FirstCV.BirthDay == null)
                {
                    //var dtNo = DateTime.Now;
                    //var years = (dtNo.Year - FirstCV.DateSave.Value.Year - (DateTime.Now.Month < FirstCV.DateSave.Value.Month ? 1 : (DateTime.Now.Month == FirstCV.DateSave.Value.Month && DateTime.Now.Day < FirstCV.DateSave.Value.Day) ? 1 : 0));
                    var gaT = 0;
                    if (FirstCV.GivenAge != null)
                        gaT = FirstCV.GivenAge.Value;

                    var ga = /*years +*/ gaT;
                    textGivenAge.Text = ga.ToString();
                       
                }

                textAdress2.Text = FirstCV.Adress2;
                textAdress3.Text = FirstCV.Adress3;

                comboTOWN.Text = null;
                if (FirstCV.IDTOWN != null && FirstCV.IDTOWN != 0 && soft.CV_TOWNS.Where(a => a.ID == FirstCV.IDTOWN).Count() != 0)
                {
                    var twn = soft.CV_TOWNS.Where(a => a.ID == FirstCV.IDTOWN).FirstOrDefault();
                    comboTOWN.Text = twn.TOWN;
                }

                comboCat.Text = null;
                if (FirstCV.IDCat != null && FirstCV.IDCat != 0 && soft.CV_CATEGORY.Where(a => a.IDCat == FirstCV.IDCat).Count() != 0)
                {
                    var cat = soft.CV_CATEGORY.Where(a => a.IDCat == FirstCV.IDCat).FirstOrDefault();
                    comboCat.Text = cat.Category;
                }

                comboCountry.Text = null;
                if (FirstCV.IDCountry != null && FirstCV.IDCountry != 0 && soft.CV_NATIONS.Where(a => a.IDCountry == FirstCV.IDCountry).Count() != 0)
                {
                    var country = soft.CV_NATIONS.Where(a => a.IDCountry == FirstCV.IDCountry).FirstOrDefault();
                    comboCountry.Text = country.Country;
                }

                textMobilPhone.Text = FirstCV.MobilPhone;
                textMobilPhone2.Text = FirstCV.MobilPhone2;
                textMail1.Text = FirstCV.Email1;

                comboPersTPH.Text = null;
                if (FirstCV.IDPersRef != null && FirstCV.IDPersRef != 0 && soft.CV_EMPLOYEE.Where(a => a.IDPersRef == FirstCV.IDPersRef).Count() != 0)
                {
                    var country = soft.CV_EMPLOYEE.Where(a => a.IDPersRef == FirstCV.IDPersRef).FirstOrDefault();
                    comboPersTPH.Text = country.PersRef;
                }

                textLandlinePhone.Text = FirstCV.LandlinePhone;
                textMail2.Text = FirstCV.Email2;

                textDailyFees.Text = FirstCV.ExpDailyFees;

                textdateInterview.Text = null;
                if (FirstCV.DateSPMU != null)
                    textdateInterview.Text = FirstCV.DateSPMU.Value.ToShortDateString();

                comboShortListed.Text = null;
                if (FirstCV.ShortListed == true)
                    comboShortListed.Text = "YES";
                else if (FirstCV.ShortListed == false)
                    comboShortListed.Text = "NO";

                comboJunSenior.Text = null;
                if (FirstCV.IDJunSenior != null && FirstCV.IDJunSenior != 0 && soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == FirstCV.IDJunSenior).Count() != 0)
                {
                    var country = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == FirstCV.IDJunSenior).FirstOrDefault();
                    comboJunSenior.Text = country.JunSenior;
                }

                textComCV.Text = FirstCV.Comments;

                textSleepComment.Text = FirstCV.SleepComments;

                comboTitle.Text = null;
                if (FirstCV.Title == true)
                    comboTitle.Text = "Mr.";
                else if (FirstCV.Title == false)
                    comboTitle.Text = "Mrs.";

                textWhy.Text = FirstCV.WHY;

                //Document//
                if (soft.CV_DOC.Where(a => a.IDCV == FirstCV.IDCV && a.NUM != 6).Count() != 0)
                {
                    List<ComboBox> comboBoxes = new List<ComboBox> { comboDoc1, comboDoc2, comboDoc3, comboDoc4, comboDoc5 };
                    List<TextBox> textbox = new List<TextBox> { textDocLink1, textDocLink2, textDocLink3, textDocLink4, textDocLink5 };

              
                    foreach (var x in soft.CV_DOC.Where(a => a.IDCV == FirstCV.IDCV && a.NUM != 6).OrderBy(a => a.NUM).ToList())
                    {
                        var doc = "";
                        int range = 0;
                           
                        if (soft.CV_DOCUMENT.Where(a => a.IDDoc == x.IDDoc).Count() != 0)
                        {
                            doc = soft.CV_DOCUMENT.Where(a => a.IDDoc == x.IDDoc).FirstOrDefault().Docum;
                        }
                        if (int.TryParse(x.NUM.ToString(), out range))
                        {
                            comboBoxes[range-1].Text = doc;
                            textbox[range-1].Text = x.Link  ;
                             
                        }
                    }
                }

                //DOC6//

                comboDoc6.Text = "Data retention authorisation";
                textdateLastRequest.Text = null;
                textBonusDoc.Text = "0";
                if (soft.CV_DOCDATECOMM.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                {
                    var isDoc = soft.CV_DOCDATECOMM.Where(a => a.IDCV == FirstCV.IDCV).FirstOrDefault();
                    if (isDoc.UpdateCV != null)
                        textdateLastRequest.Text = isDoc.UpdateCV.Value.ToShortDateString();

                    textComBonus.Text = isDoc.Comments;

                    if (isDoc.BONUS != null)
                        textBonusDoc.Text = isDoc.BONUS.Value.ToString();
                }

                var isD6 = soft.CV_DOCUMENT.Where(a => a.Docum == "Data retention authorisation").FirstOrDefault().IDDoc;
                var isDoc6 = soft.CV_DOC.Where(a => a.IDCV == FirstCV.IDCV && a.IDDoc == isD6 && a.NUM == 6).FirstOrDefault();
                if (isDoc6 != null)
                {
                    if (String.IsNullOrEmpty(isDoc6.Link))
                    {
                        textDocLink6.Text = "";
                        var docu = soft.DS_SIGN.Where(x => x.IDCV == FirstCV.IDCV && !x.SIGNED).OrderByDescending(x=>x.REQUEST).FirstOrDefault();
                        Envelope env = null;

                        if (docu != null)
                        {
                            bool test = false;
                            if (dsParameter.authToken != null) test = String.IsNullOrEmpty(dsParameter.authToken.access_token);

                            if (!test)
                            {
                                env = dsParameter.GetEnvelope(docu.REQUEST, FirstCV.FirstName + " " + FirstCV.LastName);

                                if (env != null)
                                {
                                    var link = $"DS//{env.Status}/{env.EnvelopeId}";
                                    isDoc6.Link = link;
                                    docu.SIGNED = true;
                                    soft.SaveChanges();
                                    textDocLink6.Text = link;
                                }
                            }
                        }
                    }
                    else
                    {
                        textDocLink6.Text = isDoc6.Link;
                    }
                }
                //Verify 27/01/23
                /*else
                {
                    //VerifyCVDocusign
                    var docu = soft.DS_SIGN.Where(x => x.IDCV == FirstCV.IDCV && !x.SIGNED).OrderByDescending(x => x.REQUEST).FirstOrDefault();
                    Envelope env = null;

                    if (docu != null)
                    {
                        bool test = false;
                        if (dsParameter.authToken != null) test = String.IsNullOrEmpty(dsParameter.authToken.access_token);

                        if (!test) { 
                            env = dsParameter.GetEnvelope(docu.REQUEST, FirstCV.FirstName + " " + FirstCV.LastName);
                            if(env != null)
                            {
                                var link = $"DS//${env.Status}/${env.EnvelopeId}";
                                docu.SIGNED = true;
                                soft.CV_DOC.Add(new CV_DOC()
                                {
                                    IDCV = FirstCV.IDCV,
                                    IDDoc = isD6,
                                    NUM = 6,
                                    Link = link
                                });
                                soft.SaveChanges();
                                textDocLink6.Text = link;
                            }
                        }
                    }
                }*/

                
                

                //Diploma and speciality//
                if (soft.CV_EDUC.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                {
                    List<ComboBox> comboDipl = new List<ComboBox> { comboDipl1, comboDipl2, comboDipl3 };
                    List<ComboBox> comboSpecDipl = new List<ComboBox> { comboSpecDipl1, comboSpecDipl2, comboSpecDipl3 };
                    List<ComboBox> comboDiplP = new List<ComboBox> { comboDiplP1, comboDiplP2, comboDiplP3 };
                    List<TextBox> textDiplY = new List<TextBox> { textDiplY1, textDiplY2, textDiplY3 };

                    foreach (var x in soft.CV_EDUC.Where(a => a.IDCV == FirstCV.IDCV).OrderBy(a => a.NUM).ToList())
                    {
                        var dipl = "";
                        var spec = "";
                        var place = "";
                        var years = "";
                        int range = 0;
                        
                          
                        if (soft.CV_DIPLOMA.Where(a => a.IDDiploma == x.IDDiploma).Count() != 0)
                            dipl = soft.CV_DIPLOMA.Where(a => a.IDDiploma == x.IDDiploma ).FirstOrDefault().Diploma;
                        if (soft.CV_SPECIALITY.Where(a => a.IDSpeciality == x.IDDiploma).Count() != 0)
                            spec = soft.CV_SPECIALITY.Where(a => a.IDSpeciality == x.IDSpeciality ).FirstOrDefault().Speciality;
                        if (soft.CV_PLACE.Where(a => a.IDPlace == x.IDPlace).Count() != 0)
                            place = soft.CV_PLACE.Where(a => a.IDPlace == x.IDPlace ).FirstOrDefault().Place;

                        years = x.Years.ToString();
                        if (int.TryParse(x.NUM.ToString(), out range))
                        {
                            comboDipl[range - 1].Text = dipl;
                            comboDipl[range - 1].Focus();
                            comboSpecDipl[range - 1].Text = spec;
                            comboDiplP[range - 1].Text = place;
                            textDiplY[range - 1].Text = years;
                        }
                         

                    }
                      





                }

                //Post Graduate//
                if (soft.CV_GRAD.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                {
                    List<ComboBox> combograd = new List<ComboBox> { comboPostGrad1, comboPostGrad2, comboPostGrad3 };
                    List<ComboBox> comboPostGradP = new List<ComboBox> { comboPostGradP1, comboPostGradP2, comboPostGradP3 };
                    List<TextBox> textPostGradY = new List<TextBox> { textPostGradY1, textPostGradY2, textPostGradY3 };

                   
                    foreach (var x in soft.CV_GRAD.Where(a => a.IDCV == FirstCV.IDCV).OrderBy(a => a.NUM).ToList())
                    {
                        var grad = "";
                        var place = "";
                        var years = "";
                        int range = 0;
                        if (soft.CV_GRADUATE.Where(a => a.IDGraduate == x.IDGraduate).Count() != 0)
                            grad = soft.CV_GRADUATE.Where(a => a.IDGraduate == x.IDGraduate).FirstOrDefault().Graduate;
                        if (soft.CV_PLACE.Where(a => a.IDPlace == x.IDPlace).Count() != 0)
                            place = soft.CV_PLACE.Where(a => a.IDPlace == x.IDPlace).FirstOrDefault().Place;

                        years = x.Years.ToString();
                        if (int.TryParse(x.NUM.ToString(), out range))
                        {
                            combograd[range-1].Text = grad;
                            comboPostGradP[range-1].Text = place;
                            textPostGradY[range-1].Text = years;
                        }
                            

                           
                    }
                }

                //Languages//
                if (soft.CV_WRSP.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                {
                    List<ComboBox> la = new List<ComboBox> { comboLang1, comboLang2, comboLang3, comboLang4 };
                    List<ComboBox> wr = new List<ComboBox> { comboLangW1, comboLangW2, comboLangW3, comboLangW4 };
                    List<ComboBox> sp = new List<ComboBox> { comboLangS1, comboLangS2, comboLangS3, comboLangS4 };

                     
                    int range = 0;
                    foreach (var x in soft.CV_WRSP.Where(a => a.IDCV == FirstCV.IDCV).OrderBy(a => a.NUM).ToList())
                    {
                        var lag = ""; var wri = ""; var spo = "";
                        if (soft.CV_LANGUAGE.Where(a => a.IDLanguage == x.IDLanguage).Count() != 0)
                            lag = soft.CV_LANGUAGE.Where(a => a.IDLanguage == x.IDLanguage).FirstOrDefault().Language;
                        if (soft.CV_WRSPLEVEL.Where(a => a.IDWrSp == x.IDWr).Count() != 0)
                            wri = soft.CV_WRSPLEVEL.Where(a => a.IDWrSp == x.IDWr).FirstOrDefault().WrSp;
                        if (soft.CV_WRSPLEVEL.Where(a => a.IDWrSp == x.IDSp).Count() != 0)
                            spo = soft.CV_WRSPLEVEL.Where(a => a.IDWrSp == x.IDSp).FirstOrDefault().WrSp;
                        if (int.TryParse(x.NUM.ToString(), out range))
                        {
                            la[range-1].Text = lag;
                            wr[range-1].Text = wri;
                            sp[range-1].Text = spo;
                        }
                           

                    }
                }

                //Tech field//
                if (soft.CV_INTLEXPTECH.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                {
                    List<ComboBox> tf = new List<ComboBox> { comboTechField1, comboTechField2, comboTechField3 };
                    List<TextBox> years = new List<TextBox> { textTFYears1, textTFYears2, textTFYears3 };

                
                    foreach (var x in soft.CV_INTLEXPTECH.Where(a => a.IDCV == FirstCV.IDCV).OrderBy(a => a.NUM).ToList())
                    {
                        var tfi = "";
                        int range = 0;
                        if (soft.CV_TECHNICFIELD.Where(a => a.IDTechField == x.IDTechField).Count() != 0)
                            tfi = soft.CV_TECHNICFIELD.Where(a => a.IDTechField == x.IDTechField).FirstOrDefault().TechnicField;
                        if (int.TryParse(x.NUM.ToString(), out range))
                        {
                            tf[range-1].Text = tfi;
                            years[range-1].Text = x.NbYear.Value.ToString();

                        }
                    }
                }

                //Region//
                if (soft.CV_INTLREGEXP.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                {
                    List<ComboBox> tr = new List<ComboBox> { comboRegion1, comboRegion2, comboRegion3 };
                    List<TextBox> years = new List<TextBox> { textRYears1, textRYears2, textRYears3 };

                    int range = 0;
                    foreach (var x in soft.CV_INTLREGEXP.Where(a => a.IDCV == FirstCV.IDCV).OrderBy(a => a.NUM).ToList())
                    {
                        var tri = "";
                        if (soft.CV_REGION.Where(a => a.IDRegion == x.IDRegion).Count() != 0)
                            tri = soft.CV_REGION.Where(a => a.IDRegion == x.IDRegion).FirstOrDefault().Region;
                        if (int.TryParse(x.NUM.ToString(), out range))
                        {
                            tr[range-1].Text = tri;
                            years[range-1].Text = x.NbYear.Value.ToString();

                        }
                    }
                }

                //CRITERIA//
                if (FirstCV.IDCat != 0)
                {
                    if (soft.CV_CATEGORY.Where(a => a.IDCat == FirstCV.IDCat).Count() != 0)
                    {
                        var isCat = soft.CV_CATEGORY.Where(a => a.IDCat == FirstCV.IDCat).FirstOrDefault();

                        label78.Text = "No criteria defined in the tuning page";
                        if (!String.IsNullOrEmpty(isCat.CR1))
                        {
                            label78.Text = isCat.CR1;
                            textCRYears1.Enabled = true;
                        }

                        label75.Text = "No criteria defined in the tuning page";
                        if (!String.IsNullOrEmpty(isCat.CR2))
                        {
                            label75.Text = isCat.CR2;
                            textCRYears2.Enabled = true;
                        }

                        label73.Text = "No criteria defined in the tuning page";
                        if (!String.IsNullOrEmpty(isCat.CR3))
                        {
                            label73.Text = isCat.CR3;
                            textCRYears3.Enabled = true;
                        }



                        label79.Text = "No criteria defined in the tuning page";
                        if (!String.IsNullOrEmpty(isCat.CR4))
                        {
                            textCRYears4.Enabled = true;
                            label79.Text = isCat.CR4;
                        }
                        label119.Text = "No criteria defined in the tuning page";
                        if (!String.IsNullOrEmpty(isCat.CR5))
                        {
                            textCRYears5.Enabled = true;
                            label119.Text = isCat.CR5;
                        }


                        if (soft.CV_NOTECRITERIA.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                        {
                            var noteCr = soft.CV_NOTECRITERIA.Where(a => a.IDCV == FirstCV.IDCV).FirstOrDefault();

                            textCRYears1.Text = "0";
                            if (noteCr.N1 != 0)
                                textCRYears1.Text = noteCr.N1.ToString();

                            textCRYears2.Text = "0";
                            if (noteCr.N2 != 0)
                                textCRYears2.Text = noteCr.N2.ToString();

                            textCRYears3.Text = "0";
                            if (noteCr.N3 != 0)
                                textCRYears3.Text = noteCr.N3.ToString();

                            textCRYears4.Text = "0";
                            if (noteCr.N4 != 0)
                                textCRYears4.Text = noteCr.N4.ToString();

                            textCRYears5.Text = "0";
                            if (noteCr.N5 != 0)
                                textCRYears5.Text = noteCr.N5.ToString();
                        }
                    }
                }

                //Comment INTL//
                if (soft.CV_INTLCOMMENT.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                    textINTLExpComm.Text = soft.CV_INTLCOMMENT.Where(a => a.IDCV == FirstCV.IDCV).FirstOrDefault().Comments;

                //Exprerience with SWISS TPH//
                if (soft.CV_EXPSWTPH.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                {
                    List<TextBox> TR = new List<TextBox> { textdateSDWork1, textdateSDWork2 };
                    List<TextBox> WEEK = new List<TextBox> { textDurWeek1, textDurWeek2 };
                    List<ComboBox> SCHI = new List<ComboBox> { comboSCHI1, comboSCHI2 };
                    List<ComboBox> ROLE = new List<ComboBox> { comboRole1, comboRole2 };
                    List<ComboBox> JS = new List<ComboBox> { comboJunSen1, comboJunSen2 };
                    List<ComboBox> MS = new List<ComboBox> { comboMainSup1, comboMainSup2 };
                    List<TextBox> APP = new List<TextBox> { textAppr1, textAppr2 };
                    List<ComboBox> CLT = new List<ComboBox> { comboClt1, comboClt2 };
                    List<ComboBox> DOM = new List<ComboBox> { comboDomExp1, comboDomExp2 };
                    List<ComboBox> COUN = new List<ComboBox> { comboCountry1, comboCountry2 };
                    List<ComboBox> LAN = new List<ComboBox> { comboLangReport1, comboLangReport2 };
                    List<ComboBox> LFA = new List<ComboBox> { comboLFA1, comboLFA2 };
                    List<TextBox> FEE = new List<TextBox> { textDailyFeePaid1, textDailyFeePaid2 };
                    List<TextBox> LINK = new List<TextBox> { textLink1, textLink2 };

                    int i = 0;
                    foreach (var x in soft.CV_EXPSWTPH.Where(a => a.IDCV == FirstCV.IDCV).OrderBy(a => a.NUM).ToList())
                    {
                        var tr = "";
                        if (x.StartDate != null)
                            tr = x.StartDate.Value.ToShortDateString();
                        TR[i].Text = tr;

                        if (x.Duration != null)
                            WEEK[i].Text = x.Duration.Value.ToString();

                        var schi = "";
                        if (soft.CV_UNIT.Where(a => a.IDSCIHUnit == x.IDSCIHUnit).Count() != 0)
                            schi = soft.CV_UNIT.Where(a => a.IDSCIHUnit == x.IDSCIHUnit).FirstOrDefault().Unit;
                        SCHI[i].Text = schi;

                        var role = "";
                        if (soft.CV_ROLE.Where(a => a.IDRole == x.IDRole).Count() != 0)
                            role = soft.CV_ROLE.Where(a => a.IDRole == x.IDRole).FirstOrDefault().Role;
                        ROLE[i].Text = role;

                        var js = "";
                        if (soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == x.IDJunSenior).Count() != 0)
                            js = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == x.IDJunSenior).FirstOrDefault().JunSenior;
                        JS[i].Text = js;

                        var ms = "";
                        if (soft.CV_EMPLOYEE.Where(a => a.IDPersRef == x.IDPersRef).Count() != 0)
                            ms = soft.CV_EMPLOYEE.Where(a => a.IDPersRef == x.IDPersRef).FirstOrDefault().PersRef;
                        MS[i].Text = ms;

                        APP[i].Text = x.Appreciation;

                        var clt = "";
                        if (soft.CV_CLIENT.Where(a => a.IDClient == x.IDClient).Count() != 0)
                            clt = soft.CV_CLIENT.Where(a => a.IDClient == x.IDClient).FirstOrDefault().Client;
                        CLT[i].Text = clt;

                        var dom = "";
                        if (soft.CV_TECHNICFIELD.Where(a => a.IDTechField == x.IDExp).Count() != 0)
                            dom = soft.CV_TECHNICFIELD.Where(a => a.IDTechField == x.IDExp).FirstOrDefault().TechnicField;
                        DOM[i].Text = dom;

                        var coun = "";
                        if (soft.CV_NATIONS.Where(a => a.IDCountry == x.IDCountry).Count() != 0)
                            coun = soft.CV_NATIONS.Where(a => a.IDCountry == x.IDCountry).FirstOrDefault().Country;
                        COUN[i].Text = coun;

                        var lan = "";
                        if (soft.CV_LANGUAGE.Where(a => a.IDLanguage == x.IDLanguage).Count() != 0)
                            lan = soft.CV_LANGUAGE.Where(a => a.IDLanguage == x.IDLanguage).FirstOrDefault().Language;
                        LAN[i].Text = lan;

                        LFA[i].Text = "";
                        if (x.LFAWork == true)
                            LFA[i].Text = "YES";
                        else if (x.LFAWork == false)
                            LFA[i].Text = "NO";

                        if (x.DailyFees != null)
                            FEE[i].Text = x.DailyFees.ToString();

                        LINK[i].Text = x.LinkReport;

                        i++;
                    }
                }

                //Comment SWISS TPH//
                if (soft.CV_EXPCOMMENT.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                    textExpSWISSComm.Text = soft.CV_EXPCOMMENT.Where(a => a.IDCV == FirstCV.IDCV).FirstOrDefault().Comments;

                //VISIT AT SPUM//
                if (soft.CV_VISITSPMU.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                {
                    var isVisit = soft.CV_VISITSPMU.Where(a => a.IDCV == FirstCV.IDCV).FirstOrDefault();

                    textdateVisitSPMU.Text = isVisit.Date.Value.ToShortDateString();

                    var met1 = "";
                    if (soft.CV_EMPLOYEE.Where(a => a.IDPersRef == isVisit.IDEmplo1).Count() != 0)
                        met1 = soft.CV_EMPLOYEE.Where(a => a.IDPersRef == isVisit.IDEmplo1).FirstOrDefault().PersRef;
                    comboEmplMet1.Text = met1;

                    var met2 = "";
                    if (soft.CV_EMPLOYEE.Where(a => a.IDPersRef == isVisit.IDEmplo2).Count() != 0)
                        met2 = soft.CV_EMPLOYEE.Where(a => a.IDPersRef == isVisit.IDEmplo2).FirstOrDefault().PersRef;
                    comboEmplMet2.Text = met2;

                    var met3 = "";
                    if (soft.CV_EMPLOYEE.Where(a => a.IDPersRef == isVisit.IDEmplo3).Count() != 0)
                        met3 = soft.CV_EMPLOYEE.Where(a => a.IDPersRef == isVisit.IDEmplo3).FirstOrDefault().PersRef;
                    comboEmplMet3.Text = met3;

                    comboPosTarget.Text = null;
                    if (isVisit.IDCategory != null && isVisit.IDCategory != 0)
                    {
                        var cat = soft.CV_CATEGORY.Where(a => a.IDCat == isVisit.IDCategory).FirstOrDefault();
                        comboPosTarget.Text = cat.Category;
                    }

                    comboTestDone.Text = "0";
                    if (isVisit.TestDone != null)
                        comboTestDone.Text = isVisit.TestDone.ToString();

                    comboGlobAppr.Text = null;
                    if (isVisit.IDGApprec != null && isVisit.IDGApprec != 0)
                    {
                        var app = soft.CV_GAPPREC.Where(a => a.IDGApprec == isVisit.IDGApprec).FirstOrDefault();
                        comboGlobAppr.Text = app.GApprec;
                    }

                    textVisitSPMUComm.Text = isVisit.Comments;
                }

                //EPROFIL//
                if (soft.CV_EPRO.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                {
                    List<ComboBox> combo = new List<ComboBox> { ep1, ep2, ep3 };
                    List<TextBox> text = new List<TextBox> { epl1, epl2, epl3 };

                    int i = 0;
                    foreach (var x in soft.CV_EPRO.Where(a => a.IDCV == FirstCV.IDCV).OrderBy(a => a.NUM).ToList())
                    {
                        var epro = "";
                        var link = "";

                        if (soft.CV_EPROFIL.Where(a => a.IDEProf == x.IDEProf).Count() != 0)
                            epro = soft.CV_EPROFIL.Where(a => a.IDEProf == x.IDEProf).FirstOrDefault().EProfile;

                        link = x.Link.ToString();

                        combo[i].Text = epro;
                        text[i].Text = link;

                        i++;
                    }
                }

                  //  comboDipl1.Focus();

                
               
                ////EPROFIL WEB//
                //if (soft.CV_EPROWL.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                //{
                //    List<TextBox> text = new List<TextBox> { eplw1, eplw2, eplw3 };

                //    int i = 0;
                //    foreach (var x in soft.CV_EPROWL.Where(a => a.IDCV == FirstCV.IDCV).OrderBy(a => a.NUM).ToList())
                //    {
                //        var link = "";

                //        link = x.Link.ToString();

                //        text[i].Text = link;

                //        i++;
                //    }
                //}

                ////ON CHAT PLATFORM//
                //if (soft.CV_ONCHAT.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                //{
                //    List<ComboBox> combo = new List<ComboBox> { oc1, oc2, oc3 };
                //    List<TextBox> text = new List<TextBox> { ocl1, ocl2, ocl3 };

                //    int i = 0;
                //    foreach (var x in soft.CV_ONCHAT.Where(a => a.IDCV == FirstCV.IDCV).OrderBy(a => a.NUM).ToList())
                //    {
                //        var epro = "";
                //        var link = "";

                //        if (soft.CV_ONCHATPLAT.Where(a => a.IDChat == x.IDChat).Count() != 0)
                //        {
                //            epro = soft.CV_ONCHATPLAT.Where(a => a.IDChat == x.IDChat).FirstOrDefault().OnlineChat;
                //        }
                //        link = x.Link.ToString();

                //        combo[i].Text = epro;
                //        text[i].Text = link;

                //        i++;
                //    }
                //}

                ////ON CHAT AVATAR//
                //if (soft.CV_ONCHATAVA.Where(a => a.IDCV == FirstCV.IDCV).Count() != 0)
                //{
                //    List<TextBox> text = new List<TextBox> { ocla1, ocla2, ocla3 };

                //    int i = 0;
                //    foreach (var x in soft.CV_ONCHATAVA.Where(a => a.IDCV == FirstCV.IDCV).OrderBy(a => a.NUM).ToList())
                //    {
                //        var link = "";

                //        link = x.Link.ToString();

                //        text[i].Text = link;

                //        i++;
                //    }
                //}
                AllValue();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dateCV_ValueChanged(object sender, EventArgs e)
        {
            textdateCV.Text = dateCV.Value.ToShortDateString();
        }

        private void dateBirthDay_ValueChanged(object sender, EventArgs e)
        {
            textdateBirthDay.Text = dateBirthDay.Value.ToShortDateString();
       
        }

        private void dateInterview_ValueChanged(object sender, EventArgs e)
        {
            textdateInterview.Text = dateInterview.Value.ToShortDateString();
        }

        private void dateSDWork1_ValueChanged(object sender, EventArgs e)
        {
            textdateSDWork1.Text = dateSDWork1.Value.ToShortDateString();
        }

        private void dateSDWork2_ValueChanged(object sender, EventArgs e)
        {
            textdateSDWork2.Text = dateSDWork2.Value.ToShortDateString();
        }

        private void dateVisitSPMU_ValueChanged(object sender, EventArgs e)
        {
            textdateVisitSPMU.Text = dateVisitSPMU.Value.ToShortDateString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
        private static Dictionary<string, string> mandatory = new Dictionary<string, string>();
        private static Dictionary<string, string> notmandatory = new Dictionary<string, string>();

        bool CANSAVE = new bool();
        bool yellowfields = new bool();
        public void yellowfield()
        {
            yellowfields = true;
            CANSAVE = true;
            mandatory = new Dictionary<string, string>();
            notmandatory = new Dictionary<string, string>();
            if (String.IsNullOrEmpty(comboTitle.Text))
            {
                CANSAVE = false;
                mandatory.Add("comboTitle", "Title");
            }
            
            if (String.IsNullOrEmpty(comboName.Text))
            {
                CANSAVE = false;
                mandatory.Add("comboname", "Last Name");
            }
            if (String.IsNullOrEmpty(textPrenom.Text))
            {
                CANSAVE = false;
                mandatory.Add("textPrenom", "First Name");
            }
           if (String.IsNullOrEmpty(comboGender.Text))
            {
                CANSAVE = false;
                mandatory.Add("comboGender", "Gender");
            }
            if (String.IsNullOrEmpty(comboNationality.Text))
            {
                CANSAVE = false;
                mandatory.Add("comboNationality", "Nationality");
            }
            if (String.IsNullOrEmpty(comboCat.Text))
            {
                CANSAVE = false;
                mandatory.Add("comboCat", "Category");
            }
            if (String.IsNullOrEmpty(comboJunSenior.Text))
            {
                CANSAVE = false;
                mandatory.Add("comboJunSenior", "Level");
            }
            if (String.IsNullOrEmpty(comboDipl1.Text))
            {
               yellowfields = false;
               notmandatory.Add("comboDipl1", "Diploma");
            }
            if (String.IsNullOrEmpty(comboSpecDipl1.Text))
            {
                yellowfields = false;
                notmandatory.Add("comboSpecDipl1", "Diploma Speciality");
            }
            if (String.IsNullOrEmpty(comboLang1.Text))
            {
                yellowfields = false;
                notmandatory.Add("comboLang1", "Language");
            }
            if (String.IsNullOrEmpty(comboDiplP1.Text))
            {
                yellowfields = false;
                notmandatory.Add("comboDiplP1", "Diploma Place");
            }
            if (String.IsNullOrEmpty(comboTechField1.Text))
            {
                yellowfields = false;
               notmandatory.Add("comboTechField1", "INTL Experience Technical Field");
            }
            if (String.IsNullOrEmpty(comboRegion1.Text))
            {
                yellowfields = false;
                notmandatory.Add("comboRegion1", "INTL Experience Region");
            }
        }
  

        public void InsertOrUpdateCV()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();
                string mssg = "Please fill all informations : " + "\n\n";
                string mssgyellow = "";
                CANSAVE = true;
                yellowfield();

                /*     if (!String.IsNullOrEmpty(comboName.Text) && !String.IsNullOrEmpty(textPrenom.Text) && !String.IsNullOrEmpty(comboGender.Text) &&
                          !String.IsNullOrEmpty(comboNationality.Text) && !String.IsNullOrEmpty(comboCat.Text) && !String.IsNullOrEmpty(comboJunSenior.Text) &&
                          !String.IsNullOrEmpty(comboDipl1.Text) && !String.IsNullOrEmpty(comboSpecDipl1.Text) && !String.IsNullOrEmpty(comboDiplP1.Text) &&
                          !String.IsNullOrEmpty(comboLang1.Text) &&
                          !String.IsNullOrEmpty(comboTechField1.Text) && !String.IsNullOrEmpty(comboRegion1.Text) &&
                          !String.IsNullOrEmpty(comboTitle.Text))*/
                if (!String.IsNullOrEmpty(comboName.Text) && !String.IsNullOrEmpty(textPrenom.Text) && !String.IsNullOrEmpty(comboGender.Text) &&
                   !String.IsNullOrEmpty(comboNationality.Text) && !String.IsNullOrEmpty(comboCat.Text) && !String.IsNullOrEmpty(comboJunSenior.Text) &&
                   !String.IsNullOrEmpty(comboTitle.Text) && !String.IsNullOrEmpty(textdateCV.Text))
                {
                    //   string mssg = "Please fill all informations : " + "\n\n";
                    //  string mssgyellow = "";
                    //TEST//
                    //DOC//
                    if ((!String.IsNullOrEmpty(comboDoc1.Text) && String.IsNullOrEmpty(textDocLink1.Text))
                        || (String.IsNullOrEmpty(comboDoc1.Text) && !String.IsNullOrEmpty(textDocLink1.Text)))
                    {
                        CANSAVE = false;
                        mssg += "Doc1 or LinkDoc1" + "\n";
                    }
                    if ((!String.IsNullOrEmpty(comboDoc2.Text) && String.IsNullOrEmpty(textDocLink2.Text))
                        || (String.IsNullOrEmpty(comboDoc2.Text) && !String.IsNullOrEmpty(textDocLink2.Text)))
                    {
                        CANSAVE = false;
                        mssg += "Doc2 or LinkDoc2" + "\n";
                    }
                    if ((!String.IsNullOrEmpty(comboDoc3.Text) && String.IsNullOrEmpty(textDocLink3.Text))
                        || (String.IsNullOrEmpty(comboDoc3.Text) && !String.IsNullOrEmpty(textDocLink3.Text)))
                    {
                        CANSAVE = false;
                        mssg += "Doc3 or LinkDoc3" + "\n";
                    }
                    if ((!String.IsNullOrEmpty(comboDoc4.Text) && String.IsNullOrEmpty(textDocLink4.Text))
                        || (String.IsNullOrEmpty(comboDoc4.Text) && !String.IsNullOrEmpty(textDocLink4.Text)))
                    {
                        CANSAVE = false;
                        mssg += "Doc4 or LinkDoc4" + "\n";
                    }
                    if ((!String.IsNullOrEmpty(comboDoc5.Text) && String.IsNullOrEmpty(textDocLink5.Text))
                        || (String.IsNullOrEmpty(comboDoc5.Text) && !String.IsNullOrEmpty(textDocLink5.Text)))
                    {
                        CANSAVE = false;
                        mssg += "Doc5 or LinkDoc5" + "\n";
                    }
                    //EDUCATION//
                    if ((!String.IsNullOrEmpty(comboDipl1.Text) && String.IsNullOrEmpty(comboSpecDipl1.Text) && String.IsNullOrEmpty(comboDiplP1.Text))
                        || (String.IsNullOrEmpty(comboDipl1.Text) && !String.IsNullOrEmpty(comboSpecDipl1.Text) && String.IsNullOrEmpty(comboDiplP1.Text))
                        || (String.IsNullOrEmpty(comboDipl1.Text) && String.IsNullOrEmpty(comboSpecDipl1.Text) && !String.IsNullOrEmpty(comboDiplP1.Text))
                        || (!String.IsNullOrEmpty(comboDipl1.Text) && !String.IsNullOrEmpty(comboSpecDipl1.Text) && String.IsNullOrEmpty(comboDiplP1.Text))
                        || (!String.IsNullOrEmpty(comboDipl1.Text) && String.IsNullOrEmpty(comboSpecDipl1.Text) && !String.IsNullOrEmpty(comboDiplP1.Text))
                        || (String.IsNullOrEmpty(comboDipl1.Text) && !String.IsNullOrEmpty(comboSpecDipl1.Text) && !String.IsNullOrEmpty(comboDiplP1.Text)))
                    {
                        CANSAVE = false;
                        mssg += "Diploma1 or Speciality1 or Place1" + "\n";
                    }
                    if ((!String.IsNullOrEmpty(comboDipl2.Text) && String.IsNullOrEmpty(comboSpecDipl2.Text) && String.IsNullOrEmpty(comboDiplP2.Text))
                        || (String.IsNullOrEmpty(comboDipl2.Text) && !String.IsNullOrEmpty(comboSpecDipl2.Text) && String.IsNullOrEmpty(comboDiplP2.Text))
                        || (String.IsNullOrEmpty(comboDipl2.Text) && String.IsNullOrEmpty(comboSpecDipl2.Text) && !String.IsNullOrEmpty(comboDiplP2.Text))
                        || (!String.IsNullOrEmpty(comboDipl2.Text) && !String.IsNullOrEmpty(comboSpecDipl2.Text) && String.IsNullOrEmpty(comboDiplP2.Text))
                        || (!String.IsNullOrEmpty(comboDipl2.Text) && String.IsNullOrEmpty(comboSpecDipl2.Text) && !String.IsNullOrEmpty(comboDiplP2.Text))
                        || (String.IsNullOrEmpty(comboDipl2.Text) && !String.IsNullOrEmpty(comboSpecDipl2.Text) && !String.IsNullOrEmpty(comboDiplP2.Text)))
                    {
                        CANSAVE = false;
                        mssg += "Diploma2 or Speciality2 or Place2" + "\n";
                    }
                    if ((!String.IsNullOrEmpty(comboDipl3.Text) && String.IsNullOrEmpty(comboSpecDipl3.Text) && String.IsNullOrEmpty(comboDiplP3.Text))
                        || (String.IsNullOrEmpty(comboDipl3.Text) && !String.IsNullOrEmpty(comboSpecDipl3.Text) && String.IsNullOrEmpty(comboDiplP3.Text))
                        || (String.IsNullOrEmpty(comboDipl3.Text) && String.IsNullOrEmpty(comboSpecDipl3.Text) && !String.IsNullOrEmpty(comboDiplP3.Text))
                        || (!String.IsNullOrEmpty(comboDipl3.Text) && !String.IsNullOrEmpty(comboSpecDipl3.Text) && String.IsNullOrEmpty(comboDiplP3.Text))
                        || (!String.IsNullOrEmpty(comboDipl3.Text) && String.IsNullOrEmpty(comboSpecDipl3.Text) && !String.IsNullOrEmpty(comboDiplP3.Text))
                        || (String.IsNullOrEmpty(comboDipl3.Text) && !String.IsNullOrEmpty(comboSpecDipl3.Text) && !String.IsNullOrEmpty(comboDiplP3.Text)))
                    {
                        CANSAVE = false;
                        mssg += "Diploma3 or Speciality3 or Place3" + "\n";
                    }
                    //POST GRADUATE//
                    if ((!String.IsNullOrEmpty(comboPostGrad1.Text) && String.IsNullOrEmpty(comboPostGradP1.Text))
                        || (String.IsNullOrEmpty(comboPostGrad1.Text) && !String.IsNullOrEmpty(comboPostGradP1.Text)))
                    {
                        CANSAVE = false;
                        mssg += "Post Graduate Training1 or Place1" + "\n";
                    }
                    if ((!String.IsNullOrEmpty(comboPostGrad2.Text) && String.IsNullOrEmpty(comboPostGradP2.Text))
                        || (String.IsNullOrEmpty(comboPostGrad2.Text) && !String.IsNullOrEmpty(comboPostGradP2.Text)))
                    {
                        CANSAVE = false;
                        mssg += "Post Graduate Training2 or Place2" + "\n";
                    }
                    if ((!String.IsNullOrEmpty(comboPostGrad3.Text) && String.IsNullOrEmpty(comboPostGradP3.Text))
                        || (String.IsNullOrEmpty(comboPostGrad3.Text) && !String.IsNullOrEmpty(comboPostGradP3.Text)))
                    {
                        CANSAVE = false;
                        mssg += "Post Graduate Training3 or Place3" + "\n";
                    }
                    //eProfil//
                    if ((!String.IsNullOrEmpty(ep1.Text) && String.IsNullOrEmpty(epl1.Text))
                        || (String.IsNullOrEmpty(ep1.Text) && !String.IsNullOrEmpty(epl1.Text)))
                    {
                        CANSAVE = false;
                        mssg += "eProfile1 or Link1" + "\n";
                    }
                    if ((!String.IsNullOrEmpty(ep2.Text) && String.IsNullOrEmpty(epl2.Text))
                        || (String.IsNullOrEmpty(ep2.Text) && !String.IsNullOrEmpty(epl2.Text)))
                    {
                        CANSAVE = false;
                        mssg += "eProfile2 or Link2" + "\n";
                    }
                    if ((!String.IsNullOrEmpty(ep3.Text) && String.IsNullOrEmpty(epl3.Text))
                        || (String.IsNullOrEmpty(ep3.Text) && !String.IsNullOrEmpty(epl3.Text)))
                    {
                        CANSAVE = false;
                        mssg += "eProfile3 or Link3" + "\n";
                    }

                    //////////////////CANSAVE//////////////////
                    //    string mssgyellow="";
                    //    string mssg="";
                    if (CANSAVE == true)
                    {
                        if (yellowfields == false)
                        {
                            mssgyellow += "Warning we will save but you have not filled  : \n";

                            foreach (var i in notmandatory)
                            {
                                mssgyellow += i.Value + "\n";
                            }
                            mssg += mssgyellow;
                        }

                        //Sleep//
                        var sleep = false;
                        var sleepCom = "";
                        if (checkSleep.Checked)
                        {
                            sleep = true;
                            sleepCom = textSleepComment.Text;
                        }

                        //Title//
                        var title = false;
                        if (comboTitle.Text == "Mr.")
                            title = true;

                        //LastName//
                        var lastName = comboName.Text;

                        //Prenom//
                        var firstName = textPrenom.Text;

                        //Gender//
                        var gender = 0;
                        if (soft.CV_GENDER.Where(a => a.Gender == comboGender.Text).Count() != 0)
                        {
                            gender = soft.CV_GENDER.Where(a => a.Gender == comboGender.Text).FirstOrDefault().IDGender;
                        }

                        //DateCV//
                        DateTime datecv = new DateTime();
                        if (!String.IsNullOrEmpty(textdateCV.Text))
                            datecv = DateTime.Parse(textdateCV.Text).Date;

                        //Birthday//
                        DateTime birtDay = new DateTime();
                        if (!String.IsNullOrEmpty(textdateBirthDay.Text))
                            birtDay = DateTime.Parse(textdateBirthDay.Text).Date;
                        //DateTime birtDay = DateTime.Parse(textdateBirthDay.Text).Date;
                        //DateTime birtDay = dateBirthDay.Value.Date;

                        //Adress1//
                        var adress1 = textAdress1.Text;

                        //ZipCode//
                        var zipCode = textZipCode.Text;

                        //Nationality//
                        var nationality = 0;
                        if (!String.IsNullOrEmpty(comboNationality.Text))
                        {
                            if (soft.CV_NATIONS.Where(a => a.Country == comboNationality.Text).Count() != 0)
                            {
                                nationality = soft.CV_NATIONS.Where(a => a.Country == comboNationality.Text).FirstOrDefault().IDCountry;
                            }
                        }

                        //Adress2//
                        var adress2 = textAdress2.Text;
                        //Adress3//
                        var adress3 = textAdress3.Text;

                        //Cat//
                        var cat = 0;
                        if (!String.IsNullOrEmpty(comboCat.Text))
                        {
                            if (soft.CV_CATEGORY.Where(a => a.Category == comboCat.Text).Count() != 0)
                            {
                                cat = soft.CV_CATEGORY.Where(a => a.Category == comboCat.Text).FirstOrDefault().IDCat;
                            }
                        }

                        //Given Age//
                        var givenAge = 0;
                        if (String.IsNullOrEmpty(textdateBirthDay.Text))
                        {
                            if (!String.IsNullOrEmpty(textGivenAge.Text))
                            {
                                givenAge = int.Parse(textGivenAge.Text);
                            }
                        }

                        //Country//
                        var country = 0;
                        if (!String.IsNullOrEmpty(comboCountry.Text))
                        {
                            if (soft.CV_NATIONS.Where(a => a.Country == comboCountry.Text).Count() != 0)
                            {
                                country = soft.CV_NATIONS.Where(a => a.Country == comboCountry.Text).FirstOrDefault().IDCountry;
                            }
                        }

                        //TOWN//
                        var twn = 0;
                        if (!String.IsNullOrEmpty(comboTOWN.Text))
                        {
                            if (soft.CV_TOWNS.Where(a => a.TOWN == comboTOWN.Text).Count() != 0)
                            {
                                twn = soft.CV_TOWNS.Where(a => a.TOWN == comboTOWN.Text).FirstOrDefault().ID;
                            }
                        }

                        //Mobil//
                        var mobil = textMobilPhone.Text;
                        //Mobil2//
                        var mobil2 = textMobilPhone2.Text;

                        //Email1//
                        var email1 = textMail1.Text;

                        //PersTPH//
                        var persTPH = 0;
                        if (!String.IsNullOrEmpty(comboPersTPH.Text))
                        {
                            if (soft.CV_EMPLOYEE.Where(a => a.PersRef == comboPersTPH.Text).Count() != 0)
                            {
                                persTPH = soft.CV_EMPLOYEE.Where(a => a.PersRef == comboPersTPH.Text).FirstOrDefault().IDPersRef;
                            }
                        }

                        //Landlinephone//
                        var landPhone = textLandlinePhone.Text;

                        //Email2//
                        var email2 = textMail2.Text;

                        //SKYPE//
                        var skype = textSkype.Text;

                        //DailyFees//
                        var dailyFee = textDailyFees.Text;

                        //DateIntefview//
                        DateTime interview = new DateTime();
                        if (!String.IsNullOrEmpty(textdateInterview.Text))
                            interview = DateTime.Parse(textdateInterview.Text).Date;
                        //DateTime interview = DateTime.Parse(textdateInterview.Text).Date;

                        //ShortListed//
                        var shortL = false;
                        if (comboShortListed.Text == "YES")
                        {
                            shortL = true;
                        }

                        //JUNSEN//
                        var junsen = 0;
                        if (!String.IsNullOrEmpty(comboJunSenior.Text))
                        {
                            if (soft.CV_JUNSENIOR.Where(a => a.JunSenior == comboJunSenior.Text).Count() != 0)
                            {
                                junsen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == comboJunSenior.Text).FirstOrDefault().IDJunSenior;
                            }
                        }

                        //Commentaire//
                        var commentaire = textComCV.Text;
                        DialogResult result = new DialogResult();
                        //Commentaire//
                        //var why = textWhy.Text;
                        if (!yellowfields)
                        {
                            result = MessageBox.Show(mssgyellow, "CVBASE", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        }

                        if (result == DialogResult.OK || yellowfields == true)
                        {
                            /////INSERTION/////
                            if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() == 0)
                            {
                                var cv = new CV_CVBASE
                                {
                                    Sleep = sleep,
                                    SleepComments = sleepCom,
                                    Title = title,
                                    LastName = lastName,
                                    FirstName = firstName,
                                    IDGender = gender,
                                    Adress1 = adress1,
                                    Adress2 = adress2,
                                    Adress3 = adress3,
                                    ZipCode = zipCode,
                                    IDNationality = nationality,
                                    IDTOWN = twn,
                                    IDCat = cat,
                                    IDCountry = country,
                                    MobilPhone = mobil,
                                    MobilPhone2 = mobil2,
                                    LandlinePhone = landPhone,
                                    Email1 = email1,
                                    Email2 = email2,
                                    IDPersRef = persTPH,
                                    ExpDailyFees = dailyFee,
                                    ShortListed = shortL,
                                    IDJunSenior = junsen,
                                    Comments = commentaire,
                                    GivenAge = givenAge,
                                    DateSave = DateTime.Now.Date,
                                    WEB = false,
                                    Skype = skype
                                    //WHY = why
                                };
                                soft.CV_CVBASE.Add(cv);
                                soft.SaveChanges();

                                var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();
                                //Update ALL DATE//
                                if (!String.IsNullOrEmpty(textdateCV.Text))
                                    isForModif.DateCV = datecv;
                                if (!String.IsNullOrEmpty(textdateBirthDay.Text))
                                    isForModif.BirthDay = birtDay;
                                if (!String.IsNullOrEmpty(textdateInterview.Text))
                                    isForModif.DateSPMU = interview;

                                soft.SaveChanges();

                                //Insert ALL OTHERS//
                                AllOthers(isForModif.IDCV);
                                AllValue();
                            }

                            /////UPDATE/////
                            else
                            {
                                var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                                isForModif.Sleep = sleep;
                                isForModif.SleepComments = sleepCom;
                                isForModif.Title = title;
                                isForModif.FirstName = firstName;
                                isForModif.IDGender = gender;
                                isForModif.Adress1 = adress1;
                                isForModif.Adress2 = adress2;
                                isForModif.Adress3 = adress3;
                                isForModif.ZipCode = zipCode;
                                isForModif.IDNationality = nationality;
                                isForModif.IDTOWN = twn;
                                isForModif.IDCat = cat;
                                isForModif.IDCountry = country;
                                isForModif.MobilPhone = mobil;
                                isForModif.MobilPhone2 = mobil2;
                                isForModif.LandlinePhone = landPhone;
                                isForModif.Email1 = email1;
                                isForModif.Email2 = email2;
                                isForModif.IDPersRef = persTPH;
                                isForModif.ExpDailyFees = dailyFee;
                                isForModif.ShortListed = shortL;
                                isForModif.IDJunSenior = junsen;
                                isForModif.Comments = commentaire;
                                //isForModif.WHY = why;
                                isForModif.GivenAge = givenAge;
                                isForModif.Skype = skype;

                                //Update ALL DATE//
                                if (!String.IsNullOrEmpty(textdateCV.Text))
                                    isForModif.DateCV = datecv;
                                else
                                    isForModif.DateCV = null;
                                if (!String.IsNullOrEmpty(textdateBirthDay.Text))
                                    isForModif.BirthDay = birtDay;
                                else
                                    isForModif.BirthDay = null;
                                if (!String.IsNullOrEmpty(textdateInterview.Text))
                                    isForModif.DateSPMU = interview;
                                else
                                    isForModif.DateSPMU = null;

                                soft.SaveChanges();

                                //Delete ALL OTHERS//
                                //DOC//
                                if (soft.CV_DOC.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_DOC.Where(a => a.IDCV == isForModif.IDCV).ToList())
                                    {
                                        //var docForDelete = soft.CV_DOC.Where(a => a.IDCV == x.IDCV).FirstOrDefault();
                                        soft.CV_DOC.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //DOCDATECOM//
                                if (soft.CV_DOCDATECOMM.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_DOCDATECOMM.Where(a => a.IDCV == isForModif.IDCV).ToList())
                                    {
                                        soft.CV_DOCDATECOMM.Remove(x);
                                        soft.SaveChanges();
                                    }

                                }

                                //EDUC//
                                if (soft.CV_EDUC.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_EDUC.Where(a => a.IDCV == isForModif.IDCV).ToList())
                                    {
                                        soft.CV_EDUC.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //GRAD//
                                if (soft.CV_GRAD.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_GRAD.Where(a => a.IDCV == isForModif.IDCV).ToList())
                                    {
                                        soft.CV_GRAD.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //LANGUAGE//
                                if (soft.CV_WRSP.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_WRSP.Where(a => a.IDCV == isForModif.IDCV).ToList())
                                    {
                                        soft.CV_WRSP.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //INTLEXPTECH//
                                if (soft.CV_INTLEXPTECH.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_INTLEXPTECH.Where(a => a.IDCV == isForModif.IDCV).ToList())
                                    {
                                        soft.CV_INTLEXPTECH.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //INTLREGEXP//
                                if (soft.CV_INTLREGEXP.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_INTLREGEXP.Where(a => a.IDCV == isForModif.IDCV).ToList())
                                    {
                                        soft.CV_INTLREGEXP.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //INTLCOMMENTS//
                                if (soft.CV_INTLCOMMENT.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_INTLCOMMENT.Where(a => a.IDCV == isForModif.IDCV).ToList())
                                    {
                                        soft.CV_INTLCOMMENT.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //NOTECRITERIA//
                                if (soft.CV_NOTECRITERIA.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_NOTECRITERIA.Where(a => a.IDCV == isForModif.IDCV).ToList())
                                    {
                                        soft.CV_NOTECRITERIA.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //EXPSWTPH//
                                if (soft.CV_EXPSWTPH.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    foreach (var x in soft.CV_EXPSWTPH.Where(a => a.IDCV == isForModif.IDCV).ToList())
                                    {
                                        soft.CV_EXPSWTPH.Remove(x);
                                        soft.SaveChanges();
                                    }
                                }

                                //EXPCOMMENT//
                                if (soft.CV_EXPCOMMENT.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    var ExpForDelete = soft.CV_EXPCOMMENT.Where(a => a.IDCV == isForModif.IDCV).FirstOrDefault();
                                    soft.CV_EXPCOMMENT.Remove(ExpForDelete);
                                    soft.SaveChanges();
                                }

                                //VISITPMU//
                                if (soft.CV_VISITSPMU.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    var VisitForDelete = soft.CV_VISITSPMU.Where(a => a.IDCV == isForModif.IDCV).FirstOrDefault();
                                    soft.CV_VISITSPMU.Remove(VisitForDelete);
                                    soft.SaveChanges();
                                }

                                //Eprofil//
                                if (soft.CV_EPRO.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    var epForDelete = soft.CV_EPRO.Where(a => a.IDCV == isForModif.IDCV).FirstOrDefault();
                                    soft.CV_EPRO.Remove(epForDelete);
                                    soft.SaveChanges();
                                }

                                //Eprofil Web link//
                                if (soft.CV_EPROWL.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    var epwForDelete = soft.CV_EPROWL.Where(a => a.IDCV == isForModif.IDCV).FirstOrDefault();
                                    soft.CV_EPROWL.Remove(epwForDelete);
                                    soft.SaveChanges();
                                }

                                //ON chat//
                                if (soft.CV_ONCHAT.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    var onchatForDelete = soft.CV_ONCHAT.Where(a => a.IDCV == isForModif.IDCV).FirstOrDefault();
                                    soft.CV_ONCHAT.Remove(onchatForDelete);
                                    soft.SaveChanges();
                                }

                                //ON chat avatar//
                                if (soft.CV_ONCHATAVA.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    var onchatavaForDelete = soft.CV_ONCHATAVA.Where(a => a.IDCV == isForModif.IDCV).FirstOrDefault();
                                    soft.CV_ONCHATAVA.Remove(onchatavaForDelete);
                                    soft.SaveChanges();
                                }

                                //Insert ALL OTHERS//
                                AllOthers(isForModif.IDCV);
                                AllValue();
                            }

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            previousToolStripMenuItem.Enabled = true;
                            nextToolStripMenuItem.Enabled = true;
                        }
                        /*       if (yellowfields == false)
                               {
                                   MessageBox.Show(mssgyellow, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                               }
                               else
                               {
                                   MessageBox.Show("Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                               }
                           */

                        //LastName//
                        List<String> itmName = new List<String>();
                        itmName.Add("");
                        int isco = Token.getisCO();
                        var iscoJun = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;
                        var idJunSen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == iscoJun).FirstOrDefault().IDJunSenior;

                        if (soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior == "ALL")
                        {
                            if (soft.CV_CVBASE.Count() != 0)
                            {
                                foreach (var x in soft.CV_CVBASE.Select(a => a.LastName).OrderBy(a => a).ToList())
                                {
                                    itmName.Add(x);
                                }
                            }
                            comboName.DataSource = itmName;
                            comboName.SelectedItem = lastName;
                        }
                        else
                        {
                            var isForDataSet = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior;
                            foreach (var x in soft.CV_JUNSENIOR.Where(a => a.JunSenior.ToUpper().Contains(isForDataSet.ToUpper())).ToList())
                            {
                                foreach (var y in soft.CV_CVBASE.Where(a => a.IDJunSenior == x.IDJunSenior).Select(a => a.LastName).OrderBy(a => a).ToList())
                                {
                                    itmName.Add(y);
                                }
                            }
                            comboName.DataSource = itmName;
                            comboName.SelectedItem = lastName;

                            if (!comboJunSenior.Text.ToUpper().Contains(isForDataSet.ToUpper()))
                            {
                                comboName.Focus();
                                comboName.Text = null;
                                checkNoteGlobal.Checked = false;
                                InitialCVNEW();
                                comboName.SelectedItem = "";
                            }
                        }
                    }
                    else
                        MessageBox.Show(mssg, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //  string mssgyellow = "";
                    //   yellowfield();
                    string message = "Yellow fields must be filled in!";
                    foreach (var i in mandatory)
                    {
                        message += "\n" + i.Value;
                    }

                    /*     if (yellowfields == false)
                         {
                             mssgyellow += "\n You have forget : \n";

                             foreach (var i in notmandatory)
                             {
                                 mssgyellow += "\n" + i.Value;
                             }
                             message += mssgyellow;
                         }*/
                    MessageBox.Show(message, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void AllOthers(int IDCV)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                //DOC//
                //1//
                if (!String.IsNullOrEmpty(comboDoc1.Text))
                {
                    CV_DOC newDoc = new CV_DOC();
                    var doc = soft.CV_DOCUMENT.Where(a => a.Docum == comboDoc1.Text).FirstOrDefault().IDDoc;
              
                     newDoc = new CV_DOC
                    {
                        IDDoc = doc,
                        Link = textDocLink1.Text,
                        IDCV = IDCV,
                        NUM = 1
                    };
                    soft.CV_DOC.Add(newDoc);
                    soft.SaveChanges();
                }
              
                //2//
                if (!String.IsNullOrEmpty(comboDoc2.Text))
                {
                    var doc2 = soft.CV_DOCUMENT.Where(a => a.Docum == comboDoc2.Text).FirstOrDefault().IDDoc;
                    var newDoc2 = new CV_DOC
                    {
                        IDDoc = doc2,
                        Link = textDocLink2.Text,
                        IDCV = IDCV,
                        NUM = 2
                    };
                    soft.CV_DOC.Add(newDoc2);
                    soft.SaveChanges();
                }
                
                //3//
                if (!String.IsNullOrEmpty(comboDoc3.Text))
                {
                    var doc3 = soft.CV_DOCUMENT.Where(a => a.Docum == comboDoc3.Text).FirstOrDefault().IDDoc;
                    var newDoc3 = new CV_DOC
                    {
                        IDDoc = doc3,
                        Link = textDocLink3.Text,
                        IDCV = IDCV,
                        NUM = 3
                    };
                    soft.CV_DOC.Add(newDoc3);
                    soft.SaveChanges();
                }
                
                //4//
                if (!String.IsNullOrEmpty(comboDoc4.Text))
                {
                    var doc4 = soft.CV_DOCUMENT.Where(a => a.Docum == comboDoc4.Text).FirstOrDefault().IDDoc;
                    var newDoc4 = new CV_DOC
                    {
                        IDDoc = doc4,
                        Link = textDocLink4.Text,
                        IDCV = IDCV,
                        NUM = 4
                    };
                    soft.CV_DOC.Add(newDoc4);
                    soft.SaveChanges();
                }
                
                //5//
                if (!String.IsNullOrEmpty(comboDoc5.Text))
                {
                    var doc5 = soft.CV_DOCUMENT.Where(a => a.Docum == comboDoc5.Text).FirstOrDefault().IDDoc;
                    var newDoc5 = new CV_DOC
                    {
                        IDDoc = doc5,
                        Link = textDocLink5.Text,
                        IDCV = IDCV,
                        NUM = 5
                    };
                    soft.CV_DOC.Add(newDoc5);
                    soft.SaveChanges();
                }
                
                //6//
                if (!String.IsNullOrEmpty(comboDoc6.Text))
                {
                    var doc6 = soft.CV_DOCUMENT.Where(a => a.Docum == comboDoc6.Text).FirstOrDefault().IDDoc;
                    var newDoc6 = new CV_DOC
                    {
                        IDDoc = doc6,
                        Link = textDocLink6.Text,
                        IDCV = IDCV,
                        NUM = 6
                    };
                    soft.CV_DOC.Add(newDoc6);
                    soft.SaveChanges();
                }
                
                //DOCDATECOM//
                if (String.IsNullOrEmpty(textdateLastRequest.Text))
                {
                    var newComBon = new CV_DOCDATECOMM
                    {
                        UpdateCV = null,
                        BONUS = int.Parse(textBonusDoc.Text),
                        Comments = textComBonus.Text,
                        IDCV = IDCV
                    };
                    soft.CV_DOCDATECOMM.Add(newComBon);
                    soft.SaveChanges();
                }
                /*else
                {
                    var newComBon = new CV_DOCDATECOMM
                    {
                        //UpdateCV = null,
                        BONUS = int.Parse(textBonusDoc.Text),
                        Comments = textComBonus.Text,
                        IDCV = IDCV
                    };
                    soft.CV_DOCDATECOMM.Add(newComBon);
                    soft.SaveChanges();
                }*/

                //EDUC//
                //1//
                if (!String.IsNullOrEmpty(comboDipl1.Text))
                {
                    int years = 0;

                    int.TryParse(textDiplY1.Text, out years);
                   
                    var dipl = soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl1.Text).FirstOrDefault().IDDiploma;
                
                    var spec = soft.CV_SPECIALITY.Where(a => a.Speciality == comboSpecDipl1.Text).FirstOrDefault().IDSpeciality;
                    var place = soft.CV_PLACE.Where(a => a.Place == comboDiplP1.Text).FirstOrDefault().IDPlace;
                    var newDip = new CV_EDUC
                    {
                        IDDiploma = dipl,
                        IDSpeciality = spec,
                        IDCV = IDCV,
                        IDPlace = place,
                        Years = years,
                        NUM = 1
                    };
                    soft.CV_EDUC.Add(newDip);
                    soft.SaveChanges();
                }
             
             //   var years = int.Parse(textDiplY1.Text);

                //2//
                if (!String.IsNullOrEmpty(comboDipl2.Text))
                {
                    var dipl2 = soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl2.Text).FirstOrDefault().IDDiploma;
                    var spec2 = soft.CV_SPECIALITY.Where(a => a.Speciality == comboSpecDipl2.Text).FirstOrDefault().IDSpeciality;
                    var place2 = soft.CV_PLACE.Where(a => a.Place == comboDiplP2.Text).FirstOrDefault().IDPlace;
                  //  var years2 = int.Parse(textDiplY2.Text);
                    int years2 = 0;

                    int.TryParse(textDiplY2.Text, out years2);
                    var newDip2 = new CV_EDUC
                    {
                        IDDiploma = dipl2,
                        IDSpeciality = spec2,
                        IDCV = IDCV,
                        IDPlace = place2,
                        Years = years2,
                        NUM = 2
                    };
                    soft.CV_EDUC.Add(newDip2);
                    soft.SaveChanges();
                }
               
                //3//
                if (!String.IsNullOrEmpty(comboDipl3.Text))
                {
                    var dipl3 = soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl3.Text).FirstOrDefault().IDDiploma;
                    var spec3 = soft.CV_SPECIALITY.Where(a => a.Speciality == comboSpecDipl3.Text).FirstOrDefault().IDSpeciality;
                    var place3 = soft.CV_PLACE.Where(a => a.Place == comboDiplP3.Text).FirstOrDefault().IDPlace;
                   // var years3 = int.Parse(textDiplY3.Text);
                    int years3 = 0;

                    int.TryParse(textDiplY3.Text, out years3);
                    var newDip3 = new CV_EDUC
                    {
                        IDDiploma = dipl3,
                        IDSpeciality = spec3,
                        IDCV = IDCV,
                        IDPlace = place3,
                        Years = years3,
                        NUM = 3
                    };
                    soft.CV_EDUC.Add(newDip3);
                    soft.SaveChanges();
                }
                
                //GRAD//
                //1//
                if (!String.IsNullOrEmpty(comboPostGrad1.Text))
                {
                    var grad = soft.CV_GRADUATE.Where(a => a.Graduate == comboPostGrad1.Text).FirstOrDefault().IDGraduate;
                    var placeg = soft.CV_PLACE.Where(a => a.Place == comboPostGradP1.Text).FirstOrDefault().IDPlace;
                 //   var yearsg = int.Parse(textPostGradY1.Text);
                    int yearsg = 0;

                    int.TryParse(textPostGradY1.Text, out yearsg);
                    var newGrad = new CV_GRAD
                    {
                        IDGraduate = grad,
                        IDCV = IDCV,
                        IDPlace = placeg,
                        Years = yearsg,
                        NUM = 1
                    };
                    soft.CV_GRAD.Add(newGrad);
                    soft.SaveChanges();
                }
                
                //2//
                if (!String.IsNullOrEmpty(comboPostGrad2.Text))
                {
                    var grad2 = soft.CV_GRADUATE.Where(a => a.Graduate == comboPostGrad2.Text).FirstOrDefault().IDGraduate;
                    var placeg2 = soft.CV_PLACE.Where(a => a.Place == comboPostGradP2.Text).FirstOrDefault().IDPlace;
                  //  var yearsg2 = int.Parse(textPostGradY2.Text);
                    int yearsg2 = 0;

                    int.TryParse(textPostGradY2.Text, out yearsg2);
                    var newGrad2 = new CV_GRAD
                    {
                        IDGraduate = grad2,
                        IDCV = IDCV,
                        IDPlace = placeg2,
                        Years = yearsg2,
                        NUM = 2
                    };
                    soft.CV_GRAD.Add(newGrad2);
                    soft.SaveChanges();
                }
                
                //3//
                if (!String.IsNullOrEmpty(comboPostGrad3.Text))
                {
                    var grad3 = soft.CV_GRADUATE.Where(a => a.Graduate == comboPostGrad3.Text).FirstOrDefault().IDGraduate;
                    var placeg3 = soft.CV_PLACE.Where(a => a.Place == comboPostGradP3.Text).FirstOrDefault().IDPlace;
                 //   var yearsg3 = int.Parse(textPostGradY3.Text);
                    int yearsg3 = 0;

                    int.TryParse(textPostGradY3.Text, out yearsg3);
                    var newGrad3 = new CV_GRAD
                    {
                        IDGraduate = grad3,
                        IDCV = IDCV,
                        IDPlace = placeg3,
                        Years = yearsg3,
                        NUM = 3
                    };
                    soft.CV_GRAD.Add(newGrad3);
                    soft.SaveChanges();
                }
                
                //LANGUAGE//
                //1//
                if (!String.IsNullOrEmpty(comboLang1.Text))
                {
                    var lang = soft.CV_LANGUAGE.Where(a => a.Language == comboLang1.Text).FirstOrDefault().IDLanguage;

                    var langW = 0;
                    if (!String.IsNullOrEmpty(comboLangW1.Text) && soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangW1.Text).Count() != 0)
                        langW = soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangW1.Text).FirstOrDefault().IDWrSp;

                    var langS = 0;
                    if (!String.IsNullOrEmpty(comboLangS1.Text) && soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangS1.Text).Count() != 0)
                        langS = soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangS1.Text).FirstOrDefault().IDWrSp;

                    var newLang = new CV_WRSP
                    {
                        IDLanguage = lang,
                        IDSp = langS,
                        IDWr = langW,
                        IDCV = IDCV,
                        NUM = 1
                    };
                    soft.CV_WRSP.Add(newLang);
                    soft.SaveChanges();
                }

                //2//
                if (!String.IsNullOrEmpty(comboLang2.Text))
                {
                    var lang = soft.CV_LANGUAGE.Where(a => a.Language == comboLang2.Text).FirstOrDefault().IDLanguage;

                    var langW = 0;
                    if (!String.IsNullOrEmpty(comboLangW2.Text) && soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangW2.Text).Count() != 0)
                        langW = soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangW2.Text).FirstOrDefault().IDWrSp;

                    var langS = 0;
                    if (!String.IsNullOrEmpty(comboLangS2.Text) && soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangS2.Text).Count() != 0)
                        langS = soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangS2.Text).FirstOrDefault().IDWrSp;

                    var newLang = new CV_WRSP
                    {
                        IDLanguage = lang,
                        IDSp = langS,
                        IDWr = langW,
                        IDCV = IDCV,
                        NUM = 2
                    };
                    soft.CV_WRSP.Add(newLang);
                    soft.SaveChanges();
                }

                //3//
                if (!String.IsNullOrEmpty(comboLang3.Text))
                {
                    var lang = soft.CV_LANGUAGE.Where(a => a.Language == comboLang3.Text).FirstOrDefault().IDLanguage;

                    var langW = 0;
                    if (!String.IsNullOrEmpty(comboLangW3.Text) && soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangW3.Text).Count() != 0)
                        langW = soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangW3.Text).FirstOrDefault().IDWrSp;

                    var langS = 0;
                    if (!String.IsNullOrEmpty(comboLangS3.Text) && soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangS3.Text).Count() != 0)
                        langS = soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangS3.Text).FirstOrDefault().IDWrSp;

                    var newLang = new CV_WRSP
                    {
                        IDLanguage = lang,
                        IDSp = langS,
                        IDWr = langW,
                        IDCV = IDCV,
                        NUM = 3
                    };
                    soft.CV_WRSP.Add(newLang);
                    soft.SaveChanges();
                }

                //4//
                if (!String.IsNullOrEmpty(comboLang4.Text))
                {
                    var lang = soft.CV_LANGUAGE.Where(a => a.Language == comboLang4.Text).FirstOrDefault().IDLanguage;

                    var langW = 0;
                    if (!String.IsNullOrEmpty(comboLangW4.Text) && soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangW4.Text).Count() != 0)
                        langW = soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangW4.Text).FirstOrDefault().IDWrSp;

                    var langS = 0;
                    if (!String.IsNullOrEmpty(comboLangS4.Text) && soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangS4.Text).Count() != 0)
                        langS = soft.CV_WRSPLEVEL.Where(a => a.WrSp == comboLangS4.Text).FirstOrDefault().IDWrSp;

                    var newLang = new CV_WRSP
                    {
                        IDLanguage = lang,
                        IDSp = langS,
                        IDWr = langW,
                        IDCV = IDCV,
                        NUM = 4
                    };
                    soft.CV_WRSP.Add(newLang);
                    soft.SaveChanges();
                }


                //INTLEXPTECH//
                //1//
                if (!String.IsNullOrEmpty(comboTechField1.Text))
                {
                    var tf = soft.CV_TECHNICFIELD.Where(a => a.TechnicField == comboTechField1.Text).FirstOrDefault().IDTechField;

                    var yearsi = 0;
                    if (!String.IsNullOrEmpty(textTFYears1.Text))
                        yearsi = int.Parse(textTFYears1.Text);

                    var tfy = new CV_INTLEXPTECH
                    {
                        IDTechField = tf,
                        NbYear = yearsi,
                        IDCV = IDCV,
                        NUM = 1
                    };
                    soft.CV_INTLEXPTECH.Add(tfy);
                    soft.SaveChanges();
                }

                //2//
                if (!String.IsNullOrEmpty(comboTechField2.Text))
                {
                    var tf = soft.CV_TECHNICFIELD.Where(a => a.TechnicField == comboTechField2.Text).FirstOrDefault().IDTechField;

                    var yearsi = 0;
                    if (!String.IsNullOrEmpty(textTFYears2.Text))
                        yearsi = int.Parse(textTFYears2.Text);

                    var tfy = new CV_INTLEXPTECH
                    {
                        IDTechField = tf,
                        NbYear = yearsi,
                        IDCV = IDCV,
                        NUM = 2
                    };
                    soft.CV_INTLEXPTECH.Add(tfy);
                    soft.SaveChanges();
                }

                //3//
                if (!String.IsNullOrEmpty(comboTechField3.Text))
                {
                    var tf = soft.CV_TECHNICFIELD.Where(a => a.TechnicField == comboTechField3.Text).FirstOrDefault().IDTechField;

                    var yearsi = 0;
                    if (!String.IsNullOrEmpty(textTFYears3.Text))
                        yearsi = int.Parse(textTFYears3.Text);

                    var tfy = new CV_INTLEXPTECH
                    {
                        IDTechField = tf,
                        NbYear = yearsi,
                        IDCV = IDCV,
                        NUM = 3
                    };
                    soft.CV_INTLEXPTECH.Add(tfy);
                    soft.SaveChanges();
                }

                //INTLREGEXP//
                //1//
                if (!String.IsNullOrEmpty(comboRegion1.Text))
                {
                    var tr = soft.CV_REGION.Where(a => a.Region == comboRegion1.Text).FirstOrDefault().IDRegion;

                    var yearsr = 0;
                    if (!String.IsNullOrEmpty(textRYears1.Text))
                        yearsr = int.Parse(textRYears1.Text);

                    var tri = new CV_INTLREGEXP
                    {
                        IDRegion = tr,
                        NbYear = yearsr,
                        IDCV = IDCV,
                        NUM = 1
                    };
                    soft.CV_INTLREGEXP.Add(tri);
                    soft.SaveChanges();
                }

                //2//
                if (!String.IsNullOrEmpty(comboRegion2.Text))
                {
                    var tr = soft.CV_REGION.Where(a => a.Region == comboRegion2.Text).FirstOrDefault().IDRegion;

                    var yearsr = 0;
                    if (!String.IsNullOrEmpty(textRYears2.Text))
                        yearsr = int.Parse(textRYears2.Text);

                    var tri = new CV_INTLREGEXP
                    {
                        IDRegion = tr,
                        NbYear = yearsr,
                        IDCV = IDCV,
                        NUM = 2
                    };
                    soft.CV_INTLREGEXP.Add(tri);
                    soft.SaveChanges();
                }

                //3//
                if (!String.IsNullOrEmpty(comboRegion3.Text))
                {
                    var tr = soft.CV_REGION.Where(a => a.Region == comboRegion3.Text).FirstOrDefault().IDRegion;

                    var yearsr = 0;
                    if (!String.IsNullOrEmpty(textRYears3.Text))
                        yearsr = int.Parse(textRYears3.Text);

                    var tri = new CV_INTLREGEXP
                    {
                        IDRegion = tr,
                        NbYear = yearsr,
                        IDCV = IDCV,
                        NUM = 3
                    };
                    soft.CV_INTLREGEXP.Add(tri);
                    soft.SaveChanges();
                }


                //INTLCOMMENTS//
                if (!String.IsNullOrEmpty(textINTLExpComm.Text))
                {
                    var newComINTL = new CV_INTLCOMMENT
                    {
                        Comments = textINTLExpComm.Text,
                        IDCV = IDCV
                    };
                    soft.CV_INTLCOMMENT.Add(newComINTL);
                    soft.SaveChanges();
                }

                //NOTECRITERIA//
                var cr1 = 0;
                if (!String.IsNullOrEmpty(textCRYears1.Text))
                    cr1 = int.Parse(textCRYears1.Text);
                var cr2 = 0;
                if (!String.IsNullOrEmpty(textCRYears2.Text))
                    cr2 = int.Parse(textCRYears2.Text);
                var cr3 = 0;
                if (!String.IsNullOrEmpty(textCRYears3.Text))
                    cr3 = int.Parse(textCRYears3.Text);
                var cr4 = 0;
                if (!String.IsNullOrEmpty(textCRYears4.Text))
                    cr4 = int.Parse(textCRYears4.Text);
                var cr5 = 0;
                if (!String.IsNullOrEmpty(textCRYears5.Text))
                    cr5 = int.Parse(textCRYears5.Text);

                var crNoteCR = new CV_NOTECRITERIA
                {
                    N1 = cr1,
                    N2 = cr2,
                    N3 = cr3,
                    N4 = cr4,
                    N5 = cr5,
                    IDCV = IDCV
                };

                soft.CV_NOTECRITERIA.Add(crNoteCR);
                soft.SaveChanges();

                //EXPSWTPH//
                //1//
                if (!String.IsNullOrEmpty(textdateSDWork1.Text))
                {
                    //Startdate//
                    DateTime str = new DateTime();
                    if (!String.IsNullOrEmpty(textdateSDWork1.Text))
                        str = DateTime.Parse(textdateSDWork1.Text).Date;
                    //var str = DateTime.Parse(textdateSDWork1.Text).Date;

                    //Duration week//
                    var dur = 0;
                    if (!String.IsNullOrEmpty(textDurWeek1.Text))
                    {
                        dur = int.Parse(textDurWeek1.Text);
                    }

                    //schi unit//
                    var schi = 0;
                    if (!String.IsNullOrEmpty(comboSCHI1.Text) && soft.CV_UNIT.Where(a => a.Unit == comboSCHI1.Text).Count() != 0)
                    {
                        schi = soft.CV_UNIT.Where(a => a.Unit == comboSCHI1.Text).FirstOrDefault().IDSCIHUnit;
                    }

                    //Role//
                    var role = 0;
                    if (!String.IsNullOrEmpty(comboRole1.Text) && soft.CV_ROLE.Where(a => a.Role == comboRole1.Text).Count() != 0)
                    {
                        role = soft.CV_ROLE.Where(a => a.Role == comboRole1.Text).FirstOrDefault().IDRole;
                    }

                    //JuniorSenior//
                    var junS = 0;// soft.CV_JUNSENIOR.Where(a => a.JunSenior == "TBD").FirstOrDefault().IDJunSenior;
                    if (!String.IsNullOrEmpty(comboJunSen1.Text) && soft.CV_JUNSENIOR.Where(a => a.JunSenior == comboJunSen1.Text).Count() != 0)
                    {
                        junS = soft.CV_JUNSENIOR.Where(a => a.JunSenior == comboJunSen1.Text).FirstOrDefault().IDJunSenior;
                    }

                    //Main Sup//
                    var mainSup = 0;
                    if (!String.IsNullOrEmpty(comboMainSup1.Text) && soft.CV_EMPLOYEE.Where(a => a.PersRef == comboMainSup1.Text).Count() != 0)
                    {
                        mainSup = soft.CV_EMPLOYEE.Where(a => a.PersRef == comboMainSup1.Text).FirstOrDefault().IDPersRef;
                    }

                    //Appreciation//
                    var appress = textAppr1.Text;

                    //Client//
                    var clt = 0;
                    if (!String.IsNullOrEmpty(comboClt1.Text) && soft.CV_CLIENT.Where(a => a.Client == comboClt1.Text).Count() != 0)
                    {
                        clt = soft.CV_CLIENT.Where(a => a.Client == comboClt1.Text).FirstOrDefault().IDClient;
                    }

                    //Domaine//
                    var dom = 0;
                    if (!String.IsNullOrEmpty(comboDomExp1.Text) && soft.CV_TECHNICFIELD.Where(a => a.TechnicField == comboDomExp1.Text).Count() != 0)
                    {
                        dom = soft.CV_TECHNICFIELD.Where(a => a.TechnicField == comboDomExp1.Text).FirstOrDefault().IDTechField;
                    }

                    //Country//
                    var coun = 0;
                    if (!String.IsNullOrEmpty(comboCountry1.Text) && soft.CV_NATIONS.Where(a => a.Country == comboCountry1.Text).Count() != 0)
                    {
                        coun = soft.CV_NATIONS.Where(a => a.Country == comboCountry1.Text).FirstOrDefault().IDCountry;
                    }

                    //LangReport//
                    var lr = 0;
                    if (!String.IsNullOrEmpty(comboLangReport1.Text) && soft.CV_LANGUAGE.Where(a => a.Language == comboLangReport1.Text).Count() != 0)
                    {
                        lr = soft.CV_LANGUAGE.Where(a => a.Language == comboLangReport1.Text).FirstOrDefault().IDLanguage;
                    }

                    //LFA//
                    var lfaW = false;
                    if (comboLFA1.Text == "YES")
                    {
                        lfaW = true;
                    }

                    //DailyFee//
                  var  DF = "0";
                   if (!String.IsNullOrEmpty(textDailyFeePaid1.Text))
                 //       DF = int.Parse(textDailyFeePaid1.Text);
               //     int.TryParse(textDailyFeePaid1.Text, out DF);
                     DF = textDailyFeePaid1.Text;
                    //Link to main report//
                    var linkR = textLink1.Text;

                    var newExp = new CV_EXPSWTPH
                    {
                        StartDate = str,
                        Duration = dur,
                        IDSCIHUnit = schi,
                        IDRole = role,
                        IDJunSenior = junS,
                        IDPersRef = mainSup,
                        Appreciation = appress,
                        IDClient = clt,
                        IDExp = dom,
                        IDCountry = coun,
                        IDLanguage = lr,
                        LFAWork = lfaW,
                        DailyFees = DF.ToString(),
                        LinkReport = linkR,
                        IDCV = IDCV,
                        NUM = 1
                    };

                    soft.CV_EXPSWTPH.Add(newExp);
                    soft.SaveChanges();
                }

                //2//
                if (!String.IsNullOrEmpty(textdateSDWork2.Text))
                {
                    //Startdate//
                    DateTime str = new DateTime();
                    if (!String.IsNullOrEmpty(textdateSDWork2.Text))
                        str = DateTime.Parse(textdateSDWork2.Text).Date;
                    //var str = DateTime.Parse(textdateSDWork2.Text).Date;

                    //Duration week//
                    int dur = 0;
              /*      if (!String.IsNullOrEmpty(textDurWeek2.Text))
                    {
                        dur = int.Parse(textDurWeek2.Text);
                    }*/
                    int.TryParse(textDurWeek2.Text, out dur);

                    //schi unit//
                    var schi = 0;
                    if (!String.IsNullOrEmpty(comboSCHI2.Text) && soft.CV_UNIT.Where(a => a.Unit == comboSCHI2.Text).Count() != 0)
                    {
                        schi = soft.CV_UNIT.Where(a => a.Unit == comboSCHI2.Text).FirstOrDefault().IDSCIHUnit;
                    }

                    //Role//
                    var role = 0;
                    if (!String.IsNullOrEmpty(comboRole2.Text) && soft.CV_ROLE.Where(a => a.Role == comboRole2.Text).Count() != 0)
                    {
                        role = soft.CV_ROLE.Where(a => a.Role == comboRole2.Text).FirstOrDefault().IDRole;
                    }

                    //JuniorSenior//
                    var junS = 0;// soft.CV_JUNSENIOR.Where(a => a.JunSenior == "TBD").FirstOrDefault().IDJunSenior;
                    if (!String.IsNullOrEmpty(comboJunSen2.Text) && soft.CV_JUNSENIOR.Where(a => a.JunSenior == comboJunSen2.Text).Count() != 0)
                    {
                        junS = soft.CV_JUNSENIOR.Where(a => a.JunSenior == comboJunSen2.Text).FirstOrDefault().IDJunSenior;
                    }

                    //Main Sup//
                    var mainSup = 0;
                    if (!String.IsNullOrEmpty(comboMainSup2.Text) && soft.CV_EMPLOYEE.Where(a => a.PersRef == comboMainSup2.Text).Count() != 0)
                    {
                        mainSup = soft.CV_EMPLOYEE.Where(a => a.PersRef == comboMainSup2.Text).FirstOrDefault().IDPersRef;
                    }

                    //Appreciation//
                    var appress = textAppr2.Text;

                    //Client//
                    var clt = 0;
                    if (!String.IsNullOrEmpty(comboClt2.Text) && soft.CV_CLIENT.Where(a => a.Client == comboClt2.Text).Count() != 0)
                    {
                        clt = soft.CV_CLIENT.Where(a => a.Client == comboClt2.Text).FirstOrDefault().IDClient;
                    }

                    //Domaine//
                    var dom = 0;
                    if (!String.IsNullOrEmpty(comboDomExp2.Text) && soft.CV_TECHNICFIELD.Where(a => a.TechnicField == comboDomExp2.Text).Count() != 0)
                    {
                        dom = soft.CV_TECHNICFIELD.Where(a => a.TechnicField == comboDomExp2.Text).FirstOrDefault().IDTechField;
                    }

                    //Country//
                    var coun = 0;
                    if (!String.IsNullOrEmpty(comboCountry2.Text) && soft.CV_NATIONS.Where(a => a.Country == comboCountry2.Text).Count() != 0)
                    {
                        coun = soft.CV_NATIONS.Where(a => a.Country == comboCountry2.Text).FirstOrDefault().IDCountry;
                    }

                    //LangReport//
                    var lr = 0;
                    if (!String.IsNullOrEmpty(comboLangReport2.Text) && soft.CV_LANGUAGE.Where(a => a.Language == comboLangReport2.Text).Count() != 0)
                    {
                        lr = soft.CV_LANGUAGE.Where(a => a.Language == comboLangReport2.Text).FirstOrDefault().IDLanguage;
                    }

                    //LFA//
                    var lfaW = false;
                    if (comboLFA2.Text == "YES")
                    {
                        lfaW = true;
                    }

                    //DailyFee//
                    var DF = "0";
                    if (!String.IsNullOrEmpty(textDailyFeePaid2.Text))
                        DF = textDailyFeePaid2.Text;

                    //Link to main report//
                    var linkR = textLink2.Text;

                    var newExp = new CV_EXPSWTPH
                    {
                        StartDate = str,
                        Duration = dur,
                        IDSCIHUnit = schi,
                        IDRole = role,
                        IDJunSenior = junS,
                        IDPersRef = mainSup,
                        Appreciation = appress,
                        IDClient = clt,
                        IDExp = dom,
                        IDCountry = coun,
                        IDLanguage = lr,
                        LFAWork = lfaW,
                        DailyFees = DF.ToString(),
                        LinkReport = linkR,
                        IDCV = IDCV,
                        NUM = 2
                    };

                    soft.CV_EXPSWTPH.Add(newExp);
                    soft.SaveChanges();
                }

                //EXPCOMMENT//
                if (!String.IsNullOrEmpty(textExpSWISSComm.Text))
                {
                    var newComswiss = new CV_EXPCOMMENT
                    {
                        Comments = textExpSWISSComm.Text,
                        IDCV = IDCV
                    };
                    soft.CV_EXPCOMMENT.Add(newComswiss);
                    soft.SaveChanges();
                }

                //VISITPMU//
                if (!String.IsNullOrEmpty(textdateVisitSPMU.Text))
                {
                    //Date//
                    DateTime str = new DateTime();
                    if (!String.IsNullOrEmpty(textdateVisitSPMU.Text))
                        str = DateTime.Parse(textdateVisitSPMU.Text).Date;
                    //var str = DateTime.Parse(textdateVisitSPMU.Text).Date;

                    //Empl1//
                    var Empl1 = 0;
                    if (!String.IsNullOrEmpty(comboEmplMet1.Text) && soft.CV_EMPLOYEE.Where(a => a.PersRef == comboEmplMet1.Text).Count() != 0)
                    {
                        Empl1 = soft.CV_EMPLOYEE.Where(a => a.PersRef == comboEmplMet1.Text).FirstOrDefault().IDPersRef;
                    }

                    //Empl2//
                    var Empl2 = 0;
                    if (!String.IsNullOrEmpty(comboEmplMet2.Text) && soft.CV_EMPLOYEE.Where(a => a.PersRef == comboEmplMet2.Text).Count() != 0)
                    {
                        Empl2 = soft.CV_EMPLOYEE.Where(a => a.PersRef == comboEmplMet2.Text).FirstOrDefault().IDPersRef;
                    }

                    //Empl1//
                    var Empl3 = 0;
                    if (!String.IsNullOrEmpty(comboEmplMet3.Text) && soft.CV_EMPLOYEE.Where(a => a.PersRef == comboEmplMet3.Text).Count() != 0)
                    {
                        Empl3 = soft.CV_EMPLOYEE.Where(a => a.PersRef == comboEmplMet3.Text).FirstOrDefault().IDPersRef;
                    }

                    //POsition target//
                    var po = 0;
                    if (!String.IsNullOrEmpty(comboPosTarget.Text))
                    {
                        if (soft.CV_CATEGORY.Where(a => a.Category == comboPosTarget.Text).Count() != 0)
                        {
                            po = soft.CV_CATEGORY.Where(a => a.Category == comboPosTarget.Text).FirstOrDefault().IDCat;
                        }
                    }

                    //TEST//
                    int test = 0;

                    int.TryParse(comboTestDone.Text, out test);
                    

                    //Global//
                    var glob = 0;
                    if (!String.IsNullOrEmpty(comboGlobAppr.Text))
                    {
                        if (soft.CV_GAPPREC.Where(a => a.GApprec == comboGlobAppr.Text).Count() != 0)
                        {
                            glob = soft.CV_GAPPREC.Where(a => a.GApprec == comboGlobAppr.Text).FirstOrDefault().IDGApprec;
                        }
                    }

                    //Comm//
                    var comV = textVisitSPMUComm.Text;

                    var newVisit = new CV_VISITSPMU
                    {
                        Date = str,
                        IDEmplo1 = Empl1,
                        IDEmplo2 = Empl2,
                        IDEmplo3 = Empl3,
                        IDCategory = po,
                        TestDone = test,
                        IDGApprec = glob,
                        Comments = comV,
                        IDCV = IDCV
                    };

                    soft.CV_VISITSPMU.Add(newVisit);
                    soft.SaveChanges();
                }

                //EPROFIL//
                //1//
                if (!String.IsNullOrEmpty(ep1.Text))
                {
                    var epe = soft.CV_EPROFIL.Where(a => a.EProfile == ep1.Text).FirstOrDefault().IDEProf;
                    var newDoce1 = new CV_EPRO
                    {
                        IDEProf = epe,
                        Link = epl1.Text,
                        IDCV = IDCV,
                        NUM = 1
                    };
                    soft.CV_EPRO.Add(newDoce1);
                    soft.SaveChanges();
                }
                //2//
                if (!String.IsNullOrEmpty(ep2.Text))
                {
                    var epe2 = soft.CV_EPROFIL.Where(a => a.EProfile == ep2.Text).FirstOrDefault().IDEProf;
                    var newDoce2 = new CV_EPRO
                    {
                        IDEProf = epe2,
                        Link = epl2.Text,
                        IDCV = IDCV,
                        NUM = 2
                    };
                    soft.CV_EPRO.Add(newDoce2);
                    soft.SaveChanges();
                }
                //3//
                if (!String.IsNullOrEmpty(ep3.Text))
                {
                    var epe3 = soft.CV_EPROFIL.Where(a => a.EProfile == ep3.Text).FirstOrDefault().IDEProf;
                    var newDoce3 = new CV_EPRO
                    {
                        IDEProf = epe3,
                        Link = epl3.Text,
                        IDCV = IDCV,
                        NUM = 3
                    };
                    soft.CV_EPRO.Add(newDoce3);
                    soft.SaveChanges();
                }

                //EPROFIL WEB//
                //1//
                /*if (!String.IsNullOrEmpty(eplw1.Text))
                {
                    var newDoc = new CV_EPROWL
                    {
                        Link = eplw1.Text,
                        IDCV = IDCV,
                        NUM = 1
                    };
                    soft.CV_EPROWL.Add(newDoc);
                    soft.SaveChanges();
                }

                //2//
                if (!String.IsNullOrEmpty(eplw2.Text))
                {
                    var newDoc = new CV_EPROWL
                    {
                        Link = eplw2.Text,
                        IDCV = IDCV,
                        NUM = 2
                    };
                    soft.CV_EPROWL.Add(newDoc);
                    soft.SaveChanges();
                }

                //3//
                if (!String.IsNullOrEmpty(eplw3.Text))
                {
                    var newDoc = new CV_EPROWL
                    {
                        Link = eplw3.Text,
                        IDCV = IDCV,
                        NUM = 3
                    };
                    soft.CV_EPROWL.Add(newDoc);
                    soft.SaveChanges();
                }

                //ON CHAT PLATFORM//
                //1//
                if (!String.IsNullOrEmpty(oc1.Text))
                {
                    if (!String.IsNullOrEmpty(ocl1.Text))
                    {
                        if (soft.CV_ONCHATPLAT.Where(a => a.OnlineChat == oc1.Text).Count() != 0)
                        {
                            var ep = soft.CV_ONCHATPLAT.Where(a => a.OnlineChat == oc1.Text).FirstOrDefault().IDChat;

                            var newDoc = new CV_ONCHAT
                            {
                                IDChat = ep,
                                Link = ocl1.Text,
                                IDCV = IDCV,
                                NUM = 1
                            };
                            soft.CV_ONCHAT.Add(newDoc);
                            soft.SaveChanges();
                        }
                        else
                            MessageBox.Show("Online chat1 does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Please fill all informations (Online chat1 or Link1)", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //2//
                if (!String.IsNullOrEmpty(oc2.Text))
                {
                    if (!String.IsNullOrEmpty(ocl2.Text))
                    {
                        if (soft.CV_ONCHATPLAT.Where(a => a.OnlineChat == oc2.Text).Count() != 0)
                        {
                            var ep = soft.CV_ONCHATPLAT.Where(a => a.OnlineChat == oc2.Text).FirstOrDefault().IDChat;

                            var newDoc = new CV_ONCHAT
                            {
                                IDChat = ep,
                                Link = ocl2.Text,
                                IDCV = IDCV,
                                NUM = 2
                            };
                            soft.CV_ONCHAT.Add(newDoc);
                            soft.SaveChanges();
                        }
                        else
                            MessageBox.Show("Online chat2 does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Please fill all informations (Online chat2 or Link2)", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //3//
                if (!String.IsNullOrEmpty(oc3.Text))
                {
                    if (!String.IsNullOrEmpty(ocl3.Text))
                    {
                        if (soft.CV_ONCHATPLAT.Where(a => a.OnlineChat == oc3.Text).Count() != 0)
                        {
                            var ep = soft.CV_ONCHATPLAT.Where(a => a.OnlineChat == oc3.Text).FirstOrDefault().IDChat;

                            var newDoc = new CV_ONCHAT
                            {
                                IDChat = ep,
                                Link = ocl3.Text,
                                IDCV = IDCV,
                                NUM = 3
                            };
                            soft.CV_ONCHAT.Add(newDoc);
                            soft.SaveChanges();
                        }
                        else
                            MessageBox.Show("Online chat3 does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Please fill all informations (Online chat3 or Link3)", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //ON CHAT AVATAR//
                //1//
                if (!String.IsNullOrEmpty(ocla1.Text))
                {
                    var newDoc = new CV_ONCHATAVA
                    {
                        Link = ocla1.Text,
                        IDCV = IDCV,
                        NUM = 1
                    };
                    soft.CV_ONCHATAVA.Add(newDoc);
                    soft.SaveChanges();
                }

                //2//
                if (!String.IsNullOrEmpty(ocla2.Text))
                {
                    var newDoc = new CV_ONCHATAVA
                    {
                        Link = ocla2.Text,
                        IDCV = IDCV,
                        NUM = 2
                    };
                    soft.CV_ONCHATAVA.Add(newDoc);
                    soft.SaveChanges();
                }

                //3//
                if (!String.IsNullOrEmpty(ocla3.Text))
                {
                    var newDoc = new CV_ONCHATAVA
                    {
                        Link = ocla3.Text,
                        IDCV = IDCV,
                        NUM = 3
                    };
                    soft.CV_ONCHATAVA.Add(newDoc);
                    soft.SaveChanges();
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textdateBirthDay_Validated(object sender, EventArgs e)
        {
     
            if (!String.IsNullOrEmpty(textdateBirthDay.Text))
            {
                DateTime maDate;
      
                if (DateTime.TryParse(textdateBirthDay.Text, out maDate))
                {
                    textGivenAge.Enabled = false;
                    textGivenAge.Text = "0";
                    var dtNo = DateTime.Now;

                    var years = (dtNo.Year - maDate.Year - (DateTime.Now.Month < maDate.Month ? 1 : (DateTime.Now.Month == maDate.Month && DateTime.Now.Day < maDate.Day) ? 1 : 0));

                    textAgeCalc.Text = years.ToString();

                    textAdress1.Focus();
                }
                else
                {
                    MessageBox.Show("Invalid format of the date", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textdateBirthDay.Text = null;
                   
                }

                /*DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            DateTime birth = maDate.Date;

                            isForModif.DateCV = birth;

                            soft.SaveChanges();
                        }
                    }
                }*/
            }
            else if (String.IsNullOrEmpty(textGivenAge.Text))
            {
                textGivenAge.Enabled = true;
                textAgeCalc.Text = "0";
                textGivenAge.Text = "0";
            }
            else
            {
                textGivenAge.Enabled = true;
                textAgeCalc.Text = "0";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "Office Files|*.doc;*.docx;*.xls;*.xlsx;*.ppt;*.pptx;|Pdf files (*.pdf)|*.pdf|Txt files (*.txt)|*.txt|Images files|*.png;*.jpg;*.tiff*;*.psd;*.eps;*.raw|All files(*.*)|*.*";
            openFileDialog1.Filter = "All files(*.*)|*.*";
            openFileDialog1.Title = "Please select a file";
            openFileDialog1.RestoreDirectory = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                FileInfo info = new FileInfo(openFileDialog1.FileName);
              
                textDocLink1.Text = info.FullName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files(*.*)|*.*";
            openFileDialog1.Title = "Please select a file";
            openFileDialog1.RestoreDirectory = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(openFileDialog1.FileName);
                textDocLink2.Text = info.FullName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files(*.*)|*.*";
            openFileDialog1.Title = "Please select a file";
            openFileDialog1.RestoreDirectory = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(openFileDialog1.FileName);
                textDocLink3.Text = info.FullName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files(*.*)|*.*";
            openFileDialog1.Title = "Please select a file";
            openFileDialog1.RestoreDirectory = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(openFileDialog1.FileName);
                textDocLink4.Text = info.FullName;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files(*.*)|*.*";
            openFileDialog1.Title = "Please select a file";
            openFileDialog1.RestoreDirectory = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(openFileDialog1.FileName);
                textDocLink5.Text = info.FullName;
            }
        }

        private void textTFYears1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 )
            {
                e.Handled = true;
            }
        }

        private void textTFYears2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 )
            {
                e.Handled = true;
            }
        }

        private void textTFYears3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32)
            {
                e.Handled = true;
            }
        }

        private void textRYears1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 )
            {
                e.Handled = true;
            }
        }

        private void textRYears2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 )
            {
                e.Handled = true;
            }
        }

        private void textRYears3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 )
            {
                e.Handled = true;
            }
        }

        private void textCRYears1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32)
            {
                e.Handled = true;
            }
        }

        private void textCRYears2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 )
            {
                e.Handled = true;
            }
        }

        private void textCRYears3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 )
            {
                e.Handled = true;
            }
        }

        private void textCRYears4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 )
            {
                e.Handled = true;
            }
        }

        private void textDurWeek1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 )
            {
                e.Handled = true;
            }
        }

        private void textDurWeek2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 )
            {
                e.Handled = true;
            }
        }

        private void comboCat_Validated(object sender, EventArgs e)
        {

            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (!String.IsNullOrEmpty(comboCat.Text))
                {
                    if (Token.getAUTHO() == true)
                    {
                        String text = comboCat.Text;
                        var cat = soft.CV_CATEGORY.Where(a => a.Category.ToLower() == text.ToLower()).FirstOrDefault();
                        if (cat == null)
                        {

                            DialogResult result = MessageBox.Show(" \"" + text + " \" does not exist in Category table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                CV_CATEGORY item = new CV_CATEGORY();
                                item.Category = text;
                                soft.CV_CATEGORY.Add(item);
                                soft.SaveChanges();

                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                List<String> itmCat = new List<String>();
                                itmCat.Add("");
                                if (soft.CV_CATEGORY.Count() != 0)
                                {
                                    foreach (var x in soft.CV_CATEGORY.Select(a => a.Category).OrderBy(a => a).ToList())
                                    {
                                        itmCat.Add(x);
                                    }
                                }
                                comboCat.DataSource = itmCat;
                                comboCat.SelectedItem = text;
                            }
                            else
                            {
                                comboCat.SelectedItem = "";
                            }
                        }
                    }
                    if (soft.CV_CATEGORY.Where(a => a.Category == comboCat.Text && a.ISOK == true).Count() != 0)
                    {
                        var isCat = soft.CV_CATEGORY.Where(a => a.Category == comboCat.Text && a.ISOK == true).FirstOrDefault();

                        label78.Text = "No criteria defined in the tuning page";
                        if (!String.IsNullOrEmpty(isCat.CR1))
                            label78.Text = isCat.CR1;
                        label75.Text = "No criteria defined in the tuning page";
                        if (!String.IsNullOrEmpty(isCat.CR2))
                            label75.Text = isCat.CR2;
                        label73.Text = "No criteria defined in the tuning page";
                        if (!String.IsNullOrEmpty(isCat.CR3))
                            label73.Text = isCat.CR3;
                        label79.Text = "No criteria defined in the tuning page";
                        if (!String.IsNullOrEmpty(isCat.CR4))
                            label79.Text = isCat.CR4;
                        label119.Text = "No criteria defined in the tuning page";
                        if (!String.IsNullOrEmpty(isCat.CR5))
                            label119.Text = isCat.CR5;

                        textCRYears1.Enabled = true;
                        textCRYears2.Enabled = true;
                        textCRYears3.Enabled = true;
                        textCRYears4.Enabled = true;
                        textCRYears5.Enabled = true;

                        comboCat.BackColor = Color.FromArgb(255, 255, 192);
                      
                    }
                    else
                    {
                        comboCat.BackColor = Color.Tomato;
                  

                        textCRYears1.Enabled = false;
                        textCRYears2.Enabled = false;
                        textCRYears3.Enabled = false;
                        textCRYears4.Enabled = false;
                        textCRYears5.Enabled = false;

                        textCRYears1.Text = "0";
                        textCRYears2.Text = "0";
                        textCRYears3.Text = "0";
                        textCRYears4.Text = "0";
                        textCRYears5.Text = "0";

                        label78.Text = "No criteria defined in the tuning page";
                        label75.Text = "No criteria defined in the tuning page";
                        label73.Text = "No criteria defined in the tuning page";
                        label79.Text = "No criteria defined in the tuning page";
                        label119.Text = "No criteria defined in the tuning page";
                    }
                }

                /*if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            var cat = 0;
                            if (!String.IsNullOrEmpty(comboCat.Text))
                            {
                                if (soft.CV_CATEGORY.Where(a => a.Category == comboCat.Text).Count() != 0)
                                {
                                    cat = soft.CV_CATEGORY.Where(a => a.Category == comboCat.Text).FirstOrDefault().IDCat;
                                }
                            }

                            isForModif.IDCat = cat;

                            soft.SaveChanges();
                        }
                    }
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files(*.*)|*.*";
            openFileDialog1.Title = "Please select a file";
            openFileDialog1.RestoreDirectory = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(openFileDialog1.FileName);
                textLink1.Text = info.FullName;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files(*.*)|*.*";
            openFileDialog1.Title = "Please select a file";
            openFileDialog1.RestoreDirectory = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(openFileDialog1.FileName);
                textLink2.Text = info.FullName;
            }
        }

        private void textDailyFeePaid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 && entrer != 44)
            {
                e.Handled = true;
            }
        }

        private void textDailyFeePaid2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 && entrer != 44)
            {
                e.Handled = true;
            }
        }

        private void checkSleep_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkSleep.Checked)
                    textSleepComment.Enabled = true;
                else
                    textSleepComment.Enabled = false;
                /*DbCVBASE soft = new DbCVBASE();

                if(checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            var sleep = false;
                            if (checkSleep.Checked)
                                sleep = true;

                            isForModif.Sleep = sleep;

                            soft.SaveChanges();
                        }
                    }
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textPrenom_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            var firstName = textPrenom.Text;

                            isForModif.FirstName = firstName;

                            soft.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboGender_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (!String.IsNullOrEmpty(comboGender.Text))
                {
                    //    if (Token.getAUTHO() == true)
                    //   {
                    String text = comboGender.Text;
                    var gender = soft.CV_GENDER.Where(a => a.Gender.ToLower() == text.ToLower()).FirstOrDefault();
                    if (gender == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text + " \" does not exist in Gender table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_GENDER item = new CV_GENDER();
                            item.Gender = text;
                            soft.CV_GENDER.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmGender = new List<String>();
                            itmGender.Add("");
                            if (soft.CV_GENDER.Count() != 0)
                            {
                                foreach (var x in soft.CV_GENDER.Select(a => a.Gender).OrderBy(a => a).ToList())
                                {
                                    itmGender.Add(x);
                                }
                            }
                            comboGender.DataSource = itmGender;
                            comboGender.SelectedItem = text;
                        }
                        else
                        {
                            comboGender.SelectedItem = "";
                        }
                    }
                    /*     else
                         {
                             if(gender.Gender.ToLower()=="male"){
                                 comboTitle.Text = "Mr.";
                             }
                             else if (gender.Gender.ToLower() == "female")
                             {
                                 comboTitle.Text = "Mrs.";
                             }

                         }*/
                }




            //    }




                /*  if (checkAutoSave.Checked)
                  {
                      if (!String.IsNullOrEmpty(comboName.Text))
                      {
                          if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                          {
                              var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                              var gender = 0;
                              if (soft.CV_GENDER.Where(a => a.Gender == comboGender.Text).Count() != 0)
                              {
                                  gender = soft.CV_GENDER.Where(a => a.Gender == comboGender.Text).FirstOrDefault().IDGender;
                              }

                              isForModif.IDGender = gender;

                              soft.SaveChanges();
                          }
                      }
                  }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dateCV_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(textdateCV.Text))
                    {
                        if (!String.IsNullOrEmpty(comboName.Text))
                        {
                            if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                            {
                                var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                                DateTime datecv = dateCV.Value.Date;

                                isForModif.DateCV = datecv;

                                soft.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textAdress1_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            var add = textAdress1.Text;

                            isForModif.Adress1 = add;

                            soft.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textZipCode_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            var zip = textZipCode.Text;

                            isForModif.ZipCode = zip;

                            soft.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textAdress2_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            var add = textAdress2.Text;

                            isForModif.Adress2 = add;

                            soft.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //private void textTown_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!String.IsNullOrEmpty(textTown.Text))
        //        {
        //            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        //            foreach (var value in textTown.Text)
        //            {
        //                textTown.Text = ti.ToTitleCase(textTown.Text.ToLower()); 
        //            }
        //            textTown.Select(textTown.Text.Length, 0);
        //        }
               
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + ex.StackTrace);
        //    }
        //}

        private void textGivenAge_Validated(object sender, EventArgs e)
        {
            try
            {
          
                if (textGivenAge.Text=="0")
                {
                    textdateBirthDay.Enabled = true;
                    dateBirthDay.Enabled = true;
                    dateBirthDay.Text = "";
                    textdateBirthDay.Text = "";
                }
                else if (!String.IsNullOrEmpty(textGivenAge.Text))
                {
                    textdateBirthDay.Enabled = true;
                    dateBirthDay.Enabled = true;
                }
                else
                {
                    textdateBirthDay.Enabled = true;
                                   
                }
                         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textMobilPhone_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            var mob = textMobilPhone.Text;

                            isForModif.MobilPhone = mob;

                            soft.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textMail1_Validated(object sender, EventArgs e)
        {
            try
            {  //System.Text.RegularExpressions.Regex myRegex = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$");
                    System.Text.RegularExpressions.Regex myRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    if (!String.IsNullOrEmpty(textMail1.Text))
                    {
                        if (myRegex.IsMatch(textMail1.Text) == false)
                        {
                            textMail1.Text = "";
                            MessageBox.Show("Email address invalid");
                            button29.Enabled = false;
                        }
                    
                    }
                    else
                    {
          
                            button29.Enabled = false;
                    }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textLandlinePhone_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            var land = textLandlinePhone.Text;

                            isForModif.LandlinePhone = land;

                            soft.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textMail2_Validated(object sender, EventArgs e)
        {
            try
            {
                //System.Text.RegularExpressions.Regex myRegex = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$");
                System.Text.RegularExpressions.Regex myRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                //([\w]+) ==> caractère alphanumérique apparaissant une fois ou plus 
                if (!String.IsNullOrEmpty(textMail2.Text))
                {
                    if (myRegex.IsMatch(textMail2.Text) == false && !String.IsNullOrEmpty(textMail2.Text))
                    {
                        textMail2.Text = "";
                        MessageBox.Show("Email address invalid");
                        button30.Enabled = false;
                    }
                  
                       
                }
                else
                {
                    button30.Enabled = false;
                }

           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textDailyFees_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textDailyFees.Text))
                textDailyFees.Text = "0.00";

                
            decimal testint;
            if (textDailyFees.Text == "0.00")
            {

            }
            else if (decimal.TryParse(textDailyFees.Text, out testint))
            {
                textDailyFees.Text = string.Format("{0:#,##0.00}", decimal.Parse(textDailyFees.Text));
            }
           else
            {
                string message = "Invalid or too large number";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDailyFees.Text = "0.00";
            }
         /*   try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            var dai = textDailyFees.Text;

                            isForModif.ExpDailyFees = dai;

                            soft.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }*/
        }

        private void textComCV_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            var com = textComCV.Text;

                            isForModif.Comments = com;

                            soft.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dateInterview_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(textdateInterview.Text))
                    {
                        if (!String.IsNullOrEmpty(comboName.Text))
                        {
                            if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                            {
                                var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                                DateTime date = dateInterview.Value.Date;

                                isForModif.DateSPMU = date;

                                soft.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboNationality_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();
                if (!String.IsNullOrEmpty(comboNationality.Text))
                {
                    if (Token.getAUTHO() == true)
                    {
                        String text1 = comboNationality.Text;
                        String text2 = comboCountry.Text;
                        String text3 = comboCountry1.Text;
                        String text4 = comboCountry2.Text;
                        var nation = soft.CV_NATIONS.Where(a => a.Country.ToLower() == text1.ToLower()).FirstOrDefault();
                        if (nation == null)
                        {
                            DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Nationality table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                CV_NATIONS item = new CV_NATIONS();
                                item.Country = text1;
                                soft.CV_NATIONS.Add(item);
                                soft.SaveChanges();

                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                List<String> itmNation1 = new List<String>();
                                List<String> itmNation2 = new List<String>();
                                List<String> itmNation3 = new List<String>();
                                List<String> itmNation4 = new List<String>();
                                itmNation1.Add("");
                                itmNation2.Add("");
                                itmNation3.Add("");
                                itmNation4.Add("");
                                if (soft.CV_NATIONS.Count() != 0)
                                {
                                    foreach (var x in soft.CV_NATIONS.Select(a => a.Country).OrderBy(a => a).ToList())
                                    {
                                        itmNation1.Add(x);
                                        itmNation2.Add(x);
                                        itmNation3.Add(x);
                                        itmNation4.Add(x);
                                    }
                                }
                                comboNationality.DataSource = itmNation1;
                                comboCountry.DataSource = itmNation2;
                                comboCountry1.DataSource = itmNation3;
                                comboCountry2.DataSource = itmNation4;
                                comboNationality.SelectedItem = text1;
                                comboCountry.SelectedItem = text2;
                                comboCountry1.SelectedItem = text3;
                                comboCountry2.SelectedItem = text4;
                            }
                            else
                            {
                                comboNationality.SelectedItem = "";
                            }
                        }
                    }
                }

                /*  if (checkAutoSave.Checked)
                  {
                      if (!String.IsNullOrEmpty(comboName.Text))
                      {
                          if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                          {
                              var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                              var nationality = 0;
                              if (!String.IsNullOrEmpty(comboNationality.Text))
                              {
                                  if (soft.CV_NATIONS.Where(a => a.Country == comboNationality.Text).Count() != 0)
                                  {
                                      nationality = soft.CV_NATIONS.Where(a => a.Country == comboNationality.Text).FirstOrDefault().IDCountry;
                                  }
                              }

                              isForModif.IDNationality = nationality;

                              soft.SaveChanges();
                          }
                      }
                  }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboCountry_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();
                if (Token.getAUTHO() == true)
                {
                    if (!String.IsNullOrEmpty(comboCountry.Text))
                    {
                        String text = comboCountry.Text;
                        var country = soft.CV_NATIONS.Where(a => a.Country.ToLower() == text.ToLower()).FirstOrDefault();
                        if (country == null)
                        {
                            DialogResult result = MessageBox.Show(" \"" + text + " \" does not exist in Nations table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                CV_NATIONS item = new CV_NATIONS();
                                item.Country = text;
                                soft.CV_NATIONS.Add(item);
                                soft.SaveChanges();

                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                List<String> itmCountry = new List<String>();
                                itmCountry.Add("");
                                if (soft.CV_NATIONS.Count() != 0)
                                {
                                    foreach (var x in soft.CV_NATIONS.Select(a => a.Country).OrderBy(a => a).ToList())
                                    {
                                        itmCountry.Add(x);
                                    }
                                }
                                comboCountry.DataSource = itmCountry;
                                comboCountry.SelectedItem = text;
                            }
                            else
                            {
                                comboCountry.SelectedItem = "";
                            }
                        }
                    }
                }

                /*  if (checkAutoSave.Checked)
                  {
                      if (!String.IsNullOrEmpty(comboName.Text))
                      {
                          if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                          {
                              var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                              var country = 0;
                              if (!String.IsNullOrEmpty(comboCountry.Text))
                              {
                                  if (soft.CV_NATIONS.Where(a => a.Country == comboCountry.Text).Count() != 0)
                                  {
                                      country = soft.CV_NATIONS.Where(a => a.Country == comboCountry.Text).FirstOrDefault().IDCountry;
                                  }
                              }

                              isForModif.IDCountry = country;

                              soft.SaveChanges();
                          }
                      }
                  }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboPersTPH_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();
                if (!String.IsNullOrEmpty(comboPersTPH.Text))
                {
                    if (Token.getAUTHO() == true)
                    {
                        String text1 = comboEmplMet1.Text;
                        String text2 = comboEmplMet2.Text;
                        String text3 = comboEmplMet3.Text;
                        String text4 = comboPersTPH.Text;
                        String text5 = comboMainSup1.Text;
                        String text6 = comboMainSup2.Text;

                        var emp = soft.CV_EMPLOYEE.Where(a => a.PersRef.ToLower() == text4.ToLower()).FirstOrDefault();
                        if (emp == null)
                        {
                            DialogResult result = MessageBox.Show(" \"" + text4 + " \" does not exist in Employee table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                CV_EMPLOYEE item = new CV_EMPLOYEE();
                                item.PersRef = text4;
                                soft.CV_EMPLOYEE.Add(item);
                                soft.SaveChanges();

                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                List<String> itmEmp1 = new List<String>();
                                List<String> itmEmp2 = new List<String>();
                                List<String> itmEmp3 = new List<String>();
                                List<String> itmEmp4 = new List<String>();
                                List<String> itmEmp5 = new List<String>();
                                List<String> itmEmp6 = new List<String>();
                                itmEmp1.Add("");
                                itmEmp2.Add("");
                                itmEmp3.Add("");
                                itmEmp4.Add("");
                                itmEmp5.Add("");
                                itmEmp6.Add("");
                                if (soft.CV_EMPLOYEE.Count() != 0)
                                {
                                    foreach (var x in soft.CV_EMPLOYEE.Select(a => a.PersRef).OrderBy(a => a).ToList())
                                    {
                                        itmEmp1.Add(x);
                                        itmEmp2.Add(x);
                                        itmEmp3.Add(x);
                                        itmEmp4.Add(x);
                                        itmEmp5.Add(x);
                                        itmEmp6.Add(x);
                                    }
                                }
                                comboEmplMet1.DataSource = itmEmp1;
                                comboEmplMet2.DataSource = itmEmp2;
                                comboEmplMet3.DataSource = itmEmp3;
                                comboPersTPH.DataSource = itmEmp4;
                                comboMainSup1.DataSource = itmEmp5;
                                comboMainSup2.DataSource = itmEmp6;
                                comboEmplMet1.SelectedItem = text1;
                                comboEmplMet2.SelectedItem = text2;
                                comboEmplMet3.SelectedItem = text3;
                                comboPersTPH.SelectedItem = text4;
                                comboMainSup1.SelectedItem = text5;
                                comboMainSup2.SelectedItem = text6;
                            }
                            else
                            {
                                comboPersTPH.SelectedItem = "";
                            }
                        }
                    }
                }

                /*   if (checkAutoSave.Checked)
                   {
                       if (!String.IsNullOrEmpty(comboName.Text))
                       {
                           if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                           {
                               var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                               var persTPH = 0;
                               if (!String.IsNullOrEmpty(comboPersTPH.Text))
                               {
                                   if (soft.CV_EMPLOYEE.Where(a => a.PersRef == comboPersTPH.Text).Count() != 0)
                                   {
                                       persTPH = soft.CV_EMPLOYEE.Where(a => a.PersRef == comboPersTPH.Text).FirstOrDefault().IDPersRef;
                                   }
                               }

                               isForModif.IDPersRef = persTPH;

                               soft.SaveChanges();
                           }
                       }
                   }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboShortListed_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            var shortL = false;
                            if (comboShortListed.Text == "YES")
                            {
                                shortL = true;
                            }

                            isForModif.ShortListed = shortL;

                            soft.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboJunSenior_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();
                if (!String.IsNullOrEmpty(comboJunSenior.Text))
                {

                    if (Token.getAUTHO() == true)
                    {
                        String text1 = comboJunSenior.Text;
                        String text2 = comboJunSen1.Text;
                        String text3 = comboJunSen2.Text;
                        var level = soft.CV_JUNSENIOR.Where(a => a.JunSenior.ToLower() == text1.ToLower()).FirstOrDefault();
                        if (level == null)
                        {
                            DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Level table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                CV_JUNSENIOR item = new CV_JUNSENIOR();
                                item.JunSenior = text1;
                                soft.CV_JUNSENIOR.Add(item);
                                soft.SaveChanges();

                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                List<String> itmLevel1 = new List<String>();
                                List<String> itmLevel2 = new List<String>();
                                List<String> itmLevel3 = new List<String>();
                                itmLevel1.Add("");
                                itmLevel2.Add("");
                                itmLevel3.Add("");
                                if (soft.CV_JUNSENIOR.Where(a => a.JunSenior != "ALL").Count() != 0)
                                {
                                    foreach (var x in soft.CV_JUNSENIOR.Where(a => a.JunSenior != "ALL").Select(a => a.JunSenior).OrderBy(a => a).ToList())
                                    {
                                        itmLevel1.Add(x);
                                        itmLevel2.Add(x);
                                        itmLevel3.Add(x);
                                    }
                                }
                                comboJunSenior.DataSource = itmLevel1;
                                comboJunSen1.DataSource = itmLevel2;
                                comboJunSen2.DataSource = itmLevel3;
                                comboJunSenior.SelectedItem = text1;
                                comboJunSen1.SelectedItem = text2;
                                comboJunSen2.SelectedItem = text3;
                            }
                            else
                            {
                                comboJunSenior.SelectedItem = "";
                            }

                        }
                    }
                }

                /*  if (checkAutoSave.Checked)
                  {
                      if (!String.IsNullOrEmpty(comboName.Text))
                      {
                          if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                          {
                              var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                              var junsen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "TBD").FirstOrDefault().IDJunSenior;
                              if (!String.IsNullOrEmpty(comboJunSenior.Text))
                              {
                                  if (soft.CV_JUNSENIOR.Where(a => a.JunSenior == comboJunSenior.Text).Count() != 0)
                                  {
                                      junsen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == comboJunSenior.Text).FirstOrDefault().IDJunSenior;
                                  }
                              }

                              isForModif.IDJunSenior = junsen;

                              soft.SaveChanges();
                          }
                      }
                  }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void AutomVisitSPMU()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(textdateVisitSPMU.Text))
                    {
                        if (!String.IsNullOrEmpty(comboName.Text))
                        {
                            if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                            {
                                var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                                if (soft.CV_VISITSPMU.Where(a => a.IDCV == isForModif.IDCV).Count() != 0)
                                {
                                    var VisitForDelete = soft.CV_VISITSPMU.Where(a => a.IDCV == isForModif.IDCV).FirstOrDefault();
                                    soft.CV_VISITSPMU.Remove(VisitForDelete);
                                    soft.SaveChanges();
                                }

                                //Date//
                                var str = dateVisitSPMU.Value.Date;

                                //Empl1//
                                var Empl1 = 0;
                                if (!String.IsNullOrEmpty(comboEmplMet1.Text) && soft.CV_EMPLOYEE.Where(a => a.PersRef == comboEmplMet1.Text).Count() != 0)
                                {
                                    Empl1 = soft.CV_EMPLOYEE.Where(a => a.PersRef == comboEmplMet1.Text).FirstOrDefault().IDPersRef;
                                }

                                //Empl2//
                                var Empl2 = 0;
                                if (!String.IsNullOrEmpty(comboEmplMet2.Text) && soft.CV_EMPLOYEE.Where(a => a.PersRef == comboEmplMet2.Text).Count() != 0)
                                {
                                    Empl2 = soft.CV_EMPLOYEE.Where(a => a.PersRef == comboEmplMet2.Text).FirstOrDefault().IDPersRef;
                                }

                                //Empl1//
                                var Empl3 = 0;
                                if (!String.IsNullOrEmpty(comboEmplMet3.Text) && soft.CV_EMPLOYEE.Where(a => a.PersRef == comboEmplMet3.Text).Count() != 0)
                                {
                                    Empl3 = soft.CV_EMPLOYEE.Where(a => a.PersRef == comboEmplMet3.Text).FirstOrDefault().IDPersRef;
                                }

                                //POsition target//
                                var po = 0;
                                if (!String.IsNullOrEmpty(comboPosTarget.Text))
                                {
                                    if (soft.CV_CATEGORY.Where(a => a.Category == comboPosTarget.Text).Count() != 0)
                                    {
                                        po = soft.CV_CATEGORY.Where(a => a.Category == comboPosTarget.Text).FirstOrDefault().IDCat;
                                    }
                                }

                                //TEST//
                                var test = 0;
                                if (!String.IsNullOrEmpty(comboTestDone.Text))
                                {
                                    if (soft.CV_TEST.Where(a => a.Test == comboTestDone.Text).Count() != 0)
                                    {
                                        test = soft.CV_TEST.Where(a => a.Test == comboTestDone.Text).FirstOrDefault().IDTest;
                                    }
                                }

                                //Global//
                                var glob = 0;
                                if (!String.IsNullOrEmpty(comboGlobAppr.Text))
                                {
                                    if (soft.CV_GAPPREC.Where(a => a.GApprec == comboGlobAppr.Text).Count() != 0)
                                    {
                                        glob = soft.CV_GAPPREC.Where(a => a.GApprec == comboGlobAppr.Text).FirstOrDefault().IDGApprec;
                                    }
                                }

                                //Comm//
                                var comV = textVisitSPMUComm.Text;

                                var newVisit = new CV_VISITSPMU
                                {
                                    Date = str,
                                    IDEmplo1 = Empl1,
                                    IDEmplo2 = Empl2,
                                    IDEmplo3 = Empl3,
                                    IDCategory = po,
                                    TestDone = test,
                                    IDGApprec = glob,
                                    Comments = comV,
                                    IDCV = isForModif.IDCV
                                };

                                soft.CV_VISITSPMU.Add(newVisit);
                                soft.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dateVisitSPMU_Validated(object sender, EventArgs e)
        {
            AutomVisitSPMU();
        }

        private void comboEmplMet1_Validated(object sender, EventArgs e)
        {
            AutomVisitSPMU();
            if (!String.IsNullOrEmpty(comboEmplMet1.Text))
            {
                if (Token.getAUTHO() == true)
                {

                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboEmplMet1.Text;
                    String text2 = comboEmplMet2.Text;
                    String text3 = comboEmplMet3.Text;
                    String text4 = comboPersTPH.Text;
                    String text5 = comboMainSup1.Text;
                    String text6 = comboMainSup2.Text;

                    var emp = soft.CV_EMPLOYEE.Where(a => a.PersRef.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (emp == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Employee table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_EMPLOYEE item = new CV_EMPLOYEE();
                            item.PersRef = text1;
                            soft.CV_EMPLOYEE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmEmp1 = new List<String>();
                            List<String> itmEmp2 = new List<String>();
                            List<String> itmEmp3 = new List<String>();
                            List<String> itmEmp4 = new List<String>();
                            List<String> itmEmp5 = new List<String>();
                            List<String> itmEmp6 = new List<String>();
                            itmEmp1.Add("");
                            itmEmp2.Add("");
                            itmEmp3.Add("");
                            itmEmp4.Add("");
                            itmEmp5.Add("");
                            itmEmp6.Add("");
                            if (soft.CV_EMPLOYEE.Count() != 0)
                            {
                                foreach (var x in soft.CV_EMPLOYEE.Select(a => a.PersRef).OrderBy(a => a).ToList())
                                {

                                    itmEmp1.Add(x);
                                    itmEmp2.Add(x);
                                    itmEmp3.Add(x);
                                    itmEmp4.Add(x);
                                    itmEmp5.Add(x);
                                    itmEmp6.Add(x);

                                }
                            }
                            comboEmplMet1.DataSource = itmEmp1;
                            comboEmplMet2.DataSource = itmEmp2;
                            comboEmplMet3.DataSource = itmEmp3;
                            comboPersTPH.DataSource = itmEmp4;
                            comboMainSup1.DataSource = itmEmp5;
                            comboMainSup2.DataSource = itmEmp6;
                            comboEmplMet1.SelectedItem = text1;
                            comboEmplMet2.SelectedItem = text2;
                            comboEmplMet3.SelectedItem = text3;
                            comboPersTPH.SelectedItem = text4;
                            comboMainSup1.SelectedItem = text5;
                            comboMainSup2.SelectedItem = text6;
                        }
                        else
                        {
                            comboEmplMet1.SelectedItem = "";
                        }
                    }

                }
            }
        }

        private void comboEmplMet2_Validated(object sender, EventArgs e)
        {
            AutomVisitSPMU();
            if (!String.IsNullOrEmpty(comboEmplMet2.Text))
            {
                if (Token.getAUTHO() == true)
                {

                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboEmplMet1.Text;
                    String text2 = comboEmplMet2.Text;
                    String text3 = comboEmplMet3.Text;
                    String text4 = comboPersTPH.Text;
                    String text5 = comboMainSup1.Text;
                    String text6 = comboMainSup2.Text;

                    var emp = soft.CV_EMPLOYEE.Where(a => a.PersRef.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (emp == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Employee table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_EMPLOYEE item = new CV_EMPLOYEE();
                            item.PersRef = text2;
                            soft.CV_EMPLOYEE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmEmp1 = new List<String>();
                            List<String> itmEmp2 = new List<String>();
                            List<String> itmEmp3 = new List<String>();
                            List<String> itmEmp4 = new List<String>();
                            List<String> itmEmp5 = new List<String>();
                            List<String> itmEmp6 = new List<String>();
                            itmEmp1.Add("");
                            itmEmp2.Add("");
                            itmEmp3.Add("");
                            itmEmp4.Add("");
                            itmEmp5.Add("");
                            itmEmp6.Add("");
                            if (soft.CV_EMPLOYEE.Count() != 0)
                            {
                                foreach (var x in soft.CV_EMPLOYEE.Select(a => a.PersRef).OrderBy(a => a).ToList())
                                {

                                    itmEmp1.Add(x);
                                    itmEmp2.Add(x);
                                    itmEmp3.Add(x);
                                    itmEmp4.Add(x);
                                    itmEmp5.Add(x);
                                    itmEmp6.Add(x);

                                }
                            }
                            comboEmplMet1.DataSource = itmEmp1;
                            comboEmplMet2.DataSource = itmEmp2;
                            comboEmplMet3.DataSource = itmEmp3;
                            comboPersTPH.DataSource = itmEmp4;
                            comboMainSup1.DataSource = itmEmp5;
                            comboMainSup2.DataSource = itmEmp6;
                            comboEmplMet1.SelectedItem = text1;
                            comboEmplMet2.SelectedItem = text2;
                            comboEmplMet3.SelectedItem = text3;
                            comboPersTPH.SelectedItem = text4;
                            comboMainSup1.SelectedItem = text5;
                            comboMainSup2.SelectedItem = text6;
                        }
                        else
                        {
                            comboEmplMet2.SelectedItem = "";
                        }
                    }

                }
            }
        }

        private void comboEmplMet3_Validated(object sender, EventArgs e)
        {
            AutomVisitSPMU();
            if (!String.IsNullOrEmpty(comboEmplMet3.Text))
            {
                if (Token.getAUTHO() == true)
                {

                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboEmplMet1.Text;
                    String text2 = comboEmplMet2.Text;
                    String text3 = comboEmplMet3.Text;
                    String text4 = comboPersTPH.Text;
                    String text5 = comboMainSup1.Text;
                    String text6 = comboMainSup2.Text;

                    var emp = soft.CV_EMPLOYEE.Where(a => a.PersRef.ToLower() == text3.ToLower()).FirstOrDefault();
                    if (emp == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text3 + " \" does not exist in Employee table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_EMPLOYEE item = new CV_EMPLOYEE();
                            item.PersRef = text3;
                            soft.CV_EMPLOYEE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmEmp1 = new List<String>();
                            List<String> itmEmp2 = new List<String>();
                            List<String> itmEmp3 = new List<String>();
                            List<String> itmEmp4 = new List<String>();
                            List<String> itmEmp5 = new List<String>();
                            List<String> itmEmp6 = new List<String>();
                            itmEmp1.Add("");
                            itmEmp2.Add("");
                            itmEmp3.Add("");
                            itmEmp4.Add("");
                            itmEmp5.Add("");
                            itmEmp6.Add("");
                            if (soft.CV_EMPLOYEE.Count() != 0)
                            {
                                foreach (var x in soft.CV_EMPLOYEE.Select(a => a.PersRef).OrderBy(a => a).ToList())
                                {

                                    itmEmp1.Add(x);
                                    itmEmp2.Add(x);
                                    itmEmp3.Add(x);
                                    itmEmp4.Add(x);
                                    itmEmp5.Add(x);
                                    itmEmp6.Add(x);

                                }
                            }
                            comboEmplMet1.DataSource = itmEmp1;
                            comboEmplMet2.DataSource = itmEmp2;
                            comboEmplMet3.DataSource = itmEmp3;
                            comboPersTPH.DataSource = itmEmp4;
                            comboMainSup1.DataSource = itmEmp5;
                            comboMainSup2.DataSource = itmEmp6;
                            comboEmplMet1.SelectedItem = text1;
                            comboEmplMet2.SelectedItem = text2;
                            comboEmplMet3.SelectedItem = text3;
                            comboPersTPH.SelectedItem = text4;
                            comboMainSup1.SelectedItem = text5;
                            comboMainSup2.SelectedItem = text6;
                        }
                        else
                        {
                            comboEmplMet3.SelectedItem = "";
                        }
                    }

                }
            }
        }

        private void comboPosTarget_Validated(object sender, EventArgs e)
        {
            AutomVisitSPMU();
            if (Token.getAUTHO() == true)
            {
                if (!String.IsNullOrEmpty(comboPosTarget.Text))
                {

                    DbCVBASE soft = new DbCVBASE();
                    String text = comboPosTarget.Text;
                    var cat = soft.CV_CATEGORY.Where(a => a.Category.ToLower() == text.ToLower()).FirstOrDefault();
                    if (cat == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text + " \" does not exist in PositionHR table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_CATEGORY item = new CV_CATEGORY();
                            item.Category = text;
                            soft.CV_CATEGORY.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmcat = new List<String>();
                            itmcat.Add("");
                            if (soft.CV_CATEGORY.Count() != 0)
                            {
                                foreach (var x in soft.CV_CATEGORY.Select(a => a.Category).OrderBy(a => a).ToList())
                                {
                                    itmcat.Add(x);
                                }
                            }
                            comboPosTarget.DataSource = itmcat;
                            comboPosTarget.SelectedItem = text;
                        }
                        else
                        {
                            comboPosTarget.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboTestDone_Validated(object sender, EventArgs e)
        {
            AutomVisitSPMU();
            /*if (!String.IsNullOrEmpty(comboTestDone.Text))
            {

                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text = comboTestDone.Text;
                    var test = soft.CV_TEST.Where(a => a.Test.ToLower() == text.ToLower()).FirstOrDefault();
                    if (test == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text + " \" does not exist in Test table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_TEST item = new CV_TEST();
                            item.Test = text;
                            soft.CV_TEST.Add(item);
                            soft.SaveChanges();
                            MessageBox.Show("Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            List<String> itmtest = new List<String>();
                            itmtest.Add("");
                            if (soft.CV_TEST.Count() != 0)
                            {
                                foreach (var x in soft.CV_TEST.Select(a => a.Test).OrderBy(a => a).ToList())
                                {
                                    itmtest.Add(x);
                                }
                            }
                            comboTestDone.DataSource = itmtest;
                            comboTestDone.SelectedItem = text;
                        }
                        else
                        {
                            comboTestDone.SelectedItem = "";
                        }
                    }
                }
            }*/
        }

        private void comboGlobAppr_Validated(object sender, EventArgs e)
        {
            AutomVisitSPMU();
            if (!String.IsNullOrEmpty(comboGlobAppr.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text = comboGlobAppr.Text;
                    var test = soft.CV_GAPPREC.Where(a => a.GApprec.ToLower() == text.ToLower()).FirstOrDefault();
                    if (test == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text + " \" does not exist in GApprec table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_GAPPREC item = new CV_GAPPREC();
                            item.GApprec = text;
                            soft.CV_GAPPREC.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmtest = new List<String>();
                            itmtest.Add("");
                            if (soft.CV_GAPPREC.Count() != 0)
                            {
                                foreach (var x in soft.CV_GAPPREC.Select(a => a.GApprec).OrderBy(a => a).ToList())
                                {
                                    itmtest.Add(x);
                                }
                            }
                            comboGlobAppr.DataSource = itmtest;
                            comboGlobAppr.SelectedItem = text;
                        }
                        else
                        {
                            comboGlobAppr.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void textVisitSPMUComm_Validated(object sender, EventArgs e)
        {
            AutomVisitSPMU();
        }

        private static T GetPrevious<T>(IEnumerable<T> list, T current)
        {
            try
            {
                return list.TakeWhile(x => !x.Equals(current)).Last();
            }
            catch
            {
                return default(T);
            }
        }

        private static T GetNext<T>(IEnumerable<T> list, T current)
        {
            try
            {
                return list.SkipWhile(x => !x.Equals(current)).Skip(1).First();
            }
            catch
            {
                return default(T);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {

        }

        public void cvNextName(string cvName)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                List<string> stringList = new List<string>();

                string nextString = cvName;

                int isco = Token.getisCO();
                var iscoJun = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;
                var idJunSen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == iscoJun).FirstOrDefault().IDJunSenior;

                if (soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior == "ALL")
                {
                    if (soft.CV_CVBASE.Where(a => a.LastName == cvName).Count() != 0)
                    {
                        foreach (var x in soft.CV_CVBASE.OrderBy(a => a.LastName).ToList())
                            stringList.Add(x.LastName);

                        nextString = GetNext(stringList, cvName);
                    }

                    if (nextString != null)
                    {
                        comboName.Text = nextString;
                        DetailsCV(comboName.Text);
                    }
                    else
                    {
                        MessageBox.Show("No more further records", "CV Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    var isForDataSet = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior;
                    foreach (var x in soft.CV_JUNSENIOR.Where(a => a.JunSenior.ToUpper().Contains(isForDataSet.ToUpper())).ToList())
                    {
                        if (soft.CV_CVBASE.Where(a =>/* a.LastName == cvName && */a.IDJunSenior == x.IDJunSenior).Count() != 0)
                        {
                            foreach (var y in soft.CV_CVBASE.Where(a => a.IDJunSenior == x.IDJunSenior).OrderBy(a => a.LastName).ToList())
                                stringList.Add(y.LastName);
                        }
                    }
                    nextString = GetNext(stringList.OrderBy(a => a), cvName);

                    if (nextString != null)
                    {
                        comboName.Text = nextString;
                        DetailsCV(comboName.Text);
                    }
                    else
                    {
                        MessageBox.Show("No more further records", "CV Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void cvPrevName(string cvName)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                List<string> stringList = new List<string>();

                string prevString = cvName;

                int isco = Token.getisCO();
                var iscoJun = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;
                var idJunSen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == iscoJun).FirstOrDefault().IDJunSenior;

                if (soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior == "ALL")
                {
                    if (soft.CV_CVBASE.Where(a => a.LastName == cvName).Count() != 0)
                    {
                        foreach (var x in soft.CV_CVBASE.OrderBy(a => a.LastName).ToList())
                            stringList.Add(x.LastName);

                        prevString = GetPrevious(stringList, cvName);
                    }

                    if (prevString != null)
                    {
                        comboName.Text = prevString;
                        DetailsCV(comboName.Text);
                    }
                    else
                    {
                        MessageBox.Show("No more previous records", "CV Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    var isForDataSet = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior;
                    foreach (var x in soft.CV_JUNSENIOR.Where(a => a.JunSenior.ToUpper().Contains(isForDataSet.ToUpper())).ToList())
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == cvName && a.IDJunSenior == x.IDJunSenior).Count() != 0)
                        {
                            foreach (var y in soft.CV_CVBASE.Where(a => a.IDJunSenior == x.IDJunSenior).OrderBy(a => a.LastName).ToList())
                                stringList.Add(y.LastName);
                        }
                    }
                    prevString = GetPrevious(stringList.OrderBy(a => a), cvName);

                    if (prevString != null)
                    {
                        comboName.Text = prevString;
                        DetailsCV(comboName.Text);
                    }
                    else
                    {
                        MessageBox.Show("No more previous records", "CV Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void cvNextCat(string cvName, string cvCat)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                List<string> stringList = new List<string>();

                string nextStringName = cvName;

                string nextStringCat = cvCat;

                int isco = Token.getisCO();
                var iscoJun = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;
                var idJunSen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == iscoJun).FirstOrDefault().IDJunSenior;

                if (soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior == "ALL")
                {
                    if (soft.CV_CATEGORY.Where(a => a.Category == nextStringCat).Count() != 0)
                    {
                        var isCat = soft.CV_CATEGORY.Where(a => a.Category == nextStringCat).FirstOrDefault().IDCat;

                        if (soft.CV_CVBASE.Where(a => a.IDCat == isCat).Count() != 0)
                        {
                            foreach (var x in soft.CV_CVBASE.Where(a => a.IDCat == isCat).OrderBy(a => a.LastName).ToList())
                                stringList.Add(x.LastName);

                            nextStringName = GetNext(stringList, cvName);
                        }
                    }

                    if (nextStringName != null)
                    {
                        comboName.Text = nextStringName;
                        DetailsCV(comboName.Text);
                    }
                    else
                    {
                        MessageBox.Show("No more further records", "CV Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    var isForDataSet = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior;
                    if (soft.CV_CATEGORY.Where(a => a.Category == nextStringCat).Count() != 0)
                    {
                        var isCat = soft.CV_CATEGORY.Where(a => a.Category == nextStringCat).FirstOrDefault().IDCat;

                        foreach (var x in soft.CV_JUNSENIOR.Where(a => a.JunSenior.ToUpper().Contains(isForDataSet.ToUpper())).ToList())
                        {
                            if (soft.CV_CVBASE.Where(a => a.IDCat == isCat && a.IDJunSenior == x.IDJunSenior).Count() != 0)
                            {
                                foreach (var y in soft.CV_CVBASE.Where(a => a.IDCat == isCat && a.IDJunSenior == x.IDJunSenior).OrderBy(a => a.LastName).ToList())
                                    stringList.Add(y.LastName);
                            }
                        }
                        nextStringName = GetNext(stringList.OrderBy(a => a), cvName);

                        if (nextStringName != null)
                        {
                            comboName.Text = nextStringName;
                            DetailsCV(comboName.Text);
                        }
                        else
                        {
                            MessageBox.Show("No more further records", "CV Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void cvPrevCat(string cvName, string cvCat)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                List<string> stringList = new List<string>();

                string prevStringName = cvName;

                string prevStringCat = cvCat;

                int isco = Token.getisCO();
                var iscoJun = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;
                var idJunSen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == iscoJun).FirstOrDefault().IDJunSenior;

                if (soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior == "ALL")
                {
                    if (soft.CV_CATEGORY.Where(a => a.Category == prevStringCat).Count() != 0)
                    {
                        var isCat = soft.CV_CATEGORY.Where(a => a.Category == prevStringCat).FirstOrDefault().IDCat;

                        if (soft.CV_CVBASE.Where(a => a.IDCat == isCat).Count() != 0)
                        {
                            foreach (var x in soft.CV_CVBASE.Where(a => a.IDCat == isCat).OrderBy(a => a.LastName).ToList())
                                stringList.Add(x.LastName);

                            prevStringName = GetPrevious(stringList, cvName);
                        }
                    }

                    if (prevStringName != null)
                    {
                        comboName.Text = prevStringName;
                        DetailsCV(comboName.Text);
                    }
                    else
                    {
                        MessageBox.Show("No more previous records", "CV Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    var isForDataSet = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == idJunSen).FirstOrDefault().JunSenior;
                    if (soft.CV_CATEGORY.Where(a => a.Category == prevStringName).Count() != 0)
                    {
                        var isCat = soft.CV_CATEGORY.Where(a => a.Category == prevStringName).FirstOrDefault().IDCat;

                        foreach (var x in soft.CV_JUNSENIOR.Where(a => a.JunSenior.ToUpper().Contains(isForDataSet.ToUpper())).ToList())
                        {
                            if (soft.CV_CVBASE.Where(a => a.IDCat == isCat && a.IDJunSenior == x.IDJunSenior).Count() != 0)
                            {
                                foreach (var y in soft.CV_CVBASE.Where(a => a.IDCat == isCat && a.IDJunSenior == x.IDJunSenior).OrderBy(a => a.LastName).ToList())
                                    stringList.Add(y.LastName);
                            }
                        }
                        prevStringName = GetPrevious(stringList.OrderBy(a => a), cvName);

                        if (prevStringName != null)
                        {
                            comboName.Text = prevStringName;
                            DetailsCV(comboName.Text);
                        }
                        else
                        {
                            MessageBox.Show("No more previous records", "CV Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void cvPrevSEARCH(string cvName)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                List<string> stringList = new List<string>();

                stringList = Token.getLST();

                string prevString = cvName;

                prevString = GetPrevious(stringList, cvName);

                if (prevString != null)
                {
                    comboName.Text = prevString;
                    DetailsCV(comboName.Text);
                }
                else
                {
                    MessageBox.Show("No records with this browse option", "CV Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void cvNextSEARCH(string cvName)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                List<string> stringList = new List<string>();

                stringList = Token.getLST();

                string nextString = cvName;

                nextString = GetNext(stringList, cvName);

                if (nextString != null)
                {
                    comboName.Text = nextString;
                    DetailsCV(comboName.Text);
                }
                else
                {
                    MessageBox.Show("No more further records", "CV Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textdateInterview_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textdateInterview.Text))
            {
                DateTime maDate;
                bool result = DateTime.TryParse(textdateInterview.Text, out maDate);

                if (result == false)
                {
                    MessageBox.Show("Invalid format of the date", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textdateInterview.Text = null;
                }

                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            DateTime date = maDate.Date;

                            isForModif.DateSPMU = date;

                            soft.SaveChanges();
                        }
                    }
                }
            }
        }

        private void textdateCV_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textdateCV.Text))
            {
                DateTime maDate;
                bool result = DateTime.TryParse(textdateCV.Text, out maDate);

                if (result == false)
                {
                    MessageBox.Show("Invalid format of the date", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textdateCV.Text = null;
                }

                DbCVBASE soft = new DbCVBASE();

                if (checkAutoSave.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                    {
                        if (soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                        {
                            var isForModif = soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).FirstOrDefault();

                            DateTime datecv = maDate.Date;

                            isForModif.DateCV = datecv;

                            soft.SaveChanges();
                        }
                    }
                }
            }
        }

        private void textdateSDWork1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textdateSDWork1.Text))
            {
                DateTime maDate;
                bool result = DateTime.TryParse(textdateSDWork1.Text, out maDate);

                if (result == false)
                {
                    MessageBox.Show("Invalid format of the date", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textdateSDWork1.Text = null;
                }
            }
        }

        private void textdateSDWork2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textdateSDWork2.Text))
            {
                DateTime maDate;
                bool result = DateTime.TryParse(textdateSDWork2.Text, out maDate);

                if (result == false)
                {
                    MessageBox.Show("Invalid format of the date", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textdateSDWork2.Text = null;
                }
            }
        }

        private void textdateVisitSPMU_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textdateVisitSPMU.Text))
            {
                DateTime maDate;
                bool result = DateTime.TryParse(textdateVisitSPMU.Text, out maDate);

                if (result == false)
                {
                    MessageBox.Show("Invalid format of the date", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textdateVisitSPMU.Text = null;
                }

                AutomVisitSPMU();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@textDocLink1.Text))
                {
                    try
                    {
                        using (var fileStream = new FileStream(@textDocLink1.Text, FileMode.Open))
                        {
                            System.Diagnostics.Process.Start(@textDocLink1.Text);
                        }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("This file is already open", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@textDocLink2.Text))
                {
                    try
                    {
                        using (var fileStream = new FileStream(@textDocLink2.Text, FileMode.Open))
                        {
                            System.Diagnostics.Process.Start(@textDocLink2.Text);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("This file is already open", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@textDocLink3.Text))
                {
                    try
                    {
                        using (var fileStream = new FileStream(@textDocLink3.Text, FileMode.Open))
                        {
                            System.Diagnostics.Process.Start(@textDocLink3.Text);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("This file is already open", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@textDocLink4.Text))
                {
                    try
                    {
                        using (var fileStream = new FileStream(@textDocLink4.Text, FileMode.Open))
                        {
                            System.Diagnostics.Process.Start(@textDocLink4.Text);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("This file is already open", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@textDocLink5.Text))
                {
                    try
                    {
                        using (var fileStream = new FileStream(@textDocLink5.Text, FileMode.Open))
                        {
                            System.Diagnostics.Process.Start(@textDocLink5.Text);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("This file is already open", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textDocLink6.Text.StartsWith("DS//"))
            {
                try
                {
                    bool test = false;
                    if (dsParameter.authToken != null) test = String.IsNullOrEmpty(dsParameter.authToken.access_token);

                    if (!test) { 
                        //download CV
                        string s = textDocLink6.Text;
                        var split = s.Split('/');
                        var envId = split[split.Count() - 1];
                        string path = "";

                        MessageBox.Show("Please choose the folder for saving the CV", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                            path = folderBrowserDialog1.SelectedPath;

                            dsParameter.GetDocumentPDFTo(path, envId);
                        }
                        MessageBox.Show("CV Downloaded", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Please verify your Docusign Parameter", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (File.Exists(@textDocLink6.Text))
                    {
                        try
                        {
                            using (var fileStream = new FileStream(@textDocLink6.Text, FileMode.Open))
                            {
                                System.Diagnostics.Process.Start(@textDocLink6.Text);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("This file is already open", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(openFileDialog1.FileName);
                textDocLink6.Text = info.FullName;
            }
        }

        private void checkNoteGlobal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNoteGlobal.Checked)
                checkCat.Checked = false;
            if( checknote ==false){
                checknote = true;
                checkcat = false;
            }
            else
            {
                checknote = false;
            }
         
        }

        private void checkCat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCat.Checked)
                checkNoteGlobal.Checked = false;
            /*if( checkcat == false)
            {                       
                checkcat = true;
                checknote = false;
            }
            else
            {
                checkcat = false;

            }*/ 
       
        }

        private void textBonusDoc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(!String.IsNullOrEmpty(textBonusDoc.Text))
                {
                    int istest = 0;
                    int.TryParse(textBonusDoc.Text, out istest);
                    if (istest > 3)
                    {
                        MessageBox.Show("Bonus can't be > 3", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBonusDoc.Text = "0";
                    }
                }
                CALTOTAL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textCRScore4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CALTOTAL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void CALTOTAL()
        {
            try
            {
                int BONUS = 0;
                int DIPL = 0;
                int TFI = 0;
                int REG = 0;
                int CR1 = 0;
                int CR2 = 0;
                int CR3 = 0;
                int CR4 = 0;
                int CR5 = 0;

                //if (!String.IsNullOrEmpty(textBonusDoc.Text))
                //  //  BONUS = int.Parse(textBonusDoc.Text);
                //    int.TryParse(textBonusDoc.Text, out BONUS);
                //if (!String.IsNullOrEmpty(textScoreDipGen.Text))
                // //   DIPL = int.Parse(textScoreDipGen.Text);
                //int.TryParse(textScoreDipGen.Text, out DIPL);
                //if (!String.IsNullOrEmpty(textTFScore.Text))
                // //   TFI = int.Parse(textTFScore.Text);
                //int.TryParse(textTFScore.Text, out TFI);
                //if (!String.IsNullOrEmpty(textRScore.Text))
                // //   REG = int.Parse(textRScore.Text);
                //int.TryParse(textRScore.Text, out REG);
                //if (!String.IsNullOrEmpty(textCRScore1.Text))
                //  //  CR1 = int.Parse(textCRScore1.Text);
                //int.TryParse(textCRScore1.Text, out CR1);
                //if (!String.IsNullOrEmpty(textCRScore2.Text))
                //  //  CR2 = int.Parse(textCRScore2.Text);
                //int.TryParse(textCRScore2.Text, out CR2);
                //if (!String.IsNullOrEmpty(textCRScore3.Text))
                // //   CR3 = int.Parse(textCRScore3.Text);
                //int.TryParse(textCRScore3.Text, out CR3);
                //if (!String.IsNullOrEmpty(textCRScore4.Text))
                //  //  CR4 = int.Parse(textCRScore4.Text);
                //int.TryParse(textCRScore4.Text, out CR4);
                //if (!String.IsNullOrEmpty(textCRScore5.Text))
                // //   CR5 = int.Parse(textCRScore5.Text);
                //int.TryParse(textCRScore5.Text, out CR5);

                if (!String.IsNullOrEmpty(textBonusDoc.Text))
                    int.TryParse(textBonusDoc.Text, out BONUS);

                if (!String.IsNullOrEmpty(textScoreDipGen.Text))
                    int.TryParse(textScoreDipGen.Text, out DIPL);

                if (!String.IsNullOrEmpty(textTFScore.Text))
                    int.TryParse(textTFScore.Text, out TFI);

                if (!String.IsNullOrEmpty(textRScore.Text))
                    int.TryParse(textRScore.Text, out REG);

                if (!String.IsNullOrEmpty(textCRScore1.Text))
                    int.TryParse(textCRScore1.Text, out CR1);

                if (!String.IsNullOrEmpty(textCRScore2.Text))
                    int.TryParse(textCRScore2.Text, out CR2);

                if (!String.IsNullOrEmpty(textCRScore3.Text))
                    int.TryParse(textCRScore3.Text, out CR3);

                if (!String.IsNullOrEmpty(textCRScore4.Text))
                    int.TryParse(textCRScore4.Text, out CR4);

                if (!String.IsNullOrEmpty(textCRScore5.Text))
                    int.TryParse(textCRScore5.Text, out CR5);

                int TOTAL = BONUS + DIPL + TFI + REG + CR1 + CR2 + CR3 + CR4 + CR5;

                textNoteGlobal.Text = TOTAL.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboDipl1_Validated(object sender, EventArgs e)
        {
            try
            {
              /*  DbCVBASE soft = new DbCVBASE();

                textScoreDipl1.Text = "0";

                int DP1 = 0;
                int DP2 = 0;
                int DP3 = 0;

                if (!String.IsNullOrEmpty(textScoreDipl2.Text))
                    DP2 = int.Parse(textScoreDipl2.Text);
                if (!String.IsNullOrEmpty(textScoreDipl3.Text))
                    DP3 = int.Parse(textScoreDipl3.Text);

                if (!String.IsNullOrEmpty(comboDipl1.Text))
                {
                    if (soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl1.Text).Count() != 0)
                    {
                        var isDip = soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl1.Text).FirstOrDefault();

                        if (soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDip.IDDiploma).Count() != 0)
                        {
                            var isRank = soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDip.IDDiploma).FirstOrDefault();

                            textScoreDipl1.Text = isRank.Rank.Value.ToString();

                            DP1 = (int)isRank.Rank.Value;
                        }
                    }
                }
              
                int TOTAL = 0;

                if (DP1 >= DP2 && DP1 >= DP3)
                    TOTAL = DP1;
                else if (DP2 >= DP1 && DP2 >= DP3)
                    TOTAL = DP2;
                else if (DP3 >= DP1 && DP3 >= DP2)
                    TOTAL = DP3;

                textScoreDipGen.Text = TOTAL.ToString();

                */
                DbCVBASE soft = new DbCVBASE();
                if (!String.IsNullOrEmpty(comboDipl1.Text))
                {
                    if (Token.getAUTHO() == true)
                    {
                        String text1 = comboDipl1.Text;
                        String text2 = comboDipl2.Text;
                        String text3 = comboDipl3.Text;
                        var dipl = soft.CV_DIPLOMA.Where(a => a.Diploma.ToLower() == text1.ToLower()).FirstOrDefault();
                        if (dipl == null)
                        {
                            DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Education table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                CV_DIPLOMA item = new CV_DIPLOMA();
                                item.Diploma = text1;
                                soft.CV_DIPLOMA.Add(item);
                                soft.SaveChanges();

                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                List<String> itmDipl1 = new List<String>();
                                List<String> itmDipl3 = new List<String>();
                                List<String> itmDipl2 = new List<String>();
                                itmDipl1.Add("");
                                itmDipl2.Add("");
                                itmDipl3.Add("");
                                if (soft.CV_NATIONS.Count() != 0)
                                {
                                    foreach (var x in soft.CV_DIPLOMA.Select(a => a.Diploma).OrderBy(a => a).ToList())
                                    {
                                        itmDipl1.Add(x);
                                        itmDipl2.Add(x);
                                        itmDipl3.Add(x);
                                    }
                                }
                                comboDipl1.DataSource = itmDipl1;
                                comboDipl2.DataSource = itmDipl2;
                                comboDipl3.DataSource = itmDipl3;
                                comboDipl1.SelectedItem = text1;
                                comboDipl2.SelectedItem = text2;
                                comboDipl3.SelectedItem = text3;
                            }
                            else
                            {
                                comboDipl1.SelectedItem = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboDipl2_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

            
                if (!String.IsNullOrEmpty(comboDipl2.Text))
                {
                    if (Token.getAUTHO() == true)
                    {
                        String text = comboDipl2.Text;
                        String text1 = comboDipl1.Text;
                        String text3 = comboDipl3.Text;
                        var dipl = soft.CV_DIPLOMA.Where(a => a.Diploma.ToLower() == text.ToLower()).FirstOrDefault();
                        if (dipl == null)
                        {
                            DialogResult result = MessageBox.Show(" \"" + text + " \" does not exist in Education table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                CV_DIPLOMA item = new CV_DIPLOMA();
                                item.Diploma = text;
                                soft.CV_DIPLOMA.Add(item);
                                soft.SaveChanges();

                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                List<String> itmDipl = new List<String>();
                                List<String> itmDipl1 = new List<String>();
                                List<String> itmDipl2 = new List<String>();
                                itmDipl.Add("");
                                itmDipl1.Add("");
                                itmDipl2.Add("");
                                if (soft.CV_DIPLOMA.Count() != 0)
                                {
                                    foreach (var x in soft.CV_DIPLOMA.Select(a => a.Diploma).OrderBy(a => a).ToList())
                                    {
                                        itmDipl.Add(x);
                                        itmDipl1.Add(x);
                                        itmDipl2.Add(x);
                                    }
                                }
                                comboDipl1.DataSource = itmDipl;
                                comboDipl2.DataSource = itmDipl1;
                                comboDipl3.DataSource = itmDipl2;
                                comboDipl2.SelectedItem = text;
                                comboDipl1.SelectedItem = text1;
                                comboDipl3.SelectedItem = text3;
                            }
                            else
                            {
                                comboDipl2.SelectedItem = "";
                            }
                        }
                    }
                }
             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboDipl3_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

            
                if (!String.IsNullOrEmpty(comboDipl3.Text))
                {
                    if (Token.getAUTHO() == true)
                    {
                        String text = comboDipl3.Text;
                        String text1 = comboDipl1.Text;
                        String text2 = comboDipl2.Text;
                        var dipl = soft.CV_DIPLOMA.Where(a => a.Diploma.ToLower() == text.ToLower()).FirstOrDefault();
                        if (dipl == null)
                        {
                            DialogResult result = MessageBox.Show(" \"" + text + " \" does not exist in Education table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                CV_DIPLOMA item = new CV_DIPLOMA();
                                item.Diploma = text;
                                soft.CV_DIPLOMA.Add(item);
                                soft.SaveChanges();

                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                List<String> itmDipl = new List<String>();
                                List<String> itmDipl1 = new List<String>();
                                List<String> itmDipl2 = new List<String>();
                                itmDipl.Add("");
                                itmDipl1.Add("");
                                itmDipl2.Add("");
                                if (soft.CV_NATIONS.Count() != 0)
                                {
                                    foreach (var x in soft.CV_DIPLOMA.Select(a => a.Diploma).OrderBy(a => a).ToList())
                                    {
                                        itmDipl.Add(x);
                                        itmDipl1.Add(x);
                                        itmDipl2.Add(x);
                                    }
                                }
                                comboDipl1.DataSource = itmDipl;
                                comboDipl2.DataSource = itmDipl1;
                                comboDipl3.DataSource = itmDipl2;
                                comboDipl3.SelectedItem = text;
                                comboDipl1.SelectedItem = text1;
                                comboDipl2.SelectedItem = text2;
                            }
                            else
                            {
                                comboDipl3.SelectedItem = "";
                            }
                        }
                    }
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textCRYears1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sco = 0;
                int Tsco = 0;
                if (!String.IsNullOrEmpty(textCRYears1.Text))
                {
                    var result = int.TryParse(textCRYears1.Text, out sco);
                    if (result)
                        sco = int.Parse(textCRYears1.Text);
                }

                DbCVBASE soft = new DbCVBASE();

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }

                textCRScore1.Text = Tsco.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textCRYears2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sco = 0;
                int Tsco = 0;
                if (!String.IsNullOrEmpty(textCRYears2.Text))
                {
                    var result = int.TryParse(textCRYears2.Text, out sco);
                    if (result)
                        sco = int.Parse(textCRYears2.Text);
                }

                DbCVBASE soft = new DbCVBASE();

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }

                textCRScore2.Text = Tsco.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textCRYears3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sco = 0;
                int Tsco = 0;
                if (!String.IsNullOrEmpty(textCRYears3.Text))
                {
                    var result = int.TryParse(textCRYears3.Text, out sco);
                    if (result)
                        sco = int.Parse(textCRYears3.Text);
                }

                DbCVBASE soft = new DbCVBASE();

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }

                textCRScore3.Text = Tsco.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textCRYears4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sco = 0;
                int Tsco = 0;
                if (!String.IsNullOrEmpty(textCRYears4.Text))
                {
                    var result = int.TryParse(textCRYears4.Text, out sco);
                    if (result)
                        sco = int.Parse(textCRYears4.Text);
                }

                DbCVBASE soft = new DbCVBASE();

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }

                textCRScore4.Text = Tsco.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void YTF()
        {
            try
            {
                int Tsco = 0;
                int sco = 0;
                int sco1 = 0;
                int sco2 = 0;
                int sco3 = 0;

                if (!String.IsNullOrEmpty(textTFYears1.Text))
                {
                    var result = int.TryParse(textTFYears1.Text, out sco1);
                    if (result)
                        sco1 = int.Parse(textTFYears1.Text);
                }
                if (!String.IsNullOrEmpty(textTFYears2.Text))
                {
                    var result = int.TryParse(textTFYears2.Text, out sco2);
                    if (result)
                        sco2 = int.Parse(textTFYears2.Text);
                }
                if (!String.IsNullOrEmpty(textTFYears3.Text))
                {
                    var result = int.TryParse(textTFYears3.Text, out sco3);
                    if (result)
                        sco3 = int.Parse(textTFYears3.Text);
                }

                sco = sco1 + sco2 + sco3;

                DbCVBASE soft = new DbCVBASE();

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }

                textTFScore.Text = Tsco.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textTFYears1_TextChanged(object sender, EventArgs e)
        {
            YTF();
        }

        private void textTFYears2_TextChanged(object sender, EventArgs e)
        {
            YTF();
        }

        private void textTFYears3_TextChanged(object sender, EventArgs e)
        {
            YTF();
        }

        public void REW()
        {
            try
            {
                int Tsco = 0;
                int sco = 0;
                int sco1 = 0;
                int sco2 = 0;
                int sco3 = 0;

                if (!String.IsNullOrEmpty(textRYears1.Text))
                {
                    var result = int.TryParse(textRYears1.Text, out sco1);
                    if (result)
                        sco1 = int.Parse(textRYears1.Text);
                }
                if (!String.IsNullOrEmpty(textRYears2.Text))
                {
                    var result = int.TryParse(textRYears2.Text, out sco2);
                    if (result)
                        sco2 = int.Parse(textRYears2.Text);
                }
                if (!String.IsNullOrEmpty(textRYears3.Text))
                {
                    var result = int.TryParse(textRYears3.Text, out sco3);
                    if (result)
                        sco3 = int.Parse(textRYears3.Text);
                }

                sco = sco1 + sco2 + sco3;

                DbCVBASE soft = new DbCVBASE();

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }

                textRScore.Text = Tsco.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textRYears1_TextChanged(object sender, EventArgs e)
        {
            REW();
        }

        private void textRYears2_TextChanged(object sender, EventArgs e)
        {
            REW();
        }

        private void textRYears3_TextChanged(object sender, EventArgs e)
        {
            REW();
        }

        private void textTFYears1_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textTFYears1.Text))
                textTFYears1.Text = "0";
            int testint;
            if (int.TryParse(textTFYears1.Text, out testint))
            {
                textTFYears1.Text = string.Format("{0:#,##0}", int.Parse(textTFYears1.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption,MessageBoxButtons.OK,MessageBoxIcon.Error);
                textTFYears1.Text = "0";
            }
        }

        private void textTFYears2_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textTFYears2.Text))
                textTFYears2.Text = "0";
            int testint;
            if (int.TryParse(textTFYears2.Text, out testint))
            {
                textTFYears2.Text = string.Format("{0:#,##0}", int.Parse(textTFYears2.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTFYears2.Text = "0";
            }
         
        }

        private void textTFYears3_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textTFYears3.Text))
                textTFYears3.Text = "0";
            int testint;
            if (int.TryParse(textTFYears3.Text, out testint))
            {
                textTFYears3.Text = string.Format("{0:#,##0}", int.Parse(textTFYears3.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTFYears3.Text = "0";
            }
         
        }

        private void textRYears1_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textRYears1.Text))
                textRYears1.Text = "0";
            int testint;
            if (int.TryParse(textRYears1.Text, out testint))
            {
                textRYears1.Text = string.Format("{0:#,##0}", int.Parse(textRYears1.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textRYears1.Text = "0";
            }
         
        }

        private void textRYears2_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textRYears2.Text))
                textRYears2.Text = "0";
            int testint;
            if (int.TryParse(textRYears2.Text, out testint))
            {
                textRYears2.Text = string.Format("{0:#,##0}", int.Parse(textRYears2.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textRYears2.Text = "0";
            }
         
        }

        private void textRYears3_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textRYears3.Text))
                textRYears3.Text = "0";
            int testint;
            if (int.TryParse(textRYears3.Text, out testint))
            {
                textRYears3.Text = string.Format("{0:#,##0}", int.Parse(textRYears3.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textRYears3.Text = "0";
            }
        }

        private void textCRYears1_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textCRYears1.Text))
                textCRYears1.Text = "0";
            int testint;
            if (int.TryParse(textCRYears1.Text, out testint))
            {
                textCRYears1.Text = string.Format("{0:#,##0}", int.Parse(textCRYears1.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textCRYears1.Text = "0";
            }
        }

        private void textCRYears2_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textCRYears2.Text))
                textCRYears2.Text = "0";
          
            int testint;
            if (int.TryParse(textCRYears2.Text, out testint))
            {
                textCRYears2.Text = string.Format("{0:#,##0}", int.Parse(textCRYears2.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textCRYears2.Text = "0";
            }
        }

        private void textCRYears3_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textCRYears3.Text))
                textCRYears3.Text = "0";
            int testint;
            if (int.TryParse(textCRYears3.Text, out testint))
            {
                textCRYears3.Text = string.Format("{0:#,##0}", int.Parse(textCRYears3.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textCRYears3.Text = "0";
            }
        }

        private void textCRYears4_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textCRYears4.Text))
                textCRYears4.Text = "0";
            int testint;
            if (int.TryParse(textCRYears4.Text, out testint))
            {
                textCRYears4.Text = string.Format("{0:#,##0}", int.Parse(textCRYears4.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textCRYears4.Text = "0";
            }
        }

        private void textDurWeek1_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textDurWeek1.Text))
                textDurWeek1.Text = "0";
            int testint;
            if (int.TryParse(textDurWeek1.Text, out testint))
            {
                textDurWeek1.Text = string.Format("{0:#,##0}", int.Parse(textDurWeek1.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDurWeek1.Text = "0";
            }
        }

        private void textDurWeek2_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textDurWeek2.Text))
                textDurWeek2.Text = "0";
            int testint;
            if (int.TryParse(textDurWeek2.Text, out testint))
            {
                textDurWeek2.Text = string.Format("{0:#,##0}", int.Parse(textDurWeek2.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDurWeek2.Text = "0";
            }
        }

        private void textDailyFeePaid1_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textDailyFeePaid1.Text))
                textDailyFeePaid1.Text = "0.00";
            decimal testint;
            if (decimal.TryParse(textDailyFeePaid1.Text, out testint))
            {
                textDailyFeePaid1.Text = string.Format("{0:#,##0.00}", decimal.Parse(textDailyFeePaid1.Text));
            }
            else
            {
                string message = "invalid or too large number";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDailyFeePaid1.Text = "0.00";
            }
            
           
        }

        private void textDailyFeePaid2_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textDailyFeePaid2.Text))
                textDailyFeePaid2.Text = "0.00";
            decimal testint;
            if (decimal.TryParse(textDailyFeePaid2.Text, out testint))
            {
                textDailyFeePaid2.Text = string.Format("{0:#,##0.00}", decimal.Parse(textDailyFeePaid2.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDailyFeePaid2.Text = "0.00";
            }
           
        }
        public void checkupdate ()
        {
            var tbox = Controls.OfType<TextBox>().ToDictionary(x => x.Name, x => x.Text);
            var combo = Controls.OfType<ComboBox>().ToDictionary(x => x.Name, x => x.Text);
            var check = Controls.OfType<CheckBox>().ToDictionary(x => x.Name, x => x.CheckState);
            var tbox1 = new Dictionary<string, string>();
            var combo1 = new Dictionary<string, string>();

            foreach (TabPage t in tabControl1.TabPages)
            {
                foreach (Control c in t.Controls)
                {
                    if (c is GroupBox)
                    {
                        foreach (Control cc in c.Controls)
                        {
                            if (cc is TextBox)
                            {
                                if (!tbox1.ContainsKey(cc.Name)) tbox1.Add(cc.Name, cc.Text);
                            }
                            if (cc is ComboBox)
                            {
                                if (!combo1.ContainsKey(cc.Name)) combo1.Add(cc.Name, cc.Text);
                                
                            }
                        }
                    }
                }
            }

            tbox.Add(textExpSWISSComm.Name, textExpSWISSComm.Text);
            tbox.Add(textINTLExpComm.Name, textINTLExpComm.Text);

            foreach (var item in tbox)
            {
                if (AllTextBox.ContainsKey(item.Key) && item.Value != AllTextBox[item.Key])
                {
                    if (item.Key != "textAgeCalc" || item.Key != "textDateCreate" || item.Key != "textExpSWISSComm" || item.Key == "textINTLExpComm")
                    {
                        updated = true;
                     //   AllTextBox[item.Key] = tbox[item.Key];
                    }
                }
            }

            foreach (var item in combo)
            {
                if (AllComboBox.ContainsKey(item.Key) && item.Value != AllComboBox[item.Key])
                {
                    if (item.Key != "comboName")
                    { 
                        updated = true; 
                    }
                //    AllComboBox[item.Key] = combo[item.Key];
                }
            }

            foreach (var item in check)
            {
                if ((item.Key == "checkSleep"))
                {
                   
                    if (AllCheckBox.ContainsKey(item.Key) && item.Value != AllCheckBox[item.Key])
                    {
                        updated = true;
                    //    AllCheckBox[item.Key] = check[item.Key];
                    }
                }
            }

            foreach (var item in tbox1)
            {
                if (AllTextBox1.ContainsKey(item.Key) && item.Value != AllTextBox1[item.Key])
                {
                    updated = true;
                  //  AllTextBox1[item.Key] = tbox1[item.Key];
                }
            }

            foreach (var item in combo1)
            {
                if (AllComboBox1.ContainsKey(item.Key) && item.Value != AllComboBox1[item.Key])
                {
                    updated = true;
                  //  AllComboBox1[item.Key] = combo1[item.Key];
                }
            }
        }
        private void Frm_cvadd_FormClosed(object sender,FormClosedEventArgs e)
        {
           
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Token.getAUTHO() == false)
            {
                MessageBox.Show("Your current status does not authorise the modification of CV" + "\n\n" + "Please contact Admin", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //checkupdate();

                InsertOrUpdateCV();

                //if (updated == true)
                //{
                //    InsertOrUpdateCV();
                //}
            }
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkupdate();     
            DbCVBASE soft = new DbCVBASE();

            int isco = Token.getisCO();
            var iscoJun = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;
            textPrenom.Focus();
            if (!String.IsNullOrEmpty(iscoJun))
            {
                if (Token.getAUTHO() == true){
                    if (updated == true)
                    {
                        string message = string.Format("You have modified data of {0} {1}! \n Would you like to record this new set of data ? ",textPrenom.Text, comboName.Text) ;
                        string caption = "CVBASE";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(message, caption, buttons);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            InsertOrUpdateCV();
                        }
                  
                    }
                 }
                if (!checkCat.Checked && !checkNoteGlobal.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                        cvPrevName(comboName.Text);
                }

                if (checkCat.Checked && !checkNoteGlobal.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text) && !String.IsNullOrEmpty(comboCat.Text))
                        cvPrevCat(comboName.Text, comboCat.Text);
                }

                if (!checkCat.Checked && checkNoteGlobal.Checked)
                {
                    if (Token.getLST() != null)
                        cvPrevSEARCH(comboName.Text);
                }
               
                CHANGEJUNSENFORCALCULATE();
            }
            else
                MessageBox.Show("Data set undefined", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkupdate();
            DbCVBASE soft = new DbCVBASE();

            int isco = Token.getisCO();
            var iscoJun = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;
            textPrenom.Focus();
            if (!String.IsNullOrEmpty(iscoJun))
            {
                if (Token.getAUTHO() == true)
                {

                    if (updated == true)
                    {
                        string message = string.Format("You have modified data of {0} {1}! \n Would you like to record this new set of data ? ", textPrenom.Text, comboName.Text);
                        string caption = "CVBASE";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(message, caption, buttons);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            InsertOrUpdateCV();
                        }
                    }
                }
                if (!checkCat.Checked && !checkNoteGlobal.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text))
                        cvNextName(comboName.Text);
                }

                if (checkCat.Checked && !checkNoteGlobal.Checked)
                {
                    if (!String.IsNullOrEmpty(comboName.Text) && !String.IsNullOrEmpty(comboCat.Text))
                        cvNextCat(comboName.Text, comboCat.Text);
                }

                if (!checkCat.Checked && checkNoteGlobal.Checked)
                {
                    if (Token.getLST() != null)
                        cvNextSEARCH(comboName.Text);
                }

                CHANGEJUNSENFORCALCULATE();
            }
            else
                MessageBox.Show("Data set undefined", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@textLink1.Text))
                {
                    using (var fileStream = new FileStream(@textLink1.Text, FileMode.Open))
                    {
                        System.Diagnostics.Process.Start(@textLink1.Text);
                    }
                }
                else
                    MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@textLink2.Text))
                {
                    using (var fileStream = new FileStream(@textLink2.Text, FileMode.Open))
                    {
                        System.Diagnostics.Process.Start(@textLink2.Text);
                    }
                }
                else
                    MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("File not found or corrupted link", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textCRYears5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int sco = 0;
                int Tsco = 0;
                if (!String.IsNullOrEmpty(textCRYears5.Text))
                {
                    var result = int.TryParse(textCRYears5.Text, out sco);
                    if (result)
                        sco = int.Parse(textCRYears5.Text);
                }

                DbCVBASE soft = new DbCVBASE();

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }

                textCRScore5.Text = Tsco.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textCRYears5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 && entrer != 44)
            {
                e.Handled = true;
            }
        }

        private void textCRYears5_Validated(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(textCRYears5.Text))
            //    textCRYears5.Text = "";
            if (String.IsNullOrEmpty(textCRYears5.Text))
                textCRYears5.Text = "0";
            int testint;
            if (int.TryParse(textCRYears5.Text, out testint))
            {
                textCRYears5.Text = string.Format("{0:#,##0}", int.Parse(textCRYears5.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textCRYears5.Text = "0";
            }
        }

        private void textDiplY1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 && entrer != 44)
            {
                e.Handled = true;
            }
        }

        private void textDiplY2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 && entrer != 44)
            {
                e.Handled = true;
            }
        }

        private void textDiplY3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 && entrer != 44)
            {
                e.Handled = true;
            }
        }

        private void textPostGradY1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 && entrer != 44)
            {
                e.Handled = true;
            }
        }

        private void textPostGradY2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 && entrer != 44)
            {
                e.Handled = true;
            }
        }

        private void textPostGradY3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 && entrer != 44)
            {
                e.Handled = true;
            }
        }

        private void textDiplY1_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textDiplY1.Text))
                textDiplY1.Text = "";
            else
            {
                int isYearsToday = DateTime.Now.Year;
                int min = 1960;
                int years = int.Parse(textDiplY1.Text);
                if (years < min || years > isYearsToday)
                {
                 
                    MessageBox.Show("Years can't be < " + min + " and > " + isYearsToday, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textDiplY1.Text = "";
                }
            }
        }

        private void textDiplY2_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textDiplY2.Text))
                textDiplY2.Text = "";
            else
            {
                int isYearsToday = DateTime.Now.Year;
                int min = 1960;
                int years = int.Parse(textDiplY2.Text);
                if (years < min || years > isYearsToday)
                {
                   
                    MessageBox.Show("Years can't be < " + min + " and > " + isYearsToday, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textDiplY2.Text = "";
                }
            }
        }

        private void textDiplY3_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textDiplY3.Text))
                textDiplY3.Text = "";
            else
            {
                int isYearsToday = DateTime.Now.Year;
                int min = 1960;
                int years = int.Parse(textDiplY3.Text);
                if (years < min || years > isYearsToday)
                {
                
                    MessageBox.Show("Years can't be < " + min + " and > " + isYearsToday, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textDiplY3.Text = "";
                }
            }
        }

        private void textPostGradY1_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textPostGradY1.Text))
                textPostGradY1.Text = "";
            else
            {
                int isYearsToday = DateTime.Now.Year;
                int min = 1960;
                int years = int.Parse(textPostGradY1.Text);
                if (years < min || years > isYearsToday)
                {
                  
                    MessageBox.Show("Years can't be < " + min + " and > " + isYearsToday, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textPostGradY1.Text = "";
                }
            }
        }

        private void textPostGradY2_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textPostGradY2.Text))
                textPostGradY2.Text = "";
            else
            {
                int isYearsToday = DateTime.Now.Year;
                int min = 1960;
                int years = int.Parse(textPostGradY2.Text);
                if (years < min || years > isYearsToday)
                {
                  
                    MessageBox.Show("Years can't be < " + min + " and > " + isYearsToday, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textPostGradY2.Text = "";
                }
            }
        }

        private void textPostGradY3_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textPostGradY3.Text))
                textPostGradY3.Text = "";
            else
            {
                int isYearsToday = DateTime.Now.Year;
                int min = 1960;
                int years = int.Parse(textPostGradY3.Text);
                if (years < min || years > isYearsToday)
                {
                  
                    MessageBox.Show("Years can't be < " + min + " and > " + isYearsToday, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textPostGradY3.Text = "";
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(epl1.Text))
                {
                    var uri = epl1.Text;
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The link does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(epl2.Text))
                {
                    var uri = epl2.Text;
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The link does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(epl3.Text))
                {
                    var uri = epl3.Text;
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The link does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(ocl1.Text))
                {
                    var uri = ocl1.Text;
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The link does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(ocl2.Text))
                {
                    var uri = ocl2.Text;
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The link does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(ocl3.Text))
                {
                    var uri = ocl3.Text;
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The link does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(eplw1.Text))
                {
                    var uri = eplw1.Text;
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The link does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(eplw2.Text))
                {
                    var uri = eplw2.Text;
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The link does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(eplw3.Text))
                {
                    var uri = eplw3.Text;
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The link does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(ocla1.Text))
                {
                    var uri = ocla1.Text;
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The link does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(ocla2.Text))
                {
                    var uri = ocla2.Text;
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The link does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(ocla3.Text))
                {
                    var uri = ocla3.Text;
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The link does not exist", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboJunSenior_TextChanged(object sender, EventArgs e)
        {
            CHANGEJUNSENFORCALCULATE();
        }

        public void CHANGEJUNSENFORCALCULATE()
        {
            try
            {
                //TF//
                int Tsco = 0;
                int sco = 0;
                int sco1 = 0;
                int sco2 = 0;
                int sco3 = 0;

                if (!String.IsNullOrEmpty(textTFYears1.Text))
                {
                    var result = int.TryParse(textTFYears1.Text, out sco1);
                    if (result)
                        sco1 = int.Parse(textTFYears1.Text);
                }
                if (!String.IsNullOrEmpty(textTFYears2.Text))
                {
                    var result = int.TryParse(textTFYears2.Text, out sco2);
                    if (result)
                        sco2 = int.Parse(textTFYears2.Text);
                }
                if (!String.IsNullOrEmpty(textTFYears3.Text))
                {
                    var result = int.TryParse(textTFYears3.Text, out sco3);
                    if (result)
                        sco3 = int.Parse(textTFYears3.Text);
                }

                sco = sco1 + sco2 + sco3;

                DbCVBASE soft = new DbCVBASE();

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (sco < isSCORE.V1)
                        Tsco = 0;
                    else if (sco >= isSCORE.V1 && sco <= isSCORE.V2)
                        Tsco = 1;
                    else if (sco > isSCORE.V2 && sco <= isSCORE.V3)
                        Tsco = 2;
                    else if (sco > isSCORE.V3)
                        Tsco = 3;
                }

                textTFScore.Text = Tsco.ToString();

                //REG//
                int TscoR = 0;
                int scoR = 0;
                int sco1R = 0;
                int sco2R = 0;
                int sco3R = 0;

                if (!String.IsNullOrEmpty(textRYears1.Text))
                {
                    var result = int.TryParse(textRYears1.Text, out sco1R);
                    if (result)
                        sco1R = int.Parse(textRYears1.Text);
                }
                if (!String.IsNullOrEmpty(textRYears2.Text))
                {
                    var result = int.TryParse(textRYears2.Text, out sco2R);
                    if (result)
                        sco2R = int.Parse(textRYears2.Text);
                }
                if (!String.IsNullOrEmpty(textRYears3.Text))
                {
                    var result = int.TryParse(textRYears3.Text, out sco3R);
                    if (result)
                        sco3R = int.Parse(textRYears3.Text);
                }

                scoR = sco1R + sco2R + sco3R;

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (scoR < isSCORE.V1)
                        TscoR = 0;
                    else if (scoR >= isSCORE.V1 && scoR <= isSCORE.V2)
                        TscoR = 1;
                    else if (scoR > isSCORE.V2 && scoR <= isSCORE.V3)
                        TscoR = 2;
                    else if (scoR > isSCORE.V3)
                        TscoR = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (scoR < isSCORE.V1)
                        TscoR = 0;
                    else if (scoR >= isSCORE.V1 && scoR <= isSCORE.V2)
                        TscoR = 1;
                    else if (scoR > isSCORE.V2 && scoR <= isSCORE.V3)
                        TscoR = 2;
                    else if (scoR > isSCORE.V3)
                        TscoR = 3;
                }

                textRScore.Text = TscoR.ToString();

                //CR//
                //1//
                int scoC1 = 0;
                int TscoC1 = 0;
                if (!String.IsNullOrEmpty(textCRYears1.Text))
                {
                    var result = int.TryParse(textCRYears1.Text, out scoC1);
                    if (result)
                        scoC1 = int.Parse(textCRYears1.Text);
                }

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (scoC1 < isSCORE.V1)
                        TscoC1 = 0;
                    else if (scoC1 >= isSCORE.V1 && scoC1 <= isSCORE.V2)
                        TscoC1 = 1;
                    else if (scoC1 > isSCORE.V2 && scoC1 <= isSCORE.V3)
                        TscoC1 = 2;
                    else if (scoC1 > isSCORE.V3)
                        TscoC1 = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (scoC1 < isSCORE.V1)
                        TscoC1 = 0;
                    else if (scoC1 >= isSCORE.V1 && scoC1 <= isSCORE.V2)
                        TscoC1 = 1;
                    else if (scoC1 > isSCORE.V2 && scoC1 <= isSCORE.V3)
                        TscoC1 = 2;
                    else if (scoC1 > isSCORE.V3)
                        TscoC1 = 3;
                }

                textCRScore1.Text = TscoC1.ToString();

                //2//
                int scoC2 = 0;
                int TscoC2 = 0;
                if (!String.IsNullOrEmpty(textCRYears2.Text))
                {
                    var result = int.TryParse(textCRYears2.Text, out scoC2);
                    if (result)
                        scoC2 = int.Parse(textCRYears2.Text);
                }

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (scoC2 < isSCORE.V1)
                        TscoC2 = 0;
                    else if (scoC2 >= isSCORE.V1 && scoC2 <= isSCORE.V2)
                        TscoC2 = 1;
                    else if (scoC2 > isSCORE.V2 && scoC2 <= isSCORE.V3)
                        TscoC2 = 2;
                    else if (scoC2 > isSCORE.V3)
                        TscoC2 = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (scoC2 < isSCORE.V1)
                        TscoC2 = 0;
                    else if (scoC2 >= isSCORE.V1 && scoC2 <= isSCORE.V2)
                        TscoC2 = 1;
                    else if (scoC2 > isSCORE.V2 && scoC2 <= isSCORE.V3)
                        TscoC2 = 2;
                    else if (scoC2 > isSCORE.V3)
                        TscoC2 = 3;
                }

                textCRScore2.Text = TscoC2.ToString();

                //3//
                int scoC3 = 0;
                int TscoC3 = 0;
                if (!String.IsNullOrEmpty(textCRYears3.Text))
                {
                    var result = int.TryParse(textCRYears3.Text, out scoC3);
                    if (result)
                        scoC3 = int.Parse(textCRYears3.Text);
                }

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (scoC3 < isSCORE.V1)
                        TscoC3 = 0;
                    else if (scoC3 >= isSCORE.V1 && scoC3 <= isSCORE.V2)
                        TscoC3 = 1;
                    else if (scoC3 > isSCORE.V2 && scoC3 <= isSCORE.V3)
                        TscoC3 = 2;
                    else if (scoC3 > isSCORE.V3)
                        TscoC3 = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (scoC3 < isSCORE.V1)
                        TscoC3 = 0;
                    else if (scoC3 >= isSCORE.V1 && scoC3 <= isSCORE.V2)
                        TscoC3 = 1;
                    else if (scoC3 > isSCORE.V2 && scoC3 <= isSCORE.V3)
                        TscoC3 = 2;
                    else if (scoC3 > isSCORE.V3)
                        TscoC3 = 3;
                }

                textCRScore3.Text = TscoC3.ToString();

                //4//
                int scoC4 = 0;
                int TscoC4 = 0;
                if (!String.IsNullOrEmpty(textCRYears4.Text))
                {
                    var result = int.TryParse(textCRYears4.Text, out scoC4);
                    if (result)
                        scoC4 = int.Parse(textCRYears4.Text);
                }

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (scoC4 < isSCORE.V1)
                        TscoC4 = 0;
                    else if (scoC4 >= isSCORE.V1 && scoC4 <= isSCORE.V2)
                        TscoC4 = 1;
                    else if (scoC4 > isSCORE.V2 && scoC4 <= isSCORE.V3)
                        TscoC4 = 2;
                    else if (scoC4 > isSCORE.V3)
                        TscoC4 = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (scoC4 < isSCORE.V1)
                        TscoC4 = 0;
                    else if (scoC4 >= isSCORE.V1 && scoC4 <= isSCORE.V2)
                        TscoC4 = 1;
                    else if (scoC4 > isSCORE.V2 && scoC4 <= isSCORE.V3)
                        TscoC4 = 2;
                    else if (scoC4 > isSCORE.V3)
                        TscoC4 = 3;
                }

                textCRScore4.Text = TscoC4.ToString();

                //5//
                int scoC5 = 0;
                int TscoC5 = 0;
                if (!String.IsNullOrEmpty(textCRYears5.Text))
                {
                    var result = int.TryParse(textCRYears5.Text, out scoC5);
                    if (result)
                        scoC5 = int.Parse(textCRYears5.Text);
                }

                if (comboJunSenior.Text == "Junior" || comboJunSenior.Text == "Junior LFA" || comboJunSenior.Text.ToUpper().Contains("JUNIOR"))
                {
                    var isSCORE = soft.CV_RANKJUN.FirstOrDefault();
                    if (scoC5 < isSCORE.V1)
                        TscoC5 = 0;
                    else if (scoC5 >= isSCORE.V1 && scoC5 <= isSCORE.V2)
                        TscoC5 = 1;
                    else if (scoC5 > isSCORE.V2 && scoC5 <= isSCORE.V3)
                        TscoC5 = 2;
                    else if (scoC5 > isSCORE.V3)
                        TscoC5 = 3;
                }
                else if (comboJunSenior.Text == "Senior" || comboJunSenior.Text == "Senior LFA" || comboJunSenior.Text.ToUpper().Contains("SENIOR"))
                {
                    var isSCORE = soft.CV_RANKSEN.FirstOrDefault();
                    if (scoC5 < isSCORE.V1)
                        TscoC5 = 0;
                    else if (scoC5 >= isSCORE.V1 && scoC5 <= isSCORE.V2)
                        TscoC5 = 1;
                    else if (scoC5 > isSCORE.V2 && scoC5 <= isSCORE.V3)
                        TscoC5 = 2;
                    else if (scoC5 > isSCORE.V3)
                        TscoC5 = 3;
                }

                textCRScore5.Text = TscoC5.ToString();

                CALTOTAL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboDoc1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboDoc1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboDoc1.Text;
                    String text2 = comboDoc2.Text;
                    String text3 = comboDoc3.Text;
                    String text4 = comboDoc4.Text;
                    String text5 = comboDoc5.Text;
                    var doc = soft.CV_DOCUMENT.Where(a => a.Docum.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (doc == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Document table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_DOCUMENT item = new CV_DOCUMENT();
                            item.Docum = text1;
                            soft.CV_DOCUMENT.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmDoc1 = new List<String>();
                            List<String> itmDoc2 = new List<String>();
                            List<String> itmDoc3 = new List<String>();
                            List<String> itmDoc4 = new List<String>();
                            List<String> itmDoc5 = new List<String>();
                            itmDoc1.Add("");
                            itmDoc2.Add("");
                            itmDoc3.Add("");
                            itmDoc4.Add("");
                            itmDoc5.Add("");
                            if (soft.CV_DOCUMENT.Count() != 0)
                            {
                                foreach (var x in soft.CV_DOCUMENT.Select(a => a.Docum).OrderBy(a => a).ToList())
                                {
                                    itmDoc1.Add(x);
                                    itmDoc2.Add(x);
                                    itmDoc3.Add(x);
                                    itmDoc4.Add(x);
                                    itmDoc5.Add(x);
                                }
                            }
                            comboDoc1.DataSource = itmDoc1;
                            comboDoc2.DataSource = itmDoc2;
                            comboDoc3.DataSource = itmDoc3;
                            comboDoc4.DataSource = itmDoc4;
                            comboDoc5.DataSource = itmDoc5;
                            comboDoc1.SelectedItem = text1;
                            comboDoc2.SelectedItem = text2;
                            comboDoc3.SelectedItem = text3;
                            comboDoc4.SelectedItem = text4;
                            comboDoc5.SelectedItem = text5;
                        }
                        else
                        {
                            comboDoc1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboDoc2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboDoc2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboDoc1.Text;
                    String text2 = comboDoc2.Text;
                    String text3 = comboDoc3.Text;
                    String text4 = comboDoc4.Text;
                    String text5 = comboDoc5.Text;
                    var doc = soft.CV_DOCUMENT.Where(a => a.Docum.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (doc == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Document table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_DOCUMENT item = new CV_DOCUMENT();
                            item.Docum = text2;
                            soft.CV_DOCUMENT.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmDoc1 = new List<String>();
                            List<String> itmDoc2 = new List<String>();
                            List<String> itmDoc3 = new List<String>();
                            List<String> itmDoc4 = new List<String>();
                            List<String> itmDoc5 = new List<String>();
                            itmDoc1.Add("");
                            itmDoc2.Add("");
                            itmDoc3.Add("");
                            itmDoc4.Add("");
                            itmDoc5.Add("");
                            if (soft.CV_DOCUMENT.Count() != 0)
                            {
                                foreach (var x in soft.CV_DOCUMENT.Select(a => a.Docum).OrderBy(a => a).ToList())
                                {
                                    itmDoc1.Add(x);
                                    itmDoc2.Add(x);
                                    itmDoc3.Add(x);
                                    itmDoc4.Add(x);
                                    itmDoc5.Add(x);
                                }
                            }
                            comboDoc1.DataSource = itmDoc1;
                            comboDoc2.DataSource = itmDoc2;
                            comboDoc3.DataSource = itmDoc3;
                            comboDoc4.DataSource = itmDoc4;
                            comboDoc5.DataSource = itmDoc5;
                            comboDoc1.SelectedItem = text1;
                            comboDoc2.SelectedItem = text2;
                            comboDoc3.SelectedItem = text3;
                            comboDoc4.SelectedItem = text4;
                            comboDoc5.SelectedItem = text5;
                        }
                        else
                        {
                            comboDoc2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboDoc3_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboDoc3.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboDoc1.Text;
                    String text2 = comboDoc2.Text;
                    String text3 = comboDoc3.Text;
                    String text4 = comboDoc4.Text;
                    String text5 = comboDoc5.Text;
                    var doc = soft.CV_DOCUMENT.Where(a => a.Docum.ToLower() == text3.ToLower()).FirstOrDefault();
                    if (doc == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text3 + " \" does not exist in Document table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_DOCUMENT item = new CV_DOCUMENT();
                            item.Docum = text3;
                            soft.CV_DOCUMENT.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmDoc1 = new List<String>();
                            List<String> itmDoc2 = new List<String>();
                            List<String> itmDoc3 = new List<String>();
                            List<String> itmDoc4 = new List<String>();
                            List<String> itmDoc5 = new List<String>();
                            itmDoc1.Add("");
                            itmDoc2.Add("");
                            itmDoc3.Add("");
                            itmDoc4.Add("");
                            itmDoc5.Add("");
                            if (soft.CV_DOCUMENT.Count() != 0)
                            {
                                foreach (var x in soft.CV_DOCUMENT.Select(a => a.Docum).OrderBy(a => a).ToList())
                                {
                                    itmDoc1.Add(x);
                                    itmDoc2.Add(x);
                                    itmDoc3.Add(x);
                                    itmDoc4.Add(x);
                                    itmDoc5.Add(x);
                                }
                            }
                            comboDoc1.DataSource = itmDoc1;
                            comboDoc2.DataSource = itmDoc2;
                            comboDoc3.DataSource = itmDoc3;
                            comboDoc4.DataSource = itmDoc4;
                            comboDoc5.DataSource = itmDoc5;
                            comboDoc1.SelectedItem = text1;
                            comboDoc2.SelectedItem = text2;
                            comboDoc3.SelectedItem = text3;
                            comboDoc4.SelectedItem = text4;
                            comboDoc5.SelectedItem = text5;
                        }
                        else
                        {
                            comboDoc3.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboDoc4_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboDoc4.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboDoc1.Text;
                    String text2 = comboDoc2.Text;
                    String text3 = comboDoc3.Text;
                    String text4 = comboDoc4.Text;
                    String text5 = comboDoc5.Text;
                    var doc = soft.CV_DOCUMENT.Where(a => a.Docum.ToLower() == text4.ToLower()).FirstOrDefault();
                    if (doc == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text4 + " \" does not exist in Document table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_DOCUMENT item = new CV_DOCUMENT();
                            item.Docum = text4;
                            soft.CV_DOCUMENT.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmDoc1 = new List<String>();
                            List<String> itmDoc2 = new List<String>();
                            List<String> itmDoc3 = new List<String>();
                            List<String> itmDoc4 = new List<String>();
                            List<String> itmDoc5 = new List<String>();
                            itmDoc1.Add("");
                            itmDoc2.Add("");
                            itmDoc3.Add("");
                            itmDoc4.Add("");
                            itmDoc5.Add("");
                            if (soft.CV_DOCUMENT.Count() != 0)
                            {
                                foreach (var x in soft.CV_DOCUMENT.Select(a => a.Docum).OrderBy(a => a).ToList())
                                {
                                    itmDoc1.Add(x);
                                    itmDoc2.Add(x);
                                    itmDoc3.Add(x);
                                    itmDoc4.Add(x);
                                    itmDoc5.Add(x);
                                }
                            }
                            comboDoc1.DataSource = itmDoc1;
                            comboDoc2.DataSource = itmDoc2;
                            comboDoc3.DataSource = itmDoc3;
                            comboDoc4.DataSource = itmDoc4;
                            comboDoc5.DataSource = itmDoc5;
                            comboDoc1.SelectedItem = text1;
                            comboDoc2.SelectedItem = text2;
                            comboDoc3.SelectedItem = text3;
                            comboDoc4.SelectedItem = text4;
                            comboDoc5.SelectedItem = text5;
                        }
                        else
                        {
                            comboDoc4.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboDoc5_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboDoc5.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboDoc1.Text;
                    String text2 = comboDoc2.Text;
                    String text3 = comboDoc3.Text;
                    String text4 = comboDoc4.Text;
                    String text5 = comboDoc5.Text;
                    var doc = soft.CV_DOCUMENT.Where(a => a.Docum.ToLower() == text5.ToLower()).FirstOrDefault();
                    if (doc == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text5 + " \" does not exist in Document table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_DOCUMENT item = new CV_DOCUMENT();
                            item.Docum = text5;
                            soft.CV_DOCUMENT.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmDoc1 = new List<String>();
                            List<String> itmDoc2 = new List<String>();
                            List<String> itmDoc3 = new List<String>();
                            List<String> itmDoc4 = new List<String>();
                            List<String> itmDoc5 = new List<String>();
                            itmDoc1.Add("");
                            itmDoc2.Add("");
                            itmDoc3.Add("");
                            itmDoc4.Add("");
                            itmDoc5.Add("");
                            if (soft.CV_DOCUMENT.Count() != 0)
                            {
                                foreach (var x in soft.CV_DOCUMENT.Select(a => a.Docum).OrderBy(a => a).ToList())
                                {
                                    itmDoc1.Add(x);
                                    itmDoc2.Add(x);
                                    itmDoc3.Add(x);
                                    itmDoc4.Add(x);
                                    itmDoc5.Add(x);
                                }
                            }
                            comboDoc1.DataSource = itmDoc1;
                            comboDoc2.DataSource = itmDoc2;
                            comboDoc3.DataSource = itmDoc3;
                            comboDoc4.DataSource = itmDoc4;
                            comboDoc5.DataSource = itmDoc5;
                            comboDoc1.SelectedItem = text1;
                            comboDoc2.SelectedItem = text2;
                            comboDoc3.SelectedItem = text3;
                            comboDoc4.SelectedItem = text4;
                            comboDoc5.SelectedItem = text5;
                        }
                        else
                        {
                            comboDoc5.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboSpecDipl1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboSpecDipl1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboSpecDipl1.Text;
                    String text2 = comboSpecDipl2.Text;
                    String text3 = comboSpecDipl3.Text;
                    var spec = soft.CV_SPECIALITY.Where(a => a.Speciality.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (spec == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Speciality table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_SPECIALITY item = new CV_SPECIALITY();
                            item.Speciality = text1;
                            soft.CV_SPECIALITY.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmSpec1 = new List<String>();
                            List<String> itmSpec2 = new List<String>();
                            List<String> itmSpec3 = new List<String>();
                            itmSpec1.Add("");
                            itmSpec2.Add("");
                            itmSpec3.Add("");
                            if (soft.CV_SPECIALITY.Count() != 0)
                            {
                                foreach (var x in soft.CV_SPECIALITY.Select(a => a.Speciality).OrderBy(a => a).ToList())
                                {
                                    itmSpec1.Add(x);
                                    itmSpec2.Add(x);
                                    itmSpec3.Add(x);
                                }
                            }
                            comboSpecDipl1.DataSource = itmSpec1;
                            comboSpecDipl2.DataSource = itmSpec2;
                            comboSpecDipl3.DataSource = itmSpec3;
                            comboSpecDipl1.SelectedItem = text1;
                            comboSpecDipl2.SelectedItem = text2;
                            comboSpecDipl3.SelectedItem = text3;
                        }
                        else
                        {
                            comboSpecDipl1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboSpecDipl2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboSpecDipl2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboSpecDipl1.Text;
                    String text2 = comboSpecDipl2.Text;
                    String text3 = comboSpecDipl3.Text;
                    var spec = soft.CV_SPECIALITY.Where(a => a.Speciality.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (spec == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Speciality table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_SPECIALITY item = new CV_SPECIALITY();
                            item.Speciality = text2;
                            soft.CV_SPECIALITY.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmSpec1 = new List<String>();
                            List<String> itmSpec2 = new List<String>();
                            List<String> itmSpec3 = new List<String>();
                            itmSpec1.Add("");
                            itmSpec2.Add("");
                            itmSpec3.Add("");
                            if (soft.CV_SPECIALITY.Count() != 0)
                            {
                                foreach (var x in soft.CV_SPECIALITY.Select(a => a.Speciality).OrderBy(a => a).ToList())
                                {
                                    itmSpec1.Add(x);
                                    itmSpec2.Add(x);
                                    itmSpec3.Add(x);
                                }
                            }
                            comboSpecDipl1.DataSource = itmSpec1;
                            comboSpecDipl2.DataSource = itmSpec2;
                            comboSpecDipl3.DataSource = itmSpec3;
                            comboSpecDipl1.SelectedItem = text1;
                            comboSpecDipl2.SelectedItem = text2;
                            comboSpecDipl3.SelectedItem = text3;
                        }
                        else
                        {
                            comboSpecDipl2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboSpecDipl3_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboSpecDipl3.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboSpecDipl1.Text;
                    String text2 = comboSpecDipl2.Text;
                    String text3 = comboSpecDipl3.Text;
                    var spec = soft.CV_SPECIALITY.Where(a => a.Speciality.ToLower() == text3.ToLower()).FirstOrDefault();
                    if (spec == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text3 + " \" does not exist in Speciality table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_SPECIALITY item = new CV_SPECIALITY();
                            item.Speciality = text3;
                            soft.CV_SPECIALITY.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmSpec1 = new List<String>();
                            List<String> itmSpec2 = new List<String>();
                            List<String> itmSpec3 = new List<String>();
                            itmSpec1.Add("");
                            itmSpec2.Add("");
                            itmSpec3.Add("");
                            if (soft.CV_SPECIALITY.Count() != 0)
                            {
                                foreach (var x in soft.CV_SPECIALITY.Select(a => a.Speciality).OrderBy(a => a).ToList())
                                {
                                    itmSpec1.Add(x);
                                    itmSpec2.Add(x);
                                    itmSpec3.Add(x);
                                }
                            }
                            comboSpecDipl1.DataSource = itmSpec1;
                            comboSpecDipl2.DataSource = itmSpec2;
                            comboSpecDipl3.DataSource = itmSpec3;
                            comboSpecDipl1.SelectedItem = text1;
                            comboSpecDipl2.SelectedItem = text2;
                            comboSpecDipl3.SelectedItem = text3;
                        }
                        else
                        {
                            comboSpecDipl3.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboDiplP1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboDiplP1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboDiplP1.Text;
                    String text2 = comboDiplP2.Text;
                    String text3 = comboDiplP3.Text;
                    String text4 = comboPostGradP1.Text;
                    String text5 = comboPostGradP2.Text;
                    String text6 = comboPostGradP3.Text;
                    var place = soft.CV_PLACE.Where(a => a.Place.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (place == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Place table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_PLACE item = new CV_PLACE();
                            item.Place = text1;
                            soft.CV_PLACE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmPlace1 = new List<String>();
                            List<String> itmPlace2 = new List<String>();
                            List<String> itmPlace3 = new List<String>();
                            List<String> itmPlace4 = new List<String>();
                            List<String> itmPlace5 = new List<String>();
                            List<String> itmPlace6 = new List<String>();
                            itmPlace1.Add("");
                            itmPlace2.Add("");
                            itmPlace3.Add("");
                            itmPlace4.Add("");
                            itmPlace5.Add("");
                            itmPlace6.Add("");
                            if (soft.CV_PLACE.Count() != 0)
                            {
                                foreach (var x in soft.CV_PLACE.Select(a => a.Place).OrderBy(a => a).ToList())
                                {
                                    itmPlace1.Add(x);
                                    itmPlace2.Add(x);
                                    itmPlace3.Add(x);
                                    itmPlace4.Add(x);
                                    itmPlace5.Add(x);
                                    itmPlace6.Add(x);
                                }
                            }
                            comboDiplP1.DataSource = itmPlace1;
                            comboDiplP2.DataSource = itmPlace2;
                            comboDiplP3.DataSource = itmPlace3;
                            comboPostGradP1.DataSource = itmPlace4;
                            comboPostGradP2.DataSource = itmPlace5;
                            comboPostGradP3.DataSource = itmPlace6;
                            comboDiplP1.SelectedItem = text1;
                            comboDiplP2.SelectedItem = text2;
                            comboDiplP3.SelectedItem = text3;
                            comboPostGradP1.SelectedItem = text4;
                            comboPostGradP2.SelectedItem = text5;
                            comboPostGradP3.SelectedItem = text6;
                        }
                        else
                        {
                            comboDiplP1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboDiplP2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboDiplP2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboDiplP1.Text;
                    String text2 = comboDiplP2.Text;
                    String text3 = comboDiplP3.Text;
                    String text4 = comboPostGradP1.Text;
                    String text5 = comboPostGradP2.Text;
                    String text6 = comboPostGradP3.Text;
                    var place = soft.CV_PLACE.Where(a => a.Place.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (place == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Place table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_PLACE item = new CV_PLACE();
                            item.Place = text2;
                            soft.CV_PLACE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmPlace1 = new List<String>();
                            List<String> itmPlace2 = new List<String>();
                            List<String> itmPlace3 = new List<String>();
                            List<String> itmPlace4 = new List<String>();
                            List<String> itmPlace5 = new List<String>();
                            List<String> itmPlace6 = new List<String>();
                            itmPlace1.Add("");
                            itmPlace2.Add("");
                            itmPlace3.Add("");
                            itmPlace4.Add("");
                            itmPlace5.Add("");
                            itmPlace6.Add("");
                            if (soft.CV_PLACE.Count() != 0)
                            {
                                foreach (var x in soft.CV_PLACE.Select(a => a.Place).OrderBy(a => a).ToList())
                                {
                                    itmPlace1.Add(x);
                                    itmPlace2.Add(x);
                                    itmPlace3.Add(x);
                                    itmPlace4.Add(x);
                                    itmPlace5.Add(x);
                                    itmPlace6.Add(x);
                                }
                            }
                            comboDiplP1.DataSource = itmPlace1;
                            comboDiplP2.DataSource = itmPlace2;
                            comboDiplP3.DataSource = itmPlace3;
                            comboPostGradP1.DataSource = itmPlace4;
                            comboPostGradP2.DataSource = itmPlace5;
                            comboPostGradP3.DataSource = itmPlace6;
                            comboDiplP1.SelectedItem = text1;
                            comboDiplP2.SelectedItem = text2;
                            comboDiplP3.SelectedItem = text3;
                            comboPostGradP1.SelectedItem = text4;
                            comboPostGradP2.SelectedItem = text5;
                            comboPostGradP3.SelectedItem = text6;
                        }
                        else
                        {
                            comboDiplP2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboDiplP3_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboDiplP3.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboDiplP1.Text;
                    String text2 = comboDiplP2.Text;
                    String text3 = comboDiplP3.Text;
                    String text4 = comboPostGradP1.Text;
                    String text5 = comboPostGradP2.Text;
                    String text6 = comboPostGradP3.Text;
                    var place = soft.CV_PLACE.Where(a => a.Place.ToLower() == text3.ToLower()).FirstOrDefault();
                    if (place == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text3 + " \" does not exist in Place table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_PLACE item = new CV_PLACE();
                            item.Place = text3;
                            soft.CV_PLACE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmPlace1 = new List<String>();
                            List<String> itmPlace2 = new List<String>();
                            List<String> itmPlace3 = new List<String>();
                            List<String> itmPlace4 = new List<String>();
                            List<String> itmPlace5 = new List<String>();
                            List<String> itmPlace6 = new List<String>();
                            itmPlace1.Add("");
                            itmPlace2.Add("");
                            itmPlace3.Add("");
                            itmPlace4.Add("");
                            itmPlace5.Add("");
                            itmPlace6.Add("");
                            if (soft.CV_PLACE.Count() != 0)
                            {
                                foreach (var x in soft.CV_PLACE.Select(a => a.Place).OrderBy(a => a).ToList())
                                {
                                    itmPlace1.Add(x);
                                    itmPlace2.Add(x);
                                    itmPlace3.Add(x);
                                    itmPlace4.Add(x);
                                    itmPlace5.Add(x);
                                    itmPlace6.Add(x);
                                }
                            }
                            comboDiplP1.DataSource = itmPlace1;
                            comboDiplP2.DataSource = itmPlace2;
                            comboDiplP3.DataSource = itmPlace3;
                            comboPostGradP1.DataSource = itmPlace4;
                            comboPostGradP2.DataSource = itmPlace5;
                            comboPostGradP3.DataSource = itmPlace6;
                            comboDiplP1.SelectedItem = text1;
                            comboDiplP2.SelectedItem = text2;
                            comboDiplP3.SelectedItem = text3;
                            comboPostGradP1.SelectedItem = text4;
                            comboPostGradP2.SelectedItem = text5;
                            comboPostGradP3.SelectedItem = text6;
                        }
                        else
                        {
                            comboDiplP3.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboPostGrad1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboPostGrad1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboPostGrad1.Text;
                    String text2 = comboPostGrad2.Text;
                    String text3 = comboPostGrad3.Text;
                    var grad = soft.CV_GRADUATE.Where(a => a.Graduate.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (grad == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Graduate table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_GRADUATE item = new CV_GRADUATE();
                            item.Graduate = text1;
                            soft.CV_GRADUATE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmPlace1 = new List<String>();
                            List<String> itmPlace2 = new List<String>();
                            List<String> itmPlace3 = new List<String>();
                            itmPlace3.Add("");
                            itmPlace1.Add("");
                            itmPlace2.Add("");
                            if (soft.CV_GRADUATE.Count() != 0)
                            {
                                foreach (var x in soft.CV_GRADUATE.Select(a => a.Graduate).OrderBy(a => a).ToList())
                                {
                                    itmPlace3.Add(x);
                                    itmPlace1.Add(x);
                                    itmPlace2.Add(x);
                                }
                            }
                            comboPostGrad1.DataSource = itmPlace1;
                            comboPostGrad2.DataSource = itmPlace2;
                            comboPostGrad3.DataSource = itmPlace3;
                            comboPostGrad1.SelectedItem = text1;
                            comboPostGrad2.SelectedItem = text2;
                            comboPostGrad3.SelectedItem = text3;
                        }
                        else
                        {
                            comboPostGrad1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboPostGrad2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboPostGrad2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboPostGrad1.Text;
                    String text2 = comboPostGrad2.Text;
                    String text3 = comboPostGrad3.Text;
                    var grad = soft.CV_GRADUATE.Where(a => a.Graduate.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (grad == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Graduate table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_GRADUATE item = new CV_GRADUATE();
                            item.Graduate = text2;
                            soft.CV_GRADUATE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmPlace3 = new List<String>();
                            List<String> itmPlace1 = new List<String>();
                            List<String> itmPlace2 = new List<String>();
                            itmPlace3.Add("");
                            itmPlace1.Add("");
                            itmPlace2.Add("");
                            if (soft.CV_GRADUATE.Count() != 0)
                            {
                                foreach (var x in soft.CV_GRADUATE.Select(a => a.Graduate).OrderBy(a => a).ToList())
                                {
                                    itmPlace3.Add(x);
                                    itmPlace1.Add(x);
                                    itmPlace2.Add(x);
                                }
                            }
                            comboPostGrad1.DataSource = itmPlace3;
                            comboPostGrad2.DataSource = itmPlace1;
                            comboPostGrad3.DataSource = itmPlace2;
                            comboPostGrad1.SelectedItem = text1;
                            comboPostGrad2.SelectedItem = text2;
                            comboPostGrad3.SelectedItem = text3;
                        }
                        else
                        {
                            comboPostGrad2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboPostGrad3_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboPostGrad3.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboPostGrad1.Text;
                    String text2 = comboPostGrad2.Text;
                    String text3 = comboPostGrad3.Text;
                    var grad = soft.CV_GRADUATE.Where(a => a.Graduate.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (grad == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text3 + " \" does not exist in Graduate table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_GRADUATE item = new CV_GRADUATE();
                            item.Graduate = text3;
                            soft.CV_GRADUATE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmPlace3 = new List<String>();
                            List<String> itmPlace1 = new List<String>();
                            List<String> itmPlace2 = new List<String>();
                            itmPlace3.Add("");
                            itmPlace1.Add("");
                            itmPlace2.Add("");
                            if (soft.CV_GRADUATE.Count() != 0)
                            {
                                foreach (var x in soft.CV_GRADUATE.Select(a => a.Graduate).OrderBy(a => a).ToList())
                                {
                                    itmPlace3.Add(x);
                                    itmPlace1.Add(x);
                                    itmPlace2.Add(x);
                                }
                            }
                            comboPostGrad1.DataSource = itmPlace3;
                            comboPostGrad2.DataSource = itmPlace1;
                            comboPostGrad3.DataSource = itmPlace2;
                            comboPostGrad1.SelectedItem = text1;
                            comboPostGrad2.SelectedItem = text2;
                            comboPostGrad3.SelectedItem = text3;
                        }
                        else
                        {
                            comboPostGrad3.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboPostGradP1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboPostGradP1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboDiplP1.Text;
                    String text2 = comboDiplP2.Text;
                    String text3 = comboDiplP3.Text;
                    String text4 = comboPostGradP1.Text;
                    String text5 = comboPostGradP2.Text;
                    String text6 = comboPostGradP3.Text;
                    var place = soft.CV_PLACE.Where(a => a.Place.ToLower() == text4.ToLower()).FirstOrDefault();
                    if (place == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text4 + " \" does not exist in Place table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_PLACE item = new CV_PLACE();
                            item.Place = text4;
                            soft.CV_PLACE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmPlace1 = new List<String>();
                            List<String> itmPlace2 = new List<String>();
                            List<String> itmPlace3 = new List<String>();
                            List<String> itmPlace4 = new List<String>();
                            List<String> itmPlace5 = new List<String>();
                            List<String> itmPlace6 = new List<String>();
                            itmPlace1.Add("");
                            itmPlace2.Add("");
                            itmPlace3.Add("");
                            itmPlace4.Add("");
                            itmPlace5.Add("");
                            itmPlace6.Add("");
                            if (soft.CV_PLACE.Count() != 0)
                            {
                                foreach (var x in soft.CV_PLACE.Select(a => a.Place).OrderBy(a => a).ToList())
                                {
                                    itmPlace1.Add(x);
                                    itmPlace2.Add(x);
                                    itmPlace3.Add(x);
                                    itmPlace4.Add(x);
                                    itmPlace5.Add(x);
                                    itmPlace6.Add(x);
                                }
                            }
                            comboDiplP1.DataSource = itmPlace1;
                            comboDiplP2.DataSource = itmPlace2;
                            comboDiplP3.DataSource = itmPlace3;
                            comboPostGradP1.DataSource = itmPlace4;
                            comboPostGradP2.DataSource = itmPlace5;
                            comboPostGradP3.DataSource = itmPlace6;
                            comboDiplP1.SelectedItem = text1;
                            comboDiplP2.SelectedItem = text2;
                            comboDiplP3.SelectedItem = text3;
                            comboPostGradP1.SelectedItem = text4;
                            comboPostGradP2.SelectedItem = text5;
                            comboPostGradP3.SelectedItem = text6;
                        }
                        else
                        {
                            comboPostGradP1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboPostGradP2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboPostGradP2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboDiplP1.Text;
                    String text2 = comboDiplP2.Text;
                    String text3 = comboDiplP3.Text;
                    String text4 = comboPostGradP1.Text;
                    String text5 = comboPostGradP2.Text;
                    String text6 = comboPostGradP3.Text;
                    var place = soft.CV_PLACE.Where(a => a.Place.ToLower() == text5.ToLower()).FirstOrDefault();
                    if (place == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text5 + " \" does not exist in Place table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_PLACE item = new CV_PLACE();
                            item.Place = text5;
                            soft.CV_PLACE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmPlace1 = new List<String>();
                            List<String> itmPlace2 = new List<String>();
                            List<String> itmPlace3 = new List<String>();
                            List<String> itmPlace4 = new List<String>();
                            List<String> itmPlace5 = new List<String>();
                            List<String> itmPlace6 = new List<String>();
                            itmPlace1.Add("");
                            itmPlace2.Add("");
                            itmPlace3.Add("");
                            itmPlace4.Add("");
                            itmPlace5.Add("");
                            itmPlace6.Add("");
                            if (soft.CV_PLACE.Count() != 0)
                            {
                                foreach (var x in soft.CV_PLACE.Select(a => a.Place).OrderBy(a => a).ToList())
                                {
                                    itmPlace1.Add(x);
                                    itmPlace2.Add(x);
                                    itmPlace3.Add(x);
                                    itmPlace4.Add(x);
                                    itmPlace5.Add(x);
                                    itmPlace6.Add(x);
                                }
                            }
                            comboDiplP1.DataSource = itmPlace1;
                            comboDiplP2.DataSource = itmPlace2;
                            comboDiplP3.DataSource = itmPlace3;
                            comboPostGradP1.DataSource = itmPlace4;
                            comboPostGradP2.DataSource = itmPlace5;
                            comboPostGradP3.DataSource = itmPlace6;
                            comboDiplP1.SelectedItem = text1;
                            comboDiplP2.SelectedItem = text2;
                            comboDiplP3.SelectedItem = text3;
                            comboPostGradP1.SelectedItem = text4;
                            comboPostGradP2.SelectedItem = text5;
                            comboPostGradP3.SelectedItem = text6;
                        }
                        else
                        {
                            comboPostGradP2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboPostGradP3_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboPostGradP3.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboDiplP1.Text;
                    String text2 = comboDiplP2.Text;
                    String text3 = comboDiplP3.Text;
                    String text4 = comboPostGradP1.Text;
                    String text5 = comboPostGradP2.Text;
                    String text6 = comboPostGradP3.Text;
                    var place = soft.CV_PLACE.Where(a => a.Place.ToLower() == text6.ToLower()).FirstOrDefault();
                    if (place == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text6 + " \" does not exist in Place table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_PLACE item = new CV_PLACE();
                            item.Place = text6;
                            soft.CV_PLACE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmPlace1 = new List<String>();
                            List<String> itmPlace2 = new List<String>();
                            List<String> itmPlace3 = new List<String>();
                            List<String> itmPlace4 = new List<String>();
                            List<String> itmPlace5 = new List<String>();
                            List<String> itmPlace6 = new List<String>();
                            itmPlace1.Add("");
                            itmPlace2.Add("");
                            itmPlace3.Add("");
                            itmPlace4.Add("");
                            itmPlace5.Add("");
                            itmPlace6.Add("");
                            if (soft.CV_PLACE.Count() != 0)
                            {
                                foreach (var x in soft.CV_PLACE.Select(a => a.Place).OrderBy(a => a).ToList())
                                {
                                    itmPlace1.Add(x);
                                    itmPlace2.Add(x);
                                    itmPlace3.Add(x);
                                    itmPlace4.Add(x);
                                    itmPlace5.Add(x);
                                    itmPlace6.Add(x);
                                }
                            }
                            comboDiplP1.DataSource = itmPlace1;
                            comboDiplP2.DataSource = itmPlace2;
                            comboDiplP3.DataSource = itmPlace3;
                            comboPostGradP1.DataSource = itmPlace4;
                            comboPostGradP2.DataSource = itmPlace5;
                            comboPostGradP3.DataSource = itmPlace6;
                            comboDiplP1.SelectedItem = text1;
                            comboDiplP2.SelectedItem = text2;
                            comboDiplP3.SelectedItem = text3;
                            comboPostGradP1.SelectedItem = text4;
                            comboPostGradP2.SelectedItem = text5;
                            comboPostGradP3.SelectedItem = text6;
                        }
                        else
                        {
                            comboPostGradP3.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboLang1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboLang1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboLang1.Text;
                    String text2 = comboLang2.Text;
                    String text3 = comboLang3.Text;
                    String text4 = comboLang4.Text;
                    var lang = soft.CV_LANGUAGE.Where(a => a.Language.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (lang == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Language table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_LANGUAGE item = new CV_LANGUAGE();
                            item.Language = text1;
                            soft.CV_LANGUAGE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmLang1 = new List<String>();
                            List<String> itmLang2 = new List<String>();
                            List<String> itmLang3 = new List<String>();
                            List<String> itmLang4 = new List<String>();
                            itmLang1.Add("");
                            itmLang2.Add("");
                            itmLang3.Add("");
                            itmLang4.Add("");
                            if (soft.CV_LANGUAGE.Count() != 0)
                            {
                                foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                                {
                                    itmLang1.Add(x);
                                    itmLang2.Add(x);
                                    itmLang3.Add(x);
                                    itmLang4.Add(x);
                                }
                            }
                            comboLang1.DataSource = itmLang1;
                            comboLang2.DataSource = itmLang2;
                            comboLang3.DataSource = itmLang3;
                            comboLang4.DataSource = itmLang4;
                            comboLang1.SelectedItem = text1;
                            comboLang2.SelectedItem = text2;
                            comboLang3.SelectedItem = text3;
                            comboLang4.SelectedItem = text4;
                        }
                        else
                        {
                            comboLang1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboLang2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboLang2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboLang1.Text;
                    String text2 = comboLang2.Text;
                    String text3 = comboLang3.Text;
                    String text4 = comboLang4.Text;
                    var lang = soft.CV_LANGUAGE.Where(a => a.Language.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (lang == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Language table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_LANGUAGE item = new CV_LANGUAGE();
                            item.Language = text2;
                            soft.CV_LANGUAGE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmLang1 = new List<String>();
                            List<String> itmLang2 = new List<String>();
                            List<String> itmLang3 = new List<String>();
                            List<String> itmLang4 = new List<String>();
                            itmLang1.Add("");
                            itmLang2.Add("");
                            itmLang3.Add("");
                            itmLang4.Add("");
                            if (soft.CV_LANGUAGE.Count() != 0)
                            {
                                foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                                {
                                    itmLang1.Add(x);
                                    itmLang2.Add(x);
                                    itmLang3.Add(x);
                                    itmLang4.Add(x);
                                }
                            }
                            comboLang1.DataSource = itmLang1;
                            comboLang2.DataSource = itmLang2;
                            comboLang3.DataSource = itmLang3;
                            comboLang4.DataSource = itmLang4;
                            comboLang1.SelectedItem = text1;
                            comboLang2.SelectedItem = text2;
                            comboLang3.SelectedItem = text3;
                            comboLang4.SelectedItem = text4;
                        }
                        else
                        {
                            comboLang2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboLang3_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboLang3.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboLang1.Text;
                    String text2 = comboLang2.Text;
                    String text3 = comboLang3.Text;
                    String text4 = comboLang4.Text;
                    var lang = soft.CV_LANGUAGE.Where(a => a.Language.ToLower() == text3.ToLower()).FirstOrDefault();
                    if (lang == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Language table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_LANGUAGE item = new CV_LANGUAGE();
                            item.Language = text3;
                            soft.CV_LANGUAGE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmLang1 = new List<String>();
                            List<String> itmLang2 = new List<String>();
                            List<String> itmLang3 = new List<String>();
                            List<String> itmLang4 = new List<String>();
                            itmLang1.Add("");
                            itmLang2.Add("");
                            itmLang3.Add("");
                            itmLang4.Add("");
                            if (soft.CV_LANGUAGE.Count() != 0)
                            {
                                foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                                {
                                    itmLang1.Add(x);
                                    itmLang2.Add(x);
                                    itmLang3.Add(x);
                                    itmLang4.Add(x);
                                }
                            }
                            comboLang1.DataSource = itmLang1;
                            comboLang2.DataSource = itmLang2;
                            comboLang3.DataSource = itmLang3;
                            comboLang4.DataSource = itmLang4;
                            comboLang1.SelectedItem = text1;
                            comboLang2.SelectedItem = text2;
                            comboLang3.SelectedItem = text3;
                            comboLang4.SelectedItem = text4;
                        }
                        else
                        {
                            comboLang3.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboLang4_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboLang4.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboLang1.Text;
                    String text2 = comboLang2.Text;
                    String text3 = comboLang3.Text;
                    String text4 = comboLang4.Text;
                    var lang = soft.CV_LANGUAGE.Where(a => a.Language.ToLower() == text4.ToLower()).FirstOrDefault();
                    if (lang == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text4 + " \" does not exist in Language table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_LANGUAGE item = new CV_LANGUAGE();
                            item.Language = text4;
                            soft.CV_LANGUAGE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmLang1 = new List<String>();
                            List<String> itmLang2 = new List<String>();
                            List<String> itmLang3 = new List<String>();
                            List<String> itmLang4 = new List<String>();
                            itmLang1.Add("");
                            itmLang2.Add("");
                            itmLang3.Add("");
                            itmLang4.Add("");
                            if (soft.CV_LANGUAGE.Count() != 0)
                            {
                                foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                                {
                                    itmLang1.Add(x);
                                    itmLang2.Add(x);
                                    itmLang3.Add(x);
                                    itmLang4.Add(x);
                                }
                            }
                            comboLang1.DataSource = itmLang1;
                            comboLang2.DataSource = itmLang2;
                            comboLang3.DataSource = itmLang3;
                            comboLang4.DataSource = itmLang4;
                            comboLang1.SelectedItem = text1;
                            comboLang2.SelectedItem = text2;
                            comboLang3.SelectedItem = text3;
                            comboLang4.SelectedItem = text4;
                        }
                        else
                        {
                            comboLang4.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboTechField1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboTechField1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboTechField1.Text;
                    String text2 = comboTechField2.Text;
                    String text3 = comboTechField3.Text;
                    String text4 = comboDomExp1.Text;
                    String text5 = comboDomExp2.Text;

                    var tech = soft.CV_TECHNICFIELD.Where(a => a.TechnicField.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (tech == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in TechnicField table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_TECHNICFIELD item = new CV_TECHNICFIELD();
                            item.TechnicField = text1;
                            soft.CV_TECHNICFIELD.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmTech1 = new List<String>();
                            List<String> itmTech2 = new List<String>();
                            List<String> itmTech3 = new List<String>();
                            List<String> itmTech4 = new List<String>();
                            List<String> itmTech5 = new List<String>();

                            itmTech1.Add("");
                            itmTech2.Add("");
                            itmTech3.Add("");
                            itmTech4.Add("");
                            itmTech5.Add("");
                            if (soft.CV_TECHNICFIELD.Count() != 0)
                            {
                                foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                                {
                                    itmTech1.Add(x);
                                    itmTech2.Add(x);
                                    itmTech3.Add(x);
                                    itmTech4.Add(x);
                                    itmTech5.Add(x);
                                }
                            }
                            comboTechField1.DataSource = itmTech1;
                            comboTechField2.DataSource = itmTech2;
                            comboTechField3.DataSource = itmTech3;
                            comboDomExp1.DataSource = itmTech4;
                            comboDomExp2.DataSource = itmTech5;
                            comboTechField1.SelectedItem = text1;
                            comboTechField2.SelectedItem = text2;
                            comboTechField3.SelectedItem = text3;
                            comboDomExp1.SelectedItem = text4;
                            comboDomExp2.SelectedItem = text5;
                        }
                        else
                        {
                            comboTechField1.SelectedItem = "";
                            textTFYears1.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                textTFYears1.Enabled = false;
            }
        }

        private void comboTechField2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboTechField2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboTechField1.Text;
                    String text2 = comboTechField2.Text;
                    String text3 = comboTechField3.Text;
                    String text4 = comboDomExp1.Text;
                    String text5 = comboDomExp2.Text;

                    var tech = soft.CV_TECHNICFIELD.Where(a => a.TechnicField.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (tech == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in TechnicField table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_TECHNICFIELD item = new CV_TECHNICFIELD();
                            item.TechnicField = text2;
                            soft.CV_TECHNICFIELD.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmTech1 = new List<String>();
                            List<String> itmTech2 = new List<String>();
                            List<String> itmTech3 = new List<String>();
                            List<String> itmTech4 = new List<String>();
                            List<String> itmTech5 = new List<String>();

                            itmTech1.Add("");
                            itmTech2.Add("");
                            itmTech3.Add("");
                            itmTech4.Add("");
                            itmTech5.Add("");
                            if (soft.CV_TECHNICFIELD.Count() != 0)
                            {
                                foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                                {
                                    itmTech1.Add(x);
                                    itmTech2.Add(x);
                                    itmTech3.Add(x);
                                    itmTech4.Add(x);
                                    itmTech5.Add(x);
                                }
                            }
                            comboTechField1.DataSource = itmTech1;
                            comboTechField2.DataSource = itmTech2;
                            comboTechField3.DataSource = itmTech3;
                            comboDomExp1.DataSource = itmTech4;
                            comboDomExp2.DataSource = itmTech5;
                            comboTechField1.SelectedItem = text1;
                            comboTechField2.SelectedItem = text2;
                            comboTechField3.SelectedItem = text3;
                            comboDomExp1.SelectedItem = text4;
                            comboDomExp2.SelectedItem = text5;
                        }
                        else
                        {
                            comboTechField2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboTechField3_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboTechField3.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboTechField1.Text;
                    String text2 = comboTechField2.Text;
                    String text3 = comboTechField3.Text;
                    String text4 = comboDomExp1.Text;
                    String text5 = comboDomExp2.Text;

                    var tech = soft.CV_TECHNICFIELD.Where(a => a.TechnicField.ToLower() == text3.ToLower()).FirstOrDefault();
                    if (tech == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text3 + " \" does not exist in TechnicField table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_TECHNICFIELD item = new CV_TECHNICFIELD();
                            item.TechnicField = text3;
                            soft.CV_TECHNICFIELD.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmTech1 = new List<String>();
                            List<String> itmTech2 = new List<String>();
                            List<String> itmTech3 = new List<String>();
                            List<String> itmTech4 = new List<String>();
                            List<String> itmTech5 = new List<String>();

                            itmTech1.Add("");
                            itmTech2.Add("");
                            itmTech3.Add("");
                            itmTech4.Add("");
                            itmTech5.Add("");
                            if (soft.CV_TECHNICFIELD.Count() != 0)
                            {
                                foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                                {
                                    itmTech1.Add(x);
                                    itmTech2.Add(x);
                                    itmTech3.Add(x);
                                    itmTech4.Add(x);
                                    itmTech5.Add(x);
                                }
                            }
                            comboTechField1.DataSource = itmTech1;
                            comboTechField2.DataSource = itmTech2;
                            comboTechField3.DataSource = itmTech3;
                            comboDomExp1.DataSource = itmTech4;
                            comboDomExp2.DataSource = itmTech5;
                            comboTechField1.SelectedItem = text1;
                            comboTechField2.SelectedItem = text2;
                            comboTechField3.SelectedItem = text3;
                            comboDomExp1.SelectedItem = text4;
                            comboDomExp2.SelectedItem = text5;
                        }
                        else
                        {
                            comboTechField3.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboRegion1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboRegion1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboRegion1.Text;
                    String text2 = comboRegion2.Text;
                    String text3 = comboRegion3.Text;
                    var tech = soft.CV_REGION.Where(a => a.Region.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (tech == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Region table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_REGION item = new CV_REGION();
                            item.Region = text1;
                            soft.CV_REGION.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmTech1 = new List<String>();
                            List<String> itmTech2 = new List<String>();
                            List<String> itmTech3 = new List<String>();
                            itmTech1.Add("");
                            itmTech2.Add("");
                            itmTech3.Add("");
                            if (soft.CV_REGION.Count() != 0)
                            {
                                foreach (var x in soft.CV_REGION.Select(a => a.Region).OrderBy(a => a).ToList())
                                {
                                    itmTech1.Add(x);
                                    itmTech2.Add(x);
                                    itmTech3.Add(x);
                                }
                            }
                            comboRegion1.DataSource = itmTech1;
                            comboRegion2.DataSource = itmTech2;
                            comboRegion3.DataSource = itmTech3;
                            comboRegion1.SelectedItem = text1;
                            comboRegion2.SelectedItem = text2;
                            comboRegion3.SelectedItem = text3;
                        }
                        else
                        {
                            comboRegion1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboRegion2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboRegion2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboRegion1.Text;
                    String text2 = comboRegion2.Text;
                    String text3 = comboRegion3.Text;
                    var tech = soft.CV_REGION.Where(a => a.Region.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (tech == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Region table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_REGION item = new CV_REGION();
                            item.Region = text2;
                            soft.CV_REGION.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmTech1 = new List<String>();
                            List<String> itmTech2 = new List<String>();
                            List<String> itmTech3 = new List<String>();
                            itmTech1.Add("");
                            itmTech2.Add("");
                            itmTech3.Add("");
                            if (soft.CV_REGION.Count() != 0)
                            {
                                foreach (var x in soft.CV_REGION.Select(a => a.Region).OrderBy(a => a).ToList())
                                {
                                    itmTech1.Add(x);
                                    itmTech2.Add(x);
                                    itmTech3.Add(x);
                                }
                            }
                            comboRegion1.DataSource = itmTech1;
                            comboRegion2.DataSource = itmTech2;
                            comboRegion3.DataSource = itmTech3;
                            comboRegion1.SelectedItem = text1;
                            comboRegion2.SelectedItem = text2;
                            comboRegion3.SelectedItem = text3;
                        }
                        else
                        {
                            comboRegion2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboRegion3_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboRegion3.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboRegion1.Text;
                    String text2 = comboRegion2.Text;
                    String text3 = comboRegion3.Text;
                    var tech = soft.CV_REGION.Where(a => a.Region.ToLower() == text3.ToLower()).FirstOrDefault();
                    if (tech == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text3 + " \" does not exist in Region table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_REGION item = new CV_REGION();
                            item.Region = text3;
                            soft.CV_REGION.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmTech1 = new List<String>();
                            List<String> itmTech2 = new List<String>();
                            List<String> itmTech3 = new List<String>();
                            itmTech1.Add("");
                            itmTech2.Add("");
                            itmTech3.Add("");
                            if (soft.CV_REGION.Count() != 0)
                            {
                                foreach (var x in soft.CV_REGION.Select(a => a.Region).OrderBy(a => a).ToList())
                                {
                                    itmTech1.Add(x);
                                    itmTech2.Add(x);
                                    itmTech3.Add(x);
                                }
                            }
                            comboRegion1.DataSource = itmTech1;
                            comboRegion2.DataSource = itmTech2;
                            comboRegion3.DataSource = itmTech3;
                            comboRegion1.SelectedItem = text1;
                            comboRegion2.SelectedItem = text2;
                            comboRegion3.SelectedItem = text3;
                        }
                        else
                        {
                            comboRegion3.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboMainSup1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboMainSup1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboEmplMet1.Text;
                    String text2 = comboEmplMet2.Text;
                    String text3 = comboEmplMet3.Text;
                    String text4 = comboPersTPH.Text;
                    String text5 = comboMainSup1.Text;
                    String text6 = comboMainSup2.Text;

                    var emp = soft.CV_EMPLOYEE.Where(a => a.PersRef.ToLower() == text5.ToLower()).FirstOrDefault();
                    if (emp == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text5 + " \" does not exist in Employee table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_EMPLOYEE item = new CV_EMPLOYEE();
                            item.PersRef = text5;
                            soft.CV_EMPLOYEE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmEmp1 = new List<String>();
                            List<String> itmEmp2 = new List<String>();
                            List<String> itmEmp3 = new List<String>();
                            List<String> itmEmp4 = new List<String>();
                            List<String> itmEmp5 = new List<String>();
                            List<String> itmEmp6 = new List<String>();
                            itmEmp1.Add("");
                            itmEmp2.Add("");
                            itmEmp3.Add("");
                            itmEmp4.Add("");
                            itmEmp5.Add("");
                            itmEmp6.Add("");
                            if (soft.CV_EMPLOYEE.Count() != 0)
                            {
                                foreach (var x in soft.CV_EMPLOYEE.Select(a => a.PersRef).OrderBy(a => a).ToList())
                                {
                                    itmEmp1.Add(x);
                                    itmEmp2.Add(x);
                                    itmEmp3.Add(x);
                                    itmEmp4.Add(x);
                                    itmEmp5.Add(x);
                                    itmEmp6.Add(x);
                                }
                            }

                            comboEmplMet1.DataSource = itmEmp1;
                            comboEmplMet2.DataSource = itmEmp2;
                            comboEmplMet3.DataSource = itmEmp3;
                            comboPersTPH.DataSource = itmEmp4;
                            comboMainSup1.DataSource = itmEmp5;
                            comboMainSup2.DataSource = itmEmp6;
                            comboEmplMet1.SelectedItem = text1;
                            comboEmplMet2.SelectedItem = text2;
                            comboEmplMet3.SelectedItem = text3;
                            comboPersTPH.SelectedItem = text4;
                            comboMainSup1.SelectedItem = text5;
                            comboMainSup2.SelectedItem = text6;
                        }
                        else
                        {
                            comboMainSup1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboMainSup2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboMainSup2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboEmplMet1.Text;
                    String text2 = comboEmplMet2.Text;
                    String text3 = comboEmplMet3.Text;
                    String text4 = comboPersTPH.Text;
                    String text5 = comboMainSup1.Text;
                    String text6 = comboMainSup2.Text;

                    var emp = soft.CV_EMPLOYEE.Where(a => a.PersRef.ToLower() == text6.ToLower()).FirstOrDefault();
                    if (emp == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text6 + " \" does not exist in Employee table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_EMPLOYEE item = new CV_EMPLOYEE();
                            item.PersRef = text6;
                            soft.CV_EMPLOYEE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmEmp1 = new List<String>();
                            List<String> itmEmp2 = new List<String>();
                            List<String> itmEmp3 = new List<String>();
                            List<String> itmEmp4 = new List<String>();
                            List<String> itmEmp5 = new List<String>();
                            List<String> itmEmp6 = new List<String>();
                            itmEmp1.Add("");
                            itmEmp2.Add("");
                            itmEmp3.Add("");
                            itmEmp4.Add("");
                            itmEmp5.Add("");
                            itmEmp6.Add("");
                            if (soft.CV_EMPLOYEE.Count() != 0)
                            {
                                foreach (var x in soft.CV_EMPLOYEE.Select(a => a.PersRef).OrderBy(a => a).ToList())
                                {
                                    itmEmp1.Add(x);
                                    itmEmp2.Add(x);
                                    itmEmp3.Add(x);
                                    itmEmp4.Add(x);
                                    itmEmp5.Add(x);
                                    itmEmp6.Add(x);
                                }
                            }

                            comboEmplMet1.DataSource = itmEmp1;
                            comboEmplMet2.DataSource = itmEmp2;
                            comboEmplMet3.DataSource = itmEmp3;
                            comboPersTPH.DataSource = itmEmp4;
                            comboMainSup1.DataSource = itmEmp5;
                            comboMainSup2.DataSource = itmEmp6;
                            comboEmplMet1.SelectedItem = text1;
                            comboEmplMet2.SelectedItem = text2;
                            comboEmplMet3.SelectedItem = text3;
                            comboPersTPH.SelectedItem = text4;
                            comboMainSup1.SelectedItem = text5;
                            comboMainSup2.SelectedItem = text6;
                        }
                        else
                        {
                            comboMainSup2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboDomExp1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboDomExp1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboTechField1.Text;
                    String text2 = comboTechField2.Text;
                    String text3 = comboTechField3.Text;
                    String text4 = comboDomExp1.Text;
                    String text5 = comboDomExp2.Text;

                    var dom = soft.CV_TECHNICFIELD.Where(a => a.TechnicField.ToLower() == text4.ToLower()).FirstOrDefault();
                    if (dom == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text4 + " \" does not exist in TechnicField table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_TECHNICFIELD item = new CV_TECHNICFIELD();
                            item.TechnicField = text4;
                            soft.CV_TECHNICFIELD.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmTech1 = new List<String>();
                            List<String> itmTech2 = new List<String>();
                            List<String> itmTech3 = new List<String>();
                            List<String> itmTech4 = new List<String>();
                            List<String> itmTech5 = new List<String>();

                            itmTech1.Add("");
                            itmTech2.Add("");
                            itmTech3.Add("");
                            itmTech4.Add("");
                            itmTech5.Add("");

                            if (soft.CV_TECHNICFIELD.Count() != 0)
                            {
                                foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                                {
                                    itmTech1.Add(x);
                                    itmTech2.Add(x);
                                    itmTech3.Add(x);
                                    itmTech4.Add(x);
                                    itmTech5.Add(x);
                                }
                            }
                            comboTechField1.DataSource = itmTech1;
                            comboTechField2.DataSource = itmTech2;
                            comboTechField3.DataSource = itmTech3;
                            comboDomExp1.DataSource = itmTech4;
                            comboDomExp2.DataSource = itmTech5;
                            comboTechField1.SelectedItem = text1;
                            comboTechField2.SelectedItem = text2;
                            comboTechField3.SelectedItem = text3;
                            comboDomExp1.SelectedItem = text4;
                            comboDomExp2.SelectedItem = text5;
                        }
                        else
                        {
                            comboDomExp1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboDomExp2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboDomExp2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboTechField1.Text;
                    String text2 = comboTechField2.Text;
                    String text3 = comboTechField3.Text;
                    String text4 = comboDomExp1.Text;
                    String text5 = comboDomExp2.Text;
                    var dom = soft.CV_TECHNICFIELD.Where(a => a.TechnicField.ToLower() == text5.ToLower()).FirstOrDefault();
                    if (dom == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text5 + " \" does not exist in TechnicField table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_TECHNICFIELD item = new CV_TECHNICFIELD();
                            item.TechnicField = text5;
                            soft.CV_TECHNICFIELD.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmTech1 = new List<String>();
                            List<String> itmTech2 = new List<String>();
                            List<String> itmTech3 = new List<String>();
                            List<String> itmTech4 = new List<String>();
                            List<String> itmTech5 = new List<String>();
                            itmTech1.Add("");
                            itmTech2.Add("");
                            itmTech3.Add("");
                            itmTech4.Add("");
                            itmTech5.Add("");

                            if (soft.CV_TECHNICFIELD.Count() != 0)
                            {
                                foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                                {
                                    itmTech1.Add(x);
                                    itmTech2.Add(x);
                                    itmTech3.Add(x);
                                    itmTech4.Add(x);
                                    itmTech5.Add(x);
                                }
                            }
                            comboTechField1.DataSource = itmTech1;
                            comboTechField2.DataSource = itmTech2;
                            comboTechField3.DataSource = itmTech3;
                            comboDomExp1.DataSource = itmTech4;
                            comboDomExp2.DataSource = itmTech5;
                            comboTechField1.SelectedItem = text1;
                            comboTechField2.SelectedItem = text2;
                            comboTechField3.SelectedItem = text3;
                            comboDomExp1.SelectedItem = text4;
                            comboDomExp2.SelectedItem = text5;
                        }
                        else
                        {
                            comboDomExp2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboSCHI1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboSCHI1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboSCHI1.Text;
                    String text2 = comboSCHI2.Text;
                    var unit = soft.CV_UNIT.Where(a => a.Unit.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (unit == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Unit table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_UNIT item = new CV_UNIT();
                            item.Unit = text1;
                            soft.CV_UNIT.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmUnit1 = new List<String>();
                            List<String> itmUnit2 = new List<String>();
                            itmUnit1.Add("");
                            itmUnit2.Add("");
                            if (soft.CV_UNIT.Count() != 0)
                            {
                                foreach (var x in soft.CV_UNIT.Select(a => a.Unit).OrderBy(a => a).ToList())
                                {
                                    itmUnit1.Add(x);
                                    itmUnit2.Add(x);
                                }
                            }
                            comboSCHI1.DataSource = itmUnit1;
                            comboSCHI2.DataSource = itmUnit2;
                            comboSCHI1.SelectedItem = text1;
                            comboSCHI2.SelectedItem = text2;
                        }
                        else
                        {
                            comboSCHI1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboSCHI2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboSCHI2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboSCHI1.Text;
                    String text2 = comboSCHI2.Text;
                    var unit = soft.CV_UNIT.Where(a => a.Unit.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (unit == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Unit table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_UNIT item = new CV_UNIT();
                            item.Unit = text2;
                            soft.CV_UNIT.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmUnit1 = new List<String>();
                            List<String> itmUnit2 = new List<String>();
                            itmUnit1.Add("");
                            itmUnit2.Add("");
                            if (soft.CV_UNIT.Count() != 0)
                            {
                                foreach (var x in soft.CV_UNIT.Select(a => a.Unit).OrderBy(a => a).ToList())
                                {
                                    itmUnit1.Add(x);
                                    itmUnit2.Add(x);
                                }
                            }
                            comboSCHI1.DataSource = itmUnit1;
                            comboSCHI2.DataSource = itmUnit2;
                            comboSCHI1.SelectedItem = text1;
                            comboSCHI2.SelectedItem = text2;
                        }
                        else
                        {
                            comboSCHI2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboRole1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboRole1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboRole1.Text;
                    String text2 = comboRole2.Text;
                    var role = soft.CV_ROLE.Where(a => a.Role.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (role == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Role table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_ROLE item = new CV_ROLE();
                            item.Role = text1;
                            soft.CV_ROLE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmRole1 = new List<String>();
                            List<String> itmRole2 = new List<String>();
                            itmRole1.Add("");
                            itmRole2.Add("");
                            if (soft.CV_ROLE.Count() != 0)
                            {
                                foreach (var x in soft.CV_ROLE.Select(a => a.Role).OrderBy(a => a).ToList())
                                {
                                    itmRole1.Add(x);
                                    itmRole2.Add(x);
                                }
                            }
                            comboRole1.DataSource = itmRole1;
                            comboRole2.DataSource = itmRole2;
                            comboRole1.SelectedItem = text1;
                            comboRole2.SelectedItem = text2;
                        }
                        else
                        {
                            comboRole1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboRole2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboRole2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboRole1.Text;
                    String text2 = comboRole2.Text;
                    var role = soft.CV_ROLE.Where(a => a.Role.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (role == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Role table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_ROLE item = new CV_ROLE();
                            item.Role = text2;
                            soft.CV_ROLE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmRole1 = new List<String>();
                            List<String> itmRole2 = new List<String>();
                            itmRole1.Add("");
                            itmRole2.Add("");
                            if (soft.CV_ROLE.Count() != 0)
                            {
                                foreach (var x in soft.CV_ROLE.Select(a => a.Role).OrderBy(a => a).ToList())
                                {
                                    itmRole1.Add(x);
                                    itmRole2.Add(x);
                                }
                            }
                            comboRole1.DataSource = itmRole1;
                            comboRole2.DataSource = itmRole2;
                            comboRole1.SelectedItem = text1;
                            comboRole2.SelectedItem = text2;
                        }
                        else
                        {
                            comboRole2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboJunSen1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboJunSen1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboJunSen1.Text;
                    String text2 = comboJunSen2.Text;
                    String text3 = comboJunSenior.Text;

                    var level = soft.CV_JUNSENIOR.Where(a => a.JunSenior.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (level == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Level table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_JUNSENIOR item = new CV_JUNSENIOR();
                            item.JunSenior = text1;
                            soft.CV_JUNSENIOR.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmLevel1 = new List<String>();
                            List<String> itmLevel2 = new List<String>();
                            List<String> itmLevel3 = new List<String>();
                            itmLevel1.Add("");
                            itmLevel2.Add("");
                            itmLevel3.Add("");
                            if (soft.CV_JUNSENIOR.Where(a => a.JunSenior != "ALL").Count() != 0)
                            {
                                foreach (var x in soft.CV_JUNSENIOR.Where(a => a.JunSenior != "ALL").Select(a => a.JunSenior).OrderBy(a => a).ToList())
                                {
                                    itmLevel1.Add(x);
                                    itmLevel2.Add(x);
                                    itmLevel3.Add(x);
                                }
                            }
                            comboJunSen1.DataSource = itmLevel1;
                            comboJunSen2.DataSource = itmLevel2;
                            comboJunSenior.DataSource = itmLevel3;
                            comboJunSen1.SelectedItem = text1;
                            comboJunSen2.SelectedItem = text2;
                            comboJunSenior.SelectedItem = text3;
                        }
                        else
                        {
                            comboJunSen1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboJunSen2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboJunSen2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboJunSen1.Text;
                    String text2 = comboJunSen2.Text;
                    String text3 = comboJunSenior.Text;

                    var level = soft.CV_JUNSENIOR.Where(a => a.JunSenior.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (level == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Level table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_JUNSENIOR item = new CV_JUNSENIOR();
                            item.JunSenior = text2;
                            soft.CV_JUNSENIOR.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmLevel1 = new List<String>();
                            List<String> itmLevel2 = new List<String>();
                            List<String> itmLevel3 = new List<String>();
                            itmLevel1.Add("");
                            itmLevel2.Add("");
                            itmLevel3.Add("");
                            if (soft.CV_JUNSENIOR.Where(a => a.JunSenior != "ALL").Count() != 0)
                            {
                                foreach (var x in soft.CV_JUNSENIOR.Where(a => a.JunSenior != "ALL").Select(a => a.JunSenior).OrderBy(a => a).ToList())
                                {
                                    itmLevel1.Add(x);
                                    itmLevel2.Add(x);
                                    itmLevel3.Add(x);
                                }
                            }
                            comboJunSen1.DataSource = itmLevel1;
                            comboJunSen2.DataSource = itmLevel2;
                            comboJunSenior.DataSource = itmLevel3;
                            comboJunSen1.SelectedItem = text1;
                            comboJunSen2.SelectedItem = text2;
                            comboJunSenior.SelectedItem = text3;
                        }
                        else
                        {
                            comboJunSen2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboCountry1_Validated(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(comboCountry1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboCountry1.Text;
                    String text2 = comboCountry2.Text;
                    String text3 = comboNationality.Text;
                    String text4 = comboCountry.Text;
                    var country = soft.CV_NATIONS.Where(a => a.Country.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (country == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Nations table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_NATIONS item = new CV_NATIONS();
                            item.Country = text1;
                            soft.CV_NATIONS.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmcountry1 = new List<String>();
                            List<String> itmcountry2 = new List<String>();
                            List<String> itmcountry3 = new List<String>();
                            List<String> itmcountry4 = new List<String>();
                            itmcountry1.Add("");
                            itmcountry2.Add("");
                            itmcountry3.Add("");
                            itmcountry4.Add("");
                            if (soft.CV_NATIONS.Count() != 0)
                            {
                                foreach (var x in soft.CV_NATIONS.Select(a => a.Country).OrderBy(a => a).ToList())
                                {
                                    itmcountry1.Add(x);
                                    itmcountry2.Add(x);
                                    itmcountry3.Add(x);
                                    itmcountry4.Add(x);
                                }
                            }
                            comboCountry1.DataSource = itmcountry1;
                            comboCountry2.DataSource = itmcountry2;
                            comboNationality.DataSource = itmcountry3;
                            comboCountry.DataSource = itmcountry4;

                            comboCountry1.SelectedItem = text1;
                            comboCountry2.SelectedItem = text2;
                            comboNationality.SelectedItem = text3;
                            comboCountry.SelectedItem = text4;
                        }
                        else
                        {
                            comboCountry1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboCountry2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboCountry2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboCountry1.Text;
                    String text2 = comboCountry2.Text;
                    String text3 = comboNationality.Text;
                    String text4 = comboCountry.Text;
                    var country = soft.CV_NATIONS.Where(a => a.Country.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (country == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Nations table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_NATIONS item = new CV_NATIONS();
                            item.Country = text2;
                            soft.CV_NATIONS.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmcountry1 = new List<String>();
                            List<String> itmcountry2 = new List<String>();
                            List<String> itmcountry3 = new List<String>();
                            List<String> itmcountry4 = new List<String>();
                            itmcountry1.Add("");
                            itmcountry2.Add("");
                            itmcountry3.Add("");
                            itmcountry4.Add("");
                            if (soft.CV_NATIONS.Count() != 0)
                            {
                                foreach (var x in soft.CV_NATIONS.Select(a => a.Country).OrderBy(a => a).ToList())
                                {
                                    itmcountry1.Add(x);
                                    itmcountry2.Add(x);
                                    itmcountry3.Add(x);
                                    itmcountry4.Add(x);
                                }
                            }
                            comboCountry1.DataSource = itmcountry1;
                            comboCountry2.DataSource = itmcountry2;
                            comboNationality.DataSource = itmcountry3;
                            comboCountry.DataSource = itmcountry4;
                            comboCountry1.SelectedItem = text1;
                            comboCountry2.SelectedItem = text2;
                            comboNationality.SelectedItem = text3;
                            comboCountry.SelectedItem = text4;
                        }
                        else
                        {
                            comboCountry1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboLangReport1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboLangReport1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboLangReport1.Text;
                    String text2 = comboLangReport2.Text;
                    var lang = soft.CV_LANGUAGE.Where(a => a.Language.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (lang == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Language table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_LANGUAGE item = new CV_LANGUAGE();
                            item.Language = text1;
                            soft.CV_LANGUAGE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmLang1 = new List<String>();
                            List<String> itmLang2 = new List<String>();
                            itmLang1.Add("");
                            itmLang2.Add("");
                            if (soft.CV_LANGUAGE.Count() != 0)
                            {
                                foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                                {
                                    itmLang1.Add(x);
                                    itmLang2.Add(x);
                                }
                            }
                            comboLangReport1.DataSource = itmLang1;
                            comboLangReport2.DataSource = itmLang2;
                            comboLangReport1.SelectedItem = text1;
                            comboLangReport2.SelectedItem = text2;
                        }
                        else
                        {
                            comboLangReport1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboLangReport2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboLangReport2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboLangReport1.Text;
                    String text2 = comboLangReport2.Text;
                    var lang = soft.CV_LANGUAGE.Where(a => a.Language.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (lang == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Language table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_LANGUAGE item = new CV_LANGUAGE();
                            item.Language = text2;
                            soft.CV_LANGUAGE.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmLang1 = new List<String>();
                            List<String> itmLang2 = new List<String>();
                            itmLang1.Add("");
                            itmLang2.Add("");
                            if (soft.CV_LANGUAGE.Count() != 0)
                            {
                                foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                                {
                                    itmLang1.Add(x);
                                    itmLang2.Add(x);
                                }
                            }
                            comboLangReport1.DataSource = itmLang1;
                            comboLangReport2.DataSource = itmLang2;
                            comboLangReport1.SelectedItem = text1;
                            comboLangReport2.SelectedItem = text2;
                        }
                        else
                        {
                            comboLangReport2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void ep1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ep1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = ep1.Text;
                    String text2 = ep2.Text;
                    String text3 = ep3.Text;
                    var test = soft.CV_EPROFIL.Where(a => a.EProfile.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (test == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Eprofile table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_EPROFIL item = new CV_EPROFIL();
                            item.EProfile = text1;
                            soft.CV_EPROFIL.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmtest1 = new List<String>();
                            List<String> itmtest2 = new List<String>();
                            List<String> itmtest3 = new List<String>();
                            itmtest1.Add("");
                            itmtest2.Add("");
                            itmtest3.Add("");
                            if (soft.CV_GAPPREC.Count() != 0)
                            {
                                foreach (var x in soft.CV_EPROFIL.Select(a => a.EProfile).OrderBy(a => a).ToList())
                                {
                                    itmtest1.Add(x);
                                    itmtest2.Add(x);
                                    itmtest3.Add(x);
                                }
                            }
                            ep1.DataSource = itmtest1;
                            ep2.DataSource = itmtest2;
                            ep3.DataSource = itmtest3;
                            ep1.SelectedItem = text1;
                            ep2.SelectedItem = text2;
                            ep3.SelectedItem = text3;
                        }
                        else
                        {
                            ep1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void ep2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ep2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = ep1.Text;
                    String text2 = ep2.Text;
                    String text3 = ep3.Text;
                    var test = soft.CV_EPROFIL.Where(a => a.EProfile.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (test == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Eprofile table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_EPROFIL item = new CV_EPROFIL();
                            item.EProfile = text2;
                            soft.CV_EPROFIL.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmtest1 = new List<String>();
                            List<String> itmtest2 = new List<String>();
                            List<String> itmtest3 = new List<String>();
                            itmtest1.Add("");
                            itmtest2.Add("");
                            itmtest3.Add("");
                            if (soft.CV_GAPPREC.Count() != 0)
                            {
                                foreach (var x in soft.CV_EPROFIL.Select(a => a.EProfile).OrderBy(a => a).ToList())
                                {
                                    itmtest1.Add(x);
                                    itmtest2.Add(x);
                                    itmtest3.Add(x);
                                }
                            }
                            ep1.DataSource = itmtest1;
                            ep2.DataSource = itmtest2;
                            ep3.DataSource = itmtest3;
                            ep1.SelectedItem = text1;
                            ep2.SelectedItem = text2;
                            ep3.SelectedItem = text3;
                        }
                        else
                        {
                            ep2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void ep3_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ep3.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = ep1.Text;
                    String text2 = ep2.Text;
                    String text3 = ep3.Text;
                    var test = soft.CV_EPROFIL.Where(a => a.EProfile.ToLower() == text3.ToLower()).FirstOrDefault();
                    if (test == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text3 + " \" does not exist in Eprofile table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_EPROFIL item = new CV_EPROFIL();
                            item.EProfile = text3;
                            soft.CV_EPROFIL.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmtest1 = new List<String>();
                            List<String> itmtest2 = new List<String>();
                            List<String> itmtest3 = new List<String>();
                            itmtest1.Add("");
                            itmtest2.Add("");
                            itmtest3.Add("");
                            if (soft.CV_GAPPREC.Count() != 0)
                            {
                                foreach (var x in soft.CV_EPROFIL.Select(a => a.EProfile).OrderBy(a => a).ToList())
                                {
                                    itmtest1.Add(x);
                                    itmtest2.Add(x);
                                    itmtest3.Add(x);
                                }
                            }
                            ep1.DataSource = itmtest1;
                            ep2.DataSource = itmtest2;
                            ep3.DataSource = itmtest3;
                            ep1.SelectedItem = text1;
                            ep2.SelectedItem = text2;
                            ep3.SelectedItem = text3;
                        }
                        else
                        {
                            ep3.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboClt1_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboClt1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboClt1.Text;
                    String text2 = comboClt2.Text;
                    var test = soft.CV_CLIENT.Where(a => a.Client.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (test == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Client table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_CLIENT item = new CV_CLIENT();
                            item.Client = text1;
                            soft.CV_CLIENT.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmtest1 = new List<String>();
                            List<String> itmtest2 = new List<String>();
                            itmtest1.Add("");
                            itmtest2.Add("");
                            if (soft.CV_CLIENT.Count() != 0)
                            {
                                foreach (var x in soft.CV_CLIENT.Select(a => a.Client).OrderBy(a => a).ToList())
                                {
                                    itmtest1.Add(x);
                                    itmtest2.Add(x);
                                }
                            }
                            comboClt1.DataSource = itmtest1;
                            comboClt2.DataSource = itmtest2;
                            comboClt1.SelectedItem = text1;
                            comboClt2.SelectedItem = text2;
                        }
                        else
                        {
                            comboClt1.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboClt2_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboClt2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboClt1.Text;
                    String text2 = comboClt2.Text;
                    var test = soft.CV_CLIENT.Where(a => a.Client.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (test == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Client table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_CLIENT item = new CV_CLIENT();
                            item.Client = text2;
                            soft.CV_CLIENT.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmtest1 = new List<String>();
                            List<String> itmtest2 = new List<String>();
                            itmtest1.Add("");
                            itmtest2.Add("");
                            if (soft.CV_CLIENT.Count() != 0)
                            {
                                foreach (var x in soft.CV_CLIENT.Select(a => a.Client).OrderBy(a => a).ToList())
                                {
                                    itmtest1.Add(x);
                                    itmtest2.Add(x);
                                }
                            }
                            comboClt1.DataSource = itmtest1;
                            comboClt2.DataSource = itmtest2;
                            comboClt1.SelectedItem = text1;
                            comboClt2.SelectedItem = text2;
                        }
                        else
                        {
                            comboClt2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboClt1_Validated_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboClt1.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboClt1.Text;
                    String text2 = comboClt2.Text;
                    var test = soft.CV_CLIENT.Where(a => a.Client.ToLower() == text1.ToLower()).FirstOrDefault();
                    if (test == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text1 + " \" does not exist in Client table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_CLIENT item = new CV_CLIENT();
                            item.Client = text1;
                            soft.CV_CLIENT.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmtest1 = new List<String>();
                            List<String> itmtest2 = new List<String>();
                            itmtest1.Add("");
                            itmtest2.Add("");
                            if (soft.CV_CLIENT.Count() != 0)
                            {
                                foreach (var x in soft.CV_CLIENT.Select(a => a.Client).OrderBy(a => a).ToList())
                                {
                                    itmtest1.Add(x);
                                    itmtest2.Add(x);
                                }
                            }
                            comboClt1.DataSource = itmtest1;
                            comboClt2.DataSource = itmtest2;
                            comboClt1.SelectedItem = text1;
                            comboClt2.SelectedItem = text2;
                        }
                        else
                        {
                            comboClt1.SelectedItem = "";
                        }
                    }
                }
            }

        }

        private void comboClt2_Validated_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboClt2.Text))
            {
                if (Token.getAUTHO() == true)
                {
                    DbCVBASE soft = new DbCVBASE();
                    String text1 = comboClt1.Text;
                    String text2 = comboClt2.Text;
                    var test = soft.CV_CLIENT.Where(a => a.Client.ToLower() == text2.ToLower()).FirstOrDefault();
                    if (test == null)
                    {
                        DialogResult result = MessageBox.Show(" \"" + text2 + " \" does not exist in Client table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CV_CLIENT item = new CV_CLIENT();
                            item.Client = text2;
                            soft.CV_CLIENT.Add(item);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            List<String> itmtest1 = new List<String>();
                            List<String> itmtest2 = new List<String>();
                            itmtest1.Add("");
                            itmtest2.Add("");
                            if (soft.CV_CLIENT.Count() != 0)
                            {
                                foreach (var x in soft.CV_CLIENT.Select(a => a.Client).OrderBy(a => a).ToList())
                                {
                                    itmtest1.Add(x);
                                    itmtest2.Add(x);
                                }
                            }
                            comboClt1.DataSource = itmtest1;
                            comboClt2.DataSource = itmtest2;
                            comboClt1.SelectedItem = text1;
                            comboClt2.SelectedItem = text2;
                        }
                        else
                        {
                            comboClt2.SelectedItem = "";
                        }
                    }
                }
            }
        }

        private void comboDipl1_TextChanged(object sender, EventArgs e)
        {                     
            try
            {

                if (!String.IsNullOrEmpty(comboDipl1.Text))
                {
                    TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                    foreach (var value in comboDipl1.Text)
                    {
                        comboDipl1.Text = ti.ToTitleCase(comboDipl1.Text.ToLower());
                    }
                    comboDipl1.Select(comboDipl1.Text.Length, 0);
                }
                DbCVBASE soft = new DbCVBASE();

                textScoreDipl1.Text = "0";

                int DP1 = 0;
                int DP2 = 0;
                int DP3 = 0;

                if (!String.IsNullOrEmpty(textScoreDipl2.Text))
                    DP2 = int.Parse(textScoreDipl2.Text);
                if (!String.IsNullOrEmpty(textScoreDipl3.Text))
                    DP3 = int.Parse(textScoreDipl3.Text);

                if (!String.IsNullOrEmpty(comboDipl1.Text))
                {
                    if (soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl1.Text).Count() != 0)
                    {
                        var isDip = soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl1.Text).FirstOrDefault();

                        if (soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDip.IDDiploma).Count() != 0)
                        {
                            var isRank = soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDip.IDDiploma).FirstOrDefault();

                            textScoreDipl1.Text = isRank.Rank.Value.ToString();

                            DP1 = (int)isRank.Rank.Value;
                        }
                    }
                }
      
                int TOTAL = 0;

                if (DP1 >= DP2 && DP1 >= DP3)
                    TOTAL = DP1;
                else if (DP2 >= DP1 && DP2 >= DP3)
                    TOTAL = DP2;
                else if (DP3 >= DP1 && DP3 >= DP2)
                    TOTAL = DP3;

                textScoreDipGen.Text = TOTAL.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboDipl2_TextChanged(object sender, EventArgs e)
        {
           try
            {
                DbCVBASE soft = new DbCVBASE();

                textScoreDipl2.Text = "0";

                int DP1 = 0;
                int DP2 = 0;
                int DP3 = 0;

                if (!String.IsNullOrEmpty(textScoreDipl1.Text))
                    DP1 = int.Parse(textScoreDipl1.Text);
                if (!String.IsNullOrEmpty(textScoreDipl3.Text))
                    DP3 = int.Parse(textScoreDipl3.Text);

                if (!String.IsNullOrEmpty(comboDipl2.Text))
                {
                    if (soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl2.Text).Count() != 0)
                    {
                        var isDip = soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl2.Text).FirstOrDefault();

                        if (soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDip.IDDiploma).Count() != 0)
                        {
                            var isRank = soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDip.IDDiploma).FirstOrDefault();

                            textScoreDipl2.Text = isRank.Rank.Value.ToString();

                            DP2 = (int)isRank.Rank.Value;
                        }
                    }
                }
 
                int TOTAL = 0;

                if (DP1 >= DP2 && DP1 >= DP3)
                    TOTAL = DP1;
                else if (DP2 >= DP1 && DP2 >= DP3)
                    TOTAL = DP2;
                else if (DP3 >= DP1 && DP3 >= DP2)
                    TOTAL = DP3;

                textScoreDipGen.Text = TOTAL.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboDipl3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                textScoreDipl3.Text = "0";

                int DP1 = 0;
                int DP2 = 0;
                int DP3 = 0;

                if (!String.IsNullOrEmpty(textScoreDipl1.Text))
                    DP1 = int.Parse(textScoreDipl1.Text);
                if (!String.IsNullOrEmpty(textScoreDipl2.Text))
                    DP2 = int.Parse(textScoreDipl2.Text);

                if (!String.IsNullOrEmpty(comboDipl3.Text))
                {
                    if (soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl3.Text).Count() != 0)
                    {
                        var isDip = soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl3.Text).FirstOrDefault();

                        if (soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDip.IDDiploma).Count() != 0)
                        {
                            var isRank = soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDip.IDDiploma).FirstOrDefault();

                            textScoreDipl3.Text = isRank.Rank.Value.ToString();

                            DP3 = (int)isRank.Rank.Value;
                        }
                    }
                }
  
                int TOTAL = 0;

                if (DP1 >= DP2 && DP1 >= DP3)
                    TOTAL = DP1;
                else if (DP2 >= DP1 && DP2 >= DP3)
                    TOTAL = DP2;
                else if (DP3 >= DP1 && DP3 >= DP2)
                    TOTAL = DP3;

                textScoreDipGen.Text = TOTAL.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboLang1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboLang1.Text))
            {
                comboLangW1.Enabled = true;
                comboLangW1.Text = null;
                comboLangS1.Enabled = true;
                comboLangS1.Text = null;
            }
            else
            {
                comboLangW1.Enabled = false;
                comboLangW1.Text = null;
                comboLangS1.Enabled = false;
                comboLangS1.Text = null;
            }
        }

        private void comboLang2_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboLang2.Text))
            {
                comboLangW2.Enabled = true;
                comboLangW2.Text = null;
                comboLangS2.Enabled = true;
                comboLangS2.Text = null;
            }
            else
            {
                comboLangW2.Enabled = false;
                comboLangW2.Text = null;
                comboLangS2.Enabled = false;
                comboLangS2.Text = null;
            }
        }

        private void comboLang3_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboLang3.Text))
            {
                comboLangW3.Enabled = true;
                comboLangW3.Text = null;
                comboLangS3.Enabled = true;
                comboLangS3.Text = null;
            }
            else
            {
                comboLangW3.Enabled = false;
                comboLangW3.Text = null;
                comboLangS3.Enabled = false;
                comboLangS3.Text = null;
            }
        }

        private void comboLang4_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboLang4.Text))
            {
                comboLangW4.Enabled = true;
                comboLangW4.Text = null;
                comboLangS4.Enabled = true;
                comboLangS4.Text = null;
            }
            else
            {
                comboLangW4.Enabled = false;
                comboLangW4.Text = null;
                comboLangS4.Enabled = false;
                comboLangS4.Text = null;
            }
        }

        private void comboTechField1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboTechField1.Text))
            {
                textTFYears1.Enabled = true;
                textTFYears1.Text = "0";
            }
            else
            {
                textTFYears1.Enabled = false;
                textTFYears1.Text = "0";
            }
        }

        private void comboTechField2_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboTechField2.Text))
            {
                textTFYears2.Enabled = true;
                textTFYears2.Text = "0";
            }
            else
            {
                textTFYears2.Enabled = false;
                textTFYears2.Text = "0";
            }
        }

        private void comboTechField3_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboTechField3.Text))
            {
                textTFYears3.Enabled = true;
                textTFYears3.Text = "0";
            }
            else
            {
                textTFYears3.Enabled = false;
                textTFYears3.Text = "0";
            }
        }

        private void comboRegion1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboRegion1.Text))
            {
                textRYears1.Enabled = true;
                textRYears1.Text = "0";
            }
            else
            {
                textRYears1.Enabled = false;
                textRYears1.Text = "0";
            }
        }

        private void comboRegion2_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboRegion2.Text))
            {
                textRYears2.Enabled = true;
                textRYears2.Text = "0";
            }
            else
            {
                textRYears2.Enabled = false;
                textRYears2.Text = "0";
            }
        }

        private void comboRegion3_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboRegion3.Text))
            {
                textRYears3.Enabled = true;
                textRYears3.Text = "0";
            }
            else
            {
                textRYears3.Enabled = false;
                textRYears3.Text = "0";
            }
        }

        private void textdateSDWork1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textdateSDWork1.Text))
            {
                textDurWeek1.Enabled = true;
                comboSCHI1.Enabled = true;
                comboRole1.Enabled = true;
                comboJunSen1.Enabled = true;
                comboMainSup1.Enabled = true;
                textAppr1.Enabled = true;
                comboClt1.Enabled = true;
                comboDomExp1.Enabled = true;
                comboCountry1.Enabled = true;
                comboLangReport1.Enabled = true;
                comboLFA1.Enabled = true;
                textDailyFeePaid1.Enabled = true;
                textLink1.Enabled = true;
                button9.Enabled = true;
                button15.Enabled = true;

                textDurWeek1.Text = "0";
                comboSCHI1.Text = null;
                comboRole1.Text = null;
                comboJunSen1.Text = null;
                comboMainSup1.Text = null;
                textAppr1.Text = null;
                comboClt1.Text = null;
                comboDomExp1.Text = null;
                comboCountry1.Text = null;
                comboLangReport1.Text = null;
                comboLFA1.Text = null;
                textDailyFeePaid1.Text = "0.00";
                textLink1.Text = null;
            }
            else
            {
                textDurWeek1.Enabled = false;
                comboSCHI1.Enabled = false;
                comboRole1.Enabled = false;
                comboJunSen1.Enabled = false;
                comboMainSup1.Enabled = false;
                textAppr1.Enabled = false;
                comboClt1.Enabled = false;
                comboDomExp1.Enabled = false;
                comboCountry1.Enabled = false;
                comboLangReport1.Enabled = false;
                comboLFA1.Enabled = false;
                textDailyFeePaid1.Enabled = false;
                textLink1.Enabled = false;
                button9.Enabled = false;
                button15.Enabled = false;

                textDurWeek1.Text = "0";
                comboSCHI1.Text = null;
                comboRole1.Text = null;
                comboJunSen1.Text = null;
                comboMainSup1.Text = null;
                textAppr1.Text = null;
                comboClt1.Text = null;
                comboDomExp1.Text = null;
                comboCountry1.Text = null;
                comboLangReport1.Text = null;
                comboLFA1.Text = null;
                textDailyFeePaid1.Text = "0.00";
                textLink1.Text = null;
            }
        }

        private void textdateSDWork2_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textdateSDWork2.Text))
            {
                textDurWeek2.Enabled = true;
                comboSCHI2.Enabled = true;
                comboRole2.Enabled = true;
                comboJunSen2.Enabled = true;
                comboMainSup2.Enabled = true;
                textAppr2.Enabled = true;
                comboClt2.Enabled = true;
                comboDomExp2.Enabled = true;
                comboCountry2.Enabled = true;
                comboLangReport2.Enabled = true;
                comboLFA2.Enabled = true;
                textDailyFeePaid2.Enabled = true;
                textLink2.Enabled = true;
                button10.Enabled = true;
                button16.Enabled = true;

                textDurWeek2.Text = "0";
                comboSCHI2.Text = null;
                comboRole2.Text = null;
                comboJunSen2.Text = null;
                comboMainSup2.Text = null;
                textAppr2.Text = null;
                comboClt2.Text = null;
                comboDomExp2.Text = null;
                comboCountry2.Text = null;
                comboLangReport2.Text = null;
                comboLFA2.Text = null;
                textDailyFeePaid2.Text = "0.00";
                textLink2.Text = null;
             
            }
            else
            {
                textDurWeek2.Enabled = false;
                comboSCHI2.Enabled = false;
                comboRole2.Enabled = false;
                comboJunSen2.Enabled = false;
                comboMainSup2.Enabled = false;
                textAppr2.Enabled = false;
                comboClt2.Enabled = false;
                comboDomExp2.Enabled = false;
                comboCountry2.Enabled = false;
                comboLangReport2.Enabled = false;
                comboLFA2.Enabled = false;
                textDailyFeePaid2.Enabled = false;
                textLink2.Enabled = false;
                button10.Enabled = false;
                button16.Enabled = false;

                textDurWeek2.Text = "0";
                comboSCHI2.Text = null;
                comboRole2.Text = null;
                comboJunSen2.Text = null;
                comboMainSup2.Text = null;
                textAppr2.Text = null;
                comboClt2.Text = null;
                comboDomExp2.Text = null;
                comboCountry2.Text = null;
                comboLangReport2.Text = null;
                comboLFA2.Text = null;
                textDailyFeePaid2.Text = "0.00";
                textLink2.Text = null;
               
               
            }
        }

        private void textdateVisitSPMU_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textdateVisitSPMU.Text))
            {
                comboEmplMet1.Enabled = true;
                comboEmplMet2.Enabled = true;
                comboEmplMet3.Enabled = true;
                comboPosTarget.Enabled = true;
                comboTestDone.Enabled = true;
                comboGlobAppr.Enabled = true;
                textVisitSPMUComm.Enabled = true;

                comboEmplMet1.Text = null;
                comboEmplMet2.Text = null;
                comboEmplMet3.Text = null;
                comboPosTarget.Text = null;
                comboTestDone.Text = "0";
                comboGlobAppr.Text = null;
                textVisitSPMUComm.Text = null;
            }
            else
            {
                comboEmplMet1.Enabled = false;
                comboEmplMet2.Enabled = false;
                comboEmplMet3.Enabled = false;
                comboPosTarget.Enabled = false;
                comboTestDone.Enabled = false;
                comboGlobAppr.Enabled = false;
                textVisitSPMUComm.Enabled = false;

                comboEmplMet1.Text = null;
                comboEmplMet2.Text = null;
                comboEmplMet3.Text = null;
                comboPosTarget.Text = null;
                comboTestDone.Text = "0";
                comboGlobAppr.Text = null;
                textVisitSPMUComm.Text = null;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textMail1.Text))
                {
                    var body = "Dear " + comboTitle.Text + ". " + comboName.Text + " " + textPrenom.Text + "," + "\n\n";

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
                    string Recipient = textMail1.Text;
                    string CCD = "";
                    UIdoc.FieldSetText("EnterSendTo", Recipient);
                    UIdoc.FieldSetText("EnterCopyTo", CCD);
                    string Subject1 = "";
                    UIdoc.FieldSetText("Subject", Subject1);
                    UIdoc.GotoField("Body");
                    UIdoc.INSERTTEXT("");
                    UIdoc = null;
                    WorkSpace = null;
                    db = null;
                    Notes = null;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Open HCL Notes please", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textMail2.Text))
                {
                    var body = "Dear " + comboTitle.Text + ". " + comboName.Text + " " + textPrenom.Text + "," + "\n\n";

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
                    string Recipient = textMail1.Text;
                    string CCD = "";
                    UIdoc.FieldSetText("EnterSendTo", Recipient);
                    UIdoc.FieldSetText("EnterCopyTo", CCD);
                    string Subject1 = "";
                    UIdoc.FieldSetText("Subject", Subject1);
                    UIdoc.GotoField("Body");
                    UIdoc.INSERTTEXT("");
                    UIdoc = null;
                    WorkSpace = null;
                    db = null;
                    Notes = null;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Open HCL Notes please", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textMail1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textMail1.Text))
                button29.Enabled = true;
        }

        private void textMail2_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textMail2.Text))
                button30.Enabled = true;
        }

        private void comboCat_DropDown(object sender, EventArgs e)
        {
            comboCat.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void textdateLastRequest_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (entrer != 8)
            {
                e.Handled = true;
            }
        }

        private void textBonusDoc_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBonusDoc.Text))
                textBonusDoc.Text = "0";
        }

        private void textScoreDipl3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label78_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label75_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label73_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label79_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label119_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboNationality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textDailyFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 && entrer != 44)
            {
                e.Handled = true;
            }
        }

        private void comboCat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                DbCVBASE soft = new DbCVBASE();

                if (!String.IsNullOrEmpty(comboCat.Text))
                {

                    if (soft.CV_CATEGORY.Where(a => a.Category == comboCat.Text && a.ISOK == true).Count() != 0)
                    {
                        comboCat.BackColor = Color.FromArgb(255, 255, 192);
                    }
                    else
                    {
                        comboCat.BackColor = Color.Tomato;
                    }
                }
                else
                {
                    comboCat.BackColor = Color.FromArgb(255, 255, 192);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
      
        private static Dictionary<string, string> AllTextBox = new Dictionary<string, string>();
        private static Dictionary<string, string> AllComboBox = new Dictionary<string, string>();
        private static Dictionary<string, CheckState> AllCheckBox = new Dictionary<string, CheckState>();
        private static Dictionary<string, string> AllTextBox1 = new Dictionary<string, string>();
        private static Dictionary<string, string> AllComboBox1 = new Dictionary<string, string>();


        bool testLoad = false;
        private void Frm_cvadd_Load(object sender, EventArgs e)
        {
            AllValue();
            if(isnew)
            EnableFalseCV();
            testLoad = true;

            comboCat_Validated(sender, e);
        }

        private void comboDoc1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void comboDoc2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboDoc3_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void comboDoc4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboDoc5_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void comboTestDone_Validated_1(object sender, EventArgs e)
        {
            int testint;
            if (int.TryParse(comboTestDone.Text, out testint))
            {
                comboTestDone.Text = string.Format("{0:#,##0}", int.Parse(comboTestDone.Text));
            }
            else
            {
                string message = "Number too large";
                string caption = "CVBASE";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboTestDone.Text = "0";
            }
        }

        private void Frm_cvadd_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkupdate();
            if (Token.getAUTHO() == true)
            {
                /*  if (updated == true)
                  {
                      InsertOrUpdateCV();
                  }*/

                textAdress1.Focus();
                textMobilPhone.Focus();
            //    checkupdate();
                if (isnew == true)
                {
                    updated = false;
                    if (!String.IsNullOrEmpty(comboName.Text))
                        updated = true;
                }
                
                if (updated == true && !String.IsNullOrEmpty(comboName.Text))
                {
                    string message = "Do you want to save before close?";
                    string caption = "CVBASE";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                           InsertOrUpdateCV();
                           if (CANSAVE == false)
                           {
                               e.Cancel = true;
                           }
                           else
                           {
                               Current = "`*";
                           }

                    }
                }
                AllTextBox = new Dictionary<string, string>();
                AllComboBox = new Dictionary<string, string>();
                AllCheckBox = new Dictionary<string, CheckState>();
            }
        }

        private void comboName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
             DbCVBASE soft = new DbCVBASE();

             if (!String.IsNullOrEmpty(comboName.Text))
             {
                 if (!itmName.Contains(comboName.Text) && soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                 {
                     int isco = Token.getisCO();
                     var elem = "";
                     if (soft.CV_DATASET.Where(a => a.ID_USERS == isco).Count() != 0)
                     {
                         var isColab = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;
                         if (!String.IsNullOrEmpty(isColab))
                             elem = "The CV exist but you are connected to the " + isColab + " Data set";
                         else
                             elem = "The CV exist but data set undefined";
                     }

                     MessageBox.Show(elem, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 else if (comboName.Text == Current)
                 {
                    // var elem = "The CV is already open";
                    // MessageBox.Show(elem, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 else
                 {
                     //InitialCVNEW();
                     ValidateCV();

                 }
             }
          
              //  ValidateCV();
            }
        }

    
        private void comboName_TextChanged(object sender, EventArgs e)
        {
         

        /*    if (!String.IsNullOrEmpty(comboName.Text))
            {
                if (!itmName.Contains(comboName.Text) && soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0)
                {
                    int isco = Token.getisCO();
                    var elem = "";
                    if (soft.CV_DATASET.Where(a => a.ID_USERS == isco).Count() != 0)
                    {
                        var isColab = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;
                        if (!String.IsNullOrEmpty(isColab))
                            elem = "The CV exist but you are connected to the " + isColab + " Data set";
                        else
                            elem = "The CV exist but data set undefined";
                    }

                    MessageBox.Show(elem, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboName.Text == Current)
                {
                    //     var elem = "The CV is already open";
                    //      MessageBox.Show(elem, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //InitialCVNEW();
                    ValidateCV();

                }

            }*/
        }

     

        private void comboTitle_Validated(object sender, EventArgs e)
        {
            
         
       if (!String.IsNullOrEmpty(comboTitle.Text))
          {
              if (comboTitle.Text != "Mr." && comboTitle.Text != "Mrs.")
              {

                  comboTitle.Text = "";
              }
          
          
          }
         
      
        }

        private void comboName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (testLoad)
            {
                if (!String.IsNullOrEmpty(comboName.Text))
                {
                    DbCVBASE soft = new DbCVBASE();

                    if ((soft.CV_CVBASE.Where(a => a.LastName == comboName.Text).Count() != 0))
                    {
                        //Affichage détails//

                        DetailsCV(comboName.Text);
                        previousToolStripMenuItem.Enabled = true;
                        nextToolStripMenuItem.Enabled = true;
                    }
                }    
            }
       
        }

        private void textScoreDipGen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CALTOTAL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textTFScore_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CALTOTAL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textRScore_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CALTOTAL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textCRScore1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CALTOTAL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textCRScore2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CALTOTAL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textCRScore3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CALTOTAL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textCRScore4_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                CALTOTAL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboTitle_TextChanged(object sender, EventArgs e)
        {
         
         
        }

        private void comboTitle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboTitle.Text))
            {
                if (comboTitle.Text.ToLower() == "mr.")
                {
                    if (comboGender.Text != "Other")
                        comboGender.Text = "Male";

                }
                else if (comboTitle.Text.ToLower() == "mrs.")
                {
                    if (comboGender.Text != "Other")
                        comboGender.Text = "Female";
                }
                else
                {
                    comboGender.Text = "";
                    comboTitle.Text = "";
                }
            }
        }

        private void comboGender_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboGender.Text == "Male")
            {
                comboTitle.Text = "Mr.";
            }
            else if (comboGender.Text == "Female")
            {
                comboTitle.Text = "Mrs.";
            }
        }

        private void comboSpecDipl1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboSpecDipl1.Text))
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                foreach (var value in comboSpecDipl1.Text)
                {
                    comboSpecDipl1.Text = ti.ToTitleCase(comboSpecDipl1.Text.ToLower());
                }
                comboSpecDipl1.Select(comboSpecDipl1.Text.Length, 0);
            }
        }

        private void comboCountry_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboCountry.Text)
            { comboCountry.Text = ti.ToTitleCase(comboCountry.Text.ToLower()); }

            comboCountry.Select(comboCountry.Text.Length, 0);
        }

        private void comboDiplP1_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboDiplP1.Text)
            { comboDiplP1.Text = ti.ToTitleCase(comboDiplP1.Text.ToLower()); }

            comboDiplP1.Select(comboDiplP1.Text.Length, 0);
        }

        private void comboDiplP2_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboDiplP2.Text)
            { comboDiplP2.Text = ti.ToTitleCase(comboDiplP2.Text.ToLower()); }

            comboDiplP2.Select(comboDiplP2.Text.Length, 0);
        }

        private void comboDiplP3_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboDiplP3.Text)
            { comboDiplP3.Text = ti.ToTitleCase(comboDiplP3.Text.ToLower()); }

            comboDiplP3.Select(comboDiplP3.Text.Length, 0);
        }

        private void comboPostGradP1_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboPostGradP1.Text)
            { comboPostGradP1.Text = ti.ToTitleCase(comboPostGradP1.Text.ToLower()); }

            comboPostGradP1.Select(comboPostGradP1.Text.Length, 0);
        }

        private void comboPostGradP2_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboPostGradP2.Text)
            { comboPostGradP2.Text = ti.ToTitleCase(comboPostGradP2.Text.ToLower()); }

            comboPostGradP2.Select(comboPostGradP2.Text.Length, 0);
        }

        private void comboPostGradP3_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboPostGradP3.Text)
            { comboPostGradP3.Text = ti.ToTitleCase(comboPostGradP3.Text.ToLower()); }

            comboPostGradP3.Select(comboPostGradP3.Text.Length, 0);
        }

        private void comboPersTPH_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboPersTPH.Text)
            { comboPersTPH.Text = ti.ToTitleCase(comboPersTPH.Text.ToLower()); }

            comboPersTPH.Select(comboPersTPH.Text.Length, 0);
        }

        private void comboMainSup1_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboMainSup1.Text)
            { comboMainSup1.Text = ti.ToTitleCase(comboMainSup1.Text.ToLower()); }

            comboMainSup1.Select(comboMainSup1.Text.Length, 0);
        }

        private void comboMainSup2_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboMainSup2.Text)
            { comboMainSup2.Text = ti.ToTitleCase(comboMainSup2.Text.ToLower()); }

            comboMainSup2.Select(comboMainSup2.Text.Length, 0);
        }

        private void comboCountry1_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboCountry1.Text)
            { comboCountry1.Text = ti.ToTitleCase(comboCountry1.Text.ToLower()); }

            comboCountry1.Select(comboCountry1.Text.Length, 0);
        }

        private void comboCountry2_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboCountry2.Text)
            { comboCountry2.Text = ti.ToTitleCase(comboCountry2.Text.ToLower()); }

            comboCountry2.Select(comboCountry2.Text.Length, 0);
        }

        private void comboEmplMet1_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboEmplMet1.Text)
            { comboEmplMet1.Text = ti.ToTitleCase(comboEmplMet1.Text.ToLower()); }

            comboEmplMet1.Select(comboEmplMet1.Text.Length, 0);
        }

        private void comboEmplMet2_TextChanged(object sender, EventArgs e)
        {
              TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboEmplMet2.Text)
            { comboEmplMet2.Text = ti.ToTitleCase(comboEmplMet2.Text.ToLower()); }

            comboEmplMet2.Select(comboEmplMet2.Text.Length, 0);
        }

        private void comboEmplMet3_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboEmplMet3.Text)
            { comboEmplMet3.Text = ti.ToTitleCase(comboEmplMet3.Text.ToLower()); }

            comboEmplMet3.Select(comboEmplMet3.Text.Length, 0);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 0 && String.IsNullOrEmpty(textdateCV.Text))
                tabControl1.SelectedIndex = 0;
        }

        private void textdateBirthDay_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textdateBirthDay.Text))
                textAgeCalc.Text = "";
        }

        private void comboTOWN_TextChanged(object sender, EventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            foreach (var value in comboTOWN.Text)
            { comboTOWN.Text = ti.ToTitleCase(comboTOWN.Text.ToLower()); }

            comboTOWN.Select(comboTOWN.Text.Length, 0);
        }

        private void comboTOWN_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();
                if (Token.getAUTHO() == true)
                {
                    if (!String.IsNullOrEmpty(comboTOWN.Text))
                    {
                        String text = comboTOWN.Text;
                        var country = soft.CV_TOWNS.Where(a => a.TOWN.ToLower() == text.ToLower()).FirstOrDefault();
                        if (country == null)
                        {
                            DialogResult result = MessageBox.Show(" \"" + text + " \" does not exist in Town table, do you want to create it?", "CVBASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                CV_TOWNS item = new CV_TOWNS();
                                item.TOWN = text;
                                soft.CV_TOWNS.Add(item);
                                soft.SaveChanges();

                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                List<String> itmCountry = new List<String>();
                                itmCountry.Add("");
                                if (soft.CV_TOWNS.Count() != 0)
                                {
                                    foreach (var x in soft.CV_TOWNS.Select(a => a.TOWN).OrderBy(a => a).ToList())
                                    {
                                        itmCountry.Add(x);
                                    }
                                }
                                comboTOWN.DataSource = itmCountry;
                                comboTOWN.SelectedItem = text;
                            }
                            else
                            {
                                comboTOWN.SelectedItem = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textCRScore5_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                CALTOTAL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
