using Assets.Weaponry.Behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Weaponry
{
    public class MeleeInventory  
    {
        public List<IBlade> BladedWeaponStock { get; set; }

        public MeleeInventory()
        {
            BladedWeaponStock = new List<IBlade>();
        }

    }
}
