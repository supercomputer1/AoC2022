namespace AdventOfCode.Day4
{
    public class DayFour
    {
        public static void Solve(List<string> input)
        {
            Console.WriteLine("Day 4");

            var pairs = input.SelectMany(s => s.Split('\n'))
                .Select(s => s.Split(','))
                .Select(s => new Pair(s[0], s[1]))
                .ToList();

            int p1 = 0;
            foreach (var pair in pairs)
            {
                if (pair.CleanWhenTheyDoNotNeedTo())
                {
                    p1++;
                }
            }

            int p2 = 0;
            foreach (var pair in pairs)
            {
                if (pair.Overlap())
                {
                    p2++;
                }
            }

            Console.WriteLine($"Part one: {p1}");
            Console.WriteLine($"Part two: {p2}");
        }
    }

    public class Pair
    {
        public readonly Elf elfOne;
        public readonly Elf elfTwo;

        public Pair(string elfOne, string elfTwo)
        {
            this.elfOne = new Elf(elfOne);
            this.elfTwo = new Elf(elfTwo);
        }

        public bool CleanWhenTheyDoNotNeedTo()
        {
            if (elfOne.GetRange().Except(elfTwo.GetRange()).Count() == 0) return true;
            if (elfTwo.GetRange().Except(elfOne.GetRange()).Count() == 0) return true;
            return false;
        }

        public bool Overlap()
        {
            if (elfOne.GetRange().Intersect(elfTwo.GetRange()).Count() > 0) return true;
            return false;
        }
    }

    public class Elf
    {
        private readonly int start;
        private readonly int end;

        public Elf(string startEnd)
        {
            var split = startEnd.Split('-');
            start = Convert.ToInt32(split[0]);
            end = Convert.ToInt32(split[1]);
        }

        public List<int> GetRange()
        {
            var tempStart = start;
            var result = new List<int>();
            while (tempStart <= end)
            {
                result.Add(tempStart);
                tempStart++;
            }

            return result;
        }
    }
}
