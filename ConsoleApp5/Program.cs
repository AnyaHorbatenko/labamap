using Kse.Algorithms.Samples;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var globalHeight = 16;
            var globalWidth = 160;
            var generator = new MapGenerator(new MapGeneratorOptions()
            {
                Height = globalHeight,
                Width = globalWidth,
                AddTraffic = true,
                TrafficSeed = 17
            });
            
            string[,] map = generator.Generate();
            var toStart = new Point(0, 0);
            var finish = new Point(globalWidth - 2, globalHeight - 2);
            List<Point> path = GetShortestPath(map, toStart, finish);
            new MapPrinter().Print(map, path);

            List<Point> GetShortestPath(string[,] localMap, Point start, Point goal)
            {
                var endPoint = goal;
                var frontier = new Queue<Point>();
                var locPath = new List<Point> { start };
                frontier.Enqueue(start);
                while (frontier.Count != 0)
                {
                    var current = frontier.Dequeue();
                    var availablePoint = SearchNearbyPoints(localMap, current);
                    foreach (var point in availablePoint)
                    {
                        if  ;
                    }
                }
            }






            List<Point> SearchNearbyPoints(string[,] localMap2, Point current)
            {
                List<Point> available = new List<Point>();
                if (current.Column - 1 >= 0 && current.Column - 1 <= globalWidth - 1 && current.Row <= globalWidth - 1)
                {
                    if (localMap2[current.Column - 1, current.Row] != "█")
                    {
                        available.Add(new Point(current.Column - 1, current.Row));
                    }
                }

                if (current.Column + 1 >= 0 && current.Column + 1 <= globalWidth - 1 && current.Row <= globalWidth - 1)
                {
                    if (localMap2[current.Column + 1, current.Row] != "█")
                    {
                        available.Add(new Point(current.Column + 1, current.Row));
                    }
                }

                if (current.Row - 1 >= 0 && current.Row - 1 <= globalHeight - 1 && current.Column <= globalWidth - 1)
                {
                    if (localMap2[current.Column, current.Row - 1] != "█")
                    {
                        available.Add(new Point(current.Column, current.Row - 1));
                    }
                }

                if (current.Row + 1 >= 0 && current.Row + 1 <= globalHeight - 1 && current.Column <= globalWidth - 1)
                {
                    if (localMap2[current.Column, current.Row + 1] != "█")
                    {
                        available.Add(new Point(current.Column, current.Row + 1));
                    }
                }
                return available;
            }

        }
    }
}