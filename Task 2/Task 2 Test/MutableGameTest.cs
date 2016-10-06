using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;

namespace Task_2_Test
{
    [TestClass]
    public class MutableGameTest : GameTest
    {
        public static new MutableGame InitilizationCorrectGame()
        {
            return new MutableGame(0, 1, 2, 3, 4, 5, 6, 7, 8);
        }

        public static new MutableGame InitilizationGame(params int[] cells)
        {
            return new MutableGame(cells);
        }

        [TestMethod]
        public override void CheckWork_Shift()
        {
            MutableGame gameBefore = InitilizationCorrectGame();
            MutableGame gameAfter;

            gameAfter = gameBefore.Shift(1);

            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(gameBefore.GetLocation(i), gameAfter.GetLocation(i));
            }
        }
    }
}
