using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class Game
    {
        protected readonly int[,] field;
        protected readonly int fieldSize;
        protected readonly Location[] valuesLocation;

        public Game(params int[] cells)
        {
            if (cells.Length != (int)Math.Pow((int) Math.Sqrt(cells.Length), 2))
                throw new ArgumentException("Count should be perfect square!");

            this.fieldSize = cells.Length;

            bool[] haveValues = new bool[cells.Length];
            for (var i = 0; i < this.fieldSize; i++)
            {
                haveValues[i] = false;
            }
            for (var i = 0; i < this.fieldSize; i++)
            {
                if (!IsCorrectValue(cells[i]))
                {
                    throw new ArgumentException("fields should have value from 0 to " + (this.fieldSize - 1) + "!");
                }

                haveValues[cells[i]] = true;
            }
            for (var i = 0; i < this.fieldSize; i++)
            {
                if (!haveValues[i])
                {
                    throw new ArgumentException("fields should have value from 0 to " + (this.fieldSize - 1) + "! Value " + i + " did not find!");
                }
            }
            
            this.field = new int[(int)Math.Sqrt(this.fieldSize), (int)Math.Sqrt(this.fieldSize)];
            this.valuesLocation = new Location[cells.Length];

            for (int x = 0; x < this.field.GetLength(0); x++)
            {
                for (int y = 0; y < this.field.GetLength(1); y++)
                {
                    int valueIndex = x * this.field.GetLength(0) + y;

                    this.field[x, y] = cells[valueIndex];

                    this.valuesLocation[cells[valueIndex]] = new Location(x, y);
                }
            }
        }
        
        public virtual int this[int x, int y]
        {
            get
            {
                return this.field[x, y];
            }
        }

        public virtual Location GetLocation(int value)
        {
            if (!IsCorrectValue(value))
                throw new ArgumentException("Cells should have value from 0 to " + (this.fieldSize - 1) + "!");

            return this.valuesLocation[value];
        }

        public void Shift(int value)
        {
            if (value == 0 || !IsCorrectValue(value))
                throw new ArgumentException("Value should be from 1 to " + (this.fieldSize - 1));

            Location valueLocation = GetLocation(value);
            Location zeroLocation = GetLocation(0);

            if (Math.Abs(zeroLocation.X - valueLocation.X) + Math.Abs(zeroLocation.Y - valueLocation.Y) > 1)
                throw new ArgumentException("Value can't move!");

            this.valuesLocation[0] = valueLocation;
            this.valuesLocation[value] = zeroLocation;

            this.field[zeroLocation.X, zeroLocation.Y] = value;
            this.field[valueLocation.X, valueLocation.Y] = 0;
        }

        public bool IsCorrectValue(int value)
        {
            return (0 <= value && value < this.fieldSize);
        }
    }
}
