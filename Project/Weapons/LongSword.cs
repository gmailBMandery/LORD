using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD.Weapons
{
    class LongSword : Weapon
    {
        public LongSword()
        {
            base.Name = "Long Sword";
            base.WeaponID = 4;
            base.Value = 1000;
            base.Cost = 10000;

            AttackDie ad = new AttackDie(10);
            AttackDie ad1 = new AttackDie(4);
            List<AttackDie> attackDie = new List<AttackDie>();
            attackDie.Add(ad);
            attackDie.Add(ad1);
            base.AttackDie = attackDie;
        }

        public override WeaponIDs Type => throw new NotImplementedException();
    }
}
