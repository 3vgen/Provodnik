using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Provodnik
{
    public static class Provodnik
    {
        public static ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        public static List<string> dirs; //список директорий 
        public static List<string> files; //cписок файлов
        private static DirectoryInfo dr; 
        private static FileInfo fl;
        static public string path = @"C:\Users\МБОУ ЦО 2\Desktop\учеба";
        static public int pointerPosistion = 1;

        static public void Enter()
        {
            for (int i = 0; i < dirs.Count; i++)
            {
                if (i == pointerPosistion-1)
                {
                    Console.Clear();
                    
                    path = dirs[i - 1];
                    Out();
                    break;
                }
            }
            Arrow ar = new Arrow();
            ar.SetCursorToStart(ref pointerPosistion);
            //for (int i = dirs.Count; i < files.Count; i++)
            //{
            //    if (i == pointerPosistion)
            //    {
            //        FileInfo f = new FileInfo(files[i]);
            //        File.OpenRead(f.FullName.ToString());
            //    }
            //}
        }
        static public void Escape()
        {
            string[] partOfPath = path.Split('\\');
            path = @"";
            for (int i = 0; i < partOfPath.Length - 1; i++)
            {
                path += partOfPath[i];
                path += '\\';
            }
            path = path.TrimEnd('\\');
            Out();
            Arrow ar = new Arrow();
            ar.SetCursorToStart(ref pointerPosistion);
        }



        static public void Out()
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
                dr = new DirectoryInfo(item);
                truncatedTitle = dr.Name;
                if (truncatedTitle.Length > 32)
                {
                    truncatedTitle = truncatedTitle.Substring(0, 29);
                    truncatedTitle += "...";
                }
                Console.WriteLine("  {0,31}{1,21}{2,30}", truncatedTitle, dr.LastWriteTime, dr.Attributes);
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
