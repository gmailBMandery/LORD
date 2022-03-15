using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    internal class AttackDie
    {
        Random rnd = new Random(DateTime.Now.Millisecond);

        public AttackDie(int faces)
        {
            Faces = faces;
        }

        public int Roll()
        {
            return rnd.Next(1, (Faces + 1));
        }

        public int Faces { get; private set; }

        public int MinDamage { get => Faces - Faces + 1; }

        public int MaxDamage { get => Faces; }
    }
}
