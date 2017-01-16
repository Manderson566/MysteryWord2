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
                retry = false;
            {

                string[] pulledWordArray = File.ReadAllLines(@"..\..\words.txt");
                List<string> pulledWordList = pulledWordArray.ToList<string>();

                var rng = new Random();
                int randomName = rng.Next(pulledWordList.Count);
                string randomWord = pulledWordList[randomName];

                int counter = 0;
                Console.WriteLine(randomWord);
                foreach (char place in randomWord)
                {
                    Console.Write("_ ");
                    counter++;
                }
                counter = 0;

                int rWordLength = randomWord.Length;
                int turns = rWordLength;
                List<char> usedLetters = new List<char>();
                char[] output = new char[rWordLength];
                bool winCheck = true;
                while (winCheck && turns > 0)
                {

                    string letter = Console.ReadLine();
                    Console.Clear();
                    char input = letter[0];
                    if (usedLetters.Contains(input))
                    {
                        usedLetters.Add(input);
                        Console.WriteLine("You've already used '{0}',", input);
                        continue;
                    }
                    if (randomWord.Contains(input))
                    {
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
                        Console.WriteLine("Wrong", input);
                        turns--;
                    }
                    Console.WriteLine(randomWord);
                    Console.WriteLine(output);
                    Console.WriteLine($"Your Have {turns} Trys Left");

                    foreach (char place in randomWord)
                    {
                        Console.Write("_ ");
                        counter++;
                    }
                    if (winCheck == false)
                    {
                        Console.WriteLine("winner");
                        Console.WriteLine("Play agian Y/N ?");
                        string playAgainCK = Console.ReadLine();
                        if (playAgainCK == "Y")
                        {
                            retry = true;
                        }
                        else if (playAgainCK == "N")
                        {
                            Console.WriteLine("Press Enter to exit");
                            retry = false;
                        }
                    }
                    else if (turns == 0)
                    {
                        Console.WriteLine("Loser");
                        Console.WriteLine("Play agian Y/N ?");
                        string playAgainCK = Console.ReadLine();
                        if (playAgainCK == "Y")
                        {
                            retry = true;
                        }
                        else if (playAgainCK == "N")
                        {
                            Console.WriteLine("Press Enter to exit");
                            retry = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Entery");
                            retry = false;
                        }
                    }
                }

            }




        }
    }
}