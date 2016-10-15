using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameArchitecture.Characteristics;
using GameArchitecture.Characters;

namespace GameArchitecture.SpellEffects
{
    public abstract class PassiveSpellEffect : ISpellEffect
    {
        public string Name { private set; get; }
        public string Description { private set; get; }
        public bool IsActive => true;

        public abstract void Apply(ICharacter character);

        public abstract void CleanEffect(ICharacteristic[] characteristics);

        public abstract void DoEffect(ICharacteristic[] characteristics);
    }
}
