using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Player : Character
    {
        public void Equip()
        {

        }

        public void Dismount()
        {

        }

        public void Buy()
        {

        }

        public void Sell()
        {

        }

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
                    Console.WriteLine($"{Critical}%를 뚫고 {realDamage * 2}의 치명적인 데미지를 받았습니다.");
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
