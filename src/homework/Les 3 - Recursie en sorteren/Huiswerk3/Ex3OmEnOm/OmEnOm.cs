using System;

namespace AD
{
    public class Opgave3
    {
        public static int OmEnOm(int n)
        {
            if (n < 0)
            {
                throw new OmEnOmNegativeValueException();
            }

            int product = 0;

            for (int i = n; i > 0; i = i - 2)
            {
                product = i + product;
            }

            return product;
        }
        public static void Run()
        {
            int MAX = 20;

            for (int n = 0; n < MAX; n++)
            {
                System.Console.WriteLine("          OmEnOm({0,2}) = {1,3}", n, OmEnOm(n));
            }
        }
    }

    public class OmEnOmNegativeValueException : Exception
    {
    }
}
