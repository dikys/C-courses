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

        public double currentDuration;

        public abstract void Apply(ICharacter character);

        public void Update(double dt)
        {
            this.currentDuration -= dt;
        }

        public bool IsEnded()
        {
            return (this.currentDuration <= 0);
        }
    }
}
