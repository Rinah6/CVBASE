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
    public partial class Frm_Search : Form
    {
        public Frm_Search()
        {
            InitializeComponent();

            DbCVBASE soft = new DbCVBASE();

            //Category and comboPosTarget//
            List<String> itmCat1 = new List<String>();
            itmCat1.Add("");
            if (soft.CV_CATEGORY.Count() != 0)
            {
                foreach (var x in soft.CV_CATEGORY.Select(a => a.Category).OrderBy(a => a).ToList())
                {
                    itmCat1.Add(x);
                }
            }
            comboCat.DataSource = itmCat1;

            //Language//
            List<String> itmLa1 = new List<String>();
            itmLa1.Add("");
            if (soft.CV_LANGUAGE.Count() != 0)
            {
                foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                {
                    itmLa1.Add(x);
                }
            }
            comboLang.DataSource = itmLa1;

            List<String> itmTF1 = new List<String>();
            itmTF1.Add("");
            if (soft.CV_TECHNICFIELD.Count() != 0)
            {
                foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                {
                    itmTF1.Add(x);
                }
            }
            comboTechField.DataSource = itmTF1;

            //Diplome//
            List<String> itmDipl1 = new List<String>();
            itmDipl1.Add("");
            if (soft.CV_DIPLOMA.Count() != 0)
            {
                foreach (var x in soft.CV_DIPLOMA.Select(a => a.Diploma).OrderBy(a => a).ToList())
                {
                    itmDipl1.Add(x);
                }
            }
            comboDipl.DataSource = itmDipl1;

            //Speciality//
            List<String> itmSp1 = new List<String>();
            itmSp1.Add("");
            if (soft.CV_SPECIALITY.Count() != 0)
            {
                foreach (var x in soft.CV_SPECIALITY.Select(a => a.Speciality).OrderBy(a => a).ToList())
                {
                    itmSp1.Add(x);
                }
            }
            comboSpecDipl.DataSource = itmSp1;

            //REGION//
            List<String> itmRe1 = new List<String>();
            itmRe1.Add("");
            if (soft.CV_REGION.Count() != 0)
            {
                foreach (var x in soft.CV_REGION.Select(a => a.Region).OrderBy(a => a).ToList())
                {
                    itmRe1.Add(x);
                }
            }
            comboRegion.DataSource = itmRe1;

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

            //Nationality//
            List<String> itmNat1 = new List<String>();
            itmNat1.Add("");
            if (soft.CV_NATIONS.Count() != 0)
            {
                foreach (var x in soft.CV_NATIONS.Select(a => a.Country).OrderBy(a => a).ToList())
                {
                    itmNat1.Add(x);
                }
            }
            comboNationality.DataSource = itmNat1;

            //JunSenior//
            List<String> itmJS1 = new List<String>();
            if (soft.CV_JUNSENIOR.Count() != 0)
            {
                foreach (var x in soft.CV_JUNSENIOR.Select(a => a.JunSenior).OrderBy(a => a).ToList())
                {
                    itmJS1.Add(x);
                }
            }
            comboJunSenior.DataSource = itmJS1;

            if(soft.CV_SAVESEARCH.Count() != 0)
            {
                checkBox1.Checked = true;

                var isSave = soft.CV_SAVESEARCH.FirstOrDefault();

                comboCat.SelectedItem = isSave.Cat;
                comboLang.SelectedItem = isSave.Language;
                comboTechField.SelectedItem = isSave.TechField;
                comboDipl.SelectedItem = isSave.Diploma;
                comboSpecDipl.SelectedItem = isSave.Speciality;
                comboRegion.SelectedItem = isSave.Region;
                comboGender.SelectedItem = isSave.Gender;
                comboNationality.SelectedItem = isSave.Nationality;
                comboJunSenior.SelectedItem = isSave.JUNSEN;
                if (isSave.C1 != null)
                {
                    if (isSave.C1 == "Diploma")
                    {
                        List<String> itmDiplLoad = new List<String>();
                        itmDiplLoad.Add("");
                        if (soft.CV_DIPLOMA.Count() != 0)
                        {
                            foreach (var x in soft.CV_DIPLOMA.Select(a => a.Diploma).OrderBy(a => a).ToList())
                            {
                                itmDiplLoad.Add(x);
                            }
                        }
                        V1.DataSource = itmDiplLoad;
                    }
                    else if (isSave.C1 == "Language")
                    {
                        List<String> itmLaload = new List<String>();
                        itmLaload.Add("");
                        if (soft.CV_LANGUAGE.Count() != 0)
                        {
                            foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                            {
                                itmLaload.Add(x);
                            }
                        }
                        V1.DataSource = itmLaload;
                    }
                    else if (isSave.C1 == "Region")
                    {
                        List<String> itmReLoad = new List<String>();
                        itmReLoad.Add("");
                        if (soft.CV_REGION.Count() != 0)
                        {
                            foreach (var x in soft.CV_REGION.Select(a => a.Region).OrderBy(a => a).ToList())
                            {
                                itmReLoad.Add(x);
                            }
                        }
                        V1.DataSource = itmReLoad;
                    }
                    else if (isSave.C1 == "Speciality")
                    {
                        List<String> itmSpLoad = new List<String>();
                        itmSpLoad.Add("");
                        if (soft.CV_SPECIALITY.Count() != 0)
                        {
                            foreach (var x in soft.CV_SPECIALITY.Select(a => a.Speciality).OrderBy(a => a).ToList())
                            {
                                itmSpLoad.Add(x);
                            }
                        }
                        V1.DataSource = itmSpLoad;
                    }
                    else if (isSave.C1 == "Technical Field")
                    {
                        List<String> itmTFLoad = new List<String>();
                        itmTFLoad.Add("");
                        if (soft.CV_TECHNICFIELD.Count() != 0)
                        {
                            foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                            {
                                itmTFLoad.Add(x);
                            }
                        }
                        V1.DataSource = itmTFLoad;
                    }
                }
                if (isSave.C2 != null)
                {
                    if (isSave.C2 == "Diploma")
                    {
                        List<String> itmDiplLoad2 = new List<String>();
                        itmDiplLoad2.Add("");
                        if (soft.CV_DIPLOMA.Count() != 0)
                        {
                            foreach (var x in soft.CV_DIPLOMA.Select(a => a.Diploma).OrderBy(a => a).ToList())
                            {
                                itmDiplLoad2.Add(x);
                            }
                        }
                        V2.DataSource = itmDiplLoad2;
                    }
                    else if (isSave.C2 == "Language")
                    {
                        List<String> itmLaload2 = new List<String>();
                        itmLaload2.Add("");
                        if (soft.CV_LANGUAGE.Count() != 0)
                        {
                            foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                            {
                                itmLaload2.Add(x);
                            }
                        }
                        V2.DataSource = itmLaload2;
                    }
                    else if (isSave.C2 == "Region")
                    {
                        List<String> itmReLoad2 = new List<String>();
                        itmReLoad2.Add("");
                        if (soft.CV_REGION.Count() != 0)
                        {
                            foreach (var x in soft.CV_REGION.Select(a => a.Region).OrderBy(a => a).ToList())
                            {
                                itmReLoad2.Add(x);
                            }
                        }
                        V2.DataSource = itmReLoad2;
                    }
                    else if (isSave.C2 == "Speciality")
                    {
                        List<String> itmSpLoad2 = new List<String>();
                        itmSpLoad2.Add("");
                        if (soft.CV_SPECIALITY.Count() != 0)
                        {
                            foreach (var x in soft.CV_SPECIALITY.Select(a => a.Speciality).OrderBy(a => a).ToList())
                            {
                                itmSpLoad2.Add(x);
                            }
                        }
                        V2.DataSource = itmSpLoad2;
                    }
                    else if (isSave.C2 == "Technical Field")
                    {
                        List<String> itmTFLoad2 = new List<String>();
                        itmTFLoad2.Add("");
                        if (soft.CV_TECHNICFIELD.Count() != 0)
                        {
                            foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                            {
                                itmTFLoad2.Add(x);
                            }
                        }
                        V2.DataSource = itmTFLoad2;
                    }
                }
                if (isSave.C3 != null)
                {
                    if (isSave.C3 == "Diploma")
                    {
                        List<String> itmDiplLoad3 = new List<String>();
                        itmDiplLoad3.Add("");
                        if (soft.CV_DIPLOMA.Count() != 0)
                        {
                            foreach (var x in soft.CV_DIPLOMA.Select(a => a.Diploma).OrderBy(a => a).ToList())
                            {
                                itmDiplLoad3.Add(x);
                            }
                        }
                        V3.DataSource = itmDiplLoad3;
                    }
                    else if (isSave.C3 == "Language")
                    {
                        List<String> itmLaload3 = new List<String>();
                        itmLaload3.Add("");
                        if (soft.CV_LANGUAGE.Count() != 0)
                        {
                            foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                            {
                                itmLaload3.Add(x);
                            }
                        }
                        V3.DataSource = itmLaload3;
                    }
                    else if (isSave.C3 == "Region")
                    {
                        List<String> itmReLoad3 = new List<String>();
                        itmReLoad3.Add("");
                        if (soft.CV_REGION.Count() != 0)
                        {
                            foreach (var x in soft.CV_REGION.Select(a => a.Region).OrderBy(a => a).ToList())
                            {
                                itmReLoad3.Add(x);
                            }
                        }
                        V3.DataSource = itmReLoad3;
                    }
                    else if (isSave.C3 == "Speciality")
                    {
                        List<String> itmSpLoad3 = new List<String>();
                        itmSpLoad3.Add("");
                        if (soft.CV_SPECIALITY.Count() != 0)
                        {
                            foreach (var x in soft.CV_SPECIALITY.Select(a => a.Speciality).OrderBy(a => a).ToList())
                            {
                                itmSpLoad3.Add(x);
                            }
                        }
                        V3.DataSource = itmSpLoad3;
                    }
                    else if (isSave.C3 == "Technical Field")
                    {
                        List<String> itmTFLoad3 = new List<String>();
                        itmTFLoad3.Add("");
                        if (soft.CV_TECHNICFIELD.Count() != 0)
                        {
                            foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                            {
                                itmTFLoad3.Add(x);
                            }
                        }
                        V3.DataSource = itmTFLoad3;
                    }
                }



            /*    if (isSave.C2 != null)
                {
                    if (isSave.C2 == "Diploma")
                    {
                        V2.DataSource = itmDipl1;
                    }
                    else if (isSave.C1 == "Language")
                    {
                        V1.DataSource = itmLa1;
                    }
                    else if (isSave.C1 == "Region")
                    {
                        V1.DataSource = itmRe1;
                    }
                    else if (isSave.C1 == "Speciality")
                    {
                        V1.DataSource = itmSp1;
                    }
                    else if (isSave.C1 == "Technical Field")
                    {
                        V1.DataSource = itmTF1;
                    }
                }*/


                C1.SelectedItem = isSave.C1;
                C2.SelectedItem = isSave.C2;
                C3.SelectedItem = isSave.C3;
                
                V1.SelectedItem = isSave.V1;
                V2.SelectedItem = isSave.V2;
                V3.SelectedItem = isSave.V3;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void C1_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                List<String> itm = new List<String>();
                itm.Clear();
                itm.Add("");

                if (!String.IsNullOrEmpty(C1.Text))
                {
                    if (C1.Text == "Diploma")
                    {
                        if (soft.CV_DIPLOMA.Count() != 0)
                        {
                            foreach (var x in soft.CV_DIPLOMA.Select(a => a.Diploma).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else if (C1.Text == "Language")
                    {
                        if (soft.CV_LANGUAGE.Count() != 0)
                        {
                            foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else if (C1.Text == "Region")
                    {
                        if (soft.CV_REGION.Count() != 0)
                        {
                            foreach (var x in soft.CV_REGION.Select(a => a.Region).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else if (C1.Text == "Speciality")
                    {
                        if (soft.CV_SPECIALITY.Count() != 0)
                        {
                            foreach (var x in soft.CV_SPECIALITY.Select(a => a.Speciality).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else if (C1.Text == "Technical Field")
                    {
                        if (soft.CV_TECHNICFIELD.Count() != 0)
                        {
                            foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else
                    {
                        C1.Text = "";
                    }
                }

                V1.DataSource = itm;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void C2_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                List<String> itm = new List<String>();
                itm.Clear();
                itm.Add("");

                if (!String.IsNullOrEmpty(C2.Text))
                {
                    if (C2.Text == "Diploma")
                    {
                        if (soft.CV_DIPLOMA.Count() != 0)
                        {
                            foreach (var x in soft.CV_DIPLOMA.Select(a => a.Diploma).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else if (C2.Text == "Language")
                    {
                        if (soft.CV_LANGUAGE.Count() != 0)
                        {
                            foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else if (C2.Text == "Region")
                    {
                        if (soft.CV_REGION.Count() != 0)
                        {
                            foreach (var x in soft.CV_REGION.Select(a => a.Region).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else if (C2.Text == "Speciality")
                    {
                        if (soft.CV_SPECIALITY.Count() != 0)
                        {
                            foreach (var x in soft.CV_SPECIALITY.Select(a => a.Speciality).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else if (C2.Text == "Technical Field")
                    {
                        if (soft.CV_TECHNICFIELD.Count() != 0)
                        {
                            foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else
                    {
                        C2.Text = "";
                    }
                }
                V2.DataSource = itm;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void C3_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                List<String> itm = new List<String>();
                itm.Clear();
                itm.Add("");

                if (!String.IsNullOrEmpty(C3.Text))
                {
                    if (C3.Text == "Diploma")
                    {
                        if (soft.CV_DIPLOMA.Count() != 0)
                        {
                            foreach (var x in soft.CV_DIPLOMA.Select(a => a.Diploma).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else if (C3.Text == "Language")
                    {
                        if (soft.CV_LANGUAGE.Count() != 0)
                        {
                            foreach (var x in soft.CV_LANGUAGE.Select(a => a.Language).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else if (C3.Text == "Region")
                    {
                        if (soft.CV_REGION.Count() != 0)
                        {
                            foreach (var x in soft.CV_REGION.Select(a => a.Region).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else if (C3.Text == "Speciality")
                    {
                        if (soft.CV_SPECIALITY.Count() != 0)
                        {
                            foreach (var x in soft.CV_SPECIALITY.Select(a => a.Speciality).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else if (C3.Text == "Technical Field")
                    {
                        if (soft.CV_TECHNICFIELD.Count() != 0)
                        {
                            foreach (var x in soft.CV_TECHNICFIELD.Select(a => a.TechnicField).OrderBy(a => a).ToList())
                            {
                                itm.Add(x);
                            }
                        }
                    }
                    else
                    {
                        C3.Text = "";
                    }
                }
                V3.DataSource = itm;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            V1.Text = null;
            C1.Text = null;
            V2.Text = null;
            C2.Text = null; 
            V3.Text = null;
            C3.Text = null;

            List<String> itm = new List<String>();
            itm.Clear();
            itm.Add("");

            V1.DataSource = itm;
            V2.DataSource = itm;
            V3.DataSource = itm;

            comboCat.Text = null;
            comboLang.Text = null;
            comboTechField.Text = null;
            comboDipl.Text = null;
            comboSpecDipl.Text = null;
            comboRegion.Text = null;
            comboGender.Text = null;
            comboNationality.Text = null;
            comboJunSenior.Text = null;

            checkBox1.Checked = false;

          //  textBox1.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
             
                DbCVBASE soft = new DbCVBASE();

                List<string> stringList = new List<string>();
                stringList.Clear();

                int i = 0;

                DataTable table = new DataTable();
                table.Columns.Clear();

                table.Columns.Add("Status");
                table.Columns.Add("G. Score");
                table.Columns.Add("Category");
                table.Columns.Add("First Name");
                table.Columns.Add("Last Name");
                table.Columns.Add("Main language 2");
                table.Columns.Add("Main language 3");
                table.Columns.Add("Education 2");
                table.Columns.Add("Speciality 2");
                table.Columns.Add("Education 3");
                table.Columns.Add("Speciality 3");
                table.Columns.Add("Regional working 2");
                table.Columns.Add("Regional working 3");

                table.Rows.Clear();

                if (soft.CV_CVBASE.Count() != 0 && (!String.IsNullOrEmpty(comboCat.Text) || !String.IsNullOrEmpty(comboLang.Text) || !String.IsNullOrEmpty(comboTechField.Text)
                    || !String.IsNullOrEmpty(comboDipl.Text) || !String.IsNullOrEmpty(comboSpecDipl.Text) || !String.IsNullOrEmpty(comboRegion.Text)
                    || !String.IsNullOrEmpty(comboGender.Text) || !String.IsNullOrEmpty(comboNationality.Text) || !String.IsNullOrEmpty(comboJunSenior.Text)
                    || !String.IsNullOrEmpty(V1.Text) || !String.IsNullOrEmpty(V2.Text) || !String.IsNullOrEmpty(V2.Text)))
                {
                    List<CV_CVBASE> AllCV = new List<CV_CVBASE>();

                    AllCV = soft.CV_CVBASE.OrderBy(a => a.LastName).ToList();

                    ///1er partie : filtre de AllCV par rapport aux critères de recherche statics///
                    //Cat//
                    var cat = 0;
                    if (!String.IsNullOrEmpty(comboCat.Text))
                    {
                        if (soft.CV_CATEGORY.Where(a => a.Category == comboCat.Text).Count() != 0)
                        {
                            cat = soft.CV_CATEGORY.Where(a => a.Category == comboCat.Text).FirstOrDefault().IDCat;

                            AllCV = AllCV.Where(a => a.IDCat == cat).OrderBy(a => a.LastName).ToList();
                        }
                    }

                    //Language//
                    var lang = 0;
                    if (!String.IsNullOrEmpty(comboLang.Text))
                    {
                        if (soft.CV_LANGUAGE.Where(a => a.Language == comboLang.Text).Count() != 0)
                        {
                            lang = soft.CV_LANGUAGE.Where(a => a.Language == comboLang.Text).FirstOrDefault().IDLanguage;

                            List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                            foreach (var x in AllCV)
                            {
                                if (soft.CV_WRSP.Where(a => a.IDLanguage == lang && a.IDCV == x.IDCV).Count() != 0)
                                {
                                    filtreCV.Add(x);
                                }
                            }

                            AllCV = filtreCV;
                        }
                    }

                    //TECH FIELD//
                    var tf = 0;
                    if (!String.IsNullOrEmpty(comboTechField.Text))
                    {
                        if (soft.CV_TECHNICFIELD.Where(a => a.TechnicField == comboTechField.Text).Count() != 0)
                        {
                            tf = soft.CV_TECHNICFIELD.Where(a => a.TechnicField == comboTechField.Text).FirstOrDefault().IDTechField;

                            List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                            foreach (var x in AllCV)
                            {
                                if (soft.CV_INTLEXPTECH.Where(a => a.IDTechField == tf && a.IDCV == x.IDCV).Count() != 0)
                                {
                                    filtreCV.Add(x);
                                }
                            }

                            AllCV = filtreCV;
                        }
                    }

                    //Diploma//
                    var dipl = 0;
                    if (!String.IsNullOrEmpty(comboDipl.Text))
                    {
                        if (soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl.Text).Count() != 0)
                        {
                            dipl = soft.CV_DIPLOMA.Where(a => a.Diploma == comboDipl.Text).FirstOrDefault().IDDiploma;

                            List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                            foreach (var x in AllCV)
                            {
                                if (soft.CV_EDUC.Where(a => a.IDDiploma == dipl && a.IDCV == x.IDCV).Count() != 0)
                                {
                                    filtreCV.Add(x);
                                }
                            }

                            AllCV = filtreCV;
                        }
                    }

                    //Speciality//
                    var spec = 0;
                    if (!String.IsNullOrEmpty(comboSpecDipl.Text))
                    {
                        if (soft.CV_SPECIALITY.Where(a => a.Speciality == comboSpecDipl.Text).Count() != 0)
                        {
                            spec = soft.CV_SPECIALITY.Where(a => a.Speciality == comboSpecDipl.Text).FirstOrDefault().IDSpeciality;

                            List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                            foreach (var x in AllCV)
                            {
                                if (soft.CV_EDUC.Where(a => a.IDSpeciality == spec && a.IDCV == x.IDCV).Count() != 0)
                                {
                                    filtreCV.Add(x);
                                }
                            }

                            AllCV = filtreCV;
                        }
                    }

                    //Region//
                    var tr = 0;
                    if (!String.IsNullOrEmpty(comboRegion.Text))
                    {
                        if (soft.CV_REGION.Where(a => a.Region == comboRegion.Text).Count() != 0)
                        {
                            tr = soft.CV_REGION.Where(a => a.Region == comboRegion.Text).FirstOrDefault().IDRegion;

                            List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                            foreach (var x in AllCV)
                            {
                                if (soft.CV_INTLREGEXP.Where(a => a.IDRegion == tr && a.IDCV == x.IDCV).Count() != 0)
                                {
                                    filtreCV.Add(x);
                                }
                            }

                            AllCV = filtreCV;
                        }
                    }

                    //Gender//
                    var gender = 0;
                    if (soft.CV_GENDER.Where(a => a.Gender == comboGender.Text).Count() != 0)
                    {
                        gender = soft.CV_GENDER.Where(a => a.Gender == comboGender.Text).FirstOrDefault().IDGender;

                        AllCV = AllCV.Where(a => a.IDGender == gender).OrderBy(a => a.LastName).ToList();
                    }

                    //Nationality//
                    var nationality = 0;
                    if (!String.IsNullOrEmpty(comboNationality.Text))
                    {
                        if (soft.CV_NATIONS.Where(a => a.Country == comboNationality.Text).Count() != 0)
                        {
                            nationality = soft.CV_NATIONS.Where(a => a.Country == comboNationality.Text).FirstOrDefault().IDCountry;

                            AllCV = AllCV.Where(a => a.IDNationality == nationality).OrderBy(a => a.LastName).ToList();
                        }
                    }

                    //JuniorSenior//
                    var junsen = 0;
                    if (!String.IsNullOrEmpty(comboJunSenior.Text))
                    {
                        if (comboJunSenior.Text != "ALL")
                        {
                            if (soft.CV_JUNSENIOR.Where(a => a.JunSenior == comboJunSenior.Text).Count() != 0)
                            {
                                junsen = soft.CV_JUNSENIOR.Where(a => a.JunSenior == comboJunSenior.Text).FirstOrDefault().IDJunSenior;

                                AllCV = AllCV.Where(a => a.IDJunSenior == junsen).OrderBy(a => a.LastName).ToList();
                            }
                        }
                    }

                    ///2em partie : filtre de AllCV2 par rapport aux critères de recherche dynamics et ajout de AllCV2 dans AllCV if not exist///
                    //C1 et V1//
                    if (!String.IsNullOrEmpty(C1.Text) && !String.IsNullOrEmpty(V1.Text))
                    {
                        if (C1.Text == "Diploma")
                        {
                            var Vdipl = 0;
                            if (soft.CV_DIPLOMA.Where(a => a.Diploma == V1.Text).Count() != 0)
                            {
                                Vdipl = soft.CV_DIPLOMA.Where(a => a.Diploma == V1.Text).FirstOrDefault().IDDiploma;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_EDUC.Where(a => a.IDDiploma == Vdipl && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                        else if (C1.Text == "Language")
                        {
                            var Vlang = 0;

                            if (soft.CV_LANGUAGE.Where(a => a.Language == V1.Text).Count() != 0)
                            {
                                Vlang = soft.CV_LANGUAGE.Where(a => a.Language == V1.Text).FirstOrDefault().IDLanguage;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_WRSP.Where(a => a.IDLanguage == Vlang && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                        else if (C1.Text == "Region")
                        {
                            var Vtr = 0;

                            if (soft.CV_REGION.Where(a => a.Region == V1.Text).Count() != 0)
                            {
                                Vtr = soft.CV_REGION.Where(a => a.Region == V1.Text).FirstOrDefault().IDRegion;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_INTLREGEXP.Where(a => a.IDRegion == Vtr && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                        else if (C1.Text == "Speciality")
                        {
                            var Vspec = 0;

                            if (soft.CV_SPECIALITY.Where(a => a.Speciality == V1.Text).Count() != 0)
                            {
                                Vspec = soft.CV_SPECIALITY.Where(a => a.Speciality == V1.Text).FirstOrDefault().IDSpeciality;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_EDUC.Where(a => a.IDSpeciality == Vspec && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                        else if (C1.Text == "Technical Field")
                        {
                            var Vtf = 0;

                            if (soft.CV_TECHNICFIELD.Where(a => a.TechnicField == V1.Text).Count() != 0)
                            {
                                Vtf = soft.CV_TECHNICFIELD.Where(a => a.TechnicField == V1.Text).FirstOrDefault().IDTechField;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_INTLEXPTECH.Where(a => a.IDTechField == Vtf && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                    }

                    //C2 et V2//
                    if (!String.IsNullOrEmpty(C2.Text) && !String.IsNullOrEmpty(V2.Text))
                    {
                        if (C2.Text == "Diploma")
                        {
                            var Vdipl = 0;
                            if (soft.CV_DIPLOMA.Where(a => a.Diploma == V2.Text).Count() != 0)
                            {
                                Vdipl = soft.CV_DIPLOMA.Where(a => a.Diploma == V2.Text).FirstOrDefault().IDDiploma;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_EDUC.Where(a => a.IDDiploma == Vdipl && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                        else if (C2.Text == "Language")
                        {
                            var Vlang = 0;

                            if (soft.CV_LANGUAGE.Where(a => a.Language == V2.Text).Count() != 0)
                            {
                                Vlang = soft.CV_LANGUAGE.Where(a => a.Language == V2.Text).FirstOrDefault().IDLanguage;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_WRSP.Where(a => a.IDLanguage == Vlang && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                        else if (C2.Text == "Region")
                        {
                            var Vtr = 0;

                            if (soft.CV_REGION.Where(a => a.Region == V2.Text).Count() != 0)
                            {
                                Vtr = soft.CV_REGION.Where(a => a.Region == V2.Text).FirstOrDefault().IDRegion;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_INTLREGEXP.Where(a => a.IDRegion == Vtr && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                        else if (C2.Text == "Speciality")
                        {
                            var Vspec = 0;

                            if (soft.CV_SPECIALITY.Where(a => a.Speciality == V2.Text).Count() != 0)
                            {
                                Vspec = soft.CV_SPECIALITY.Where(a => a.Speciality == V2.Text).FirstOrDefault().IDSpeciality;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_EDUC.Where(a => a.IDSpeciality == Vspec && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                        else if (C2.Text == "Technical Field")
                        {
                            var Vtf = 0;

                            if (soft.CV_TECHNICFIELD.Where(a => a.TechnicField == V2.Text).Count() != 0)
                            {
                                Vtf = soft.CV_TECHNICFIELD.Where(a => a.TechnicField == V2.Text).FirstOrDefault().IDTechField;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_INTLEXPTECH.Where(a => a.IDTechField == Vtf && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                    }

                    //C3 et V3//
                    if (!String.IsNullOrEmpty(C3.Text) && !String.IsNullOrEmpty(V3.Text))
                    {
                        if (C3.Text == "Diploma")
                        {
                            var Vdipl = 0;
                            if (soft.CV_DIPLOMA.Where(a => a.Diploma == V3.Text).Count() != 0)
                            {
                                Vdipl = soft.CV_DIPLOMA.Where(a => a.Diploma == V3.Text).FirstOrDefault().IDDiploma;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_EDUC.Where(a => a.IDDiploma == Vdipl && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                        else if (C3.Text == "Language")
                        {
                            var Vlang = 0;

                            if (soft.CV_LANGUAGE.Where(a => a.Language == V3.Text).Count() != 0)
                            {
                                Vlang = soft.CV_LANGUAGE.Where(a => a.Language == V3.Text).FirstOrDefault().IDLanguage;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_WRSP.Where(a => a.IDLanguage == Vlang && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                        else if (C3.Text == "Region")
                        {
                            var Vtr = 0;

                            if (soft.CV_REGION.Where(a => a.Region == V3.Text).Count() != 0)
                            {
                                Vtr = soft.CV_REGION.Where(a => a.Region == V3.Text).FirstOrDefault().IDRegion;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_INTLREGEXP.Where(a => a.IDRegion == Vtr && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                        else if (C3.Text == "Speciality")
                        {
                            var Vspec = 0;

                            if (soft.CV_SPECIALITY.Where(a => a.Speciality == V3.Text).Count() != 0)
                            {
                                Vspec = soft.CV_SPECIALITY.Where(a => a.Speciality == V3.Text).FirstOrDefault().IDSpeciality;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_EDUC.Where(a => a.IDSpeciality == Vspec && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                        else if (C3.Text == "Technical Field")
                        {
                            var Vtf = 0;

                            if (soft.CV_TECHNICFIELD.Where(a => a.TechnicField == V3.Text).Count() != 0)
                            {
                                Vtf = soft.CV_TECHNICFIELD.Where(a => a.TechnicField == V3.Text).FirstOrDefault().IDTechField;

                                List<CV_CVBASE> filtreCV = new List<CV_CVBASE>();

                                foreach (var x in AllCV)
                                {
                                    if (soft.CV_INTLEXPTECH.Where(a => a.IDTechField == Vtf && a.IDCV == x.IDCV).Count() != 0)
                                    {
                                        filtreCV.Add(x);
                                    }
                                }

                                AllCV = filtreCV;
                            }
                        }
                    }

                    //Grid//
                    if (AllCV.Count() != 0)
                    {
                        foreach (var x in AllCV.ToList())
                        {
                            var isCV = soft.CV_CVBASE.Where(a => a.IDCV == x.IDCV).FirstOrDefault();

                            //TF//
                            int Tsco = 0;
                            int sco = 0;

                            if(soft.CV_INTLEXPTECH.Where(a => a.IDCV == isCV.IDCV).Count() != 0)
                            {
                                foreach(var y in soft.CV_INTLEXPTECH.Where(a => a.IDCV == isCV.IDCV).ToList())
                                {
                                    sco += y.NbYear.Value;
                                }
                            }

                            var isJUNS = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == isCV.IDJunSenior).FirstOrDefault().JunSenior;
                            if (isJUNS.ToUpper().Contains("JUNIOR"))
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
                            else if (isJUNS.ToUpper().Contains("SENIOR"))
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

                            //REG//
                            int TscoR = 0;
                            int scoR = 0;

                            if (soft.CV_INTLREGEXP.Where(a => a.IDCV == isCV.IDCV).Count() != 0)
                            {
                                foreach (var y in soft.CV_INTLREGEXP.Where(a => a.IDCV == isCV.IDCV).ToList())
                                {
                                    scoR += y.NbYear.Value;
                                }
                            }

                            var isJUNSR = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == isCV.IDJunSenior).FirstOrDefault().JunSenior;
                            if (isJUNSR.ToUpper().Contains("JUNIOR"))
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
                            else if (isJUNSR.ToUpper().Contains("SENIOR"))
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

                            //CR//
                            //1//
                            int TscoC1 = 0;
                            int scoC1 = 0;

                            if (soft.CV_NOTECRITERIA.Where(a => a.IDCV == isCV.IDCV).Count() != 0)
                            {
                                var isNo = soft.CV_NOTECRITERIA.Where(a => a.IDCV == isCV.IDCV).FirstOrDefault();
                                scoC1 = isNo.N1.Value;
                            }

                            var isJUNSC1 = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == isCV.IDJunSenior).FirstOrDefault().JunSenior;
                            if (isJUNSC1.ToUpper().Contains("JUNIOR"))
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
                            else if (isJUNSC1.ToUpper().Contains("SENIOR"))
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

                            //2//
                            int TscoC2 = 0;
                            int scoC2 = 0;

                            if (soft.CV_NOTECRITERIA.Where(a => a.IDCV == isCV.IDCV).Count() != 0)
                            {
                                var isNo = soft.CV_NOTECRITERIA.Where(a => a.IDCV == isCV.IDCV).FirstOrDefault();
                                scoC2 = isNo.N2.Value;
                            }

                            var isJUNSC2 = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == isCV.IDJunSenior).FirstOrDefault().JunSenior;
                            if (isJUNSC2.ToUpper().Contains("JUNIOR"))
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
                            else if (isJUNSC2.ToUpper().Contains("SENIOR"))
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

                            //3//
                            int TscoC3 = 0;
                            int scoC3 = 0;

                            if (soft.CV_NOTECRITERIA.Where(a => a.IDCV == isCV.IDCV).Count() != 0)
                            {
                                var isNo = soft.CV_NOTECRITERIA.Where(a => a.IDCV == isCV.IDCV).FirstOrDefault();
                                scoC3 = isNo.N3.Value;
                            }

                            var isJUNSC3 = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == isCV.IDJunSenior).FirstOrDefault().JunSenior;
                            if (isJUNSC3.ToUpper().Contains("JUNIOR"))
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
                            else if (isJUNSC3.ToUpper().Contains("SENIOR"))
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

                            //4//
                            int TscoC4 = 0;
                            int scoC4 = 0;

                            if (soft.CV_NOTECRITERIA.Where(a => a.IDCV == isCV.IDCV).Count() != 0)
                            {
                                var isNo = soft.CV_NOTECRITERIA.Where(a => a.IDCV == isCV.IDCV).FirstOrDefault();
                                scoC4 = isNo.N4.Value;
                            }

                            var isJUNSC4 = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == isCV.IDJunSenior).FirstOrDefault().JunSenior;
                            if (isJUNSC4.ToUpper().Contains("JUNIOR"))
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
                            else if (isJUNSC4.ToUpper().Contains("SENIOR"))
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

                            //5//
                            int TscoC5 = 0;
                            int scoC5 = 0;

                            if (soft.CV_NOTECRITERIA.Where(a => a.IDCV == isCV.IDCV).Count() != 0)
                            {
                                var isNo = soft.CV_NOTECRITERIA.Where(a => a.IDCV == isCV.IDCV).FirstOrDefault();
                                scoC5 = isNo.N5.Value;
                            }

                            var isJUNSC5 = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == isCV.IDJunSenior).FirstOrDefault().JunSenior;
                            if (isJUNSC5.ToUpper().Contains("JUNIOR"))
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
                            else if (isJUNSC5.ToUpper().Contains("SENIOR"))
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

                            int BONUS = 0;
                            if (soft.CV_DOCDATECOMM.Where(a => a.IDCV == isCV.IDCV).Count() != 0)
                            {
                                var isBO = soft.CV_DOCDATECOMM.Where(a => a.IDCV == isCV.IDCV).FirstOrDefault();
                                if(isBO.BONUS != null)
                                    BONUS = soft.CV_DOCDATECOMM.Where(a => a.IDCV == isCV.IDCV).FirstOrDefault().BONUS.Value;
                            }

                            int DIPL = 0;

                            if(soft.CV_EDUC.Where(a => a.IDCV == isCV.IDCV).Count() != 0)
                            {
                                foreach(var y in soft.CV_EDUC.Where(a => a.IDCV == isCV.IDCV).ToList())
                                {
                                    if (soft.CV_DIPLOMA.Where(a => a.IDDiploma == y.IDDiploma).Count() != 0)
                                    {
                                        var isDip = soft.CV_DIPLOMA.Where(a => a.IDDiploma == y.IDDiploma).FirstOrDefault();

                                        if (soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDip.IDDiploma).Count() != 0)
                                        {
                                            var isRank = soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDip.IDDiploma).FirstOrDefault();

                                            var RaNKS = isRank.Rank.Value;

                                            if (RaNKS >= DIPL)
                                                DIPL = RaNKS;
                                        }
                                    }
                                }
                            }

                            int TFI = Tsco;
                            int REG = TscoR;
                            int CR1 = TscoC1;
                            int CR2 = TscoC2;
                            int CR3 = TscoC3;
                            int CR4 = TscoC4;
                            int CR5 = TscoC5;
                            
                            int TOTAL = BONUS + DIPL + TFI + REG + CR1 + CR2 + CR3 + CR4 + CR5;

                            //INSERT TABLE TEMPORAIRE DES IDCVs et NOTES//
                            var newRANK = new CV_TEMPORDERCVRANK
                            {
                                IDCV = isCV.IDCV,
                                RANKS = TOTAL,
                                LASTNAME = isCV.LastName
                            };

                            soft.CV_TEMPORDERCVRANK.Add(newRANK);
                            soft.SaveChanges();
                        }
                    }

                    //DELETE PRINT SEARCH//
                    if (soft.CV_PRINTSEARCH.Count() != 0)
                    {
                        foreach (var x in soft.CV_PRINTSEARCH.ToList())
                        {
                            soft.CV_PRINTSEARCH.Remove(x);
                            soft.SaveChanges();
                        }
                    }

                    if(soft.CV_TEMPORDERCVRANK.Count() != 0)
                    {
                        foreach(var xy in soft.CV_TEMPORDERCVRANK.OrderByDescending(a => a.RANKS).ThenBy(a => a.LASTNAME).ToList())
                        {
                            var x = soft.CV_CVBASE.Where(a => a.IDCV == xy.IDCV).FirstOrDefault();
                            var id = x.IDCV;

                            var stat = "ALIVE";
                            if (x.Sleep==true)
                                stat = "SLEEP";

                            var Lastname = x.LastName;

                            var Firstname = x.FirstName;

                            var catE = "";
                            if (x.IDCat != null && x.IDCat != 0)
                            {
                                var cato = soft.CV_CATEGORY.Where(a => a.IDCat == x.IDCat).FirstOrDefault();

                                catE = cato.Category;
                            }

                            var lang2 = "";
                            if(soft.CV_WRSP.Where(a => a.IDCV == xy.IDCV && a.NUM == 3).Count() != 0)
                            {
                                var islangID = soft.CV_WRSP.Where(a => a.IDCV == xy.IDCV && a.NUM == 3).FirstOrDefault().IDLanguage;
                                lang2 = soft.CV_LANGUAGE.Where(a => a.IDLanguage == islangID).FirstOrDefault().Language;
                            }
                            var lang3 = "";
                            if (soft.CV_WRSP.Where(a => a.IDCV == xy.IDCV && a.NUM == 2).Count() != 0)
                            {
                                var islangID = soft.CV_WRSP.Where(a => a.IDCV == xy.IDCV && a.NUM == 2).FirstOrDefault().IDLanguage;
                                lang3 = soft.CV_LANGUAGE.Where(a => a.IDLanguage == islangID).FirstOrDefault().Language;
                            }
                            var diplo2 = "";
                            if (soft.CV_EDUC.Where(a => a.IDCV == xy.IDCV && a.NUM == 2).Count() != 0)
                            {
                                var iseduc = soft.CV_EDUC.Where(a => a.IDCV == xy.IDCV && a.NUM == 2).FirstOrDefault().IDDiploma;
                                diplo2 = soft.CV_DIPLOMA.Where(a => a.IDDiploma == iseduc).FirstOrDefault().Diploma;
                            }
                            var diplo3 = "";
                            if (soft.CV_EDUC.Where(a => a.IDCV == xy.IDCV && a.NUM == 3).Count() != 0)
                            {
                                var iseduc = soft.CV_EDUC.Where(a => a.IDCV == xy.IDCV && a.NUM == 3).FirstOrDefault().IDDiploma;
                                diplo3 = soft.CV_DIPLOMA.Where(a => a.IDDiploma == iseduc).FirstOrDefault().Diploma;
                            }
                            var spec2 = "";
                            if (soft.CV_EDUC.Where(a => a.IDCV == xy.IDCV && a.NUM == 2).Count() != 0)
                            {
                                var isS = soft.CV_EDUC.Where(a => a.IDCV == xy.IDCV && a.NUM == 2).FirstOrDefault().IDSpeciality;
                                spec2 = soft.CV_SPECIALITY.Where(a => a.IDSpeciality == isS).FirstOrDefault().Speciality;
                            }
                            var spec3 = "";
                            if (soft.CV_EDUC.Where(a => a.IDCV == xy.IDCV && a.NUM == 3).Count() != 0)
                            {
                                var isS = soft.CV_EDUC.Where(a => a.IDCV == xy.IDCV && a.NUM == 3).FirstOrDefault().IDSpeciality;
                                spec3 = soft.CV_SPECIALITY.Where(a => a.IDSpeciality == isS).FirstOrDefault().Speciality;
                            }
                            var R2 = "";
                            if (soft.CV_INTLREGEXP.Where(a => a.IDCV == xy.IDCV && a.NUM == 2).Count() != 0)
                            {
                                var isR = soft.CV_INTLREGEXP.Where(a => a.IDCV == xy.IDCV && a.NUM == 2).FirstOrDefault().IDRegion;
                                R2 = soft.CV_REGION.Where(a => a.IDRegion == isR).FirstOrDefault().Region;
                            }
                            var R3 = "";
                            if (soft.CV_INTLREGEXP.Where(a => a.IDCV == xy.IDCV && a.NUM == 3).Count() != 0)
                            {
                                var isR = soft.CV_INTLREGEXP.Where(a => a.IDCV == xy.IDCV && a.NUM == 3).FirstOrDefault().IDRegion;
                                R3 = soft.CV_REGION.Where(a => a.IDRegion == isR).FirstOrDefault().Region;
                            }

                            var natiO = "";
                            if (soft.CV_NATIONS.Where(a => a.IDCountry == x.IDNationality).Count() != 0)
                            {
                                var isnatiO = soft.CV_NATIONS.Where(a => a.IDCountry == x.IDNationality).FirstOrDefault();
                                natiO = isnatiO.Country;
                            }

                            var levaka = "";
                            if (soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == x.IDJunSenior).Count() != 0)
                            {
                                var isLEvaka = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == x.IDJunSenior).FirstOrDefault();
                                levaka = isLEvaka.JunSenior;
                            }

                            table.Rows.Add(stat, xy.RANKS, catE, Firstname, Lastname, lang2, lang3, diplo2, spec2, diplo3, spec3, R2, R3);

                            stringList.Add(Lastname);

                            var insertNEw = new CV_PRINTSEARCH
                            {
                                N_STAT = stat,
                                N_RANK = xy.RANKS.Value.ToString(),
                                N_CAT = catE,
                                N_LAST = Lastname,
                                N_FIRST = Firstname,
                                /*N_LANG2 = lang2,
                                N_LANG3 = lang3,
                                N_DIP2 = diplo2,
                                N_DIP3 = diplo3,
                                N_SP2 = spec2,
                                N_SP3 = spec3,
                                
                                N_R2 = R2,
                                N_R3 = R3,*/
                                N_NATIONAL = natiO,
                                N_LEVEL = levaka,

                                //SINGLE INFORMATION//
                                CAT = comboCat.Text,
                                TECHFIELD = comboTechField.Text,
                                JUNSEN = comboJunSenior.Text,
                                DIPL = comboDipl.Text,
                                SPEC = comboSpecDipl.Text,
                                LANG = comboLang.Text,
                                REGION = comboRegion.Text,
                                GENDER = comboGender.Text,
                                NATION = comboNationality.Text,
                                CR1 = C1.Text,
                                CR2 = C2.Text,
                                CR3 = C3.Text,
                                V1 = V1.Text,
                                V2 = V2.Text,
                                V3 = V3.Text
                            };

                            soft.CV_PRINTSEARCH.Add(insertNEw);
                            soft.SaveChanges();

                            i++;
                        }
                    }
                }

                Token.setLST(stringList);
                textBox1.Text = i.ToString();

                if(soft.CV_PRINTSEARCH.Count() != 0)
                {
                    foreach (var x in soft.CV_PRINTSEARCH.ToList())
                    {
                        x.FOUND = i.ToString();

                        soft.SaveChanges();
                    }
                }

                gridListe.DataSource = table;
             
                if(soft.CV_TEMPORDERCVRANK.Count() != 0)
                {
                    foreach(var x in soft.CV_TEMPORDERCVRANK.ToList())
                    {
                        soft.CV_TEMPORDERCVRANK.Remove(x);
                        soft.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Frm_Search_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (checkBox1.Checked == false)
                {
                    if (soft.CV_SAVESEARCH.Count() != 0)
                    {
                        var isForDelete = soft.CV_SAVESEARCH.FirstOrDefault();

                        soft.CV_SAVESEARCH.Remove(isForDelete);
                        soft.SaveChanges();
                    }
                }
                else
                {
                    if (soft.CV_SAVESEARCH.Count() == 0)
                    {
                        var forInsert = new CV_SAVESEARCH
                        {
                            Cat = comboCat.Text,
                            Language = comboLang.Text,
                            TechField = comboTechField.Text,
                            Diploma = comboDipl.Text,
                            Speciality = comboSpecDipl.Text,
                            Region = comboRegion.Text,
                            Gender = comboGender.Text,
                            Nationality = comboNationality.Text,
                            JUNSEN = comboJunSenior.Text,
                            C1 = C1.Text,
                            C2 = C2.Text,
                            C3 = C3.Text,
                            V1 = V1.Text,
                            V2 = V2.Text,
                            V3 = V3.Text
                        };
                        soft.CV_SAVESEARCH.Add(forInsert);
                        soft.SaveChanges();
                    }
                    else
                    {
                        var forModif = soft.CV_SAVESEARCH.FirstOrDefault();

                        forModif.Cat = comboCat.Text;
                        forModif.Language = comboLang.Text;
                        forModif.TechField = comboTechField.Text;
                        forModif.Diploma = comboDipl.Text;
                        forModif.Speciality = comboSpecDipl.Text;
                        forModif.Region = comboRegion.Text;
                        forModif.Gender = comboGender.Text;
                        forModif.Nationality = comboNationality.Text;
                        forModif.JUNSEN = comboJunSenior.Text;
                        forModif.C1 = C1.Text;
                        forModif.C2 = C2.Text;
                        forModif.C3 = C3.Text;
                        forModif.V1 = V1.Text;
                        forModif.V2 = V2.Text;
                        forModif.V3 = V3.Text;

                        soft.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gridListe.Rows.Count != 0)
            {
                Frm_PrintSearch frm = new Frm_PrintSearch();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Nothing to print!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void gridListe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var name = gridListe.CurrentRow.Cells[4].Value.ToString();

                if (!String.IsNullOrEmpty(name))
                {
                    Frm_cvadd frm = new Frm_cvadd();

                    frm.textPrenom.Focus();
                    /*frm.buttonSave.Enabled = true;
                    frm.buttonNext.Enabled = true;
                    frm.buttonPrevious.Enabled = true;*/

                    frm.InitialCVNEW();
                    frm.DetailsCV(name);

                    //Liste et recherche par liste des recherches//
                    frm.checkNoteGlobal.Checked = true;

                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
