using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Monster:Character
    {
        public int CP { get; set; }

        public void Drop(Player player, Monster monster)
        {
            player.Gold += monster.Gold;
        }

        public void SuperDrop(Player player, Monster monster)
        {
            player.Gold += monster.Gold*10;
            //시간되면 특수장비 떨구는거로...
        }
        public override int TakeDamage(int damage)
        {
            Random rand = new Random();
            int randValue = rand.Next(1, 101);
            int randValue2 = rand.Next(1, 101);
            if (randValue >= Evasion)
            {
                int realDamage = damage - Def;

                if (randValue2 <= Critical)
                {
                    Hp -= realDamage * 2;
                    Console.WriteLine($"{Critical}%를 뚫고 {realDamage * 2}의 치명적인 데미지를 주었습니다.");
                }
                else
                {
                    Console.WriteLine($"{realDamage}의 데미지를 주었습니다.");
                }

                Hp -= realDamage;
            }
            else
            {
                Console.WriteLine("몬스터가 공격을 회피 하였습니다.!");
                return Hp;
            }


            return Hp;
        }
    }
}
