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

        public static void NQueens(int n, int col)
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
                    NQueens(n, col + 1);
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

        public static void Labyrinth(int n, int col)
        {
            if (col == n)
            {
                Console.WriteLine("Final: ");
                PrintBoard();
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (IsPath(i, col))
                {
                    int prev = board[i][col];
                    board[i][col] = 2;
                    PrintBoard();
                    Labyrinth(n, col + 1);

                    if (board[i + 1][col] == 0)
                        board[i][col] = 2;
                    else
                    {
                        board[i][col] = prev;
                    }
                }
            }
        }

        public static bool IsPath(int i, int col)
        {
            if (board[i][col] != 0)
                return false;

            try
            {
                if (board[i][col - 1] == 2)
                    return true;
            }
            catch (Exception)
            {
                if (col == 0)
                    return true;
            }

            try
            {
                if (board[i - 1][col] == 2)
                    return true;
            }
            catch (Exception) { }

            return false;
        }

        public static void FillLabyrinth(int n)
        {
            board = new int[n][];

            for (int i = 0; i < n; i++)
            {
                board[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (i == n - (n / 2) && j < n - 1)
                        board[i][j] = 0;
                    else if (i == (n / 2) + 2 && (j == n - 1 || j == n - 2))
                        board[i][j] = 0;
                    else
                        board[i][j] = 1;
                }
            }

            PrintBoard();
        }
    }
}
