using System;
using System.Collections.Generic;
using System.Linq;

namespace TestPropelicsBaseCode
{
    public class BaseLogic
    {
        /// <summary>(1)
        /// Makes the sigma summatory from k to the limite spesified
        /// </summary>
        /// <param name="k"></param>
        /// <param name="limite"></param>
        /// <returns></returns>
        public double SigmaSum(int k = 1, int limite = 1000000)
        {
            double sum = 0;

            // Make the summatory
            for (int k2 = k; k2 < limite; k2++)
            {
                sum += (Math.Pow((-1), k2 + 1)) / ((2 * k2) - 1);
            }

            // return the summatory multiplied by four
            return 4 * sum;
        }

        /// <summary>(2)
        /// Prints a word if the number is divisible by 3, 5 or both
        /// </summary>
        public void PrintNumbersDivisibleBy3And5()
        {
            for (int i = 1; i < 200; i++)
            {
                if (i % 3 == 0)
                    if (i % 5 == 0)
                        // Number is divisible by 3 and 5
                        Console.WriteLine("fizzbuzz");
                    else
                        // Number is divisible only by 3
                        Console.WriteLine("fizz");
                else
                    if (i % 5 == 0)
                    // Number is divisible only by 5
                    Console.WriteLine("buzz");
            }
        }

        /// <summary>(3)
        /// Not Implemented
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int GetNumberFromString(string number)
        {
            throw new NotImplementedException();

        }

        /// <summary>(4)
        /// Given two strings, test whether one is an anagram of the other.
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public bool WordsAreAnagram(string word1, string word2)
        {
            // Remove the blank spaces
            word1 = word1.Replace(" ", "");
            word2 = word2.Replace(" ", "");

            // Group the string for each character
            var elementList1 = word1.GroupBy(c => c).Select(r => r.Key);
            var elementList2 = word2.GroupBy(c => c).Select(r => r.Key);

            // First compare if the number of the chareacters count is the same
            if (elementList1.Count() != elementList2.Count())
            {
                return false;
            }

            // Check for specific characters if are contained in both lists
            foreach (var key in elementList1)
            {
                if (!elementList2.Contains(key))
                    return false;
            }

            return true;
        }

        /// <summary>(5)
        /// Perform basic string compression using the counts of repeated characters;
        /// e.g. "aabcccccaaa" would become "a2b1c5a3". If the compressed string would not become
        /// smaller than the original string, just print the original string.
        /// </summary>
        /// <param name="text"></param>
        public void StringCompression(string text)
        {
            string compressedString = null;
            // Get groups of chareacters from the original text
            var groupedCharacters = text.GroupBy(c => c);
            // Iterate for each character group
            foreach (IGrouping<char, char> charGroup in groupedCharacters)
            {
                compressedString += charGroup.Key.ToString() + charGroup.Count();
            }

            // Check if the length of the compressed string is smaller than the original text
            if (compressedString.Length < text.Length)
                Console.WriteLine(compressedString);
            else
                Console.WriteLine(text);
        }

        /// <summary>
        /// Reverses a string in a memory-efficient manner and without using the
        ///  Enumerable.Reverse(IEnumerable<TSource>) extension method.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public String Reverse(String str)
        {
            char[] c = str.ToCharArray();
            char[] r = new char[c.Length];
            int end = c.Length - 1;

            for (int n = 0; n <= end; n++)
            {
                r[n] = c[end - n];
            }

            return new String(r);
        }

        /// <summary>
        /// Swaps two integers without using a temporary variable.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }

        /// <summary>
        /// if an element in an MxN matrix is 0, its entire row and column are set
        /// to 0 and then printed out.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public void SetMatrizRowsAndColumns(int rows, int columns)
        {
            int[,] matrizOrig = GetMatriz(rows, columns);
            PrintMatriz(matrizOrig);
            List<RowColumn> zerosList = GetMatrizWithZeros(matrizOrig);
            ChangeRowsAndColumnsToZero(matrizOrig, zerosList);
            PrintMatriz(matrizOrig);
        }

        /// <summary>
        /// Generates a matriz with random numbers
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        private int[,] GetMatriz(int rows, int columns)
        {
            int[,] matrizOrig = new int[rows, columns];
            var nums = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrizOrig[i, j] = nums.Next(0, 9);
                }
            }

            return matrizOrig;
        }
        
        /// <summary>
        /// Prints the matriz
        /// </summary>
        /// <param name="matriz"></param>
        private void PrintMatriz(int[,] matriz)
        {
            int rows = matriz.GetLength(0);
            int columns = matriz.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j < columns - 1)
                        Console.Write(matriz[i, j] + ", ");
                    else
                        Console.WriteLine(matriz[i, j]);
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Gets the coordinates of each 0 element in the original matriz.
        /// </summary>
        /// <param name="matrizOrig"></param>
        /// <returns></returns>
        private List<RowColumn> GetMatrizWithZeros(int[,] matrizOrig)
        {
            int rows = matrizOrig.GetLength(0);
            int columns = matrizOrig.GetLength(1);
            int[,] matrizWithZeros = new int[rows,columns];
            List<RowColumn> ubicationList = new List<RowColumn>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrizOrig[i,j] == 0)
                    {
                        ubicationList.Add(new RowColumn(i, j));
                    }
                }
            }

            return ubicationList;
        }

        /// <summary>
        /// Sets to 0 the entire row and column where a zero was found in the original matriz
        /// </summary>
        /// <param name="arrOrig"></param>
        /// <param name="zeroList"></param>
        private void ChangeRowsAndColumnsToZero(int[,] arrOrig, List<RowColumn> zeroList)
        {
            int rows = arrOrig.GetLength(0);
            int columns = arrOrig.GetLength(1);
            foreach (RowColumn value in zeroList)
            {
                SetRows(value.Row, columns, arrOrig);
                SetColumns(value.Column, rows, arrOrig);
            }
        }

        /// <summary>
        /// Sets to 0 an entire column of the original matriz where there is a 0.
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <param name="rows"></param>
        /// <param name="arrOrig"></param>
        private void SetColumns(int columnNumber, int rows, int[,] arrOrig)
        {
            for (int i = 0; i < rows; i++)
            {
                arrOrig[i, columnNumber] = 0;
            }
        }

        /// <summary>
        /// Sets to 0 an entire row of the original matriz where there is a 0.
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="columns"></param>
        /// <param name="arrOrig"></param>
        private void SetRows(int rowNumber, int columns, int[,] arrOrig)
        {
            for (int i = 0; i < columns; i++)
            {
                arrOrig[rowNumber, i] = 0;
            }
        }

        /// <summary>
        /// Class used a dto to wiork with the coordinates of each zero in the original matriz
        /// </summary>
        public class RowColumn
        {
            public RowColumn(int row, int column)
            {
                Row = row;
                Column = column;
            }
            public int Row { get; set; }
            public int Column { get; set; }
        }
    }
}
