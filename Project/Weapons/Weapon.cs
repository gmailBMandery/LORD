using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
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

        public static Weapon CreateWeapon(int weaponID)
        {
            Weapon returnWeapon = null;
            switch (weaponID)
            {
                case (int)Weapons.WeaponIDs.STICK:
                    returnWeapon = new Weapons.Stick();
                    break;

                case (int)Weapons.WeaponIDs.DAGGER:
                    returnWeapon = new Weapons.Dagger();
                    break;

                case (int)Weapons.WeaponIDs.SHORT_SWORD:
                    break;

                case (int)Weapons.WeaponIDs.LONG_SWORD:
                    break;

                case (int)Weapons.WeaponIDs.HUGE_AXE:
                    break;

                case (int)Weapons.WeaponIDs.BONE_CRUNCHER:
                    break;

                case (int)Weapons.WeaponIDs.TWIN_SWORDS:
                    break;

                case (int)Weapons.WeaponIDs.POWER_AXE:
                    break;

                case (int)Weapons.WeaponIDs.ABLES_SWORD:
                    break;

                case (int)Weapons.WeaponIDs.WANS_WEAPON:
                    break;

                case (int)Weapons.WeaponIDs.SPEAR_OF_GOLD:
                    break;

                case (int)Weapons.WeaponIDs.CRYSTAL_SHARD:
                    break;

                case (int)Weapons.WeaponIDs.NIRASS_TEETH:
                    break;

                case (int)Weapons.WeaponIDs.BLOOD_SWORD:
                    break;

                case (int)Weapons.WeaponIDs.DEATH_SWORD:
                    break;
            }

            return returnWeapon;
        }
    }
}
