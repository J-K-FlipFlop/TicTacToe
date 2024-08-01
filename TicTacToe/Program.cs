string[] grid = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

bool xTurn = true;
int turnNum = 1;
Console.WriteLine();

while(turnNum < 10)
{
    if (xTurn)
    {
        Console.WriteLine("Place an X by typing a number!");
    }
    else
    {
        Console.WriteLine("Place an O by typing a number!");
    }

    PrintGrid();
    TakeTurn();
    if (CheckVictory())
    {
        if (xTurn) { PrintGrid(); Console.WriteLine("Game is over! X wins!"); }
        else { PrintGrid(); Console.WriteLine("Games is over! O wins!"); }
        break;
    }
    turnNum++;
}

if (!CheckVictory())
{
    Console.WriteLine("Game is a draw!");
}

void PrintGrid()
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (j < 2)
            {
                Console.Write("  " + grid[j + i * 3] + "  |");
            }
            else
            {
                Console.Write("  " + grid[j + i * 3]);
            }
        }

        Console.WriteLine();
        if (i < 2)
        {
            Console.WriteLine(" ---------------");
        }
    }
}

void TakeTurn() {
    string response = Console.ReadLine();

    while(response.Length > 1 | response[0] - 49 < 0 | response[0] - 49 > 9)
    {
        Console.WriteLine("Please give a valid grid square");
        response = Console.ReadLine();
    }

    int index = response[0] - 49;

    if (xTurn)
    {
        grid[index] = "X";
    }
    else
    {
        grid[index] = "O";
    }

    xTurn = !xTurn;
}

bool CheckVictory()
{
    if (grid[0] == grid[1] & grid[1] == grid[2]) { return true; }
    if (grid[3] == grid[4] & grid[4] == grid[5]) { return true; }
    if (grid[6] == grid[7] & grid[7] == grid[8]) { return true; }
    if (grid[0] == grid[3] & grid[3] == grid[6]) { return true; }
    if (grid[1] == grid[4] & grid[4] == grid[7]) { return true; }
    if (grid[2] == grid[5] & grid[5] == grid[8]) { return true; }
    if (grid[0] == grid[4] & grid[4] == grid[8]) { return true; }
    if (grid[2] == grid[4] & grid[4] == grid[6]) { return true; }

    return false;
}
