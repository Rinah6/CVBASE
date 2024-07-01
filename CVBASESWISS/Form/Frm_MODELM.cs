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
    public partial class Frm_MODELM : Form
    {
        string update;

        public bool testCLOSE = false;
        public Frm_MODELM()
        {
            InitializeComponent();

            DbCVBASE soft = new DbCVBASE();

            if (soft.CV_CCMAIL.Count() != 0)
            {
                textBox1.Text = soft.CV_CCMAIL.FirstOrDefault().MDLMAIL;
            }

            if (Token.getAUTHO() == true)
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
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
                            MDLMAIL = textBox1.Text
                        };
                        soft.CV_CCMAIL.Add(InsCC);
                        soft.SaveChanges();
                        update = textBox1.Text;
                    }
                    else
                    {
                        var isModiISCO = soft.CV_CCMAIL.FirstOrDefault();

                        isModiISCO.MDLMAIL = textBox1.Text;

                        soft.SaveChanges();
                        update = textBox1.Text;
                    }

                    MessageBox.Show("Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    testCLOSE = true;

                    this.Dispose();
                }
            }
         catch (Exception ex)
         {
             MessageBox.Show(ex.Message + ex.StackTrace);
         }
        }
        private void Frm_MODELM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (testCLOSE == true)
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
