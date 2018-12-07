using System;
using static System.Console;

namespace SnakesAndLadders
{
    public class Player
    {
        private bool inPlay { get; set; }
        private int position { get; set; }
        public string Name { get; set; }

        public Player(string Name)
        {
            position = Constants.StartingPosition;
            inPlay = true;
            Console.WriteLine("Welcome {0}. You are at position {1}!", Name, position);
        }

        public void Play()
        {
            if (inPlay) Console.WriteLine("Wow, what a cool game! You are at position {0}", position);
        }
    }
}
