using System;
namespace LORD
{
    internal class Enemy
    {
        //Enemies will be read from file

        public Enemy(string name, int hp, int attackStrength, int level)
        {
            Name = name;
            HP = hp;
            IsDead = false;
            AttackStrength = attackStrength;
            Level = level;


        }

        /// <summary>
        /// This will populate the Damage output
        /// </summary>
        private void Attack()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            double attackModifier = rnd.NextDouble();
            
            AttackStrength = (int)((double)rnd.Next(1, AttackStrength) / .8);

            DamageOutput = AttackStrength;

            System.Diagnostics.Debug.WriteLine($"Attack Strength : {AttackStrength} : Mod : {attackModifier}");
        }

        public void TakeDamage(int amount)
        {
            HP -= amount;
            if(HP<=0)
            {
                //This enemy is dead
                //Spill reward and exp
                IsDead = true;
            }
            else
            {
                Attack();
            }
        }


        public int AttackStrength
        {
            get; private set;
        }

        public int Level
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
    }
}