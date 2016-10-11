using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameArchitecture.Characteristics;
using GameArchitecture.Spells;
using GameArchitecture.SpellEffects;

namespace GameArchitecture.Characters
{
    public abstract class Character : ICharacter
    {
        public string Name { private set; get; }
        public string Description { private set; get; }

        public ICharacteristic[] Characteristics { private set; get; }
        public ISpell[] Spells { private set; get; }

        public List<ISpellEffect> AppliedEffects { private set; get; }
    }
}
