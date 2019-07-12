namespace ExpertSystem
{
    partial class FrmEditor
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
            this.lvChoices = new System.Windows.Forms.ListView();
            this.tbHeader = new System.Windows.Forms.TextBox();
            this.BtnAddChoice = new System.Windows.Forms.Button();
            this.BtnToParent = new System.Windows.Forms.Button();
            this.BtnEditChoice = new System.Windows.Forms.Button();
            this.btnDeleteChoice = new System.Windows.Forms.Button();
            this.BtnAddConclusion = new System.Windows.Forms.Button();
            this.BtnDeleteConclusion = new System.Windows.Forms.Button();
            this.lvConclusions = new System.Windows.Forms.ListView();
            this.BtnNextHeader = new System.Windows.Forms.Button();
            this.BtnValidate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tiedostoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MIExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MIImport = new System.Windows.Forms.ToolStripMenuItem();
            this.MIExit = new System.Windows.Forms.ToolStripMenuItem();
            this.näytäToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MITreeView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvChoices
            // 
            this.lvChoices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvChoices.AutoArrange = false;
            this.lvChoices.FullRowSelect = true;
            this.lvChoices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvChoices.HideSelection = false;
            this.lvChoices.Location = new System.Drawing.Point(12, 123);
            this.lvChoices.MultiSelect = false;
            this.lvChoices.Name = "lvChoices";
            this.lvChoices.Size = new System.Drawing.Size(352, 162);
            this.lvChoices.TabIndex = 1;
            this.lvChoices.UseCompatibleStateImageBehavior = false;
            this.lvChoices.View = System.Windows.Forms.View.Details;
            this.lvChoices.DoubleClick += new System.EventHandler(this.LvChoices_DoubleClick);
            // 
            // tbHeader
            // 
            this.tbHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHeader.Location = new System.Drawing.Point(12, 68);
            this.tbHeader.Multiline = true;
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.Size = new System.Drawing.Size(352, 36);
            this.tbHeader.TabIndex = 2;
            this.tbHeader.Leave += new System.EventHandler(this.TbHeader_Leave);
            // 
            // BtnAddChoice
            // 
            this.BtnAddChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddChoice.Location = new System.Drawing.Point(370, 123);
            this.BtnAddChoice.Name = "BtnAddChoice";
            this.BtnAddChoice.Size = new System.Drawing.Size(102, 36);
            this.BtnAddChoice.TabIndex = 3;
            this.BtnAddChoice.Text = "Lisää vaihtoehto";
            this.BtnAddChoice.UseVisualStyleBackColor = true;
            this.BtnAddChoice.Click += new System.EventHandler(this.BtnAddChoice_Click);
            // 
            // BtnToParent
            // 
            this.BtnToParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnToParent.Location = new System.Drawing.Point(370, 68);
            this.BtnToParent.Name = "BtnToParent";
            this.BtnToParent.Size = new System.Drawing.Size(102, 36);
            this.BtnToParent.TabIndex = 4;
            this.BtnToParent.Text = "Palaa edelliselle tasolle";
            this.BtnToParent.UseVisualStyleBackColor = true;
            this.BtnToParent.Click += new System.EventHandler(this.BtnToParent_Click);
            // 
            // BtnEditChoice
            // 
            this.BtnEditChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEditChoice.Location = new System.Drawing.Point(370, 165);
            this.BtnEditChoice.Name = "BtnEditChoice";
            this.BtnEditChoice.Size = new System.Drawing.Size(102, 36);
            this.BtnEditChoice.TabIndex = 3;
            this.BtnEditChoice.Text = "Muokkaa";
            this.BtnEditChoice.UseVisualStyleBackColor = true;
            this.BtnEditChoice.Click += new System.EventHandler(this.BtnEditChoice_Click);
            // 
            // btnDeleteChoice
            // 
            this.btnDeleteChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteChoice.Location = new System.Drawing.Point(370, 207);
            this.btnDeleteChoice.Name = "btnDeleteChoice";
            this.btnDeleteChoice.Size = new System.Drawing.Size(102, 36);
            this.btnDeleteChoice.TabIndex = 10;
            this.btnDeleteChoice.Text = "Poista vaihtoehto";
            this.btnDeleteChoice.Click += new System.EventHandler(this.BtnDeleteChoice_Click_1);
            // 
            // BtnAddConclusion
            // 
            this.BtnAddConclusion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddConclusion.Location = new System.Drawing.Point(370, 304);
            this.BtnAddConclusion.Name = "BtnAddConclusion";
            this.BtnAddConclusion.Size = new System.Drawing.Size(102, 36);
            this.BtnAddConclusion.TabIndex = 6;
            this.BtnAddConclusion.Text = "Lisää päätelmä";
            this.BtnAddConclusion.UseVisualStyleBackColor = true;
            this.BtnAddConclusion.Click += new System.EventHandler(this.BtnAddConclusion_Click);
            // 
            // BtnDeleteConclusion
            // 
            this.BtnDeleteConclusion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDeleteConclusion.Location = new System.Drawing.Point(370, 346);
            this.BtnDeleteConclusion.Name = "BtnDeleteConclusion";
            this.BtnDeleteConclusion.Size = new System.Drawing.Size(102, 36);
            this.BtnDeleteConclusion.TabIndex = 7;
            this.BtnDeleteConclusion.Text = "Poista päätelmä";
            this.BtnDeleteConclusion.UseVisualStyleBackColor = true;
            this.BtnDeleteConclusion.Click += new System.EventHandler(this.BtnDeleteConclusion_Click);
            // 
            // lvConclusions
            // 
            this.lvConclusions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConclusions.FullRowSelect = true;
            this.lvConclusions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvConclusions.HideSelection = false;
            this.lvConclusions.Location = new System.Drawing.Point(12, 304);
            this.lvConclusions.Name = "lvConclusions";
            this.lvConclusions.Size = new System.Drawing.Size(352, 120);
            this.lvConclusions.TabIndex = 5;
            this.lvConclusions.UseCompatibleStateImageBehavior = false;
            // 
            // BtnNextHeader
            // 
            this.BtnNextHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNextHeader.Location = new System.Drawing.Point(370, 249);
            this.BtnNextHeader.Name = "BtnNextHeader";
            this.BtnNextHeader.Size = new System.Drawing.Size(102, 36);
            this.BtnNextHeader.TabIndex = 3;
            this.BtnNextHeader.Text = "Lisää seuraava taso";
            this.BtnNextHeader.UseVisualStyleBackColor = true;
            this.BtnNextHeader.Click += new System.EventHandler(this.BtnNextHeader_Click);
            // 
            // BtnValidate
            // 
            this.BtnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnValidate.Location = new System.Drawing.Point(370, 388);
            this.BtnValidate.Name = "BtnValidate";
            this.BtnValidate.Size = new System.Drawing.Size(102, 36);
            this.BtnValidate.TabIndex = 8;
            this.BtnValidate.Text = "Validoi sääntöpuu";
            this.BtnValidate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Otsikko / kysymys";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Vaihtoehdot";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Johtopäätökset / ehdotukset";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiedostoToolStripMenuItem,
            this.näytäToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tiedostoToolStripMenuItem
            // 
            this.tiedostoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIExport,
            this.MIImport,
            this.MIExit});
            this.tiedostoToolStripMenuItem.Name = "tiedostoToolStripMenuItem";
            this.tiedostoToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.tiedostoToolStripMenuItem.Text = "Tiedosto";
            // 
            // MIExport
            // 
            this.MIExport.Name = "MIExport";
            this.MIExport.Size = new System.Drawing.Size(180, 22);
            this.MIExport.Text = "Vie xml...";
            this.MIExport.Click += new System.EventHandler(this.MIExport_Click);
            // 
            // MIImport
            // 
            this.MIImport.Name = "MIImport";
            this.MIImport.Size = new System.Drawing.Size(180, 22);
            this.MIImport.Text = "Tuo xml...";
            // 
            // MIExit
            // 
            this.MIExit.Name = "MIExit";
            this.MIExit.Size = new System.Drawing.Size(180, 22);
            this.MIExit.Text = "Lopeta";
            this.MIExit.Click += new System.EventHandler(this.MIExit_Click);
            // 
            // näytäToolStripMenuItem
            // 
            this.näytäToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MITreeView});
            this.näytäToolStripMenuItem.Name = "näytäToolStripMenuItem";
            this.näytäToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.näytäToolStripMenuItem.Text = "Näytä";
            // 
            // MITreeView
            // 
            this.MITreeView.Name = "MITreeView";
            this.MITreeView.Size = new System.Drawing.Size(137, 22);
            this.MITreeView.Text = "Puunäkymä";
            this.MITreeView.Click += new System.EventHandler(this.MITreeView_Click);
            // 
            // FrmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 436);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnValidate);
            this.Controls.Add(this.BtnAddConclusion);
            this.Controls.Add(this.BtnDeleteConclusion);
            this.Controls.Add(this.lvConclusions);
            this.Controls.Add(this.BtnToParent);
            this.Controls.Add(this.BtnEditChoice);
            this.Controls.Add(this.BtnNextHeader);
            this.Controls.Add(this.btnDeleteChoice);
            this.Controls.Add(this.BtnAddChoice);
            this.Controls.Add(this.tbHeader);
            this.Controls.Add(this.lvChoices);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1000, 475);
            this.MinimumSize = new System.Drawing.Size(500, 475);
            this.Name = "FrmEditor";
            this.Text = "ExpertSystem";
            this.Load += new System.EventHandler(this.FrmEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvChoices;
        private System.Windows.Forms.TextBox tbHeader;
        private System.Windows.Forms.Button BtnAddChoice;
        private System.Windows.Forms.Button BtnToParent;
        private System.Windows.Forms.Button BtnEditChoice;
        private System.Windows.Forms.Button btnDeleteChoice;
        private System.Windows.Forms.Button BtnAddConclusion;
        private System.Windows.Forms.Button BtnDeleteConclusion;
        private System.Windows.Forms.ListView lvConclusions;
        private System.Windows.Forms.Button BtnNextHeader;
        private System.Windows.Forms.Button BtnValidate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tiedostoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MIExport;
        private System.Windows.Forms.ToolStripMenuItem MIImport;
        private System.Windows.Forms.ToolStripMenuItem MIExit;
        private System.Windows.Forms.ToolStripMenuItem näytäToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MITreeView;
    }
}
