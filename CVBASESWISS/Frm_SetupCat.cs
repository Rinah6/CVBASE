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
    public partial class Frm_SetupCat : Form
    {
        public Frm_SetupCat()
        {
            InitializeComponent();

            DbCVBASE soft = new DbCVBASE();

            Cat.Items.Add("");
            if (soft.CV_CATEGORY.Count() != 0)
            {
                foreach (var y in soft.CV_CATEGORY.ToList())
                {
                    Cat.Items.Add(y.Category);
                }
            }

            remplir();

            Cat.Focus();
        }

        public void remplir()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                DataTable table = new DataTable();
                table.Columns.Clear();

                table.Columns.Add("N°");
                table.Columns.Add("Criteria");

                table.Rows.Clear();

                textBox0.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

                if(!String.IsNullOrEmpty(Cat.Text))
                {
                    if (soft.CV_CATEGORY.Where(a => a.Category == Cat.Text).Count() != 0)
                    {
                        var isCat = soft.CV_CATEGORY.Where(a => a.Category == Cat.Text).FirstOrDefault();

                        table.Rows.Add("Criteria 1", isCat.CR1);
                        table.Rows.Add("Criteria 2", isCat.CR2);
                        table.Rows.Add("Criteria 3", isCat.CR3);
                        table.Rows.Add("Criteria 4", isCat.CR4);

                        textBox0.Text = isCat.CR1;
                        textBox1.Text = isCat.CR2;
                        textBox2.Text = isCat.CR3;
                        textBox3.Text = isCat.CR4;
                    }
                }
                gridliste.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void RoleU_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Cat_Validated(object sender, EventArgs e)
        {
            remplir();
        }

        private void ajout_Click(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                if(!String.IsNullOrEmpty(Cat.Text))
                {
                    if (!String.IsNullOrEmpty(textBox0.Text) && !String.IsNullOrEmpty(textBox1.Text) &&
                        !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text))
                    {
                        var isCAt = soft.CV_CATEGORY.Where(a => a.Category == Cat.Text).FirstOrDefault();

                        isCAt.CR1 = textBox0.Text;
                        isCAt.CR2 = textBox1.Text;
                        isCAt.CR3 = textBox2.Text;
                        isCAt.CR4 = textBox3.Text;

                        isCAt.ISOK = true;

                        soft.SaveChanges();

                        MessageBox.Show("Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        remplir();
                    }
                    else
                        MessageBox.Show("Please fill all criteria", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Please choose the category", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                var total = soft.CV_CATEGORY.Count();

                var notSetup = soft.CV_CATEGORY.Where(a => a.ISOK != true).Count();

                var message = "Out of a total of " + total + " categories, " + notSetup + " are not yet set up" + "\n\n";
                message += "Here is the list of the categories not yet set up : " + "\n\n";

                int i = 1;
                foreach(var x in soft.CV_CATEGORY.Where(a => a.ISOK != true).OrderBy(a => a.Category).ToList())
                {
                    message += i + " - " + x.Category + "\n";

                    i++;
                }

                MessageBox.Show(message, "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
