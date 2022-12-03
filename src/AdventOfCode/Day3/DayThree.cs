using AdventOfCode.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.DayThree
{
    public static class DayThree
    {

        private static Dictionary<char, int> priorities = CreatePrio(); 

        public static void Solve()
        {
            Console.WriteLine("Day 3");
            var input = Parser.ParseAsList("..//..//..//Day3//input.txt");

            Console.WriteLine($"Part one: {SolvePartOne(input)}");
            Console.WriteLine($"Part two: {SolvePartTwo(input)}");
        }

        private static int SolvePartOne(List<string> input)
        {
            var rucksacks = new List<Rucksack>();
            foreach (var i in input)
            {
                var firstHalf = i.Substring(0, i.Length / 2);
                var secondHalf = i.Substring(i.Length / 2);

                rucksacks.Add(new Rucksack(firstHalf, secondHalf));
            }

            var result = new List<int>();  
            foreach (var rucksack in rucksacks)
            {
                int prio = priorities[rucksack.GetCommonCharacter()];
                result.Add(prio); 
            }

            return result.Sum(); 
        }

        private static int SolvePartTwo(List<string> input)
        {
            int counter = 1;
            var group = new List<string>();
            var stackedRucksacks = new List<RucksackWithBadges>(); 
            foreach (var i in input)
            {
                group.Add(i);
                counter++; 

                if (counter == 4)
                {
                    stackedRucksacks.Add(new RucksackWithBadges(group[0], group[1], group[2]));    
                    counter = 1;
                    group.Clear(); 
                }
            }

            var result = new List<int>();  
            foreach (var rucksack in stackedRucksacks)
            {
                int prio = priorities[rucksack.GetCommonCharacter()];
                result.Add(prio); 
            }

            return result.Sum();  
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
