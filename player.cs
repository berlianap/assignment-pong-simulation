using System;
using System.Threading;

namespace PongSimulation
{
    public enum Players { 
        PlayerX, 
        PlayerY
    };

    class Player : ICloneable
    {
        public Players players;
        public float hits;

        public Player(Players players)
        {
            this.players = players;
        }

        public void GenerateHits()
        {
            Random rand = new Random();

            while (Score.playerXScore < 10 && Score.playerYScore < 10)
            {
                hits = rand.Next(1, 101);
                Console.WriteLine(players + " Hits :" + hits);

                if (hits <= 50)
                {
                    if (players == Players.PlayerX)
                    {
                        Score.playerXScore += 1;
                        Console.WriteLine(players + " Scored.");
                    }
                        
                    else if (players == Players.PlayerY)
                    {
                        Score.playerYScore += 1;
                        Console.WriteLine(players + " Scored.");
                    }
                }

                Console.WriteLine();

                Thread.Sleep(2000);
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
