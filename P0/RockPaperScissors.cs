using System;

namespace P0{
    class RockPaperScissors{
        private string[] responses = new string[] {"rock", "paper", "scissors"};
        public void playGame(int numWins){
            var random = new Random();
            int computerWins = 0;
            int playerWins = 0;
            bool completion = true;
            while(computerWins < numWins && playerWins <numWins && completion == true){
                var range = random.Next(0,3);
                Console.WriteLine("What would you like to throw (rock, paper, scissors)?");
                string playerMove = Console.ReadLine();
                string computerMove = responses[range];
                switch(playerMove){
                    case "rock":
                        if(computerMove == "rock"){
                            Console.WriteLine("The computer chose rock. Tie!");
                        }
                        else if(computerMove == "paper"){
                            Console.WriteLine("The computer chose paper. Compuer wins!");
                            computerWins += 1;
                        }
                        else if(computerMove == "scissors"){
                            Console.WriteLine("The computer chose scissors. You win!");
                            playerWins += 1;
                        }
                        Console.WriteLine($"Player Score: {playerWins}\nComputer Score:{computerWins}\n");
                        break;
                    case "paper":
                        if(computerMove == "rock"){
                            Console.WriteLine("The computer chose rock. You win!");
                            playerWins += 1;
                        }
                        else if(computerMove == "paper"){
                            Console.WriteLine("The computer chose paper. Tie!");
                        }
                        else if(computerMove == "scissors"){
                            Console.WriteLine("The computer chose scissors. Computer wins!");
                            computerWins += 1;
                        }
                        Console.WriteLine($"Player Score: {playerWins}\nComputer Score:{computerWins}\n");
                        break;
                    case "scissors":
                        if(computerMove == "rock"){
                            Console.WriteLine("The computer chose rock. Computer wins!");
                            computerWins += 1;
                        }
                        else if(computerMove == "paper"){
                            Console.WriteLine("The computer chose paper. You win!");
                            playerWins += 1;
                        }
                        else if(computerMove == "scissors"){
                            Console.WriteLine("The computer chose scissors. Tie!");
                        }
                        Console.WriteLine($"Player Score: {playerWins}\nComputer Score:{computerWins}\n");
                        break;
                    case "exit":
                        Console.WriteLine("Exiting the game.\n");
                        completion = false;
                        break;
                    default:
                        Console.WriteLine("Sorry the input was invalid please try again");
                        break;
                }
            }
            if (computerWins > playerWins && completion == true){
                Console.WriteLine("The computer has won! Better luck next time!");
            }
            else if(playerWins > computerWins && completion == true){
                Console.WriteLine("You have won! Congratulations!");
            }
            Console.WriteLine("Thank you for playing!\n");
        }
    }
}