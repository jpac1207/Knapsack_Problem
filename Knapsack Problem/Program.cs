using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_Problem
{
    class Program
    {
        static int[][] table;

        static void Main(string[] args)
        {
            //int n = 4;
            //int c = 60;
            //int[] pesos = { -1, 20, 20, 30, 30 };
            //int[] valores = { -1, 20, 30, 20, 40 };            

            //int n = 4;
            //int c = 50;
            //int[] pesos = { -1, 40, 30, 20, 10 };
            //int[] valores = { -1, 840, 600, 400, 100 };

            int n = 3;
            int c = 4;
            int[] pesos = { -1, 3, 2, 2 };
            int[] valores = { -1, 5, 4, 2 };

            table = new int[n + 1][];

            for (int i = 0; i < n + 1; i++)
                table[i] = new int[c + 1];

            List<int> results = Knapsack_Problem(pesos, valores, n, c);

            results.ForEach(x => Console.Write(x + ", "));
            Console.ReadKey();
        }

        static List<int> Knapsack_Problem(int[] pesos, int[] valores, int n, int c)
        {
            int b = 0;

            for (b = 0; b <= c; b++)
            {
                table[0][b] = 0;

                for (int i = 1; i <= n; i++)
                {
                    int a = table[i - 1][b];
                    int candidato = 0;
                    //Verifico a constraint para cada subproblema
                    if (pesos[i] > b)
                        candidato = 0;
                    else
                        candidato = table[i - 1][b - pesos[i]] + valores[i];

                    table[i][b] = (a > candidato) ? a : candidato;
                }
            }

            b = c;

            List<int> itens = new List<int>();

            for (int i = n; i >= 1; i--)
            {
                if (table[i][b] != table[i - 1][b])
                {
                    itens.Add(i);
                    b = b - pesos[i];
                }
            }

            return itens;
        }
    }
}
