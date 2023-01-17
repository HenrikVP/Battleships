class Program
{
    static Random random = new();
    static int size = 5;
    static int ships = 3;
    static int[,,] shipGrid = new int[2, size, size];
    static int[,,] fireGrid = new int[2, size, size];

    //On grids
    // 0 : nothing to see here folks
    // 1 : Ship is parked and unharmed
    // 2 : Ship is hit and sunk
    // 3 : Fired at location, but no ship

    // BB    CA   DD  DD  SM
    // ***** **** *** *** **
    // Our: * (Rowboat)
    static void Main(string[] args)
    {
        Menu();
        CreateGrid(shipGrid);
        CreateGrid(fireGrid);
        AddRandomShips();

        Game();
    }

    static void Game()
    {
        while (true)
        {
            ShowShipGrid();
            ShowFireGrid();

            int[] fire = ChooseTarget();
            CheckIfHit(fire, 1);
            AIFire(0);
        }
    }

    static int[] ChooseTarget()
    {
        int[] fireAt = new int[2];
        do { Console.Write("Choose x: "); }
        while (!int.TryParse(Console.ReadLine(), out fireAt[0]));
        do { Console.Write("Choose y: "); }
        while (!int.TryParse(Console.ReadLine(), out fireAt[1]));
        return fireAt;
    }

    static bool CheckIfHit(int[] target, int targetPlayer)
    {
        //Check if our int[] (x,y) hits on player shipgrid
        if (shipGrid[targetPlayer, target[0], target[1]] == 1)
        {
            Console.WriteLine($"The shell hit a ship at {target[0]},{target[1]}");
            shipGrid[targetPlayer, target[0], target[1]] = 2;
            fireGrid[(targetPlayer + 1) % 2, target[0], target[1]] = 2;
            return true;
        }
        else
        {
            Console.WriteLine($"The shell missed at {target[0]},{target[1]}");
            fireGrid[targetPlayer, target[0], target[1]] = 3;
            return false;
        }

    }

    static void AIFire(int p)
    {
        while (true)
        {
            //Picks a random number between 0 to <size
            int x = random.Next(size);
            int y = random.Next(size);
            //Checks to see if location is occupied. If it isnt 
            //we park the ship and break out of the while loop.
            if (fireGrid[p, x, y] < 2)
            {
                CheckIfHit(new int[] { x, y }, p + 1 % 2);
                break;
            }
        }
    }

    #region Setup
    private static void Menu()
    {
        Console.WriteLine("Welcome to Battleships! ");

        //As long as the input cannot parse to int the loop will continue
        //If it CAN parse, then it outputs the value to [size] and
        //the method returns true and breaks the while loop.
        do { Console.Write("Choose size of grid: "); }
        while (!int.TryParse(Console.ReadLine(), out size));
        shipGrid = new int[2, size, size];
        #region Alternative
        //do
        //{
        //    string input = Console.ReadLine();
        //    bool b = int.TryParse(input, out size);
        //    if (b) break;

        //} while (true);
        #endregion
        do { Console.Write("Choose number of ships: "); }
        while (!int.TryParse(Console.ReadLine(), out ships));
    }

    static void AddRandomShips()
    {
        //Loops every player (0 for human or 1 for AI)
        for (int p = 0; p <= 1; p++)
            //For every ship we try to find a random location
            for (int i = 0; i < ships; i++)
                //Looper until we find a suitable location that is not occupied
                while (true)
                {
                    //Picks a random number between 0 to <size
                    int x = random.Next(size);
                    int y = random.Next(size);
                    //Checks to see if location is occupied. If it isnt 
                    //we park the ship and break out of the while loop.
                    if (shipGrid[p, x, y] == 0)
                    {
                        shipGrid[p, x, y] = 1;
                        break;
                    }
                }
    }

    static void ShowFireGrid()
    {
        Console.WriteLine("Firegrid");
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Console.Write(fireGrid[0, x, y]);
            }
            Console.WriteLine();
        }
    }

    static void ShowShipGrid()
    {
        Console.WriteLine("ShipGrid");
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Console.Write(shipGrid[0, x, y]);
            }
            Console.WriteLine();
        }
    }
    static void CreateGrid(int[,,] array)
    {
        for (int p = 0; p <= 1; p++)
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    array[p, x, y] = 0;
    }
    #endregion
}
