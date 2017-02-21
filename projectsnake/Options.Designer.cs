namespace ProjectSnake
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.panelLevel = new System.Windows.Forms.Panel();
            this.rBtnMaster = new System.Windows.Forms.RadioButton();
            this.rBtnHard = new System.Windows.Forms.RadioButton();
            this.rBtnMedium = new System.Windows.Forms.RadioButton();
            this.rBtnEasy = new System.Windows.Forms.RadioButton();
            this.panelWalls = new System.Windows.Forms.Panel();
            this.rBtnWallsOff = new System.Windows.Forms.RadioButton();
            this.rBtnWallsOn = new System.Windows.Forms.RadioButton();
            this.btnAddOptions = new System.Windows.Forms.Button();
            this.panelLevel.SuspendLayout();
            this.panelWalls.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLevel
            // 
            this.panelLevel.BackColor = System.Drawing.Color.Transparent;
            this.panelLevel.Controls.Add(this.rBtnMaster);
            this.panelLevel.Controls.Add(this.rBtnHard);
            this.panelLevel.Controls.Add(this.rBtnMedium);
            this.panelLevel.Controls.Add(this.rBtnEasy);
            this.panelLevel.Location = new System.Drawing.Point(450, 1148);
            this.panelLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelLevel.Name = "panelLevel";
            this.panelLevel.Size = new System.Drawing.Size(200, 396);
            this.panelLevel.TabIndex = 3;
            // 
            // rBtnMaster
            // 
            this.rBtnMaster.AutoSize = true;
            this.rBtnMaster.Location = new System.Drawing.Point(4, 248);
            this.rBtnMaster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBtnMaster.Name = "rBtnMaster";
            this.rBtnMaster.Size = new System.Drawing.Size(27, 26);
            this.rBtnMaster.TabIndex = 3;
            this.rBtnMaster.TabStop = true;
            this.rBtnMaster.UseVisualStyleBackColor = true;
            // 
            // rBtnHard
            // 
            this.rBtnHard.AutoSize = true;
            this.rBtnHard.Location = new System.Drawing.Point(4, 167);
            this.rBtnHard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBtnHard.Name = "rBtnHard";
            this.rBtnHard.Size = new System.Drawing.Size(27, 26);
            this.rBtnHard.TabIndex = 2;
            this.rBtnHard.TabStop = true;
            this.rBtnHard.UseVisualStyleBackColor = true;
            // 
            // rBtnMedium
            // 
            this.rBtnMedium.AutoSize = true;
            this.rBtnMedium.Location = new System.Drawing.Point(4, 87);
            this.rBtnMedium.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBtnMedium.Name = "rBtnMedium";
            this.rBtnMedium.Size = new System.Drawing.Size(27, 26);
            this.rBtnMedium.TabIndex = 1;
            this.rBtnMedium.TabStop = true;
            this.rBtnMedium.UseVisualStyleBackColor = true;
            // 
            // rBtnEasy
            // 
            this.rBtnEasy.AutoSize = true;
            this.rBtnEasy.Checked = true;
            this.rBtnEasy.Location = new System.Drawing.Point(4, 4);
            this.rBtnEasy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBtnEasy.Name = "rBtnEasy";
            this.rBtnEasy.Size = new System.Drawing.Size(27, 26);
            this.rBtnEasy.TabIndex = 0;
            this.rBtnEasy.TabStop = true;
            this.rBtnEasy.UseVisualStyleBackColor = true;
            // 
            // panelWalls
            // 
            this.panelWalls.BackColor = System.Drawing.Color.Transparent;
            this.panelWalls.Controls.Add(this.rBtnWallsOff);
            this.panelWalls.Controls.Add(this.rBtnWallsOn);
            this.panelWalls.ForeColor = System.Drawing.Color.Black;
            this.panelWalls.Location = new System.Drawing.Point(450, 713);
            this.panelWalls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelWalls.Name = "panelWalls";
            this.panelWalls.Size = new System.Drawing.Size(38, 129);
            this.panelWalls.TabIndex = 2;
            // 
            // rBtnWallsOff
            // 
            this.rBtnWallsOff.AutoSize = true;
            this.rBtnWallsOff.Checked = true;
            this.rBtnWallsOff.Location = new System.Drawing.Point(4, 85);
            this.rBtnWallsOff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBtnWallsOff.Name = "rBtnWallsOff";
            this.rBtnWallsOff.Size = new System.Drawing.Size(27, 26);
            this.rBtnWallsOff.TabIndex = 1;
            this.rBtnWallsOff.TabStop = true;
            this.rBtnWallsOff.UseVisualStyleBackColor = true;
            // 
            // rBtnWallsOn
            // 
            this.rBtnWallsOn.AutoSize = true;
            this.rBtnWallsOn.Location = new System.Drawing.Point(4, 4);
            this.rBtnWallsOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rBtnWallsOn.Name = "rBtnWallsOn";
            this.rBtnWallsOn.Size = new System.Drawing.Size(27, 26);
            this.rBtnWallsOn.TabIndex = 0;
            this.rBtnWallsOn.UseVisualStyleBackColor = true;
            // 
            // btnAddOptions
            // 
            this.btnAddOptions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddOptions.BackgroundImage")));
            this.btnAddOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOptions.Location = new System.Drawing.Point(1268, 1282);
            this.btnAddOptions.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAddOptions.Name = "btnAddOptions";
            this.btnAddOptions.Size = new System.Drawing.Size(342, 124);
            this.btnAddOptions.TabIndex = 4;
            this.btnAddOptions.UseVisualStyleBackColor = true;
            this.btnAddOptions.Click += new System.EventHandler(this.btnAddOptions_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectSnake.Properties.Resources.bg_options;
            this.ClientSize = new System.Drawing.Size(1625, 1363);
            this.Controls.Add(this.btnAddOptions);
            this.Controls.Add(this.panelLevel);
            this.Controls.Add(this.panelWalls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Options_KeyDown);
            this.panelLevel.ResumeLayout(false);
            this.panelLevel.PerformLayout();
            this.panelWalls.ResumeLayout(false);
            this.panelWalls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLevel;
        private System.Windows.Forms.RadioButton rBtnMaster;
        private System.Windows.Forms.RadioButton rBtnHard;
        private System.Windows.Forms.RadioButton rBtnMedium;
        private System.Windows.Forms.RadioButton rBtnEasy;
        private System.Windows.Forms.Panel panelWalls;
        private System.Windows.Forms.RadioButton rBtnWallsOff;
        private System.Windows.Forms.RadioButton rBtnWallsOn;
        private System.Windows.Forms.Button btnAddOptions;
    }
}