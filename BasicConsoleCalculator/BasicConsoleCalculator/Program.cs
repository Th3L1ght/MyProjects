namespace BasicConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number: ");
            GetNumber(out int firstNumber);

            string operation = ChooseOperation();

            int secondNumber = 0;
            while (true)
            {
                Console.WriteLine("Enter second number: ");
                GetNumber(out secondNumber);
                if ((operation == "/" || operation == "%") && secondNumber == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Attempt to divide by zero.");
                    Console.ResetColor();
                    continue;
                }
                else break;
            }

            try
            {
                int result = Calculation(firstNumber, secondNumber, operation);
                ResultOutput(firstNumber, secondNumber, operation, result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void GetNumber(out int number)
        {
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error. Enter a number...");
                Console.ResetColor();
            }
        }

        static string ChooseOperation()
        {
            string operation = null;
            bool inputCorrect = false;

            while (!inputCorrect)
            {
                Console.WriteLine("Choose an operation (+, -, *, /, %): ");
                operation = Console.ReadLine();
                switch (operation)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "%":
                        inputCorrect = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a correct operation symbol.");
                        Console.ResetColor();
                        break;
                }
            }
            return operation;
        }

        static int Calculation(int firstNumber, int secondNumber, string operation)
        {
            int result = 0;
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber == 0) throw new DivideByZeroException();
                    result = firstNumber / secondNumber;
                    break;
                case "%":
                    if (secondNumber == 0) throw new DivideByZeroException();
                    result = firstNumber % secondNumber;
                    break;
            }
            return result;
        }

        static void ResultOutput(int firstNumber, int secondNumber, string operation, int result)
        {
            Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {result}");
        }
    }
}
