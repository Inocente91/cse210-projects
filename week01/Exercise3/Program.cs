using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes"; 

        while (playAgain.ToLower() == "yes")
        {
            
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1; 
            int attempts = 0; 

            Console.WriteLine("Guess the magic number between 1 and 100!");

            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempts++; 

                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine($"You guessed it! It took you {attempts} guesses.");
                }
            }

            
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thanks for playing! Goodbye!");
    }
}
