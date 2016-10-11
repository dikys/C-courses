using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameArchitecture.Characters;

namespace GameArchitecture.Spells
{
    public abstract class SpellOnMySelf : Spell
    {
        public abstract void Apply(ICharacter character);
    }
}
