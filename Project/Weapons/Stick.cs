using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD.Weapons
{
    internal class Stick : Weapon
    {
        public Stick()
        {

            AttackDie ad = new AttackDie(4);
            List<AttackDie> attackDie = new List<AttackDie>();
            attackDie.Add(ad);

            base.WeaponID = 1;
            base.Name = "Stick";
            base.Cost = 200;
            base.Value = 12;
            base.AttackDie = attackDie;

        }

        public override int GetDamage(Boolean critHit)
        {
            return base.GetDamage(critHit);
        }


        public override WeaponIDs Type => WeaponIDs.STICK;



    }
}
