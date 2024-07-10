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
    public partial class Frm_DATAWH : Form
    {
        public Frm_DATAWH()
        {
            InitializeComponent();

            remplir();
            comboTa.Focus();

            if (Token.getAUTHO() == true)
            {
                ajout.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void comboTa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void remplir()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                DataTable table = new DataTable();
                table.Columns.Clear();

                table.Columns.Add("ID");
                table.Columns.Add("Value");

                table.Rows.Clear();

                //CATEGORY//
                if (comboTa.Text == "CATEGORY")
                {
                    if (soft.CV_CATEGORY.Count() != 0)
                    {
                        foreach (var x in soft.CV_CATEGORY.OrderBy(a => a.Category).ToList())
                            table.Rows.Add(x.IDCat,x.Category);
                    }
                }

                //CLIENT//
                if (comboTa.Text == "CLIENT")
                {
                    if (soft.CV_CLIENT.Count() != 0)
                    {
                        foreach (var x in soft.CV_CLIENT.OrderBy(a => a.Client).ToList())
                            table.Rows.Add(x.IDClient,x.Client);
                    }
                }

                //DIPLOMA//
                if (comboTa.Text == "DIPLOMA")
                {
                    if (soft.CV_DIPLOMA.Count() != 0)
                    {
                        foreach (var x in soft.CV_DIPLOMA.OrderBy(a => a.Diploma).ToList())
                            table.Rows.Add(x.IDDiploma,x.Diploma);
                    }
                }

                //DOCUMENT//
                if (comboTa.Text == "DOCUMENT")
                {
                    if (soft.CV_DOCUMENT.Count() != 0)
                    {
                        foreach (var x in soft.CV_DOCUMENT.OrderBy(a => a.Docum).ToList())
                            table.Rows.Add(x.IDDoc,x.Docum);
                    }
                }

                //EMPLOYEE//
                if (comboTa.Text == "EMPLOYEE")
                {
                    if (soft.CV_EMPLOYEE.Count() != 0)
                    {
                        foreach (var x in soft.CV_EMPLOYEE.OrderBy(a => a.PersRef).ToList())
                            table.Rows.Add(x.IDPersRef,x.PersRef);
                    }
                }

                //GENDER//
                if (comboTa.Text == "GENDER")
                {
                    if (soft.CV_GENDER.Count() != 0)
                    {
                        foreach (var x in soft.CV_GENDER.OrderBy(a => a.Gender).ToList())
                            table.Rows.Add(x.IDGender,x.Gender);
                    }
                }

                //GRADUATION//
                if (comboTa.Text == "GRADUATION")
                {
                    if (soft.CV_GRADUATE.Count() != 0)
                    {
                        foreach (var x in soft.CV_GRADUATE.OrderBy(a => a.Graduate).ToList())
                            table.Rows.Add(x.IDGraduate,x.Graduate);
                    }
                }

                //LANGUAGE//
                if (comboTa.Text == "LANGUAGE")
                {
                    if (soft.CV_LANGUAGE.Count() != 0)
                    {
                        foreach (var x in soft.CV_LANGUAGE.OrderBy(a => a.Language).ToList())
                            table.Rows.Add(x.IDLanguage,x.Language);
                    }
                }

                //NATION//
                if (comboTa.Text == "NATION")
                {
                    if (soft.CV_NATIONS.Count() != 0)
                    {
                        foreach (var x in soft.CV_NATIONS.OrderBy(a => a.Country).ToList())
                            table.Rows.Add(x.IDCountry,x.Country);
                    }
                }

                //TOWN//
                if (comboTa.Text == "TOWN")
                {
                    if (soft.CV_TOWNS.Count() != 0)
                    {
                        foreach (var x in soft.CV_TOWNS.OrderBy(a => a.TOWN).ToList())
                            table.Rows.Add(x.ID, x.TOWN);
                    }
                }

                //REGION//
                if (comboTa.Text == "REGION")
                {
                    if (soft.CV_REGION.Count() != 0)
                    {
                        foreach (var x in soft.CV_REGION.OrderBy(a => a.Region).ToList())
                            table.Rows.Add(x.IDRegion,x.Region);
                    }
                }

                //ROLE//
                if (comboTa.Text == "ROLE")
                {
                    if (soft.CV_ROLE.Count() != 0)
                    {
                        foreach (var x in soft.CV_ROLE.OrderBy(a => a.Role).ToList())
                            table.Rows.Add(x.IDRole,x.Role);
                    }
                }

                //SPECIALITY//
                if (comboTa.Text == "SPECIALITY")
                {
                    if (soft.CV_SPECIALITY.Count() != 0)
                    {
                        foreach (var x in soft.CV_SPECIALITY.OrderBy(a => a.Speciality).ToList())
                            table.Rows.Add(x.IDSpeciality,x.Speciality);
                    }
                }

                //SCHI UNIT//
                if (comboTa.Text == "SCIH UNIT")
                {
                    if (soft.CV_UNIT.Count() != 0)
                    {
                        foreach (var x in soft.CV_UNIT.OrderBy(a => a.Unit).ToList())
                            table.Rows.Add(x.IDSCIHUnit,x.Unit);
                    }
                }

                //LANGUAGE LEVEL//
                if (comboTa.Text == "LANGUAGE LEVEL")
                {
                    if (soft.CV_WRSPLEVEL.Count() != 0)
                    {
                        foreach (var x in soft.CV_WRSPLEVEL.OrderBy(a => a.WrSp).ToList())
                            table.Rows.Add(x.IDWrSp,x.WrSp);
                    }
                }

                //APPRECIATION//
                if (comboTa.Text == "APPRECIATION")
                {
                    if (soft.CV_GAPPREC.Count() != 0)
                    {
                        foreach (var x in soft.CV_GAPPREC.OrderBy(a => a.GApprec).ToList())
                            table.Rows.Add(x.IDGApprec, x.GApprec);
                    }
                }

                //TEST//
                if (comboTa.Text == "TEST")
                {
                    if (soft.CV_TEST.Count() != 0)
                    {
                        foreach (var x in soft.CV_TEST.OrderBy(a => a.Test).ToList())
                            table.Rows.Add(x.IDTest, x.Test);
                    }
                }

                //EPROFIL PLATFORM//
                if (comboTa.Text == "EPROFIL PLATFORM")
                {
                    if (soft.CV_EPROFIL.Count() != 0)
                    {
                        foreach (var x in soft.CV_EPROFIL.OrderBy(a => a.EProfile).ToList())
                            table.Rows.Add(x.IDEProf, x.EProfile);
                    }
                }

                //ONLINE CHAT PLATFORM//
                if (comboTa.Text == "ONLINE CHAT PLATFORM")
                {
                    if (soft.CV_ONCHATPLAT.Count() != 0)
                    {
                        foreach (var x in soft.CV_ONCHATPLAT.OrderBy(a => a.OnlineChat).ToList())
                            table.Rows.Add(x.IDChat, x.OnlineChat);
                    }
                }

                //PLACE//
                if (comboTa.Text == "PLACE")
                {
                    if (soft.CV_PLACE.Count() != 0)
                    {
                        foreach (var x in soft.CV_PLACE.OrderBy(a => a.Place).ToList())
                            table.Rows.Add(x.IDPlace, x.Place);
                    }
                }

                //LEVEL//
                if (comboTa.Text == "LEVEL")
                {
                    if (soft.CV_JUNSENIOR.Count() != 0)
                    {
                        foreach (var x in soft.CV_JUNSENIOR.OrderBy(a => a.JunSenior).ToList())
                            table.Rows.Add(x.IDJunSenior, x.JunSenior);
                    }
                }

                //TECHNICAL FIELD//
                if (comboTa.Text == "TECHNICAL FIELD")
                {
                    if (soft.CV_TECHNICFIELD.Count() != 0)
                    {
                        foreach (var x in soft.CV_TECHNICFIELD.OrderBy(a => a.TechnicField).ToList())
                            table.Rows.Add(x.IDTechField, x.TechnicField);
                    }
                }

                gridliste.DataSource = table;

                gridliste.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboTa_Validated(object sender, EventArgs e)
        {
            remplir();

            textVal.Text = null;
        }

        private void ajout_Click(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (!String.IsNullOrEmpty(comboTa.Text))
                {
                    if (!String.IsNullOrEmpty(textVal.Text))
                    {
                        //CATEGORY//
                        if (comboTa.Text == "CATEGORY")
                        {
                            if (soft.CV_CATEGORY.Where(a => a.Category.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_CATEGORY
                                {
                                    Category = textVal.Text,
                                    ISOK = false
                                };

                                soft.CV_CATEGORY.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Category already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //CLIENT//
                        if (comboTa.Text == "CLIENT")
                        {
                            if (soft.CV_CLIENT.Where(a => a.Client.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_CLIENT
                                {
                                    Client = textVal.Text
                                };

                                soft.CV_CLIENT.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Client already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //DIPLOMA//
                        if (comboTa.Text == "DIPLOMA")
                        {
                            if (soft.CV_DIPLOMA.Where(a => a.Diploma.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_DIPLOMA
                                {
                                    Diploma = textVal.Text
                                };

                                soft.CV_DIPLOMA.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Diploma already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //DOCUMENT//
                        if (comboTa.Text == "DOCUMENT")
                        {
                            if (textVal.Text.ToLower() != "data retention authorisation")
                            {
                                if (soft.CV_DOCUMENT.Where(a => a.Docum.ToLower() == textVal.Text.ToLower()).Count() == 0)
                                {
                                    var newInsert = new CV_DOCUMENT
                                    {
                                        Docum = textVal.Text
                                    };

                                    soft.CV_DOCUMENT.Add(newInsert);
                                    soft.SaveChanges();


                                    var w = new Form() { Size = new Size(0, 0) };
                                    Task.Delay(TimeSpan.FromSeconds(1))
                                        .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                    //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                    remplir();
                                }
                                else
                                    MessageBox.Show("Document already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                MessageBox.Show("You can't add this document (Document 6)", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //EMPLOYEE//
                        if (comboTa.Text == "EMPLOYEE")
                        {
                            if (soft.CV_EMPLOYEE.Where(a => a.PersRef.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_EMPLOYEE
                                {
                                    PersRef = textVal.Text
                                };

                                soft.CV_EMPLOYEE.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Employee already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //GENDER//
                        if (comboTa.Text == "GENDER")
                        {
                            if (soft.CV_GENDER.Where(a => a.Gender.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_GENDER
                                {
                                    Gender = textVal.Text
                                };

                                soft.CV_GENDER.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Gender already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //GRADUATION//
                        if (comboTa.Text == "GRADUATION")
                        {
                            if (soft.CV_GRADUATE.Where(a => a.Graduate.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_GRADUATE
                                {
                                    Graduate = textVal.Text
                                };

                                soft.CV_GRADUATE.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Graduation already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //LANGUAGE//
                        if (comboTa.Text == "LANGUAGE")
                        {
                            if (soft.CV_LANGUAGE.Where(a => a.Language.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_LANGUAGE
                                {
                                    Language = textVal.Text
                                };

                                soft.CV_LANGUAGE.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Language already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //NATION//
                        if (comboTa.Text == "NATION")
                        {
                            if (soft.CV_NATIONS.Where(a => a.Country.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_NATIONS
                                {
                                    Country = textVal.Text
                                };

                                soft.CV_NATIONS.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Nation already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //TOWN//
                        if (comboTa.Text == "TOWN")
                        {
                            if (soft.CV_TOWNS.Where(a => a.TOWN.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_TOWNS
                                {
                                    TOWN = textVal.Text
                                };

                                soft.CV_TOWNS.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Town already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //REGION//
                        if (comboTa.Text == "REGION")
                        {
                            if (soft.CV_REGION.Where(a => a.Region.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_REGION
                                {
                                    Region = textVal.Text
                                };

                                soft.CV_REGION.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Region already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //ROLE//
                        if (comboTa.Text == "ROLE")
                        {
                            if (soft.CV_ROLE.Where(a => a.Role.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_ROLE
                                {
                                    Role = textVal.Text
                                };

                                soft.CV_ROLE.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Role already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //SPECIALITY//
                        if (comboTa.Text == "SPECIALITY")
                        {
                            if (soft.CV_SPECIALITY.Where(a => a.Speciality.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_SPECIALITY
                                {
                                    Speciality = textVal.Text
                                };

                                soft.CV_SPECIALITY.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Speciality already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //SCHI UNIT//
                        if (comboTa.Text == "SCIH UNIT")
                        {
                            if (soft.CV_UNIT.Where(a => a.Unit.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_UNIT
                                {
                                    Unit = textVal.Text
                                };

                                soft.CV_UNIT.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("SCIH Unit already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //LANGUAGE LEVEL//
                        if (comboTa.Text == "LANGUAGE LEVEL")
                        {
                            if (soft.CV_WRSPLEVEL.Where(a => a.WrSp.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_WRSPLEVEL
                                {
                                    WrSp = textVal.Text
                                };

                                soft.CV_WRSPLEVEL.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Language level already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //APPRECIATION//
                        if (comboTa.Text == "APPRECIATION")
                        {
                            if (soft.CV_GAPPREC.Where(a => a.GApprec.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_GAPPREC
                                {
                                    GApprec = textVal.Text
                                };

                                soft.CV_GAPPREC.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Appreciation already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //TEST//
                        if (comboTa.Text == "TEST")
                        {
                            if (soft.CV_TEST.Where(a => a.Test.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_TEST
                                {
                                    Test = textVal.Text
                                };

                                soft.CV_TEST.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Test résult already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //EPROFIL PLATFORM//
                        if (comboTa.Text == "EPROFIL PLATFORM")
                        {
                            if (soft.CV_EPROFIL.Where(a => a.EProfile.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_EPROFIL
                                {
                                    EProfile = textVal.Text
                                };

                                soft.CV_EPROFIL.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("eProfil plateform already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //ONLINE CHAT PLATFORM//
                        if (comboTa.Text == "ONLINE CHAT PLATFORM")
                        {
                            if (soft.CV_ONCHATPLAT.Where(a => a.OnlineChat.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_ONCHATPLAT
                                {
                                    OnlineChat = textVal.Text
                                };

                                soft.CV_ONCHATPLAT.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Online chat plateform already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //PLACE//
                        if (comboTa.Text == "PLACE")
                        {
                            if (soft.CV_PLACE.Where(a => a.Place.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_PLACE
                                {
                                    Place = textVal.Text
                                };

                                soft.CV_PLACE.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Place already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //LEVEL//
                        if (comboTa.Text == "LEVEL")
                        {
                            if (textVal.Text.ToUpper() != "JUNIOR" && textVal.Text.ToUpper() != "SENIOR")
                            {
                                if (soft.CV_JUNSENIOR.Where(a => a.JunSenior.ToLower() == textVal.Text.ToLower()).Count() == 0)
                                {
                                    var newInsert = new CV_JUNSENIOR
                                    {
                                        JunSenior = textVal.Text
                                    };

                                    soft.CV_JUNSENIOR.Add(newInsert);
                                    soft.SaveChanges();


                                    var w = new Form() { Size = new Size(0, 0) };
                                    Task.Delay(TimeSpan.FromSeconds(1))
                                        .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                    //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                    remplir();
                                }
                                else
                                    MessageBox.Show("Level already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                MessageBox.Show("You can't add this Level", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //TECHNICAL FIELD//
                        if (comboTa.Text == "TECHNICAL FIELD")
                        {
                            if (soft.CV_TECHNICFIELD.Where(a => a.TechnicField.ToLower() == textVal.Text.ToLower()).Count() == 0)
                            {
                                var newInsert = new CV_TECHNICFIELD
                                {
                                    TechnicField = textVal.Text
                                };

                                soft.CV_TECHNICFIELD.Add(newInsert);
                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                            else
                                MessageBox.Show("Technical field already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Please fill the value", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Please select TABLE", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (!String.IsNullOrEmpty(comboTa.Text))
                {
                    int GridSelect = 0;
                    bool result = int.TryParse(gridliste.CurrentRow.Cells[0].Value.ToString(), out GridSelect);

                    if (result)
                    {
                        GridSelect = int.Parse(gridliste.CurrentRow.Cells[0].Value.ToString());

                        if (!String.IsNullOrEmpty(textVal.Text))
                        {
                            //CATEGORY//
                            if (comboTa.Text == "CATEGORY")
                            {
                                var modif = soft.CV_CATEGORY.Where(a => a.IDCat == GridSelect).FirstOrDefault();

                                modif.Category = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //CLIENT//
                            if (comboTa.Text == "CLIENT")
                            {
                                var modif = soft.CV_CLIENT.Where(a => a.IDClient == GridSelect).FirstOrDefault();

                                modif.Client = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //DIPLOMA//
                            if (comboTa.Text == "DIPLOMA")
                            {
                                var modif = soft.CV_DIPLOMA.Where(a => a.IDDiploma == GridSelect).FirstOrDefault();

                                modif.Diploma = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //DOCUMENT//
                            if (comboTa.Text == "DOCUMENT")
                            {
                                var modif = soft.CV_DOCUMENT.Where(a => a.IDDoc == GridSelect).FirstOrDefault();
                                var isDoc6 = soft.CV_DOCUMENT.Where(a => a.Docum == "Data retention authorisation").FirstOrDefault().IDDoc;

                                if(modif.IDDoc != isDoc6)
                                {
                                    modif.Docum = textVal.Text;

                                    soft.SaveChanges();


                                    var w = new Form() { Size = new Size(0, 0) };
                                    Task.Delay(TimeSpan.FromSeconds(1))
                                        .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                    //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                    remplir();
                                }
                                else
                                    MessageBox.Show("You can't change the value of the Document 6", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            //EMPLOYEE//
                            if (comboTa.Text == "EMPLOYEE")
                            {
                                var modif = soft.CV_EMPLOYEE.Where(a => a.IDPersRef == GridSelect).FirstOrDefault();

                                modif.PersRef = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //GENDER//
                            if (comboTa.Text == "GENDER")
                            {
                                var modif = soft.CV_GENDER.Where(a => a.IDGender == GridSelect).FirstOrDefault();

                                modif.Gender = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //GRADUATION//
                            if (comboTa.Text == "GRADUATION")
                            {
                                var modif = soft.CV_GRADUATE.Where(a => a.IDGraduate == GridSelect).FirstOrDefault();

                                modif.Graduate = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //LANGUAGE//
                            if (comboTa.Text == "LANGUAGE")
                            {
                                var modif = soft.CV_LANGUAGE.Where(a => a.IDLanguage == GridSelect).FirstOrDefault();

                                modif.Language = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //NATION//
                            if (comboTa.Text == "NATION")
                            {
                                var modif = soft.CV_NATIONS.Where(a => a.IDCountry == GridSelect).FirstOrDefault();

                                modif.Country = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //TOWN//
                            if (comboTa.Text == "TOWN")
                            {
                                var modif = soft.CV_TOWNS.Where(a => a.ID == GridSelect).FirstOrDefault();

                                modif.TOWN = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //REGION//
                            if (comboTa.Text == "REGION")
                            {
                                var modif = soft.CV_REGION.Where(a => a.IDRegion == GridSelect).FirstOrDefault();

                                modif.Region = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //ROLE//
                            if (comboTa.Text == "ROLE")
                            {
                                var modif = soft.CV_ROLE.Where(a => a.IDRole == GridSelect).FirstOrDefault();

                                modif.Role = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //SPECIALITY//
                            if (comboTa.Text == "SPECIALITY")
                            {
                                var modif = soft.CV_SPECIALITY.Where(a => a.IDSpeciality == GridSelect).FirstOrDefault();

                                modif.Speciality = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //SCHI UNIT//
                            if (comboTa.Text == "SCIH UNIT")
                            {
                                var modif = soft.CV_UNIT.Where(a => a.IDSCIHUnit == GridSelect).FirstOrDefault();

                                modif.Unit = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //LANGUAGE LEVEL//
                            if (comboTa.Text == "LANGUAGE LEVEL")
                            {
                                var modif = soft.CV_WRSPLEVEL.Where(a => a.IDWrSp == GridSelect).FirstOrDefault();

                                modif.WrSp = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //APPRECIATION//
                            if (comboTa.Text == "APPRECIATION")
                            {
                                var modif = soft.CV_GAPPREC.Where(a => a.IDGApprec == GridSelect).FirstOrDefault();

                                modif.GApprec = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //TEST//
                            if (comboTa.Text == "TEST")
                            {
                                var modif = soft.CV_TEST.Where(a => a.IDTest == GridSelect).FirstOrDefault();

                                modif.Test = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //EPROFIL PLATFORM//
                            if (comboTa.Text == "EPROFIL PLATFORM")
                            {
                                var modif = soft.CV_EPROFIL.Where(a => a.IDEProf == GridSelect).FirstOrDefault();

                                modif.EProfile = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //ONLINE CHAT PLATFORM//
                            if (comboTa.Text == "ONLINE CHAT PLATFORM")
                            {
                                var modif = soft.CV_ONCHATPLAT.Where(a => a.IDChat == GridSelect).FirstOrDefault();

                                modif.OnlineChat = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //PLACE//
                            if (comboTa.Text == "PLACE")
                            {
                                var modif = soft.CV_PLACE.Where(a => a.IDPlace == GridSelect).FirstOrDefault();

                                modif.Place = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }

                            //LEVEL//
                            if (comboTa.Text == "LEVEL")
                            {
                                var modif = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == GridSelect).FirstOrDefault();
                                var idJUN = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "Junior").FirstOrDefault().IDJunSenior;
                                var idSEN = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "Senior").FirstOrDefault().IDJunSenior;

                                if(modif.IDJunSenior != idJUN && modif.IDJunSenior != idSEN)
                                {
                                    modif.JunSenior = textVal.Text;

                                    soft.SaveChanges();


                                    var w = new Form() { Size = new Size(0, 0) };
                                    Task.Delay(TimeSpan.FromSeconds(1))
                                        .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                    //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                    remplir();
                                }
                                else
                                    MessageBox.Show("You can't change the value of Junior and Senior", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            //TECHNICAL FIELD//
                            if (comboTa.Text == "TECHNICAL FIELD")
                            {
                                var modif = soft.CV_TECHNICFIELD.Where(a => a.IDTechField == GridSelect).FirstOrDefault();

                                modif.TechnicField = textVal.Text;

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }
                        else
                            MessageBox.Show("Please fill the value", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Select item before edit", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Please select TABLE", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void gridliste_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textVal.Text = gridliste.CurrentRow.Cells[1].Value.ToString();
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
                DbCVBASE soft = new DbCVBASE();

                int GridSelect = 0;
                bool result = int.TryParse(gridliste.CurrentRow.Cells[0].Value.ToString(), out GridSelect);

                if (result)
                {
                    GridSelect = int.Parse(gridliste.CurrentRow.Cells[0].Value.ToString());

                    string message = "You are going to permanently delete the " + comboTa.Text + " : \"" + textVal.Text + " \"";
                    string caption = "CVBASE";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult resultA;

                    // Displays the MessageBox.
                    resultA = MessageBox.Show(message, caption, buttons);

                    if (resultA == System.Windows.Forms.DialogResult.Yes)
                    {
                        //CATEGORY//
                        if (comboTa.Text == "CATEGORY")
                        {
                            var del = soft.CV_CATEGORY.Where(a => a.IDCat == GridSelect).FirstOrDefault();

                            if (soft.CV_CVBASE.Where(a => a.IDCat == del.IDCat).Count() != 0 || soft.CV_VISITSPMU.Where(a => a.IDCategory == del.IDCat).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_CATEGORY.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //CLIENT//
                        if (comboTa.Text == "CLIENT")
                        {
                            var del = soft.CV_CLIENT.Where(a => a.IDClient == GridSelect).FirstOrDefault();

                            if (soft.CV_EXPSWTPH.Where(a => a.IDClient == del.IDClient).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_CLIENT.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //DIPLOMA//
                        if (comboTa.Text == "DIPLOMA")
                        {
                            var del = soft.CV_DIPLOMA.Where(a => a.IDDiploma == GridSelect).FirstOrDefault();

                            if (soft.CV_EDUC.Where(a => a.IDDiploma == del.IDDiploma).Count() != 0 || soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == del.IDDiploma).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_DIPLOMA.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //DOCUMENT//
                        if (comboTa.Text == "DOCUMENT")
                        {
                            var del = soft.CV_DOCUMENT.Where(a => a.IDDoc == GridSelect).FirstOrDefault();
                            var isDoc6 = soft.CV_DOCUMENT.Where(a => a.Docum == "Data retention authorisation").FirstOrDefault().IDDoc;

                            if (soft.CV_DOC.Where(a => a.IDDoc == del.IDDoc).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (del.IDDoc != isDoc6)
                                {
                                    soft.CV_DOCUMENT.Remove(del);

                                    soft.SaveChanges();


                                    var w = new Form() { Size = new Size(0, 0) };
                                    Task.Delay(TimeSpan.FromSeconds(1))
                                        .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                    //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                    remplir();
                                }
                                else
                                    MessageBox.Show("You can't delete the Document 6", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        //EMPLOYEE//
                        if (comboTa.Text == "EMPLOYEE")
                        {
                            var del = soft.CV_EMPLOYEE.Where(a => a.IDPersRef == GridSelect).FirstOrDefault();
                            if (soft.CV_CVBASE.Where(a => a.IDPersRef == del.IDPersRef).Count() != 0 || soft.CV_EXPSWTPH.Where(a => a.IDPersRef == del.IDPersRef).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_EMPLOYEE.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //GENDER//
                        if (comboTa.Text == "GENDER")
                        {
                            var del = soft.CV_GENDER.Where(a => a.IDGender == GridSelect).FirstOrDefault();

                            if (soft.CV_CVBASE.Where(a => a.IDGender == del.IDGender).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_GENDER.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //GRADUATION//
                        if (comboTa.Text == "GRADUATION")
                        {
                            var del = soft.CV_GRADUATE.Where(a => a.IDGraduate == GridSelect).FirstOrDefault();

                            if (soft.CV_GRAD.Where(a => a.IDGraduate == del.IDGraduate).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_GRADUATE.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //LANGUAGE//
                        if (comboTa.Text == "LANGUAGE")
                        {
                            var del = soft.CV_LANGUAGE.Where(a => a.IDLanguage == GridSelect).FirstOrDefault();

                            if (soft.CV_EXPSWTPH.Where(a => a.IDLanguage == del.IDLanguage).Count() != 0 || soft.CV_WRSP.Where(a => a.IDLanguage == del.IDLanguage).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_LANGUAGE.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //NATION//
                        if (comboTa.Text == "NATION")
                        {
                            var del = soft.CV_NATIONS.Where(a => a.IDCountry == GridSelect).FirstOrDefault();

                            if (soft.CV_CVBASE.Where(a => a.IDCountry == del.IDCountry).Count() != 0 || soft.CV_EXPSWTPH.Where(a => a.IDCountry == del.IDCountry).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_NATIONS.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //TOWN//
                        if (comboTa.Text == "TOWN")
                        {
                            var del = soft.CV_TOWNS.Where(a => a.ID == GridSelect).FirstOrDefault();

                            if (soft.CV_CVBASE.Where(a => a.IDTOWN == del.ID).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_TOWNS.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //REGION//
                        if (comboTa.Text == "REGION")
                        {
                            var del = soft.CV_REGION.Where(a => a.IDRegion == GridSelect).FirstOrDefault();
                            if (soft.CV_INTLREGEXP.Where(a => a.IDRegion == del.IDRegion).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_REGION.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //ROLE//
                        if (comboTa.Text == "ROLE")
                        {
                            var del = soft.CV_ROLE.Where(a => a.IDRole == GridSelect).FirstOrDefault();

                            if (soft.CV_EXPSWTPH.Where(a => a.IDRole == del.IDRole).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_ROLE.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //SPECIALITY//
                        if (comboTa.Text == "SPECIALITY")
                        {
                            var del = soft.CV_SPECIALITY.Where(a => a.IDSpeciality == GridSelect).FirstOrDefault();

                            if (soft.CV_EDUC.Where(a => a.IDSpeciality == del.IDSpeciality).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_SPECIALITY.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //SCHI UNIT//
                        if (comboTa.Text == "SCIH UNIT")
                        {
                            var del = soft.CV_UNIT.Where(a => a.IDSCIHUnit == GridSelect).FirstOrDefault();

                            if (soft.CV_EXPSWTPH.Where(a => a.IDSCIHUnit == del.IDSCIHUnit).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_UNIT.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //LANGUAGE LEVEL//
                        if (comboTa.Text == "LANGUAGE LEVEL")
                        {
                            var del = soft.CV_WRSPLEVEL.Where(a => a.IDWrSp == GridSelect).FirstOrDefault();

                            if (soft.CV_WRSP.Where(a => a.IDWr == del.IDWrSp).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_WRSPLEVEL.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //APPRECIATION//
                        if (comboTa.Text == "APPRECIATION")
                        {
                            var del = soft.CV_GAPPREC.Where(a => a.IDGApprec == GridSelect).FirstOrDefault();

                            if (soft.CV_VISITSPMU.Where(a => a.IDGApprec == del.IDGApprec).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_GAPPREC.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //TEST//
                        if (comboTa.Text == "TEST")
                        {
                            var del = soft.CV_TEST.Where(a => a.IDTest == GridSelect).FirstOrDefault();

                            soft.CV_TEST.Remove(del);

                            soft.SaveChanges();


                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                            remplir();
                        }

                        //EPROFIL PLATFORM//
                        if (comboTa.Text == "EPROFIL PLATFORM")
                        {
                            var del = soft.CV_EPROFIL.Where(a => a.IDEProf == GridSelect).FirstOrDefault();

                            if (soft.CV_EPRO.Where(a => a.IDEProf == del.IDEProf).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_EPROFIL.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //ONLINE CHAT PLATFORM//
                        if (comboTa.Text == "ONLINE CHAT PLATFORM")
                        {
                            var del = soft.CV_ONCHATPLAT.Where(a => a.IDChat == GridSelect).FirstOrDefault();

                            if (soft.CV_ONCHAT.Where(a => a.IDChat == del.IDChat).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_ONCHATPLAT.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //PLACE//
                        if (comboTa.Text == "PLACE")
                        {
                            var del = soft.CV_PLACE.Where(a => a.IDPlace == GridSelect).FirstOrDefault();

                            if (soft.CV_EDUC.Where(a => a.IDPlace == del.IDPlace).Count() != 0 || soft.CV_GRAD.Where(a => a.IDPlace == del.IDPlace).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_PLACE.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        //LEVEL//
                        if (comboTa.Text == "LEVEL")
                        {
                            var del = soft.CV_JUNSENIOR.Where(a => a.IDJunSenior == GridSelect).FirstOrDefault();
                            var idJUN = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "Junior").FirstOrDefault().IDJunSenior;
                            var idSEN = soft.CV_JUNSENIOR.Where(a => a.JunSenior == "Senior").FirstOrDefault().IDJunSenior;

                            if (soft.CV_EXPSWTPH.Where(a => a.IDJunSenior == del.IDJunSenior).Count() != 0 || soft.CV_CVBASE.Where(a => a.IDJunSenior == del.IDJunSenior).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (del.IDJunSenior != idJUN && del.IDJunSenior != idSEN)
                                {
                                    soft.CV_JUNSENIOR.Remove(del);

                                    soft.SaveChanges();


                                    var w = new Form() { Size = new Size(0, 0) };
                                    Task.Delay(TimeSpan.FromSeconds(1))
                                        .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                    //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                    remplir();
                                }
                                else
                                    MessageBox.Show("You can't delete Junior and Senior", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        //TECHNICAL FIELD//
                        if (comboTa.Text == "TECHNICAL FIELD")
                        {
                            var del = soft.CV_TECHNICFIELD.Where(a => a.IDTechField == GridSelect).FirstOrDefault();

                            if (soft.CV_INTLEXPTECH.Where(a => a.IDTechField == del.IDTechField).Count() != 0)
                            {
                                MessageBox.Show("Vous ne pouvez pas effectuer cette action!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                soft.CV_TECHNICFIELD.Remove(del);

                                soft.SaveChanges();


                                var w = new Form() { Size = new Size(0, 0) };
                                Task.Delay(TimeSpan.FromSeconds(1))
                                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                                remplir();
                            }
                        }

                        textVal.Text = null;
                    }
                }
                else
                    MessageBox.Show("Select item before delete", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
