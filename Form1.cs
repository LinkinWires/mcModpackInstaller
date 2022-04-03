using System;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Media;
using System.IO.Compression;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Readers;
using SharpCompress.Common;
using SharpCompress.Archives.Rar;

namespace mcModpackInstaller
{
    public partial class Form1 : Form
    {
        /* 
        TODO:
        - Добавить проверку при добавлении модов для разных API (например, если пользователь одновременно добавляет мод для Forge и Fabric.
        - Добавить проверку при указании папки с Minecraft, которая проверяла бы, может ли в этой папке быть установлен Minecraft.
        - Добавить поддержку перезаписи файлов при установке модов. Сейчас, программа просто жалуеться на существование файла в выходной папке.
        - Добавить возможность при очистке Minecraft выбирать то, что конкретно пользователь хочет очистить, а также поддержку пресетов очистки.
        */
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DoesDotMinecraftExist())
            {
                dotmcFindStatus.Text = ".minecraft найден.";
                dotmcFindStatus.ForeColor = Color.Green;
                mcPath.Text = Environment.GetEnvironmentVariable("appdata") + "\\.minecraft";
            }
            else
            {
                dotmcFindStatus.Text = ".minecraft не найден! Укажите папку, в которой установлен Minecraft.";
                dotmcFindStatus.ForeColor = Color.Red;
            }
        }

        private bool DoesDotMinecraftExist()
        {
            return Directory.Exists(Environment.GetEnvironmentVariable("appdata") + "\\.minecraft"); // ориентируется на то, что переменная среды %AppData% существует, которая есть только в Windows. Думаю, те, у кого Linux, сами смогут установить моды =)
        }

        private void mcPathChoose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); // выбор папки
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                mcPath.Text = fbd.SelectedPath;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog(); // выбор файлов
            opf.Title = "Выберите мод(-ы) и/или архив(-ы)";
            opf.Multiselect = true;
            opf.Filter = "Одиночний мод (*.jar)|*.jar|Архив со сборкой (*.zip; *.rar; *.7z)|*.zip;*.rar;*.7z|Все файлы (*.*)|*.*"; // jar, 7z, rar, zip, Все файлы.
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
            dotmcFindStatus.Text = "Готово.";
            dotmcFindStatus.ForeColor = Color.Green;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(mcPath.Text))
            {
                if (Directory.Exists(mcPath.Text))
                {
                    LockUIElements();
                    foreach (var file in whatToInstall.Items)
                    {
                        Debug.WriteLine(file);
                        if (file.ToString().EndsWith(".jar"))
                        {
                            await Task.Run(() => InstallJar(file.ToString()));
                        }
                        else
                        {
                            await Task.Run(() => InstallModPack(file.ToString()));
                        }
                    }
                    SoundPlayer jobsdone = new SoundPlayer(mcModpackInstaller.Properties.Resources.jobsdone);
                    jobsdone.Play();
                    dotmcFindStatus.Text = "Готово.";
                    dotmcFindStatus.ForeColor = Color.Green;
                    MessageBox.Show("Установка завершена.");
                    whatToInstall.Items.Clear();
                    UnlockUIElements();
                }
                else
                {
                    MessageBox.Show("Указанный путь не существует.",
                        "mcModpackInstaller",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Путь к Minecraft не может быть пустым.",
                        "mcModpackInstaller",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void UnlockUIElements()
        {
            mcPath.ReadOnly = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            serviceButton.Enabled = true;
            mcPathChoose.Enabled = true;
        }

        private void LockUIElements() // чтобы пользователь не шкодил во время работы программы
        {
            mcPath.ReadOnly = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            serviceButton.Enabled = false;
            mcPathChoose.Enabled = false;
        }

        private void AddToList(string filename)
        {
            string file = Path.GetFileName(filename);
            this.Invoke(new MethodInvoker(delegate ()
            {
                dotmcFindStatus.Text = "Добавление " + file + "...";
                dotmcFindStatus.ForeColor = DefaultBackColor;
            }
            ));
            if (!whatToInstall.Items.Contains(filename))
            {
                if (filename.EndsWith(".jar"))
                {
                    using (ZipArchive jar = ZipFile.Open(filename, ZipArchiveMode.Read)) // jar-файлы - это zip-архивы =О
                    {
                        foreach (ZipArchiveEntry entry in jar.Entries)
                        {
                            if (entry.Name == "pack.mcmeta" || // проверка на Forge
                                entry.Name == "flattening_ids.txt" || // проверка на Optifine
                                entry.Name == "fabric.mod.json") // проверка на Fabric
                            {
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    whatToInstall.Items.Add(filename);
                                }
                                ));
                            }
                        }
                        if (!whatToInstall.Items.Contains(filename))
                        {
                            DialogResult dr = MessageBox.Show("Возникла проблема с опознаванием того, что файл " +
                                file +
                                " действительно является модом. Вы уверены, что хотите добавть этот файл в список?",
                                "mcModpackInstaller",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);
                            if (dr == DialogResult.Yes)
                            {
                                this.Invoke(new MethodInvoker(delegate () // чтобы можно было менять форму из другого потока
                                {
                                    whatToInstall.Items.Add(filename);
                                }
                                ));
                            }
                        }
                    }
                }
                else if (filename.EndsWith(".zip") ||
                    filename.EndsWith(".rar") ||
                    filename.EndsWith(".7z"))
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        whatToInstall.Items.Add(filename);
                    }
                    ));
                }
                else
                {
                    MessageBox.Show("Файл " + file + "не является ни модом, ни архивом.",
                        "mcModpackInstaller",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(file + " уже был добавлен.",
                    "mcModpackInstaller",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InstallJar(string filename)
        {
            string file = Path.GetFileName(filename);
            this.Invoke(new MethodInvoker(delegate ()
            {
                dotmcFindStatus.Text = "Установка " + file + "...";
                dotmcFindStatus.ForeColor = DefaultForeColor;
            }
            ));
            try
            {
                File.Copy(filename, mcPath.Text + "\\mods\\" + file);
            }
            catch (IOException)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    dotmcFindStatus.Text = file + " уже установлен.";
                    dotmcFindStatus.ForeColor = Color.Red;
                }
                ));
                MessageBox.Show(file + " уже установлен. Его установка будет пропущена.",
                    "mcModpackInstaller",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InstallModPack(string filename)
        {
            short unzipMode = 0;
            string file = Path.GetFileName(filename);
            this.Invoke(new MethodInvoker(delegate ()
            {
                dotmcFindStatus.Text = "Распаковка " + file + "...";
                dotmcFindStatus.ForeColor = DefaultBackColor;
            }
            ));
            if (filename.EndsWith(".rar")) // если архив со сборкой в формате rar
            {
                using (Stream stream = File.OpenRead(filename))
                {
                    var archive = RarArchive.Open(stream);
                    foreach (var entry in archive.Entries)
                    {
                        Debug.WriteLine(entry);
                        if (entry.IsDirectory)
                        {
                            if (entry.ToString().EndsWith(".minecraft")) // в корне архива - .minecraft
                            {
                                unzipMode = 0;
                                break;
                            }
                            else // в корне архива - mods
                            {
                                unzipMode = 1;
                                break;
                            }
                        }
                        else // в корне архива - jar-файл(-ы)
                        {
                            unzipMode = 2;
                            break;
                        }
                    }
                    try
                    {
                        using (var reader = archive.ExtractAllEntries())
                        {
                            var options = new ExtractionOptions();
                            options.ExtractFullPath = true;
                            switch (unzipMode)
                            {
                                case 0:
                                    reader.WriteAllToDirectory(mcPath.Text.Replace(".minecraft", ""), options);
                                    break;
                                case 1:
                                    reader.WriteAllToDirectory(mcPath.Text, options);
                                    break;
                                case 2:
                                    reader.WriteAllToDirectory(mcPath.Text + "\\mods", options);
                                    break;
                            }
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("При попытке распаковки " + filename + " произошла ошибка: " +
                            "\nПопытка распаковать файл, который уже существует в выходной директории." +
                            "\nРаспаковка этого архива была остановлена", "mcModpackInstaller",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }    
            }
            if (filename.EndsWith(".7z")) // если архив со сборкой в формате 7z
            {
                using (Stream stream = File.OpenRead(filename))
                {
                    var archive = SevenZipArchive.Open(stream);
                    foreach (var entry in archive.Entries)
                    {
                        Debug.WriteLine(entry);
                        if (entry.IsDirectory)
                        {
                            if (entry.ToString().EndsWith(".minecraft")) // в корне архива - .minecraft
                            {
                                unzipMode = 0;
                                break;
                            }
                            else // в корне архива - mods
                            {
                                unzipMode = 1;
                                break;
                            }
                        }
                        else // в корне архива - jar-файл(-ы)
                        {
                            unzipMode = 2;
                            break;
                        }
                    }
                    try
                    {
                        using (var reader = archive.ExtractAllEntries())
                        { 
                            var options = new ExtractionOptions();
                            options.ExtractFullPath = true;
                            switch (unzipMode) 
                            {
                                case 0:
                                    reader.WriteAllToDirectory(mcPath.Text.Replace(".minecraft", ""), options);
                                    break;
                                case 1:
                                    reader.WriteAllToDirectory(mcPath.Text, options);
                                    break;
                                case 2:
                                    reader.WriteAllToDirectory(mcPath.Text + "\\mods", options);
                                    break;
                            }    
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("При попытке распаковки " + filename + " произошла ошибка: " +
                            "\nПопытка распаковать файл, который уже существует в выходной директории." +
                            "\nРаспаковка этого архива была остановлена", "mcModpackInstaller",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }    
            else if (filename.EndsWith(".zip")) // если архив со сборкой в формате zip
            {
                using (ZipArchive zip = ZipFile.Open(filename, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        Debug.WriteLine(entry);
                        if (entry.FullName.EndsWith(".minecraft/")) // в корне архива - .minecraft
                        {
                            unzipMode = 0;
                            break;
                        }
                        else if (entry.FullName.StartsWith("mods/")) // в корне архива - mods
                        {
                            unzipMode = 1;
                            break;
                        }
                        else if (entry.FullName.EndsWith(".jar")) // в корне архива - jar-файл(-ы)
                        {
                            unzipMode = 2;
                            break;
                        }
                    }
                    try
                    {
                        switch (unzipMode)
                        {
                            case 0:
                                zip.ExtractToDirectory(mcPath.Text.Replace(".minecraft", ""));
                                break;
                            case 1:
                                zip.ExtractToDirectory(mcPath.Text);
                                break;
                            case 2:
                                zip.ExtractToDirectory(mcPath.Text + "\\mods");
                                break;
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("При попытке распаковки " + filename + " произошла ошибка: " +
                            "\nПопытка распаковать файл, который уже существует в выходной директории." +
                            "\nРаспаковка этого архива была остановлена", "mcModpackInstaller",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void PurgeFolder(string folder) // чистка папки от файлов и подпапок без удаления самой папки
        {
            foreach (var file in Directory.GetFiles(folder))
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    dotmcFindStatus.Text = "Удаление " + file + "...";
                    dotmcFindStatus.ForeColor = DefaultBackColor;
                }
                ));
                File.Delete(file);
            }
            foreach (var dir in Directory.GetDirectories(folder))
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    dotmcFindStatus.Text = "Удаление " + dir + "...";
                    dotmcFindStatus.ForeColor = DefaultBackColor;
                }
                ));
                Directory.Delete(dir, true);
            }
        }

        private void whatToInstall_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (whatToInstall.SelectedItem != null)
            {
                DialogResult dr = MessageBox.Show("Вы точно хотите удалить " + whatToInstall.SelectedItem + " из списка?"
                    , "mcModpackInstaller",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    whatToInstall.Items.Remove(whatToInstall.SelectedItem);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы действительно хотите отчистить список?",
                "mcModpackInstaller",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                whatToInstall.Items.Clear();
            }
        }

        private void serviceButton_Click(object sender, EventArgs e)
        {
            serviceMenu.Show(Cursor.Position);
        }

        private async void deleteMods_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Вы действительно хотите удалить моды? Это отчистит всё содержимое папки mods.",
                "mcModpackInstaller",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);
            if (dl == DialogResult.Yes)
            {
                LockUIElements();
                await Task.Run(() => PurgeFolder(mcPath.Text + "\\mods"));
                UnlockUIElements();
                dotmcFindStatus.Text = "Готово.";
                dotmcFindStatus.ForeColor = Color.Green;
            }
        }

        private async void cleanMC_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Вы действительно очистить Minecraft? Это удалит такие файлы, а также содержимое таких папок, как:" +
                "\n - папку coremods (API-моды, актуально только для старых версий Minecraft);" +
                "\n - папку mods (моды);" +
                "\n - папку config и файл options.txt (настройки);" +
                "\n - папку logs (файлы журнала);" +
                "\n - папки resourcepacks и server-resource-packs (ресурс-паки, включая те, которые были скачаны при игре на других серверах);" +
                "\n - папку saves (миры);" +
                "\n - папку screenshots (скриншоты, сделанные с помощью кнопки F2);" +
                "\n - папку scripts (скрипты для модов);" +
                "\n - папку shaderpacks (шейдеры);" +
                "\n - папку structures (структуры для модов);" +
                "\n - папку texturepacks (текстур-паки, актуально только для старых версий Minecraft);" +
                "\n - файлы servers.dat и servers.dat_old (список серверов)." +
                "\nРекомендуем внимательно прочитать список и сделать резервную копию того, что вам понадобиться!",
                "mcModpackInstaller",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);
            if (dl == DialogResult.Yes)
            {
                string[] folders = new string[] { "coremods", "mods", "config", "logs", "resourcepacks", "server-resource-packs", "saves", "screenshots", "scripts", "shaderpacks", "structures", "texturepacks" };
                string[] files = new string[] { "options.txt", "servers.dat", "servers.dat_old" };
                LockUIElements();
                foreach (var dir in folders)
                {
                    if (Directory.Exists(mcPath.Text + "\\" + dir))
                    {
                        await Task.Run(() => PurgeFolder(mcPath.Text + "\\" + dir));
                    }
                }
                foreach (var file in files)
                {
                    if (File.Exists(mcPath.Text + "\\" + file))
                    {
                        File.Delete(mcPath.Text + "\\" + file);
                    }
                }
                UnlockUIElements();
                dotmcFindStatus.Text = "Готово.";
                dotmcFindStatus.ForeColor = Color.Green;
            }
        }
    }
}
