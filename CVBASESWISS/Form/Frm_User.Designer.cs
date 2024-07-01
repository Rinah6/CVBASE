namespace CVBASESWISS
{
    partial class Frm_User
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_User));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ajout = new System.Windows.Forms.Button();
            this.RoleU = new System.Windows.Forms.ComboBox();
            this.MdpU = new System.Windows.Forms.TextBox();
            this.LoginU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridliste = new System.Windows.Forms.DataGridView();
            this.ISADMIN = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridliste)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(397, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(397, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ajout
            // 
            this.ajout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ajout.Location = new System.Drawing.Point(397, 40);
            this.ajout.Name = "ajout";
            this.ajout.Size = new System.Drawing.Size(75, 23);
            this.ajout.TabIndex = 19;
            this.ajout.Text = "Add";
            this.ajout.UseVisualStyleBackColor = true;
            this.ajout.Click += new System.EventHandler(this.ajout_Click);
            // 
            // RoleU
            // 
            this.RoleU.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.RoleU.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RoleU.FormattingEnabled = true;
            this.RoleU.Location = new System.Drawing.Point(143, 73);
            this.RoleU.Name = "RoleU";
            this.RoleU.Size = new System.Drawing.Size(233, 21);
            this.RoleU.TabIndex = 18;
            this.RoleU.SelectedIndexChanged += new System.EventHandler(this.RoleU_SelectedIndexChanged);
            this.RoleU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RoleU_KeyPress);
            // 
            // MdpU
            // 
            this.MdpU.Location = new System.Drawing.Point(143, 44);
            this.MdpU.Name = "MdpU";
            this.MdpU.Size = new System.Drawing.Size(233, 20);
            this.MdpU.TabIndex = 17;
            // 
            // LoginU
            // 
            this.LoginU.Location = new System.Drawing.Point(143, 12);
            this.LoginU.Name = "LoginU";
            this.LoginU.Size = new System.Drawing.Size(233, 20);
            this.LoginU.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "User\'s status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Login";
            // 
            // gridliste
            // 
            this.gridliste.AllowUserToAddRows = false;
            this.gridliste.AllowUserToDeleteRows = false;
            this.gridliste.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridliste.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridliste.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridliste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridliste.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridliste.Location = new System.Drawing.Point(0, 143);
            this.gridliste.Name = "gridliste";
            this.gridliste.ReadOnly = true;
            this.gridliste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridliste.Size = new System.Drawing.Size(484, 218);
            this.gridliste.TabIndex = 22;
            this.gridliste.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridliste_CellClick);
            // 
            // ISADMIN
            // 
            this.ISADMIN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.ISADMIN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ISADMIN.FormattingEnabled = true;
            this.ISADMIN.Items.AddRange(new object[] {
            "NO",
            "YES"});
            this.ISADMIN.Location = new System.Drawing.Point(143, 103);
            this.ISADMIN.Name = "ISADMIN";
            this.ISADMIN.Size = new System.Drawing.Size(233, 21);
            this.ISADMIN.TabIndex = 24;
            this.ISADMIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ISADMIN_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Is Admin";
            // 
            // Frm_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.ISADMIN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gridliste);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ajout);
            this.Controls.Add(this.RoleU);
            this.Controls.Add(this.MdpU);
            this.Controls.Add(this.LoginU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 400);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Frm_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Users";
            ((System.ComponentModel.ISupportInitialize)(this.gridliste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ajout;
        private System.Windows.Forms.ComboBox RoleU;
        private System.Windows.Forms.TextBox MdpU;
        private System.Windows.Forms.TextBox LoginU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridliste;
        private System.Windows.Forms.ComboBox ISADMIN;
        private System.Windows.Forms.Label label4;
    }
}