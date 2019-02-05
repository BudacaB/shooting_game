using Assets.Weaponry.Behaviour.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Weaponry.Behaviour
{
    public interface IBlade : IDamage, IDamageArea, IDamageElemental, IDamageType, IAugment
    {
        void Slash();
        void Stab();
    }
}
