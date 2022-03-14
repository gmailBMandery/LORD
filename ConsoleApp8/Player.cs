namespace LORD
{
    internal class Player
    {

        public Player(string name, int hitPoints)
        {
            Name = name;
            //Go find the players information by name

            HitPoints = hitPoints;
            Weapon weapon = new Weapon(1, 7);
            this.Weapon = weapon;
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

        public int HitPoints
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
    }


}