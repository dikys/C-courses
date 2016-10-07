using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class MutableGame : Game
    {
        int[] shiftHistory;

        public MutableGame(params int[] cells) : base(cells)
        {
            this.shiftHistory = new int[0];
        }

        public MutableGame(int[] cells, int[] shiftHistory) : base(cells)
        {
            this.shiftHistory = shiftHistory;
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

        public new MutableGame Shift(int value)
        {
            if (value == 0 || !IsCorrectValue(value))
                throw new ArgumentException("Zero can't move. Value should be from 1 to " + (this.fieldSize - 1));

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

            MutableGame result = new MutableGame(cells, newShiftHistory);

            return result;
        }
    }
}
