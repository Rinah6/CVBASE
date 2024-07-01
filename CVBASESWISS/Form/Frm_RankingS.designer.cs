namespace CVBASESWISS
{
    partial class Frm_RankingS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RankingS));
            this.V1p = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.V1 = new System.Windows.Forms.TextBox();
            this.V2p = new System.Windows.Forms.TextBox();
            this.V3p = new System.Windows.Forms.TextBox();
            this.V3 = new System.Windows.Forms.TextBox();
            this.V2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // V1p
            // 
            this.V1p.Location = new System.Drawing.Point(188, 59);
            this.V1p.Name = "V1p";
            this.V1p.Size = new System.Drawing.Size(28, 20);
            this.V1p.TabIndex = 18;
            this.V1p.Text = "0";
            this.V1p.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.V1p.TextChanged += new System.EventHandler(this.V1p_TextChanged);
            this.V1p.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.V3p_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Score is 3 if number of years > ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Score is 2 if number of years > ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Score is 1 if number of years >= ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Score is 0 if number of years < ";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(33, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(221, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "and <=";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(221, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "and <=";
            // 
            // V1
            // 
            this.V1.Enabled = false;
            this.V1.Location = new System.Drawing.Point(188, 83);
            this.V1.Name = "V1";
            this.V1.Size = new System.Drawing.Size(28, 20);
            this.V1.TabIndex = 32;
            this.V1.Text = "0";
            this.V1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // V2p
            // 
            this.V2p.Location = new System.Drawing.Point(188, 35);
            this.V2p.Name = "V2p";
            this.V2p.Size = new System.Drawing.Size(28, 20);
            this.V2p.TabIndex = 33;
            this.V2p.Text = "0";
            this.V2p.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.V2p.TextChanged += new System.EventHandler(this.V2p_TextChanged);
            this.V2p.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.V3p_KeyPress);
            // 
            // V3p
            // 
            this.V3p.Location = new System.Drawing.Point(188, 11);
            this.V3p.Name = "V3p";
            this.V3p.Size = new System.Drawing.Size(28, 20);
            this.V3p.TabIndex = 34;
            this.V3p.Text = "0";
            this.V3p.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.V3p.TextChanged += new System.EventHandler(this.V3p_TextChanged);
            this.V3p.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.V3p_KeyPress);
            // 
            // V3
            // 
            this.V3.Enabled = false;
            this.V3.Location = new System.Drawing.Point(262, 35);
            this.V3.Name = "V3";
            this.V3.Size = new System.Drawing.Size(28, 20);
            this.V3.TabIndex = 36;
            this.V3.Text = "0";
            this.V3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // V2
            // 
            this.V2.Enabled = false;
            this.V2.Location = new System.Drawing.Point(262, 59);
            this.V2.Name = "V2";
            this.V2.Size = new System.Drawing.Size(28, 20);
            this.V2.TabIndex = 35;
            this.V2.Text = "0";
            this.V2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Frm_RankingS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 147);
            this.Controls.Add(this.V3);
            this.Controls.Add(this.V2);
            this.Controls.Add(this.V3p);
            this.Controls.Add(this.V2p);
            this.Controls.Add(this.V1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.V1p);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_RankingS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ranking system for SENIOR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_RankingS_FormClosing);
            this.Load += new System.EventHandler(this.Frm_RankingJ_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox V1p;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox V1;
        private System.Windows.Forms.TextBox V2p;
        private System.Windows.Forms.TextBox V3p;
        private System.Windows.Forms.TextBox V3;
        private System.Windows.Forms.TextBox V2;
    }
}