class Program
{
    static Random random = new();
    static int size = 5;
    static int[,] coordinates = new int[size, size];

    static void Main(string[] args)
    {
        Menu();
        Grid();
        AddRandomShips(3);
        ShowGrid();
    }

    private static void Menu()
    {
        Console.Write("Welcome to Battleships! Choose size of grid: ");

        //As long as the input cannot parse to int the loop will continue
        //If it CAN parse, then it outputs the value to [size] and
        //the method returns true and breaks the while loop.
        while (!int.TryParse(Console.ReadLine(), out size));
        coordinates = new int[size, size];
        //do
        //{
        //    string input = Console.ReadLine();
        //    bool b = int.TryParse(input, out size);
        //    if (b) break;

        //} while (true);

    }

    static void AddRandomShips(int ships)
    {
        for (int i = 0; i < ships; i++)
        {
            while (true)
            {
                int x = random.Next(0, size);
                int y = random.Next(0, size);
                if (coordinates[x, y] == 0)
                {
                    coordinates[x, y] = 1;
                    break;
                }
            }
        }
    }
    static void ShowGrid()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Console.Write(coordinates[x, y]);
            }
            Console.WriteLine();
        }
    }
    static void Grid()
    {
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                coordinates[x, y] = 0;
    }

}
