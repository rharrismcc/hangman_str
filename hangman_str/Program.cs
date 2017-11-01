using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman_str
{
    public class Program
    {
        public static void DrawBodyParts(string[] bodyParts, int index)
        {
            for (int i=0; i<index; i++)
            {
                Console.Write(bodyParts[i]);
            }
            Console.WriteLine("\n\n");
        }

        public static void DisplayWrongGuesses(string[] guesses, int count)
        {
            Console.Write("\n\nWrong Guesses:");
            for (int i = 0; i < count; i++)
            {
                Console.Write("  " + guesses[i]);
            }
            Console.WriteLine("\n\n");
        }

        public static void DrawWordDashes(string word, string[] allGuesses, bool displayLetters)
        {
            bool correctLetter = false;
            string letter;
            int length = word.Length;
            for (int i = 0; i < length; i++)
            {
                correctLetter = false;
                letter = word[i].ToString();
                for (int j = 0; j < allGuesses.Length; j++)
                {
                    if (letter.Equals(allGuesses[j]))
                    {
                        correctLetter = true;
                        break;
                    }
                }
                if (correctLetter)
                {
                    Console.Write($"{word[i]} ");
                }
                else
                {
                    if (displayLetters)
                    {
                        Console.Write($"{word[i]} ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
            }
            Console.WriteLine("\n");
        }

        public static bool CheckAlreadyGuessed(string[] allGuesses, string guess)
        {
            bool duplicateFound = false;
            for (int i = 0; i < allGuesses.Length; i++)
            {
                if (guess.Equals(allGuesses[i]))
                {
                    duplicateFound = true;
                }
            }
            return duplicateFound;
        }
        
        public static string GetCurrentGuess(string[] allGuesses)
        {
            string strGuess;
            bool duplicateFound;
            do
            {
                Console.Write("\n\nGuess a letter: ");
                strGuess = Console.ReadLine();

                duplicateFound = CheckAlreadyGuessed(allGuesses, strGuess);

                if (duplicateFound)
                {
                    Console.WriteLine("You already guessed that letter.  Guess again. ");
                }
            } while (duplicateFound);
            Console.WriteLine("\n");
            return strGuess;
        }

        public static int CheckCurrentGuess(string winningWord, string guess)
        {
            int correctLetters = 0;
            string strWordChar;
            for (int i = 0; i < winningWord.Length; i++)
            {
                strWordChar = winningWord[i].ToString();
                if (guess.Equals(strWordChar))
                {
                    correctLetters++;
                }
            }
            return correctLetters;
        }

        public static int MainZZZ(string[] args)
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
            string strGuess;

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
            DrawWordDashes(winningWord, arrAllGuesses, false);

            do
            {
                strGuess = GetCurrentGuess(arrAllGuesses);
                arrAllGuesses[allGuesses] = strGuess;
                allGuesses++;

                correctLetters = CheckCurrentGuess(winningWord, strGuess);
                correctGuesses += correctLetters;

                // guessed wrong
                if (correctLetters == 0)
                {
                    arrWrongGuesses[wrongGuesses] = strGuess;
                    wrongGuesses++;
                }

                DrawBodyParts(bodyParts, wrongGuesses);
                DrawWordDashes(winningWord, arrAllGuesses, false);
                DisplayWrongGuesses(arrWrongGuesses, wrongGuesses);
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

            DrawWordDashes(winningWord, arrAllGuesses, true);
            
            Console.ReadLine();
            return 0;
        }
    }
}
