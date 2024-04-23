namespace Net_Delegates
{
    internal class Student
    {
        private string _name;
        private int _id;
        private int _mark;

        public string Name { get => _name; set => _name = value.Trim(); }
        public int Id { get => _id; set => _id = value; }
        public int Mark { get => _mark; set => _mark = value; }

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
        public static bool IsLeftMarkGreater(object left, object right)
        {
            Student leftStudent = (Student)left;
            Student rightStudent = (Student)right;
            return leftStudent.Mark > rightStudent.Mark;
        }

        /// <summary>
        ///  Пользовательская функция сравнения студентов по имени, возвращающая целочисленное значение
        /// </summary>
        /// <param name="left">кого</param>
        /// <param name="right">с кем</param>
        /// <returns></returns>
        public static bool IsLeftNameGreater(object left, object right)
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
        public static bool IsRightNameGreater(object left, object right)
        {
            Student leftStudent = (Student)left;
            Student rightStudent = (Student)right;
            return string.Compare(rightStudent.Name, leftStudent.Name, StringComparison.Ordinal) > 0;
        }

        public static bool IsLeftNameAndMarkGreater(object left, object right)
        {
            return IsRightNameGreater(left, right) && IsLeftMarkGreater(left, right);
            // TODO implement correct 2 field sorting
        }
    }
}