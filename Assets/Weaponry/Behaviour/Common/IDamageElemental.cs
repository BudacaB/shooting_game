using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Weaponry
{
    public interface IDamageElemental
    {
        void DoPoisonDamage();
        void DoIceDamage();
        void DoFireDamage();
    }
}
