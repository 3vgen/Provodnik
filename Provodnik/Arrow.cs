using System;
using System.Collections.Generic;
using System.Text;

namespace Provodnik
{
    public class Arrow
    {
        
        public const int min = 1;
        public int max;
        public Arrow(int countOfDirs, int countOfFilse)
        {
            max = countOfDirs + countOfFilse;
        }
    }
}
