using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            string str = Console.ReadLine().Replace('.', ',');
            string[] numbers = str.Split(new char[] { '-', '+', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            string[] operation = str.Split(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            string[] symbols = new string[numbers.Length + operation.Length];

            int numofoperat = 0;
            for (int num = 0, oper = 1, ш = 0; num < symbols.Length; num += 2, oper += 2, ш++)
            {
                symbols[num] = numbers[ш];
                if (numofoperat < operation.Length) symbols[oper] = operation[ш];
                numofoperat++;
            }

            int count = 0;
            for (int i = 1; i < symbols.Length - 1; i++)
            {
                if (symbols[i] == "*")
                {
                    symbols[i - 1] = Convert.ToString(Convert.ToDouble(symbols[i - 1]) * Convert.ToDouble(symbols[i + 1]));
                    symbols[i] = null;
                    symbols[i + 1] = null;
                    count += 2;
                }
                if (symbols[i] == "/")
                {
                    symbols[i - 1] = Convert.ToString(Convert.ToDouble(symbols[i - 1]) / Convert.ToDouble(symbols[i + 1]));
                    symbols[i] = null;
                    symbols[i + 1] = null;
                    count += 2;
                }
            }

            string[] symbchanged = new string[symbols.Length - count];
            for (int i = 0, j = 0; i < symbols.Length; i++)
            {
                if (symbols[i] != null)
                {
                    symbchanged[j] = symbols[i];
                    j++;
                }
            }

            for (int i = 1; i < symbchanged.Length - 1; i++)
            {
                if (symbchanged[i] == "+")
                {
                    symbchanged[i + 1] = Convert.ToString(Convert.ToDouble(symbchanged[i - 1]) + Convert.ToDouble(symbchanged[i + 1]));
                    symbchanged[i - 1] = null;
                    symbchanged[i] = null;
                }
                if (symbchanged[i] == "-")
                {
                    symbchanged[i + 1] = Convert.ToString(Convert.ToDouble(symbchanged[i - 1]) - Convert.ToDouble(symbchanged[i + 1]));
                    symbchanged[i - 1] = null;
                    symbchanged[i] = null;
                }
            }
            Console.WriteLine("\nResult " + symbchanged[symbchanged.Length - 1]);
            Console.ReadLine();
        }
    }
}
