﻿using System;

namespace NegativeBinomialDistribution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Binomial Probability {BinomialDistribution(9, 2, 0.5)}");
            Console.WriteLine($"Negative Binomial Probability {NegBinomialDistribution(3, 3, 0.5)}");
            Console.WriteLine($"Negative Binomial Probability {NegBinomialDistributionOriginal(3, 0.5)}");

            var probability = HyperGeometricDistribution(N: 20, K: 6, k: 4, n: 5);
            Console.WriteLine($"Hypergeometric Probability {probability}");


        }

        public static double BinomialDistribution(int numberOfTrials, int numberOfSuccesses, double probOfSuccess)
        {
            var nCr = Factorial(numberOfTrials) / (Factorial(numberOfSuccesses) * Factorial(numberOfTrials - numberOfSuccesses));

            return nCr * Math.Pow(probOfSuccess, numberOfSuccesses) * Math.Pow((1 - probOfSuccess), (numberOfTrials - numberOfSuccesses));
        }

        /// <summary>
        /// Gives the probability of rth success in n trials
        /// </summary>
        /// <param name="numberOfTrials"></param>
        /// <param name="numberOfSuccesses"></param>
        /// <param name="probOfSuccess"></param>
        /// <returns></returns>
        public static double NegBinomialDistribution(int numberOfTrials, int numberOfSuccesses, double probOfSuccess)
        {
            var nCr = Factorial(numberOfTrials - 1) / (Factorial(numberOfSuccesses - 1) * Factorial(numberOfTrials - numberOfSuccesses));

            return nCr * Math.Pow(probOfSuccess, numberOfSuccesses) * Math.Pow((1 - probOfSuccess), (numberOfTrials - numberOfSuccesses));
        }

        public static double NegBinomialDistributionOriginal(int numberOfTrials, double probOfSuccess)
        {
            var nCr = Factorial(numberOfTrials - 1) / (Factorial(2) * Factorial(numberOfTrials - 3));

            return nCr * Math.Pow(probOfSuccess, 3) * Math.Pow((1 - probOfSuccess), (numberOfTrials - 3));
        }

        public static decimal HyperGeometricDistribution(int K, int k, int N, int n)
        {
            var numerator = BinomialCoefficient(K, k) * BinomialCoefficient(N - K, n - k);
            var denomenator = BinomialCoefficient(N, n);

            return (decimal)numerator / (decimal)denomenator;
        }


        public static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            long answer = 1;
            for (long i = 1; i <= n; i++)
            {
                answer = answer * i;
            }

            return answer;
        }

        public static long BinomialCoefficient(int n, int k)
        {
            var numerator = Factorial(n);

            var denominator = Factorial(n - k) * Factorial(k);

            return numerator / denominator;
        }
    }
}
