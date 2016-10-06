using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;

namespace Task_2_Test
{
    [TestClass]
    public class GameTest
    {
        public static Game InitilizationCorrectGame()
        {
            return new Game(0, 1, 2, 3, 4, 5, 6, 7, 8);
        }

        public static Game InitilizationGame(params int[] cells)
        {
            return new Game(cells);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowArgumentException_When_CountFieldsNotEqual4or9or16()
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
        public virtual void CheckWork_Shift()
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
        public void CheckWork_Indexer()
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
        public virtual void CheckWork_GetLocation()
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
    }
}
