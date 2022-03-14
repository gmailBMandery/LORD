using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    [Serializable]
    class Weapon
    {
        public Weapon(int minDamage, int maxDamage)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
        public int MinDamage
        { get; private set; }

        public int MaxDamage
        { get; private set; }
    }
}
