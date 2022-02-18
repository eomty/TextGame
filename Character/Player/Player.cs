using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Player : Character
    {
        public void LevelUp()
        {
            //Attack_Prop += 3000; //임시
            if (Exp > 100)
            {
                Exp -= 100;
                Level += 1;
                Hp += 22;
                Attack_Prop += 3;
                Def += 1;
                Evasion += 1;
                Critical += 2;
                Console.WriteLine("레벨업!!");
            }
        }
        public int TakeDamage(int damage, Player player, Monster monster)
        {
            Random rand = new Random();
            int playerEvasionValue = rand.Next(1, 101);
            int randomMonsterCriticalValue = rand.Next(1, 101);
            if (playerEvasionValue >= player.Evasion)
            {
                int realDamage = damage - player.Def;
                if (randomMonsterCriticalValue <= monster.Critical)
                {
                    Hp -= realDamage * 2;
                    Console.WriteLine($"{monster.Critical}%를 뚫고 {realDamage * 2}의 치명적인 데미지를 받았습니다.");
                }
                else
                {
                    Console.WriteLine($"{realDamage}의 데미지를 받았습니다.");
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
