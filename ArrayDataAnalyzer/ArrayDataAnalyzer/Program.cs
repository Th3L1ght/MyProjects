namespace ArrayDataAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = ArrGenerator();

            ArrAnalyze(arr);
        }

        static int[] ArrGenerator()
        {
            Random rd = new Random();
            int[] arr = new int[rd.Next(1, 46000)];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rd.Next(Int32.MinValue, Int32.MaxValue);
            }
            return arr;
        }

        static void ArrAnalyze(int[] arr)
        {
            int minNum = Int32.MaxValue, maxNum = Int32.MinValue;
            long sum = 0;
            foreach (int num in arr)
            {
                sum += num;
                if (num < minNum)
                    minNum = num;
                if (num > maxNum)
                    maxNum = num;
            }

            ArrStatsOutput(arr.Length, minNum, maxNum, sum);
        }

        private static void ArrStatsOutput(int length, int minNum, int maxNum, long sum)
        {
            Console.WriteLine($"The array have {length} elements.");
            Console.WriteLine($"Minimum value in the array is {minNum}");
            Console.WriteLine($"Maximum value in the array is {maxNum}");
            Console.WriteLine($"Sum of all values in the array is {sum}");
        }
    }
}
