using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Weapon: DataManagement
    {
        public Weapon()
        {
            SetInfo(100, 75, 1, 5, 25, 500,"무난한 무기");
        }
        public void SetInfo(int hp, int attack, int def, int evasion, int critical, int gold, string armor)
        {
            this.Attack_Prop = attack;
            this.Def = def;
            this.Evasion = evasion;
            this.Critical = critical;
            this.Hp = hp;
            this.Gold = gold;
            this.ArmorName = armor;
        }
    }
}
