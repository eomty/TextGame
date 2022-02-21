using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class DataManagement
    {
        public string ArmorName { get; set; }
        public int Attack_Prop { get; set; }
        public int Def { get; set; }
        public int Evasion { get; set; }
        public int Critical { get; set; }
        public int Gold { get; set; }
        public int Hp { get; set; }
        public bool PossibleActive { get; set; }

       public bool PossibleBuy { get; set; }
    }
}
