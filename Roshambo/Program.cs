﻿using System;
using System.Threading;
using System.Linq;

namespace Roshambo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ROSHAMBO");
            Console.WriteLine();
            Console.WriteLine("What is your name?");

            string name = Console.ReadLine();

            User u = new User(name);
            Console.Clear();
            Console.WriteLine($"Alright {name}");
            Console.WriteLine();
            Console.WriteLine("Which oppenent would you like to face in the ring?");
            Console.WriteLine("1) Rocky - the God of rocks I guess");
            Console.WriteLine("OR");
            Console.WriteLine("2) Randy - Dude's a wildcard");
            int num = 0;

            
            // validate input
            bool validInpt = false;
            bool isNum = false;
            while (!validInpt)
            {
                Console.WriteLine("Please input either 1 or 2");
                isNum = int.TryParse(Console.ReadLine(), out num);
                if (isNum == true && (num == 1 || num == 2) )
                {
                    validInpt = true;
                }
            }


            //Choose opponent based on player input
            Player opponent = new Rocky("no");
            if (num == 1)
            {
                opponent = new Rocky("Rocky");

            }
            else if (num == 2)
            {
                Random randy = new Random();
                int num2 = randy.Next(1, 4);
                opponent = new Rando("Randy", randy);
            }
    

            Scoreboard boardScore = new Scoreboard(0, 0, 0, u.GetName() , opponent.GetName()); 


            while (true)
            {
                sBoard(Throw(u, opponent), boardScore);

                if (!Proceed())
                {
                    break;
                }
            }   

        }
        

        public static string sBoard(int result, Scoreboard boardScore)
        {
            if (result == 0)
            {
                boardScore.uScore++;
            }
            else if (result == 1)
            {
                boardScore.oScore++;
            }
            else
            {
                boardScore.draws++;
            }
            return boardScore.ToString();
        }

        public static int Throw(Player user, Player opponent)
        {
            Console.Clear();

            Console.WriteLine("Alright, prepare for battle");
            Console.WriteLine("Rock...");
            Thread.Sleep(1000);
            Console.WriteLine("Paper...");
            Thread.Sleep(1000);
            Console.WriteLine("Scissors...");
            Thread.Sleep(1000);
            Console.WriteLine("SHOOT!");

            // Lock in what player and opponent threw
            string playerThrow = user.ChooseThrow();
            string oppThrow = opponent.ChooseThrow();
            Console.WriteLine($"You chose {playerThrow}");
            Console.WriteLine("Your opponent chose...");
            Thread.Sleep(3000);
            Console.WriteLine(oppThrow.ToUpper());
            Thread.Sleep(4000);

            // Determine who won
            Console.Clear();
            if (WinLoseDraw(playerThrow, oppThrow) == 0)
            {
                Console.WriteLine("You win this round!");
            }
            else if (WinLoseDraw(playerThrow, oppThrow) == 1)
            {
                Console.WriteLine("You lose this round");
            }
            else if (WinLoseDraw(playerThrow, oppThrow) == 2)
            {
                Console.WriteLine("This was a DRAW, everybody loses");
            }

            return WinLoseDraw(playerThrow, oppThrow);

        }

        public static int WinLoseDraw(string player, string opp)  // 0: win, 1: lose, 2: draw
        {
            if (player == "Rock")
            {
                if (opp == "Scissors")
                {
                    return 0;
                }
                else if (opp == "Paper")
                {
                    return 1;
                }
                else if (opp == "Rock")
                {
                    return 2;
                }
                else { return -1; }
            }

            if (player == "Paper")
            {
                if (opp == "Scissors")
                {
                    return 1;
                }
                else if (opp == "Paper")
                {
                    return 2;
                }
                else if (opp == "Rock")
                {
                    return 0;
                }
                else { return -1; }
            }

            if (player == "Scissors")
            {
                if (opp == "Scissors")
                {
                    return 2;
                }
                else if (opp == "Paper")
                {
                    return 0;
                }
                else if (opp == "Rock")
                {
                    return 1;
                }
                else { return -1; }
            }
            return -1;
        }


        public static bool Proceed()
        {
            Console.WriteLine("Play another round? y/n : ");
            string contEnter = Console.ReadLine();

            // Check if they want to continue
            if (contEnter.ToLower() == "y")
            {
                return true;
            }
            else if (contEnter.ToLower() == "n")
            {
                return false;
            }
            else 
            {
                return Proceed();
            }
        }
    }
}
