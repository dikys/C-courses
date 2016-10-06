using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;

namespace Task_2_Test
{
    [TestClass]
    public class ImmutableGameTest : GameTest
    {
        public static new ImmutableGame InitilizationCorrectGame()
        {
            return new ImmutableGame(0, 1, 2, 3, 4, 5, 6, 7, 8);
        }

        public static new ImmutableGame InitilizationGame(params int[] cells)
        {
            return new ImmutableGame(cells);
        }

        [TestMethod]
        public override void CheckWork_Shift()
        {
            ImmutableGame gameBefore = InitilizationCorrectGame();
            ImmutableGame gameAfter;

            gameAfter = gameBefore.Shift(1);

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
    }
}
