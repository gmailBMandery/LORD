using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD.Weapons
{
    class Dagger : Weapon
    {
        public Dagger()
        {
            base.Name = "Dagger";
            base.WeaponID = 2;
            base.Value = 75;
            base.Cost = 100;

            AttackDie ad = new AttackDie(6);
            List<AttackDie> attackDie = new List<AttackDie>();
            attackDie.Add(ad);
            base.AttackDie = attackDie;
        }

        public override int GetDamage()
        {
            return base.GetDamage();
        }
    }
}
