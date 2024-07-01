namespace CVBASESWISS
{
    partial class Frm_UserAUTHO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_UserAUTHO));
            this.ajout = new System.Windows.Forms.Button();
            this.RoleU = new System.Windows.Forms.ComboBox();
            this.LoginU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridliste = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridliste)).BeginInit();
            this.SuspendLayout();
            // 
            // ajout
            // 
            this.ajout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ajout.Location = new System.Drawing.Point(395, 40);
            this.ajout.Name = "ajout";
            this.ajout.Size = new System.Drawing.Size(77, 23);
            this.ajout.TabIndex = 19;
            this.ajout.Text = "Save";
            this.ajout.UseVisualStyleBackColor = true;
            this.ajout.Click += new System.EventHandler(this.ajout_Click);
            // 
            // RoleU
            // 
            this.RoleU.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.RoleU.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RoleU.FormattingEnabled = true;
            this.RoleU.Location = new System.Drawing.Point(143, 41);
            this.RoleU.Name = "RoleU";
            this.RoleU.Size = new System.Drawing.Size(233, 21);
            this.RoleU.TabIndex = 18;
            this.RoleU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RoleU_KeyPress);
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
            this.label3.Location = new System.Drawing.Point(20, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "User\'s status";
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
            this.gridliste.Location = new System.Drawing.Point(0, 69);
            this.gridliste.Name = "gridliste";
            this.gridliste.ReadOnly = true;
            this.gridliste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridliste.Size = new System.Drawing.Size(484, 292);
            this.gridliste.TabIndex = 22;
            this.gridliste.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridliste_CellClick);
            // 
            // Frm_UserAUTHO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.gridliste);
            this.Controls.Add(this.ajout);
            this.Controls.Add(this.RoleU);
            this.Controls.Add(this.LoginU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 400);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Frm_UserAUTHO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Authorisation";
            ((System.ComponentModel.ISupportInitialize)(this.gridliste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ajout;
        private System.Windows.Forms.ComboBox RoleU;
        private System.Windows.Forms.TextBox LoginU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridliste;
    }
}