using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    public abstract class Weapon
    {
        public Weapon()
        {
        }

        public virtual int GetDamage(Boolean critHit)
        {
            int totalDamage = 0;
            int x = 2;
            //If we crit hit, roll double the damage die
            do
            {
                foreach (AttackDie ad in AttackDie)
                    totalDamage += ad.Roll();

                if (!critHit)//Break out of the loop
                    break;

                x--;
            }
            while (x != 0);

            System.Diagnostics.Debug.WriteLine($"Total Damage: {totalDamage}");
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

        public static Weapon CreateWeapon(Weapons.WeaponIDs weaponID)
        {
            Weapon returnWeapon = null;
            switch (weaponID)
            {
                case Weapons.WeaponIDs.STICK:
                    returnWeapon = new Weapons.Stick(); //1D4 Max Base 4
                    break;

                case Weapons.WeaponIDs.DAGGER:
                    returnWeapon = new Weapons.Dagger(); //1D6 Max Base 6
                    break;

                case Weapons.WeaponIDs.SHORT_SWORD:
                    returnWeapon = new Weapons.ShortSword(); //1D8 Max Base 8
                    break;

                case Weapons.WeaponIDs.LONG_SWORD:
                    returnWeapon = new Weapons.LongSword(); //1D10-1D4 Max Base 14
                    break;

                case Weapons.WeaponIDs.HUGE_AXE:
                    returnWeapon = new Weapons.HugeAxe(); //2D8-1D4 Max Base 20
                    break;

                case Weapons.WeaponIDs.BONE_CRUNCHER:
                    returnWeapon = new Weapons.BoneCruncher(); //2D8 - 1D4 - 1D6 Max Bose 20
                    break;

                case Weapons.WeaponIDs.TWIN_SWORDS:
                    returnWeapon = new Weapons.TwinSwords(); //2D10 - 1D4// Max Base 24
                    break;

                case Weapons.WeaponIDs.POWER_AXE:
                    returnWeapon = new Weapons.PowerAxe(); //2D10 - 1D8 Max Base 28
                    break;

                case Weapons.WeaponIDs.ABLES_SWORD:
                    returnWeapon = new Weapons.AblesSword(); //3D10 - 1D6 Max Base 36
                    break;

                case Weapons.WeaponIDs.WANS_WEAPON:
                    returnWeapon = new Weapons.WansWeapon(); //4D8 - 2D6 Max Base 44
                    break;

                case Weapons.WeaponIDs.SPEAR_OF_GOLD:
                    returnWeapon = new Weapons.SpearOfGold(); // 4D10 - 1D8 Max base 48
                    break;

                case Weapons.WeaponIDs.CRYSTAL_SHARD:
                    returnWeapon = new Weapons.CrystalShard(); // 2D20 - 2D10 // Max Base 60
                    break;

                case Weapons.WeaponIDs.NIRASS_TEETH:
                    returnWeapon = new Weapons.NirassTeeth(); // 3D20 - 2D10 - 1D6 // Max Base 86
                    break;

                case Weapons.WeaponIDs.BLOOD_SWORD:
                    returnWeapon = new Weapons.BloodSword(); //4D20 - 3D10 - 2D6 - 1D4 Max Base 122
                    break;

                case Weapons.WeaponIDs.DEATH_SWORD:
                    returnWeapon = new Weapons.DeathSword(); // 4D20 - 4D10 - 4D6 - 2D4  Max Base 152
                    break;
            }

            return returnWeapon;
        }

        public abstract Weapons.WeaponIDs Type { get; }
    }
}
