using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode5
{
    public class Canvas
    {
        private readonly int[,] _canvas;
        
        public Canvas(int sizeX, int sizeY)
        {
            _canvas = new int[sizeX + 1, sizeY + 1];
        }

        public void AddLines(IEnumerable<Line> lines)
        {
            foreach (var line in lines)
            {
                foreach (var point in line.GetPoints())
                {
                    _canvas[point.X, point.Y]++;
                }
            }
        }

        public int CalculateOverlappingPoints() => _canvas.Cast<int>().Count(number => number > 1);
    }
    }