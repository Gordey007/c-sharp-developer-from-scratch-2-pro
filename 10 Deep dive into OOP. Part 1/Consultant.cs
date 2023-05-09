namespace Homework_Theme_10
{
    class Consultant : Employee, IEditing
    {
        /// <summary>
        /// Консультант
        /// </summary>
        /// <param name="EmployeeType">Тип сотрудника</param>
        public Consultant(string EmployeeType = "Consultant") : base(EmployeeType) { }


        /// <summary>
        /// Приветствие
        /// </summary>
        public override void Authorization() { Console.WriteLine("Хорошего рабочего дня консультант!"); }


        /// <summary>
        /// Информация о прав доступа
        /// </summary>
        public void GetInfoAccess()
        {
            Console.WriteLine("Консультант может изменять только номер телефона клиента.");
        }
    }
}