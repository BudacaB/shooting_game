using Assets.Weaponry.Behaviour;
using Assets.Weaponry.Behaviour.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Weaponry
{
    public class Knife : IBlade
    {
        public int damage = 0;

        public int CalculateDamage()
        {
            CommonDamage();
            UsesGem();
            return damage;
        }

        public Knife()
        {

        }

        public void CommonDamage()
        {
            this.damage = damage + 50;
        }

        public void UsesGem()
        {
            this.damage += 20;
        }

        public void DoBaseDamage()
        {
            
        }

        public void DoFireDamage()
        {
            
        }

        public void DoIceDamage()
        {
            
        }

        public void DoPoisonDamage()
        {
            
        }

        public void FocusedDamage()
        {
            
        }

        public void LegendaryDamage()
        {
            this.damage += 300;
        }

        public void RareDamage()
        {
            this.damage = damage + 100;
        }

        public void SetDamage()
        {
            this.damage = damage + 500;
        }

        public void Slash()
        {
            
        }

        public void SplashDamage()
        {
            
        }

        public void Stab()
        {
            
        }

        public void TakeDamage()
        {
            
        }

        public void UsesRune()
        {
            this.damage = damage + 40;
        }
    }
}
