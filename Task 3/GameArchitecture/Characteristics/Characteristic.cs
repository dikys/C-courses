using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Characteristics
{
    public abstract class Characteristic<T> : ICharacteristic
    {
        public string Name { private set; get; }
        public string Description { private set; get; }

        public T Value { set; get; }
    }
}
