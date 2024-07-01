namespace CVBASESWISS
{
    partial class Frm_RankDipl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RankDipl));
            this.comboTa = new System.Windows.Forms.ComboBox();
            this.gridliste = new System.Windows.Forms.DataGridView();
            this.ajout = new System.Windows.Forms.Button();
            this.textVal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridliste)).BeginInit();
            this.SuspendLayout();
            // 
            // comboTa
            // 
            this.comboTa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboTa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTa.FormattingEnabled = true;
            this.comboTa.Location = new System.Drawing.Point(123, 12);
            this.comboTa.Name = "comboTa";
            this.comboTa.Size = new System.Drawing.Size(253, 21);
            this.comboTa.TabIndex = 33;
            this.comboTa.SelectedValueChanged += new System.EventHandler(this.comboTa_SelectedValueChanged);
            this.comboTa.Validated += new System.EventHandler(this.comboTa_Validated);
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
            this.gridliste.TabIndex = 40;
            this.gridliste.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridliste_CellClick);
            // 
            // ajout
            // 
            this.ajout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ajout.Enabled = false;
            this.ajout.Location = new System.Drawing.Point(397, 11);
            this.ajout.Name = "ajout";
            this.ajout.Size = new System.Drawing.Size(75, 23);
            this.ajout.TabIndex = 37;
            this.ajout.Text = "Save";
            this.ajout.UseVisualStyleBackColor = true;
            this.ajout.Click += new System.EventHandler(this.ajout_Click);
            // 
            // textVal
            // 
            this.textVal.Location = new System.Drawing.Point(123, 44);
            this.textVal.Name = "textVal";
            this.textVal.Size = new System.Drawing.Size(253, 20);
            this.textVal.TabIndex = 34;
            this.textVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textVal_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Score";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Diploma";
            // 
            // Frm_RankDipl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.comboTa);
            this.Controls.Add(this.gridliste);
            this.Controls.Add(this.ajout);
            this.Controls.Add(this.textVal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Frm_RankDipl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ranking for Diploma";
            ((System.ComponentModel.ISupportInitialize)(this.gridliste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboTa;
        private System.Windows.Forms.DataGridView gridliste;
        private System.Windows.Forms.Button ajout;
        private System.Windows.Forms.TextBox textVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}