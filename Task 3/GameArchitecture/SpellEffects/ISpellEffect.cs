using GameArchitecture.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameArchitecture;
using GameArchitecture.Characteristics;

namespace GameArchitecture.SpellEffects
{
    public interface ISpellEffect
    {
        void Apply(ICharacter character);

        void DoEffect(ICharacteristic[] characteristics);
        void CleanEffect(ICharacteristic[] characteristics);

        bool IsActive { get; }
    }
}
