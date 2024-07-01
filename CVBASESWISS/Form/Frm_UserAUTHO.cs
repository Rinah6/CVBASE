using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace CVBASESWISS
{
    public partial class Frm_UserAUTHO : Form
    {
        public Frm_UserAUTHO()
        {
            InitializeComponent();

            RoleU.Items.Add("Authorised");
            RoleU.Items.Add("Not authorised");

            /*if (Token.getAUTHO() == true)
            {
                ajout.Enabled = true;
            }*/

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
                table.Columns.Add("User's Status");

                table.Rows.Clear();
          
                if (Token.getISA() == true)
                {

                    if (soft.CV_USERS.Count() != 0)
                    {
                        foreach (var x in soft.CV_USERS.OrderBy(a => a.LOGIN).ToList())
                        {
                            var roleUser = "Not authorised";
                            if (x.AUTH == 1)
                                roleUser = "Authorised";

                            table.Rows.Add(x.ID_USERS, x.LOGIN, roleUser);
                        }
                    }
                }
                else
                {
                   string login = Token.getName();
                   string pswd = Token.getPass();
                   var us = soft.CV_USERS.FirstOrDefault(h => h.LOGIN == login && h.PASSWORD == pswd);
                    var roleUser = "Not authorised";
                    if (us.AUTH == 1)
                        roleUser = "Authorised";
                    table.Rows.Add(us.ID_USERS, us.LOGIN, roleUser);

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
                int GridSelect = 0;
                bool result = int.TryParse(gridliste.CurrentRow.Cells[0].Value.ToString(), out GridSelect);

                if (result)
                {
                    GridSelect = int.Parse(gridliste.CurrentRow.Cells[0].Value.ToString());

                    if (LoginU.Text != String.Empty && RoleU.Text != String.Empty)
                    {
                        string message = Interaction.InputBox("Entrer the Password Authorisation", "CVBASE", "", -1, -1);

                        if(!String.IsNullOrEmpty(message))
                        {
                            var isMe = Cipher.Encrypt(message, "CVBASE2022softrfr_rr");
                            if (soft.CV_AUTHORMDP.Where(a => a.MDPAUTH == isMe).Count() != 0)
                            {
                                int idR = 0;
                                if (RoleU.Text == "Authorised")
                                {
                                    idR = 1;
                                    Token.setAUTHO(true);
                                   
                                 //   Form1 fr = new Form1();
                                    
                      
                                }
                                else
                                {
                                    Token.setAUTHO(false);  
                               //    Form1 fr = new Form1();
                                }
                              
                                var modifUser = soft.CV_USERS.Where(a => a.ID_USERS == GridSelect).FirstOrDefault();

                                modifUser.AUTH = idR;

                                soft.SaveChanges();

                                MessageBox.Show("Successful", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                               
                                remplir();
                            }
                            else
                                MessageBox.Show("Wrong Password Authorisation", "CVBASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
                RoleU.SelectedItem = gridliste.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
