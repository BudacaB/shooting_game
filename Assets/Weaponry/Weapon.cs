using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Weaponry
{
    public enum WeaponType
    {
        Ranged,
        Melee
    }

    public enum DamageSpread
    {
        Focused,
        Splash
    }

    public enum DamageType
    {
        Poison,
        Fire,
        Ice
    }

    public enum WeaponClass
    {
        Common,
        Rare,
        Legendary,
        Set
    }


    public class Weapon
    {
        public string Name { get; set; }
        public int Damage {
            get {
                return this.CalculateDamage();
            }
        }
        public WeaponType Type { get; set; }
        public DamageSpread DmgSpread { get; set; }
        public DamageType DmgType { get; set; }
        public WeaponClass Class { get; set; }
        public List<Augment> Augments { get; set; }

        public Weapon(string name, WeaponClass weaponClass)
        {
            this.Class = weaponClass;
            this.Name = name;
            this.Augments = new List<Augment>();
        }

        private int CalculateDamage()
        {
            var totalDamage = CalculateBaseDamageByClass() + GetDmgForAllAugments();
            return totalDamage;
        }

        private int CalculateBaseDamageByClass()
        {
            var baseDmg = 0;
            if (this.Class == WeaponClass.Common) baseDmg = 50;
            else if (this.Class == WeaponClass.Legendary) baseDmg = 300;
            else if (this.Class == WeaponClass.Rare) baseDmg = 100;
            else baseDmg = 500;
            return baseDmg;
        }

        private int GetDmgForAllAugments()
        {
            var totalExtraDmg = 0;
            for (var i = 0; i < this.Augments.Count; i++)
            {
                var currentAugment = Augments[i];
                totalExtraDmg = totalExtraDmg + currentAugment.ExtraDmg;
            }
            return totalExtraDmg;
        }

        public override string ToString()
        {
            return $"Attacking with: {Name}, augmented with: {GetNamesOfAugments()}";
        }

        private object GetNamesOfAugments()
        {
            string nameOfAugments = String.Empty;
            for (var i = 0; i < Augments.Count; i++)
            {
                var comma = i == 0 ? string.Empty : ", ";
                nameOfAugments = nameOfAugments + comma + Augments[i].Name;
            }
            return nameOfAugments;
        }
    }

    public enum AugmentType
    {
        Gem,
        Rune
    }

    public class Augment
    {
        public string Name { get; set; }
        public AugmentType Type { get; set; }
        public int ExtraDmg { get; set; }

        public Augment(string name, AugmentType type)
        {
            this.Name = name;
            if (type == AugmentType.Gem) ExtraDmg = 20;
            else ExtraDmg = 40;
        }
    }
}
