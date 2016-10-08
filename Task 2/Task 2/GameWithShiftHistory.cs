using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class GameWithShiftHistory : Game
    {
        int[] shiftHistory;

        public GameWithShiftHistory(params int[] cells) : base(cells)
        {
            this.shiftHistory = new int[0];
        }

        public GameWithShiftHistory(int[] cells, int[] shiftHistory) : base(cells)
        {
            this.shiftHistory = shiftHistory;
        }

        public override int this[int x, int y]
        {
            get
            {
                int[] cells = new int[this.fieldSize];
                for (int i = 0; i < this.field.GetLength(0); i++)
                {
                    for (int j = 0; j < this.field.GetLength(1); j++)
                    {
                        cells[i * this.field.GetLength(0) + j] = this.field[i, j];
                    }
                }

                Game game = new Game(cells);

                for (int i = 0; i < this.shiftHistory.Length; i++)
                {
                    game.Shift(this.shiftHistory[i]);
                }

                return game[x, y];
            }
        }

        public override Location GetLocation(int value)
        {
            int[] cells = new int[this.fieldSize];
            for (int x = 0; x < this.field.GetLength(0); x++)
            {
                for (int y = 0; y < this.field.GetLength(1); y++)
                {
                    cells[x * this.field.GetLength(0) + y] = this.field[x, y];
                }
            }

            Game game = new Game(cells);

            for (int i = 0; i < this.shiftHistory.Length; i++)
            {
                game.Shift(this.shiftHistory[i]);
            }

            return game.GetLocation(value);
        }

        public new GameWithShiftHistory Shift(int value)
        {
            if (value == 0 || !IsCorrectValue(value))
                throw new ArgumentException("Value should be from 1 to " + (this.fieldSize - 1));

            Location valueLocation = GetLocation(value);
            Location zeroLocation = GetLocation(0);

            if (Math.Abs(zeroLocation.X - valueLocation.X) + Math.Abs(zeroLocation.Y - valueLocation.Y) > 1)
                throw new ArgumentException("Value can't move!");

            int[] newShiftHistory = new int[this.shiftHistory.Length + 1];
            for (int i = 0; i < this.shiftHistory.Length; i++)
            {
                newShiftHistory[i] = this.shiftHistory[i];
            }
            newShiftHistory[this.shiftHistory.Length] = value;

            int[] cells = new int[this.fieldSize];
            for (int x = 0; x < this.field.GetLength(0); x++)
            {
                for (int y = 0; y < this.field.GetLength(1); y++)
                {
                    cells[x * this.field.GetLength(0) + y] = this.field[x, y];
                }
            }

            GameWithShiftHistory result = new GameWithShiftHistory(cells, newShiftHistory);

            return result;
        }
    }
}
