using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public enum GameProcess
    {
        None = 0,
        Lobby = 1,

        //inGame
        Town = 2,
        Field = 3
    }
    class GameManager
    {
        Player player = null; //이 되야함;

        //Knight knight = null; //이게 아니라...
        //Archer archer = null;
        //Mage mage= null;
        Slime slime = null;
        Random rand = new Random();
        GameProcess gm = GameProcess.Lobby;
        public void Process()
        {
            switch (gm)
            {
                case GameProcess.Lobby:
                    Lobby();
                    break;
                case GameProcess.Town:
                    Town();
                    break;
                case GameProcess.Field:
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
                    player = new Player.Knight();
                    Console.WriteLine("기사가 생성 되었습니다.");
                    gm = GameProcess.Town;
                    Console.WriteLine($"체력: {player.Hp} 공격력: {player.Attack}");
                    break;
                case "2":
                    //궁수 생성
                    player = new Player.Archer();
                    Console.WriteLine("궁수가 생성 되었습니다.");
                    gm = GameProcess.Town;
                    Console.WriteLine($"체력: {player.Hp} 공격력: {player.Attack}");
                    break;
                case "3":
                    //마법사 생성
                    player = new Player.Mage();
                    Console.WriteLine("법사가 생성 되었습니다.");
                    gm = GameProcess.Town;
                    Console.WriteLine($"체력: {player.Hp} 공격력: {player.Attack}");
                    break;
            }

        }
        private void Town()
        {
            Console.WriteLine("마을에 입장하셨습니다.");
            Console.WriteLine("[1] 필드 들어가기");
            Console.WriteLine("[2] 로비로 돌아가기");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    gm = GameProcess.Field;
                    break;

                case "2":
                    gm = GameProcess.Lobby;
                    break;
            }
        }

        private void Field()
        {
            Console.WriteLine("필드에 입장하셨습니다.");
            //몬스터 소환
            slime = new Slime();

            Console.WriteLine("몬스터가 소환 되었습니다.");
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

        public void Fight()
        {
            //캐릭터 VS 몬스터
            while (true)
            {
                int damage = player.Attack;
                slime.DecreaseHp(damage);
                if (slime.IsDie())
                {
                    Console.WriteLine("몬스터를 처치하였습니다.");
                    Console.WriteLine($"체력: {player.Hp}");
                    break;
                }

                damage = slime.Attack;
                player.DecreaseHp(damage);
                if (player.IsDie())
                {
                    Console.WriteLine("플레이어가 사망하였습니다.\n");
                    gm = GameProcess.Lobby;
                    break;
                }

                //이후 무한 반복
            }
        }

        private void RunAway()
        {
            int randValue = rand.Next(1, 101);
            if (randValue <= 66)
            {
                Console.WriteLine("도망치지 못하였습니다. 강제 전투 진행");
                Fight();
            }
            else
            {
                Console.WriteLine("도망쳤습니다.");
                gm = GameProcess.Town;
            }
        }
    }
}
