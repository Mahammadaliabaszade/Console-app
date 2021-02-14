using System;
using System.Collections.Generic;
using System.Text;

namespace csharp30
{
     static class Helper
    {

        public static void Print(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
