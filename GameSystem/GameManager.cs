using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{


    class GameManager
    {
        Player player = null; //이 되야함;
        //Monster monster = null;
        Random rand = new Random();
        static readonly string path = @"c:\StartMessage.txt";
        string[] startText = System.IO.File.ReadAllLines(path);

        public void GameStart()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(startText[i]);
            }
            Lobby();
        }

        public void Enter()
        {
            //Console.WriteLine($"[{place}]에 입장하셨습니다.");
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
                    player = new Knight();
                    Console.WriteLine("기사가 생성 되었습니다.");
                    break;
                case "2":
                    //궁수 생성
                    player = new Archer();
                    Console.WriteLine("궁수가 생성 되었습니다.");
                    break;
                case "3":
                    //마법사 생성
                    player = new Mage();
                    Console.WriteLine("법사가 생성 되었습니다.");
                    break;
            }

        }
        private void Town()
        {

        }

        private void Field()
        {

        }

        public void Fight()
        {

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
            }
        }
    }
}
