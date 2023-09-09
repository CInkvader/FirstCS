using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstCS
{
    class BingoTable
    {
        const int TABLE_ROW_COLUMN = 5;
        int maxNumber;
        int[] possibleNumbers;
        string[,] table;
        int[] numberIndices; // Future purposes

        Random randomNumber = new Random();

        public BingoTable(int maxNumber = 75)
        {
            this.maxNumber = maxNumber;
            
            possibleNumbers = new int[this.maxNumber];
            numberIndices = new int[(int)Math.Pow(TABLE_ROW_COLUMN, 2) - 1];

            table = new string[TABLE_ROW_COLUMN, TABLE_ROW_COLUMN];

            generatePossibleNumbers();
            generateTable();
        }
        ~BingoTable()
        {}
        public void newBingoTable()
        {
            generateTable();
            printTable();
        }
        private void printTable()
        {
            Console.WriteLine("\n\t B\t I\t N\t G\t O\n");
            for (int i = 0; i < TABLE_ROW_COLUMN; i++)
            {
                for (int j = 0; j < TABLE_ROW_COLUMN; j++)
                {
                    Console.Write($"\t{table[i,j]}");
                }
                Console.Write("\n");
            }
        }
        private void generateTable()
        {
            int randomIndex;
            List<int> selectedIndices = new List<int>();

            for (int i = 0; i < TABLE_ROW_COLUMN; i++)
            {
                for (int j = 0; j < TABLE_ROW_COLUMN;)
                {
                    if (i == 2 && j == 2)
                    {
                        table[j, i] = "FRE";
                        j++;
                        continue;
                    }
                    randomIndex = randomNumber.Next(0 + (15 * i), 15 + (15 * i));

                    if (selectedIndices.Contains(randomIndex))
                    {
                        continue;
                    }
                    table[j, i] = randomIndex < 9 ? "00" : "0";
                    table[j, i] += possibleNumbers[randomIndex].ToString();

                    selectedIndices.Add(randomIndex);
                    j++;
                }
            }
            selectedIndices.Clear();
        }
        private void generatePossibleNumbers()
        {
            for (int i = 0; i < maxNumber; i++)
            {
                possibleNumbers[i] = i + 1;
            }
        }
    }

    class Program
    {
        BingoTable bingo = new BingoTable();
        static void Main(string[] args)
        {
            Program program = new Program();

            while (true)
            {
                program.bingo.newBingoTable();
                Console.WriteLine("\n     Press another key to generate a new table");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}