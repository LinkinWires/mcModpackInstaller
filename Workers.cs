using System;
using System.IO;
using System.Text.RegularExpressions;
using SharpCompress.Common;
using SharpCompress.Readers;
using SharpCompress.Archives.Zip;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;

namespace mcModpackInstaller
{
    internal class Workers
    {
        /*
        TODO:
        - Add support for installing modpacks from .rar and .7z archives.
         */
        
        string[] ModRubbishFull = { "bendspacks", "CustomDISkins", "defaultconfigs", "journeymap", "patchouli_books", "crafttweaker.log" }; // full names of dirs and files
        string[] ModRubbishPart = { "XaeroWaypoints" }; // partial names of dirs and files

        public enum FindMode
        {
            Exact,
            EndsWith,
            StartsWith,
            Contains
        }

        enum UnzipMode
        {
            DotMinecraft,
            ModsFolder,
            IndividualMods
        }
        /// <summary>
        /// Checks if .minecraft folder exists at %AppData%. Works only on Windows (I'm not even sure if this program will ever receive a port for macOS or Linux).
        /// </summary>
        /// <returns>Returns true if it does exist, otherwise returns false.</returns>
        public bool DoesDotMinecraftExist()
        {
            return Directory.Exists(Environment.GetEnvironmentVariable("appdata") + "\\.minecraft");
        }

