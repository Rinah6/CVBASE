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
    public partial class Frm_RankingS : Form
    {
        string c1, c2, c3;
        bool cansave = false;
        public Frm_RankingS()
        {
            InitializeComponent();
         
            DbCVBASE soft = new DbCVBASE();

            if (soft.CV_RANKSEN.Count() == 0)
            {
                var newRank = new CV_RANKSEN
                {
                    V1 = 0,
                    V2 = 0,
                    V3 = 0
                };
                soft.CV_RANKSEN.Add(newRank);
                soft.SaveChanges();
            }

            V1p.Text = "0";
            V2p.Text = "0";
            V3p.Text = "0";

            var isRank = soft.CV_RANKSEN.FirstOrDefault();

            if (isRank != null)
            {
                V1p.Text = isRank.V1.ToString();
                V2p.Text = isRank.V2.ToString();
                V3p.Text = isRank.V3.ToString();
            }
            c1 = V1p.Text;
            c2 = V2p.Text;
            c3 = V3p.Text;
            if (Token.getAUTHO()==true)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
           /* try
            {

                DbCVBASE soft = new DbCVBASE();

                var isRank = soft.CV_RANKSEN.FirstOrDefault();

                int v1 = 0;
                int v2 = 0;
                int v3 = 0;

                if (!String.IsNullOrEmpty(V1.Text))
                    v1 = int.Parse(V1.Text);
                if (!String.IsNullOrEmpty(V2.Text))
                    v2 = int.Parse(V2.Text);
                if (!String.IsNullOrEmpty(V3.Text))
                    v3 = int.Parse(V3.Text);

                isRank.V1 = v1;
                isRank.V2 = v2;
                isRank.V3 = v3;

          

                if (v1 > v2 && v2 > v3)
                {
                    soft.SaveChanges();
                    MessageBox.Show("Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Please verify", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }*/
        }

        private void Frm_RankingJ_Load(object sender, EventArgs e)
        {

        }

        private void V1p_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(V1p.Text))
            {
                V1.Text = V1p.Text = "0";
            }
            else
                V1.Text = V1p.Text;
        }

        private void V2p_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(V2p.Text))
            {
                V2.Text = V2p.Text = "0";
            }
            else
                V2.Text = V2p.Text;
        }

        private void V3p_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(V3p.Text))
            {
                V3.Text = V3p.Text = "0";
            }
            else
                V3.Text = V3p.Text;
        }

        private void V3p_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32)
            {
                e.Handled = true;
            }
        }
        private void save()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                var isRank = soft.CV_RANKSEN.FirstOrDefault();

                int v1 = 0;
                int v2 = 0;
                int v3 = 0;

                if (!String.IsNullOrEmpty(V1.Text))
                    v1 = int.Parse(V1.Text);
                if (!String.IsNullOrEmpty(V2.Text))
                    v2 = int.Parse(V2.Text);
                if (!String.IsNullOrEmpty(V3.Text))
                    v3 = int.Parse(V3.Text);
             
                if (v3 > v2 && v2 > v1)
                {
                    cansave = true;
                    isRank.V1 = v1;
                    isRank.V2 = v2;
                    isRank.V3 = v3;
                    soft.SaveChanges();
                    c1 = V1p.Text;
                    c2 = V2p.Text;
                    c3 = V3p.Text;

                    var w = new Form() { Size = new Size(0, 0) };
                    Task.Delay(TimeSpan.FromSeconds(1))
                        .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                    //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Please change value to obtain score! ", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Frm_RankingS_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool updated = false;
            if (c1 != V1p.Text || c2 != V2p.Text || c3 != V3p.Text)
            {
                updated = true;
            }
            if (updated == true)
            {
                string message = "Do you want to save before close?";
                string caption = "CVBASE";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    int v1 = 0;
                    int v2 = 0;
                    int v3 = 0;
                    if (!String.IsNullOrEmpty(V1.Text))
                        v1 = int.Parse(V1.Text);
                    if (!String.IsNullOrEmpty(V2.Text))
                        v2 = int.Parse(V2.Text);
                    if (!String.IsNullOrEmpty(V3.Text))
                        v3 = int.Parse(V3.Text);

                    if (v3 > v2 && v2 > v1)
                    {
                        save();
                    }
                    else
                    {
                        MessageBox.Show("Please change value to obtain score!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         e.Cancel = true;
                    }
                }
            }
        }
      
    }
}
