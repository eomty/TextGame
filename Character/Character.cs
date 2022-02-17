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
        public int Level { get; set; }
        public int Hp { get; set; }

        public int Exp { get; set; }



        public virtual int TakeDamage(int damage)
        {
            Random rand = new Random();
           int randValue= rand.Next(1, 101);
            int randValue2 = rand.Next(1, 101);
            if (randValue >= Evasion)
            {
                int realDamage = damage - Def;
                Console.WriteLine($"{realDamage}의 데미지를 주었습니다.");
                if (randValue2 <= Critical)
                {
                    Hp -= realDamage * 2;
                    Console.WriteLine($"{Critical}%를 뚫고 {realDamage*2}의 치명적인 데미지를 주었습니다.");
                }

                Hp -= realDamage;
            }
            else
            {
                Console.WriteLine("몬스터 공격을 회피 하였습니다.!");
                return Hp;
            }

            
            return Hp;
        }
    }
}
