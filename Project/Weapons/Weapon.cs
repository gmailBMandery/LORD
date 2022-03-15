using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    [Serializable]
    abstract class Weapon
    {
        public Weapon()
        {
        }

        public virtual int GetDamage()
        {
            int totalDamage = 0;
            foreach(AttackDie ad in AttackDie)
                totalDamage += ad.Roll();

            return totalDamage;
        }

        public List<AttackDie> AttackDie
        { get; internal set; }

        public int WeaponID { get; internal set; }
        public string Name{ get; internal set; }

        public int Cost { get; internal set; }

        public int Value { get; internal set; }

        public new virtual string ToString()
        {
            return base.ToString();
        }
    }
}
