using System;
using System.Collections.Generic;

namespace ConsoleSnake
{
    public static class Snake
    {
        public static Direction Direction { get; set; }
        public static List<int> PartsX { get; set; } = new();
        public static List<int> PartsY { get; set; } = new();
        public static int Score { get; set; }

        public static void Initialize(int x, int y, Direction direction)
        {
            Direction = direction;
            PartsX.Add(x);
            PartsY.Add(y);
            AddPart();
            AddPart();
            AddPart();
            Score = 0;
        }

        public static void AddPart()
        {
            PartsX.Add(PartsX[PartsX.Count - 1]);
            PartsY.Add(PartsY[PartsY.Count - 1]);
        }

        public static void HandleInput(Input input)
        {
            if ((input == Input.Up) && (Direction != Direction.Down))
            {
                Direction = Direction.Up;
            }
            else if ((input == Input.Down) && (Direction != Direction.Up))
            {
                Direction = Direction.Down;
            }
            else if ((input == Input.Left) && (Direction != Direction.Right))
            {
                Direction = Direction.Left;
            }
            else if ((input == Input.Right) && (Direction != Direction.Left))
            {
                Direction = Direction.Right;
            }
        }

        public static void Move()
        {
            int x = PartsX[0], y = PartsY[0];
            if (((Direction == Direction.Up) && (CheckFree(x, y - 1)))
                || ((Direction == Direction.Down) && (CheckFree(x, y + 1)))
                || ((Direction == Direction.Left) && (CheckFree(x - 1, y)))
                || ((Direction == Direction.Right) && (CheckFree(x + 1, y)))
                )
            {
                // Body
                for (int i = PartsX.Count - 1; i >= 1; i--)
                {
                    PartsX[i] = PartsX[i - 1];
                    PartsY[i] = PartsY[i - 1];
                }

                // Head
                switch (Direction)
                {
                case Direction.Up:
                    PartsY[0] -= 1;
                    break;
                case Direction.Down:
                    PartsY[0] += 1;
                    break;
                case Direction.Left:
                    PartsX[0] -= 1;
                    break;
                case Direction.Right:
                    PartsX[0] += 1;
                    break;
                }
            }
            else
            {
                throw new Exception("Self collision!"); // TODO: End the game.
            }
        }

        public static bool CheckFree(int x, int y)
        {
            for (int i = 0; i < PartsX.Count; i++)
            {
                if ((x == PartsX[i]) && (y == PartsY[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static void Wrap()
        {
            if (PartsX[0] < 0)
            {
                PartsX[0] += Game.levelWidth;
            }
            else if (PartsX[0] >= Game.levelWidth)
            {
                PartsX[0] -= Game.levelWidth;
            }
            else if (PartsY[0] < 0)
            {
                PartsY[0] += Game.levelHeight;
            }
            else if (PartsY[0] >= Game.levelHeight)
            {
                PartsY[0] -= Game.levelHeight;
            }
        }
        
        public static void CheckFruit()
        {
            if ((Fruit.X == PartsX[0]) && (Fruit.Y == PartsY[0]))
            {
                AddPart();
                Fruit.MoveToNewLocation();
                Score++;
            }
        }

        public static void Draw()
        {
            // Head
            Console.SetCursorPosition(Game.levelX + PartsX[0] * 2, Game.levelY + PartsY[0]);
            Console.Write("@");

            // Body
            for (int i = 1; i < PartsX.Count; i++)
            {
                Console.SetCursorPosition(Game.levelX + PartsX[i] * 2, Game.levelY + PartsY[i]);
                Console.Write("O");
            }
        }
    }
}
