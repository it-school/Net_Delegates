namespace Net_Delegates
{
    internal class Student
    {
        private string name;
        private int id;
        private int mark;

        public string Name { get => name; set => name = value.Trim(); }
        public int Id { get => id; set => id = value; }
        public int Mark { get => mark; set => mark = value; }

        public Student(string name, int id, int mark)
        {
            Name = name;
            Id = id;
            Mark = mark;
        }

        public override string ToString()
        {
            return string.Format($"ID => {Id,3} \tName => {Name,12} \tMark => {Mark,5}");
        }

        /// <summary>
        ///  Пользовательская функция сравнения студентов по оценке, возвращающая булевое значение
        /// </summary>
        /// <param name="left">кого</param>
        /// <param name="right">с кем</param>
        /// <returns></returns>
        public static bool isLeftMarkGreater(object left, object right)
        {
            Student leftStudent = (Student)left;
            Student rightStudent = (Student)right;
            return rightStudent.Mark < leftStudent.Mark;
        }

        /// <summary>
        ///  Пользовательская функция сравнения студентов по имени, возвращающая целочисленное значение
        /// </summary>
        /// <param name="left">кого</param>
        /// <param name="right">с кем</param>
        /// <returns></returns>
        public static bool isLeftNameGreater(object left, object right)
        {
            Student leftStudent = (Student)left;
            Student rightStudent = (Student)right;
            return string.Compare(rightStudent.Name, leftStudent.Name, StringComparison.Ordinal) < 0;
        }        
        
        /// <summary>
        ///  Пользовательская функция сравнения студентов по имени, возвращающая целочисленное значение
        /// </summary>
        /// <param name="left">кого</param>
        /// <param name="right">с кем</param>
        /// <returns></returns>
        public static bool isRightNameGreater(object left, object right)
        {
            Student leftStudent = (Student)left;
            Student rightStudent = (Student)right;
            return string.Compare(rightStudent.Name, leftStudent.Name, StringComparison.Ordinal) > 0;
        }
    }
}

