using System;
using System.Collections.Generic;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            Matcher matcher = new Matcher();
            List<string> resultList = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter the number of input " + (i + 1));
                int n = Convert.ToInt32(Console.ReadLine());
                for (int j = 0; j < n; j++)
                    resultList.Add(matcher.MatchByNumber(i, Console.ReadLine()));
            }

            foreach (string s in resultList)
                Console.WriteLine(s);
        }

    }
}
