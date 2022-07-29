using System;

namespace P0{
    class TicTacToe{
        public void playGame(){
            char Player = 'X';
            char[,] board = new char[3,3];
            Initialize(board);
            bool loop = true;
            int movecount = 0;
            while(loop){
                Console.Clear();
                Print(board);

                Console.WriteLine("Please enter a row: ");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter a column: ");
                int col = Convert.ToInt32(Console.ReadLine());
                if(movecount == 8){
                    Console.WriteLine("Tie!");
                    Console.WriteLine("Would you like to play again?(Y/N)\n");
                    string tieResponse = Console.ReadLine();
                    switch(tieResponse){
                        case ("Y"):
                            Console.WriteLine("Creating a new board!\n");
                            movecount = 0;
                            board = new char[3,3];
                            Player = 'X';
                            break;
                        case ("N"):
                            Console.WriteLine("Thank you for playing!\n");
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("Input was not understood. Exiting the game\n");
                            loop = false;
                            break;
                    }
                    
                }
                else if(board[row,col] != 'X' && board[row,col]!= 'O'){
                    board[row,col] = Player;
                    if((Player == board[0,0] && Player == board[0,1] && Player == board[0,2])
                    || (Player == board[1,0] && Player == board[1,1] && Player == board[1,2])
                    || (Player == board[2,0] && Player == board[2,1] && Player == board[2,2])
                    || (Player == board[0,0] && Player == board[1,0] && Player == board[2,0])
                    || (Player == board[0,1] && Player == board[1,1] && Player == board[2,1])
                    || (Player == board[0,2] && Player == board[1,2] && Player == board[2,2])
                    || (Player == board[0,0] && Player == board[1,1] && Player == board[2,2])
                    || (Player == board[0,2] && Player == board[1,1] && Player == board[2,0])){
                        Print(board);
                        Console.WriteLine(Player + " has won the game!\n");
                        Console.WriteLine("Would you like to play again?(Y/N)\n");
                        string response = Console.ReadLine();
                        switch(response){
                            case ("Y"):
                                Console.WriteLine("Creating a new board!\n");
                                movecount = 0;
                                board = new char[3,3];
                                Player = 'X';
                                break;
                            case ("N"):
                                Console.WriteLine("Thank you for playing!\n");
                                loop = false;
                                break;
                            default:
                                Console.WriteLine("Input was not understood. Exiting the game\n");
                                loop = false;
                                break;
                        }
                    }
                    else{
                        Print(board);
                        Player = ChangeTurn(Player);
                        movecount ++;
                    }
                }
            }
        }

        static void Initialize(char[,] board){
            for(int row = 0; row < 3; row++){
                for(int col = 0; col < 3; col ++){
                    board[row,col] = ' ';
                }
            }
        }
        private void Print(char[,] board){
            Console.WriteLine("    0   1   2 ");
            for(int row = 0; row < 3; row++){
                Console.Write(row + " | ");
                for(int col = 0; col < 3; col ++){
                    Console.Write(board[row,col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }
        private char ChangeTurn(char currentPlayer){
            if(currentPlayer == 'X'){
                return 'O';
            }
            else{
                return 'X';
            }
        }
    }
}