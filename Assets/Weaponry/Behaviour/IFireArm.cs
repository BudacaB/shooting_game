using Assets.Weaponry.Behaviour.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Weaponry.Behaviour
{
    public interface IFireArm : IDamage, IDamageArea, IDamageElemental, IDamageType, IAugment
    {
        void Reload();
        void Aim();
        void Shoot();
    }
}
