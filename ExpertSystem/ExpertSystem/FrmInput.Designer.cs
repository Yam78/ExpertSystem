namespace ExpertSystem
{
    partial class FrmInput
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
            this.BtnRight = new System.Windows.Forms.Button();
            this.BtnMiddle = new System.Windows.Forms.Button();
            this.BtnLeft = new System.Windows.Forms.Button();
            this.LblHeader = new System.Windows.Forms.Label();
            this.TbInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnRight
            // 
            this.BtnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRight.Location = new System.Drawing.Point(228, 51);
            this.BtnRight.Name = "BtnRight";
            this.BtnRight.Size = new System.Drawing.Size(102, 36);
            this.BtnRight.TabIndex = 0;
            this.BtnRight.Text = "button1";
            this.BtnRight.UseVisualStyleBackColor = true;
            this.BtnRight.Click += new System.EventHandler(this.BtnRight_Click);
            // 
            // BtnMiddle
            // 
            this.BtnMiddle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMiddle.Location = new System.Drawing.Point(120, 51);
            this.BtnMiddle.Name = "BtnMiddle";
            this.BtnMiddle.Size = new System.Drawing.Size(102, 36);
            this.BtnMiddle.TabIndex = 1;
            this.BtnMiddle.Text = "button2";
            this.BtnMiddle.UseVisualStyleBackColor = true;
            this.BtnMiddle.Click += new System.EventHandler(this.BtnMiddle_Click);
            // 
            // BtnLeft
            // 
            this.BtnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLeft.Location = new System.Drawing.Point(12, 51);
            this.BtnLeft.Name = "BtnLeft";
            this.BtnLeft.Size = new System.Drawing.Size(102, 36);
            this.BtnLeft.TabIndex = 2;
            this.BtnLeft.Text = "button3";
            this.BtnLeft.UseVisualStyleBackColor = true;
            this.BtnLeft.Click += new System.EventHandler(this.BtnLeft_Click);
            // 
            // LblHeader
            // 
            this.LblHeader.AutoSize = true;
            this.LblHeader.Location = new System.Drawing.Point(12, 9);
            this.LblHeader.Name = "LblHeader";
            this.LblHeader.Size = new System.Drawing.Size(52, 13);
            this.LblHeader.TabIndex = 3;
            this.LblHeader.Text = "lblHeader";
            // 
            // TbInput
            // 
            this.TbInput.Location = new System.Drawing.Point(12, 25);
            this.TbInput.Name = "TbInput";
            this.TbInput.Size = new System.Drawing.Size(318, 20);
            this.TbInput.TabIndex = 4;
            // 
            // FrmInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 99);
            this.Controls.Add(this.TbInput);
            this.Controls.Add(this.LblHeader);
            this.Controls.Add(this.BtnLeft);
            this.Controls.Add(this.BtnMiddle);
            this.Controls.Add(this.BtnRight);
            this.Name = "FrmInput";
            this.Text = "Header";
            this.Load += new System.EventHandler(this.FrmInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRight;
        private System.Windows.Forms.Button BtnMiddle;
        private System.Windows.Forms.Button BtnLeft;
        private System.Windows.Forms.Label LblHeader;
        private System.Windows.Forms.TextBox TbInput;
    }
}