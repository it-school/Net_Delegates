
namespace Net_Delegates
{
    internal class Human
    {
        // Делегат на функцию, которая ничего не возвращает и принимает объект типа human
        public delegate void HumanDelegate(Human h);

        private Utils.ESex _sex;
        private string _name;
        private string _surname;
        private int _age;

        public Utils.ESex Sex { get => _sex; set => _sex = value; }
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public int Age { get => _age; set => _age = value; }

        /// <summary>
        /// конструктор
        /// </summary>
        public Human()
        {
            Name = Surname = "No data";
            Age = 0;
            Sex = Utils.ESex.Male;
        }
        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>        
        public Human(string name, string surname, int age, Utils.ESex sex)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Sex = sex;
        }

        /// <summary>
        /// Проверка по полу
        /// </summary>
        /// <param name="human"></param>
        internal static void AnalyzeSex(Human human)
        {
            Console.WriteLine((human.Sex == Utils.ESex.Male) ? "Мужчина" : "Женщина");
        }

        /// <summary>
        /// Проверка по возрасту
        /// </summary>
        /// <param name="human"></param>
        internal static void AnalyzeAge(Human human)
        {
            if (human.Age >= 60)
            {
                Console.WriteLine("Пенсионер");
            }
            else if (human.Age >= 16)
            {
                Console.WriteLine("Работник");
            }
            else
            {
                Console.WriteLine("Ребёнок");
            }
        }
    }
}
