using System;

namespace LORD
{
    class DieRoll
    {
        private static Random rnd = null;
        private static int seedValue;
        public DieRoll()
        {
            seedValue = (int)(DateTime.Now.Millisecond * .25);
            rnd = new Random( seedValue );

        }
        public static int D20() {
            seedValue = (int)(DateTime.Now.Millisecond * .25);
            rnd = new Random(seedValue);

            return rnd.Next(1, 21); 
        }

        public static Boolean Crit()
        {
            seedValue = (int)(DateTime.Now.Millisecond * .25);
            rnd = new Random(seedValue);

            int Roll1 = rnd.Next(1, 7);
            int Roll2 = rnd.Next(1, 7);
            if ((Roll1 + Roll2) == 11)
                return true;
            else
                return false;
        }
    }
}
