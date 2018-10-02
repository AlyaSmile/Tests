using System;
using System.Collections.Generic;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestOfLogicalAndForDaysMatrix();
            Console.ReadKey();
        }
        
        private static void TestOfLogicalAndForDaysMatrix()
        {
            char[] charMatrix = "1010101010101010101010101010000".ToCharArray();
            int daysMatrix = 0;

            for (int i = 30; i > -1; i--)
            {
                daysMatrix <<= 1;
                char c = charMatrix[i];
                if (c != '0')
                {
                    daysMatrix += 1;
                }
            }

            var departureDate1 = new DateTime(2018, 10, 1); 
            var departureDate2 = new DateTime(2018, 10, 2); 
            var departureDate3 = new DateTime(2018, 10, 3); 
            var departureDate4 = new DateTime(2018, 10, 4); 

            var dayMatrixlist = new List<int>()
            {
                1 << (departureDate1.Day - 1), // 1000000000000000000000000000000
                1 << (departureDate2.Day - 1), // 0100000000000000000000000000000
                1 << (departureDate3.Day - 1), // 0010000000000000000000000000000
                1 << (departureDate4.Day - 1)  // 0001000000000000000000000000000
            };
            
            foreach (var myMatrix in dayMatrixlist)
            {
                Console.WriteLine((daysMatrix & myMatrix) == 0);
                // 1000000000000000000000000000000 и 1010101010101010101010101010000 = 1000000000000000000000000000000
                // 0100000000000000000000000000000 и 1010101010101010101010101010000 = 0000000000000000000000000000000
                // 0010000000000000000000000000000 и 1010101010101010101010101010000 = 0010000000000000000000000000000
                // 0001000000000000000000000000000 и 1010101010101010101010101010000 = 0000000000000000000000000000000
            }
        }

        private static void TestGitCommit()
        {
        }
    }
}
