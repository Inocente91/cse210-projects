using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write( "Enter your grade percentage: ");
        int percentage = int.Parse(Console.ReadLine());

        string letter = "";
        string sign = "":

        if (percentage >= 90)
        {
            letterr = "A";
        
        }

        elif (percentage >= 80)
        {
            letter = "B"
        }

        elif (percentage >= 70)

        {
            letter = "C";
        }

        elif (percentage > = 60)
        {
            letter = "D";
        }

        else
        {
            letter ="F";
        }

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }

        else
        {
            Console.WriteLine("Unfortunately, you did not pass.")
        }

        if (letter != "F")
        {
            int lastDigit = percentage % 10;
            if (lastDigit > 7)
            {
                sign = "+";
            }
        }

        elif (lastDigit <3)
        {
            sign = "-";
        }


    }
}