using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public struct Location
    {
        int x;
        public int X
        {
            get
            {
                return this.x;
            }
        }
        int y;
        public int Y
        {
            get
            {
                return this.y;
            }
        }

        public Location (int x, int y)
        {
            this.x = x;
            this.y = y; 
        }
    }
}
