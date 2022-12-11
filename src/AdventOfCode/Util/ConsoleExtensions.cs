using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Util
{
    public static class ConsoleExtensions
    {
        public static void Print<T>(object content)
        {
            Console.WriteLine(content.ToString());
        }

        public static void PrintList<T>(IEnumerable<T> content)
        {
            foreach (var c in content)
            {
                Console.WriteLine(c.ToString());
            }
        }

    }
}
