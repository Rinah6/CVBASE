namespace CVBASESWISS
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.parameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docusignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authenticationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nbMailInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEQUESTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCMailAddressCVUpdateMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swichDatasetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.swichDatasetToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.rankingYearsExperienceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jUNIORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sENIORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rankingDiplomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datasetConnexionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridListe = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListe)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parameterToolStripMenuItem,
            this.dataEntryToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.dataSearchToolStripMenuItem,
            this.mailingToolStripMenuItem,
            this.swichDatasetToolStripMenuItem1,
            this.swichDatasetToolStripMenuItem2,
            this.datasetConnexionToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // parameterToolStripMenuItem
            // 
            this.parameterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManagementToolStripMenuItem,
            this.superAdminToolStripMenuItem,
            this.docusignToolStripMenuItem});
            this.parameterToolStripMenuItem.Name = "parameterToolStripMenuItem";
            this.parameterToolStripMenuItem.Size = new System.Drawing.Size(70, 26);
            this.parameterToolStripMenuItem.Text = "Setting";
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.userManagementToolStripMenuItem.Text = "User Management";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // superAdminToolStripMenuItem
            // 
            this.superAdminToolStripMenuItem.Name = "superAdminToolStripMenuItem";
            this.superAdminToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.superAdminToolStripMenuItem.Text = "Authorisation";
            this.superAdminToolStripMenuItem.Click += new System.EventHandler(this.superAdminToolStripMenuItem_Click);
            // 
            // docusignToolStripMenuItem
            // 
            this.docusignToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authenticationToolStripMenuItem,
            this.modelToolStripMenuItem1});
            this.docusignToolStripMenuItem.Name = "docusignToolStripMenuItem";
            this.docusignToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.docusignToolStripMenuItem.Text = "Docusign";
            // 
            // authenticationToolStripMenuItem
            // 
            this.authenticationToolStripMenuItem.Name = "authenticationToolStripMenuItem";
            this.authenticationToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.authenticationToolStripMenuItem.Text = "Authentication";
            this.authenticationToolStripMenuItem.Click += new System.EventHandler(this.authenticationToolStripMenuItem_Click);
            // 
            // modelToolStripMenuItem1
            // 
            this.modelToolStripMenuItem1.Name = "modelToolStripMenuItem1";
            this.modelToolStripMenuItem1.Size = new System.Drawing.Size(189, 26);
            this.modelToolStripMenuItem1.Text = "Model";
            this.modelToolStripMenuItem1.Click += new System.EventHandler(this.modelToolStripMenuItem1_Click);
            // 
            // dataEntryToolStripMenuItem
            // 
            this.dataEntryToolStripMenuItem.Name = "dataEntryToolStripMenuItem";
            this.dataEntryToolStripMenuItem.Size = new System.Drawing.Size(92, 26);
            this.dataEntryToolStripMenuItem.Text = "Data Entry";
            this.dataEntryToolStripMenuItem.Click += new System.EventHandler(this.dataEntryToolStripMenuItem_Click);
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(96, 26);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // dataSearchToolStripMenuItem
            // 
            this.dataSearchToolStripMenuItem.Name = "dataSearchToolStripMenuItem";
            this.dataSearchToolStripMenuItem.Size = new System.Drawing.Size(103, 26);
            this.dataSearchToolStripMenuItem.Text = "Data Search";
            this.dataSearchToolStripMenuItem.Click += new System.EventHandler(this.dataSearchToolStripMenuItem_Click);
            // 
            // mailingToolStripMenuItem
            // 
            this.mailingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modelToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.nbMailInToolStripMenuItem,
            this.rEQUESTToolStripMenuItem,
            this.cCMailAddressCVUpdateMessageToolStripMenuItem});
            this.mailingToolStripMenuItem.Name = "mailingToolStripMenuItem";
            this.mailingToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.mailingToolStripMenuItem.Text = "Request Update CV";
            // 
            // modelToolStripMenuItem
            // 
            this.modelToolStripMenuItem.Name = "modelToolStripMenuItem";
            this.modelToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.modelToolStripMenuItem.Text = "Log";
            this.modelToolStripMenuItem.Click += new System.EventHandler(this.modelToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.historyToolStripMenuItem.Text = "Model";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // nbMailInToolStripMenuItem
            // 
            this.nbMailInToolStripMenuItem.Name = "nbMailInToolStripMenuItem";
            this.nbMailInToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.nbMailInToolStripMenuItem.Text = "Nb. e-mail per batch";
            this.nbMailInToolStripMenuItem.Click += new System.EventHandler(this.nbMailInToolStripMenuItem_Click);
            // 
            // rEQUESTToolStripMenuItem
            // 
            this.rEQUESTToolStripMenuItem.Name = "rEQUESTToolStripMenuItem";
            this.rEQUESTToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.rEQUESTToolStripMenuItem.Text = "REQUEST";
            this.rEQUESTToolStripMenuItem.Click += new System.EventHandler(this.rEQUESTToolStripMenuItem_Click);
            // 
            // cCMailAddressCVUpdateMessageToolStripMenuItem
            // 
            this.cCMailAddressCVUpdateMessageToolStripMenuItem.Name = "cCMailAddressCVUpdateMessageToolStripMenuItem";
            this.cCMailAddressCVUpdateMessageToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.cCMailAddressCVUpdateMessageToolStripMenuItem.Text = "CC mail address (CV update message)";
            this.cCMailAddressCVUpdateMessageToolStripMenuItem.Click += new System.EventHandler(this.cCMailAddressCVUpdateMessageToolStripMenuItem_Click);
            // 
            // swichDatasetToolStripMenuItem1
            // 
            this.swichDatasetToolStripMenuItem1.Name = "swichDatasetToolStripMenuItem1";
            this.swichDatasetToolStripMenuItem1.Size = new System.Drawing.Size(132, 26);
            this.swichDatasetToolStripMenuItem1.Text = "Data Warehouse";
            this.swichDatasetToolStripMenuItem1.Click += new System.EventHandler(this.swichDatasetToolStripMenuItem1_Click);
            // 
            // swichDatasetToolStripMenuItem2
            // 
            this.swichDatasetToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rankingYearsExperienceToolStripMenuItem,
            this.rankingDiplomaToolStripMenuItem,
            this.setupCategoriesToolStripMenuItem});
            this.swichDatasetToolStripMenuItem2.Name = "swichDatasetToolStripMenuItem2";
            this.swichDatasetToolStripMenuItem2.Size = new System.Drawing.Size(116, 26);
            this.swichDatasetToolStripMenuItem2.Text = "Swich Dataset";
            // 
            // rankingYearsExperienceToolStripMenuItem
            // 
            this.rankingYearsExperienceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jUNIORToolStripMenuItem,
            this.sENIORToolStripMenuItem});
            this.rankingYearsExperienceToolStripMenuItem.Name = "rankingYearsExperienceToolStripMenuItem";
            this.rankingYearsExperienceToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.rankingYearsExperienceToolStripMenuItem.Text = "Ranking for Years Exp.";
            // 
            // jUNIORToolStripMenuItem
            // 
            this.jUNIORToolStripMenuItem.Name = "jUNIORToolStripMenuItem";
            this.jUNIORToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.jUNIORToolStripMenuItem.Text = "JUNIOR";
            this.jUNIORToolStripMenuItem.Click += new System.EventHandler(this.jUNIORToolStripMenuItem_Click);
            // 
            // sENIORToolStripMenuItem
            // 
            this.sENIORToolStripMenuItem.Name = "sENIORToolStripMenuItem";
            this.sENIORToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.sENIORToolStripMenuItem.Text = "SENIOR";
            this.sENIORToolStripMenuItem.Click += new System.EventHandler(this.sENIORToolStripMenuItem_Click);
            // 
            // rankingDiplomaToolStripMenuItem
            // 
            this.rankingDiplomaToolStripMenuItem.Name = "rankingDiplomaToolStripMenuItem";
            this.rankingDiplomaToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.rankingDiplomaToolStripMenuItem.Text = "Ranking for Diploma";
            this.rankingDiplomaToolStripMenuItem.Click += new System.EventHandler(this.rankingDiplomaToolStripMenuItem_Click);
            // 
            // setupCategoriesToolStripMenuItem
            // 
            this.setupCategoriesToolStripMenuItem.Name = "setupCategoriesToolStripMenuItem";
            this.setupCategoriesToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.setupCategoriesToolStripMenuItem.Text = "Setup Categories";
            this.setupCategoriesToolStripMenuItem.Click += new System.EventHandler(this.setupCategoriesToolStripMenuItem_Click);
            // 
            // datasetConnexionToolStripMenuItem1
            // 
            this.datasetConnexionToolStripMenuItem1.Name = "datasetConnexionToolStripMenuItem1";
            this.datasetConnexionToolStripMenuItem1.Size = new System.Drawing.Size(153, 26);
            this.datasetConnexionToolStripMenuItem1.Text = "Dataset Connection";
            this.datasetConnexionToolStripMenuItem1.Click += new System.EventHandler(this.datasetConnexionToolStripMenuItem1_Click);
            // 
            // gridListe
            // 
            this.gridListe.AllowUserToAddRows = false;
            this.gridListe.AllowUserToDeleteRows = false;
            this.gridListe.AllowUserToOrderColumns = true;
            this.gridListe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridListe.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridListe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListe.Location = new System.Drawing.Point(0, 73);
            this.gridListe.Margin = new System.Windows.Forms.Padding(4);
            this.gridListe.Name = "gridListe";
            this.gridListe.ReadOnly = true;
            this.gridListe.RowHeadersWidth = 51;
            this.gridListe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridListe.Size = new System.Drawing.Size(1800, 766);
            this.gridListe.TabIndex = 1;
            this.gridListe.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridListe_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.label1.MaximumSize = new System.Drawing.Size(81, 18);
            this.label1.MinimumSize = new System.Drawing.Size(55, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 4);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.MaxLength = 500;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(323, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.95238F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 889F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 489F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1800, 36);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(1314, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(482, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "You are connected to the ... data set.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Location = new System.Drawing.Point(425, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1535, 842);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "CV BASE";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1612, 842);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Version 4.2.2d";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1703, 843);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "29/12/2022";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 842);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "User : ";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(773, 842);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Number of records in the Database : ";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 842);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Authorisation";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 887);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.gridListe);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(5114, 2644);
            this.MinimumSize = new System.Drawing.Size(1813, 921);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CVBASE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListe)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem parameterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mailingToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView gridListe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem swichDatasetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem swichDatasetToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem rankingYearsExperienceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jUNIORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sENIORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rankingDiplomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem superAdminToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem datasetConnexionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEQUESTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nbMailInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docusignToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authenticationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cCMailAddressCVUpdateMessageToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}

