using System;
using System.Collections.Generic;
using System.Linq;

namespace OrmucoQuestionA
{
    class Program
    {
        // this is the main program that lunched the console 
        static void Main(string[] args)
        {
            string firstLineFirstNumber = "";
            string firstLineSecondNumber = "";
            string secondLineFirstNumber = "";
            string secondLineSecondNumber = "";
            Dictionary<string, int> numbersList = new Dictionary<string, int>();


            while (!validateEntry(firstLineFirstNumber))
            {
                Console.WriteLine("Please enter first number for the first Line");
                firstLineFirstNumber = Console.ReadLine();
            }

            while (!validateEntry(firstLineSecondNumber))
            {
                Console.WriteLine("Please enter second number for the first Line");
                firstLineSecondNumber = Console.ReadLine();
            }

            while (!validateEntry(secondLineFirstNumber))
            {
                Console.WriteLine("Please enter first number for the second Line");
                secondLineFirstNumber = Console.ReadLine();
            }

            while (!validateEntry(secondLineSecondNumber))
            {
                Console.WriteLine("Please enter second number for the second Line");
                secondLineSecondNumber = Console.ReadLine();
            }

            fillDictionary();


            //this function is the one that validate the entry of the input numbers 
            bool validateEntry(string entry)
            {
                int number;
                return int.TryParse(entry, out number);
            }

            //this function is the one that fills the Dictionary
            void fillDictionary()
            {
                numbersList.Add("X11", int.Parse(firstLineFirstNumber));
                numbersList.Add("X12", int.Parse(firstLineSecondNumber));
                numbersList.Add("X21", int.Parse(secondLineFirstNumber));
                numbersList.Add("X22", int.Parse(secondLineSecondNumber));

                var sortedDict = numbersList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                if(doesOverlap(sortedDict))
                {
                    Console.WriteLine("the two line don't overlap");
                }
                else
                {
                    Console.WriteLine("the two line overlap");
                }
            }

            //this function does see if two input strings overlap
            bool doesOverlap(Dictionary<string, int> sortedNumbers)
            {
                if ((sortedNumbers.ElementAt(0).Key == "X11" && sortedNumbers.ElementAt(1).Key == "X12") || (sortedNumbers.ElementAt(0).Key == "X12" && sortedNumbers.ElementAt(1).Key == "X11"))
                {
                    return true;
                }
                else if ((sortedNumbers.ElementAt(0).Key == "X21" && sortedNumbers.ElementAt(1).Key == "X22") || (sortedNumbers.ElementAt(0).Key == "X22" && sortedNumbers.ElementAt(1).Key == "X21"))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
