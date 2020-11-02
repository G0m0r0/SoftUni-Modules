using System;
using System.Numerics;

namespace bigfactoriel
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger nfactoriel = BigInteger.Parse(Console.ReadLine());
            BigInteger bigInt = Bigfactoriel(nfactoriel);
            int count = 0;
            BigInteger countNum = bigInt;
            while(countNum>0)
            {
                count++;
               countNum /= 10;
            }
            Console.WriteLine(bigInt); 
        }

        static BigInteger Bigfactoriel(BigInteger nfactoriel)
        {
           // if (nfactoriel == 0) return 0;
            if (nfactoriel == 1) return 1;
            else
                return Bigfactoriel(nfactoriel - 1) * nfactoriel;
        }
    }
}
