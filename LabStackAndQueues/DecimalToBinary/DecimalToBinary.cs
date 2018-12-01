using System;
using System.Collections.Generic;

namespace DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            Stack<int> binaryNumber = new Stack<int>();

            if (decimalNumber == 0)
            {
                Console.WriteLine("0");
                return;
            }

            while (decimalNumber > 0)
            {
                int result = decimalNumber % 2;
                decimalNumber /= 2;
                binaryNumber.Push(result);
            }
            while (binaryNumber.Count > 0)
            {
                Console.Write(binaryNumber.Pop());
            }
            Console.WriteLine();
        }
    }
}
