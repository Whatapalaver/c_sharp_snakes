using System;

namespace SnakesAndLadders
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name to play");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome {0}, let's play", name);
            Player player = new Player();
            player.Play();
        }
    }
}
