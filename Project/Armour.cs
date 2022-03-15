using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    class Armour
    {
        public Armour(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        /// <summary>
        /// This nubmer is used in the calculation to see if a hit occurs or not.
        /// </summary>
        public int Class { get; private set; }

        public int Cost { get; private set; }

        public int Value { get; private set; }
    }
}
