using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameArchitecture.Characters;
using GameArchitecture.Characteristics;

namespace GameArchitecture.SpellEffects
{
    public abstract class SpellEffect: ISpellEffect, IUpdatableObject
    {
        public string Name { private set; get; }
        public string Description { private set; get; }
        public double Duration { private set; get; }
        public bool IsActive { get { return this.currentDuration <= 0; } }
        
        public double currentDuration;

        public abstract void Apply(ICharacter character);

        public abstract void DoEffect(ICharacteristic[] characteristics);

        public abstract void CleanEffect(ICharacteristic[] characteristics);
        
        public void Update(double dt)
        {
            this.currentDuration -= dt;
        }
    }
}
