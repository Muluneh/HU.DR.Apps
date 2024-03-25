namespace HU.DR.GUI.Aps
{
    partial class frmDR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDR));
            this.picOrigianal = new System.Windows.Forms.PictureBox();
            this.picProcessed = new System.Windows.Forms.PictureBox();
            this.menuDR = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cBRCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMYKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textureFutureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.machineLearningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sVMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nN1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nN2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nN3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.InfoPan = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.infoList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picOrigianal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessed)).BeginInit();
            this.menuDR.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.InfoPan.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // picOrigianal
            // 
            this.picOrigianal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picOrigianal.BackColor = System.Drawing.SystemColors.Window;
            this.picOrigianal.Location = new System.Drawing.Point(0, 0);
            this.picOrigianal.Name = "picOrigianal";
            this.picOrigianal.Size = new System.Drawing.Size(283, 59);
            this.picOrigianal.TabIndex = 0;
            this.picOrigianal.TabStop = false;
            // 
            // picProcessed
            // 
            this.picProcessed.BackColor = System.Drawing.SystemColors.Window;
            this.picProcessed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picProcessed.Location = new System.Drawing.Point(0, 0);
            this.picProcessed.Name = "picProcessed";
            this.picProcessed.Size = new System.Drawing.Size(210, 210);
            this.picProcessed.TabIndex = 1;
            this.picProcessed.TabStop = false;
            this.picProcessed.Click += new System.EventHandler(this.picProcessed_Click);
            // 
            // menuDR
            // 
            this.menuDR.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuDR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDR.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.machineLearningToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuDR.Location = new System.Drawing.Point(0, 0);
            this.menuDR.Name = "menuDR";
            this.menuDR.Size = new System.Drawing.Size(810, 24);
            this.menuDR.TabIndex = 9;
            this.menuDR.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contrastToolStripMenuItem,
            this.brightnesToolStripMenuItem,
            this.gammaToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // contrastToolStripMenuItem
            // 
            this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
            this.contrastToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.contrastToolStripMenuItem.Text = "Contrast";
            // 
            // brightnesToolStripMenuItem
            // 
            this.brightnesToolStripMenuItem.Name = "brightnesToolStripMenuItem";
            this.brightnesToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.brightnesToolStripMenuItem.Text = "Brightness";
            this.brightnesToolStripMenuItem.Click += new System.EventHandler(this.brightnesToolStripMenuItem_Click);
            // 
            // gammaToolStripMenuItem
            // 
            this.gammaToolStripMenuItem.Name = "gammaToolStripMenuItem";
            this.gammaToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.gammaToolStripMenuItem.Text = "Gamma";
            this.gammaToolStripMenuItem.Click += new System.EventHandler(this.gammaToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gLMToolStripMenuItem,
            this.cBRCToolStripMenuItem,
            this.cMYKToolStripMenuItem,
            this.grayToolStripMenuItem,
            this.textureFutureToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.viewToolStripMenuItem.Text = "Tool";
            // 
            // gLMToolStripMenuItem
            // 
            this.gLMToolStripMenuItem.Name = "gLMToolStripMenuItem";
            this.gLMToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.gLMToolStripMenuItem.Text = "GLM";
            this.gLMToolStripMenuItem.Click += new System.EventHandler(this.gLMToolStripMenuItem_Click);
            // 
            // cBRCToolStripMenuItem
            // 
            this.cBRCToolStripMenuItem.Name = "cBRCToolStripMenuItem";
            this.cBRCToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.cBRCToolStripMenuItem.Text = "CBRC";
            this.cBRCToolStripMenuItem.Click += new System.EventHandler(this.cBRCToolStripMenuItem_Click);
            // 
            // cMYKToolStripMenuItem
            // 
            this.cMYKToolStripMenuItem.Name = "cMYKToolStripMenuItem";
            this.cMYKToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.cMYKToolStripMenuItem.Text = "CMYK";
            this.cMYKToolStripMenuItem.Click += new System.EventHandler(this.cMYKToolStripMenuItem_Click);
            // 
            // grayToolStripMenuItem
            // 
            this.grayToolStripMenuItem.Name = "grayToolStripMenuItem";
            this.grayToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.grayToolStripMenuItem.Text = "Gray";
            this.grayToolStripMenuItem.Click += new System.EventHandler(this.grayToolStripMenuItem_Click);
            // 
            // textureFutureToolStripMenuItem
            // 
            this.textureFutureToolStripMenuItem.Name = "textureFutureToolStripMenuItem";
            this.textureFutureToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.textureFutureToolStripMenuItem.Text = "Extract Texture Feature";
            this.textureFutureToolStripMenuItem.Click += new System.EventHandler(this.textureFutureToolStripMenuItem_Click);
            // 
            // machineLearningToolStripMenuItem
            // 
            this.machineLearningToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sVMToolStripMenuItem,
            this.neuToolStripMenuItem});
            this.machineLearningToolStripMenuItem.Name = "machineLearningToolStripMenuItem";
            this.machineLearningToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.machineLearningToolStripMenuItem.Text = "Machine Learning";
            // 
            // sVMToolStripMenuItem
            // 
            this.sVMToolStripMenuItem.Name = "sVMToolStripMenuItem";
            this.sVMToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.sVMToolStripMenuItem.Text = "SVM";
            this.sVMToolStripMenuItem.Click += new System.EventHandler(this.sVMToolStripMenuItem_Click);
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nN1ToolStripMenuItem,
            this.nN2ToolStripMenuItem,
            this.nN3ToolStripMenuItem});
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.neuToolStripMenuItem.Text = "Neural Network";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // nN1ToolStripMenuItem
            // 
            this.nN1ToolStripMenuItem.Name = "nN1ToolStripMenuItem";
            this.nN1ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.nN1ToolStripMenuItem.Text = "NN1";
            this.nN1ToolStripMenuItem.Click += new System.EventHandler(this.nN1ToolStripMenuItem_Click);
            // 
            // nN2ToolStripMenuItem
            // 
            this.nN2ToolStripMenuItem.Name = "nN2ToolStripMenuItem";
            this.nN2ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.nN2ToolStripMenuItem.Text = "NN2";
            this.nN2ToolStripMenuItem.Click += new System.EventHandler(this.nN2ToolStripMenuItem_Click);
            // 
            // nN3ToolStripMenuItem
            // 
            this.nN3ToolStripMenuItem.Name = "nN3ToolStripMenuItem";
            this.nN3ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.nN3ToolStripMenuItem.Text = "NN3";
            this.nN3ToolStripMenuItem.Click += new System.EventHandler(this.nN3ToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.picOrigianal);
            this.panel1.Location = new System.Drawing.Point(0, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 210);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.picProcessed);
            this.panel2.Location = new System.Drawing.Point(289, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 210);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Location = new System.Drawing.Point(505, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(304, 210);
            this.panel3.TabIndex = 12;
            // 
            // InfoPan
            // 
            this.InfoPan.BackColor = System.Drawing.SystemColors.Info;
            this.InfoPan.Controls.Add(this.infoList);
            this.InfoPan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InfoPan.Location = new System.Drawing.Point(0, 319);
            this.InfoPan.Name = "InfoPan";
            this.InfoPan.Size = new System.Drawing.Size(810, 121);
            this.InfoPan.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(810, 73);
            this.panel5.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(810, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // infoList
            // 
            this.infoList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infoList.FormattingEnabled = true;
            this.infoList.Location = new System.Drawing.Point(0, 0);
            this.infoList.Name = "infoList";
            this.infoList.ScrollAlwaysVisible = true;
            this.infoList.Size = new System.Drawing.Size(810, 121);
            this.infoList.TabIndex = 0;
            // 
            // frmDR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 440);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.InfoPan);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuDR);
            this.MainMenuStrip = this.menuDR;
            this.Name = "frmDR";
            this.Text = "HU.DR.API";
            this.Load += new System.EventHandler(this.frmDR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOrigianal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessed)).EndInit();
            this.menuDR.ResumeLayout(false);
            this.menuDR.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.InfoPan.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOrigianal;
        private System.Windows.Forms.PictureBox picProcessed;
        private System.Windows.Forms.MenuStrip menuDR;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cBRCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cMYKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textureFutureToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel InfoPan;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripMenuItem machineLearningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sVMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nN1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nN2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nN3ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gammaToolStripMenuItem;
        private System.Windows.Forms.ListBox infoList;
    }
}

