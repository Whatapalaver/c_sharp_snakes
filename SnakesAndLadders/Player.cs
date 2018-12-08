using System;
using static System.Console;

namespace SnakesAndLadders
{
    public class Player
    {
        private bool InPlay { get; set; }
        private int Position { get; set; }
        public string Name { get; set; }

        public Player(string Name)
        {
            Position = Constants.StartingPosition;
            InPlay = true;
            Console.WriteLine("Welcome {0}. You are at position {1}!", Name, Position);
        }

        public void Play()
        {
            while (Position != Constants.FinalPosition && InPlay)
            {
                Console.WriteLine("You are at position {0}, press any key to roll, or 'Q' to exit", Position);
                string decision = Console.ReadLine() ?? string.Empty;

                // Handle user input Q to exit otherwise move()
                switch (decision.ToUpper())
                {
                    case "Q":
                        Console.WriteLine("You appear to have become bored at position {0}. Goodbye!", Position);
                        InPlay = false;
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
                Position += roll;
                Console.WriteLine("You are now at position {0}.", Position);
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
                InPlay = false;
                DeclareWinner();
            }
            else
            {
                DeclareOvershoot(roll);
            }
        }

        private void DeclareOvershoot(int roll)
        {
            Console.WriteLine("You overshot the last square with a roll of {0}, try again!.", roll);
        }

        private void DeclareWinner()
        {
            Console.WriteLine("{0} You have won!!.", Name);
        }

        private int DiceRoll()
        {
            Random rnd = new Random();
            return rnd.Next(1, 6);
        }

        private bool Win(int roll)
        {
            return (Position + roll) == Constants.FinalPosition;
        }

        private bool ValidMove(int roll)
        {
            return (Position + roll) < Constants.FinalPosition;
        }
    }
}
