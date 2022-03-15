using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORD
{
    class LeatherVest : Armour
    {
        public LeatherVest()
        {
            base.ArmourID = 2;
            base.Class = 2;
            base.Cost = 75;
            base.Value = 26;
            base.Name = "Leather Vest";
        }
    }
}