        /// <summary>
        /// Deletes all directories and files inside of specified directory. Also deletes files and can delete entire directories.
        /// </summary>
        /// <param name="path">Working directory of directory or file.</param>
        /// <param name="whatToPurge">Directory or file to clean or delete.</param>
        /// <param name="removeDir">If true, deletes entire directory it's working with instead of cleaning directory.</param>
        public void Purge(string path, string whatToPurge, bool removeDir = false)
        {
            if (whatToPurge != "variousMods") // if not dealing with multiple dirs or files per one call
            {
                string fullPath = path + "\\" + whatToPurge;
                if (Directory.Exists(path))
                {
                    if (removeDir)
                    {
                        Directory.Delete(fullPath, true);
                    }
                    else
                    {
                        if (Directory.Exists(fullPath))
                        {
                            foreach (var file in Directory.GetFiles(fullPath))
                            {
                                File.Delete(file);
                            }
                        }
                        else if (File.Exists(fullPath))
                        {
                            foreach (var dir in Directory.GetDirectories(fullPath))
                            {
                                Directory.Delete(dir, true);
                            }
                        }
                    }
                }
                else if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
            else
            {
                // first cleaning/deleting files and dirs with full names
                foreach (var item in ModRubbishFull) 
                {
                    if (Directory.Exists(path + "\\" + item))
                    {
                        if (removeDir)
                        {
                            Directory.Delete(path + "\\" + item, true);
                        }
                        else
                        {
                            foreach (var file in Directory.GetFiles(path + "\\" + item))
                            {
                                File.Delete(file);
                            }
                            foreach (var dir in Directory.GetDirectories(path + "\\" + item))
                            {
                                Directory.Delete(dir, true);
                            }
                        }
                    }
                    else if (File.Exists(path + "\\" + item))
                    {
                        File.Delete(path + "\\" + item);
                    }
                }
                // finding files and dirs which contain partial name and cleaning/deleting them
                DirectoryInfo di = new DirectoryInfo(path);  
                foreach (var item in ModRubbishPart) 
                {
                    foreach (var dirs in di.GetDirectories("*" + item + "*.*"))
                    {
                        if (removeDir)
                        {
                            Directory.Delete(dirs.FullName, true);
                        }
                        else
                        {
                            foreach (var file in Directory.GetFiles(dirs.FullName))
                            {
                                File.Delete(file);
                            }
                            foreach (var dir in Directory.GetDirectories(dirs.FullName))
                            {
                                Directory.Delete(dir, true);
                            }
                        }
                    }
                    foreach (var files in di.GetFiles("*" + item + "*.*"))
                    {
                        File.Delete(files.FullName);
                    }
                }
            }    
        }

        /// <summary>
        /// Installs archive with modpack inside. Supports only zip archives. Supports cases when root of the archive or multiple dirs in the archive contains .minecraft dir itself, inside of .minecraft or just individual mods.
        /// </summary>
        /// <param name="installPath">Full destination path.</param>
        /// <param name="filename">Archive with modpack to install.</param>
        /// <param name="overwrite">Is overwriting files allowed?</param>
        /// <exception cref="Exception">Occurs when method can't figure out the structure of archive. If this happens, it means that the archive has obscure structure that this method doesn't support.</exception>
        /// <exception cref="IOException">Occurs when file is not an valid zip or rar archive.</exception>
        public void InstallModPack(string installPath, string filename, bool overwrite = false)
        {
            UnzipMode mode = UnzipMode.DotMinecraft;
            string file = Path.GetFileName(filename);
            if (File.Exists(filename))
            {
                if (IsInArchive(filename, ".minecraft/", FindMode.Contains))
                {
                    mode = UnzipMode.DotMinecraft;
                }
                else if (IsInArchive(filename, "mods/", FindMode.Contains))
                {
                    mode = UnzipMode.ModsFolder;
                }
                else if (IsInArchive(filename, ".jar", FindMode.EndsWith))
                {
                    mode = UnzipMode.IndividualMods;
                }
                else
                {
                    throw new Exception("The structure of this archive is unsupported.");
                }
                using (Stream stream = File.OpenRead(filename))
                {
                    if (filename.EndsWith(".zip"))
                    {
                        using (ZipArchive zip = ZipArchive.Open(stream))
                        {
                            using (var reader = zip.ExtractAllEntries())
                            {
                                var options = new ExtractionOptions();
                                options.ExtractFullPath = true;
                                if (overwrite)
                                {
                                    options.Overwrite = true;
                                }
                                switch (mode)
                                {
                                    case UnzipMode.DotMinecraft:
                                        string DotMcPath = FindInArchive(filename, ".minecraft/", FindMode.Contains);
                                        string installTo = installPath.Replace(".minecraft", "");
                                        if (!DotMcPath.StartsWith(".minecraft"))
                                        {
                                            string pathToDotMc = DotMcPath.Replace(".minecraft/", "");
                                            string unpackTempPath = "UnpackTemp\\";
                                            string unpackTempStructure = unpackTempPath + pathToDotMc;
                                            string unpackTempFullPath = unpackTempStructure + "\\.minecraft";
                                            Directory.CreateDirectory(unpackTempPath);
                                            reader.WriteAllToDirectory(unpackTempPath, options);
                                            foreach (var dir in Directory.GetDirectories(unpackTempFullPath, "*", SearchOption.AllDirectories))
                                            {
                                                Directory.CreateDirectory(dir.Replace(unpackTempStructure, installTo));
                                            }
                                            foreach (var singleFile in Directory.GetFiles(unpackTempFullPath, "*.*", SearchOption.AllDirectories))
                                            {
                                                if (overwrite)
                                                {
                                                    File.Copy(singleFile, singleFile.Replace(unpackTempStructure, installTo), true);
                                                }
                                                else 
                                                {
                                                    File.Copy(singleFile, singleFile.Replace(unpackTempStructure, installTo));
                                                }
                                            }
                                            Directory.Delete(unpackTempPath, true);
                                        }
                                        else
                                        {
                                            reader.WriteAllToDirectory(installTo, options);
                                        }
                                        break;
                                    case UnzipMode.ModsFolder:
                                        string ModsPath = FindInArchive(filename, "mods/", FindMode.Contains);
                                        if (!ModsPath.StartsWith("mods"))
                                        {
                                            string pathToMods = ModsPath.Replace("mods/", "");
                                            string unpackTempPath = "UnpackTemp\\";
                                            string unpackTempStructure = unpackTempPath + pathToMods;
                                            string unpackTempFullPath = unpackTempStructure + "\\mods";
                                            Directory.CreateDirectory(unpackTempPath);
                                            reader.WriteAllToDirectory(unpackTempPath, options);
                                            foreach (var dir in Directory.GetDirectories(unpackTempFullPath, "*", SearchOption.AllDirectories))
                                            {
                                                Directory.CreateDirectory(dir.Replace(unpackTempStructure, installPath));
                                            }
                                            foreach (var singleFile in Directory.GetFiles(unpackTempFullPath, "*.*", SearchOption.AllDirectories))
                                            {
                                                if (overwrite)
                                                {
                                                    File.Copy(singleFile, singleFile.Replace(unpackTempStructure, installPath), true);
                                                }
                                                else
                                                {
                                                    File.Copy(singleFile, singleFile.Replace(unpackTempStructure, installPath));
                                                }
                                            }
                                            Directory.Delete(unpackTempPath, true);
                                        }
                                        else
                                        {
                                            reader.WriteAllToDirectory(installPath, options);
                                        }
                                        break;
                                    case UnzipMode.IndividualMods:
                                        string InModsPath = FindInArchive(filename, ".jar", FindMode.EndsWith);
                                        string installToIn = installPath + "\\mods\\";
                                        if (InModsPath.Contains("/"))
                                        {
                                            string pathToInMods = Regex.Replace(InModsPath, "[ \\w-]+\\....", "");
                                            string unpackTempPath = "UnpackTemp\\";
                                            string unpackTempFullPath = unpackTempPath + pathToInMods;
                                            Directory.CreateDirectory(unpackTempPath);
                                            reader.WriteAllToDirectory(unpackTempPath, options);
                                            foreach (var singleFile in Directory.GetFiles(unpackTempFullPath, "*.*", SearchOption.AllDirectories))
                                            {
                                                if (overwrite)
                                                {
                                                    File.Copy(singleFile, singleFile.Replace(unpackTempFullPath, installToIn), true);
                                                }
                                                else
                                                {
                                                    File.Copy(singleFile, singleFile.Replace(unpackTempFullPath, installToIn));
                                                }
                                            }
                                            Directory.Delete(unpackTempPath, true);
                                        }
                                        else
                                        {
                                            reader.WriteAllToDirectory(installToIn, options);
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new IOException("File " + filename + " is not an valid zip archive.");
                    }
                }
            }
        }

        /// <summary>
        /// Installs single .jar to the directory.
        /// </summary>
        /// <param name="installPath">Full destination path, including filename.</param>
        /// <param name="filename">Source file</param>
        /// <param name="overwrite">Is overwriting destination file with source file allowed?</param>
        /// <exception cref="IOException">Occurs when trying to overwrite destination file with source file without allowing to.</exception>
        /// <exception cref="FileNotFoundException">Occurs when source file does not exist.</exception>
        public void InstallJar(string installPath, string filename, bool overwrite = false)
        {
            string file = Path.GetFileName(filename);
            if (File.Exists(filename))
            {
                if (!File.Exists(installPath))
                {
                    File.Copy(filename, installPath);
                }
                else
                {
                    if (overwrite)
                    {
                        File.Copy(filename, installPath, true);
                    }
                    else
                    {
                        throw new IOException("File with the name" + file + " already exists in destination.");
                    }    
                }
            }
            else
            {
                throw new FileNotFoundException("File " + filename + "does not exist");
            }
        }

        /// <summary>
        /// Finds any file out of array in archive and tells if any of them does exist. Supports jar, zip, rar and 7z archives.
        /// </summary>
        /// <param name="filename">Full path to the archive.</param>
        /// <param name="filesToFind">Array of files to find in the archive.</param>
        /// <returns>Returns true if any file out of array does exist in the archive, otherwise returns false.</returns>
        /// <exception cref="IOException">Occurs when specified archive is not an jar, zip, rar or 7z archive or is not actually an archive at all.</exception>
        /// <exception cref="FileNotFoundException">Occurs when specified archive does not exist.</exception>
        public bool IsAnyInArchive(string filename, string[] filesToFind, FindMode mode = FindMode.Exact)
        {
            bool anyExists = false;
            if (File.Exists(filename))
            {
                foreach (var file in filesToFind)
                {
                    using (Stream stream = File.OpenRead(filename))
                    {
                        if (filename.EndsWith(".zip") || filename.EndsWith(".jar"))
                        {
                            var archive = ZipArchive.Open(stream);
                            foreach (var entry in archive.Entries)
                            {
                                if (mode == FindMode.Exact)
                                {
                                    if (entry.ToString() == file)
                                    {
                                        anyExists = true;
                                        break;
                                    }
                                }
                                else if (mode == FindMode.StartsWith)
                                {
                                    if (entry.ToString().StartsWith(file))
                                    {
                                        anyExists = true;
                                        break;
                                    }
                                }
                                else if (mode == FindMode.EndsWith)
                                {
                                    if (entry.ToString().EndsWith(file))
                                    {
                                        anyExists = true;
                                        break;
                                    }
                                }
                                else if (mode == FindMode.Contains)
                                {
                                    if (entry.ToString().Contains(file))
                                    {
                                        anyExists = true;
                                        break;
                                    }
                                }
                            }
                        }
                        else if (filename.EndsWith(".rar"))
                        {
                            var archive = RarArchive.Open(stream);
                            foreach (var entry in archive.Entries)
                            {
                                if (mode == FindMode.Exact)
                                {
                                    if (entry.ToString() == file)
                                    {
                                        anyExists = true;
                                        break;
                                    }
                                }
                                else if (mode == FindMode.StartsWith)
                                {
                                    if (entry.ToString().StartsWith(file))
                                    {
                                        anyExists = true;
                                        break;
                                    }
                                }
                                else if (mode == FindMode.EndsWith)
                                {
                                    if (entry.ToString().EndsWith(file))
                                    {
                                        anyExists = true;
                                        break;
                                    }
                                }
                                else if (mode == FindMode.Contains)
                                {
                                    if (entry.ToString().Contains(file))
                                    {
                                        anyExists = true;
                                        break;
                                    }
                                }
                            }
                        }
                        else if (filename.EndsWith(".7z"))
                        {
                            var archive = SevenZipArchive.Open(stream);
                            foreach (var entry in archive.Entries)
                            {
                                if (mode == FindMode.Exact)
                                {
                                    if (entry.ToString() == file)
                                    {
                                        anyExists = true;
                                        break;
                                    }
                                }
                                else if (mode == FindMode.StartsWith)
                                {
                                    if (entry.ToString().StartsWith(file))
                                    {
                                        anyExists = true;
                                        break;
                                    }
                                }
                                else if (mode == FindMode.EndsWith)
                                {
                                    if (entry.ToString().EndsWith(file))
                                    {
                                        anyExists = true;
                                        break;
                                    }
                                }
                                else if (mode == FindMode.Contains)
                                {
                                    if (entry.ToString().Contains(file))
                                    {
                                        anyExists = true;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            throw new IOException("File " + filename + " is not an zip, rar or 7z archive or is not an archive at all.");
                        }
                        if (anyExists)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("File " + filename + " does not exist.");
            }
            return anyExists;
        }

        public string FindInArchive(string filename, string fileToFind, FindMode mode = FindMode.Exact)
        {
            string pathToReturn = "";
            if (File.Exists(filename))
            {
                using (Stream stream = File.OpenRead(filename))
                {
                    if (ZipArchive.IsZipFile(stream) || filename.EndsWith(".jar"))
                    {
                        var archive = ZipArchive.Open(stream);
                        foreach (var entry in archive.Entries)
                        {
                            if (mode == FindMode.Exact)
                            {
                                if (entry.ToString() == fileToFind)
                                {
                                    pathToReturn = entry.ToString();
                                    break;
                                }
                            }
                            else if (mode == FindMode.StartsWith)
                            {
                                if (entry.ToString().StartsWith(fileToFind))
                                {
                                    pathToReturn = entry.ToString();
                                    break;
                                }
                            }
                            else if (mode == FindMode.EndsWith)
                            {
                                if (entry.ToString().EndsWith(fileToFind))
                                {
                                    pathToReturn = entry.ToString();
                                    break;
                                }
                            }
                            else if (mode == FindMode.Contains)
                            {
                                if (entry.ToString().Contains(fileToFind))
                                {
                                    pathToReturn = entry.ToString();
                                    break;
                                }
                            }
                        }
                    }
                    else if (RarArchive.IsRarFile(stream))
                    {
                        var archive = RarArchive.Open(stream);
                        foreach (var entry in archive.Entries)
                        {
                            if (mode == FindMode.Exact)
                            {
                                if (entry.ToString() == fileToFind)
                                {
                                    pathToReturn = entry.ToString();
                                    break;
                                }
                            }
                            else if (mode == FindMode.StartsWith)
                            {
                                if (entry.ToString().StartsWith(fileToFind))
                                {
                                    pathToReturn = entry.ToString();
                                    break;
                                }
                            }
                            else if (mode == FindMode.EndsWith)
                            {
                                if (entry.ToString().EndsWith(fileToFind))
                                {
                                    pathToReturn = entry.ToString();
                                    break;
                                }
                            }
                            else if (mode == FindMode.Contains)
                            {
                                if (entry.ToString().Contains(fileToFind))
                                {
                                    pathToReturn = entry.ToString();
                                    break;
                                }
                            }
                        }
                    }
                    else if (SevenZipArchive.IsSevenZipFile(stream))
                    {
                        var archive = SevenZipArchive.Open(stream);
                        foreach (var entry in archive.Entries)
                        {
                            if (mode == FindMode.Exact)
                            {
                                if (entry.ToString() == fileToFind)
                                {
                                    pathToReturn = entry.ToString();
                                    break;
                                }
                            }
                            else if (mode == FindMode.StartsWith)
                            {
                                if (entry.ToString().StartsWith(fileToFind))
                                {
                                    pathToReturn = entry.ToString();
                                    break;
                                }
                            }
                            else if (mode == FindMode.EndsWith)
                            {
                                if (entry.ToString().EndsWith(fileToFind))
                                {
                                    pathToReturn = entry.ToString();
                                    break;
                                }
                            }
                            else if (mode == FindMode.Contains)
                            {
                                if (entry.ToString().Contains(fileToFind))
                                {
                                    pathToReturn = entry.ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return pathToReturn;
        }

        /// <summary>
        /// Finds single file in archive and tells if it does exist. Supports jar, zip, rar and 7z archives.
        /// </summary>
        /// <param name="filename">Full path to the archive.</param>
        /// <param name="fileToFind">File to find in the archive.</param>
        /// <returns>Returns true if the file does exist in the archive, otherwise returns false.</returns>
        /// <exception cref="IOException">Occurs when specified archive is not an jar, zip, rar or 7z archive or is not actually an archive at all.</exception>
        /// <exception cref="FileNotFoundException">Occurs when specified archive does not exist.</exception>
        public bool IsInArchive(string filename, string fileToFind, FindMode mode = FindMode.Exact)
        {
            bool fileExists = false;
            if (File.Exists(filename))
            {
                using (Stream stream = File.OpenRead(filename))
                {
                    if (filename.EndsWith(".zip") || filename.EndsWith(".jar"))
                    {
                        var archive = ZipArchive.Open(stream);
                        foreach (var entry in archive.Entries)
                        {
                            if (mode == FindMode.Exact)
                            {
                                if (entry.ToString() == fileToFind)
                                {
                                    fileExists = true;
                                    break;
                                }
                            }
                            else if (mode == FindMode.StartsWith)
                            {
                                if (entry.ToString().StartsWith(fileToFind))
                                {
                                    fileExists = true;
                                    break;
                                }
                            }
                            else if (mode == FindMode.EndsWith)
                            {
                                if (entry.ToString().EndsWith(fileToFind))
                                {
                                    fileExists = true;
                                    break;
                                }
                            }
                            else if (mode == FindMode.Contains)
                            {
                                if (entry.ToString().Contains(fileToFind))
                                {
                                    fileExists = true;
                                    break;
                                }
                            }
                        }
                    }
                    else if (filename.EndsWith(".rar"))
                    {
                        var archive = RarArchive.Open(stream);
                        foreach (var entry in archive.Entries)
                        {
                            if (mode == FindMode.Exact)
                            {
                                if (entry.ToString() == fileToFind)
                                {
                                    fileExists = true;
                                    break;
                                }
                            }
                            else if (mode == FindMode.StartsWith)
                            {
                                if (entry.ToString().StartsWith(fileToFind))
                                {
                                    fileExists = true;
                                    break;
                                }
                            }
                            else if (mode == FindMode.EndsWith)
                            {
                                if (entry.ToString().EndsWith(fileToFind))
                                {
                                    fileExists = true;
                                    break;
                                }
                            }
                            else if (mode == FindMode.Contains)
                            {
                                if (entry.ToString().Contains(fileToFind))
                                {
                                    fileExists = true;
                                    break;
                                }
                            }
                        }
                    }
                    else if (filename.EndsWith(".7z"))
                    {
                        var archive = SevenZipArchive.Open(stream);
                        foreach (var entry in archive.Entries)
                        {
                            if (mode == FindMode.Exact)
                            {
                                if (entry.ToString() == fileToFind)
                                {
                                    fileExists = true;
                                    break;
                                }
                            }
                            else if (mode == FindMode.StartsWith)
                            {
                                if (entry.ToString().StartsWith(fileToFind))
                                {
                                    fileExists = true;
                                    break;
                                }
                            }
                            else if (mode == FindMode.EndsWith)
                            {
                                if (entry.ToString().EndsWith(fileToFind))
                                {
                                    fileExists = true;
                                    break;
                                }
                            }
                            else if (mode == FindMode.Contains)
                            {
                                if (entry.ToString().Contains(fileToFind))
                                {
                                    fileExists = true;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new IOException("File " + filename + " is not an zip, rar or 7z archive or is not an archive at all.");
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("File " + filename + " does not exist.");
            }
            return fileExists;
        }
    }
}
