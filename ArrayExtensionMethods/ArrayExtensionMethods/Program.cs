namespace ArrayExtensionMethods
{
    static class ArrayHelper
    {
        public static int CalculateSum(params int[] nums)
        {
            return nums.Sum();
        }

        public static void FindAndReplace(this int[] arr, int oldValue, int newValue)
        {
            bool wasFound = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == oldValue)
                {
                    arr[i] = newValue;
                    wasFound = true;
                }
            }
            if(!wasFound)
                Console.WriteLine($"Couldn't find the {oldValue} in the array");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Simple tests
            Console.WriteLine(ArrayHelper.CalculateSum(1, 2, 3));
            Console.WriteLine(ArrayHelper.CalculateSum(5, 10, 15, 20));

            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            arr.FindAndReplace(5, 55);
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
