//Author:   Jamolov Isroilbek
//Date:     2023.05.15
//Title:    Assignment_2

using TextFile;

namespace Assignment_2
{
    class Program
    {
        static void Main()
        {
            // opening the file
            TextFileReader reader = new(GetFileNameFromUser());

            reader.ReadLine(out string line);
            int n = int.Parse(line);
            List<LayerOfGas> layers = new();

            // getting the initial values of the layers
            for (int i = 0; i < n; i++)
            {
                char[] separators = new char[] { ' ', '\t' };
                if (reader.ReadLine(out line))
                {
                    string[] tokesn = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    char type = char.Parse(tokesn[0]);
                    double thickness = double.Parse(tokesn[1]);

                    switch (type)
                    {
                        case 'Z': layers.Add(new Ozone(type, thickness)); break;
                        case 'X': layers.Add(new Oxygen(type, thickness)); break;
                        case 'C': layers.Add(new CarbonDioxide(type, thickness)); break;
                    }
                }
            }

            reader.ReadLine(out line);
            int lineIndex = 0;
            int round = 0;

            List<IAtmosphericVariable> atmosphericVariables = new();

            // print the initial values of the layers
            Console.WriteLine("\nInitial values");
            PrintLayers(layers);

            // simulation part of the program
            while (layers.Count >= 3 && layers.Count < (n * 3))
            {
                Console.WriteLine("Round " + ++round);
                int previousCountOfLayers = layers.Count;

                for (int i = 0; i < layers.Count; i++)
                {
                    char c = line[lineIndex++ % line.Length]; // to keep looping until the conditions (count > n * 3 or count < 3) are met
                    switch (c)
                    {
                        case 'T': atmosphericVariables.Add(Thunderstorm.Instance); break;
                        case 'S': atmosphericVariables.Add(Sunshine.Instance); break;
                        case 'O': atmosphericVariables.Add(Other.Instance); break;
                    }

                    layers[i].Transform(atmosphericVariables[round - 1], ref layers); // to ascend and engross the new layer or create a new one on top of the atmosphere
                    if (!layers[i].Survived()) layers.RemoveAt(i); // if the thickness of the layer is less than 0.5 then it will perish

                    if (layers.Count < previousCountOfLayers) // if the old layer removed then go one index back
                    {
                        previousCountOfLayers = layers.Count;
                        i--;
                    }
                }

                PrintLayers(layers);
            }
            Console.WriteLine("Simulation is over!");
        }

        public static string GetFileNameFromUser()
        {

            while (true)
            {
                try
                {
                    Console.Write("Enter the file's name: ");
                    string fileName = Console.ReadLine()!;
                    TextFileReader reader = new(fileName);
                    return fileName;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("The file doesn't exist\n\n");
                }
            }
        }

        public static void PrintLayers(List<LayerOfGas> layers)
        {
            foreach (LayerOfGas layer in layers)
            {
                Console.WriteLine(layer.Type + " " + layer.Thickness);
            }
            Console.WriteLine();
        }
    }
}
