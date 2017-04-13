using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static string[] words = { "apple", "pear", "pineapple", "plum", "melon", "peach",
                                  "banana", "lychee", "blueberry", "strawberry", "raspberry", "blackberry",
                                  "grape", "kiwi", "mango", "orange", "watermelon", "lemon", "lime", "grapefruit"};
        static Random rnd = new Random();
        static string wordToGuess = returnWord();
        static string placeholder = drawLetterPlaceholders();
        static List<char> charactersTried = new List<char>();
        static int nrOfTriesLeft = 5;
        static char userInput;

        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to HANGMAN, you will have to guess a fruit! Let's start..");

            while (nrOfTriesLeft > 0)
            {
                Console.WriteLine("************************");  
                Console.WriteLine(placeholder);
                Console.WriteLine("Type a letter:");
                while (!Char.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Type only 1 letter!!");
                }

                checkInput(userInput);
                checkForWinner(placeholder);

            }

            Console.WriteLine("\n\nGAME OVER");
            Console.ReadLine();
        }

        static string returnWord ()
        {
            int index = rnd.Next(0, words.Length + 1);
            return words[index];
        }

        static string drawLetterPlaceholders()
        {
            string ph = "";
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                ph += "_ ";
            }
            return ph;
        }

        static void checkInput (char input)
        {
          
           
            StringBuilder builder = new StringBuilder(placeholder);
           
            builder.Replace(" ", "");
           
            bool match = false;

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (input == wordToGuess[i])
                {
                    builder[i] = input;                  
                    match = true;
                }
            }

            if (!match)
            {
                charactersTried.Add(input);
                nrOfTriesLeft--;
                Console.WriteLine("\t\t\t\tNo match, you have {0} more tries..\n", nrOfTriesLeft);
                Console.WriteLine("\t\t\t\tThese are the letters you have already tried \n\t\t\t\tand was no match: ");
                string y = "";

                foreach (var letter in charactersTried)
                {
                    y += letter + " ";
                }

                Console.WriteLine("\t\t\t\t" + y);

                drawHangman();
            }

            string x = "";

            for (int i = 0; i < builder.Length; i++)
            {
                x += builder[i] + " ";
            }

            placeholder = x;

            
        }

        static void checkForWinner(string placeholder)
        {
            if (placeholder.IndexOf('_') == -1)
            {
                Console.WriteLine("\nWell done, the word was: {0}", wordToGuess);
                Console.WriteLine("\nYOU HAVE WON!");
                nrOfTriesLeft = -1;
            }
      
        }

        static void drawHangman ()
        {
            if (nrOfTriesLeft == 4)
            {
                Console.WriteLine(" \t\t\t\t__________");
                Console.WriteLine(" \t\t\t\t||//	  ");
                Console.WriteLine(" \t\t\t\t||/	  ");
                Console.WriteLine(" \t\t\t\t||	  ");
                Console.WriteLine(" \t\t\t\t||	  ");
                Console.WriteLine(" \t\t\t\t||	  ");
                Console.WriteLine(" \t\t\t\t||	  ");
                Console.WriteLine(" \t\t\t\t||	  ");
            }

            else if (nrOfTriesLeft == 3)
            {
                Console.WriteLine("\t\t\t\t __________");
                Console.WriteLine("\t\t\t\t||//	  |");
                Console.WriteLine("\t\t\t\t||/	  |");
                Console.WriteLine("\t\t\t\t||	  0");
                Console.WriteLine("\t\t\t\t||      ");
                Console.WriteLine("\t\t\t\t||      ");
                Console.WriteLine("\t\t\t\t||      ");
                Console.WriteLine("\t\t\t\t||      ");
            }

            else if (nrOfTriesLeft == 2)
            {
                Console.WriteLine("\t\t\t\t __________");
                Console.WriteLine("\t\t\t\t||//	  |");
                Console.WriteLine("\t\t\t\t||/	  |");
                Console.WriteLine("\t\t\t\t||	  0");
                Console.WriteLine("\t\t\t\t||       / \\");
                Console.WriteLine("\t\t\t\t||      ");
                Console.WriteLine("\t\t\t\t||      ");
                Console.WriteLine("\t\t\t\t||      ");
            }

            else if (nrOfTriesLeft == 1)
            {
                Console.WriteLine("\t\t\t\t __________");
                Console.WriteLine("\t\t\t\t||//	  |");
                Console.WriteLine("\t\t\t\t||/	  |");
                Console.WriteLine("\t\t\t\t||	  0");
                Console.WriteLine("\t\t\t\t||       /|\\");
                Console.WriteLine("\t\t\t\t||	  |");
                Console.WriteLine("\t\t\t\t||      ");
                Console.WriteLine("\t\t\t\t||      ");
            }
            else if (nrOfTriesLeft == 0)
            {
                Console.WriteLine("\t\t\t\t __________");
                Console.WriteLine("\t\t\t\t||//	  |");
                Console.WriteLine("\t\t\t\t||/	  |");
                Console.WriteLine("\t\t\t\t||	  0");
                Console.WriteLine("\t\t\t\t||       /|\\");
                Console.WriteLine("\t\t\t\t||	  |");
                Console.WriteLine("\t\t\t\t||       / \\  ");
                Console.WriteLine("\t\t\t\t||      ");
            }
        }


    }
}
