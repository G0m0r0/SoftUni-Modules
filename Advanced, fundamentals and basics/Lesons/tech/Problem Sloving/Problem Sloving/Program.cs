using System;

namespace Problem_Sloving
{
    class Program
    {
       static Random rand = new Random();
        //count of 1 and 2 
        static void GenerateRandom()
        {
            for (int i = 0; i < 10; i++)
            {
                int month = rand.Next(1, 52);
                Console.WriteLine(month);
            }
        }
        static void Swap(int index1,int index2,string[] cards)
        {
            string oldCard = cards[index1];
            cards[index1] = cards[index2];
            cards[index2] = oldCard;
        }
        static void PrintCards(string[] str)
        {
            Console.WriteLine(string.Join(" ",str));
        }
        static void Main(string[] args)
        {
            string[] cards = { "AS", "10H", "2C", "KD" };

            PrintCards(cards);

            //Swap(0, 3, cards);
            for (int i = 0; i < cards.Length; i++)
            {
                SingleRandomSwap(cards);
            }

            PrintCards(cards);
            //GenerateRandom();

        }

        private static void SingleRandomSwap(string[] cards)
        {
            int rand1 = rand.Next(0, cards.Length);
            int rand2 = rand.Next(0, cards.Length);
            Swap(rand1, rand2, cards);
        }
    }
}
