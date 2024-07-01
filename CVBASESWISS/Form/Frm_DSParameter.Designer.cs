namespace CVBASESWISS
{
    partial class Frm_DSParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DSParameter));
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.txt_ik = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_uid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_accid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_burl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_henv = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_rsaprk = new System.Windows.Forms.RichTextBox();
            this.txt_rsapbk = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(16, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 1);
            this.label2.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "RSA Private Key :";
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.Location = new System.Drawing.Point(329, 249);
            this.btnsave.MaximumSize = new System.Drawing.Size(75, 22);
            this.btnsave.MinimumSize = new System.Drawing.Size(75, 22);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 22);
            this.btnsave.TabIndex = 18;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txt_ik
            // 
            this.txt_ik.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ik.Location = new System.Drawing.Point(117, 15);
            this.txt_ik.Name = "txt_ik";
            this.txt_ik.Size = new System.Drawing.Size(288, 20);
            this.txt_ik.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Integration Key :";
            // 
            // txt_uid
            // 
            this.txt_uid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_uid.Location = new System.Drawing.Point(117, 128);
            this.txt_uid.Name = "txt_uid";
            this.txt_uid.Size = new System.Drawing.Size(288, 20);
            this.txt_uid.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "UserId :";
            // 
            // txt_accid
            // 
            this.txt_accid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_accid.Location = new System.Drawing.Point(117, 152);
            this.txt_accid.Name = "txt_accid";
            this.txt_accid.Size = new System.Drawing.Size(288, 20);
            this.txt_accid.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "AccountId";
            // 
            // txt_burl
            // 
            this.txt_burl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_burl.Location = new System.Drawing.Point(117, 176);
            this.txt_burl.Name = "txt_burl";
            this.txt_burl.Size = new System.Drawing.Size(288, 20);
            this.txt_burl.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "BaseUrl :";
            // 
            // txt_henv
            // 
            this.txt_henv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_henv.Location = new System.Drawing.Point(117, 201);
            this.txt_henv.Name = "txt_henv";
            this.txt_henv.Size = new System.Drawing.Size(288, 20);
            this.txt_henv.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Host Environment :";
            // 
            // txt_rsaprk
            // 
            this.txt_rsaprk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_rsaprk.Location = new System.Drawing.Point(117, 41);
            this.txt_rsaprk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_rsaprk.Name = "txt_rsaprk";
            this.txt_rsaprk.Size = new System.Drawing.Size(288, 39);
            this.txt_rsaprk.TabIndex = 35;
            this.txt_rsaprk.Text = "";
            // 
            // txt_rsapbk
            // 
            this.txt_rsapbk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_rsapbk.Location = new System.Drawing.Point(117, 84);
            this.txt_rsapbk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_rsapbk.Name = "txt_rsapbk";
            this.txt_rsapbk.Size = new System.Drawing.Size(288, 39);
            this.txt_rsapbk.TabIndex = 37;
            this.txt_rsapbk.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "RSA Public Key :";
            // 
            // Frm_DSParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 288);
            this.Controls.Add(this.txt_rsapbk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_rsaprk);
            this.Controls.Add(this.txt_henv);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_burl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_accid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_uid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txt_ik);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(444, 327);
            this.Name = "Frm_DSParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Docusign Parameter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txt_ik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_uid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_accid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_burl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_henv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox txt_rsaprk;
        private System.Windows.Forms.RichTextBox txt_rsapbk;
        private System.Windows.Forms.Label label4;
    }
}