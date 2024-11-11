using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToeOyunu
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag = 0; // 1: kazanma, -1: berabere, 0: devam ediyor

        public static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Tic Tac Toe Oyunu");
                Console.WriteLine("Oyuncu 1: X ve Oyuncu 2: O");
                Console.WriteLine();
                DrawBoard();

                Console.WriteLine("Oyuncu {0}, nereye koymak istiyorsun? ", player % 2 == 0 ? 2 : 1);
                choice = int.Parse(Console.ReadLine());

                // Seçilen alan boşsa X veya O'yu koyar
                if (board[choice - 1] != 'X' && board[choice - 1] != 'O')
                {
                    board[choice - 1] = player % 2 == 0 ? 'O' : 'X';
                    player++;
                }
                else
                {
                    Console.WriteLine("Üzgünüm; bu kare zaten dolu. Tekrar deneyin!");
                    Console.ReadKey();
                }
                flag = CheckWin();
            }
            while (flag == 0);

            Console.Clear();
            DrawBoard();

            if (flag == 1)
            {
                Console.WriteLine("Tebrikler! Oyuncu {0} kazandı!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Oyun berabere!");
            }

            Console.ReadLine();
        }

        private static void DrawBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        private static int CheckWin()
        {
            // Kazanma durumlarını kontrol et
            int[][] winConditions = new int[][]
            {
            new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 6, 7, 8 }, // Yatay
            new int[] { 0, 3, 6 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 }, // Dikey
            new int[] { 0, 4, 8 }, new int[] { 2, 4, 6 }  // Çapraz
            };

            foreach (int[] condition in winConditions)
            {
                if (board[condition[0]] == board[condition[1]] && board[condition[1]] == board[condition[2]])
                {
                    return 1; // Kazanma durumu
                }
            }

            // Beraberlik durumu: tüm hücreler doluysa
            if (Array.IndexOf(board, '1') == -1 && Array.IndexOf(board, '2') == -1 && Array.IndexOf(board, '3') == -1 &&
                Array.IndexOf(board, '4') == -1 && Array.IndexOf(board, '5') == -1 && Array.IndexOf(board, '6') == -1 &&
                Array.IndexOf(board, '7') == -1 && Array.IndexOf(board, '8') == -1 && Array.IndexOf(board, '9') == -1)
            {
                return -1; // Berabere
            }

            return 0; // Oyun devam ediyor
        }
    }
}
