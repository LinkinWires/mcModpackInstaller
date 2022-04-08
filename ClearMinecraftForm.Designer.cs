namespace mcModpackInstaller
{
    partial class ClearMinecraftForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClearMinecraftForm));
            this.label1 = new System.Windows.Forms.Label();
            this.auto = new System.Windows.Forms.Button();
            this.templates = new System.Windows.Forms.Button();
            this.purge = new System.Windows.Forms.Button();
            this.coremodsBox = new System.Windows.Forms.CheckBox();
            this.configBox = new System.Windows.Forms.CheckBox();
            this.logsBox = new System.Windows.Forms.CheckBox();
            this.modsBox = new System.Windows.Forms.CheckBox();
            this.resourcepacksBox = new System.Windows.Forms.CheckBox();
            this.savesBox = new System.Windows.Forms.CheckBox();
            this.screenshotsBox = new System.Windows.Forms.CheckBox();
            this.serverresourcepacksBox = new System.Windows.Forms.CheckBox();
            this.shaderpacksBox = new System.Windows.Forms.CheckBox();
            this.structuresBox = new System.Windows.Forms.CheckBox();
            this.texturepacksBox = new System.Windows.Forms.CheckBox();
            this.optionsTxtBox = new System.Windows.Forms.CheckBox();
            this.serversDatBox = new System.Windows.Forms.CheckBox();
            this.serversDatOldBox = new System.Windows.Forms.CheckBox();
            this.variousModsBox = new System.Windows.Forms.CheckBox();
            this.uniToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.templatesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.builtinAll = new System.Windows.Forms.ToolStripMenuItem();
            this.builtinModPackUniversal = new System.Windows.Forms.ToolStripMenuItem();
            this.builtinModsOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.builtinVanilaCleaning = new System.Windows.Forms.ToolStripMenuItem();
            this.sep = new System.Windows.Forms.ToolStripSeparator();
            this.saveTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearChecks = new System.Windows.Forms.ToolStripMenuItem();
            this.templatesMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.uniToolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // auto
            // 
            resources.ApplyResources(this.auto, "auto");
            this.auto.Name = "auto";
            this.uniToolTip.SetToolTip(this.auto, resources.GetString("auto.ToolTip"));
            this.auto.UseVisualStyleBackColor = true;
            this.auto.Click += new System.EventHandler(this.auto_Click);
            // 
            // templates
            // 
            resources.ApplyResources(this.templates, "templates");
            this.templates.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.templates.Name = "templates";
            this.uniToolTip.SetToolTip(this.templates, resources.GetString("templates.ToolTip"));
            this.templates.UseVisualStyleBackColor = true;
            this.templates.Click += new System.EventHandler(this.templates_Click);
            // 
            // purge
            // 
            resources.ApplyResources(this.purge, "purge");
            this.purge.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.purge.Name = "purge";
            this.uniToolTip.SetToolTip(this.purge, resources.GetString("purge.ToolTip"));
            this.purge.UseVisualStyleBackColor = true;
            this.purge.Click += new System.EventHandler(this.purge_Click);
            // 
            // coremodsBox
            // 
            resources.ApplyResources(this.coremodsBox, "coremodsBox");
            this.coremodsBox.Name = "coremodsBox";
            this.coremodsBox.Tag = "coremods";
            this.uniToolTip.SetToolTip(this.coremodsBox, resources.GetString("coremodsBox.ToolTip"));
            this.coremodsBox.UseVisualStyleBackColor = true;
            this.coremodsBox.MouseHover += new System.EventHandler(this.coremodsBox_MouseHover);
            // 
            // configBox
            // 
            resources.ApplyResources(this.configBox, "configBox");
            this.configBox.Name = "configBox";
            this.configBox.Tag = "config";
            this.uniToolTip.SetToolTip(this.configBox, resources.GetString("configBox.ToolTip"));
            this.configBox.UseVisualStyleBackColor = true;
            this.configBox.MouseHover += new System.EventHandler(this.configBox_MouseHover);
            // 
            // logsBox
            // 
            resources.ApplyResources(this.logsBox, "logsBox");
            this.logsBox.Name = "logsBox";
            this.logsBox.Tag = "logs";
            this.uniToolTip.SetToolTip(this.logsBox, resources.GetString("logsBox.ToolTip"));
            this.logsBox.UseVisualStyleBackColor = true;
            this.logsBox.MouseHover += new System.EventHandler(this.logsBox_MouseHover);
            // 
            // modsBox
            // 
            resources.ApplyResources(this.modsBox, "modsBox");
            this.modsBox.Name = "modsBox";
            this.modsBox.Tag = "mods";
            this.uniToolTip.SetToolTip(this.modsBox, resources.GetString("modsBox.ToolTip"));
            this.modsBox.UseVisualStyleBackColor = true;
            this.modsBox.MouseHover += new System.EventHandler(this.modsBox_MouseHover);
            // 
            // resourcepacksBox
            // 
            resources.ApplyResources(this.resourcepacksBox, "resourcepacksBox");
            this.resourcepacksBox.Name = "resourcepacksBox";
            this.resourcepacksBox.Tag = "resourcepacks";
            this.uniToolTip.SetToolTip(this.resourcepacksBox, resources.GetString("resourcepacksBox.ToolTip"));
            this.resourcepacksBox.UseVisualStyleBackColor = true;
            this.resourcepacksBox.MouseHover += new System.EventHandler(this.resourcepacksBox_MouseHover);
            // 
            // savesBox
            // 
            resources.ApplyResources(this.savesBox, "savesBox");
            this.savesBox.Name = "savesBox";
            this.savesBox.Tag = "saves";
            this.uniToolTip.SetToolTip(this.savesBox, resources.GetString("savesBox.ToolTip"));
            this.savesBox.UseVisualStyleBackColor = true;
            this.savesBox.MouseHover += new System.EventHandler(this.savesBox_MouseHover);
            // 
            // screenshotsBox
            // 
            resources.ApplyResources(this.screenshotsBox, "screenshotsBox");
            this.screenshotsBox.Name = "screenshotsBox";
            this.screenshotsBox.Tag = "screenshots";
            this.uniToolTip.SetToolTip(this.screenshotsBox, resources.GetString("screenshotsBox.ToolTip"));
            this.screenshotsBox.UseVisualStyleBackColor = true;
            this.screenshotsBox.MouseHover += new System.EventHandler(this.screenshotsBox_MouseHover);
            // 
            // serverresourcepacksBox
            // 
            resources.ApplyResources(this.serverresourcepacksBox, "serverresourcepacksBox");
            this.serverresourcepacksBox.Name = "serverresourcepacksBox";
            this.serverresourcepacksBox.Tag = "server-resource-packs";
            this.uniToolTip.SetToolTip(this.serverresourcepacksBox, resources.GetString("serverresourcepacksBox.ToolTip"));
            this.serverresourcepacksBox.UseVisualStyleBackColor = true;
            this.serverresourcepacksBox.MouseHover += new System.EventHandler(this.serverresourcepacksBox_MouseHover);
            // 
            // shaderpacksBox
            // 
            resources.ApplyResources(this.shaderpacksBox, "shaderpacksBox");
            this.shaderpacksBox.Name = "shaderpacksBox";
            this.shaderpacksBox.Tag = "shaderpacks";
            this.uniToolTip.SetToolTip(this.shaderpacksBox, resources.GetString("shaderpacksBox.ToolTip"));
            this.shaderpacksBox.UseVisualStyleBackColor = true;
            this.shaderpacksBox.MouseHover += new System.EventHandler(this.shaderpacksBox_MouseHover);
            // 
            // structuresBox
            // 
            resources.ApplyResources(this.structuresBox, "structuresBox");
            this.structuresBox.Name = "structuresBox";
            this.structuresBox.Tag = "structures";
            this.uniToolTip.SetToolTip(this.structuresBox, resources.GetString("structuresBox.ToolTip"));
            this.structuresBox.UseVisualStyleBackColor = true;
            this.structuresBox.MouseHover += new System.EventHandler(this.structuresBox_MouseHover);
            // 
            // texturepacksBox
            // 
            resources.ApplyResources(this.texturepacksBox, "texturepacksBox");
            this.texturepacksBox.Name = "texturepacksBox";
            this.texturepacksBox.Tag = "texturepacks";
            this.uniToolTip.SetToolTip(this.texturepacksBox, resources.GetString("texturepacksBox.ToolTip"));
            this.texturepacksBox.UseVisualStyleBackColor = true;
            this.texturepacksBox.MouseHover += new System.EventHandler(this.texturepacksBox_MouseHover);
            // 
            // optionsTxtBox
            // 
            resources.ApplyResources(this.optionsTxtBox, "optionsTxtBox");
            this.optionsTxtBox.Name = "optionsTxtBox";
            this.optionsTxtBox.Tag = "options.txt";
            this.uniToolTip.SetToolTip(this.optionsTxtBox, resources.GetString("optionsTxtBox.ToolTip"));
            this.optionsTxtBox.UseVisualStyleBackColor = true;
            this.optionsTxtBox.MouseHover += new System.EventHandler(this.optionsTxtBox_MouseHover);
            // 
            // serversDatBox
            // 
            resources.ApplyResources(this.serversDatBox, "serversDatBox");
            this.serversDatBox.Name = "serversDatBox";
            this.serversDatBox.Tag = "servers.dat";
            this.uniToolTip.SetToolTip(this.serversDatBox, resources.GetString("serversDatBox.ToolTip"));
            this.serversDatBox.UseVisualStyleBackColor = true;
            this.serversDatBox.MouseHover += new System.EventHandler(this.serversDatBox_MouseHover);
            // 
            // serversDatOldBox
            // 
            resources.ApplyResources(this.serversDatOldBox, "serversDatOldBox");
            this.serversDatOldBox.Name = "serversDatOldBox";
            this.serversDatOldBox.Tag = "servers.dat_old";
            this.uniToolTip.SetToolTip(this.serversDatOldBox, resources.GetString("serversDatOldBox.ToolTip"));
            this.serversDatOldBox.UseVisualStyleBackColor = true;
            this.serversDatOldBox.MouseHover += new System.EventHandler(this.serversDatOldBox_MouseHover);
            // 
            // variousModsBox
            // 
            resources.ApplyResources(this.variousModsBox, "variousModsBox");
            this.variousModsBox.Name = "variousModsBox";
            this.variousModsBox.Tag = "variousMods";
            this.uniToolTip.SetToolTip(this.variousModsBox, resources.GetString("variousModsBox.ToolTip"));
            this.variousModsBox.UseVisualStyleBackColor = true;
            this.variousModsBox.MouseHover += new System.EventHandler(this.variousModsBox_MouseHover);
            // 
            // templatesMenu
            // 
            resources.ApplyResources(this.templatesMenu, "templatesMenu");
            this.templatesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.builtinAll,
            this.builtinModPackUniversal,
            this.builtinModsOnly,
            this.builtinVanilaCleaning,
            this.sep,
            this.saveTemplate,
            this.loadTemplate,
            this.sep2,
            this.clearChecks});
            this.templatesMenu.Name = "templatesMenu";
            this.uniToolTip.SetToolTip(this.templatesMenu, resources.GetString("templatesMenu.ToolTip"));
            // 
            // builtinAll
            // 
            resources.ApplyResources(this.builtinAll, "builtinAll");
            this.builtinAll.Name = "builtinAll";
            this.builtinAll.Click += new System.EventHandler(this.builtinAll_Click);
            // 
            // builtinModPackUniversal
            // 
            resources.ApplyResources(this.builtinModPackUniversal, "builtinModPackUniversal");
            this.builtinModPackUniversal.Name = "builtinModPackUniversal";
            this.builtinModPackUniversal.Click += new System.EventHandler(this.builtinModPackUniversal_Click);
            // 
            // builtinModsOnly
            // 
            resources.ApplyResources(this.builtinModsOnly, "builtinModsOnly");
            this.builtinModsOnly.Name = "builtinModsOnly";
            this.builtinModsOnly.Click += new System.EventHandler(this.builtinModsOnly_Click);
            // 
            // builtinVanilaCleaning
            // 
            resources.ApplyResources(this.builtinVanilaCleaning, "builtinVanilaCleaning");
            this.builtinVanilaCleaning.Name = "builtinVanilaCleaning";
            // 
            // sep
            // 
            resources.ApplyResources(this.sep, "sep");
            this.sep.Name = "sep";
            // 
            // saveTemplate
            // 
            resources.ApplyResources(this.saveTemplate, "saveTemplate");
            this.saveTemplate.Name = "saveTemplate";
            this.saveTemplate.Click += new System.EventHandler(this.saveTemplate_Click);
            // 
            // loadTemplate
            // 
            resources.ApplyResources(this.loadTemplate, "loadTemplate");
            this.loadTemplate.Name = "loadTemplate";
            this.loadTemplate.Click += new System.EventHandler(this.loadTemplate_Click);
            // 
            // sep2
            // 
            resources.ApplyResources(this.sep2, "sep2");
            this.sep2.Name = "sep2";
            // 
            // clearChecks
            // 
            resources.ApplyResources(this.clearChecks, "clearChecks");
            this.clearChecks.Name = "clearChecks";
            this.clearChecks.Click += new System.EventHandler(this.clearChecks_Click);
            // 
            // ClearMinecraftForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.variousModsBox);
            this.Controls.Add(this.serversDatOldBox);
            this.Controls.Add(this.serversDatBox);
            this.Controls.Add(this.optionsTxtBox);
            this.Controls.Add(this.texturepacksBox);
            this.Controls.Add(this.structuresBox);
            this.Controls.Add(this.shaderpacksBox);
            this.Controls.Add(this.serverresourcepacksBox);
            this.Controls.Add(this.screenshotsBox);
            this.Controls.Add(this.savesBox);
            this.Controls.Add(this.resourcepacksBox);
            this.Controls.Add(this.modsBox);
            this.Controls.Add(this.logsBox);
            this.Controls.Add(this.configBox);
            this.Controls.Add(this.coremodsBox);
            this.Controls.Add(this.purge);
            this.Controls.Add(this.templates);
            this.Controls.Add(this.auto);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ClearMinecraftForm";
            this.uniToolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.templatesMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button auto;
        private System.Windows.Forms.Button templates;
        private System.Windows.Forms.Button purge;
        private System.Windows.Forms.CheckBox coremodsBox;
        private System.Windows.Forms.CheckBox configBox;
        private System.Windows.Forms.CheckBox logsBox;
        private System.Windows.Forms.CheckBox modsBox;
        private System.Windows.Forms.CheckBox resourcepacksBox;
        private System.Windows.Forms.CheckBox savesBox;
        private System.Windows.Forms.CheckBox screenshotsBox;
        private System.Windows.Forms.CheckBox serverresourcepacksBox;
        private System.Windows.Forms.CheckBox shaderpacksBox;
        private System.Windows.Forms.CheckBox structuresBox;
        private System.Windows.Forms.CheckBox texturepacksBox;
        private System.Windows.Forms.CheckBox optionsTxtBox;
        private System.Windows.Forms.CheckBox serversDatBox;
        private System.Windows.Forms.CheckBox serversDatOldBox;
        private System.Windows.Forms.CheckBox variousModsBox;
        private System.Windows.Forms.ToolTip uniToolTip;
        private System.Windows.Forms.ContextMenuStrip templatesMenu;
        private System.Windows.Forms.ToolStripMenuItem builtinAll;
        private System.Windows.Forms.ToolStripMenuItem builtinModPackUniversal;
        private System.Windows.Forms.ToolStripMenuItem builtinModsOnly;
        private System.Windows.Forms.ToolStripMenuItem builtinVanilaCleaning;
        private System.Windows.Forms.ToolStripSeparator sep;
        private System.Windows.Forms.ToolStripMenuItem saveTemplate;
        private System.Windows.Forms.ToolStripMenuItem loadTemplate;
        private System.Windows.Forms.ToolStripSeparator sep2;
        private System.Windows.Forms.ToolStripMenuItem clearChecks;
    }
}