using System;
using Newtonsoft.Json;
using System.IO;
namespace LORD
{
    internal class Player
    {

        //public Player(string name, int hitPoints, int maxHitPoints, int currentLevel, Weapon weapon, Armour armour)
        //{
        //    Name = name;
        //    //Go find the players information by name
        //    HitPoints = hitPoints;

        //    //Get our weapon readied
        //    this.Weapon = weapon;//Weapon.CreateWeapon((Weapons.WeaponIDs)weapon.WeaponID);

        //    //Get our Armour on
        //    this.ArmourDress = armour;//Armour.CreateArmour((ArmourIDs)armourID);
        //    Level = currentLevel;

        //    //temp
        //    ExperiencePoints = 0;
        //    ForestFights = 25;
        //    PlayerFights = 3;
        //    MaxHitPoints = 20;
        //    Gold = 50;
        //    GoldInBank = 12000;
        //    AttackStrength = 1;
        //    Gems = 0;
        //    DefensiveStrength = 1;
        //    AttackModifier = .2f;
        //}

        public Player(string Name, string Password, Boolean NewUser=false)
        {
            this.Name = Name;
            this.Password = Password;

            if (NewUser)
            {
                //Get our weapon readied
                this.Weapon = Weapon.CreateWeapon(Weapons.WeaponIDs.STICK);

                //Get our Armour on
                this.ArmourDress = Armour.CreateArmour(ArmourIDs.COAT);

                Level = 1;
                ExperiencePoints = 0;
                ForestFights = 25;
                PlayerFights = 3;
                HitPoints = 20;
                MaxHitPoints = 20;
                Gold = 0;
                GoldInBank = 0;
                AttackStrength = 0;
                Gems = 0;
                DefensiveStrength = 0;
                AttackModifier = .1f;

                string player = JsonConvert.SerializeObject(this);
                StreamWriter sw = new StreamWriter($"c:\\lord\\users\\{this.Name}.json");
                sw.Write(player);
                sw.Close();
                sw.Dispose();
            }
        }

        #region Public Methods
        public Boolean TakeDamage(int damageAmount)
        {
            if (damageAmount >= ArmourDress.CalculateArmourClass(this.DefensiveStrength))
            {
                HitPoints -= damageAmount;
                if (HitPoints <= 0)
                {
                    //Player is dead6
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

        public int GetDamage(Boolean crit)
        {
            int weaponDamage = Weapon.GetDamage(crit);
            int subDamage = (AttackStrength + weaponDamage);
            int totalDamage = (int)Math.Round(Math.Abs(((subDamage * AttackModifier)+weaponDamage)),0);

            System.Diagnostics.Debug.WriteLine($"GetDamage = {totalDamage}");
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

        public void AddReward(int GoldAmount, ulong ExperienceAmount)
        {
            if (GoldAmount < 0 || ExperienceAmount < 0)
                return;

            this.Gold += GoldAmount;
            this.ExperiencePoints += ExperienceAmount;
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
        public Armour ArmourDress { get; private set; }



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