using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class ImmutableGame : Game
    {
        public ImmutableGame(params int[] cells) : base(cells)
        {
        }

        public new ImmutableGame Shift(int value)
        {
            if (value == 0 || !IsCorrectValue(value))
                throw new ArgumentException("Zero can't move. Value should be from 1 to " + (this.fieldSize - 1));

            Location valueLocation = GetLocation(value);
            Location zeroLocation = GetLocation(0);

            if (Math.Abs(zeroLocation.X - valueLocation.X) + Math.Abs(zeroLocation.Y - valueLocation.Y) > 1)
                throw new ArgumentException("Value can't move!");

            int[] cellsAfterShift = new int[this.fieldSize];
            for (int x = 0; x < this.field.GetLength(0); x++)
            {
                for (int y = 0; y < this.field.GetLength(1); y++)
                {
                    int valueIndex = x * this.field.GetLength(0) + y;

                    if (this.field[x, y] == 0)
                    {
                        cellsAfterShift[valueIndex] = value;
                    }
                    else if (this.field[x, y] == value)
                    {
                        cellsAfterShift[valueIndex] = 0;
                    }
                    else
                    {
                        cellsAfterShift[valueIndex] = this.field[x, y];
                    }
                }
            }

            ImmutableGame gameAfterShift = new ImmutableGame(cellsAfterShift);

            return gameAfterShift;
        }
    }
}
