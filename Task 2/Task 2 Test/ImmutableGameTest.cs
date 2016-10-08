using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;

namespace Task_2_Test
{
    [TestClass]
    public class ImmutableGameTest : GameTest
    {
        public new ImmutableGame InitilizationCorrectGame()
        {
            return new ImmutableGame(0, 1, 2, 3, 4, 5, 6, 7, 8);
        }
        
        public new ImmutableGame InitilizationGame(params int[] cells)
        {
            return new ImmutableGame(cells);
        }
        
        [TestMethod]
        public override void Should_CorrectValuesLocation_When_AppliedShift()
        {
            ImmutableGame currentGameBefore = InitilizationCorrectGame();
            ImmutableGame currentGameAfter = InitilizationCorrectGame();

            currentGameAfter.Shift(1);

            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(currentGameBefore.GetLocation(i), currentGameAfter.GetLocation(i));
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
        public void Should_CorrectValuesLocationAtNewGame_When_AppliedShift()
        {
            ImmutableGame game = InitilizationCorrectGame();
            ImmutableGame newGame = InitilizationCorrectGame();

            newGame = game.Shift(1);

            for (int i = 0; i < 9; i++)
            {
                if (i != 0 && i != 1)
                {
                    Assert.AreEqual(newGame.GetLocation(i), game.GetLocation(i));
                }
                else if (i == 0)
                {
                    Assert.AreEqual(newGame.GetLocation(i), game.GetLocation(1));
                }
                else
                {
                    Assert.AreEqual(newGame.GetLocation(i), game.GetLocation(0));
                }
            }
        }

        [TestMethod]
        public override void Should_RealValuesLocationEqualResultGetLocationFromItValue_When_AppliedShift()
        {
            ImmutableGame game = InitilizationCorrectGame();

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
    }
}
