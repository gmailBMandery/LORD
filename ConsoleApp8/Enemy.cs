using System;
namespace LORD
{
    internal class Enemy
    {
        private int attackStrength;

        public Enemy(string name, int hp)
        {
            Name = name;
            HP = hp;
            IsDead = false;

        }

        /// <summary>
        /// This will populate the Damage output
        /// </summary>
        private void Attack()
        {

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