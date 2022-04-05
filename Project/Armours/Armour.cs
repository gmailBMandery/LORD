using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    public abstract class Armour
    {
        public int ArmourID { get; internal set; }
        public string Name { get; internal set; }

        /// <summary>
        /// This nubmer is used in the calculation to see if a hit occurs or not.
        /// </summary>
        public int Class { get; internal set; }

        public int Cost { get; internal set; }

        public int Value { get; internal set; }

        public float DefenseModifier { get; internal set; }

        public static Armour CreateArmour(ArmourIDs armourID)
        {
            Armour returnArmour = null;

            switch (armourID)
            {
                case ArmourIDs.COAT:
                    returnArmour = new Armours.Coat();
                    break;
            }

            return returnArmour;
        }

        public virtual int  CalculateArmourClass(int defensiveStrength)
        {
            //def + class = x + (* .95)
            //ex: 1 + 1 = 2 + (2 * .95) = 3.9 Round t 4 ---Hmm. armour class of 4????

            int thaco = (int)Math.Round((defensiveStrength + this.Class) + ((defensiveStrength * this.Class) * this.DefenseModifier));
            Console.WriteLine(thaco);
            return thaco;
        }

    }
}
