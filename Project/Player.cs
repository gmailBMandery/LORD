using System;
using System.Collections.Generic;

namespace LORD
{
    internal class Player
    {

        public Player(string name, int hitPoints, int maxHitPoints, int currentLevel, int weaponID, int armourID)
        {
            Name = name;
            //Go find the players information by name
            HitPoints = hitPoints;

            //Get our weapon readied
            this.Weapon = Weapon.CreateWeapon(weaponID);

            //Get our Armour on
            this.Armour = CreateArmour(armourID);
            Level = currentLevel;

            //temp
            ExperiencePoints = 0;
            ForestFights = 25;
            PlayerFights = 3;
            MaxHitPoints = 20;
            Gold = 50;
            GoldInBank = 12000;
            AttackStrength = 12;
            Gems = 0;
            DefensiveStrength = 1;
            AttackModifier = .2f;
        }

        public Player(string name, string password)
        {
            Name = name;
            Password = password;

            //set new user defaults
            //Get our weapon readied
            this.Weapon = Weapon.CreateWeapon(1);

            //Get our Armour on
            this.Armour = CreateArmour(1);
            Level = 1;

            //temp
            ExperiencePoints = 0;
            ForestFights = 25;
            PlayerFights = 3;
            HitPoints = 20;
            MaxHitPoints = 20;
            Gold = 0;
            GoldInBank = 0;
            AttackStrength = 1;
            Gems = 0;
            DefensiveStrength = 1;
            AttackModifier = .1f;
        }

        private Armour CreateArmour(int armourID)
        {
            Armour returnArmour = null;
            switch(armourID)
            {
                case (int)ArmourID.CLOTH_VEST:
                    returnArmour = new ClothVest();
                    break;

                case (int)ArmourID.LEATHER_VEST:
                    returnArmour = new LeatherVest();
                    break;
            }

            return returnArmour;
        }

        #region Public Methods
        public Boolean TakeDamage(int damageAmount)
        {
            if (damageAmount > Armour.Class)
            {
                HitPoints -= damageAmount;
                if (HitPoints <= 0)
                {
                    //Player is dead
                    //Tell a sad story, let them know they lost all gold on hand and 10% of experiance
                }
                return true;
            }
            else
            {
                //Console.WriteLine("That is a miss");
                return false;
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

        public void HealHitPoints(int pointsToHeal, int totalCost)
        {
            this.Gold -= totalCost;
            if (pointsToHeal> this.MaxHitPoints)
                this.HitPoints = MaxHitPoints;
            else
                this.HitPoints += pointsToHeal;
        }

        internal void PurchaseWeapon(Weapon w)
        {
            this.Weapon = w;
            this.Gold -= w.Cost;
        }
        #endregion

        public float AttackModifier { get; private set; }
        public int HitPoints { get; private set; }

        public int MaxHitPoints
        {
            get; private set;
        }

        public string Name
        {
            get; private set;
        }

        public string Password
        { get; private set; }

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