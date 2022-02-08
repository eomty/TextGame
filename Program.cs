using System;

namespace TextGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();

            while (true)
            {
                gm.Process();
            }
        }
    }
}
