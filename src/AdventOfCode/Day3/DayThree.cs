using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3
{
    public static class DayThree
    {
        private static Dictionary<char, int> priorities = CreatePrio(); 
        public static void Solve()
        {
            Console.WriteLine("Day 3");
            var input = Parser.ParseAsList("..//..//..//Day3//input.txt");

            int p1 = 0; 
            foreach (var line in input)
            {
                var firstHalf = line.Substring(0, line.Length / 2);
                var secondHalf = line.Substring(line.Length / 2);
                var c = firstHalf.Intersect(secondHalf).First(); 
                p1 += priorities[c]; 
            }

            int p2 = 0;
            int i = 0; 
            while (i < input.Count)
            {
                var c = input[i].Intersect(input[i+1]).Intersect(input[i+2]).First();
                p2 += priorities[c];
                i += 3; 
            }


            Console.WriteLine($"Part one: {p1}");
            Console.WriteLine($"Part two: {p2}");
        }


        private static Dictionary<char, int> CreatePrio()
        {
            var dict = new Dictionary<char, int>();

            int count = 1; 
            for (char c = 'a'; c <= 'z'; c++)
            {
                dict.Add(c, count);
                count++; 
            }

            count = 27; 
            for (char c = 'A'; c <= 'Z'; c++)
            {
                dict.Add(c, count);
                count++; 
            }

            return dict; 
        }

    }
}
