using System;

namespace P0{
    class eightBall{
        private string[] responses = new string[] {"Yes!", "No.", "Definitely!", "Not even a chance.", "You may rely on it", "Maybe", "Don't count on it.", "I'm not so sure..." };
        public void BallResponse(){
            bool loop = true;
            while(loop){
                Console.WriteLine("Ask the magic 8 ball a question!");
                Console.WriteLine("Type exit to leave early\n");
                string response = Console.ReadLine();
                if(response == "exit"){
                    Console.WriteLine("Goodbye!\n");
                    loop = false;
                }
                else{
                    var random = new Random();
                    var range = random.Next(0,8);
                    Console.WriteLine(responses[range]);
                    Console.WriteLine("Thanks for asking!\n");
                    Console.WriteLine("Would you like to ask another question? (yes or no)");
                    string continuation = Console.ReadLine();
                    switch(continuation){
                        case "yes":
                            Console.WriteLine();
                            break;
                        case "no":
                            Console.WriteLine("Okay. Thanks for playing!\n");
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("Sorry input not recognized. Please ask another question or exit");
                            break;
                    }
                }
            }
        }
    }
}