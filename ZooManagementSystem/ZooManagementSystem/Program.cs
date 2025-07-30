using ZooManagementSystem.Animals;

namespace ZooManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.AddAnimal(new Lion("Michael"));
            zoo.AddAnimal(new Lion("Max"));
            zoo.AddAnimal(new Snake("George"));
            zoo.AddAnimal(new Snake("Kimi"));
            zoo.AddAnimal(new Lion("Nelson"));
            zoo.AddAnimal(new Elephant("Nigel"));
            zoo.AddAnimal(new Elephant("Alain"));
            zoo.AddAnimal(new Animal("Daniil"));
            zoo.AddAnimal(new Animal("Nikita"));

            while (true)
            {
                Console.WriteLine("Choose the operation: ");
                Console.WriteLine("1. Add new animal to the zoo.");
                Console.WriteLine("2. Remove animal from the zoo.");
                Console.WriteLine("3. Morning call.");
                Console.WriteLine("Enter \"exit\" to quit the program.");

                switch (Console.ReadLine())
                {
                    case "1":
                        HandleAddAnimal(zoo);
                        break;
                    case "2":
                        HandleRemoveAnimal(zoo);
                        break;
                    case "3":
                        MorningRollCall(zoo);
                        break;
                    case "exit":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong operation!");
                        Console.ResetColor();
                        break;
                }
            }

        }

        private static void HandleAddAnimal(Zoo zoo)
        {
            string name = GetCorrectInput("Enter the name: ");
            string type = GetCorrectInput("Enter the type of animal: ");

            Animal animal = CreateAnimal(type, name);
            zoo.AddAnimal(animal);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{animal.ToString()} was added to the zoo.");
            Console.ResetColor();
        }

        private static void HandleRemoveAnimal(Zoo zoo)
        {
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();
            if (zoo.RemoveAnimal(name))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Animal deleted successfully.\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No animal found with this title!\n");
                Console.ResetColor();
            }
        }

        private static string GetCorrectInput(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    break;

                Console.WriteLine("Error: incorrect input - cannot be empty.");
            }
            return input.Trim();
        }

        private static Animal CreateAnimal(string animalType, string name)
        {
            switch (animalType.ToLower())
            {
                case "lion":
                    return new Lion(name);
                case "snake":
                    return new Snake(name);
                case "elephant":
                    return new Elephant(name);
                default:
                    Console.WriteLine("Unknown animal type! Type \"Animal\" will be used for this animal.");
                    return new Animal(name);
            }
        }

        public static void MorningRollCall(Zoo zoo)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (Animal animal in zoo.GetAnimals())
            {
                Console.WriteLine($"{animal.ToString()}{animal.MakeSound()}");
            }
            Console.ResetColor();
        }
    }
}
