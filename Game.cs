using System;
using System.Threading;

namespace ConsoleSnake
{
    class Game
    {
        public static int sleepDuration = 50;
        public static int levelX = 3;
        public static int levelY = 2;
        public static int levelWidth = 20;
        public static int levelHeight = 15;

        public static void GameInitialize()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(levelX * 2 + levelWidth * 2, levelY * 2 + levelHeight);
            DrawHelper.DrawFrame(levelX - 1, levelY - 1, levelWidth * 2 + 2, levelHeight + 2, true);
        }

        public static void GameLoop()
        {
            Snake.Initialize(levelWidth / 2, levelHeight / 2, Direction.Up);
            Fruit.MoveToNewLocation();

            while (true) // Main loop
            {
                Thread.Sleep(sleepDuration);

                var input = GetInput();
                if (input == Input.Quit) { break; }

                Snake.HandleInput(input);
                Snake.Move();
                Snake.Wrap();
                Snake.CheckFruit();

                DrawHelper.FillArea(levelX, levelY, levelWidth * 2, levelHeight);
                Snake.Draw();
                Fruit.Draw();

                DrawScore();
            }
        }

        public static Input GetInput()
        {
            var input = Input.Nothing;
            while (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                case ConsoleKey.LeftArrow:
                    input = Input.Left;
                    break;
                case ConsoleKey.RightArrow:
                    input = Input.Right;
                    break;
                case ConsoleKey.UpArrow:
                    input = Input.Up;
                    break;
                case ConsoleKey.DownArrow:
                    input = Input.Down;
                    break;
                case ConsoleKey.Q:
                    input = Input.Quit;
                    break;
                case ConsoleKey.Spacebar:
                    input = Input.Pause;
                    break;
                }
            }
            return input;
        }

        public static void DrawScore()
        {
            Console.SetCursorPosition(levelX, levelY - 2);
            Console.Write("                        ");
            Console.SetCursorPosition(levelX, levelY - 2);
            Console.Write($"Score: {Snake.Score}");
        }

        public static void End()
        {
            // TODO: End the game.
        }
    }
}
