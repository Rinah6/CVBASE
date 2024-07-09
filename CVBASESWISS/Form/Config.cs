using CVBASESWISS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVBASESWISS
{
    public partial class Config : Form
    {
        private static string key = "CVBASE2022softrfr_rr";
        public Config()
        {
            InitializeComponent();
            Authentication.SelectedIndex = 0;
        }

        private void btconnect_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtserver.Text)){
                MessageBox.Show("Please, fill all fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string connectionString = selectedItem == 0 ?
                string.Format("Data Source={0};Initial Catalog=CVBASE;integrated security=True", txtserver.Text)
                :
                string.Format("Data Source={0};Initial Catalog=CVBASE;User ID={1};persist security info=True; Password={2};MultipleActiveResultSets=True;App=EntityFramework", txtserver.Text, txtusername.Text, txtpassword.Text)
            ;


            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.ConnectionStrings.ConnectionStrings["DbCVBASE"].ConnectionString = connectionString;
                    config.Save(ConfigurationSaveMode.Modified, true);
                    ConfigurationManager.RefreshSection("connectionStrings");
                    MessageBox.Show("Test connection succeeded", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnsave_Click(sender, e);
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void Config_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string connectionString = selectedItem == 0 ?
                string.Format("Data Source={0};Initial Catalog=CVBASE;integrated security=True", txtserver.Text)
                :
                string.Format("Data Source={0};Initial Catalog=CVBASE;User ID={1};persist security info=True; Password={2};MultipleActiveResultSets=True;App=EntityFramework", txtserver.Text, txtusername.Text, txtpassword.Text)
            ;

            var encText = Cipher.Encrypt(connectionString, key);
            System.IO.File.WriteAllText(P_Directory.file, encText);

            var w = new Form() { Size = new Size(0, 0) };
            Task.Delay(TimeSpan.FromSeconds(1.5))
                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MessageBox.Show(w, "Your connection string has been successfully saved", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            this.Dispose();
            //try
            //{
            //    SqlHelper helper = new SqlHelper(connectionString);
            //    if (helper.IsConnection)
            //    {
            //        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //        config.ConnectionStrings.ConnectionStrings["DbCVBASE"].ConnectionString = connectionString;
            //        config.Save(ConfigurationSaveMode.Modified, true);
            //        ConfigurationManager.RefreshSection("connectionStrings");
            //        MessageBox.Show("Your connection string has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private static int selectedItem = 0; 
        private void Authentication_TextChanged(object sender, EventArgs e)
        {
            Authentication.SelectedIndex = Authentication.SelectedIndex == -1 ? selectedItem : Authentication.SelectedIndex;
            selectedItem = Authentication.SelectedIndex;

            if (selectedItem == 1)
            {
                txtusername.Enabled = true;
                txtpassword.Enabled = true;
            }
            else
            {
                txtusername.Enabled = false;
                txtpassword.Enabled = false;
            }
        }
    }
}
