using System;
using System.Diagnostics;

namespace program
{
    class Program
    {
        static int roll1;
        static int roll2;
        static int totalScore1=0;
        static int totalScore2=0;
        static string player1Name;
        static string player2Name;
        static void Main(string[]args)
        {
            
            Console.Write("Du u want play vs AI (1) or vs second player(2)? ");
            int ai_or_2 = Convert.ToInt32(Console.ReadLine());

            

            switch (ai_or_2) //switch choice 
            {
                case 1: //AI game
                Console.Write("Input a number of rounds: ");
                int max_rounds_ai = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < max_rounds_ai; i++)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.ForegroundColor=ConsoleColor.DarkYellow;
                    Console.WriteLine("it's round "+(i+1));
                    Console.WriteLine();
                    Console.ResetColor();
                    roll1 = Player_vs_ai();
                    Empty_line();
                    roll2 = Ai_vs_player();
                    Empty_line();
                    UpdateScores();
                    Result_after_round_ai();
                }


                    if (totalScore1>totalScore2)
                    {
                        Console.ForegroundColor=ConsoleColor.DarkBlue;
                        Console.WriteLine("you won the game, gratz");
                    }
                    else if (totalScore1<totalScore2)
                    {
                        Console.ForegroundColor=ConsoleColor.DarkGreen;
                        Console.WriteLine("ai won the game :(");
                    }
                    else
                    {
                        Console.WriteLine("its draw");

                    }
                    Console.ReadKey();
                    break;
                  




                case 2: // 1V1 GAME
                var playerNames = Names();
                player1Name = playerNames.Item1;
                player2Name = playerNames.Item2;

                
                Console.Write("Input a number of rounds: ");
                Console.ForegroundColor=ConsoleColor.DarkYellow;
                int max_rounds = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();

                for (int i = 0; i < max_rounds; i++)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.ForegroundColor=ConsoleColor.DarkYellow;
                    Console.WriteLine("it's round "+(i+1));
                    Console.WriteLine();
                    Console.ResetColor();
                    roll1 = Player1();
                    Empty_line();
                    roll2 = Player2();
                    Empty_line();
                    UpdateScores();
                    Result_after_round();
                
                }
                Console.WriteLine("-----------------------------------");
                if (totalScore1>totalScore2)
                {
                    Console.ForegroundColor=ConsoleColor.DarkBlue;
                    Console.WriteLine(player1Name+" won the game, gratz");
                }
                else if (totalScore1<totalScore2)
                {
                    Console.ForegroundColor=ConsoleColor.DarkGreen;
                    Console.WriteLine(player2Name+" won the game, gratz");
                }
                else
                {
                    Console.WriteLine("its draw");

                }


                Console.ReadKey();//input
        
                break;

                default:
                    Console.WriteLine("You have to choice between 1 or 2 only!");
                    
                    Main(args);
                    break;
            }
        }
        static int NumberGen()
        {
            Random r = new Random();
            int rolled = r.Next(1, 6+1);
            
            return rolled ;
        }
        static void Empty_line()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
        }
        
        static int Player1()
        {
            Console.ForegroundColor=ConsoleColor.DarkBlue;
            Console.WriteLine("press enter key to roll, "+player1Name+" is rolling:");
            Console.ReadKey();
            int roll1 = NumberGen();
            
            Console.Write(player1Name+" rolled: "+ roll1);
            Console.ResetColor();
            return roll1;
        }
        static int Player2()
        {
            Console.ForegroundColor=ConsoleColor.DarkGreen;
            Console.WriteLine("press enter key to roll, "+player2Name+" is rolling:");
            Console.ReadKey();
            int roll2 = NumberGen();
            Console.Write(player2Name+" rolled: "+ roll2);
            Console.ResetColor();
            return roll2;
    
        }
        static void Result_after_round()
        {           
            Console.WriteLine("The score is now: ");
            Console.ForegroundColor=ConsoleColor.DarkBlue;
            Console.WriteLine(player1Name+" "+totalScore1);
            Console.ForegroundColor=ConsoleColor.DarkGreen;
            Console.WriteLine(player2Name+" "+totalScore2);
            Console.ResetColor();
        }

        static void UpdateScores()
        {
            totalScore1 += roll1;
            totalScore2 += roll2;
        }
        
        static (string, string) Names()
        {
            Console.Write("Input name of player 1: ");
            Console.ForegroundColor=ConsoleColor.DarkBlue;
            string name1 = (Console.ReadLine());
            Console.ResetColor();
            Console.Write("Input name of player 2: ");
            Console.ForegroundColor=ConsoleColor.DarkGreen;
            string name2 = (Console.ReadLine());
            Console.ResetColor();
            return (name1,name2);
        }

        static int Player_vs_ai()
        {
            Console.ForegroundColor=ConsoleColor.DarkBlue;
            Console.WriteLine("press enter key to roll, you are rolling:");
            Console.ReadKey();
            int roll1 = NumberGen();
            Console.Write("you rolled: "+ roll1);
            Console.ResetColor();
            return roll1;
        }

        static int Ai_vs_player()
        {
            Console.ForegroundColor=ConsoleColor.DarkGreen;
            Console.WriteLine("press enter key to roll, ai is rolling:");
            Console.ReadKey();
            int roll2 = NumberGen();
            
            Console.Write("ai rolled: "+ roll2);
            Console.ResetColor();
            return roll2;
        }

        static void Result_after_round_ai()
        {           
            Console.WriteLine("The score is now: ");
            Console.ForegroundColor=ConsoleColor.DarkBlue;
            Console.WriteLine("your score: "+totalScore1);
            Console.ForegroundColor=ConsoleColor.DarkGreen;
            Console.WriteLine("ai score: "+totalScore2);
            Console.ResetColor();
        }

    }
}