using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task_3.Character;

namespace Task_3.Spells
{
    public abstract class Spell : ISpell
    {
        public string Name { private set; get; }
        public string Description { private set; get; }
        public double Cost { private set; get; }
        public double Cooldown { private set; get; }
        public double Duration { private set; get; }
        
        public abstract bool Apply(ICharacter target);
    }
}
