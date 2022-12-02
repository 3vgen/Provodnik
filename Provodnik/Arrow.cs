using System;
using System.Collections.Generic;
using System.Text;

namespace Provodnik
{
    public class Arrow
    {
        
        public int upperBound = 2;
        public int bottomBound;
        public int max;
        
        public Arrow(int countOfDirs, int countOfFilse)
        {
            max = countOfDirs + countOfFilse+upperBound;

        }
        public Arrow()
        {

        }
        public void SetCursorToStart(ref int pointerPosition)
        {
            pointerPosition = upperBound;
            Console.SetCursorPosition(0, upperBound);
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
            if (pointerPosition != upperBound)
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
