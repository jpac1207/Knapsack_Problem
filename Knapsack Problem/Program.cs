using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            KnapsackTest();
            //BackTracking.InitBoard(6);
            //BackTracking.NQueens(6, 0);
            //BackTracking.FillLabyrinth(7);
            //BackTracking.Labyrinth(7, 0);
            Console.ReadKey();
        }

        static void KnapsackTest()
        {
            //int n = 4;
            //int c = 60;
            //int[] pesos = { -1, 20, 20, 30, 30 };
            //int[] valores = { -1, 20, 30, 20, 40 };

            //int n = 4;
            //int c = 50;
            //int[] pesos = { -1, 40, 30, 20, 10 };
            //int[] valores = { -1, 840, 600, 400, 100 };

            //int n = 3;
            //int c = 4;
            //int[] pesos = { -1, 3, 2, 2 };
            //int[] valores = { -1, 5, 4, 2 };

            int n = 6;
            int c = 12;
            int[] pesos = { -1, 9, 12, 3, 4, 8, 2 };
            double[] valores = { -1, 8, 7, 13, 11.5, 10, 10 };

            Dynamic.InitTable(n, c);

            List<int> results = Dynamic.Knapsack_Problem(pesos, valores, n, c);

            results.ForEach(x => Console.Write(x + ", "));
            Console.ReadKey();
        }

        static void LcsTest()
        {
            //char[] x = { ' ', 'a', 'b', 'c', 'd', 'g', 'h' };
            //char[] y = { ' ', 'a', 'e', 'd', 'f', 'h', 'r' };

            //char[] x = { ' ', '1', '0', '0', '1', '0', '1', '0', '1' };
            //char[] y = { ' ', '0', '1', '0', '1', '1', '0', '1', '1', '0' };

            char[] x = { ' ', '1', '2', '3', '2', '1', '2', '3', '1' };
            char[] y = { ' ', '1', '2', '2', '3', '1', '2', '2', '1', '1' };

            Dynamic.InitTableLcs(x, y);
            Dynamic.Lcs(x, y);

            Console.ReadKey();
        }

    }
}
