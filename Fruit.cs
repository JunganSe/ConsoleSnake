using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class Fruit
    {
        public static int X { get; set; }
        public static int Y { get; set; }

        public static void MoveToNewLocation()
        {
            bool restart = true;
            while (restart)
            {
                restart = false;
                var random = new Random();
                X = random.Next(Game.levelWidth);
                Y = random.Next(Game.levelHeight);

                for (int i = 0; i < Snake.PartsX.Count; i++)
                {
                    if ((X == Snake.PartsX[i]) && (Y == Snake.PartsY[i]))
                    {
                        restart = true;
                    }
                }
            }
        }

        public static void Draw()
        {
            Console.SetCursorPosition(Game.levelX + X * 2, Game.levelY + Y);
            Console.Write("o");
        }
    }
}
