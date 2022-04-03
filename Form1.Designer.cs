namespace mcModpackInstaller
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.mcPath = new System.Windows.Forms.TextBox();
            this.dotmcFindStatus = new System.Windows.Forms.Label();
            this.mcPathChoose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.whatToInstall = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.serviceButton = new System.Windows.Forms.Button();
            this.serviceMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteMods = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanMC = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Папка с Minecraft";
            // 
            // mcPath
            // 
            this.mcPath.Location = new System.Drawing.Point(12, 25);
            this.mcPath.Name = "mcPath";
            this.mcPath.Size = new System.Drawing.Size(465, 20);
            this.mcPath.TabIndex = 1;
            // 
            // dotmcFindStatus
            // 
            this.dotmcFindStatus.AutoSize = true;
            this.dotmcFindStatus.Location = new System.Drawing.Point(12, 363);
            this.dotmcFindStatus.Name = "dotmcFindStatus";
            this.dotmcFindStatus.Size = new System.Drawing.Size(97, 13);
            this.dotmcFindStatus.TabIndex = 2;
            this.dotmcFindStatus.Text = "Поиск .minecraft...";
            // 
            // mcPathChoose
            // 
            this.mcPathChoose.Location = new System.Drawing.Point(483, 25);
            this.mcPathChoose.Name = "mcPathChoose";
            this.mcPathChoose.Size = new System.Drawing.Size(24, 20);
            this.mcPathChoose.TabIndex = 3;
            this.mcPathChoose.Text = "...";
            this.mcPathChoose.UseVisualStyleBackColor = true;
            this.mcPathChoose.Click += new System.EventHandler(this.mcPathChoose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(425, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Установить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // whatToInstall
            // 
            this.whatToInstall.FormattingEnabled = true;
            this.whatToInstall.Location = new System.Drawing.Point(12, 67);
            this.whatToInstall.Name = "whatToInstall";
            this.whatToInstall.Size = new System.Drawing.Size(495, 264);
            this.whatToInstall.TabIndex = 7;
            this.whatToInstall.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.whatToInstall_MouseDoubleClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(41, 337);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Очистить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // serviceButton
            // 
            this.serviceButton.Location = new System.Drawing.Point(344, 337);
            this.serviceButton.Name = "serviceButton";
            this.serviceButton.Size = new System.Drawing.Size(75, 23);
            this.serviceButton.TabIndex = 9;
            this.serviceButton.Text = "Сервис";
            this.serviceButton.UseVisualStyleBackColor = true;
            this.serviceButton.Click += new System.EventHandler(this.serviceButton_Click);
            // 
            // serviceMenu
            // 
            this.serviceMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteMods,
            this.cleanMC});
            this.serviceMenu.Name = "serviceMenu";
            this.serviceMenu.Size = new System.Drawing.Size(181, 48);
            this.serviceMenu.Text = "Сервис";
            // 
            // deleteMods
            // 
            this.deleteMods.Name = "deleteMods";
            this.deleteMods.Size = new System.Drawing.Size(185, 22);
            this.deleteMods.Text = "Удалить моды";
            this.deleteMods.Click += new System.EventHandler(this.deleteMods_Click);
            // 
            // cleanMC
            // 
            this.cleanMC.Name = "cleanMC";
            this.cleanMC.Size = new System.Drawing.Size(180, 22);
            this.cleanMC.Text = "Очистить Minecraft";
            this.cleanMC.Click += new System.EventHandler(this.cleanMC_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 386);
            this.Controls.Add(this.serviceButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.whatToInstall);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mcPathChoose);
            this.Controls.Add(this.dotmcFindStatus);
            this.Controls.Add(this.mcPath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "mcModpackInstaller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.serviceMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mcPath;
        private System.Windows.Forms.Label dotmcFindStatus;
        private System.Windows.Forms.Button mcPathChoose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox whatToInstall;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button serviceButton;
        private System.Windows.Forms.ContextMenuStrip serviceMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteMods;
        private System.Windows.Forms.ToolStripMenuItem cleanMC;
    }
}

