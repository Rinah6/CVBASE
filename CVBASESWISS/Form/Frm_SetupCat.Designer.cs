namespace CVBASESWISS
{
    partial class Frm_SetupCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_SetupCat));
            this.gridliste = new System.Windows.Forms.DataGridView();
            this.ajout = new System.Windows.Forms.Button();
            this.Cat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox0 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridliste)).BeginInit();
            this.SuspendLayout();
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
            this.gridliste.Location = new System.Drawing.Point(0, 335);
            this.gridliste.Name = "gridliste";
            this.gridliste.ReadOnly = true;
            this.gridliste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridliste.Size = new System.Drawing.Size(484, 135);
            this.gridliste.TabIndex = 32;
            this.gridliste.TabStop = false;
            // 
            // ajout
            // 
            this.ajout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ajout.Enabled = false;
            this.ajout.Location = new System.Drawing.Point(102, 269);
            this.ajout.Name = "ajout";
            this.ajout.Size = new System.Drawing.Size(370, 32);
            this.ajout.TabIndex = 29;
            this.ajout.Text = "Save";
            this.ajout.UseVisualStyleBackColor = true;
            this.ajout.Click += new System.EventHandler(this.ajout_Click);
            // 
            // Cat
            // 
            this.Cat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.Cat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cat.FormattingEnabled = true;
            this.Cat.Location = new System.Drawing.Point(102, 12);
            this.Cat.Name = "Cat";
            this.Cat.Size = new System.Drawing.Size(370, 21);
            this.Cat.TabIndex = 1;
            this.Cat.SelectedValueChanged += new System.EventHandler(this.Cat_SelectedValueChanged);
            this.Cat.TextChanged += new System.EventHandler(this.Cat_TextChanged);
            this.Cat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RoleU_KeyPress);
            this.Cat.Validated += new System.EventHandler(this.Cat_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Criteria 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Criteria 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Category";
            // 
            // textBox0
            // 
            this.textBox0.Location = new System.Drawing.Point(102, 39);
            this.textBox0.MaxLength = 350;
            this.textBox0.Multiline = true;
            this.textBox0.Name = "textBox0";
            this.textBox0.Size = new System.Drawing.Size(370, 40);
            this.textBox0.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 85);
            this.textBox1.MaxLength = 350;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(370, 40);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(102, 131);
            this.textBox2.MaxLength = 350;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(370, 40);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(102, 177);
            this.textBox3.MaxLength = 350;
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(370, 40);
            this.textBox3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Criteria 3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Criteria 4";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.Color.Tomato;
            this.button1.Location = new System.Drawing.Point(297, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Check if all categories are setup";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Criteria 5";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(102, 223);
            this.textBox4.MaxLength = 350;
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(370, 40);
            this.textBox4.TabIndex = 6;
            // 
            // Frm_SetupCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 470);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gridliste);
            this.Controls.Add(this.ajout);
            this.Controls.Add(this.Cat);
            this.Controls.Add(this.textBox0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "Frm_SetupCat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup Category Criteria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_SetupCat_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridliste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridliste;
        private System.Windows.Forms.Button ajout;
        private System.Windows.Forms.ComboBox Cat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox0;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
    }
}