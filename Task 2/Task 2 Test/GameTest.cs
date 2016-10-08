using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;

namespace Task_2_Test
{
    [TestClass]
    public class GameTest
    {
        public Game InitilizationCorrectGame()
        {
            return new Game(0, 1, 2, 3, 4, 5, 6, 7, 8);
        }
        
        public Game InitilizationGame(params int[] cells)
        {
            return new Game(cells);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowArgumentException_When_CountFieldsIsNotPerfectSquare()
        {
            var game = InitilizationGame(1, 0);
            game = InitilizationGame(1, 2, 0);
            game = InitilizationGame(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowArgumentException_When_CellsHaveDublicateValue()
        {
            var game = InitilizationGame(1, 2, 3, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowArgumentException_When_ValueFieldIncorrect()
        {
            var game = InitilizationGame(1, 2, 4, 0);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowArgumentException_When_NoPlaceForMove()
        {
            var game = InitilizationCorrectGame();

            game.Shift(1);
            game.Shift(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowArgumentException_When_ValueNotExistOr()
        {
            var game = InitilizationCorrectGame();

            game.Shift(10);
            game.Shift(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowArgumentException_When_ValueIsZero()
        {
            var game = InitilizationCorrectGame();

            game.Shift(0);
        }

        [TestMethod]
        public virtual void Should_CorrectValuesLocation_When_AppliedShift()
        {
            var gameBefore = InitilizationCorrectGame();
            var gameAfter = InitilizationCorrectGame();

            gameAfter.Shift(1);

            for (int i = 0; i < 9; i++)
            {
                if (i != 0 && i != 1)
                {
                    Assert.AreEqual(gameBefore.GetLocation(i), gameAfter.GetLocation(i));
                }
                else if (i == 0)
                {
                    Assert.AreEqual(gameBefore.GetLocation(i), gameAfter.GetLocation(1));
                }
                else
                {
                    Assert.AreEqual(gameBefore.GetLocation(i), gameAfter.GetLocation(0));
                }
            }
        }

        [TestMethod]
        public void Should_RealValueEqualResultIndexerFromItValueLocation_When_GameIsCorrect()
        {
            var game = InitilizationCorrectGame();

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Assert.AreEqual(x * 3 + y, game[x, y]);
                }
            }
        }

        [TestMethod]
        public virtual void Should_RealValueEqualResultIndexerFromItValueLocation_When_AppliedShift()
        {
            var game = InitilizationCorrectGame();

            game.Shift(1);

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    int value = x * 3 + y;

                    if (value == 0)
                    {
                        value = 1;
                    }
                    else if (value == 1)
                    {
                        value = 0;
                    }

                    Assert.AreEqual(value, game[x, y]);
                }
            }
        }

        [TestMethod]
        public virtual void Should_RealValuesLocationEqualResultGetLocationFromItValue_When_GameIsCorrect()
        {
            var game = InitilizationCorrectGame();

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Assert.AreEqual(x, game.GetLocation(x * 3 + y).X);
                    Assert.AreEqual(y, game.GetLocation(x * 3 + y).Y);
                }
            }
        }

        [TestMethod]
        public virtual void Should_RealValuesLocationEqualResultGetLocationFromItValue_When_AppliedShift()
        {
            var game = InitilizationCorrectGame();

            game.Shift(1);

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    int value = x * 3 + y;
                    Location valueLocation = game.GetLocation(value);

                    if (value == 0)
                    {
                        valueLocation = game.GetLocation(1);
                    }
                    else if (value == 1)
                    {
                        valueLocation = game.GetLocation(0);
                    }

                    Assert.AreEqual(x, valueLocation.X);
                    Assert.AreEqual(y, valueLocation.Y);
                }
            }
        }
    }
}
