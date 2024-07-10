namespace CVBASESWISS
{
    partial class Frm_DATAWH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DATAWH));
            this.gridliste = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ajout = new System.Windows.Forms.Button();
            this.textVal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboTa = new System.Windows.Forms.ComboBox();
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
            this.gridliste.Location = new System.Drawing.Point(0, 101);
            this.gridliste.Name = "gridliste";
            this.gridliste.ReadOnly = true;
            this.gridliste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridliste.Size = new System.Drawing.Size(484, 260);
            this.gridliste.TabIndex = 32;
            this.gridliste.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridliste_CellClick);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(397, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 31;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(397, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ajout
            // 
            this.ajout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ajout.Enabled = false;
            this.ajout.Location = new System.Drawing.Point(397, 11);
            this.ajout.Name = "ajout";
            this.ajout.Size = new System.Drawing.Size(75, 23);
            this.ajout.TabIndex = 29;
            this.ajout.Text = "Add";
            this.ajout.UseVisualStyleBackColor = true;
            this.ajout.Click += new System.EventHandler(this.ajout_Click);
            // 
            // textVal
            // 
            this.textVal.Location = new System.Drawing.Point(123, 44);
            this.textVal.Name = "textVal";
            this.textVal.Size = new System.Drawing.Size(253, 20);
            this.textVal.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Table";
            // 
            // comboTa
            // 
            this.comboTa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboTa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTa.FormattingEnabled = true;
            this.comboTa.Items.AddRange(new object[] {
            "",
            "APPRECIATION",
            "CATEGORY",
            "CLIENT",
            "DIPLOMA",
            "DOCUMENT",
            "EMPLOYEE",
            "EPROFIL PLATFORM",
            "GENDER",
            "LANGUAGE",
            "LANGUAGE LEVEL",
            "LEVEL",
            "NATION",
            "PLACE",
            "REGION",
            "ROLE",
            "SPECIALITY",
            "SCIH UNIT",
            "TECHNICAL FIELD",
            "TOWN"});
            this.comboTa.Location = new System.Drawing.Point(123, 12);
            this.comboTa.Name = "comboTa";
            this.comboTa.Size = new System.Drawing.Size(253, 21);
            this.comboTa.TabIndex = 1;
            this.comboTa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboTa_KeyPress);
            this.comboTa.Validated += new System.EventHandler(this.comboTa_Validated);
            // 
            // Frm_DATAWH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.comboTa);
            this.Controls.Add(this.gridliste);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ajout);
            this.Controls.Add(this.textVal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 400);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Frm_DATAWH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data Warehouse";
            ((System.ComponentModel.ISupportInitialize)(this.gridliste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridliste;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ajout;
        private System.Windows.Forms.TextBox textVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboTa;
    }
}