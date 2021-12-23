using System;
using System.Linq;
using AdventOfCode5;
using Xunit;

namespace TestProject1
{
    public class LineTest
    {
        [Fact]
        public void Test1()
        {
            var startX = 0;
            var startY = 9;
            var endX = 5;
            var endY = 9;
            var text = $"{startX},{startY} -> {endX},{endY}";

            var result = new Line(text);
            
            Assert.Equal(startX, result.StartPoint.X);
            Assert.Equal(startY, result.StartPoint.Y);
            Assert.Equal(endX, result.EndPoint.X);
            Assert.Equal(endY, result.EndPoint.Y);
            Assert.Equal(result.GetMaxX(), endX);
            Assert.Equal(result.GetMaxY(), endY);
        }
        
        [Fact]
        public void Test2()
        {
            var text = $"1,1 -> 1,3";
            var line = new Line(text);

            var result = line.GetPoints();

            Assert.Equal(3, result.Count());
            Assert.All(result.Select(x => x.X), x => Assert.Equal(1, x));
            Assert.Collection(result.Select(x => x.Y), 
                item => Assert.Equal(1, item),
                item => Assert.Equal(2, item),
                item => Assert.Equal(3, item));
        }
        
        [Fact]
        public void Test3()
        {
            var text = $"9,7 -> 7,7";
            var line = new Line(text);

            var result = line.GetPoints();

            Assert.Equal(3, result.Count());
            Assert.All(result.Select(x => x.Y), x => Assert.Equal(7, x));
            Assert.Collection(result.Select(x => x.X), 
                item => Assert.Equal(9, item),
                item => Assert.Equal(8, item),
                item => Assert.Equal(7, item));
        }
        
        [Fact]
        public void Test4()
        {
            var text = $"1,1 -> 3,3";
            var line = new Line(text);

            var result = line.GetPoints();

            Assert.Equal(3, result.Count());
            Assert.Collection(result, 
                item => Assert.Equal(line.StartPoint, item),
                item =>
                {
                    Assert.Equal(2, item.X);
                    Assert.Equal(2, item.Y);
                },
                item => Assert.Equal(line.EndPoint, item));
        }
        
        [Fact]
        public void Test5()
        {
            var text = $"9,7 -> 7,9";
            var line = new Line(text);

            var result = line.GetPoints();

            Assert.Equal(3, result.Count());
            Assert.Collection(result, 
                item => Assert.Equal(line.StartPoint, item),
                item =>
                {
                    Assert.Equal(8, item.X);
                    Assert.Equal(8, item.Y);
                },
                item => Assert.Equal(line.EndPoint, item));
        }
    }
}