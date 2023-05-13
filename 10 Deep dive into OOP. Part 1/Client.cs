namespace Homework_Theme_10
{
    class Client
    {
        /// <summary>
        /// Уникальный идентификатор клиента.
        /// </summary>
        protected readonly string clientId;

        protected string surname;
        protected string name;
        protected string patronymic;
        protected string phoneNumber;
        protected string seriesPassportNumber;

        protected DateTime dateTimeModified;
        // Список полей, которые изменились.
        protected List<string> dataChanged;
        /// <summary>
        /// Тип изменений.
        /// </summary>
        protected string status;
        /// <summary>
        /// Тип сотрудника, который внес изменения.
        /// </summary>
        protected string employeeChangedData;

        /// <summary>
        /// Тип сотрудника.
        /// </summary>
        protected string employeeType;


        /// <summary>
        /// Клиент
        /// </summary>
        /// <param name="ClientId">ID клиента</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Name">Имя</param>
        /// <param name="Patronymic">Отчество</param>
        /// <param name="PhoneNumber">Номер телефона</param>
        /// <param name="SeriesPassportNumber">Серия и номер паспорта</param>
        /// <param name="DateTimeModified">Дата и время изменения</param>
        /// <param name="DataChanged">Список изменённых полей</param>
        /// <param name="Status">Тип изменения</param>
        /// <param name="EmployeeChangedData">Кто изменил</param>
        /// <param name="EmployeeType">Тип сотрудника</param>
        public Client(string ClientId, string Surname, string Name, string Patronymic, string PhoneNumber,
            string SeriesPassportNumber, DateTime DateTimeModified, List<string> DataChanged, 
            string Status = "Created", string EmployeeChangedData = "Manager", string EmployeeType = "")
        {
            this.clientId = ClientId;

            this.surname = Surname;
            this.name = Name;
            this.patronymic = Patronymic;
            this.phoneNumber = PhoneNumber;
            this.seriesPassportNumber = SeriesPassportNumber;
            
            this.dateTimeModified = DateTimeModified;
            this.dataChanged = DataChanged;
            this.status = Status;
            this.employeeChangedData = EmployeeChangedData;

            this.employeeType = EmployeeType;
        }


        public string ClientId { get => this.clientId; }


        public string Surname
        {
            get => this.surname;
            set
            {
                var output = (employeeType, surname is not "" and not null) switch
                {
                    // Консультант не имеет доступ на внесение данных.
                    ("Consultant", true) => "Ошибка доступа.",
                    ("Manager", true) => this.surname = value,
                    // Если поле не заполнено.
                    (_, false) => "Нет данных.",
                    _ => "Ошибка.",
                };

                // Если установка значения не произошла по какой-либо причине,
                // То вывести информацию.
                if (output != value)
                    Console.WriteLine(output);
            }
        }


        public string Name
        {
            get => this.name;
            set
            {
                var output = (employeeType, name is not "" and not null) switch
                {
                    ("Consultant", true) => "Ошибка доступа.",
                    ("Manager", true) => this.name = value,
                    (_, false) => "Нет данных.",
                    _ => "Ошибка.",
                };

                if (output != value)
                    Console.WriteLine(output);
            }
        }


        public string Patronymic
        {
            get => this.patronymic;
            set
            {
                var output = (employeeType, patronymic is not "" and not null) switch
                {
                    ("Consultant", true) => "Ошибка доступа.",
                    ("Manager", true) => this.patronymic = value,
                    (_, false) => "Нет данных.",
                    _ => "Ошибка.",
                };

                if (output != value)
                    Console.WriteLine(output);
            }
        }


        public string PhoneNumber
        {
            get => this.phoneNumber;
            set
            {
                var output = (employeeType, phoneNumber is not "" and not null) switch
                {
                    // Консультант имеет доступ к внесению данных.
                    ("Consultant", true) => this.phoneNumber = value,
                    ("Manager", true) => this.phoneNumber = value,
                    (_, false) => "Нет данных.",
                    _ => "Ошибка.",
                };

                if (output != value)
                    Console.WriteLine(output);
            }
        }


        public string SeriesPassportNumber
        {
            get => (employeeType, $"{seriesPassportNumber}" is not "" and not "null") switch
            {
                // Для консультанта происходит обфускация данных
                ("Consultant", true) => "******************",
                ("Manager", true) => seriesPassportNumber,
                (_, false) => "Нет данных.",
                _ => "Ошибка.",
            };
            set
            {
                var output = (employeeType, seriesPassportNumber is not "" and not null) switch
                {
                    ("Consultant", true) => "Ошибка доступа.",
                    ("Manager", true) => this.seriesPassportNumber = value,
                    (_, false) => "Нет данных.",
                    _ => "Ошибка.",
                };

                if (output != value)
                    Console.WriteLine(output);
            }
        }


        public DateTime DateTimeModified 
        { 
            get => this.dateTimeModified; 
            set => this.dateTimeModified = value; 
        }


        public List<string> DataChanged {
            get
            {
                if (this.dataChanged != null)
                    return this.dataChanged;
                else
                    return new List<string> { "" };
            }
            set 
            {
                if (value != null)
                    this.dataChanged = value;
                else
                    this.dataChanged = new List<string> { "" }; 
            }
        }


        public string Status { get => this.status; set => this.status = value; }


        public string EmployeeChangedData 
        { 
            get => this.employeeChangedData; 
            set => this.employeeChangedData = value; 
        }


        public string EmployeeType { set { this.employeeType = value; } }

    }
}