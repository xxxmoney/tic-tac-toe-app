using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Models;

namespace TicTacToe.Test.Tests.Helpers
{
    public class PositionHelperTest
    {
        public static object[] GetMainDiagonalLeftCornerCaseSource =
        {
            new object[] 
            { 
                new Position
                {
                    X = 2,
                    Y = 2   
                },
                new Position
                {
                    X = 0,
                    Y = 0
                }
            },
            new object[]
            {
                new Position
                {
                    X = 3,
                    Y = 2
                },
                new Position
                {
                    X = 1,
                    Y = 0
                }
            },
            new object[]
            {
                new Position
                {
                    X = 4,
                    Y = 6
                },
                new Position
                {
                    X = 0,
                    Y = 2
                }
            }
        };
        [Test]
        [TestCaseSource(nameof(GetMainDiagonalLeftCornerCaseSource))]
        public void GetMainDiagonalLeftCorner(Position input, Position expected)
        {
            // Arrange

            // Act
            var result = Core.Helpers.PositionHelper.GetMainDiagonalLeftCorner(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        static object[] GetAntiDiagonalLeftCornerCaseSource =
        {
            new object[]
            {
                new Position
                {
                    X = 5,
                    Y = 6
                },
                9,
                new Position
                {
                    X = 3,
                    Y = 8
                }
            },
            new object[]
            {
                new Position
                {
                    X = 2,
                    Y = 2
                },
                9,
                new Position
                {
                    X = 0,
                    Y = 4
                }
            }
        };
        [Test]
        [TestCaseSource(nameof(GetAntiDiagonalLeftCornerCaseSource))]
        public void GetAntiDiagonalLeftCorner(Position input, int yLimit, Position expected)
        {
            // Arrange

            // Act
            var result = Core.Helpers.PositionHelper.GetAntiDiagonalLeftCorner(input, yLimit);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
