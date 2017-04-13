using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static string[] words;

        static string[] fruit =   {"apple", "pear", "pineapple", "plum", "melon", "peach",
                                  "banana", "lychee", "blueberry", "strawberry", "raspberry", "blackberry",
                                  "grape", "kiwi", "mango", "orange", "watermelon", "lemon", "lime", "grapefruit"};
        static string[] animals = { "lion", "giraffe", "fox", "dog", "cat", "tiger", "bear", "elephant", "orangutan", "gorilla",
                                    "flamingo", "goat", "frog", "duck", "goose", "horse", "hyena"};
        static string[] food =    {"pizza", "hamburger", "sushi", "rice", "goulash", "soup", "noodles", "steak", "fries",
                                    "curry", "gyoza", "cake", "muffin", "cookie", "cheese", "salami", "sausage", "salami"};
        static Random rnd = new Random();
        static string wordToGuess = "";
        static string placeholder = "";
        static List<char> charactersTried = new List<char>();
        static int nrOfTriesLeft = 5;
        static char userInput;
        static char category;

        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to HANGMAN, please select from the below categories: ");
            Console.WriteLine("(F)ruit, (A)nimals or f(O)od");

            chooseCategory();

            while (nrOfTriesLeft > 0)
            {
                Console.WriteLine("************************");
                Console.WriteLine(placeholder);
                Console.WriteLine("\nType a letter:");
                while (!Char.TryParse(Console.ReadLine().ToLower(), out userInput))
                {
                    Console.WriteLine("Type only 1 letter!!");
                }

                checkInput(userInput);
                checkForWinner(placeholder);

            }
            
            Console.WriteLine("\n\nGAME OVER");
            Console.ReadLine();
        }

        static string returnWord()
        {
            int index = rnd.Next(0, words.Length);
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

        static void checkInput(char input)
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
                if (!charactersTried.Contains(input))
                {
                    charactersTried.Add(input);
                }

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

        static void drawHangman()
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

        static void chooseCategory()
        {
            while (!Char.TryParse(Console.ReadLine().ToLower(), out category) && (category != 'f' || category != 'a' || category != 'o'))
            {
                Console.WriteLine("(F)ruit, (A)nimals or f(O)od");
            }

            if (category == 'f')
            {
                Console.WriteLine("\nYou have chosen fruit");
                words = fruit;
            }
            else if (category == 'a')
            {
                Console.WriteLine("\nYou have chosen animals");
                words = animals;
            }
            else if (category == 'o')
            {
                Console.WriteLine("\nYou have chosen food");
                words = food;
            }
            else
            {
                Console.WriteLine("(F)ruit, (A)nimals or f(O)od");
                chooseCategory();
            }

            wordToGuess = returnWord();
            placeholder = drawLetterPlaceholders();
        }
    }
}