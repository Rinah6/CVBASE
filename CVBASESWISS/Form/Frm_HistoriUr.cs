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
    public partial class Frm_HistoriUr : Form
    {
        public Frm_HistoriUr()
        {
            InitializeComponent();
            FeelComboSearch();
            RemplirHis(String.Empty);
            bool auth = Token.getAUTHO();
            if (auth == false)
            {
                deleteToolStripMenuItem.Enabled = false;
                deleteAllToolStripMenuItem.Enabled = false;
            }
            else
            {
                deleteToolStripMenuItem.Enabled = true;
                deleteAllToolStripMenuItem.Enabled = true;
            }
           
        }
        public void FeelComboSearch()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();
                List<string> name = new List<string>();
                name.Add("");
                if(soft.CV_CVBASE.Count()!=0)
                {
                    foreach (var x in soft.CV_CVBASE.Select(a => a.LastName).OrderBy(a => a).ToList())
                    {
                        name.Add(x);
                    }
                }
                comboSearch.DataSource = name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }      
        }

        public void RemplirHis(string search)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Clear();
                DbCVBASE soft = new DbCVBASE();
            //    dataGridView1.Columns[0].Visible = false;

                table.Columns.Add("Id");
                table.Columns.Add("Last Name");
                table.Columns.Add("First Name");
                table.Columns.Add("Date of request");
                table.Columns.Add("@Mail");
                table.Columns.Add("PDRA");
                table.Columns.Add("DOCS");
                if (!String.IsNullOrEmpty(search))
                {
                    if (soft.CV_HISTOUR.Count() != 0)
                    {
                        foreach (var x in soft.CV_HISTOUR.Where(a => a.LastName.ToUpper() == search.ToUpper()).OrderByDescending(a => a.Date).ToList())
                        {
                       
                            var last = "";
                            var first = "";
                            var date = "";
                            var mail = "";
                            if (x.LastName != null) 
                                last = x.LastName;
                            if (x.FirstName != null) 
                                first = x.FirstName;
                            if (x.Date != null) 
                                date = x.Date.Value.ToShortDateString();
                            if (x.Mail != null) 
                                mail = x.Mail;
                            table.Rows.Add(x.ID,last, first,date,mail);
                        }
                       
                    }
                }
                else
                {
                    if (soft.CV_HISTOUR.Count() != 0)
                    {
                        foreach (var x in soft.CV_HISTOUR.OrderByDescending(a => a.Date).ToList())
                        {
                          
                            var last = "";
                            var first = "";
                            var date = "";
                            var mail = "";
                            if (x.LastName != null) 
                                last = x.LastName;
                            if (x.FirstName != null) 
                                first = x.FirstName;
                            if (x.Date != null) 
                                date = x.Date.Value.ToShortDateString();
                            if (x.Mail != null) 
                                mail = x.Mail;
                            table.Rows.Add(x.ID,last, first, date, mail);
                        }                   
                    }
                }
                dataGridView1.DataSource = table;
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }      
        }

        private void comboSearch_Validated(object sender, EventArgs e)
        {
            RemplirHis(comboSearch.Text);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            RemplirHis(comboSearch.Text);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "Do you want to delete?";
                string caption = "CVBASE";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    DbCVBASE db = new DbCVBASE();
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            int cel = 0;
                            var val = (row.Cells[0].Value).ToString();
                            int.TryParse(val, out cel);
                            var his = db.CV_HISTOUR.Where(f => f.ID == cel).FirstOrDefault();
                            db.CV_HISTOUR.Remove(his);
                        }
                        db.SaveChanges();
                    }
                    RemplirHis(string.Empty);
                    MessageBox.Show("Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }      
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                 string message = "Do you want to delete all log?";
                string caption = "CVBASE";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    DbCVBASE db = new DbCVBASE();
                    var all = from c in db.CV_HISTOUR select c;

                    if (all != null)
                    {
                        db.CV_HISTOUR.RemoveRange(all);
                         db.SaveChanges();
                    }
                    RemplirHis(string.Empty);
                    MessageBox.Show("Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }      
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                var name = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                if (!String.IsNullOrEmpty(name))
                {
                    var isCV = soft.CV_CVBASE.Where(a => a.LastName == name).FirstOrDefault();

                    int isco = Token.getisCO();
                    var iscoJun = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;

                    if (!String.IsNullOrEmpty(iscoJun))
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

                            //remplir(String.Empty);
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

                                //remplir(String.Empty);
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

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
