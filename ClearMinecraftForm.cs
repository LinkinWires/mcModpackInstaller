using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mcModpackInstaller
{
    public partial class ClearMinecraftForm : Form
    {
        string path;
        Workers work = new Workers();
        /* 
        different icons for taskbar and titlebar
        from stackoverflow: https://stackoverflow.com/questions/4048910
        ty, Andreas Adler! (https://stackoverflow.com/users/649841)
        */
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);
        private const uint WM_SETICON = 0x80u;
        private const int ICON_SMALL = 0;
        private const int ICON_BIG = 1;

        // colors for dark theme
        Color TextColor = ColorTranslator.FromHtml("#F3F3F3");
        Color FormBackColor = ColorTranslator.FromHtml("#383838");
        Color ContolsBackColor = ColorTranslator.FromHtml("#252525");

        // language (depends on OS language)
        CultureInfo ci = CultureInfo.InstalledUICulture;

        public ClearMinecraftForm(string mcPath, bool darkTheme)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(ci.Name);
            InitializeComponent();
            SendMessage(this.Handle, WM_SETICON, ICON_SMALL, Properties.Resources.mcModpackInstaller_small.Handle);
            SendMessage(this.Handle, WM_SETICON, ICON_BIG, Properties.Resources.mcModpackInstaller_large.Handle); // part of setting icons
            path = mcPath;
            if (darkTheme)
            {
                DarkTheme();
            }    
        }

        private void DarkTheme()
        {
            BackColor = FormBackColor;
            ForeColor = TextColor;  // colors for the form itself
            foreach (var label in this.Controls.OfType<Label>())
            {
                label.ForeColor = TextColor;
            }
            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                textBox.ForeColor = TextColor;
                textBox.BackColor = ContolsBackColor;
            }
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.ForeColor = TextColor;
                button.BackColor = FormBackColor;
            }
            foreach (var checkbox in this.Controls.OfType<CheckBox>())
            {
                checkbox.ForeColor = TextColor;
                checkbox.BackColor = FormBackColor;
            }
        }

        private void configBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(configBox, Resources.Localizations.Tooltip.Tooltip.TooltipConfig);
        }

        private void coremodsBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(coremodsBox, Resources.Localizations.Tooltip.Tooltip.TooltipCoremods);
        }

        private void logsBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(logsBox, Resources.Localizations.Tooltip.Tooltip.TooltipLogs);
        }

        private void modsBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(modsBox, Resources.Localizations.Tooltip.Tooltip.TooltipMods);
        }

        private void resourcepacksBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(resourcepacksBox, Resources.Localizations.Tooltip.Tooltip.TooltipResourcepacks);
        }

        private void savesBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(savesBox, Resources.Localizations.Tooltip.Tooltip.TooltipSaves);
        }

        private void screenshotsBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(screenshotsBox, Resources.Localizations.Tooltip.Tooltip.TooltipScreenshots);
        }

        private void serverresourcepacksBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(serverresourcepacksBox, Resources.Localizations.Tooltip.Tooltip.TooltipServerResourcePacks);
        }

        private void shaderpacksBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(shaderpacksBox, Resources.Localizations.Tooltip.Tooltip.TooltipShaderpacks);
        }

        private void structuresBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(structuresBox, Resources.Localizations.Tooltip.Tooltip.TooltipStructures);
        }

        private void texturepacksBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(texturepacksBox, Resources.Localizations.Tooltip.Tooltip.TooltipTexturepacks);
        }

        private void optionsTxtBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(optionsTxtBox, Resources.Localizations.Tooltip.Tooltip.TooltipOptionsTxt);
        }

        private void serversDatBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(serversDatBox, Resources.Localizations.Tooltip.Tooltip.TooltipServersDat);
        }

        private void serversDatOldBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(serversDatOldBox, Resources.Localizations.Tooltip.Tooltip.TooltipServersDatOld);
        }

        private void variousModsBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(variousModsBox, Resources.Localizations.Tooltip.Tooltip.TooltipVariousMods);
        }

        private void purge_Click(object sender, EventArgs e)
        {
            LockUIElements();
            StringBuilder clearList = new StringBuilder();
            foreach (var checkBox in this.Controls.OfType<CheckBox>())
            {
                if (checkBox.Checked)
                {
                    clearList.Append(checkBox.Tag + ";");
                }
            }
            clearList.Remove(clearList.Length - 1, 1);
            string clearListString = clearList.ToString();
            clearList.Clear();
            string[] toClear = clearListString.Split(new char[] { ';' });
            foreach (var item in toClear)
            {
                work.Purge(path, item);
            }
            JobsDone(Resources.Localizations.MessageBox.MessageBox.MessageBoxClearSuccessful);
            foreach (var checkBox in this.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = false;
            }
            UnlockUIElements();
        }

        private void templates_Click(object sender, EventArgs e)
        {
            templatesMenu.Show(Cursor.Position);
        }

        private void fillFromTemplate(string templateFile)
        {
            if (File.Exists(templateFile))
            {
                string[] options = File.ReadAllLines(templateFile);
                foreach (string option in options)
                {
                    foreach (var checkBox in this.Controls.OfType<CheckBox>())
                    {
                        if (checkBox.Tag.ToString() == option)
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                checkBox.Checked = true;
                            }
                            ));
                            break;
                        }
                    }
                }
            }
        }

        private void saveTemplateToTxt()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = Resources.Localizations.Dialogs.FileDialogs.SaveTemplateTitle;
                sfd.Filter = Resources.Localizations.Dialogs.FileDialogs.TemplateFilter;
                sfd.FileName = "Template_*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder toTemplate = new StringBuilder();
                    foreach (var checkBox in this.Controls.OfType<CheckBox>())
                    {
                        if (checkBox.Checked)
                        {
                            toTemplate.Append(checkBox.Tag + ";");
                        }
                    }
                    toTemplate.Remove(toTemplate.Length - 1, 1);
                    string toTemplateString = toTemplate.ToString();
                    toTemplate.Clear();
                    string[] toTemp = toTemplateString.Split(new char[] { ';' });
                    if (File.Exists(sfd.FileName))
                    {
                        File.Delete(sfd.FileName);
                    }
                    File.AppendAllLines(sfd.FileName, toTemp);
                }
            }
        }

        private void loadTemplateFromTxt()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = Resources.Localizations.Dialogs.FileDialogs.OpenTemplateTitle;
                ofd.Filter = Resources.Localizations.Dialogs.FileDialogs.TemplateFilter;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var checkBox in this.Controls.OfType<CheckBox>())
                    {
                        checkBox.Checked = false;
                    }
                    fillFromTemplate(ofd.FileName);
                }
            }  
        }

        private DialogResult ShowMessage(string text, MessageBoxIcon icon = MessageBoxIcon.None,
            MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            return MessageBox.Show(text, "mcModPackInstaller", buttons, icon);
        }

        private void JobsDone(string message)
        {
            SoundPlayer jobsdone = new SoundPlayer(mcModpackInstaller.Properties.Resources.jobsdone);
            jobsdone.Play();
            ShowMessage(message);
        }

        private async void builtinAll_Click(object sender, EventArgs e)
        {
            foreach (var checkBox in this.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = false;
            }
            await Task.Run(() => fillFromTemplate("Templates\\Template_All.txt"));
        }

        private async void builtinModPackUniversal_Click(object sender, EventArgs e)
        {
            foreach (var checkBox in this.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = false;
            }
            await Task.Run(() => fillFromTemplate("Templates\\Template_ModPackUniversal.txt"));
        }

        private async void builtinModsOnly_Click(object sender, EventArgs e)
        {
            foreach (var checkBox in this.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = false;
            }
            await Task.Run(() => fillFromTemplate("Templates\\Template_ModsOnly.txt"));
        }

        private async void builtinVanilaCleaning_Click(object sender, EventArgs e)
        {
            foreach (var checkBox in this.Controls.OfType<CheckBox>())
            { 
                checkBox.Checked = false;
            }
            await Task.Run(() => fillFromTemplate("Templates\\Template_VanillaCleaning.txt"));
        }

        private void saveTemplate_Click(object sender, EventArgs e)
        {
            LockUIElements();
            saveTemplateToTxt();
            UnlockUIElements();
        }

        private void loadTemplate_Click(object sender, EventArgs e)
        {
            LockUIElements();
            loadTemplateFromTxt();
            UnlockUIElements();
        }

        private void clearChecks_Click(object sender, EventArgs e)
        {
            LockUIElements();
            foreach (var checkBox in this.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = false;
            }
            UnlockUIElements();
        }

        private async void auto_Click(object sender, EventArgs e)
        {
            DialogResult dr = ShowMessage(Resources.Localizations.MessageBox.MessageBox.MessageBoxGeneralCleaningConfirmation, 
                MessageBoxIcon.Warning, 
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                LockUIElements();
                await Task.Run(() => work.Purge(path.Replace(".minecraft", ""), ".minecraft", true));
                Directory.CreateDirectory(path);
                JobsDone(Resources.Localizations.MessageBox.MessageBox.MessageBoxClearSuccessful);
                UnlockUIElements();
            }
        }

        private void UnlockUIElements() // enable ui back
        {
            foreach (var checkBox in this.Controls.OfType<CheckBox>())
            {
                checkBox.Enabled = true;
            }
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = true;
            }
        }

        private void LockUIElements() // disable ui for safety
        {
            foreach (var checkBox in this.Controls.OfType<CheckBox>())
            {
                checkBox.Enabled = false;
            }
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = false;
            }
        }
    }
}
