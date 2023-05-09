namespace Homework_Theme_10
{
    internal class Manager : Employee, IEditing
    {
        /// <summary>
        /// Менеджер
        /// </summary>
        /// <param name="EmployeeType">Тип сотрудника</param>
        public Manager(string EmployeeType = "Manager") : base(EmployeeType) { }


        /// <summary>
        /// Приветствие
        /// </summary>
        public override void Authorization() { Console.WriteLine("Хорошего рабочего дня менеджер!"); }

        /// <summary>
        /// Информация о прав доступа
        /// </summary>
        public void GetInfoAccess()
        {
            Console.WriteLine("Менеджер может изменять: фамилию; имя; отчество; " +
                "серию и номер паспорта; номер телефона клиента");
        }
    }
}