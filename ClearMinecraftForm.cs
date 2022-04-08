using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
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

        public ClearMinecraftForm(string mcPath, bool darkTheme)
        {
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
            uniToolTip.SetToolTip(configBox, "Папка для хранения модами своих настроек. Сам Minecraft здесь НЕ хранит свои настройки." +
                "\nТакже стоит отметить, что настройки управления от модов храняться в настройках самого Minecraft.");
        }

        private void coremodsBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(coremodsBox, "Папка для установки спецальных модов, которые могут не только добавлять новый код, но и менять старый." +
                " Чаще всего, это библиотеки\nили API для других модов. " +
                "Актуально только для версий Minecraft до 1.5.2, сейчас такие моды загружаются из папки mods.");
        }

        private void logsBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(logsBox, "Папка для хранения файлов журналов, в которых расписаны события, которые произошли за определённый сеанс игры, включая вылеты. " +
                "\nСтоит оставлять, только если вы - тестер или собираетесь писать на какой-либо форум с проблемой вылета игры.");
        }

        private void modsBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(modsBox, "Папка для установки модов. Не знаете, что такое моды? Тогда зачем вам эта программа? =)");
        }

        private void resourcepacksBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(resourcepacksBox, "Папка для установки ресурс-паков - официального инструмента для модификации и добавления новых текстур, звуков и моделей.");
        }

        private void savesBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(savesBox, "Папка для хранения миров, созданных игроком.");
        }

        private void screenshotsBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(screenshotsBox, "Папка для хранения скриншотов, сделанных при помощи нажатия кнопки F2 в игре");
        }

        private void serverresourcepacksBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(serverresourcepacksBox, "Папка, в которой кэшируються ресурс-паки, скачанные для игры на серверах со своими ресурс-паками. " +
                "\nКак пример такого сервера можно назвать Hypixel, а именно режим Cops and Crims.");
        }

        private void shaderpacksBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(shaderpacksBox, "Папка для установки шейдеров - особих мини-программ, которые испольняються видеокартой и, в случае с Minecraft, модифицируют уже имеющуюся картинку.");
        }

        private void structuresBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(structuresBox, "Папка для хранения модами пользовательских структур. Эта папка никак не влияет на существующие в Minecraft структуры, " +
                "\nа также на структуры, которые были созданы с помощью структурного блока, такие храняться в папке с миром, в котором эта структура была сохранена.");
        }

        private void texturepacksBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(texturepacksBox, "Папка для установки текстур-паков - официального инструмента только для модификации и добавления новых текстур. " +
                "\nВ снапшоте 13w24a для версии 1.6.1 текстур-паки были упразднены и заменены на ресурс-паки.");
        }

        private void optionsTxtBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(optionsTxtBox, "Файл, где храняться все настройки Minecraft, а также настройки управления для модов.");
        }

        private void serversDatBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(serversDatBox, "Файл, где храниться вся информация о серверах Minecraft, которые были добавлены в список серверов игроком.");
        }

        private void serversDatOldBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(serversDatOldBox, "Резервная копия файла servers.dat, сделанная самим Minecraft.");
        }

        private void variousModsBox_MouseHover(object sender, EventArgs e)
        {
            uniToolTip.SetToolTip(variousModsBox, "Удаляет остатки от разных модов, как например папку journeymap или файл crafttweaker.log.");
        }

        private void purge_Click(object sender, EventArgs e)
        {
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
            JobsDone("Чистка завершена.");
            foreach (var checkBox in this.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = false;
            }
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
            else
            {

            }
        }

        private void saveTemplateToTxt()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Выберите, куда сохранить шаблон";
                sfd.Filter = "Тестовый файл с шаблоном (*.txt)|*.txt";
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
                ofd.Title = "Выберите шаблон";
                ofd.Filter = "Текстовый файл с шаблоном (*.txt)|*.txt";
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
            saveTemplateToTxt();
        }

        private void loadTemplate_Click(object sender, EventArgs e)
        {
            loadTemplateFromTxt();
        }

        private void clearChecks_Click(object sender, EventArgs e)
        {
            foreach (var checkBox in this.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = false;
            }
        }
    }
}
