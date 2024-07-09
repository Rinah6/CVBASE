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
    public partial class Frm_CCMAIL : Form
    {
        List<String> itmName = new List<String>();

        public Frm_CCMAIL()
        {
            InitializeComponent();

            DbCVBASE soft = new DbCVBASE();

            itmName.Add("");
            if (soft.CV_JUNSENIOR.Count() != 0)
            {
                foreach (var x in soft.CV_JUNSENIOR.Select(a => a.JunSenior).OrderBy(a => a).ToList())
                {
                    itmName.Add(x);
                }
            }
            comboBox1.DataSource = itmName;

            okCON();
        }

        public void okCON()
        {
            DbCVBASE soft = new DbCVBASE();

            int isco = Token.getisCO();

            label2.Text = "Data set undefined.";
            comboBox1.SelectedItem = "";

            if (soft.CV_DATASET.Where(a => a.ID_USERS == isco).Count() != 0)
            {
                var isColab = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault().DATASETCV;

                if (!String.IsNullOrEmpty(isColab))
                {
                    label2.Text = "You are connected to the " + isColab + " Data set.";
                    comboBox1.SelectedItem = isColab;
                    label2.ForeColor = Color.LimeGreen;
                }
                else
                {
                    label2.Text = "Data set undefined.";
                    label2.ForeColor = Color.Tomato;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                int isco = Token.getisCO();

                var isModiISCO = soft.CV_DATASET.Where(a => a.ID_USERS == isco).FirstOrDefault();

                if (!String.IsNullOrEmpty(comboBox1.Text))
                {
                    isModiISCO.DATASETCV = comboBox1.Text;
                }
                else
                    isModiISCO.DATASETCV = "";

                soft.SaveChanges();

                okCON();

                this.DialogResult = DialogResult.OK;


                var w = new Form() { Size = new Size(0, 0) };
                Task.Delay(TimeSpan.FromSeconds(1.5))
                    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
