using System.Collections.Generic;
using System.IO;
using System;

namespace Provodnik
{
    class Program
    {
        static void Main(string[] args)
        {
            Provodnik.Out();
            Arrow ar = new Arrow();
            ar.SetCursorToStart(ref Provodnik.pointerPosistion);
            while (true)
            {
                Provodnik.keyInfo = Console.ReadKey();
                //Console.Clear();
                //Provodnik.Out();
                if(Provodnik.keyInfo.Key == ConsoleKey.Enter)
                {
                     Provodnik.Enter();
                }
                if(Provodnik.keyInfo.Key == ConsoleKey.Escape)
                {
                    Provodnik.Escape();
                }
                if(Provodnik.keyInfo.Key==ConsoleKey.DownArrow)
                {
                    ar = new Arrow(Provodnik.dirs.Count, Provodnik.files.Count);
                    ar.Down(ref Provodnik.pointerPosistion);
              
                }
                if (Provodnik.keyInfo.Key == ConsoleKey.UpArrow)
                {
                    ar = new Arrow(Provodnik.dirs.Count, Provodnik.files.Count);
                    ar.Up(ref Provodnik.pointerPosistion);
                    
                }
            }
            
           
        }
    }
}
