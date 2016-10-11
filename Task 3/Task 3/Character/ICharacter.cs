using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task_3.Characteristics;
using Task_3.Spells;

namespace Task_3.Character
{
    public interface ICharacter
    {
        public void ApplySpell(ISpell spell);
    }
}
