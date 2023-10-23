namespace Net_Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            example1();
            example2();
            example3();
            example4();
        }

        public static void example1()
        {
            Console.WriteLine("Example 1: ");

            MathIntOperations example1 = new();
            IntOperation operation = new IntOperation(example1.Sum); // Конструируем делегат

            int result = operation(5, 10);
            Console.WriteLine("Сумма: " + result);

            operation = new IntOperation(example1.Mul);   // Меняем ссылку на метод
            result = operation(5, 10);
            Console.WriteLine("Произведение: " + result);

            operation = new IntOperation(example1.Min);   // Меняем ссылку на метод ещё раз
            result = new IntOperation(example1.Div)(operation(operation(5, 10), 10), 5);
            Console.WriteLine("Деление(Разность(5 и 10) - 10) на 5: " + result);
        }

        private static void example2()
        {
            Console.WriteLine("\n\nExample 2: ");

            int[] myArr = new int[] { 2, -4, 10, 5, -6, 9, 0, -7, 7 };

            // Структуируем делегаты
            Operation DelegateOperation;
            Operation Print = ArrayOperation.PrintArray;
            Operation SortASC = ArrayOperation.SortAscending;
            Operation SortDESC = ArrayOperation.SortDescending;
            Operation ArrayEvenify = ArrayOperation.Evenify;
            Operation ArrayOddify = ArrayOperation.Oddify;

            // Групповая адресация
            DelegateOperation = Print;
            DelegateOperation += Print;
            DelegateOperation += Print;
            DelegateOperation += SortASC;
            DelegateOperation += ArrayEvenify;
            DelegateOperation += SortDESC;
            DelegateOperation += ArrayOddify;
            DelegateOperation += Print;

            Console.WriteLine("Initial array:");
            // Выполняем делегат
            DelegateOperation(ref myArr);

            Console.WriteLine("\nRemove some operations:");
            DelegateOperation -= SortDESC;
            //            DelegateOperation -= SortASC;
            DelegateOperation -= ArrayEvenify;
            DelegateOperation -= Print;
            DelegateOperation -= ArrayOddify;
            DelegateOperation(ref myArr);
        }

        private static void example3()
        {
            Console.WriteLine("\n\nExample 3: ");

            Company firm = new();

            firm.AnalyzePeople(new Human.HumanDelegate(Human.AnalyzeSex)); // Сейчас делегат указывает на метод AnalyzeSex
            firm.AnalyzePeople(new Human.HumanDelegate(Human.AnalyzeAge)); // Сейчас делегат указывает на метод AnalyzeAge
            Console.ReadLine();


            // Создание делегатов
            Human.HumanDelegate analyzeSexDelegate = new Human.HumanDelegate(Human.AnalyzeSex);
            Human.HumanDelegate analyzeAgeDelegate = new Human.HumanDelegate(Human.AnalyzeAge);

            // Многоадресный Делегат (формируем его через +)
            // Произойдет вызов методов AnalyzeSex и AnalyzeAge
            Console.WriteLine("\nПример работы Многоадресного делегата (через +):");
            Console.ReadLine();
            firm.AnalyzePeople(analyzeSexDelegate + analyzeAgeDelegate);
            Console.ReadLine();


            // Многоадресный Делегат (формируем его через Combine)
            // Произойдет вызов методов AnalyzeSex и AnalyzeAge
            Console.WriteLine("\nПример работы Многоадресного делегата (через Combine):");
            Console.ReadLine();
            firm.AnalyzePeople((Human.HumanDelegate)Delegate.Combine(analyzeSexDelegate, analyzeAgeDelegate));
            Console.ReadLine();

            // Многоадресный Делегат (формируем его через MulticastDelegate и +)
            // Произойдет вызов методов AnalyzeAge и AnalyzeSex
            Console.WriteLine("\nПример работы Многоадресного делегата (через MulticastDelegate и +):");
            Console.ReadLine();
            MulticastDelegate multicastDelegate = analyzeAgeDelegate + analyzeSexDelegate;
            firm.AnalyzePeople((Human.HumanDelegate)multicastDelegate);
            Console.ReadLine();

            // Удаляем один делегат
            Console.WriteLine("\nУдаление из многоадресного делегата (анализа возраста): ");
            Console.ReadLine();
            Delegate onlySex = MulticastDelegate.Remove(multicastDelegate, analyzeAgeDelegate);
            // Уже не многоадресный делегат        
            firm.AnalyzePeople(onlySex as Human.HumanDelegate);
        }

        public static void example4()
        {
            Console.WriteLine("\n\nExample 4: ");
            
            Random r = new Random();
            // Создание массива объектов класса Student.cs
            Student[] students = {
                                    new Student(Utils.getRandomName(), 1, r.Next()%101),
                                    new Student(Utils.getRandomName(), 2, r.Next()%101),
                                    new Student(Utils.getRandomName(), 3, r.Next()%101),
                                    new Student(Utils.getRandomName(), 4, r.Next()%101),
                                    new Student(Utils.getRandomName(), 5, r.Next()%101),
                                    new Student(Utils.getRandomName(), 6, r.Next()%101),
                                    new Student(Utils.getRandomName(), 7, r.Next()%101),
                                    new Student(Utils.getRandomName(), 8, r.Next()%101),
                                    new Student(Utils.getRandomName(), 9, r.Next()%101),
                                    new Student(Utils.getRandomName(), 10, r.Next()%101)
                                };
            Console.WriteLine("\nInitial data:");
            for (int i = 0; i < students.Length; i++)
                Console.WriteLine(students[i].ToString());


            // Создание делегата с передачей статического метода класса Student в качестве аргумента
            CompareDelegate StudentCompareOperation = new CompareDelegate(Student.isLeftMarkGreater);
            
            // Вызов статического метода класса BubbleSortDummieClass, передача массива объектов и делегата
            BubbleSortDummieClass.Sort(students, StudentCompareOperation);

            Console.WriteLine("\nSorted by mark ASC:");
            for (int i = 0; i < students.Length; i++)
                Console.WriteLine(students[i].ToString());


            // а теперь сортировка по имени
            BubbleSortDummieClass.Sort(students, new CompareDelegate(Student.isLeftNameGreater));
            
            Console.WriteLine("\nSorted by name ASC:");
            for (int i = 0; i < students.Length; i++)
                Console.WriteLine(students[i].ToString());
        }
    }
}