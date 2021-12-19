using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksHWConsole
{
    public class PrimeNumberFinder
    {
        static private List<int> primeNumbers;
        private List<int> userPrimeNumbers;
        public List<int> UserPrimeNumbers { get => userPrimeNumbers; }
        private int userIndex;

        static PrimeNumberFinder()
        {
            primeNumbers = new List<int>();
            FillPrime(Int16.MaxValue);
        }

        public PrimeNumberFinder()
        {
            userPrimeNumbers = new List<int>();
        }

        static private void FillPrime(int finish)
        {
            for (int i = 2; i < finish; i++)
            {
                bool isPrime = true;
                for (int j = 0; j < primeNumbers.Count; j++)
                {
                    if (i % primeNumbers[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeNumbers.Add(i);
                }
            }
        }

        public void FindPrime(int start, int finish)
        {
            userPrimeNumbers.Clear();
            userPrimeNumbers.AddRange(primeNumbers.FindAll(x => x >= start && x < finish));
            userIndex = 0;
        }

        public static List<int> NumbersBetween(int start, int end)
        {
            return primeNumbers.FindAll(x => x >= start && x < end);
        }

        public int? NextPrime()
        {
            if (userIndex >= userPrimeNumbers.Count)
            {
                return null;
            }

            return userPrimeNumbers[userIndex++];
        }
    }
}
