using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman_str
{
    public class ProgramOLD
    {
        public static int Main(string[] args)
        {
            Random generator = new Random((int)DateTime.Now.Ticks);
            const int MAX_ALPHABET = 26;
            int winningWordIndex;
            string winningWord;
            const int MAX_GUESSES = 7;
            int correctLetters = 0;
            int correctGuesses = 0;
            int wrongGuesses = 0;
            int allGuesses = 0;
            string strGuess = "";
            bool correctLetter = false;
            string letter = "";

            string[] arrWrongGuesses = new string[MAX_ALPHABET];
            string[] arrAllGuesses = new string[MAX_ALPHABET];
            string[] bodyParts = new string[] { " O\n", "\\", "|", "/\n", " |\n", "/", " \\\n" };
            string[] wordList = new string[] { "aardvark", "apple", "badminton", "banana", "charter", "doctor"
                                , "elephant", "foible", "giraffe", "hippopotamus", "indian", "juice", "kilogram", "lion", "money"
                                , "nantucket", "orange", "pupil", "query", "romance", "", "stone", "towel", "uniform"
                                , "victrola", "whiskey", "xylophone", "zebra"};

            winningWordIndex = generator.Next(wordList.Length);
            winningWord = wordList[winningWordIndex];


            Console.WriteLine("\nHere is the word.  GOOD LUCK !!!\n\n");
            //  display initial dashes for the word
            for (int i = 0; i < winningWord.Length; i++)
            {
                Console.Write("_ ");
            }
            Console.WriteLine("");

            do
            {
                bool duplicateFound;
                do
                {
                    Console.Write("\n\nGuess a letter: ");
                    strGuess = Console.ReadLine();

                    duplicateFound = false;
                    for (int i = 0; i < arrAllGuesses.Length; i++)
                    {
                        if (strGuess.Equals(arrAllGuesses[i]))
                        {
                            duplicateFound = true;
                        }
                    }

                    if (duplicateFound)
                    {
                        Console.WriteLine("You already guessed that letter.  Guess again. ");
                    }
                } while (duplicateFound);
                Console.WriteLine("\n");


                arrAllGuesses[allGuesses] = strGuess;
                allGuesses++;


                // check how many matches the current guess has
                correctLetters = 0;
                string strWordChar;
                for (int i = 0; i < winningWord.Length; i++)
                {
                    strWordChar = winningWord[i].ToString();
                    if (strGuess.Equals(strWordChar))
                    {
                        correctLetters++;
                    }
                }
                // add the latest matches to the "total correct count"
                correctGuesses += correctLetters;


                // guessed wrong
                if (correctLetters == 0)
                {
                    arrWrongGuesses[wrongGuesses] = strGuess;
                    wrongGuesses++;
                }


                //  draw the number of body parts that correspond to
                //  the number of wrong guesses
                for (int i = 0; i < wrongGuesses; i++)
                {
                    Console.Write(bodyParts[i]);
                }
                Console.WriteLine("\n\n");


                // display the mixture of correct guess letters, 
                // and dashes for as-yet unguessed letters
                for (int i = 0; i < winningWord.Length; i++)
                {
                    correctLetter = false;
                    letter = winningWord[i].ToString();
                    for (int j = 0; j < arrAllGuesses.Length; j++)
                    {
                        if (letter.Equals(arrAllGuesses[j]))
                        {
                            correctLetter = true;
                            break;
                        }
                    }

                    if (correctLetter)
                    {
                        Console.Write($"{winningWord[i]} ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine("\n");


                Console.Write("\n\nWrong Guesses:");
                for (int i = 0; i < arrWrongGuesses.Length; i++)
                {
                    Console.Write("  " + arrWrongGuesses[i]);
                }
                Console.WriteLine("\n\n");

            } while (correctGuesses < winningWord.Length
                       &&
                       wrongGuesses < MAX_GUESSES
                       );
            // if they haven't won yet, and haven't lost yet, keep asking for letter guesses


            if (correctGuesses == winningWord.Length)
            {
                Console.WriteLine("\nYOU WON !!!!");
            }
            else
            {
                Console.WriteLine("\nYOU LOST YOU BAD GUESSER !!!!");
            }
            

            // display the chosen word

            for (int i = 0; i < winningWord.Length; i++)
            {
                Console.Write($"{winningWord[i]} ");
            }
            Console.WriteLine("\n");


            Console.ReadLine();
            return 0;
        }
    }
}
