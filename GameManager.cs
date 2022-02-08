using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    enum GameMode
    {
        None=0,
        Lobby=1,
        Town=2,
        Field=3
    }
    class GameManager
    {
        Creature creature = new Creature();
        GameMode gm = GameMode.Lobby;
        public void Process()
        {
            switch (gm)
            {
                case GameMode.Lobby:
                    Lobby();
                    break;
                case GameMode.Town:
                    Town();
                    break;
                case GameMode.Field:
                    Field();
                    break;
            }
        }
        private void Lobby()
        {

            Console.WriteLine("로비에 입장하셨습니다.");
            Console.WriteLine("번호를 눌러 캐릭터를 생성해주십시오.");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    //기사 생성
                    Player.Knight knight = new Player.Knight(150,20);
                    Console.WriteLine("기사가 생성 되었습니다.");
                    gm = GameMode.Town;
                    Console.WriteLine($"체력: {knight.GetHp()} 공격력: {knight.attack}");
                    break;
                case "2":
                    //궁수 생성
                    Player.Archer archer = new Player.Archer(100, 30);
                    Console.WriteLine("궁수가 생성 되었습니다.");
                    gm = GameMode.Town;
                    Console.WriteLine($"체력: {archer.GetHp()} 공격력: {archer.attack}");
                    break;
                case "3":
                    //마법사 생성
                    Player.Mage mage = new Player.Mage(80, 50);
                    Console.WriteLine("법사가 생성 되었습니다.");
                    gm = GameMode.Town;
                    Console.WriteLine($"체력: {mage.GetHp()} 공격력: {mage.attack}");
                    break;
            }
            
        }
        private void Town()
        {
            Console.WriteLine("마을에 입장하셨습니다.");
            Console.WriteLine("[1] 필드 들어가기");
            Console.WriteLine("[2] 로비로 돌아가기");
            Monster.Slime slime = new Monster.Slime(50, 2);

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    gm = GameMode.Field;
                    break;

                case "2":
                    gm = GameMode.Lobby;
                    break;
            }
        }

        private void Field()
        {
            Console.WriteLine("필드에 입장하셨습니다.");
            //몬스터 소환
            Console.WriteLine("... 가 소환 되었습니다.");
            Console.WriteLine("[1] 전투!");
            Console.WriteLine("[2] 도망가기");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Fight();
                    break;

                case "2":
                    RunAway();
                    break;
            }
        }

        private void Fight()
        {
            //캐릭터 VS 몬스터
            while (true)
            {
                
            }
        }

        private void RunAway()
        {
            gm = GameMode.Town;
        }
    }
}
