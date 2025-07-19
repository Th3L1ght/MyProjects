using System.Text;
namespace WordReverser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to reverse: ");
            string userInput = Console.ReadLine();
            Console.WriteLine("Your string Accepted!\nProcessing...");
            Thread.Sleep((userInput.Split(' ').Length) * 25);
            string reversedString = ReverseWordsLINQ(userInput);
            Console.WriteLine(reversedString);
        }
        
        // Using the Array.Reverse()
        static string ReverseWordsArrMethod(string userInput)
        {
            string[] sentence = userInput.Split(' ');
            for (int i = 0; i < sentence.Length; i++)
            {
                sentence[i] = ReverseWordArrMethod(sentence[i]);
            }
            return string.Join(" ", sentence);
        }

        // Without any methods, only cycle
        static string ReverseWordsCycle(string userInput)
        {
            string[] sentence = userInput.Split(' ');
            for(int i = 0; i < sentence.Length; i++)
            {
                sentence[i] = ReverseWordCycle(sentence[i]);
            }
            return string.Join(' ', sentence);
        }

        // Using the StringBuilder
        static string ReverseWordsStrBuilder(string userInput)
        {
            string[] sentence = userInput.Split(' ');
            for (int i = 0; i < sentence.Length; i++)
            {
                sentence[i] = ReverseWordStrBuilder(sentence[i]);
            }
            return string.Join(' ', sentence);
        }

        // Using LINQ
        static string ReverseWordsLINQ(string userInput)
        {
            return string.Join(" ", userInput.Split(' ').Select(word => new string(word.Reverse().ToArray())));
        }

        static string ReverseWordArrMethod(string word)
        {
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static string ReverseWordCycle(string word)
        {
            char[] rWord = new char[word.Length];
            for(int i = 0; i < word.Length; i++)
            {
                rWord[i] = word[word.Length - 1 - i];
            }
            return new string(rWord);
        }

        static string ReverseWordStrBuilder(string word)
        {
            StringBuilder @string = new StringBuilder();
            for (int i = word.Length - 1; i >= 0; i--)
            {
                @string.Append(word[i]);
            }
            return @string.ToString();
        }
    }
}