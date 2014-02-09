using System;
using System.Collections.Generic;
using System.IO;

namespace DiscreteMathLab5_I
{
    class Program
    {
        static StreamReader sr = new StreamReader("num2part.in");
        static StreamWriter sw = new StreamWriter("num2part.out");

        static void Main(string[] args)
        {
            String[] words = sr.ReadLine().Split(' ');
            int n = int.Parse(words[0]);
            long r = long.Parse(words[1]);
            long[,] d = new long[n+1, n+1];
            for (int last = 0; last <= n; last++)
                d[0,last] = 1;
            for (int lack = 1; lack <= n; lack++)
                for (int last = 0; last <= lack; last++)
                    for (int k = 0; k <= lack - last; k++)
                        d[lack, last] += d[lack - last - k, last + k];
            List<int> result = new List<int>();
            int currentsum = 0;
            int summand = 1;
            while (currentsum < n)
            {
                if (d[n - currentsum - summand, summand] <= r)
                    r -= d[n - currentsum - summand, summand++];
                else
                {
                    result.Add(summand);
                    currentsum += summand;
                }
            }
            for (int i = 0; i < result.Count; i++)
                sw.Write(result[i] + (i + 1 < result.Count ? "+" : ""));
            sw.Close();
        }
    }
}
