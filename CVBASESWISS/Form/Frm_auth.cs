using CVBASESWISS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVBASESWISS
{
    public partial class Frm_auth : Form
    {
        private static string key = "CVBASE2022softrfr_rr";
        public Frm_auth()
        {
            InitializeComponent();
            connect();
        }

        public void authentif()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                var isencr = Cipher.Encrypt(tMdp.Text, key);

                if (soft.CV_USERS.Where(a => a.LOGIN == tPseudo.Text && a.PASSWORD == isencr).Count() != 0)
                {
                    var isCo = soft.CV_USERS.Where(a => a.LOGIN == tPseudo.Text && a.PASSWORD == isencr).FirstOrDefault();
                    Token.setISCO(isCo.ID_USERS);

                    if (isCo.AUTH == 1)
                        Token.setAUTHO(true);
                    else
                        Token.setAUTHO(false);

                    if (isCo.ISADMIN == 1)
                        Token.setISA(true);
                    else
                        Token.setISA(false);


                    if (soft.CV_DATASET.Where(a => a.ID_USERS == isCo.ID_USERS).Count() == 0)
                    {
                        var newisco = new CV_DATASET
                        {
                            ID_USERS = isCo.ID_USERS,
                            DATASETCV = ""
                        };

                        soft.CV_DATASET.Add(newisco);
                        soft.SaveChanges();
                    }
                    Token.setName(tPseudo.Text, isencr);
                    this.Visible = false;

                    Form1 frm = new Form1();
                    frm.Show();
                }
                else
                    MessageBox.Show("Please check your login information", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            authentif();
        }

        private void tPseudo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)10) || (e.KeyChar == (char)13))
            {
                authentif();
            }
        }

        private void tMdp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)10) || (e.KeyChar == (char)13))
            {
                authentif();
            }
        }
        private void connect()
        {
            var cfgText = P_Directory.CheckRepository();

            if (String.IsNullOrEmpty(cfgText))
            {
                Config frm = new Config();
                frm.ShowDialog();
                return;
            }

            try
            {
                var connectionString = Cipher.Decrypt(cfgText, key);
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["DbCVBASE"].ConnectionString = connectionString;
                config.ConnectionStrings.ConnectionStrings["CVBASESWISS.Properties.Settings.CVBASEConnectionPrint"].ConnectionString = connectionString;
                config.ConnectionStrings.ConnectionStrings["CVBASESWISS.Properties.Settings.CVBASEConnectionString"].ConnectionString = connectionString;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");
                //MessageBox.Show("Your connection string has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Config frm = new Config();
                frm.ShowDialog();
                return;
            }
        }

        private void tool_Click(object sender, EventArgs e)
        {
            Config frm = new Config();
            frm.ShowDialog();
        }
    }
}
