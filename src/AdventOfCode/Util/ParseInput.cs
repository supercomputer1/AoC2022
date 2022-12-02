﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Util
{
    public static class ParseInput
    {
        public static List<string> Parse(string filePath)
        {
            return File.ReadAllLines(filePath)
                 .Select(s => s.TrimEnd())
                 .ToList();
        }
    }
}
