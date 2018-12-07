﻿using System;

namespace SnakesAndLadders
{
    static class Constants
    {
        public const int StartingPosition = 1;
        public const int FinalPosition = 100;
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name to play");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome {0}, let's play", name);
            Player player = new Player(name);
            player.Play();
        }
    }
}
