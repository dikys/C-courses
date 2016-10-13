using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.Characteristics
{
    public abstract class Characteristic<TValue> : ICharacteristic
    {
        public string Name { private set; get; }
        public string Description { private set; get; }
        
        public TValue Value { set; get; }

        public abstract void Update(double dt);
    }
}
