using System;
namespace LORD
{
    internal class Enemy
    {
        private int MinXP, MaxXP;
        private int MinGold, MaxGold;
        private Random rnd;
        //Enemies will be read from file

        public Enemy(string name, int hp, int attackStrength, int armourClass, float attackModifier, int minXP, int maxXP, int minReward, int maxReward)
        {
            Name = name;
            HP = hp;
            IsDead = false;
            AttackStrength = attackStrength;
            ArmourClass = armourClass;
            AttackModifier = attackModifier; // Added to D20 roll to see if enemy can hit.

            MinXP = minXP;
            MaxXP = maxXP;
            MinGold = minReward;
            MaxGold = maxReward;

            rnd = new Random(DateTime.Now.Millisecond);
        }

        /// <summary>
        /// This will populate the Damage output
        /// </summary>
        private void Attack()
        {
            double attackModifier = rnd.NextDouble();
            
            AttackStrength = (int)((double)rnd.Next(1, AttackStrength) / AttackModifier);

            DamageOutput = AttackStrength;

            System.Diagnostics.Debug.WriteLine($"Attack Strength : {AttackStrength} : Mod : {attackModifier}");
        }

        public void TakeDamage(int amount)
        {
            if(amount>ArmourClass)
                HP -= amount;

            if(HP<=0)
            {
                //This enemy is dead
                //Spill reward and exp
                IsDead = true;
                CalculateRewards();
            }
            else
            {
                Attack();
            }
        }

        private void CalculateRewards()
        {
            XPReward = rnd.Next(MinXP, MaxXP);
            GoldReward = rnd.Next(MinGold, MaxGold);
        }

        public int AttackStrength
        {
            get; private set;
        }

        public int ArmourClass
        {
            get; private set;
        }
        public string Name
        {
            get; private set;
        }

        /// <summary>
        /// Total life
        /// </summary>
        public int HP
        {
            get; private set;
        }

        /// <summary>
        /// The amount of damage that will be inflicted on fighter
        /// </summary>
        public int DamageOutput
        {
            get; private set;
        }

        public bool IsDead
        {
            get; private set;
        }

        public float AttackModifier { get; private set; }

        public int XPReward { get; internal set; }
        public int GoldReward { get; internal set; }
        
    }
}