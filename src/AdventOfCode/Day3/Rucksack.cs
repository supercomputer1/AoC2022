using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.DayThree
{
    public class Rucksack
    {
        private readonly string firstCompartment; 
        private readonly string lastCompartment; 
        public Rucksack(string firstCompartment, string lastCompartment)
        {
            this.firstCompartment = firstCompartment;
            this.lastCompartment = lastCompartment;
        }

        public char GetCommonCharacter()
        {
            return firstCompartment.Intersect(lastCompartment).First(); 
        }
    }
}
