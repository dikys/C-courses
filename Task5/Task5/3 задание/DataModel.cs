using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public interface IObserver<TValue>
    {
        void PutEvent(int row, int column, TValue value);
        void InsertRowEvent(int rowIndex);
        void InsertColumnEvent(int columnIndex);
    }

    public class DataModel<TValue>
        where TValue: new()
    {
        private List<List<TValue>> table;

        public int CountRow { get; private set; }
        public int CountColumn { get; private set; }

        private List<IObserver<TValue>> observers;

        public DataModel()
        {
            this.table = new List<List<TValue>>();
        }

        public void Put(int row, int column, TValue value)
        {
            if (row < 0 || this.CountRow - 1 < row || column < 0 || this.CountColumn - 1 < column)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.table[row][column] = value;

            foreach (var observer in observers)
            {
                observer.PutEvent(row, column, value);
            }
        }

        public void InsertRow(int rowIndex)
        {
            if (rowIndex < 0 || this.CountRow < rowIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            var newRow = new List<TValue>();
            
            for (var i = 0; i < this.CountColumn; i++)
            {
                newRow.Add(new TValue());
            }

            this.table.Insert(rowIndex, newRow);

            this.CountRow ++;

            foreach (var observer in observers)
            {
                observer.InsertRowEvent(rowIndex);
            }
        }

        public void InsertColumn(int columnIndex)
        {
            if (columnIndex < 0 || this.CountColumn < columnIndex)
            {
                throw new ArgumentOutOfRangeException();
            }

            foreach (var row in this.table)
            {
                row.Add(new TValue());
            }

            this.CountColumn ++;

            foreach (var observer in observers)
            {
                observer.InsertColumnEvent(columnIndex);
            }
        }

        public TValue Get(int row, int column)
        {
            if (row < 0 || this.CountRow - 1 < row
                || column < 0 || this.CountColumn - 1 < column)
            {
                throw new ArgumentOutOfRangeException();
            }   
            
            return this.table[row][column];
        }

        public void AddObserver(IObserver<TValue> observer)
        {
            if (this.observers.Contains(observer))
            {
                throw new ArgumentException("Этот observer уже в списке.");
            }

            this.observers.Add(observer);
        }

        public void RemoveObserver(IObserver<TValue> observer)
        {
            if (!this.observers.Contains(observer))
            {
                throw new ArgumentException("Этого observer нет в списке.");
            }

            this.observers.Remove(observer);
        }
    }
}
