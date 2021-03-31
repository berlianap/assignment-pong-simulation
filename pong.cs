using System;
using System.Threading;

namespace PongSimulation
{
    class main
    {
        static void Main(string[] args)
        {
            // create score instance
            Score score = new Score();

            // create player instance
            Player playerX = new Player(Players.PlayerX);
            Player playerY = (Player) playerX.Clone();
            playerY.players = Players.PlayerY;

            // create thread
            Thread playerXThread = new Thread(new ThreadStart(playerX.GenerateHits));
            Thread playerYThread = new Thread(new ThreadStart(playerY.GenerateHits));
            

            // random first turn
            Random rand = new Random();
            int firstTurn;
            firstTurn = rand.Next(0, 2);

            if (firstTurn == (int)Players.PlayerX)
            {
                playerXThread.Start();
                Thread.Sleep(1000);
                playerYThread.Start();
            }
            else if (firstTurn == (int)Players.PlayerY)
            {
                playerYThread.Start();
                Thread.Sleep(1000);
                playerXThread.Start();
            }

            playerXThread.Join();
            playerYThread.Join();

            // final score
            Console.WriteLine("PlayerX :" + Score.playerXScore);
            Console.WriteLine("PlayerY :" + Score.playerYScore);
        }
    }
}
