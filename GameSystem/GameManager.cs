using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public enum Position
    {
        Lobby = 1,
        Town = 2,
        Shop = 3,
        Field = 4
    }
    class GameManager
    {
        Shop shop = new Shop();
        Equipment equipment = new Equipment();
        Position StatePosition = Position.Lobby;
        Player player = null; //이 되야함;
        Monster monster = null;
        Random rand = new Random();
        public Equipment equip = new Equipment();
        //static readonly string path = @"c:\StartMessage.txt";
        //string[] startText = System.IO.File.ReadAllLines(path);

        string[] placeArr = { "로비", "마을", "상점", "필드" };
        int placeInt = 0;
        public bool isMonsterSpawn = false;
        public bool isMonsterNull = false;
        public bool possibleBackShowText = false;

        public void GameProcess()
        {
            //for (int i = 0; i < 2; i++)
            //{
            //    Console.WriteLine(startText[i]);
            //}
            switch (StatePosition)
            {
                case Position.Lobby:
                    Lobby();
                    break;
                case Position.Town:
                    Town();
                    break;
                case Position.Shop:
                    GM_Shop();
                    break;
                case Position.Field:
                    Field();
                    break;
            }
        }

        public void Enter()
        {
            switch (StatePosition)
            {
                case Position.Lobby:
                    placeInt = 0;
                    break;
                case Position.Town:
                    placeInt = 1;
                    break;
                case Position.Shop:
                    placeInt = 2;
                    break;
                case Position.Field:
                    placeInt = 3;
                    break;
            }
            Console.WriteLine($"현재위치: {placeArr[placeInt]}\n");
        }

        public void Lobby()
        {
            Console.WriteLine("번호를 눌러 캐릭터를 생성해주십시오.");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            PlayerSpawn();
            equipment.Temp();
            equipment.SetEquipment();
        }
        public void Town()
        {
            Enter();
            Console.WriteLine("번호를 눌러 행동을 선택해주십시오.");
            Console.WriteLine("[1] 상점");
            Console.WriteLine("[2] 필드");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    StatePosition = Position.Shop;
                    break;
                case "2":
                    StatePosition = Position.Field;
                    break;
            }
            possibleBackShowText = false; //여기서 false를 안해주면 몬스터를 소환해도 행동을 할 수 없다.
        }

        public void GM_Shop()
        {
            Enter();
            equipment.Temp();
            while (true)
            {
                Console.WriteLine($"플레이어 스탯 정보: {player.Attack_Prop}");
                Console.WriteLine("1. 장비");
                Console.WriteLine("2. 스탯보기");
                Console.WriteLine("3. 나가기");
                Console.WriteLine("4. 구걸하기(확률로 랜덤 수치 하락)");
                Console.WriteLine("5. [20G] 50체력회복");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            shop.EquipMent(player);
                            break;
                        case 2:
                            shop.ShowPlayerStat(player);
                            break;
                        case 3:
                            StatePosition = Position.Town;
                            return;
                        case 4:
                            Beg();
                            break;
                        case 5:
                            if (player.Gold >= 20)
                            {
                                player.Gold -= 20;
                                player.Hp += 50;
                                Console.WriteLine($"체력50을 회복하였습니다. [현재체력]: {player.Hp}");
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("1~5의 숫자를 적어주십시오.");
                }
            }
        }


        public void Field()
        {
            Enter();
            MonsterSpawn();
            Console.WriteLine("행동을 선택하십시오.");

            while (!isMonsterNull && !possibleBackShowText) //true면 작동안함 [나가기와 도망]시 fallBack이 false일 경우  마을가도 공격 도망 텍스트뜸
            {
                Console.WriteLine("[1] 공격");
                Console.WriteLine("[2] 도망");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            Fight();
                            break;
                        case 2:
                            RunAway();
                            break;
                        default:
                            Console.WriteLine("1~2의 숫자를 적어주십시오.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("1~2의 숫자를 적어주십시오.");
                }

            }
        }

        public void Fight()
        {
            monster.TakeDamage(player.Attack_Prop, player, monster);

            if (monster.Hp > 0)
                Console.WriteLine($"ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ몬스터 체력: {monster.Hp}ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");

            if (monster.Hp <= 0)
            {
                if (monster.Name.Contains("Boss"))
                {
                    Console.WriteLine("보스를 처치하였습니다. 플레이 해주셔서 감사합니다.");
                    Environment.Exit(0);
                }
                int randomDropValue = rand.Next(1, 101);

                if (randomDropValue <= 20)
                {
                    monster.SuperDrop(player, monster);
                    Console.WriteLine(player.Gold);
                }
                else
                {
                    monster.Drop(player, monster);
                    Console.WriteLine(player.Gold);
                }
                Console.WriteLine($"ㅡㅡㅡㅡㅡㅡㅡㅡ****몬스터를 처치하였습니다.****ㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                player.Exp += monster.Exp;
                player.LevelUp();
                monster.Hp = 0;
                monster = null;
                isMonsterNull = true;
                isMonsterSpawn = false;
                return;
            }
            else
            {
                player.TakeDamage(monster.Attack_Prop, player, monster);

                if (player.Hp > 0)
                    Console.WriteLine($"ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ플레이어 체력: {player.Hp}ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");

                if (player.Hp <= 0)
                {
                    player.Hp = 0;
                    Console.WriteLine($"ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ플레이어 체력: {player.Hp = 0}ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                    Console.WriteLine($"ㅡㅡㅡ당신은 죽었습니다. 게임을 종료합니다. 모든정보는 초기화됩니다.ㅡㅡㅡ");
                    Environment.Exit(0);
                }
            }
        }

        public void PlayerSpawn()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            //기사 생성
                            player = new Knight();
                            Console.WriteLine("기사가 생성 되었습니다.");
                            StatePosition = Position.Town;
                            return;
                        case 2:
                            //궁수 생성
                            player = new Archer();
                            Console.WriteLine("궁수가 생성 되었습니다.");
                            StatePosition = Position.Town;
                            return;
                        case 3:
                            //마법사 생성
                            player = new Mage();
                            Console.WriteLine("법사가 생성 되었습니다.");
                            StatePosition = Position.Town;
                            return;
                        default:
                            Console.WriteLine("1~3의 숫자를 적어주십시오.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("1~3의 숫자를 적어주십시오.");
                }
            }
        }

        public void MonsterSpawn()
        {
            Console.WriteLine("번호를 선택하십시오.");
            Console.WriteLine("1. 슬라임   2. 오크   3. 스켈레톤   4. 뒤로가기   5. 보스(엄청 쌥니다.) ");
            while (!isMonsterSpawn)  //기본 값 false   true면 작동안함
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    switch (input)
                    {
                        case "1":
                            monster = new Slime();
                            Console.WriteLine("슬라임이 생성 되었습니다.");
                            isMonsterSpawn = true;
                            isMonsterNull = false;
                            break;
                        case "2":
                            monster = new Orc();
                            Console.WriteLine("오크가 생성 되었습니다.");
                            isMonsterSpawn = true;
                            isMonsterNull = false;
                            break;
                        case "3":
                            monster = new Skeleton();
                            Console.WriteLine("스켈레톤이 생성 되었습니다.");
                            isMonsterSpawn = true;
                            isMonsterNull = false;
                            break;
                        case "4":
                            monster = null;
                            possibleBackShowText = true;
                            StatePosition = Position.Town;
                            return;
                        case "5":
                            monster = new Boss();
                            Console.WriteLine("보스가 생성 되었습니다.");
                            Console.WriteLine("보스를 처치하시면 승리, 죽으시면 패배입니다.");
                            Console.WriteLine("건투를 빕니다.");
                            isMonsterSpawn = true;
                            isMonsterNull = false;
                            break;
                        default:
                            Console.WriteLine("[1]슬라임 2[오크] 3[스켈레톤] 4[뒤로가기] 5[보스] 올바른 번호를 적어주십시오.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("[1]슬라임 2[오크] 3[스켈레톤] 4[뒤로가기] 5[보스] 올바른 번호를 적어주십시오.");
                }
            }
        }

        private void RunAway()
        {
            int randValue = rand.Next(1, 101);

            if (monster.Name == "Boss")
            {
                Console.WriteLine("보스와의 전투는 무를 수 없습니다.");
                Console.WriteLine("당신에 겁에 질렸습니다.");
                Console.WriteLine("당신은 패기에 당해 사망하였습니다.");
                Environment.Exit(0);
            }
            else if (randValue <= 60)
            {
                Console.WriteLine("도망치지 못하였습니다. 강제 전투 진행");
                Fight();
            }
            else
            {
                Console.WriteLine("마을로 도망쳤습니다.");
                StatePosition = Position.Town;
                isMonsterSpawn = false;
                possibleBackShowText = true;
                return;
            }
        }
        public void Beg()
        {
            int begValue = rand.Next(1, 11);
            int randomMinusStatValue = rand.Next(1, 11);
            int minusStatValue = 0;
            string[] statString = { "공격력", "치명타", "방어력", "회피율", "경험치", "골드", "체력" };
            if (begValue <= 4)
            {
                player.Gold += 4;
                Console.WriteLine("구걸로 [4G]를 얻었습니다.");
            }
            else
            {
                switch (randomMinusStatValue)
                {
                    case 1:
                        minusStatValue = 0;
                        player.Attack_Prop -= 1;
                        break;
                    case 2:
                        minusStatValue = 1;
                        player.Critical -= 1;
                        break;
                    case 3:
                        minusStatValue = 2;
                        player.Def -= 1;
                        break;
                    case 4:
                        minusStatValue = 3;
                        player.Evasion -= 1;
                        break;
                    case 5:
                        minusStatValue = 4;
                        player.Exp -= 1;
                        break;
                    case 6:
                        minusStatValue = 5;
                        player.Gold -= 1;
                        break;
                    case 7:
                        minusStatValue = 6;
                        player.Hp -= 1;
                        break;
                    default:
                        Console.WriteLine("구타를 피하여 스탯하락을 막았습니다.");
                        break;
                }
                if (randomMinusStatValue <= 7)
                    Console.WriteLine($"[{statString[minusStatValue]}] 스탯이 1만큼 하락하였습니다.");
            }
        }
    }
}
