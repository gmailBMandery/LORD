using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    [Serializable]
    class ReadWritePlayer
    {
        public ReadWritePlayer(string name, string password, ulong exp, int level, int gold, int goldInBank, int weaponID, int armourID, int atk, int def
            , int hitPoints, int charm, int gems, int playerFights, int forestFights, int masterID, float attackMod)
        {
            Name = name;
            Password = password;
            Experience = exp;
            Level = level;
            Gold = gold;
            GoldInBank = goldInBank;
            WeaponID = weaponID;
            ArmourID = armourID;
            AttackStrength = atk;
            DefensiveStrength = def;
            HitPoints = hitPoints;
            Charm = charm;
            Gems = gems;
            PlayerFights = playerFights;
            ForestFights = forestFights;
            MasterID = masterID;
            AttackModifier = attackMod;
        }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public ulong Experience { get; private set; }
        public int Level { get; private set; }
        public int Gold { get; private set; }
        public int GoldInBank { get; private set; }
        public int WeaponID { get; private set; }
        public int ArmourID { get; private set; }
        public int AttackStrength { get; private set; }
        public int DefensiveStrength { get; private set; }
        public int HitPoints { get; private set; }
        public int Charm { get; private set; }
        public int Gems { get; private set; }
        public int PlayerFights { get; private set; }
        public int ForestFights { get; private set; }
        public int MasterID { get; private set; }
        public float AttackModifier { get; private set; }
    }
}
