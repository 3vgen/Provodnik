using System.Collections.Generic;
using System.IO;
using System;

namespace Provodnik
{
    class Program
    {
        static void Main(string[] args)
        {
            Provodnik.ChooseDrive();
            //Provodnik.ShowDirectoryContents();
            Arrow ar = new Arrow();
            ar.SetCursorToStart(ref Provodnik.pointerPosistion);
            while (true)
            {
                Provodnik.keyInfo = Console.ReadKey();
               
                if(Provodnik.keyInfo.Key == ConsoleKey.Enter)
                {
                    try
                    {
                        if (Provodnik.path == "")
                        {
                            Provodnik.OpenDrive();
                            ar = new Arrow(Provodnik.dirs.Count, Provodnik.files.Count);
                        }
                        else if (Provodnik.pointerPosistion < Provodnik.dirs.Count + 2)
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
                else if (Provodnik.keyInfo.Key == ConsoleKey.Escape)
                {
                    if (Provodnik.path == "") Provodnik.OpenDrive(); 
                    Provodnik.ReturnToBack();
                }
                else if (Provodnik.keyInfo.Key==ConsoleKey.DownArrow)
                {
                    ar.Down(ref Provodnik.pointerPosistion);
              
                }
                else if (Provodnik.keyInfo.Key == ConsoleKey.UpArrow)
                {
                    ar.Up(ref Provodnik.pointerPosistion);
                }
            }
            
           
        }
    }
}
