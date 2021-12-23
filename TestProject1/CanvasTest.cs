using System.Collections.Generic;
using AdventOfCode5;
using Xunit;

namespace TestProject1
{
    public class CanvasTest
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var lines = new List<Line>
            {
                new Line("0,9 -> 5,9"),
                new Line("8,0 -> 0,8"),
                new Line("9,4 -> 3,4"),
                new Line("2,2 -> 2,1"),
                new Line("7,0 -> 7,4"),
                new Line("6,4 -> 2,0"),
                new Line("0,9 -> 2,9"),
                new Line("3,4 -> 1,4"),
                new Line("0,0 -> 8,8"),
                new Line("5,5 -> 8,2")
            };

            var canvas = new Canvas(9, 9);
            canvas.AddLines(lines);
            
            //act
            var result = canvas.CalculateOverlappingPoints();
            
            //assert
            Assert.Equal(12, result);
        }
    }
}