using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Character
    {
        public int Attack_Prop { get; set; }
        public int Def { get; set; }
        public int Evasion { get; set; }
        public int Critical { get; set; }
        public int Gold { get; set; }
        public int Hp { get; set; }
        public int Exp { get; set; }

        public bool EquipWeapon { get; set; }
        public bool EquipArmor { get; set; }
        public bool EquipHat { get; set; }
    }
}
