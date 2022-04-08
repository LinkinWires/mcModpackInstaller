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
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 143);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // auto
            // 
            this.auto.Location = new System.Drawing.Point(12, 424);
            this.auto.Name = "auto";
            this.auto.Size = new System.Drawing.Size(75, 23);
            this.auto.TabIndex = 1;
            this.auto.Text = "Ген. уборка";
            this.auto.UseVisualStyleBackColor = true;
            // 
            // templates
            // 
            this.templates.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.templates.Location = new System.Drawing.Point(125, 424);
            this.templates.Name = "templates";
            this.templates.Size = new System.Drawing.Size(75, 23);
            this.templates.TabIndex = 2;
            this.templates.Text = "Шаблоны";
            this.templates.UseVisualStyleBackColor = true;
            this.templates.Click += new System.EventHandler(this.templates_Click);
            // 
            // purge
            // 
            this.purge.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.purge.Location = new System.Drawing.Point(238, 424);
            this.purge.Name = "purge";
            this.purge.Size = new System.Drawing.Size(75, 23);
            this.purge.TabIndex = 18;
            this.purge.Text = "Очистить!";
            this.purge.UseVisualStyleBackColor = true;
            this.purge.Click += new System.EventHandler(this.purge_Click);
            // 
            // coremodsBox
            // 
            this.coremodsBox.AutoSize = true;
            this.coremodsBox.Location = new System.Drawing.Point(12, 187);
            this.coremodsBox.Name = "coremodsBox";
            this.coremodsBox.Size = new System.Drawing.Size(107, 17);
            this.coremodsBox.TabIndex = 4;
            this.coremodsBox.Tag = "coremods";
            this.coremodsBox.Text = "Папка coremods";
            this.coremodsBox.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.coremodsBox.UseVisualStyleBackColor = true;
            this.coremodsBox.MouseHover += new System.EventHandler(this.coremodsBox_MouseHover);
            // 
            // configBox
            // 
            this.configBox.AutoSize = true;
            this.configBox.Location = new System.Drawing.Point(12, 164);
            this.configBox.Name = "configBox";
            this.configBox.Size = new System.Drawing.Size(90, 17);
            this.configBox.TabIndex = 3;
            this.configBox.Tag = "config";
            this.configBox.Text = "Папка config";
            this.configBox.UseVisualStyleBackColor = true;
            this.configBox.MouseHover += new System.EventHandler(this.configBox_MouseHover);
            // 
            // logsBox
            // 
            this.logsBox.AutoSize = true;
            this.logsBox.Location = new System.Drawing.Point(12, 210);
            this.logsBox.Name = "logsBox";
            this.logsBox.Size = new System.Drawing.Size(80, 17);
            this.logsBox.TabIndex = 5;
            this.logsBox.Tag = "logs";
            this.logsBox.Text = "Папка logs";
            this.logsBox.UseVisualStyleBackColor = true;
            this.logsBox.MouseHover += new System.EventHandler(this.logsBox_MouseHover);
            // 
            // modsBox
            // 
            this.modsBox.AutoSize = true;
            this.modsBox.Location = new System.Drawing.Point(12, 233);
            this.modsBox.Name = "modsBox";
            this.modsBox.Size = new System.Drawing.Size(86, 17);
            this.modsBox.TabIndex = 6;
            this.modsBox.Tag = "mods";
            this.modsBox.Text = "Папка mods";
            this.modsBox.UseVisualStyleBackColor = true;
            this.modsBox.MouseHover += new System.EventHandler(this.modsBox_MouseHover);
            // 
            // resourcepacksBox
            // 
            this.resourcepacksBox.AutoSize = true;
            this.resourcepacksBox.Location = new System.Drawing.Point(12, 256);
            this.resourcepacksBox.Name = "resourcepacksBox";
            this.resourcepacksBox.Size = new System.Drawing.Size(131, 17);
            this.resourcepacksBox.TabIndex = 7;
            this.resourcepacksBox.Tag = "resourcepacks";
            this.resourcepacksBox.Text = "Папка resourcepacks";
            this.resourcepacksBox.UseVisualStyleBackColor = true;
            this.resourcepacksBox.MouseHover += new System.EventHandler(this.resourcepacksBox_MouseHover);
            // 
            // savesBox
            // 
            this.savesBox.AutoSize = true;
            this.savesBox.Location = new System.Drawing.Point(12, 279);
            this.savesBox.Name = "savesBox";
            this.savesBox.Size = new System.Drawing.Size(89, 17);
            this.savesBox.TabIndex = 8;
            this.savesBox.Tag = "saves";
            this.savesBox.Text = "Папка saves";
            this.savesBox.UseVisualStyleBackColor = true;
            this.savesBox.MouseHover += new System.EventHandler(this.savesBox_MouseHover);
            // 
            // screenshotsBox
            // 
            this.screenshotsBox.AutoSize = true;
            this.screenshotsBox.Location = new System.Drawing.Point(12, 302);
            this.screenshotsBox.Name = "screenshotsBox";
            this.screenshotsBox.Size = new System.Drawing.Size(118, 17);
            this.screenshotsBox.TabIndex = 9;
            this.screenshotsBox.Tag = "screenshots";
            this.screenshotsBox.Text = "Папка screenshots";
            this.screenshotsBox.UseVisualStyleBackColor = true;
            this.screenshotsBox.MouseHover += new System.EventHandler(this.screenshotsBox_MouseHover);
            // 
            // serverresourcepacksBox
            // 
            this.serverresourcepacksBox.AutoSize = true;
            this.serverresourcepacksBox.Location = new System.Drawing.Point(12, 325);
            this.serverresourcepacksBox.Name = "serverresourcepacksBox";
            this.serverresourcepacksBox.Size = new System.Drawing.Size(166, 17);
            this.serverresourcepacksBox.TabIndex = 10;
            this.serverresourcepacksBox.Tag = "server-resource-packs";
            this.serverresourcepacksBox.Text = "Папка server-resource-packs";
            this.serverresourcepacksBox.UseVisualStyleBackColor = true;
            this.serverresourcepacksBox.MouseHover += new System.EventHandler(this.serverresourcepacksBox_MouseHover);
            // 
            // shaderpacksBox
            // 
            this.shaderpacksBox.AutoSize = true;
            this.shaderpacksBox.Location = new System.Drawing.Point(12, 348);
            this.shaderpacksBox.Name = "shaderpacksBox";
            this.shaderpacksBox.Size = new System.Drawing.Size(122, 17);
            this.shaderpacksBox.TabIndex = 11;
            this.shaderpacksBox.Tag = "shaderpacks";
            this.shaderpacksBox.Text = "Папка shaderpacks";
            this.shaderpacksBox.UseVisualStyleBackColor = true;
            this.shaderpacksBox.MouseHover += new System.EventHandler(this.shaderpacksBox_MouseHover);
            // 
            // structuresBox
            // 
            this.structuresBox.AutoSize = true;
            this.structuresBox.Location = new System.Drawing.Point(12, 371);
            this.structuresBox.Name = "structuresBox";
            this.structuresBox.Size = new System.Drawing.Size(107, 17);
            this.structuresBox.TabIndex = 12;
            this.structuresBox.Tag = "structures";
            this.structuresBox.Text = "Папка structures";
            this.structuresBox.UseVisualStyleBackColor = true;
            this.structuresBox.MouseHover += new System.EventHandler(this.structuresBox_MouseHover);
            // 
            // texturepacksBox
            // 
            this.texturepacksBox.AutoSize = true;
            this.texturepacksBox.Location = new System.Drawing.Point(12, 394);
            this.texturepacksBox.Name = "texturepacksBox";
            this.texturepacksBox.Size = new System.Drawing.Size(122, 17);
            this.texturepacksBox.TabIndex = 13;
            this.texturepacksBox.Tag = "texturepacks";
            this.texturepacksBox.Text = "Папка texturepacks";
            this.texturepacksBox.UseVisualStyleBackColor = true;
            this.texturepacksBox.MouseHover += new System.EventHandler(this.texturepacksBox_MouseHover);
            // 
            // optionsTxtBox
            // 
            this.optionsTxtBox.AutoSize = true;
            this.optionsTxtBox.Location = new System.Drawing.Point(125, 164);
            this.optionsTxtBox.Name = "optionsTxtBox";
            this.optionsTxtBox.Size = new System.Drawing.Size(106, 17);
            this.optionsTxtBox.TabIndex = 14;
            this.optionsTxtBox.Tag = "options.txt";
            this.optionsTxtBox.Text = "Файл options.txt";
            this.optionsTxtBox.UseVisualStyleBackColor = true;
            this.optionsTxtBox.MouseHover += new System.EventHandler(this.optionsTxtBox_MouseHover);
            // 
            // serversDatBox
            // 
            this.serversDatBox.AutoSize = true;
            this.serversDatBox.Location = new System.Drawing.Point(125, 187);
            this.serversDatBox.Name = "serversDatBox";
            this.serversDatBox.Size = new System.Drawing.Size(110, 17);
            this.serversDatBox.TabIndex = 15;
            this.serversDatBox.Tag = "servers.dat";
            this.serversDatBox.Text = "Файл servers.dat";
            this.serversDatBox.UseVisualStyleBackColor = true;
            this.serversDatBox.MouseHover += new System.EventHandler(this.serversDatBox_MouseHover);
            // 
            // serversDatOldBox
            // 
            this.serversDatOldBox.AutoSize = true;
            this.serversDatOldBox.Location = new System.Drawing.Point(125, 210);
            this.serversDatOldBox.Name = "serversDatOldBox";
            this.serversDatOldBox.Size = new System.Drawing.Size(130, 17);
            this.serversDatOldBox.TabIndex = 16;
            this.serversDatOldBox.Tag = "servers.dat_old";
            this.serversDatOldBox.Text = "Файл servers.dat_old";
            this.serversDatOldBox.UseVisualStyleBackColor = true;
            this.serversDatOldBox.MouseHover += new System.EventHandler(this.serversDatOldBox_MouseHover);
            // 
            // variousModsBox
            // 
            this.variousModsBox.AutoSize = true;
            this.variousModsBox.Location = new System.Drawing.Point(125, 233);
            this.variousModsBox.Name = "variousModsBox";
            this.variousModsBox.Size = new System.Drawing.Size(157, 17);
            this.variousModsBox.TabIndex = 17;
            this.variousModsBox.Tag = "variousMods";
            this.variousModsBox.Text = "Остатки от разных модов";
            this.variousModsBox.UseVisualStyleBackColor = true;
            this.variousModsBox.MouseHover += new System.EventHandler(this.variousModsBox_MouseHover);
            // 
            // templatesMenu
            // 
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
            this.templatesMenu.Size = new System.Drawing.Size(286, 170);
            // 
            // builtinAll
            // 
            this.builtinAll.Name = "builtinAll";
            this.builtinAll.Size = new System.Drawing.Size(285, 22);
            this.builtinAll.Text = "Всё";
            this.builtinAll.Click += new System.EventHandler(this.builtinAll_Click);
            // 
            // builtinModPackUniversal
            // 
            this.builtinModPackUniversal.Name = "builtinModPackUniversal";
            this.builtinModPackUniversal.Size = new System.Drawing.Size(285, 22);
            this.builtinModPackUniversal.Text = "Чистка для установки сборки";
            this.builtinModPackUniversal.Click += new System.EventHandler(this.builtinModPackUniversal_Click);
            // 
            // builtinModsOnly
            // 
            this.builtinModsOnly.Name = "builtinModsOnly";
            this.builtinModsOnly.Size = new System.Drawing.Size(285, 22);
            this.builtinModsOnly.Text = "Только моды";
            this.builtinModsOnly.Click += new System.EventHandler(this.builtinModsOnly_Click);
            // 
            // builtinVanilaCleaning
            // 
            this.builtinVanilaCleaning.Name = "builtinVanilaCleaning";
            this.builtinVanilaCleaning.Size = new System.Drawing.Size(285, 22);
            this.builtinVanilaCleaning.Text = "Чистка лишнего";
            // 
            // sep
            // 
            this.sep.Name = "sep";
            this.sep.Size = new System.Drawing.Size(282, 6);
            // 
            // saveTemplate
            // 
            this.saveTemplate.Name = "saveTemplate";
            this.saveTemplate.Size = new System.Drawing.Size(285, 22);
            this.saveTemplate.Text = "Сохранить пользовательский шаблон";
            this.saveTemplate.Click += new System.EventHandler(this.saveTemplate_Click);
            // 
            // loadTemplate
            // 
            this.loadTemplate.Name = "loadTemplate";
            this.loadTemplate.Size = new System.Drawing.Size(285, 22);
            this.loadTemplate.Text = "Загрузить пользовательский шаблон";
            this.loadTemplate.Click += new System.EventHandler(this.loadTemplate_Click);
            // 
            // sep2
            // 
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(282, 6);
            // 
            // clearChecks
            // 
            this.clearChecks.Name = "clearChecks";
            this.clearChecks.Size = new System.Drawing.Size(285, 22);
            this.clearChecks.Text = "Очистить выбор";
            this.clearChecks.Click += new System.EventHandler(this.clearChecks_Click);
            // 
            // ClearMinecraftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 457);
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
            this.Text = "Очистить Minecraft";
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