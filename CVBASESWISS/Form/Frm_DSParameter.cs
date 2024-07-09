using CVBASESWISS.Model;
using DocuSign.eSign.Model;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DocuSign.eSign.Client.Auth.OAuth.UserInfo;

namespace CVBASESWISS
{
    public partial class Frm_DSParameter : Form
    {
        DbCVBASE db = new DbCVBASE();
        public Frm_DSParameter()
        {
            InitializeComponent();
            if(dsParameter.dsOption != null)
            {
                txt_ik.Text = dsParameter.dsOption.IntegrationKey;
                txt_rsaprk.Text = dsParameter.dsOption.PrivateKey;
                txt_rsapbk.Text = dsParameter.dsOption.PublicKey;
                txt_uid.Text = dsParameter.dsOption.UserId;
                txt_accid.Text = dsParameter.dsOption.AccountId;
                txt_burl.Text = dsParameter.dsOption.BaseUrl;
                txt_henv.Text = dsParameter.dsOption.HostEnv;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            dsParameter.dsOption = new CV_DOCUSIGN()
            {
                id = 1,
                IntegrationKey = txt_ik.Text,
                PrivateKey = txt_rsaprk.Text,
                PublicKey = txt_rsapbk.Text,
                UserId = txt_uid.Text,
                AccountId = txt_accid.Text,
                BaseUrl = txt_burl.Text,
                HostEnv = txt_henv.Text
            };

            var ds = db.CV_DOCUSIGN.FirstOrDefault();
            if(ds != null)
            {
                ds.IntegrationKey = txt_ik.Text;
                ds.PrivateKey = txt_rsaprk.Text;
                ds.PublicKey = txt_rsapbk.Text;
                ds.UserId = txt_uid.Text;
                ds.AccountId = txt_accid.Text;
                ds.BaseUrl = txt_burl.Text;
                ds.HostEnv = txt_henv.Text;
            }
            else
            {
                db.CV_DOCUSIGN.Add(dsParameter.dsOption); 
            }

            if (dsParameter.GetAuth())
            {
                db.SaveChanges();

                var w = new Form() { Size = new Size(0, 0) };
                Task.Delay(TimeSpan.FromSeconds(1.5))
                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Dispose();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"Please, verify your docusign identity!", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
