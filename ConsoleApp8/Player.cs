namespace LORD
{
    internal class Player
    {

        public Player(string name, int hitPoints, int maxHitPoints, int currentLevel)
        {
            Name = name;
            //Go find the players information by name

            HitPoints = hitPoints;
            Weapon weapon = new Weapon(1, 7);
            this.Weapon = weapon;
            Level = currentLevel;
        }

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

        public Weapon Weapon
        {
            get; private set;
        }
        
        public int Gold
        {
            get;private set;
        }
        public int Level { get; private set; }
    }


}