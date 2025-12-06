namespace ConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Press any key to start.");
            //Console.ReadKey(true);

            Game.GameInitialize();
            Game.GameLoop();

            // Console.WriteLine("Copying array 1 into array 2 but offset by 1.");
            // Array.Copy(numbers1, 0, numbers2, 1, numbers1.Length - 1);
            // Använd för kvadrat: "██"
        }
    }
}
