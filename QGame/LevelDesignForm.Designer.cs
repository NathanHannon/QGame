using System.Windows.Forms;
namespace QGame
{
    partial class LevelDesignForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelDesignForm));
            this.strpMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnToMainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.lblRows = new System.Windows.Forms.Label();
            this.lblColumns = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.grpToolbox = new System.Windows.Forms.GroupBox();
            this.btnYellowExit = new System.Windows.Forms.Button();
            this.btnYellowSquare = new System.Windows.Forms.Button();
            this.btnGreenExit = new System.Windows.Forms.Button();
            this.btnGreenSquare = new System.Windows.Forms.Button();
            this.btnBlueExit = new System.Windows.Forms.Button();
            this.btnBlueSquare = new System.Windows.Forms.Button();
            this.btnRedExit = new System.Windows.Forms.Button();
            this.btnRedSquare = new System.Windows.Forms.Button();
            this.btnBrickWall = new System.Windows.Forms.Button();
            this.btnBlank = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.strpMenu.SuspendLayout();
            this.grpToolbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // strpMenu
            // 
            this.strpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.strpMenu.Location = new System.Drawing.Point(0, 0);
            this.strpMenu.Name = "strpMenu";
            this.strpMenu.Size = new System.Drawing.Size(800, 24);
            this.strpMenu.TabIndex = 0;
            this.strpMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.returnToMainMenuToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveToolStripMenuItem.Text = "Save Level";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveLevelToolStripMenuItem_Click);
            // 
            // returnToMainMenuToolStripMenuItem
            // 
            this.returnToMainMenuToolStripMenuItem.Name = "returnToMainMenuToolStripMenuItem";
            this.returnToMainMenuToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.returnToMainMenuToolStripMenuItem.Text = "Return to Main Menu";
            this.returnToMainMenuToolStripMenuItem.Click += new System.EventHandler(this.returnToMainMenuToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.closeToolStripMenuItem.Text = "Close Program";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dlgSave
            // 
            this.dlgSave.Title = "Save Game";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(15, 40);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(100, 20);
            this.txtRows.TabIndex = 5;
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(130, 40);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(100, 20);
            this.txtColumns.TabIndex = 2;
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(12, 24);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(37, 13);
            this.lblRows.TabIndex = 3;
            this.lblRows.Text = "Rows:";
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(127, 24);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(50, 13);
            this.lblColumns.TabIndex = 4;
            this.lblColumns.Text = "Columns:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(268, 27);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(129, 33);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // grpToolbox
            // 
            this.grpToolbox.Controls.Add(this.btnYellowExit);
            this.grpToolbox.Controls.Add(this.btnYellowSquare);
            this.grpToolbox.Controls.Add(this.btnGreenExit);
            this.grpToolbox.Controls.Add(this.btnGreenSquare);
            this.grpToolbox.Controls.Add(this.btnBlueExit);
            this.grpToolbox.Controls.Add(this.btnBlueSquare);
            this.grpToolbox.Controls.Add(this.btnRedExit);
            this.grpToolbox.Controls.Add(this.btnRedSquare);
            this.grpToolbox.Controls.Add(this.btnBrickWall);
            this.grpToolbox.Controls.Add(this.btnBlank);
            this.grpToolbox.Location = new System.Drawing.Point(12, 66);
            this.grpToolbox.Name = "grpToolbox";
            this.grpToolbox.Size = new System.Drawing.Size(139, 348);
            this.grpToolbox.TabIndex = 10;
            this.grpToolbox.TabStop = false;
            this.grpToolbox.Text = "Toolbox";
            // 
            // btnYellowExit
            // 
            this.btnYellowExit.BackColor = System.Drawing.Color.White;
            this.btnYellowExit.Image = global::QGame.Properties.Resources.exit_yellow;
            this.btnYellowExit.Location = new System.Drawing.Point(72, 283);
            this.btnYellowExit.Name = "btnYellowExit";
            this.btnYellowExit.Size = new System.Drawing.Size(60, 60);
            this.btnYellowExit.TabIndex = 16;
            this.btnYellowExit.UseVisualStyleBackColor = false;
            this.btnYellowExit.Click += new System.EventHandler(this.btnYellowExit_Click);
            // 
            // btnYellowSquare
            // 
            this.btnYellowSquare.Image = global::QGame.Properties.Resources.yellow_square;
            this.btnYellowSquare.Location = new System.Drawing.Point(6, 283);
            this.btnYellowSquare.Name = "btnYellowSquare";
            this.btnYellowSquare.Size = new System.Drawing.Size(60, 60);
            this.btnYellowSquare.TabIndex = 15;
            this.btnYellowSquare.UseVisualStyleBackColor = true;
            this.btnYellowSquare.Click += new System.EventHandler(this.btnYellowSquare_Click);
            // 
            // btnGreenExit
            // 
            this.btnGreenExit.BackColor = System.Drawing.Color.White;
            this.btnGreenExit.Image = global::QGame.Properties.Resources.exit_green;
            this.btnGreenExit.Location = new System.Drawing.Point(72, 217);
            this.btnGreenExit.Name = "btnGreenExit";
            this.btnGreenExit.Size = new System.Drawing.Size(60, 60);
            this.btnGreenExit.TabIndex = 14;
            this.btnGreenExit.UseVisualStyleBackColor = false;
            this.btnGreenExit.Click += new System.EventHandler(this.btnGreenExit_Click);
            // 
            // btnGreenSquare
            // 
            this.btnGreenSquare.Image = global::QGame.Properties.Resources.green_square;
            this.btnGreenSquare.Location = new System.Drawing.Point(6, 217);
            this.btnGreenSquare.Name = "btnGreenSquare";
            this.btnGreenSquare.Size = new System.Drawing.Size(60, 60);
            this.btnGreenSquare.TabIndex = 13;
            this.btnGreenSquare.UseVisualStyleBackColor = true;
            this.btnGreenSquare.Click += new System.EventHandler(this.btnGreenSquare_Click);
            // 
            // btnBlueExit
            // 
            this.btnBlueExit.BackColor = System.Drawing.Color.White;
            this.btnBlueExit.Image = global::QGame.Properties.Resources.exit_blue;
            this.btnBlueExit.Location = new System.Drawing.Point(72, 151);
            this.btnBlueExit.Name = "btnBlueExit";
            this.btnBlueExit.Size = new System.Drawing.Size(60, 60);
            this.btnBlueExit.TabIndex = 12;
            this.btnBlueExit.UseVisualStyleBackColor = false;
            this.btnBlueExit.Click += new System.EventHandler(this.btnBlueExit_Click);
            // 
            // btnBlueSquare
            // 
            this.btnBlueSquare.Image = global::QGame.Properties.Resources.blue_square;
            this.btnBlueSquare.Location = new System.Drawing.Point(6, 151);
            this.btnBlueSquare.Name = "btnBlueSquare";
            this.btnBlueSquare.Size = new System.Drawing.Size(60, 60);
            this.btnBlueSquare.TabIndex = 11;
            this.btnBlueSquare.UseVisualStyleBackColor = true;
            this.btnBlueSquare.Click += new System.EventHandler(this.btnBlueSquare_Click);
            // 
            // btnRedExit
            // 
            this.btnRedExit.BackColor = System.Drawing.Color.White;
            this.btnRedExit.Image = global::QGame.Properties.Resources.exit_red;
            this.btnRedExit.Location = new System.Drawing.Point(72, 85);
            this.btnRedExit.Name = "btnRedExit";
            this.btnRedExit.Size = new System.Drawing.Size(60, 60);
            this.btnRedExit.TabIndex = 10;
            this.btnRedExit.UseVisualStyleBackColor = false;
            this.btnRedExit.Click += new System.EventHandler(this.btnRedExit_Click);
            // 
            // btnRedSquare
            // 
            this.btnRedSquare.Image = global::QGame.Properties.Resources.red_square;
            this.btnRedSquare.Location = new System.Drawing.Point(6, 85);
            this.btnRedSquare.Name = "btnRedSquare";
            this.btnRedSquare.Size = new System.Drawing.Size(60, 60);
            this.btnRedSquare.TabIndex = 9;
            this.btnRedSquare.UseVisualStyleBackColor = true;
            this.btnRedSquare.Click += new System.EventHandler(this.btnRedSquare_Click);
            // 
            // btnBrickWall
            // 
            this.btnBrickWall.BackColor = System.Drawing.Color.White;
            this.btnBrickWall.Image = global::QGame.Properties.Resources.brick_wall;
            this.btnBrickWall.Location = new System.Drawing.Point(72, 19);
            this.btnBrickWall.Name = "btnBrickWall";
            this.btnBrickWall.Size = new System.Drawing.Size(60, 60);
            this.btnBrickWall.TabIndex = 8;
            this.btnBrickWall.UseVisualStyleBackColor = false;
            this.btnBrickWall.Click += new System.EventHandler(this.btnBrickWall_Click);
            // 
            // btnBlank
            // 
            this.btnBlank.Image = global::QGame.Properties.Resources.blank_square;
            this.btnBlank.Location = new System.Drawing.Point(6, 19);
            this.btnBlank.Name = "btnBlank";
            this.btnBlank.Size = new System.Drawing.Size(60, 60);
            this.btnBlank.TabIndex = 7;
            this.btnBlank.UseVisualStyleBackColor = true;
            this.btnBlank.Click += new System.EventHandler(this.btnBlank_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(403, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "The grid must be a square.";
            // 
            // LevelDesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 559);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpToolbox);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblColumns);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.txtColumns);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.strpMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.strpMenu;
            this.Name = "LevelDesignForm";
            this.Text = "Level Editor";
            this.Load += new System.EventHandler(this.LevelDesignForm_Load);
            this.strpMenu.ResumeLayout(false);
            this.strpMenu.PerformLayout();
            this.grpToolbox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip strpMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox grpToolbox;
        private System.Windows.Forms.Button btnYellowExit;
        private System.Windows.Forms.Button btnYellowSquare;
        private System.Windows.Forms.Button btnGreenExit;
        private System.Windows.Forms.Button btnGreenSquare;
        private System.Windows.Forms.Button btnBlueExit;
        private System.Windows.Forms.Button btnBlueSquare;
        private System.Windows.Forms.Button btnRedExit;
        private System.Windows.Forms.Button btnRedSquare;
        private System.Windows.Forms.Button btnBrickWall;
        private System.Windows.Forms.Button btnBlank;
        private ToolStripMenuItem returnToMainMenuToolStripMenuItem;
        private Label label1;
    }
}