using System;

namespace tik_tac_toe_game
{
    class Program
    {

        static void print_board(int[,] arr)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();

            }
        }

        static bool isComplete(int[,] arr)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] == -1)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        static bool hasWin(int[,] arr)
        {
            int horizontal_check = 0, vertical_check = 0, right_diagnal_check = 0, left_diagnal_check = 0;

            left_diagnal_check = arr[2, 0] + arr[1, 1] + arr[0, 2];
            if ((left_diagnal_check == 18 || left_diagnal_check == 3))
            {
                return true;
            }

            for (int i = 0; i < 3; i++)
            {
                horizontal_check = 0;
                vertical_check = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        right_diagnal_check += arr[i, j];
                    }

                    horizontal_check += arr[i, j];
                    vertical_check += arr[j, i];
                }
                if ((vertical_check == 18 || vertical_check == 3) || (horizontal_check == 18 || horizontal_check == 3) || (right_diagnal_check == 18 || right_diagnal_check == 3))
                {
                    return true;
                }
            }


            return false;
        }


        static void pr_board(string[,] b)
        {
            Console.WriteLine("-----------Board------------");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(b[i, j]);
                }
                Console.WriteLine();

            }
            Console.WriteLine("------------------------");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to tik tak toe game!!");
            // string[,] board = new string[5, 3]
            // {
            //     {". |",". |", ". |" },
            //     {"--", "--", "----"},
            //     {". |", ". |", ". |" },
            //     {"--", "--", "----"},
            //     {". |", ". |", ". |" }
            // };

            string[,] sample = new string[5, 3]
            {
                { "1 1 |", "1 2 |", "1 3 |"},
                { "---", "----", "--------" },
                { "2 1 |", "2 2 |", "2 3 |"},
                { "---", "----", "--------" },
                { "3 1 |", "3 2 |", "3 3 |"},
            };

            int[,] arr = new int[3, 3] {
                { -1, -1, -1 },
                { -1, -1, -1 },
                { -1, -1, -1 } };
            Console.WriteLine("Player 1 choose your symbol (press 1 for 'x', press 2 for 'o')");
            int player_1_symb, k;
            char player_1_symb_char;
            k = Convert.ToInt32(Console.ReadLine());
            if (k == 1)
            {
                player_1_symb = 6;
                player_1_symb_char = 'x';
            }
            else
            {
                player_1_symb_char = 'o';
                player_1_symb = 1;
            }

            Console.WriteLine("Player 2 choose your symbol (press 1 for 'x', press 2 for 'o')");
            int player_2_symb = player_1_symb;
            char player_2_symb_char = 'x';
            while (player_2_symb == player_1_symb)
            {
                k = Convert.ToInt32(Console.ReadLine());
                if (k == 1)
                {
                    player_2_symb = 6;
                    player_2_symb_char = 'x';
                }
                else
                {
                    player_2_symb_char = 'o';
                    player_2_symb = 1;
                }
                if (player_2_symb == player_1_symb)
                {
                    Console.WriteLine("Please select another symbol");
                }
            }
            Console.WriteLine("This is the sample index of the board.");
            /*            for (int i = 0; i < 5; i++)
                        {
                            for (int jj = 0; jj < 3; jj++)
                            {
                                Console.Write(sample[i, jj] + "");
                            }
                            Console.WriteLine();

                        }
                        Console.WriteLine();*/
            pr_board(sample);
            int j = 0;
            int flg = 0;
            int check_sart = 1;
            Console.Write("Please select your box by typing the index number (Ex. 1 1 or 2 1): \n");
            bool win = false;
            while (j != 9)
            {
                if (flg == 0)
                {
                    Console.Write("( " + player_1_symb_char + " )" + "Player 1 select your box: \n");
                    String kk = Console.ReadLine();
                    int p1_1 = kk[0] - '0';
                    --p1_1;
                    int p1_2 = kk[2] - '0';
                    --p1_2;

                    arr[p1_1, p1_2] = player_1_symb;

                    p1_1 = p1_1 * 2;

                    /*board[p1_1, p1_2] = player_1_symb_char + " |";*/
                    sample[p1_1, p1_2] = " " + player_1_symb_char + "  |";
                    pr_board(sample);
                    if (check_sart >= 4)
                    {
                        bool p1_win = hasWin(arr);
                        if (p1_win)
                        {
                            Console.WriteLine("Player 1 wins. Comgratulation.");
                            win = true;
                            break;
                        }
                    }
                    flg = 1;
                }
                else
                {
                    Console.Write("( " + player_2_symb_char + " )" + "Player 2 select your box: \n");
                    String kk = Console.ReadLine();

                    int p2_1 = kk[0] - '0';
                    --p2_1;
                    int p2_2 = kk[2] - '0';
                    --p2_2;

                    arr[p2_1, p2_2] = player_2_symb;

                    p2_1 = p2_1 * 2;

                    /*board[p2_1, p2_2] = player_2_symb_char + " |";*/
                    sample[p2_1, p2_2] = " " + player_2_symb_char + "  |";
                    pr_board(sample);

                    if (check_sart >= 4)
                    {
                        bool p2_win = hasWin(arr);
                        if (p2_win)
                        {
                            Console.WriteLine("Player 2 wins. Comgratulation.");
                            win = true;
                            break;
                        }
                    }

                    flg = 0;

                }

                j++;
                check_sart++;
            }
            if (!win)
            {
                Console.WriteLine("The game is a tie. play again");
            }
        }
    }
}
