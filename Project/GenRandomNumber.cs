using System;
namespace LORD
{
    internal class GenRandomNumber
    {
        public static int Next()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return rnd.Next();
        }
        public static int Next(int MaxValue)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return rnd.Next(MaxValue);
        }

        public static int Next(int MinValue, int MaxValue)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return rnd.Next(MinValue, MaxValue+1);
        }
    }
}