namespace ComplexNumberOperations
{
    public struct Complex
    {
        public double real;
        public double imaginary;

        public Complex(double real, double imaginary = 0)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public static implicit operator Complex(double argument)
        {
            return new Complex(argument);
        }

        public static explicit operator double(Complex argument)
        {
            return argument.real;
        }

        public static Complex operator +(Complex num1, Complex num2)
        {
            Complex sum = new Complex();
            sum.real = num1.real + num2.real;
            sum.imaginary = num1.imaginary + num2.imaginary;
            return sum;
        }

        public static Complex operator -(Complex num1, Complex num2)
        {
            Complex sum = new Complex();
            sum.real = num1.real - num2.real;
            sum.imaginary = num1.imaginary - num2.imaginary;
            return sum;
        }

        public override string ToString()
        {
            if (imaginary < 0)
                return $"{real} - {Math.Abs(imaginary)}i";
            else
                return $"{real} + {imaginary}i";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Simple tests
            Complex c = 5.5;
            double num = (double)c;
            Console.WriteLine(c.ToString());
            Console.WriteLine(num);

            Complex num1 = new Complex(4, -11);
            Complex num2 = new Complex(2.7, 3.14);
            Console.WriteLine(num1.ToString());
            Console.WriteLine(num2.ToString());
            Console.WriteLine((num1 + num2).ToString());
            Console.WriteLine((num1 - num2).ToString());
        }
    }
}
