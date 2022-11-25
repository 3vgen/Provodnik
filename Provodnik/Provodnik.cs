using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Provodnik
{
    public static class Provodnik
    {
        public static ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        private static List<string> dirs; //список директорий 
        private static List<string> files;
        static int Length = dirs.Count + files.Count;
        private static DirectoryInfo dr;
        private static FileInfo fl;
        static public string path = @"C:\Users\МБОУ ЦО 2\Desktop\учеба";
        static int pointerPosistion = 1;
        static public void UpDown()
        {
            string arrow = "->";
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                pointerPosistion++;
            }
            if (keyInfo.Key == ConsoleKey.UpArrow && pointerPosistion != 1)
            {
                pointerPosistion--;
            }
            Out();
            Console.SetCursorPosition(0, pointerPosistion);
            Console.WriteLine(arrow);
        }

        static public void Enter()
        {

            for (int i = 0; i < dirs.Count; i++)
            {
                if (i == pointerPosistion)
                {
                    Console.Clear();
                    pointerPosistion = 2;
                    path = dirs[i - 1];
                    Out();
                    break;
                }
            }
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
            Console.Clear();
            //pointerPosistion = 1;
            //path = dr.Parent.Parent.FullName;
            string[] partOfPath = path.Split('\\');
            path = @"";
            for (int i = 0; i < partOfPath.Length - 1; i++)
            {
                path += partOfPath[i];
                path += '\\';
            }
            path = path.TrimEnd('\\');
            Out();

        }



        static public void Out()
        {
            Console.WriteLine("  Имя" + '\t' + '\t' + '\t' + '\t' +
               "|Дата изменения" + '\t' + '\t' + '\t' + '\t' +
               "|Тип" + '\t' + '\t' +
               "|Размер   |");
            dirs = new List<string>(Directory.EnumerateDirectories(path));
            files = new List<string>(Directory.EnumerateFiles(path));
            foreach (var item in dirs)
            {

                dr = new DirectoryInfo(item);
                Console.WriteLine("{0,31}{1,21}{2,30}", dr.Name, dr.LastWriteTime, dr.Attributes);
                //Console.WriteLine($"  {dr.Name}\t\t\t\t {dr.LastWriteTime}\t\t\t{dr.Attributes}");

            }
            foreach (var item in files)
            {

                fl = new FileInfo(item);
                Console.WriteLine("{0,31}{1,21}{2,30}{3,15}", fl.Name, fl.LastWriteTime, fl.Extension, fl.Length);
            }
        }
    }
}
