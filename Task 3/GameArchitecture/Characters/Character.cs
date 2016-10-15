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
        
        public ICharacteristic[] Characteristics
        {
            private set { }
            get
            {
                ICharacteristic[] result = new ICharacteristic[this.Characteristics.Length];

                this.Characteristics.CopyTo(result, 0);

                foreach (var spellEffect in this.AppliedEffects)
                {
                    spellEffect.DoEffect(result);
                }

                return result;
            }
        }
        public ISpell[] Spells { private set; get; }

        public List<SpellEffect> AppliedEffects { private set; get; }
        public List<PassiveSpellEffect> AppliedPassiveEffects { private set; get; }

        public void Update(double dt)
        {
            for (int i = 0; i < Characteristics.Length; i++)
                Characteristics[i].Update(dt);
            for (int i = 0; i < Spells.Length; i++)
                Spells[i].Update(dt);
            for (int i = 0; i < AppliedEffects.Count; i++)
            {
                AppliedEffects[i].Update(dt);

                if (!AppliedEffects[i].IsActive)
                {
                    AppliedEffects.RemoveAt(i);

                    i--;
                }
            }
            for (int i = 0; i < AppliedPassiveEffects.Count; i++)
            {
                if (!AppliedPassiveEffects[i].IsActive)
                {
                    AppliedPassiveEffects.RemoveAt(i);
                }
            }
        }
    }
}
