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
            base.Value = 10;
            base.Cost = 1000;

            AttackDie ad = new AttackDie(6);
            List<AttackDie> attackDie = new List<AttackDie>();
            attackDie.Add(ad);
            base.AttackDie = attackDie;
        }

        public override WeaponIDs Type => throw new NotImplementedException();

        public override int GetDamage(Boolean critHit)
        {
            return base.GetDamage(critHit);
        }
    }
}
