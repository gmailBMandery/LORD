using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    abstract class Armour
    {
        public int ArmourID { get; internal set; }
        public string Name { get; internal set; }

        /// <summary>
        /// This nubmer is used in the calculation to see if a hit occurs or not.
        /// </summary>
        public int Class { get; internal set; }

        public int Cost { get; internal set; }

        public int Value { get; internal set; }
    }



    enum ArmourID
    {
        CLOTH_VEST = 1
            , LEATHER_VEST = 2
    }
}
