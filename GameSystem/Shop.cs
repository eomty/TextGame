using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    class Shop : Equipment
    {
        public int TempValue = 0;
        public bool temp = false;

        public void ShowPlayerStat(Player player)
        {

            Console.WriteLine($"골드:{player.Gold} 체력:{player.Hp} 공격력:{player.Attack_Prop} 방어력:{player.Def} 회피율:{player.Evasion}% 치명타:{player.Critical}%");
        }

        public void EquipMent(Player player)
        {

            while (true)
            {
                Console.WriteLine($"1. [{hat.Gold}G] ({hat.ArmorName}) 체력+{hat.Hp} 공격력+{hat.Attack_Prop} 방어력+{hat.Def} 회피율+{hat.Evasion} 치명타+{hat.Critical}");
                Console.WriteLine($"2. [{armor.Gold}G] ({armor.ArmorName}) 체력+{armor.Hp} 공격력+{armor.Attack_Prop} 방어력+{armor.Def} 회피율+{armor.Evasion} 치명타+{armor.Critical}");
                Console.WriteLine($"3. [{weapon.Gold}G] ({weapon.ArmorName}) 체력+{weapon.Hp} 공격력+{weapon.Attack_Prop} 방어력+{weapon.Def} 회피율+{weapon.Evasion} 치명타+{weapon.Critical}");
                Console.WriteLine("4. 뒤로가기");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            if (player.Gold >= 100)
                            {
                                if (!isAlreadyBuyHat)
                                {

                                    isBuyHat = true; //고정
                                    IncreaseEquipmentStat(player);
                                    isAlreadyBuyHat = true;
                                    Console.WriteLine("투구구입 완료");
                                }
                                else
                                {
                                    Console.WriteLine("이미 투구를 구입하셨습니다.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("골드가 부족합니다.");
                            }
                            break;
                        case 2:
                            if (player.Gold >= 200)
                            {
                                if (!isAlreadyBuyArmor)
                                {
                                    isBuyArmor = true;
                                    IncreaseEquipmentStat(player);
                                    isAlreadyBuyArmor = true;
                                    Console.WriteLine("조끼구입 완료");
                                }
                                else
                                {
                                    Console.WriteLine("이미 조끼를 구입하셨습니다.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("골드가 부족합니다.");
                            }
                            break;
                        case 3:
                            if (player.Gold >= 500)
                            {
                                if (!isAlreadyBuyWeapon)
                                {
                                    isBuyWeapon = true;
                                    IncreaseEquipmentStat(player);
                                    isAlreadyBuyWeapon = true;
                                    Console.WriteLine("무기구입 완료");
                                }
                                else
                                {
                                    Console.WriteLine("이미 무기를 구입하셨습니다.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("골드가 부족합니다.");
                            }
                            break;
                        case 4:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("1~3의 숫자를 적어주십시오.");
                }
            }
        }

    }
}
