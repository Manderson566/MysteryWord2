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
            int turns = randomName;
            int rWordLength = randomWord.Length;
            List<char> usedLetters = new List<char>();
            char[] output = new char[rWordLength];
            bool winCheck = false;
            while (!winCheck && turns > 0)
            {
               
                    string letter = Console.ReadLine();
                    char input = letter[0];
                    if (usedLetters.Contains(input))
                    {
                        usedLetters.Add(input);
                        Console.WriteLine("You've already tried '{0}',", input);
                        continue;
                    }
                if (randomWord.Contains(input))
                {
                    usedLetters.Add(input);

                    for (int i = 0; i < rWordLength; i++)
                    {
                        if (randomWord[i] == input)
                        {
                            output[i] = randomWord[i];
                            counter++;

                        }
                    }
                    if (counter == rWordLength)
                        winCheck = true;

                }
                else
                {
                    usedLetters.Add(input);
                    Console.WriteLine("Wrong", input);
                    turns--;
                }
                Console.WriteLine(output);

                

            }
            if (winCheck)
            {
                Console.WriteLine("winner");
            }
            else
            {
                Console.WriteLine("Loser");
                Console.Write("enter to exit");
                Console.ReadLine();
            }

        }
    }
}