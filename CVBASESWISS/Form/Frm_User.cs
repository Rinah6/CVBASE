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
    public partial class Frm_User : Form
    {
        public Frm_User()
        {
            InitializeComponent();

            RoleU.Items.Add("Authorised");
            RoleU.Items.Add("Not authorised");

            remplir();
        }

        private void RoleU_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void remplir()
        {
            try
            {
                DbCVBASE soft = new DbCVBASE();

                DataTable table = new DataTable();
                table.Columns.Clear();

                table.Columns.Add("ID");
                table.Columns.Add("Login");
                table.Columns.Add("Password");
                table.Columns.Add("User's Status");
                table.Columns.Add("Is Admin");

                table.Rows.Clear();


                if (soft.CV_USERS.Count() != 0)
                {
                    foreach (var x in soft.CV_USERS.OrderBy(a => a.LOGIN).ToList())
                    {
                        var roleUser = "Not authorised";
                        if (x.AUTH == 1)
                            roleUser = "Authorised";

                        var isA = "NO";
                        if (x.ISADMIN == 1)
                            isA = "YES";

                        table.Rows.Add(x.ID_USERS, x.LOGIN, Cipher.Decrypt(x.PASSWORD, "CVBASE2022softrfr_rr"), roleUser, isA);
                    }
                }

                gridliste.DataSource = table;

                gridliste.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ajout_Click(object sender, EventArgs e)
        {
            DbCVBASE soft = new DbCVBASE();
            try
            {
                if (LoginU.Text != String.Empty && MdpU.Text != String.Empty && RoleU.Text != String.Empty)
                {
                    if (soft.CV_USERS.Where(a => a.LOGIN == LoginU.Text).Count() == 0)
                    {
                        int idR = 0;
                        if (RoleU.Text == "Authorised")
                            idR = 1;

                        int isA = 0;
                        if (ISADMIN.Text == "YES")
                            isA = 1;

                        var newUser = new CV_USERS
                        {
                            LOGIN = LoginU.Text,
                            PASSWORD = Cipher.Encrypt(MdpU.Text,"CVBASE2022softrfr_rr"),
                            AUTH = idR,
                            ISADMIN = isA
                        };

                        soft.CV_USERS.Add(newUser);
                        soft.SaveChanges();


                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(1))
                            .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        remplir();
                    }
                    else
                        MessageBox.Show("User already in", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Please fill all informations", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbCVBASE soft = new DbCVBASE();
            try
            {
                int GridSelect = 0;
                bool result = int.TryParse(gridliste.CurrentRow.Cells[0].Value.ToString(), out GridSelect);

                if (result)
                {
                    GridSelect = int.Parse(gridliste.CurrentRow.Cells[0].Value.ToString());

                    if (LoginU.Text != String.Empty && MdpU.Text != String.Empty && RoleU.Text != String.Empty)
                    {
                        int idR = 0;
                        if (RoleU.Text == "Authorised")
                            idR = 1;

                        int isA = 0;
                        if (ISADMIN.Text == "YES")
                            isA = 1;

                        var modifUser = soft.CV_USERS.Where(a => a.ID_USERS == GridSelect).FirstOrDefault();

                        modifUser.LOGIN = LoginU.Text;
                        modifUser.PASSWORD = Cipher.Encrypt(MdpU.Text, "CVBASE2022softrfr_rr");
                        modifUser.AUTH = idR;
                        modifUser.ISADMIN = isA;

                        soft.SaveChanges();

                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(1))
                            .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                        remplir();
                    }
                    else
                        MessageBox.Show("Please fill all informations", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Select user before edit", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void gridliste_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LoginU.Text = gridliste.CurrentRow.Cells[1].Value.ToString();
                MdpU.Text = gridliste.CurrentRow.Cells[2].Value.ToString();
                RoleU.SelectedItem = gridliste.CurrentRow.Cells[3].Value.ToString();
                ISADMIN.SelectedItem = gridliste.CurrentRow.Cells[4].Value.ToString();
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

                int GridSelect = 0;
                bool result = int.TryParse(gridliste.CurrentRow.Cells[0].Value.ToString(), out GridSelect);

                if (result)
                {
                    GridSelect = int.Parse(gridliste.CurrentRow.Cells[0].Value.ToString());

                    if (soft.CV_USERS.Count() != 0 && soft.CV_USERS.Where(a => a.ID_USERS == GridSelect).Count() != 0)
                    {
                        string message = "You are going to permanently delete the user : \"" + gridliste.CurrentRow.Cells[1].Value.ToString() + " \"";
                        string caption = "CVBASE";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult resultA;

                        // Displays the MessageBox.
                        resultA = MessageBox.Show(message, caption, buttons);

                        if (resultA == System.Windows.Forms.DialogResult.Yes)
                        {
                            var forDelete = soft.CV_USERS.Where(a => a.ID_USERS == GridSelect).FirstOrDefault();

                            soft.CV_USERS.Remove(forDelete);
                            soft.SaveChanges();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            //MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(w, "Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            remplir();
                        }
                    }
                    else
                        MessageBox.Show("Select user before delete", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Select user before delete", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DbCVBASE soft = new DbCVBASE();
            try
            {
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void RoleU_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ISADMIN.Items.Clear();

                if (RoleU.Text == "Not authorised")
                {
                    ISADMIN.Items.Remove("YES");
                    ISADMIN.Items.Add("NO");
                    ISADMIN.Text = "NO";
                    ISADMIN.Enabled = false;
                }
                else
                {
                    ISADMIN.Items.Add("YES");
                    ISADMIN.Items.Add("NO");
                    ISADMIN.Text = "YES";
                    ISADMIN.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ISADMIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
