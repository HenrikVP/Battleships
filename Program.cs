class Program
{
    static Random random = new();
    static int size = 5;
    static int ships = 3;
    static int[,,] shipGrid = new int[2, size, size];
    static int[,,] fireGrid = new int[2, size, size];

    static void Main(string[] args)
    {
        Menu();
        CreateGrid(shipGrid);
        CreateGrid(fireGrid);
        AddRandomShips();
        ShowShipGrid();
        ShowFireGrid();
    }

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
        for (int p = 0; p <= 1; p++)
            for (int i = 0; i < ships; i++)
                while (true)
                {
                    int x = random.Next(0, size);
                    int y = random.Next(0, size);
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
}
