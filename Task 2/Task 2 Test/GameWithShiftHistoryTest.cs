using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;

namespace Task_2_Test
{
    [TestClass]
    public class GameWithShiftHistoryTest : GameTest
    {
        public new GameWithShiftHistory InitilizationCorrectGame()
        {
            return new GameWithShiftHistory(0, 1, 2, 3, 4, 5, 6, 7, 8);
        }
        
        public new GameWithShiftHistory InitilizationGame(params int[] cells)
        {
            return new GameWithShiftHistory(cells);
        }

        [TestMethod]
        public override void Should_RealValuesLocationEqualResultGetLocationFromItValue_When_AppliedShift()
        {
            var game = InitilizationCorrectGame();

            game.Shift(1);

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    int value = x * 3 + y;
                    Location valueLocation = game.GetLocation(value);

                    Assert.AreEqual(x, valueLocation.X);
                    Assert.AreEqual(y, valueLocation.Y);
                }
            }
        }

        [TestMethod]
        public override void Should_RealValueEqualResultIndexerFromItValueLocation_When_AppliedShift()
        {
            var game = InitilizationCorrectGame();

            game.Shift(1);

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    int value = x * 3 + y;

                    Assert.AreEqual(value, game[x, y]);
                }
            }
        }

        [TestMethod]
        public void Should_RealValueEqualResultIndexerFromItValueLocationAtNewGame_When_AppliedShift()
        {
            var game = InitilizationCorrectGame();

            game = game.Shift(1);

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
        public void Should_RealValuesLocationEqualResultGetLocationFromItValueByNewGame_When_AppliedShift()
        {
            var game = InitilizationCorrectGame();

            var newGame = game.Shift(1);

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    int value = x * 3 + y;
                    Location valueLocation = newGame.GetLocation(value);

                    if (value == 0)
                    {
                        valueLocation = newGame.GetLocation(1);
                    }
                    else if (value == 1)
                    {
                        valueLocation = newGame.GetLocation(0);
                    }

                    Assert.AreEqual(x, valueLocation.X);
                    Assert.AreEqual(y, valueLocation.Y);
                }
            }
        }
    }
}
