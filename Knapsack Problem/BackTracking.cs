using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_Problem
{
    class BackTracking
    {
        static int[][] board;

        public static void InitBoard(int n)
        {
            board = new int[n][];

            for (int i = 0; i < n; i++)
            {
                board[i] = new int[n];
            }
        }

        public static void Run(int n, int col)
        {
            //Console.WriteLine(n + "," + col);

            if (n == col)
            {
                Console.WriteLine("Final: ");
                PrintBoard();
                return;
            }

            for (int i = 0; i < n; i++)
            {
                //Console.WriteLine("Linha: " + i);
                bool flag = Safe(i, col);
                //Console.WriteLine("Safe:" + flag);

                if (flag)
                {
                    board[i][col] = 1;
                    //PrintBoard();
                    Run(n, col + 1);
                    board[i][col] = 0;
                }
                //Console.WriteLine("---------------");
            }
        }

        public static bool Safe(int linha, int coluna)
        {
            if (board[linha].Contains(1))
                return false;

            foreach (var x in board)
            {
                if (x[coluna] == 1)
                    return false;
            }

            //diagonal \ para cima
            int lvlinha = linha - 1;
            int lvcoluna = coluna - 1;

            while (lvlinha >= 0 && lvcoluna >= 0)
            {
                if (board[lvlinha][lvcoluna] == 1)
                    return false;

                lvlinha--;
                lvcoluna--;
            }

            //diagonal / para baixo
            lvlinha = linha + 1;
            lvcoluna = coluna - 1;
            while (lvlinha < board.Length && lvcoluna >= 0)
            {
                if (board[lvlinha][lvcoluna] == 1)
                    return false;

                lvlinha++;
                lvcoluna--;
            }

            //diagonal \ para baixo
            lvlinha = linha + 1;
            lvcoluna = coluna + 1;

            while (lvlinha < board.Length && lvcoluna < board.Length)
            {
                if (board[lvlinha][lvcoluna] == 1)
                    return false;

                lvlinha++;
                lvcoluna++;
            }

            //diagonal / para cima
            lvlinha = linha - 1;
            lvcoluna = coluna + 1;
            while (lvlinha >= 0 && lvcoluna < board.Length)
            {
                if (board[lvlinha][lvcoluna] == 1)
                    return false;

                lvlinha--;
                lvcoluna++;
            }

            return true;
        }

        public static void PrintBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    Console.Write(board[i][j] + ", ");
                }
                Console.WriteLine();
            }
            //Console.WriteLine("---------------");
            Console.ReadKey();
        }
    }
}
