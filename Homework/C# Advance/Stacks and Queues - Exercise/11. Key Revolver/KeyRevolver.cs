using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> bulletsStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);

            int moneyForBullets = 0;
            int countBullets = 0;
            while (locksQueue.Count > 0)
            {


                int bullet = bulletsStack.Pop();
                countBullets++;

                moneyForBullets += priceOfBullet;

                int lockk = locksQueue.Peek();

                if (bullet <= lockk)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bulletsStack.Count == 0)
                {
                    if(locksQueue.Count==0)
                    {
                        break;
                    }
                    Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                    return;
                }
                else if (countBullets == sizeOfGunBarrel)
                {
                    Console.WriteLine("Reloading!");
                    countBullets = 0;
                }
            }
            Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${valueOfIntelligence - moneyForBullets}");
        }
    }
}
