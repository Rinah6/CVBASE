using CVBASESWISS.Model;
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
    public partial class Frm_DSModel : Form
    {
        DbCVBASE soft = new DbCVBASE();
        public Frm_DSModel()
        {
            InitializeComponent();
            
            var mail = soft.CV_CCMAIL.FirstOrDefault();
            if (mail != null)
            {
                //txt_retmail.Text = mail.RETMAIL;
                txt_powerform.Text = mail.DSPF;
            }
        }

        private void Frm_DSModel_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try { 
                var mail = soft.CV_CCMAIL.FirstOrDefault();
                if(mail != null)
                {
                    //mail.RETMAIL = txt_retmail.Text;
                    mail.DSPF = txt_powerform.Text;
                }
                else
                {
                    soft.CV_CCMAIL.Add(new CV_CCMAIL()
                    {
                        //RETMAIL = txt_retmail.Text,
                        DSPF = txt_powerform.Text
                    });
                }
                soft.SaveChanges();
                dsParameter.PowerForm = dsParameter.GetPowerFormId(txt_powerform.Text);
                MessageBox.Show(dsParameter.PowerForm);
                System.Windows.Forms.MessageBox.Show("successfully saved", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
            }catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
