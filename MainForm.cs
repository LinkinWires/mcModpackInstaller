using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Media;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Globalization;

namespace mcModpackInstaller
{
    public partial class MainForm : Form
    {
        /* 
        TODO
        Plans:
        - Add check for different versions of Minecraft (for example, if user adds mods for 1.12.2 and 1.18.2 at the same time);
        - Add check for different modding APIs (for example, if user adds mods for Forge and Fabric at the same time);
        - Add check for possibility of installed Minecraft in chosen folder;
        - Add translation support (for now interface is only in Russian).
        Ideas:
        - Add mods and modpacks manager;
        - Add support for CurseForge mods and modpacks;
        */

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
        private bool darkTheme = false;

        // language (depends on OS language)
        CultureInfo ci = CultureInfo.InstalledUICulture;

        public MainForm()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(ci.Name);
            InitializeComponent();
            SendMessage(this.Handle, WM_SETICON, ICON_SMALL, Properties.Resources.mcModpackInstaller_small.Handle);
            SendMessage(this.Handle, WM_SETICON, ICON_BIG, Properties.Resources.mcModpackInstaller_large.Handle); // part of setting icons
            using (RegistryKey darkMode = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", false)) // checks for AppsUseLightTheme registry key
            {
                if (darkMode != null)
                {
                    Object value = darkMode.GetValue("AppsUseLightTheme");
                    if (Convert.ToInt16(value) == 0)
                    {
                        darkTheme = true;
                    }
                }
            }
            if (darkTheme)
            {
                DarkTheme();
            }
        }

        string[] modIndef = { "pack.mcmeta", // Generic Minecraft Forge mod resources metafile (also metafile for resource packs, but they are contained in zip files, so we're fine)
                              "mcmod.info", // Generic Minecraft Forge mod metafile
                              "flattening_ids.txt", // OptiFine
                              "fabric.mod.json", // Generic Fabric mod
                              "LibLoader.version"}; // LibLoader

