using Assets.Weaponry.Behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Weaponry
{
    class RangedInventory
    {
        public List<IFireArm> GunsWeaponStock { get; set; }

        public RangedInventory()
        {
            GunsWeaponStock = new List<IFireArm>();
        }
    }

}
