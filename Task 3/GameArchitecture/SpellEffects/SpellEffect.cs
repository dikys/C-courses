using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameArchitecture.Characters;

namespace GameArchitecture.SpellEffects
{
    public abstract class SpellEffect: ISpellEffect
    {
        public string Name { private set; get; }
        public string Description { private set; get; }

        public double Duration { private set; get; }

        public abstract void Apply(ICharacter character);
    }
}
