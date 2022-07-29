using System;

namespace P0{
    class MainMenu{
        static void Main(string[] args){
            int n;
            bool test = true;
            eightBall ball = new eightBall();
            RockPaperScissors rps = new RockPaperScissors();
            TicTacToe ttt = new TicTacToe();
            BlackJack bj = new BlackJack();
            while(test){
                Console.WriteLine("What would you like to play!\n(Insert the number of the option.)");
                Console.WriteLine("1: Magic 8 Ball");
                Console.WriteLine("2: Rock Paper Scissors");
                Console.WriteLine("3: Tic Tac Toe");
                Console.WriteLine("4: BlackJack");
                Console.WriteLine("5: Close the application\n");
                string input = Console.ReadLine();
                switch(input){
                    case "1":
                        ball.BallResponse();
                        break;
                    case "2":
                        Console.WriteLine("How many rounds would you like to play?");
                        Console.WriteLine("Just one round (1)");
                        Console.WriteLine("Best 2 out of 3 (2)");
                        Console.WriteLine("Best 3 out of 5 (3)\n");
                        string numRounds = Console.ReadLine();
                        bool isInt = int.TryParse(input,out n);
                        // Console.WriteLine(isInt); ask about why this is always returning true
                        if(isInt){
                            switch(int.Parse(numRounds)){
                                case 1:
                                    rps.playGame(1);
                                    break;
                                case 2:
                                    rps.playGame(2);
                                    break;
                                case 3:
                                    rps.playGame(3);
                                    break;
                                default:
                                    Console.WriteLine("The number you input was not a valid option. Please try again\n");
                                    break;
                            }
                        }
                        else{
                            Console.WriteLine("Sorry the input was not correct please try again.\n");
                        }
                        break;
                    case "3":
                        ttt.playGame();
                        break;
                    case "4":
                        bj.PlayGame();
                        break;
                    case "5":
                        Console.WriteLine("Thank you for playing!");
                        test = false;
                        break;
                    default:
                        Console.WriteLine("Incorrectly formatted input\n");
                        break;
                    }
                }
            }
        }
    }
