namespace cm
{
    partial class CMForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMForm));
            this.pictureBox_G = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Start = new System.Windows.Forms.ToolStripButton();
            this.btn_Clear = new System.Windows.Forms.ToolStripButton();
            this.btn_Pause = new System.Windows.Forms.ToolStripButton();
            this.btn_Settings = new System.Windows.Forms.ToolStripButton();
            this.btn_Save = new System.Windows.Forms.ToolStripButton();
            this.btn_Help = new System.Windows.Forms.ToolStripButton();
            this.btn_Exit = new System.Windows.Forms.ToolStripButton();
            this.btn_Status = new System.Windows.Forms.ToolStripButton();
            this.label_Ia = new System.Windows.Forms.Label();
            this.label_Uab = new System.Windows.Forms.Label();
            this.label_Uc = new System.Windows.Forms.Label();
            this.label_Ic = new System.Windows.Forms.Label();
            this.label_Ib = new System.Windows.Forms.Label();
            this.label_TC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_G)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_G
            // 
            this.pictureBox_G.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_G.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox_G.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_G.Location = new System.Drawing.Point(0, 87);
            this.pictureBox_G.Name = "pictureBox_G";
            this.pictureBox_G.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.pictureBox_G.Size = new System.Drawing.Size(1082, 653);
            this.pictureBox_G.TabIndex = 1;
            this.pictureBox_G.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Start,
            this.btn_Clear,
            this.btn_Pause,
            this.btn_Settings,
            this.btn_Save,
            this.btn_Help,
            this.btn_Exit,
            this.btn_Status});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1082, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_Start
            // 
            this.btn_Start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Start.Image = ((System.Drawing.Image)(resources.GetObject("btn_Start.Image")));
            this.btn_Start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(23, 22);
            this.btn_Start.Text = "Start";
            this.btn_Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Clear.Image = ((System.Drawing.Image)(resources.GetObject("btn_Clear.Image")));
            this.btn_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(23, 22);
            this.btn_Clear.Text = "Reset";
            this.btn_Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // btn_Pause
            // 
            this.btn_Pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Pause.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pause.Image")));
            this.btn_Pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(23, 22);
            this.btn_Pause.Text = "Pause";
            this.btn_Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // btn_Settings
            // 
            this.btn_Settings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Settings.Image = ((System.Drawing.Image)(resources.GetObject("btn_Settings.Image")));
            this.btn_Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(23, 22);
            this.btn_Settings.Text = "Settings";
            this.btn_Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(23, 22);
            this.btn_Save.Text = "Save";
            this.btn_Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // btn_Help
            // 
            this.btn_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Help.Image = ((System.Drawing.Image)(resources.GetObject("btn_Help.Image")));
            this.btn_Help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(23, 22);
            this.btn_Help.Text = "About";
            this.btn_Help.Click += new System.EventHandler(this.About_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
            this.btn_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(23, 22);
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // btn_Status
            // 
            this.btn_Status.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Status.Image = ((System.Drawing.Image)(resources.GetObject("btn_Status.Image")));
            this.btn_Status.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Status.Name = "btn_Status";
            this.btn_Status.Size = new System.Drawing.Size(23, 22);
            this.btn_Status.Text = "Status";
            this.btn_Status.ToolTipText = "Status";
            this.btn_Status.Visible = false;
            // 
            // label_Ia
            // 
            this.label_Ia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Ia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Ia.Location = new System.Drawing.Point(12, 38);
            this.label_Ia.Name = "label_Ia";
            this.label_Ia.Size = new System.Drawing.Size(160, 46);
            this.label_Ia.TabIndex = 3;
            this.label_Ia.Text = "I: ";
            this.label_Ia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Uab
            // 
            this.label_Uab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Uab.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Uab.Location = new System.Drawing.Point(177, 38);
            this.label_Uab.Name = "label_Uab";
            this.label_Uab.Size = new System.Drawing.Size(160, 46);
            this.label_Uab.TabIndex = 4;
            this.label_Uab.Text = "U: ";
            this.label_Uab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Uc
            // 
            this.label_Uc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Uc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Uc.Location = new System.Drawing.Point(750, 38);
            this.label_Uc.Name = "label_Uc";
            this.label_Uc.Size = new System.Drawing.Size(160, 46);
            this.label_Uc.TabIndex = 5;
            this.label_Uc.Text = "Uc: ";
            this.label_Uc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Ic
            // 
            this.label_Ic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Ic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Ic.Location = new System.Drawing.Point(385, 38);
            this.label_Ic.Name = "label_Ic";
            this.label_Ic.Size = new System.Drawing.Size(160, 23);
            this.label_Ic.TabIndex = 6;
            this.label_Ic.Text = "Ic: ";
            this.label_Ic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Ib
            // 
            this.label_Ib.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Ib.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Ib.Location = new System.Drawing.Point(385, 61);
            this.label_Ib.Name = "label_Ib";
            this.label_Ib.Size = new System.Drawing.Size(160, 23);
            this.label_Ib.TabIndex = 7;
            this.label_Ib.Text = "Ib: ";
            this.label_Ib.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_TC
            // 
            this.label_TC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_TC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_TC.Location = new System.Drawing.Point(551, 38);
            this.label_TC.Name = "label_TC";
            this.label_TC.Size = new System.Drawing.Size(160, 46);
            this.label_TC.TabIndex = 8;
            this.label_TC.Text = "Ktt: ";
            this.label_TC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 738);
            this.Controls.Add(this.label_TC);
            this.Controls.Add(this.label_Ib);
            this.Controls.Add(this.label_Ic);
            this.Controls.Add(this.label_Uc);
            this.Controls.Add(this.label_Uab);
            this.Controls.Add(this.label_Ia);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox_G);
            this.Name = "CMForm";
            this.Text = "GLAZ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CMForm_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_G)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox_G;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_Start;
        private System.Windows.Forms.ToolStripButton btn_Settings;
        private System.Windows.Forms.ToolStripButton btn_Exit;
        private System.Windows.Forms.Label label_Ia;
        private System.Windows.Forms.Label label_Uab;
        private System.Windows.Forms.Label label_Uc;
        private System.Windows.Forms.Label label_Ic;
        private System.Windows.Forms.ToolStripButton btn_Pause;
        private System.Windows.Forms.ToolStripButton btn_Save;
        private System.Windows.Forms.ToolStripButton btn_Clear;
        private System.Windows.Forms.ToolStripButton btn_Help;
        private System.Windows.Forms.Label label_Ib;
        private System.Windows.Forms.Label label_TC;
        private System.Windows.Forms.ToolStripButton btn_Status;
    }
}

