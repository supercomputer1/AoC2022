using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.DayThree
{

    public class RucksackWithBadges
    {
        private readonly string first; 
        private readonly string second; 
        private readonly string third; 

        public RucksackWithBadges(string first, string second, string third)
        {
            this.first = first; 
            this.second = second;
            this.third = third;
        }

        public char GetCommonCharacter()
        {
            return first.Intersect(second).Intersect(third).First(); 
        }
    }
}
