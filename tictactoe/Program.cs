namespace tictactoe
{
    internal class Program
    {
        static string[,] gameTable = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
        static void Main(string[] args)
        {
            bool isGame = true, isWinner = true;
            int playerWinner = 0;

            while (isGame)
            {
                while (isWinner)
                {
                    PlayerTurn(1);
                    if (CheckWinner(gameTable, 1))
                    {
                        isWinner = false;
                        playerWinner = 1;
                        break;
                    }
                    PlayerTurn(2);
                    if (CheckWinner(gameTable, 2))
                    {
                        isWinner = false;
                        playerWinner = 2;
                        break;
                    }

                }
                PrintGameTable(gameTable);
                Console.WriteLine("Player {0} is winner", playerWinner);
                Console.WriteLine("Do you want to play again? type Y or N");
                string playAgain = Console.ReadLine();
                if (playAgain.ToUpper() == "Y")
                {
                    isWinner = true;
                    gameTable = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
                    Console.Clear();
                }
                else
                    isGame = false;

            }


        }

        static bool CheckWinner(string[,] table, int player)
        {
            string playerSign = "";
            if (player == 1)
                playerSign = "X";
            else
                playerSign = "O";


            static bool CheckdiagonalRL(string[,] table, string playerSign)
            {
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    if (table[i, i] != playerSign)
                        return false;
                }
                return true;
            }
            static bool CheckdiagonalLR(string[,] table, string playerSign)
            {
                for (int i = 0, j = 2; i < table.GetLength(0); i++, j--)
                {
                    if (table[i, j] != playerSign)
                        return false;
                }
                return true;
            }

            static bool CheckHorizonal(string[,] table, string playerSign)
            {
                int counter = 0;
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    counter = 0;
                    for (int j = 0; j < table.GetLength(1); j++)
                    {
                        if (table[i, j] == playerSign)
                            counter++;
                    }
                    if (counter == 3)
                        return true;
                }
                return false;
            }

            static bool CheckVerticaly(string[,] table, string playerSign)
            {
                int counter = 0;
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    counter = 0;
                    for (int j = 0; j < table.GetLength(1); j++)
                    {
                        if (table[j, i] == playerSign)
                            counter++;
                    }
                    if (counter == 3)
                        return true;
                }
                return false;
            }

            if (CheckdiagonalRL(table, playerSign) || CheckdiagonalLR(table, playerSign) || CheckHorizonal(table, playerSign) || CheckVerticaly(table, playerSign))
                return true;
            else
                return false;
        }

        static void PlayerTurn(int player)
        {
            bool isWritingGood = true;
            do
            {

                PrintGameTable(gameTable);
                Console.Write($"Player {player}: Choose your field: ");
                string playerInput = Console.ReadLine();
                Console.Clear();
                if (CheckIsNumber(playerInput))
                {
                    if (IsTaken(gameTable, playerInput))
                    {
                        WriteAnswer(gameTable, playerInput, player);
                        isWritingGood = true;
                    }
                    else
                    {
                        Console.WriteLine("This place is already taken, please take another one");
                        isWritingGood = false;
                    }


                }
                else
                {
                    Console.WriteLine("Please input a number");
                    isWritingGood = false;
                }
            } while (!isWritingGood);



        }


        static bool IsTaken(string[,] table, string playerInput)
        {
            int counter = 1;
            int playerInputInt = int.Parse(playerInput);

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (counter == playerInputInt)
                    {
                        if (table[i, j] == "X" || table[i, j] == "O")
                            return false;
                        else
                            return true;
                    }
                    else
                        counter++;
                }
            }
            return true;

        }

        static bool CheckIsNumber(string input)
        {
            if (int.TryParse(input, out int inputInt))
            {
                if (inputInt > 9 || inputInt < 1)
                    return false;
                return true;
            }
            else
                return false;
        }

        static void WriteAnswer(string[,] table, string pInput, int player)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (player == 1)
                    {
                        if (table[i, j] == pInput)
                            table[i, j] = "X";
                    }
                    else
                    {
                        if (table[i, j] == pInput)
                            table[i, j] = "O";
                    }

                }
            }
        }



        static void PrintGameTable(string[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(" " + table[i, j] + " ");
                    if (j == 0 || j == 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}