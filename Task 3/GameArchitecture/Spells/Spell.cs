using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameArchitecture.SpellEffects;

namespace GameArchitecture.Spells
{
    public abstract class Spell : ISpell
    {
        public string Name { private set; get; }
        public string Description { private set; get; }

        public double Cost { private set; get; }
        public double Cooldown { private set; get; }

        public SpellEffect Effect { private set; get; }

        private double currentCooldown = 0;

        public void Update(double dt)
        {
            if (currentCooldown == 0)
                return;

            currentCooldown -= dt;

            if (currentCooldown < 0)
                currentCooldown = 0;
        }
    }
}
