using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.DayOne
{
    public static class DayOne
    {
        public static void Solve()
        {
            Console.WriteLine("Day 1");
            var input = Parser.ParseAsList("..//..//..//Day1//input.txt");

            var result = new List<int>();
            int counter = 0;

            foreach (var i in input)
            {
                if (i == string.Empty)
                {
                    result.Add(counter);
                    counter = 0;
                }
                else
                {
                    counter += Convert.ToInt32(i);
                }
            }


            Console.WriteLine($"Part one: {result.Max(m => m)}");
            Console.WriteLine($"Part two: {result.OrderBy(o => o).TakeLast(3).Sum(s => s)}");
        }
    }
}
