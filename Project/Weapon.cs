using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    [Serializable]
    class Weapon
    {
        public Weapon( string name, int cost, int value, List<AttackDie> attackDie)
        {
            Name = name;
            Cost = cost;
            Value = value;
            AttackDie = attackDie;
        }

        public int GetDamage()
        {
            int totalDamage = 0;
            foreach(AttackDie ad in AttackDie)
                totalDamage += ad.Roll();

            return totalDamage;
        }

        public List<AttackDie> AttackDie
        { get; private set; }

        public int MinDamage
        { get; private set; }

        public int MaxDamage
        { get; private set; }

        public string Name
        { get; private set; }

        public int Cost { get; private set; }

        public int Value { get; private set; }

        public override string ToString()
        {
            return $"Name:{Name},MinDamage:{MinDamage},MaxDamage:{MaxDamage},Cost:{Cost},Value:{Value}";
        }
    }
}
