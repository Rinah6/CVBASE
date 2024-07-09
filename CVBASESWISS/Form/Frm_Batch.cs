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
    public partial class Frm_Batch : Form
    {
        public Frm_Batch()
        {
            InitializeComponent();

            DbCVBASE soft = new DbCVBASE();

            if (soft.CV_BATCH.Count() != 0)
            {
                textBox1.Text = soft.CV_BATCH.FirstOrDefault().LOT.ToString();
            }

            if (Token.getAUTHO() == true)
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    if (soft.CV_BATCH.Count() == 0)
                    {
                        var InsCC = new CV_BATCH
                        {
                            LOT = int.Parse(textBox1.Text)
                        };
                        soft.CV_BATCH.Add(InsCC);
                        soft.SaveChanges();
                    }
                    else
                    {
                        var isModiISCO = soft.CV_BATCH.FirstOrDefault();

                        isModiISCO.LOT = int.Parse(textBox1.Text);

                        soft.SaveChanges();
                    }


                    var w = new Form() { Size = new Size(0, 0) };
                    Task.Delay(TimeSpan.FromSeconds(1.5))
                        .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                    //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entrer = e.KeyChar;
            if (!Char.IsDigit(entrer) && entrer != 8 && entrer != 32)
            {
                e.Handled = true;
            }
        }
    }
}
