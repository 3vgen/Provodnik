using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Provodnik
{
    public static class Provodnik
    {
        public static ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        public static List<string> dirs; //список директорий 
        public static List<string> files; //cписок файлов
        private static DriveInfo[] allDrives = DriveInfo.GetDrives();

        private static DirectoryInfo dir; 
        private static FileInfo fl;
        //static public string path = @"C:\Users\МБОУ ЦО 2\Desktop\учеба";
        static public string path = @"";

        static public int pointerPosistion = 1;

        static public void ChooseDrive()
        {
            path = @"";
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("  Выберите диск");
           foreach(var item in allDrives)
            {
                Console.WriteLine($"  {item.Name}");
            }

        }
        static public void OpenDrive()
        {
            path = allDrives[pointerPosistion - 2].Name;
            ShowDirectoryContents();
        }
        static public void OpenDirectory()
        {
            for (int i = 0; i < dirs.Count; i++)
            {
                if (i == pointerPosistion-1)
                {
                    Console.Clear();
                    
                    path = dirs[i - 1];
                    ShowDirectoryContents();
                    break;
                }
            }
            Arrow ar = new Arrow();
            ar.SetCursorToStart(ref pointerPosistion);
        }
        static public void OpenFile()
        {
            Process.Start(new ProcessStartInfo(files[pointerPosistion-2]) { UseShellExecute = true});
        }
        static public void ReturnToBack()
        {
            string[] partOfPath = path.Split('\\');
            path = @"";
            for (int i = 0; i < partOfPath.Length - 1; i++)
            {
                path += partOfPath[i];
                path += '\\';
            }
            if (partOfPath.Length != 2) path = path.TrimEnd('\\');
            if (path.Length == 3) ChooseDrive();
            else ShowDirectoryContents();
            Arrow ar = new Arrow();
            ar.SetCursorToStart(ref pointerPosistion);
        }



        static public void ShowDirectoryContents()
        {
            Console.Clear();
            Console.WriteLine(path);
            Console.WriteLine("  Имя" + '\t' + '\t' + '\t' + '\t' +
               "|Дата изменения" + '\t' + '\t' + '\t' + '\t' +
               "  |Тип" + '\t' + '\t' +
               "|Размер   |");
            dirs = new List<string>(Directory.EnumerateDirectories(path));
            files = new List<string>(Directory.EnumerateFiles(path));
            string truncatedTitle;
            foreach (var item in dirs)
            {
                dir = new DirectoryInfo(item);
                truncatedTitle = dir.Name;
                if (truncatedTitle.Length > 32)
                {
                    truncatedTitle = truncatedTitle.Substring(0, 29);
                    truncatedTitle += "...";
                }
                Console.WriteLine("  {0,31}{1,21}{2,30}", truncatedTitle, dir.LastWriteTime, dir.Attributes);
            }

            foreach (var item in files)
            {
                fl = new FileInfo(item);
                truncatedTitle = fl.Name;
                if (truncatedTitle.Length > 32)
                {
                    truncatedTitle = truncatedTitle.Substring(0, 29);
                    truncatedTitle += "...";
                }
     
                Console.WriteLine("  {0,31}{1,21}{2,30}{3,15}", truncatedTitle, fl.LastWriteTime, fl.Extension, fl.Length);

            }
            Console.SetCursorPosition(0, 0);//необходимо для вывода сверху экрана
        }
    }
}
