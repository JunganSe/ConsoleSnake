using System;

namespace ConsoleSnake
{
    class DrawHelper
    {
        public static void DrawFrame(int x, int y, int width, int height, bool doubleWall = false)
        {
            string parts = (doubleWall ? "═║╔╗╚╝" : "─│┌┐└┘"), horizontalLine = "";

            // Horizontal line without corners.
            for (int i = 0; i < width - 2; i++) { horizontalLine += parts[0]; }

            // Top part
            Console.SetCursorPosition(x, y);
            Console.Write(parts[2] + horizontalLine + parts[3]);

            // Middle part (sides).
            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(parts[1]);
                Console.SetCursorPosition(x + width - 1, y + i);
                Console.Write(parts[1]);
            }

            // Bottom part.
            Console.SetCursorPosition(x, y + height - 1);
            Console.Write(parts[4] + horizontalLine + parts[5]);
        }

        public static void FillArea(int x, int y, int width, int height, char character = ' ')
        {
            string line = new String(character, width);
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(line);
            }
        }
    }
}
