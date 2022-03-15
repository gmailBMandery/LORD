using System;
using System.Collections.Generic;

namespace LORD
{
    internal class Player
    {

        public Player(string name, int hitPoints, int maxHitPoints, int currentLevel)
        {
            Name = name;
            //Go find the players information by name

            HitPoints = hitPoints;
            AttackDie ad = new AttackDie(4);
            AttackDie ad1 = new AttackDie(4);
            AttackDie ad2 = new AttackDie(4);

            List<AttackDie> attackDie = new List<AttackDie>();
            attackDie.Add(ad);
            attackDie.Add(ad1);
            attackDie.Add(ad2);

            Weapon weapon = new Weapon("Stick", 50, 12, attackDie);
            this.Armour = new Armour("Iron Vest");
            this.Weapon = weapon;
            Level = currentLevel;

            //temp
            ExperiencePoints = 0;
            ForestFights = 25;
            PlayerFights = 3;
            MaxHitPoints = 20;
            Gold = 4500;
            GoldInBank = 12000;
            AttackStrength = 12;
            Gems = 0;
            DefensiveStrength = 1;
            AttackModifier = .2f;
        }

        #region Public Methods
        public void TakeDamage(int damageAmount)
        {
            HitPoints -= damageAmount;
            if(HitPoints<=0)
            {
                //Player is dead
                //Tell a sad story, let them know they lost all gold on hand and 10% of experiance
            }
        }

        public void RestoreHitPoints(int restoreAmount)
        {
            if (restoreAmount > MaxHitPoints)
                HitPoints = MaxHitPoints;
            else
                HitPoints += restoreAmount;
        }

        public int GetDamage()
        {
            int weaponDamage = Weapon.GetDamage();
            int subDamage = (AttackStrength * weaponDamage);
            int totalDamage = (int)(subDamage * AttackModifier);

            return totalDamage;
        }
        #endregion

        public float AttackModifier { get; private set; }
        public int HitPoints
        {
            get; private set;
        }

        public int MaxHitPoints
        {
            get; private set;
        }

        public string Name
        {
            get; private set;
        }

        public Weapon Weapon { get; private set; }        
        public Armour Armour { get; private set; }

        public int Gold
        {
            get;private set;
        }
        public int Level { get; private set; }
        public ulong ExperiencePoints { get; private set; }
        public int ForestFights { get; private set; }
        public int PlayerFights { get; private set; }
        public int GoldInBank { get; private set; }
        public int AttackStrength { get; private set; }
        public int Gems { get; private set; }
        public int Charm { get; private set; }
        public int DefensiveStrength { get; private set; }
    }


}