using GameArchitecture.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArchitecture.SpellEffects
{
    public interface ISpellEffect
    {
        void Apply(ICharacter character);
    }
}
