using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Problems
    {
        public static int Problem1()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                    sum += i;
            }
            return sum;
        }


        static public int Problem2()
        {
            int first = 1;
            int second = 2;
            int sum = 2;
            bool stop = false;
            while (!stop)
            {
                int newElem = first + second;
                first = second;
                second = newElem;
                if (newElem <= 4000000)
                {
                    if (newElem % 2 == 0)
                        sum += newElem;
                }
                else
                    stop = true;
            }
            return sum;
        }

        static public BigInteger Problem3()
        {
            BigInteger EXCERCISENUMBER = 600851475143;
            BigInteger result = 2;
            BigInteger numberBig = EXCERCISENUMBER;
            BigInteger numberSmall = 2;

            while (numberBig > 1)
            {
                if (numberBig % numberSmall == 0)
                {
                    result = numberSmall;
                    do
                    {
                        numberBig = numberBig / numberSmall;
                    } while (numberBig % numberSmall == 0);
                }
                numberSmall++;
            }
            return result;
        }

        private static bool IsPalindrome(int aNumber)
        {
            string str = aNumber.ToString();
            for (int i = 0; 2 * i < str.Length; i++)
                if (str[i] != str[str.Length - i - 1])
                    return false;
            return true;
        }

        public static int Problem4()
        {
            IsPalindrome(10000);

            int result = 0;
            for (int i = 100; i <= 999; i++)
                for (int j = 100; j <= 999; j++)
                {
                    var product = i * j;
                    if ((product > result) && IsPalindrome(product))
                        result = product;
                }
            return result;
        }


        private static Dictionary<int, int> GetPrimesDivideCount(int aNumber)
        {
            var result = new Dictionary<int, int>();
            int prime = 2;
            while(aNumber > 1)
            {
                if (aNumber % prime == 0)
                {
                    int nrDivides = 0;
                    do
                    {
                        aNumber /= prime;
                        nrDivides++;
                    } while (aNumber % prime == 0);
                    result.Add(prime, nrDivides);
                }
                prime++;
            }
            return result;
        }




        public static int Problem5()
        {
            int result = 1;
            var numberPrimes = Enumerable.Range(2, 19).Select(n => GetPrimesDivideCount(n)).ToArray();
            for (int i =2; i <= 20; i++)
            {
                var numbersWithPrime =  numberPrimes.Where(dict => dict.Keys.Contains(i)).ToArray();
                if (numbersWithPrime.Any())
                {
                    int divideCount = numbersWithPrime.Select(dict => dict[i]).Max();
                    result *= (int)Math.Pow(i, divideCount);
                }

            }
            return result;
        }

        public static int Problem6()
        {
            int square = Enumerable.Range(1, 100).Sum() * Enumerable.Range(1, 100).Sum();
            int sumSquare = Enumerable.Range(1, 100).Select(n => n * n).Sum();
            int result = square - sumSquare;
            return result;
        }


    }
}
