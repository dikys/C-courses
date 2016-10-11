using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task_3.Characteristics;
using Task_3.Spells;

namespace Task_3.Character
{
    public abstract class Character : ICharacter
    {
        List<ICharacteristic> characteristics;
        List<ISpell> spells;
        List<ISpell> appliedSpells;

        public void ApplySpell(ISpell spell)
        {
            this.appliedSpells.Add(spell);
        }
    }
}
