using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD.Weapons
{
    class ShortSword : Weapon
    {
        public ShortSword() 
        {
            base.Name = "Short Sword";
            base.WeaponID = 3;
            base.Value = 30;
            base.Cost = 3000;

            AttackDie ad = new AttackDie(8);
            List<AttackDie> attackDie = new List<AttackDie>();
            attackDie.Add(ad);
            base.AttackDie = attackDie;
        }
    }
}
