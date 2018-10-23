using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Secret code contains all functions needed for creating our code and checking if the users guess is correct
namespace Mastermind
{
    class SecretCode
    {
        private readonly int[] Code = new int[4];

        public SecretCode() //constructor creates new randomized code
        {
            CreateCode();
        }

        public List<char> CheckCode(int[] Guess) //cycle through the two lists, zeroing out any matches found
        {
            List<char> DecriptionFeedback = new List<char>();
            int[] TempCode = new int[4];
            Code.CopyTo(TempCode, 0);
            for (int i = 0; i < Code.Length; i++) //first loop to check for exact matches
            {
                if (Guess[i] == Code[i])
                {
                    DecriptionFeedback.Insert(0, '+');
                    Guess[i] = 0;
                    TempCode[i] = 0;
                }
            }
            for (int i = 0; i < Code.Length; i++) //second loop to check for correct digits out of place
            {
                if (TempCode.Contains(Guess[i]) & Guess[i] != 0)
                {
                    DecriptionFeedback.Add('-');
                    TempCode[Array.IndexOf(TempCode, Guess[i])] = 0;
                    Guess[i] = 0;
                }
            }
            return DecriptionFeedback;
        }

        public void CreateCode()
        {
            Random rnd = new Random();
            Code[0] = rnd.Next(1, 6);
            Code[1] = rnd.Next(1, 6);
            Code[2] = rnd.Next(1, 6);
            Code[3] = rnd.Next(1, 6);
        }

        public int[] GetCode()
        {
            return Code;
        }
    }
}
