using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /*public class DataModel<TElement> : IObservable<TElement>
    {
        private List<IObserver<TElement>> observers;

        public IDisposable Subscribe(IObserver<TElement> observer)
        {
            if (!this.observers.Contains(observer))
            {
                this.observers.Add(observer);
            }

            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<TElement>> observers;
            private IObserver<TElement> observer;

            public Unsubscriber(List<IObserver<TElement>> observers, IObserver<TElement> observer)
            {
                this.observers = observers;
                this.observer = observer;
            }

            public void Dispose()
            {
                if (this.observer != null && this.observers.Contains(this.observer))
                {
                    this.observers.Remove(this.observer);
                }
            }
        }
    }

    public class ElementOfDataModel<TValue> : IObserver<TValue>
    {
        public TValue Value { get; private set; }

        public void OnNext(TValue value)
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }*/

    public class DataModel<TValue>
    {
        private List<List<TValue> table;
        public int CountRow { get; private set; }
        public int CountColumn { get; private set; }

        public DataModel()
        {
            this.table = new List<List<TValue>>();
        }

        public void Put(int row, int column, TValue value)
        {
            this.table[row][column] = value;
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
                // ТУТ ElementOfDataModel
                newRow.Add(new TValue());
            }

            this.table.Insert(rowIndex, newRow);

            this.CountRow ++;
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
    }
}
