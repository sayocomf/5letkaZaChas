﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int[] cards = new int[]
            {
                2, 3, 4, 5, 6, 7, 8, 9, 10, // цифры
                10, 10, 10, // картинки
                11, // туз

                2, 3, 4, 5, 6, 7, 8, 9, 10, // цифры
                10, 10, 10, // картинки
                11, // туз

                2, 3, 4, 5, 6, 7, 8, 9, 10, // цифры
                10, 10, 10, // картинки
                11, // туз

                2, 3, 4, 5, 6, 7, 8, 9, 10, // цифры
                10, 10, 10, // картинки
                11, // туз
            };

            cards = Shuffle(cards);

            for (int i = 0; i < cards.Length; i++)
            {
                Console.WriteLine(cards[i]);
            }

            Console.WriteLine();

            cards = Shuffle(cards);
            cards = Shuffle(cards);

            bool IsPlayerContinue = true;
            bool IsComputerContinue = true;

            Random random = new Random();

            do
            {
                IsPlayerContinue = AskPlayer(IsPlayerContinue);

                IsComputerContinue = AskComputer(IsComputerContinue, random);

            } while (IsPlayerContinue || IsComputerContinue);
        }

        private static int[] Shuffle(int[] cards)
        {
            int[] usedIndexes = new int[cards.Length];

            for (int i = 0; i < usedIndexes.Length; i++)
            {
                usedIndexes[i] = -1;
            }

            int[] result = new int[cards.Length];

            Random random = new Random();

            for (int i = 0; i < cards.Length; i++)
            {
                int index = 0;

                do
                {
                    index = random.Next(0, cards.Length);
                } while (Contains(usedIndexes, index));

                result[i] = cards[index];
                usedIndexes[i] = index;
            }

            return result;
        }

        private static bool Contains(int[] values, int value)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool AskComputer(bool IsComputerContinue, Random random)
        {
            int decisionNumber = 0;

            if (IsComputerContinue)
            {
                decisionNumber = random.Next(0, 2);
            }

            if (decisionNumber == 0)
            {
                Console.WriteLine("Компьютер тянет карту");
            }

            if (decisionNumber == 1)
            {
                Console.WriteLine("Компьютер пасует");
                IsComputerContinue = false;
            }

            return IsComputerContinue;
        }

        private static bool AskPlayer(bool IsPlayerContinue)
        {
            Console.WriteLine("Будешь тянуть карту? (y/n)");
            string answer = Console.ReadLine();

            if (answer == "y")
            {
                Console.WriteLine("Вы тянете карту");
            }

            else if (answer == "n")
            {
                Console.WriteLine("Вы пасуете");
                IsPlayerContinue = false;
            }

            return IsPlayerContinue;
        }
    }
}
