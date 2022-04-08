namespace mcModpackInstaller
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.cleanMC = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // mcPath
            // 
            resources.ApplyResources(this.mcPath, "mcPath");
            this.mcPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mcPath.Name = "mcPath";
            // 
            // dotmcFindStatus
            // 
            resources.ApplyResources(this.dotmcFindStatus, "dotmcFindStatus");
            this.dotmcFindStatus.Name = "dotmcFindStatus";
            // 
            // mcPathChoose
            // 
            resources.ApplyResources(this.mcPathChoose, "mcPathChoose");
            this.mcPathChoose.Name = "mcPathChoose";
            this.mcPathChoose.UseVisualStyleBackColor = true;
            this.mcPathChoose.Click += new System.EventHandler(this.mcPathChoose_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // whatToInstall
            // 
            resources.ApplyResources(this.whatToInstall, "whatToInstall");
            this.whatToInstall.FormattingEnabled = true;
            this.whatToInstall.Name = "whatToInstall";
            this.whatToInstall.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.whatToInstall_MouseDoubleClick);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // serviceButton
            // 
            resources.ApplyResources(this.serviceButton, "serviceButton");
            this.serviceButton.Name = "serviceButton";
            this.serviceButton.UseVisualStyleBackColor = true;
            this.serviceButton.Click += new System.EventHandler(this.serviceButton_Click);
            // 
            // serviceMenu
            // 
            resources.ApplyResources(this.serviceMenu, "serviceMenu");
            this.serviceMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanMC});
            this.serviceMenu.Name = "serviceMenu";
            // 
            // cleanMC
            // 
            resources.ApplyResources(this.cleanMC, "cleanMC");
            this.cleanMC.Name = "cleanMC";
            this.cleanMC.Click += new System.EventHandler(this.cleanMC_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.serviceButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.whatToInstall);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mcPathChoose);
            this.Controls.Add(this.dotmcFindStatus);
            this.Controls.Add(this.mcPath);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
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
        private System.Windows.Forms.ToolStripMenuItem cleanMC;
    }
}

