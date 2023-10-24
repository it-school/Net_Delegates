namespace Net_Delegates
{
    // Объявление делегата, ссылающегося на функцию с двумя параметрами и результатом логического типа
    public delegate bool CompareDelegate(object lhs, object rhs);

    internal class SortFunctions
    {
        public static void BuubleSort(object[] sortArray, CompareDelegate greaterMethod)
        {
            for (int i = 0; i < sortArray.Length - 1; i++)
            {
                for (int j = 0; j < sortArray.Length - 1; j++)
                {
                    if (greaterMethod(sortArray[j], sortArray[j + 1]))
                    {
                        (sortArray[j], sortArray[j + 1]) = (sortArray[j + 1], sortArray[j]);
                        /*
                            object temp = sortArray[j];
                            sortArray[j] = sortArray[j+1];
                            sortArray[j+1] = temp;
                        */
                    }
                }
            }
        }
    }
}