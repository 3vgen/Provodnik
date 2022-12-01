using System;
using System.Collections.Generic;
using System.Text;

namespace Provodnik
{
    public class Arrow
    {
        
        public const int min = 2;
        public int max;
        public Arrow(int countOfDirs, int countOfFilse)
        {
            max = countOfDirs + countOfFilse+min;
        }
        public Arrow()
        {

        }
        public void SetCursorToStart(ref int pointerPosition)
        {
            pointerPosition = min;
            Console.SetCursorPosition(0, min);
            Console.WriteLine("->");
        }
        public void Down(ref int pointerPosition)
        {
            if (pointerPosition != max)
            {
                Console.SetCursorPosition(0, pointerPosition);
                Console.WriteLine("  ");
                pointerPosition++;
                Console.SetCursorPosition(0, pointerPosition);
                Console.WriteLine("->");
            }
        }
        public void Up(ref int pointerPosition)
        {
            if (pointerPosition != min)
            {
                Console.SetCursorPosition(0, pointerPosition);
                Console.WriteLine("  ");
                pointerPosition--;
                Console.SetCursorPosition(0, pointerPosition);
                Console.WriteLine("->");
            }
        }
    }
}
