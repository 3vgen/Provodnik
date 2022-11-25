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
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("->");
            while (true)
            {
                Provodnik.keyInfo = Console.ReadKey();
                Console.Clear();
                //Provodnik.Out();
                if(Provodnik.keyInfo.Key == ConsoleKey.Enter)
                {
                     Provodnik.Enter();
                }
                if(Provodnik.keyInfo.Key == ConsoleKey.Escape)
                {
                    Provodnik.Escape();
                }
                if(Provodnik.keyInfo.Key==ConsoleKey.DownArrow||Provodnik.keyInfo.Key == ConsoleKey.UpArrow)
                {
                    Provodnik.UpDown();
                }
            }
            
           
        }
    }
}
