using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryWord2
{
    class Program
    {


        static void Main(string[] args)
        {
            bool retry = true;
            while (retry)

            {
                Console.Clear();
                string[] pulledWordArray = File.ReadAllLines(@"..\..\words.txt");
                List<string> pulledWordList = pulledWordArray.ToList<string>();

                var rng = new Random();
                int randomName = rng.Next(pulledWordList.Count);
                string randomWord = pulledWordList[randomName];

                Console.WriteLine("");
                Console.WriteLine("WELCOME TO MYSTERY WORD! GUESS A LETTER!");
                Console.WriteLine("");
                Console.WriteLine("");
                int numLetters = randomWord.Length;
                int letterCount = numLetters;
                int counter = 0;
                int rWordLength = randomWord.Length;
                int turns = rWordLength;
                List<char> usedLetters = new List<char>();
                char[] output = new char[rWordLength];
                bool winCheck = true;
                while (winCheck && turns > 0)
                {
                    
                    string combindOutput = string.Join("|", output.ToArray());
                    Console.WriteLine($"You Have {turns} Incorrect Guesses Left");
                    Console.Write("Correct Guesses =");
                    Console.WriteLine(combindOutput);
                    Console.WriteLine($"The Mystery Word you are looking for has {letterCount} letters and/or characters");

                    string combindUsedletters = string.Join(",", usedLetters.ToArray());
                    Console.WriteLine($"The Letters you have used are ( {combindUsedletters} )");

                    string letter = Console.ReadLine();
                    letter = letter.ToLower();
                    Console.Clear();
                    char input = letter[0];

                    if (usedLetters.Contains(input))
                    {
                        usedLetters.Add(input);
                        Console.WriteLine("");
                        Console.WriteLine("     USED LETTER!");                        
                        Console.WriteLine("");
                        Console.WriteLine("YOU HAVE ALREADY USED {0},", input);
                        continue;
                    }
                    if (randomWord.Contains(input))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("     CORRECT!");
                        Console.WriteLine("");
                        usedLetters.Add(input);
                        for (int countLength = 0; countLength < rWordLength; countLength++)
                        {
                            if (randomWord[countLength] == input)
                            {
                                output[countLength] = randomWord[countLength];
                                counter++;
                            }
                        }
                        string output2 = new string(output);
                        if (output2 == randomWord)
                        {
                            winCheck = false;
                        }
                    }
                    else
                    {
                        usedLetters.Add(input);
                        Console.WriteLine("");
                        Console.WriteLine("     WRONG!", input);
                        Console.WriteLine("");
                        turns--;
                    }
                    //Console.WriteLine(randomWord);
                    Console.WriteLine($"Make Your Guess. You Have {turns} Incorrect guesses left");
            
                    if (winCheck == false)
                    {
                        Console.WriteLine("   You Win!");
                        Console.WriteLine("Type Y To Try Again");
                        string playAgainCK = Console.ReadLine();
                        if (playAgainCK.ToUpper() == "Y")
                        {
                            continue;
                        }
                        else 
                        {
                            Console.WriteLine("Goodbye");
                            continue;
                        }
                    }
                    else if (turns == 0)
                    {
                        Console.WriteLine($"   You Lose! The Word Was ({randomWord}) ");
                        Console.WriteLine("Type (Y) To Play Agian");
                        string playAgainCK = Console.ReadLine();
                        if (playAgainCK.ToUpper() == "Y")
                        {
                            retry = true;
                        }
                        else 
                        {
                            Console.WriteLine("Goodbye");
                            retry = false;
                        }
                    }
                }

            }
        }
    }
}