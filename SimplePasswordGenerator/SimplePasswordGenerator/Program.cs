using System.Text;
namespace PasswordGenerator
{
    class Program
    {
        const string LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
        const string UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string Numbers = "0123456789";
        const string SpecSymbols = "!@#$%^&*";

        static void Main(string[] args)
        {
            bool useLowerCase, useUpperCase, useNums, useSpecSymbols;
            Console.Write("Write the password's length: ");
            int passLen;
            while(!int.TryParse(Console.ReadLine(), out passLen) || passLen <= 0)
                Console.WriteLine("Error. Enter a number that more than 0");

            GetAllowed(out useLowerCase, out useUpperCase, out useNums, out useSpecSymbols);
            if(!useLowerCase && !useUpperCase && !useNums && !useSpecSymbols)
            {
                Console.WriteLine("Error. No symbols were allowed to use.");
                return;
            }

            StringBuilder allowed = AddAllowed(useLowerCase, useUpperCase, useNums, useSpecSymbols);

            StringBuilder password = new StringBuilder();

            Random rd = new Random();
            for(int i = 0; i < passLen; i++)
                password.Append(allowed[rd.Next(0, allowed.Length)]);

            Console.WriteLine("Processing...");
            Thread.Sleep(passLen * 100);
            Console.WriteLine($"Your password is ready: {password}");
        }

        static void GetAllowed(out bool useLowerCase, out bool useUpperCase, out bool useNums, out bool useSpecSymbols)
        {
            Console.Write("Use the lower case letters? [a-z] y/n: ");
            useLowerCase = (Console.ReadLine().ToLower() == "y");
            Console.Write("Use the upper case letters? [A-Z] y/n: ");
            useUpperCase = (Console.ReadLine().ToLower() == "y");
            Console.Write("Use the numbers? [0-9] y/n: ");
            useNums = (Console.ReadLine().ToLower() == "y");
            Console.Write("Use the special symbols? [!@#$%] y/n: ");
            useSpecSymbols = (Console.ReadLine().ToLower() == "y");
        }

        static StringBuilder AddAllowed(bool useLowerCase, bool useUpperCase, bool useNums, bool useSpecSymbols)
        {
            StringBuilder sb = new StringBuilder();
            if (useLowerCase)
                sb.Append(LowerCaseLetters);
            if (useUpperCase)
                sb.Append(UpperCaseLetters);
            if (useNums)
                sb.Append(Numbers);
            if (useSpecSymbols)
                sb.Append(SpecSymbols);
            return sb;
        }
    }
}
