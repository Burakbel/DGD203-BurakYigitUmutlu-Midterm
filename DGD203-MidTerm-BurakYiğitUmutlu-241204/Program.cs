// This code was generated with the assistance of Claude 3.5 Sonnet
using System;

class Program
{
    static void Main()
    {
        try
        {
            Game game = new Game();
            game.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
