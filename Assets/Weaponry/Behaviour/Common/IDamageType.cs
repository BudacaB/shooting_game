using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Weaponry.Behaviour
{
    public interface IDamageType
    {
        void CommonDamage();
        void RareDamage();
        void LegendaryDamage();
        void SetDamage();
    }
}