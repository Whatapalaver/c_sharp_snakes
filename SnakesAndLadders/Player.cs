﻿using System;
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
            while (position != Constants.FinalPosition && inPlay)
            {
                Console.WriteLine("You are at position {0}, press any key to roll, or 'Q' to exit", position);
                string decision = Console.ReadLine() ?? string.Empty;

                // Handle user input Q to exit otherwise move()
                switch (decision.ToUpper())
                {
                    case "Q":
                        Console.WriteLine("You appear to have become bored at position {0}. Goodbye!", position);
                        inPlay = false;
                        break;
                    default:
                        PlayerMove();
                        break;

                }
            }

        }

        public void PlayerMove()
        {
            int roll = DiceRoll();
            if (ValidMove(roll))
            {
                position += roll;
                Console.WriteLine("You are now at position {0}.", position);
            }
            else
            {
                ExceptionMove(roll);
            }

        }

        private void ExceptionMove(int roll)
        {
            // test for win or overshoot
            if (Win(roll))
            {
                inPlay = false;
                DeclareWinner();
            }
            else
            {
                DeclareOvershoot(roll);
            }
        }

        private void DeclareOvershoot(int roll)
        {
            Console.WriteLine("You overshot the last square with a roll of {0}, try again!}.", roll);
        }

        private void DeclareWinner()
        {
            Console.WriteLine("{0} You have won!!}.", Name);
        }

        private int DiceRoll()
        {
            Random rnd = new Random();
            return rnd.Next(1, 6);
        }

        private bool Win(int roll)
        {
            return (position + roll) == Constants.FinalPosition;
        }

        private bool ValidMove(int roll)
        {
            return (position + roll) < Constants.FinalPosition;
        }
    }
}
