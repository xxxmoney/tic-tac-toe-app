using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Test.Tests.Helpers
{
    public class CircularListTest
    {
        [Test]
        public void Next()
        {
            // Arrange
            var items = new [] { 1, 7, 8, 6 };
            var circular = new Core.Helpers.CircularList<int>(items);
            var expected = new[] { 1, 7, 8, 6, 1, 7 };

            // Act
            var output = new List<int>();
            for (int i = 0; i < expected.Length; i++)
            {
                output.Add(circular.Next());
            }

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(expected, output));
        }

    }
}
