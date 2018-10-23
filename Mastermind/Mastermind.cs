using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Mastermind implementation by Kyle Brezovec for Quadax
namespace Mastermind
{
    class Mastermind
    {
        static void Main(string[] args)
        {
            Boolean Playing = true;
            Console.WriteLine("Welcome to mastermind. Can you guess the secret code?");
            while(Playing)
            {
                Playing = Game();
            }
        }

        static Boolean Game() //Main game function. We will stay here until the user exits
        {
            SecretCode Code = new SecretCode();
            int RoundCounter = 10; //number of rounds determinded by requirements
            do
            {
                Console.WriteLine(RoundCounter + " guesses remaining. Please enter your guess, a four digit code using integers 1-6");
                String Input = Console.ReadLine();
                int[] InputArray = ValidateAndConvertInput(ref Input);
                List<char> Feedback = Code.CheckCode(InputArray);
                Console.WriteLine("Your feedback:" );
                Feedback.ForEach(Console.WriteLine);
                if (IsVictorious(Feedback))
                {
                    break; //winner!
                }
                RoundCounter--;
            } while (RoundCounter > 0);
            if(RoundCounter == 0) //determine if we left the loop via win condition or from running out of tries
            {
                Console.WriteLine("You failed to guess the secrect code in 10 tunes. The code was " + String.Join("", new List<int>(Code.GetCode()).ConvertAll(i => i.ToString()).ToArray()));
                return EndGame();
            }
            else
            {
                Console.WriteLine("Congratulations! You cracked the code " + String.Join("", new List<int>(Code.GetCode()).ConvertAll(i => i.ToString()).ToArray()));
                return EndGame();
            }
        }

        static int[] ValidateAndConvertInput(ref string Input) //all validation for the users guess
        {
            while (true)
            {
                if (int.TryParse(Input, out int n) & (n >= 1111 & n <= 6666) & !Input.Contains("0"))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter your guess, a four digit code using integers 1-6");
                Input = Console.ReadLine();
            }
            char[] InputChar = Input.ToCharArray();
            int[] InputInt = InputChar.Select(a => a - '0').ToArray();
            return InputInt;
        }

        static Boolean EndGame() //return the users desire to play another round after validation
        {
            Console.WriteLine("Play Again? [Y/N]");
            string PlayAgain = Console.ReadLine();
            while (true)
            {
                if (string.Equals(PlayAgain, "Y", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if(string.Equals(PlayAgain, "N", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                Console.WriteLine("Invalid input. Play again? [Y/N]");
                PlayAgain = Console.ReadLine();
            }
        }

        static Boolean IsVictorious(List<char> Input)
        {
            List<char> VictoryList = new List<char>(new char[] { '+', '+', '+', '+' });
            if (Input.SequenceEqual(VictoryList))
            {
                return true;
            }
            return false;
        }
    }
}
