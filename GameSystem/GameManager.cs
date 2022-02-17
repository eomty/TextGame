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
        Position StatePosition = Position.Lobby;
        Player player = null; //이 되야함;
        Monster monster = null;
        Random rand = new Random();
       public Equipment equip = new Equipment();
        static readonly string path = @"c:\StartMessage.txt";
        string[] startText = System.IO.File.ReadAllLines(path);

        string[] placeArr = { "로비", "마을", "상점", "필드" };
        int playerPoint = 1;
        int placeInt = 0;
        public bool isMonsterSpawn = false;
        public bool isMonsterNull = false;
        public bool fallBack = false;
        //int playerPosition=1;

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
                    Shop();
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
        }
        public void Town()
        {
            equip.Temp();
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
            fallBack = false;
        }

        public void Shop()
        {
            Enter();
            //Console.WriteLine("미완성이므로 마을로 돌아갑니다.");
            //Console.WriteLine("1. 장비");
            //Console.WriteLine("2. 아이템");
            //Console.WriteLine("3. 도박");
            //Console.WriteLine("4. 나가기");

            //Console.WriteLine("장비이름, 스탯, 가격, 장착여부");
            //Console.WriteLine("장비이름, 스탯, 가격, 장착여부");
            //Console.WriteLine("장비이름, 스탯, 가격, 장착여부");

            //Console.WriteLine("소형포션, 중형포션, 대형포션");

            //장비는 각각 다른이름의 클래스만들어서 하나식 관리


            player.LevelUp();
            StatePosition = Position.Town;
        }

        public void Field()
        {
            Enter();

            MonsterSpawn();
            Console.WriteLine("행동을 선택하십시오.");


            while (!isMonsterNull && !fallBack) //기본값 false     true면 작동안함
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
                            return;
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
            monster.TakeDamage(player.Attack_Prop);

            if (monster.Hp > 0)
                Console.WriteLine($"ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ몬스터 체력: {monster.Hp}ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");

            if (monster.Hp <= 0)
            {
                int randValue3 = rand.Next(1, 101);

                if (randValue3 <= 5)
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
                player.TakeDamage(monster.Attack_Prop);

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
            Console.WriteLine("1. 슬라임   2. 오크   3. 스켈레톤   4. 뒤로가기 ");
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
                            fallBack = true;
                            StatePosition = Position.Town;
                            return;
                        default:
                            Console.WriteLine("[1]슬라임 2[오크] 3[스켈레톤] 4[뒤로가기] 올바른 번호를 적어주십시오.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("[1]슬라임 2[오크] 3[스켈레톤] 4[뒤로가기] 올바른 번호를 적어주십시오.");
                }
            }
        }

        private void RunAway()
        {
            int randValue = rand.Next(1, 101);
            if (randValue <= 60)
            {
                Console.WriteLine("도망치지 못하였습니다. 강제 전투 진행");
                Fight();
            }
            else
            {
                Console.WriteLine("마을로 도망쳤습니다.");
                StatePosition = Position.Town;
                return;
            }
        }
    }
}
