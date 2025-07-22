namespace DictionaryConsoleTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> words = new Dictionary<string, string>();
            int choose;

            while (true)
            {
                Console.WriteLine("""
                    Choose an operation:    
                    1. Add a word
                    2. Translate the word
                    3. Exit program
                    """);
                int.TryParse(Console.ReadLine(), out choose);
                switch (choose)
                {
                    case 1:
                        Addword(words);
                        break;
                    case 2:
                        Translate(words);
                        break;
                    case 3:
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong operation! Try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        static void Addword(Dictionary<string, string> words)
        {
            Console.Write("Enter an english word: ");
            string word = Console.ReadLine().ToLower().Trim();
            if (string.IsNullOrWhiteSpace(word))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! The translation can't be empty");
                Console.ResetColor();
                return;
            }

            if (words.ContainsKey(word))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("This word is already added.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter it's translation on ukrainian: ");
            string translation = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(translation))
            {
                ErrorMessage();
                return;
            }

            words.Add(word, translation);
        }

        static void Translate(Dictionary<string, string> words)
        {
            Console.Write("Enter an english word: ");
            string word = Console.ReadLine().ToLower().Trim();

            if (string.IsNullOrWhiteSpace(word))
            {
                ErrorMessage();
                return;
            }

            if (words.TryGetValue(word, out string translation))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(translation);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Word \"{word}\" wasn't found in dictionary...");
                Console.ResetColor();
            } 
        }

        static void ErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error! Word can't be empty");
            Console.ResetColor();
        }
    }
}
