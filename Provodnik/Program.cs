using System.Collections.Generic;
using System.IO;
using System;

namespace Provodnik
{
    class Program
    {
        static void Main(string[] args)
        {

            //Provodnik.ChooseDrive();
            //Provodnik.OpenDirectory();
            Provodnik.Out();
            Arrow ar = new Arrow();
            ar.SetCursorToStart(ref Provodnik.pointerPosistion);
            while (true)
            {
                Provodnik.keyInfo = Console.ReadKey();
                if(Provodnik.keyInfo.Key == ConsoleKey.Enter)
                {
                    try
                    {
                        if (Provodnik.pointerPosistion < Provodnik.dirs.Count + 2)
                        {
                            Provodnik.OpenDirectory();
                            ar = new Arrow(Provodnik.dirs.Count, Provodnik.files.Count);
                        }
                        else
                        {
                            Provodnik.OpenFile();
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Нет доступа к данной папке или файлу");
                    }

                }
                if (Provodnik.keyInfo.Key == ConsoleKey.Escape)
                {
                    Provodnik.Escape();
                    ar = new Arrow(Provodnik.dirs.Count, Provodnik.files.Count);

                }
                if (Provodnik.keyInfo.Key==ConsoleKey.DownArrow)
                {
                    ar.Down(ref Provodnik.pointerPosistion);
              
                }
                if (Provodnik.keyInfo.Key == ConsoleKey.UpArrow)
                {
                    ar.Up(ref Provodnik.pointerPosistion);
                }
            }
            
           
        }
    }
}
