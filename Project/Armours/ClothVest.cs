using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    class ClothVest : Armour
    {
        public ClothVest()
        {
            base.ArmourID = 1;
            base.Class = 1;
            base.Cost = 50;
            base.Value = 12;
            base.Name = "Cloth Vest";
        }
        
    }
}