        private void DarkTheme()
        {
            BackColor = FormBackColor;
            ForeColor = TextColor; // colors for the form itself
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
            foreach (var listbox in this.Controls.OfType<ListBox>())
            {
                listbox.ForeColor = TextColor;
                listbox.BackColor = ContolsBackColor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(ci.Name);
            if (work.DoesDotMinecraftExist())
            {
                ChangeStatus(Resources.Localizations.Status.Status.StatusDotMinecraftFound, DefaultForeColor, TextColor);
                mcPath.Text = Environment.GetEnvironmentVariable("appdata") + "\\.minecraft";
            }
            else
            {
                ChangeStatus(Resources.Localizations.Status.Status.StatusDotMinecraftNotFound, Color.Red, Color.Red);
            }
        }

        private void mcPathChoose_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    mcPath.Text = fbd.SelectedPath;
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opf = new OpenFileDialog())
            {
                opf.Title = Resources.Localizations.Dialogs.FileDialogs.OpenModModpackTitle;
                opf.Multiselect = true;
                opf.Filter = Resources.Localizations.Dialogs.FileDialogs.ModModpackFilter; // jar, zip.
                opf.RestoreDirectory = true;
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    LockUIElements();
                    foreach (string file in opf.FileNames)
                    {
                        await Task.Run(() => AddToList(file));
                    }
                    UnlockUIElements();
                }
                ChangeStatus("Ready.", DefaultForeColor, TextColor);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(mcPath.Text))
            {
                if (Directory.Exists(mcPath.Text))
                {
                    LockUIElements();
                    foreach (var filename in whatToInstall.Items)
                    {
                        string file = Path.GetFileName(filename.ToString());
                        if (file.ToString().EndsWith(".jar"))
                        {
                            try
                            {
                                string modInstallDir = mcPath.Text + "\\mods\\" + file.ToString();
                                ChangeStatus(String.Format(Resources.Localizations.Status.Status.StatusInstallingGeneric, file),
                                    DefaultForeColor,
                                    TextColor);
                                if (!File.Exists(modInstallDir))
                                {
                                    await Task.Run(() => work.InstallJar(modInstallDir, filename.ToString()));
                                }
                                else
                                {
                                    DialogResult dr = ShowMessage(String.Format(Resources.Localizations.MessageBox.MessageBox.MessageBoxOverwriteConfirmation, file),
                                        MessageBoxIcon.Warning,
                                        MessageBoxButtons.YesNo);
                                    if (dr == DialogResult.Yes)
                                    {
                                        await Task.Run(() => work.InstallJar(modInstallDir, filename.ToString(), true));
                                    }    
                                }    
                            }
                            catch (FileNotFoundException)
                            {
                                ChangeStatus(String.Format(Resources.Localizations.Status.Status.StatusSourceFileNotFound, file),
                                    Color.Red,
                                    Color.Red);
                                ShowMessage(String.Format(Resources.Localizations.MessageBox.MessageBox.MessageBoxSourceFileNotFound, file),
                                    MessageBoxIcon.Error);
                            }
                            catch (IOException)
                            {
                                ChangeStatus(String.Format(Resources.Localizations.Status.Status.StatusFileAlreadyExists, file),
                                    Color.Red,
                                    Color.Red);
                                ShowMessage(String.Format(Resources.Localizations.MessageBox.MessageBox.MessageBoxFileAlreadyExists, file),
                                    MessageBoxIcon.Error);
                                throw;
                            }
                        }
                        else
                        {
                            FileInfo fileSize = new FileInfo(filename.ToString());
                            if (fileSize.Length / 1024 > 102400)
                            {
                                ChangeStatus(String.Format(Resources.Localizations.Status.Status.StatusInstallingBigModpack, file.ToString(), fileSize.Length / 1048576),
                                    DefaultBackColor,
                                    TextColor);
                            }
                            else
                            {
                                ChangeStatus(String.Format(Resources.Localizations.Status.Status.StatusInstallingGeneric, file.ToString()),
                                    DefaultBackColor,
                                    TextColor);
                            }    
                            await Task.Run(() => work.InstallModPack(mcPath.Text, filename.ToString(), true));
                        }
                    }
                    JobsDone(Resources.Localizations.MessageBox.MessageBox.MessageBoxInstallationSuccessful);
                    whatToInstall.Items.Clear();
                    UnlockUIElements();
                }
                else
                {
                    ShowMessage(Resources.Localizations.MessageBox.MessageBox.MessageBoxDotMinecraftPathNotFound, MessageBoxIcon.Error);
                }
            }
            else
            {
                ShowMessage(Resources.Localizations.MessageBox.MessageBox.MessageBoxDotMinecraftPathEmpty, MessageBoxIcon.Error);
            }
        }

        private void JobsDone(string message)
        {
            SoundPlayer jobsdone = new SoundPlayer(mcModpackInstaller.Properties.Resources.jobsdone);
            jobsdone.Play();
            ChangeStatus(message, DefaultForeColor, TextColor);
            ShowMessage(message);
        }

        private void UnlockUIElements() // enable ui back
        {
            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                textBox.ReadOnly = false;
            }
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = true;
            }
        }

        private void LockUIElements() // disable ui for safety
        {
            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                textBox.ReadOnly = true;
            }
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = false;
            }
        }

        private async void AddToList(string filename)
        {
            string file = Path.GetFileName(filename);
            this.Invoke(new MethodInvoker(delegate ()
            {
                ChangeStatus(String.Format(Resources.Localizations.Status.Status.StatusAddingToList, file),
                    DefaultForeColor,
                    TextColor);
            }
            ));
            if (!whatToInstall.Items.Contains(filename))
            {
                if (filename.EndsWith(".jar"))
                {
                    if (await Task.Run(() => work.IsAnyInArchive(filename, modIndef)))
                    {
                        this.Invoke(new MethodInvoker(delegate () // change form elements from other thread
                        {
                            whatToInstall.Items.Add(filename);
                        }
                        ));
                    }
                    else if (await Task.Run(() => work.IsInArchive(filename, "plugin.yml")))
                    {
                        ShowMessage(Resources.Localizations.MessageBox.MessageBox.MessageBoxJarIsPlugin,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult dr = ShowMessage(String.Format(Resources.Localizations.MessageBox.MessageBox.MessageBoxPotentiallyNotMod, file),
                            MessageBoxIcon.Warning,
                                MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                whatToInstall.Items.Add(filename);
                            }
                            ));
                        }
                    }
                }
                else if (filename.EndsWith(".zip"))
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        whatToInstall.Items.Add(filename);
                    }
                    ));
                }
                else
                {
                    ShowMessage(String.Format(Resources.Localizations.MessageBox.MessageBox.MessageBoxFileNotJarOrZip, file),
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                ShowMessage(String.Format(Resources.Localizations.MessageBox.MessageBox.MessageBoxFileAlreadyInList, file), MessageBoxIcon.Error);
            }
        }

        private DialogResult ShowMessage(string text, MessageBoxIcon icon = MessageBoxIcon.None,
            MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            return MessageBox.Show(text, "mcModPackInstaller", buttons, icon);
        }

        private void ChangeStatus(string text, Color color, Color darkColor)
        {
            if (darkTheme)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    dotmcFindStatus.Text = text;
                    dotmcFindStatus.ForeColor = darkColor;
                }
                ));
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    dotmcFindStatus.Text = text;
                    dotmcFindStatus.ForeColor = color;
                }
                ));
            }
        }

        private void whatToInstall_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (whatToInstall.SelectedItem != null)
            {
                DialogResult dr = ShowMessage(String.Format(Resources.Localizations.MessageBox.MessageBox.MessageBoxDeleteFromList, whatToInstall.SelectedItem),
                    MessageBoxIcon.Warning,
                    MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    whatToInstall.Items.Remove(whatToInstall.SelectedItem);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = ShowMessage(Resources.Localizations.MessageBox.MessageBox.MessageBoxClearList,
                MessageBoxIcon.Warning,
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                whatToInstall.Items.Clear();
            }
        }

        private void serviceButton_Click(object sender, EventArgs e)
        {
            serviceMenu.Show(Cursor.Position);
        }

        private void cleanMC_Click(object sender, EventArgs e)
        {
            LockUIElements();
            ClearMinecraftForm cmf = new ClearMinecraftForm(mcPath.Text, darkTheme);
            cmf.Show();
            UnlockUIElements();
        }
    }
}
