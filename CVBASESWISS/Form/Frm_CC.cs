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
        string update;
        bool cansave = false;
        bool testCanDisp = false;
        public Frm_CC()
        {
            InitializeComponent();
            cansave = false;
            DbCVBASE soft = new DbCVBASE();

            if (soft.CV_CCMAIL.Count() != 0)
            {
                textBox1.Text = soft.CV_CCMAIL.FirstOrDefault().CCMAIL;
                update = textBox1.Text;
            }

            if (Token.getAUTHO() == true)
            {
                button1.Enabled = true;
            }
        }
        private void save()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    cansave = true;
                    if (soft.CV_CCMAIL.Count() == 0)
                    {
                        var InsCC = new CV_CCMAIL
                        {
                            CCMAIL = textBox1.Text
                        };
                        soft.CV_CCMAIL.Add(InsCC);
                        soft.SaveChanges();
                        update = textBox1.Text;
                    }
                    else
                    {
                        var isModiISCO = soft.CV_CCMAIL.FirstOrDefault();
                        isModiISCO.CCMAIL = textBox1.Text;
                        soft.SaveChanges();
                        update = textBox1.Text;
                    }


                    var w = new Form() { Size = new Size(0, 0) };
                    Task.Delay(TimeSpan.FromSeconds(1.5))
                        .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                    //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    this.Dispose();
                    testCanDisp = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void Frm_CC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (testCanDisp == true)
            {
                this.Dispose();
            }
            else
            {
                if (textBox1.Text != update)
                {
                    string message = "Do you want to save before close?";
                    string caption = "CVBASE";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!String.IsNullOrEmpty(textBox1.Text))
                        {
                            save();
                        }
                        else
                        {
                            MessageBox.Show("Please fill in the field!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }

                    }
                }
            }
        }
    }
}
