using System;

namespace P0{
    class BlackJack{
        private string[] deck = new string[] {"2","3","4","5","6","7","8","9","10","Jack","Queen","King","Ace"};
        public void PlayGame(){
            var random = new Random();

            Console.WriteLine("Rules:");
            Console.WriteLine("Minimum bet will be $5");
            Console.WriteLine("Dealer will hit on soft 17");
            Console.WriteLine("BlackJack will payout 3:2");
            Console.WriteLine("You are able to hit or stand");
            Console.WriteLine("How much would you like to put in your balance?\n");

            string response = Console.ReadLine();
            List<string> playerCards = new List<string>();
            List<string> dealerCards = new List<string>();

            double balance = double.Parse(response);
            bool playLoop = true;
            bool isValidBet = true;
            bool playerBlackJack = false; // will be used to help determine payout
            bool dealerBlackJack = false;
            int bet = 0;

            int playerHandValue = 0;
            int alternatePlayerValue = 0;
            int dealerHandValue = 0;
            int alternateDealerValue = 0;
            string initialDealerCard = "";
            while(playLoop){
                Console.WriteLine("Player balance: " + balance.ToString() + "\n");
                while(isValidBet){
                    Console.WriteLine("Would you like to make a bet? (Y/N)");
                    string better = Console.ReadLine();
                    switch(better){
                        case "Y":
                            break;
                        case "N":
                            playLoop = false;
                            isValidBet = false;
                            Console.WriteLine("Thanks for playing!\n");
                            break;
                        default:
                            Console.WriteLine("input not understood. Place your bet.");
                            break;
                    }
                    if(isValidBet == false){
                        break;
                    }
                    Console.WriteLine("Please place your bet!\n");
                    bet = int.Parse(Console.ReadLine());
                    if(bet < 5){
                        Console.WriteLine("Bet must be greater than $5\n");
                    }
                    else if(bet > balance && balance > 5){
                        Console.WriteLine("Balance not large enough for bet size. Deposit more money? (Y/N)");
                        string reDeposit = Console.ReadLine();
                        switch(reDeposit){
                            case "Y":
                                Console.WriteLine("How much would you like to deposit?(Whole numbers only)\n");
                                int depositAmount = int.Parse(Console.ReadLine());
                                balance += depositAmount;
                                break;
                            case "N":
                                Console.WriteLine("Please choose a smaller bet size\n");
                                break;
                            default:
                                Console.WriteLine("Response not understood. Please re-enter your bet\n");
                                break;
                        }
                    }
                    else if(balance < 5){
                        Console.WriteLine("Balance not large enough for min bet. Please deposit more funds to keep playing");
                        Console.WriteLine("Redeposit? (Y/N)");
                        string emptyBalance = Console.ReadLine();
                        switch(emptyBalance){
                            case "Y":
                                Console.WriteLine("How much would you like to deposit?(Whole numbers only)\n");
                                int depositAmount = int.Parse(Console.ReadLine());
                                balance += depositAmount;
                                break;
                            case "N":
                                Console.WriteLine("Dispensing balance: " + balance.ToString());
                                Console.WriteLine("Thanks for playing!\n");
                                isValidBet = false;
                                playLoop = false;
                                break;
                            default:
                                Console.WriteLine("input not recognized. Dispensing balance: " + balance.ToString() + " Thank you for playing.");
                                break;
                        }
                    }
                    else{
                        isValidBet = false;
                        balance -= bet;
                        Console.WriteLine("Time to deal. Good luck!");
                    }
                }
                if(playLoop == false){
                    break;
                }
                isValidBet = true;
                for(int i = 0; i < 4; i++){
                    var card = random.Next(0,13);
                    if(i % 2 == 0){
                        if(alternatePlayerValue != 0 && CardValue(deck[card]) != 11){
                            alternatePlayerValue += CardValue(deck[card]);
                        }
                        else if(CardValue(deck[card]) == 11){
                            alternatePlayerValue += 1;
                            alternatePlayerValue += playerHandValue;
                        }
                        playerHandValue += CardValue(deck[card]);
                        playerCards.Add(deck[card]);
                    }
                    else{
                        if(i == 1){
                            initialDealerCard = deck[card];
                            Console.WriteLine("Dealer is showing: " + deck[card]);
                        }
                        if(alternateDealerValue != 0 && CardValue(deck[card]) != 11){
                            alternateDealerValue += CardValue(deck[card]);
                        }
                        else if(CardValue(deck[card]) == 11){
                            alternateDealerValue += 1;
                            alternateDealerValue += dealerHandValue;
                        }
                        dealerHandValue += CardValue(deck[card]);
                        dealerCards.Add(deck[card]);
                    }
                }
                if(playerHandValue == 21){
                    Console.WriteLine("Player has blackjack!");
                    playerBlackJack = true;
                }                
                if(dealerHandValue == 21){
                    dealerBlackJack = true;
                }
                playerHandValue = PlayerHit(playerHandValue, alternatePlayerValue, playerCards, initialDealerCard, random);
                dealerHandValue = DealerHit(dealerHandValue, alternateDealerValue, playerHandValue, dealerCards, random);
                if(playerHandValue <= 21){
                    if(dealerHandValue > 21){
                        if(playerBlackJack == true){
                            Console.WriteLine("You win!\n");
                            balance += (2.5 * bet);
                        }
                        else{
                            Console.WriteLine("You win!\n");
                            balance += (2* bet);
                        }
                    }
                    else if(dealerHandValue == 21){
                        if(dealerHandValue > playerHandValue){
                            Console.WriteLine("You lose.\n");
                        }
                        else if(dealerHandValue == playerHandValue){
                            if(dealerBlackJack == false && playerBlackJack == true){
                                Console.WriteLine("You win!\n");
                                balance += (2.5 * bet);
                            }
                            else if(dealerBlackJack == true && playerBlackJack == false){
                                Console.WriteLine("You lose.\n");
                            }
                            else{
                                Console.WriteLine("You push.\n");
                                balance += bet;
                            }
                        }
                    }
                    else if(dealerHandValue < 21){
                        if(dealerHandValue < playerHandValue){
                            Console.WriteLine("You win!\n");
                            if(playerBlackJack == true){
                                balance += (2.5 * bet);
                            }
                            else{
                                balance += (2* bet);
                            }
                        }
                        else if(dealerHandValue > playerHandValue){
                            Console.WriteLine("You lose.\n");
                        }
                        else if(dealerHandValue == playerHandValue){
                                Console.WriteLine("You push.\n");
                                balance += bet;
                        }
                    }

                }
                playerHandValue = 0;
                dealerHandValue = 0;
                alternateDealerValue = 0;
                alternatePlayerValue = 0;
                playerCards = new List<string>();
                dealerCards = new List<string>();
                
            }

        }
        private int PlayerHit(int playerHandValue, int alternateValue, List<string> playerCards, string dealerShowing, Random random){
            bool hitLoop = true;
            while(hitLoop){
                Console.Clear();
                Console.WriteLine("Dealer is showing: " + dealerShowing + "\n");
                Console.WriteLine("Player current hand: ");
                foreach(string s in playerCards){
                    Console.Write(s + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Player hand value: " + playerHandValue.ToString() + "\n");
                if(playerHandValue == 21){
                    break;
                }
                Console.WriteLine("Would you like to hit or stand? (H/S)");
                string response = Console.ReadLine();
                var card = random.Next(0,13);
                switch(response){
                    case "H":
                        playerCards.Add(deck[card]);
                        playerHandValue += CardValue(deck[card]);
                        if(playerHandValue > 21){
                            if(alternateValue != 0 || CardValue(deck[card]) == 11){
                                if(CardValue(deck[card]) == 11){
                                    alternateValue += 1;
                                }
                                else{
                                    alternateValue += CardValue(deck[card]);
                                }
                                playerHandValue = alternateValue;
                                alternateValue = 0;
                            }
                            else{
                                Console.WriteLine("You bust. Better luck next time\n");
                                Console.WriteLine("Player hand: ");
                                foreach(string s in playerCards){
                                    Console.Write(s + " ");
                                }
                                Console.WriteLine();
                                hitLoop = false;
                            }
                        }
                        break;
                    case "S":
                        hitLoop = false;
                        break;
                    default:
                        Console.WriteLine("Input not understood, please hit or stand. (H/S)");
                        break;
                        
                }
            }
            return(playerHandValue);
        }
        private int DealerHit(int dealerHandValue, int dealerAlternateValue, int playerHandValue, List<string> dealerCards, Random random){
            bool hitLoop = true;
            if(playerHandValue > 21){
                return dealerHandValue;
            }
            while(hitLoop){
                Console.WriteLine("Dealer current hand: ");
                foreach(string s in dealerCards){
                    Console.Write(s + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Dealer hand value: " + dealerHandValue.ToString() + "\n");
                if(dealerHandValue < 17 || (dealerHandValue == 17 && dealerAlternateValue != 0)){
                    var card = random.Next(0,13);
                    dealerCards.Add(deck[card]);
                    dealerHandValue += CardValue(deck[card]);
                    if(dealerHandValue > 21){
                        if(dealerAlternateValue == 0){
                            Console.WriteLine("Dealer busts!");
                            Console.WriteLine("Dealer current hand: ");
                            foreach(string s in dealerCards){
                                Console.Write(s + " ");
                            }
                            Console.WriteLine();
                            hitLoop = false;
                        }
                        else if(dealerAlternateValue != 0){
                            dealerAlternateValue += CardValue(deck[card]);
                            dealerHandValue = dealerAlternateValue;
                            dealerAlternateValue = 0;
                        }
                    }
                }
                else{
                    hitLoop = false;
                }
            }
            return(dealerHandValue);
        }
        private int CardValue(string card){
            if(card == "10" || card == "Jack" || card == "King" || card == "Queen"){
                return 10;
            }
            else if(card == "Ace"){
                return 11;
            }
            else{
                return int.Parse(card);
            }
        }
    }
}