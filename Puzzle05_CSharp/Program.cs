using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Puzzle05_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            var wireA = ParseWire(input[0]);
            var wireB = ParseWire(input[1]);

            var intersections = wireA.Keys.Intersect(wireB.Keys);
            Console.WriteLine(intersections.Min(x => Manhattan(x.Item1, x.Item2)));

            // Part Two. Had to add 2 since I'm not counting 0, 0 on either wire
            Console.WriteLine(intersections.Min(x => wireA[x] + wireB[x]) + 2);
            Console.ReadKey();
        }

        private static int Manhattan(int x, int y)
        {
            return Math.Abs(x) + Math.Abs(y);
        }


        private static Dictionary<Tuple<int, int>, int> ParseWire(string input)
        {
            var r = new Dictionary<Tuple<int, int>, int>();
            int x = 0, y = 0, c = 0;

            foreach (var i in input.Split(','))
            {
                switch (i[0])
                {
                    case 'U':
                        for (int s = 0; s < int.Parse(i.Substring(1)); s++)
                        {
                            var newPoint = Tuple.Create<int, int>(x, ++y);
                            if (!r.ContainsKey(newPoint))
                            {
                                r.Add(newPoint, c++);
                            }                                
                        }
                        break;

                    case 'D':
                        for (int s = 0; s < int.Parse(i.Substring(1)); s++)
                        {
                            var newPoint = Tuple.Create<int, int>(x, ++y);
                            if (!r.ContainsKey(newPoint))
                            {
                                r.Add(newPoint, c++);
                            }                                
                        }
                        break;

                    case 'R':
                        for (int s = 0; s < int.Parse(i.Substring(1)); s++)
                        {
                           var newPoint = Tuple.Create<int, int>(++x, y);
                            if (!r.ContainsKey(newPoint))
                            {
                                r.Add(newPoint, c++);
                            }                                
                        }
                        break;

                    case 'L':
                        for (int s = 0; s<int.Parse(i.Substring(1)); s++)
                        {
                            var newPoint = Tuple.Create<int, int>(--x, y);
                            if (!r.ContainsKey(newPoint))
                            {
                                r.Add(Tuple.Create<int, int>(--x, y), c++);
                            }                            
                        }
                        break;
                }
            }

            return r;
        }
        

    }
}
