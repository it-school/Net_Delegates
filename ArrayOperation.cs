namespace Net_Delegates
{
    delegate void Operation(ref int[] array);
    internal class ArrayOperation
    {
        public static void PrintArray(ref int[] array)
        {
            foreach (var i in array)
                Console.Write("{0, 7}", i);
            Console.WriteLine();
        }

        /// <summary>
        /// Сортировка массива по возрастанию
        /// </summary>
        /// <param name="array"></param>
        public static void SortAscending(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }

            Console.WriteLine("Ascending sort: ");
            PrintArray(ref array);
        }

        /// <summary>
        /// Сортировка массива по убыванию
        /// </summary>
        /// <param name="array"></param>
        public static void SortDescending(ref int[] array)
        {
            int j;
            for (int i = 0; i < array.Length - 1; i++)
            {
                j = 0;
                do
                {
                    if (array[j] < array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                    j++;
                }
                while (j < array.Length - 1);
            }

            Console.WriteLine("Descending sort: ");
            PrintArray(ref array);
        }

        /// <summary>
        /// Заменяем нечётные числа чётными
        /// </summary>
        /// <param name="array"></param>
        public static void Evenify(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] % 2 != 0)
                    array[i] += 1;

            Console.WriteLine("Even array: ");
            PrintArray(ref array);
        }

        /// <summary>
        /// Заменяем чётные числа нечётными
        /// </summary>
        /// <param name="array"></param>
        public static void Oddify(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] % 2 == 0)
                    array[i] -= 1;

            Console.WriteLine("Odd array: ");
            PrintArray(ref array);
        }
    }
}
