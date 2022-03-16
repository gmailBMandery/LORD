using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD.Armours
{
    class Coat : Armour
    {
        public Coat()
        {
            base.ArmourID = 1;
            base.Class = 1;
            base.Cost = 200;
            base.Value = 25;
            base.Name = "Coat";
            base.DefenseModifier = .05f;
            
        }
    }
}
