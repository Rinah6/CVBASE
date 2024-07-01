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
    public partial class Frm_CC : Form
    {
        public Frm_CC()
        {
            InitializeComponent();

            DbCVBASE soft = new DbCVBASE();

            if (soft.CV_CCMAIL.Count() != 0)
            {
                textBox1.Text = soft.CV_CCMAIL.FirstOrDefault().CCMAIL;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    if (soft.CV_CCMAIL.Count() == 0)
                    {
                        var InsCC = new CV_CCMAIL
                        {
                            CCMAIL = textBox1.Text
                        };
                        soft.CV_CCMAIL.Add(InsCC);
                        soft.SaveChanges();
                    }
                    else
                    {
                        var isModiISCO = soft.CV_CCMAIL.FirstOrDefault();

                        isModiISCO.CCMAIL = textBox1.Text;

                        soft.SaveChanges();
                    }

                    MessageBox.Show("Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
