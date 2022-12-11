using AdventOfCode.Util;

namespace AdventOfCode.Day9;

public static class DayNine
{
    public static void Solve(List<string> test)
    {
        Console.WriteLine("Day 9 ");

        var input = new List<string>();

        input.Add("R 4");
        input.Add("U 4");
        input.Add("L 3");
        input.Add("D 1");
        input.Add("R 4");
        input.Add("D 1");
        input.Add("L 5");
        input.Add("R 2");

        var moves = GetMoves(input);

        // min tanke är att alla positioner är koordinater som har en x och y position 
        // vi kan lägga till att x och y positioner i en hashset som svansen har besökt 
        var visited = new HashSet<(int x, int y)>();

        // vi behöver veta alla positioner som head har varit på, använder mig av x och y koordinater för att uppnå detta
        var headVisited = new List<(int x, int y)>() { (0, 0) };

        // x är horisontell och y är vertikal
        // positivt x värde är åt höger, negativt är åt vänster
        // positivt y värde är uppåt, negativt är nedåt
        int headX, headY;
        headX = headY = 0;

        foreach (var move in moves)
        {
            if (move.direction.Equals('R')) headX += move.steps;
            if (move.direction.Equals('L')) headX -= move.steps;

            if (move.direction.Equals('U')) headY += move.steps;
            if (move.direction.Equals('D')) headY -= move.steps;

            var rangeX = CalculateRangeBetweenOldAndNewPosition(headVisited.Last().x, headX).ToList();
            var rangeY = CalculateRangeBetweenOldAndNewPosition(headVisited.Last().y, headY).ToList();

            if (rangeX.Any()) rangeX.ForEach(f => headVisited.Add((f, headVisited.Last().y)));
            if (rangeY.Any()) rangeY.ForEach(f => headVisited.Add((headVisited.Last().x, f)));

        }

        // nu vet vi hur huvudet rörde sig.. 

        // tailVisited är en hashset för vi vill endast ha unika positioner
        var tailVisited = new HashSet<(int x, int y)>() { (0, 0) };
        int tailX = 0;
        int tailY = 0;

        var lastVisitedHead = headVisited.First();
        foreach (var head in headVisited.Skip(1)) // vi behöver inte veta vart huvudet startade för svansen har samma startposition
        {
            Console.WriteLine(head); 
            // vilken direction har huvudet rört på sig? 

            if (tailX == head.x && tailY == head.y)
            {
                // same spot 
            }


        }

        ConsoleExtensions.PrintList(tailVisited);
    }

    private static List<(char direction, int steps)> GetMoves(List<string> input)
    {
        var moves = new List<(char direction, int steps)>();

        foreach (var i in input)
        {
            var split = i.Split();
            moves.Add((char.Parse(split[0]), Convert.ToInt32(split[1])));
        }

        return moves;
    }

    private static IEnumerable<int> CalculateRangeBetweenOldAndNewPosition(int oldPos, int newPos)
    {
        if (newPos < oldPos)
        {
            for (int i = oldPos - 1; i >= newPos; i--)
            {
                yield return i;
            }
        }
        else
        {
            for (int i = oldPos + 1; i <= newPos; i++)
            {
                yield return i;
            }
        }
    }
}
