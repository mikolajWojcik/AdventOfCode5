using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode5
{
    public class Line
    {
        public Point StartPoint { get; }
        public Point EndPoint { get; }

        public Line(string input)
        {
            var segments = input.Split(" -> ");

            StartPoint = GetPointFromSegment(segments[0]);
            EndPoint = GetPointFromSegment(segments[1]);
        }

        public int GetMaxX() => Math.Max(StartPoint.X, EndPoint.X);
        public int GetMaxY() => Math.Max(StartPoint.Y, EndPoint.Y);

        public IEnumerable<Point> GetPoints()
        {
            var deltaX = StartPoint.X - EndPoint.X;
            var deltaY = StartPoint.Y - EndPoint.Y;

            var point = StartPoint;

            while (point.X != EndPoint.X || point.Y != EndPoint.Y)
            {
                yield return point;

                var newX = deltaX == 0 ? point.X : deltaX > 0 ? point.X - 1 : point.X + 1;
                var newY = deltaY == 0 ? point.Y : deltaY > 0 ? point.Y - 1 : point.Y + 1;

                point = new Point(newX, newY);
            }

            yield return EndPoint;
        }

        private Point GetPointFromSegment(string segment)
        {
            var pointsText = segment.Split(",");
            var coordinates = pointsText.Select(int.Parse).ToList();
            return new Point(coordinates[0], coordinates[1]);
        }
    }
    
    public record Point(int X, int Y)
    {
        public int X { get; } = X;
        public int Y { get; } = Y;
    }
}