using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_Problem
{
    class Dynamic
    {
        static double[][] table;

        public static void InitTable(int n, int c)
        {
            table = new double[n + 1][];

            for (int i = 0; i < n + 1; i++)
                table[i] = new double[c + 1];
        }

        public static void InitTableLcs(char[] x, char[] y)
        {
            table = new double[x.Length][];
            printtable = new char[x.Length][];

            for (int i = 0; i < x.Length; i++)
            {
                table[i] = new double[y.Length];
                printtable[i] = new char[y.Length];
            }
        }

        public static List<int> Knapsack_Problem(int[] pesos, double[] valores, int n, int c)
        {
            int b = 0;

            for (b = 0; b <= c; b++)
            {
                table[0][b] = 0;

                for (int i = 1; i <= n; i++)
                {
                    double a = table[i - 1][b];
                    double candidato = 0;
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

        static char[][] printtable;

        public static void Lcs(char[] x, char[] y)
        {
            int i = 0;

            for (i = 1; i <= x.Length - 1; i++)
            {
                //table[0][b] = 0;

                for (int j = 1; j <= y.Length - 1; j++)
                {
                    if (x[i] == y[j])
                    {
                        table[i][j] = table[i - 1][j - 1] + 1;
                        printtable[i][j] = '\\';
                    }
                    else if (table[i - 1][j] >= table[i][j - 1])
                    {
                        table[i][j] = table[i - 1][j];
                        printtable[i][j] = '|';
                    }
                    else
                    {
                        table[i][j] = table[i][j - 1];
                        printtable[i][j] = '-';
                    }

                }
            }

            i = y.Length - 1;
            PrintLcs(x, y, x.Length - 1, y.Length - 1);
        }

        private static void PrintLcs(char[] x, char[] y, int i, int j)
        {
            if (i == 0 || j == 0)
            {
                return;
            }
            if (printtable[i][j] == '\\')
            {
                PrintLcs(x, y, i - 1, j - 1);
                Console.Write(x[i] + " ");
            }
            else if (printtable[i][j] == '|')
            {
                PrintLcs(x, y, i - 1, j);
            }
            else
            {
                PrintLcs(x, y, i, j - 1);
            }
        }
    }
}
