using System;
using TestPropelicsBaseCode;

namespace TestPropelics
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseLogic bLogic = new BaseLogic();

            #region 1-SigmaSummatory
            var result = bLogic.SigmaSum();
            Console.WriteLine(result);
            #endregion

            #region 2-PrintNumbers
            // Print a word when the number is divisible by 3 or 5 or by both
            //blogic.PrintNumbersDivisibleBy3And5(); 
            #endregion

            //3-(Missing)

            #region 4-WordsAreAnagram
            //Console.WriteLine(bLogic.WordsAreAnagram("casa nueva1", "nueva casa2"));
            #endregion

            #region 5-StringCompression
            //bLogic.StringCompression(Console.ReadLine());
            #endregion

            #region 6-ReverseString
            //bLogic.Reverse("Jugar");
            #endregion

            #region 7-Swap
            //int a = 3, b = 7;
            //bLogic.Swap(ref a, ref b);
            //Console.WriteLine(a + " - " + b);
            #endregion

            #region 8-MatrizWithZeros
            //Pass the values for the matriz size and print the matriz
            //Console.Write("Introduce the rows number: ");
            //int rows = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Introduce the columns number: ");
            //int columns = Convert.ToInt32(Console.ReadLine());            
            //bLogic.SetMatrizRowsAndColumns(rows, columns);
            #endregion

            Console.Read();
        }
    }
}
