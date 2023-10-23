using System.Collections;
using System.Reflection;

namespace Net_Delegates
{
    internal class Company
    {
        ArrayList _people = new();
        public Company()
        {
            // Добавляем в список 3 - х людей
            _people.Add(new Human());
            _people.Add(new Human("Вася", "Петров", 80, Utils.ESex.Male));
            _people.Add(new Human("Катерина", "Сидорова", 25, Utils.ESex.Female));
        }
        /// <summary>
        /// Метод, принимающий делегат 
        /// </summary>
        /// <param name="ptr">название класса, где содержится делегат, а также название делегата</param>        
        public void AnalyzePeople(Human.HumanDelegate ptr)
        {
            Console.Write($"Анализ персонала ({ptr.GetInvocationList().Length}):");
            foreach (var item in ptr.GetInvocationList())
            {
                Console.Write($"  {item.GetMethodInfo().Name}");
            }
            Console.WriteLine();
            // Вызываются методы, на которые указывает делегат
            foreach (Human obj in _people)
                ptr(obj);
        }
    }
}