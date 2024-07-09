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
    public partial class Frm_RankDipl : Form
    {
        public Frm_RankDipl()
        {
            InitializeComponent();

            DbCVBASE soft = new DbCVBASE();

            comboTa.Items.Add("");
            if (soft.CV_DIPLOMA.Count() != 0)
            {
                foreach (var y in soft.CV_DIPLOMA.ToList())
                {
                    comboTa.Items.Add(y.Diploma);
                }
            }

            remplir();

            if (Token.getAUTHO() == true)
            {
                ajout.Enabled = true;
            }
        }

        private void textVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32 && entrer != 48 && entrer != 49 && entrer != 50 && entrer != 51)
            {
                e.Handled = true;
            }
        }

        public void remplir()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                DataTable table = new DataTable();
                table.Columns.Clear();

                table.Columns.Add("Diploma");
                table.Columns.Add("Score");

                table.Rows.Clear();

                if(soft.CV_DIPLOMA.Count() != 0)
                {
                    foreach(var y in soft.CV_DIPLOMA.ToList())
                    {
                        var score = "0";
                        if(soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == y.IDDiploma).Count() != 0)
                        {
                            var isRank = soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == y.IDDiploma).FirstOrDefault();

                            score = isRank.Rank.ToString();
                        }
                        table.Rows.Add(y.Diploma, score);
                    }
                    gridliste.DataSource = table;
                }
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
                comboTa.SelectedItem = gridliste.CurrentRow.Cells[0].Value.ToString();
                textVal.Text = gridliste.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboTa_Validated(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                var score = "0";

                if(!String.IsNullOrEmpty(comboTa.Text))
                {
                    var isDipl = soft.CV_DIPLOMA.Where(a => a.Diploma == comboTa.Text).FirstOrDefault().IDDiploma;

                    if(soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDipl).Count() != 0)
                    {
                        var isrank = soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDipl).FirstOrDefault().Rank.Value.ToString();
                        score = isrank;
                    }
                }

                textVal.Text = score;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ajout_Click(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (!String.IsNullOrEmpty(comboTa.Text))
                {
                    int score = 0;
                    var isDipl = soft.CV_DIPLOMA.Where(a => a.Diploma == comboTa.Text).FirstOrDefault().IDDiploma;
                    if (!String.IsNullOrEmpty(textVal.Text))
                    {
                        score = int.Parse(textVal.Text);
                    }

                    if (soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDipl).Count() != 0)
                    {
                        var ismod = soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDipl).FirstOrDefault();

                        ismod.Rank = score;

                        soft.SaveChanges();


                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(1.5))
                            .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        remplir();
                    }
                    else
                    {
                        var newRank = new CV_RANKDIPLOMA
                        {
                            IDDiploma = isDipl,
                            Rank = score
                        };

                        soft.CV_RANKDIPLOMA.Add(newRank);
                        soft.SaveChanges();


                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(1.5))
                            .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        remplir();
                    }
                }
                else
                    MessageBox.Show("Please choose the diploma", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboTa_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                var score = "0";

                if (!String.IsNullOrEmpty(comboTa.Text))
                {
                    var isDipl = soft.CV_DIPLOMA.Where(a => a.Diploma == comboTa.Text).FirstOrDefault().IDDiploma;

                    if (soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDipl).Count() != 0)
                    {
                        var isrank = soft.CV_RANKDIPLOMA.Where(a => a.IDDiploma == isDipl).FirstOrDefault().Rank.Value.ToString();
                        score = isrank;
                    }
                }

                textVal.Text = score;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
