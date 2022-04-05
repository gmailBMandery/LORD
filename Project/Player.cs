using System;
using Newtonsoft.Json;
using System.IO;
namespace LORD
{
    public class Player
    {

        private int hitPoints;
        private int maxHitPoints;
        private int goldInHand;
        private int holdInBank;
        private int weaponID;
        private int armourID;
        private int forestFights;
        private int playerFights;
        private int level;
        private ulong xp;
        private int gems;
        private int charm;
        private int attackStrength;
        private int defensiveStrength;
        private float attackModifier;
        public Player() { }


        [JsonConstructor]
        public Player(int Level, 
                    string Name, 
                    string Password, 
                    int WeaponType, 
                    int ArmourType, 
                    int ForestFights, 
                    int PlayerFights, 
                    ulong ExperiencePoints,
                    int HitPoints,
                    int MaxHitPoints,
                    int AttackStrength,
                    int DefensiveStrength,
                    int Gems,
                    int Charm,
                    int GoldInBank,
                    int Gold)
        {
            this.Level = Level;
            this.Name = Name;
            this.Password = Password;
            this.xp = ExperiencePoints;
            this.WeaponType = WeaponType;
            this.ArmourType = ArmourType;
            this.forestFights = ForestFights;
            this.playerFights = PlayerFights;
            this.hitPoints = HitPoints;
            this.MaxHitPoints = MaxHitPoints;
            this.AttackStrength = AttackStrength;
            this.DefensiveStrength = DefensiveStrength;
            this.Gems = Gems;
            this.Charm = Charm;
            this.GoldInBank = GoldInBank;
            this.goldInHand = Gold;
            
        }

        internal void ReduceForestFights(int v)
        {
            this.forestFights -= v;
        }

        public Player(string Name, string Password, Boolean NewUser=false)
        {
            this.Name = Name;
            this.Password = FileSecurity.Encrypt(Password);
            PlayerReady = false;

            if (NewUser)
            {

                this.WeaponType = (int)Weapons.WeaponIDs.STICK;
                this.ArmourType = (int)ArmourIDs.COAT;

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
                StreamWriter sw = new StreamWriter($"{Program.fileLocation}{this.Name}.json");
                sw.Write(player);
                sw.Close();
                sw.Dispose();
                PlayerReady = true;
            }
  
        }

        #region Public Methods
        public Player LoadPlayerData(string Name, string Password)
        {
            Player p = null;
            try
            {
                StreamReader sr = new StreamReader($"{Program.fileLocation}{Name}.json");
                string playerData = sr.ReadToEnd();
                p = JsonConvert.DeserializeObject<Player>(playerData);
                sr.Close();
                sr.Dispose();
                
                
                if (FileSecurity.Decrypt(p.Password) == Password)
                    p.PlayerReady = true;
                else
                    p.PlayerReady = false;

                return p;
            }
            catch (FileNotFoundException noUser)
            {
                Console.WriteLine("You don't seem to exists, are you a new user?");
                Console.ReadKey();
                PlayerReady = false;
            }

            return null;

        }
            
        public Boolean TakeDamage(int damageAmount)
        {
            if (damageAmount >= Armour.CreateArmour((ArmourIDs)this.ArmourType).CalculateArmourClass(this.DefensiveStrength))
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
            int weaponDamage = Weapon.CreateWeapon((Weapons.WeaponIDs)Program.player.WeaponType).GetDamage(crit);
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
            //this.Weapon = w;
            this.WeaponType = w.WeaponID;
            this.Gold -= w.Cost;
        }
        #endregion

        public string Name
        {
            get; private set;
        }
        public string Password
        { get; private set; }
        public float AttackModifier { get; private set; }
        public int HitPoints { get { return this.hitPoints; } private set { this.hitPoints = value; this.SavePlayerData(); } }
        public int MaxHitPoints
        {
            get; private set;
        }
        public int Gold
        {
            get { return this.goldInHand; } set { this.goldInHand = value; this.SavePlayerData(); }
        }
        public int Level { get; private set; }
        public ulong ExperiencePoints { get { return this.xp; } private set { this.xp = value; this.SavePlayerData(); } }
        public int ForestFights { get { return this.forestFights; } private set { this.forestFights = value; this.SavePlayerData(); } }
        public int PlayerFights { get; private set; }
        public int GoldInBank { get; private set; }
        public int AttackStrength { get; private set; }
        public int Gems { get; private set; }
        public int Charm { get; private set; }
        public int DefensiveStrength { get; private set; }
        public int WeaponType { get; private set; }
        public int ArmourType { get; private set; }
        public Boolean PlayerReady { get; private set; }

        private void SavePlayerData()
        {
            //this.hitPoints = FileSecurity.Encrypt(this.hitPoints.ToString());
            string player = JsonConvert.SerializeObject(this);
            StreamWriter sw = new StreamWriter($"{Program.fileLocation}{this.Name}.json");
            sw.Write(player);
            sw.Close();
            sw.Dispose();
        }
    }


}