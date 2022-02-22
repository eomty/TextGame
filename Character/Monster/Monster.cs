using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Monster : Character
    {
        public string Name { get; set; }

        public void Drop(Player player, Monster monster)
        {
            player.Gold += monster.Gold;
            Console.WriteLine($"\n몬스터를 처치하여 [{monster.Gold}G]를 획득하였습니다.\n");
        }

        public void SuperDrop(Player player, Monster monster)
        {
            player.Gold += monster.Gold * 3;
            Console.WriteLine($"\n몬스터를 처치하여 [{monster.Gold * 3}G]를 획득하였습니다.\n");
        }
        public int TakeDamage(int damage, Player player, Monster monster)
        {
            Random rand = new Random();
            int monsterEvasionValue = rand.Next(1, 101);
            int randomPlayerCriticalValue = rand.Next(1, 101);
            if (monsterEvasionValue >= monster.Evasion)
            {
                int realDamage = damage - monster.Def;

                if (randomPlayerCriticalValue <= player.Critical)
                {
                    Hp -= realDamage * 2;
                    Console.WriteLine($"\n{player.Critical}%를 뚫고 {realDamage * 2}의 치명적인 데미지를 주었습니다.");
                }
                else
                {
                    Console.WriteLine($"\n{realDamage}의 데미지를 주었습니다.");
                }
                Hp -= realDamage;
            }
            else
            {
                Console.WriteLine("몬스터가 공격을 회피 하였습니다!\n");
                return Hp;
            }
            return Hp;
        }
    }
}
