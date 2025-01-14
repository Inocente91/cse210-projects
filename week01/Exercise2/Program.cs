using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write( "Enter your grade percentage: ");
        int percentage = int.Parse(Console.ReadLine());

        string letter = "";
        string sign = "";

        //This line will determine the letter for the user grade.

        if (percentage >= 90)
        {
            letterr = "A";
        
        }

        else if (percentage >= 80)
        {
            letter = "B";
        }

        else if (percentage >= 70)

        {
            letter = "C";
        }

        else if (percentage > = 60)
        {
            letter = "D";
        }

        else
        {
            letter ="F";
        }

        // This line of code will determine if the user passed the course or not.

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }

        else
        {
            Console.WriteLine("Unfortunately, you did not pass.");
        }

        // This line of code will add "+" or "-" to the grade user type.

        if (letter != "F") 
        {
            int lastDigit = percentage % 10;
            if (lastDigit > 7)
            {
                sign ="+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            
        }


        // This line of code will handle exceptional cases.

        if (letter == "A" && sign == "+")
        {
            sign = ""; 
        }
        if (letter = "";)
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is: {letter}{sign});


    }

}