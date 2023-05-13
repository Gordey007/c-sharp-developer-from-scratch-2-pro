namespace Homework_Theme_10
{
    class Program
    {
        static void Main()
        {
            // Инициализация типов сотрудников.
            Dictionary<string, Employee> employees = new ()
            {
                { "Consultant", new Consultant("Consultant")},
                { "Manager", new Manager("Manager")}
            };

            // Расширение функционала сотрудников.
            Dictionary<string, IEditing> infoAccess = new()
            {
                { "Consultant", new Consultant("Consultant")},
                { "Manager", new Manager("Manager")}
            };

            // Получить список объектов клиентов.
            Dictionary<string, Client> clients = Employee.GetClients();

            while (true)
            {
                // Выбор типа сотрудника.
                Console.WriteLine("\nДля завершения работы программы введите любой символ.");
                Console.Write("\nДля авторизации введите цифру 1 или 2 (1 - Consultant, 2 - Manager): ");

                string employeeType = Console.ReadLine() switch
                {
                    "1" => employees["Consultant"].Occupation,
                    "2" => employees["Manager"].Occupation,
                    // Любое др. значение.
                    _ => "exit"
                };

                // Выход из меню.
                if (employeeType == "exit") break;

                // Бесконечный цикл для работы в меню
                while (true)
                {
                    var mode = Employee.PrintMenu();

                    if (mode == byte.MinValue)
                    {
                        Console.WriteLine("\nОшибка ввода. Попробуйте еще раз.");
                        continue;
                    }

                    // Получить список идентификаторов клиентов.
                    if (mode == 1)
                    {
                        Console.WriteLine("\nИндетификаторы клиентов:");
                        foreach (var id in Employee.GetClientsIds(clients))
                        {
                            Console.WriteLine(id);
                        }
                    }

                    // Получить информацию обо всех клиентов.
                    if (mode == 2)
                    {
                        Console.WriteLine("\nИнфо. о всех клиентов:");
                        Employee.PrintAllInfoClient(clients, employeeType);
                    }

                    // Получить информацию по выбранному клиенту.
                    if (mode == 3)
                    {
                        Console.Write("\nВведите ClientId (например, c268f499-37fc-4843-b130-437bfa8629b1): ");
                        try
                        {
                            Employee.PrintInfoClient(clients[$"{Console.ReadLine()}"], employeeType);
                            Console.WriteLine("Инфо. о клиенте:");
                        }
                        catch (KeyNotFoundException)
                        {
                            Console.WriteLine("\nНе корректный ClientId.");
                        }
                    }

                    // Добавить нового клиента.
                    if (mode == 4)
                    {
                        Console.Write("Введите фамилию: ");
                        var surname = $"{Console.ReadLine()}";

                        Console.Write("Введите имя: ");
                        var name = $"{Console.ReadLine()}";

                        Console.Write("Введите отчество: ");
                        var patronymic = $"{Console.ReadLine()}";

                        Console.Write("Введите телефонный номер: ");
                        var phoneNumber = $"{Console.ReadLine()}";

                        Console.Write("Введите серию и номер паспорта: ");
                        var seriesPassportNumber = $"{Console.ReadLine()}";

                        Client? client = Employee.AddClient(surname, name, patronymic, phoneNumber, 
                            seriesPassportNumber, employeeType);

                        if (client != null) clients.Add(client.ClientId, client);
                    }

                    // Изменить данные о клиенте.
                    if (mode == 5)
                    {
                        infoAccess[employeeType].GetInfoAccess();
                        
                        Console.Write("\nВведите ClientId (например, c268f499-37fc-4843-b130-437bfa8629b1): ");
                        string clientId = $"{Console.ReadLine()}";

                        Console.WriteLine("Если не хотите изменять данные, то нажмите Enter.");

                        // Флаг для установки даты и времени обновления данных.
                        bool checkFlag = false;
                        // Для сохранения старых значений.
                        string checkEdit;
                        // Список полей, в которых было внесено изменение.
                        List<string> dataChanged = new();
                        // Для записи новых данных.
                        string editTxt;

                        try
                        {
                            // Установить тип клиента для определения доступа к данным.
                            clients[clientId].EmployeeType = employeeType;

                            // Сохранить прошлое значение.
                            checkEdit = clients[clientId].Surname;

                            Console.Write("Введите фамилию: ");
                            // Ввести новые данные.
                            editTxt = $"{Console.ReadLine()}";

                            // Если не был нажат Enter и были введены новые данные.
                            if (editTxt != "")
                            {
                                clients[clientId].Surname = editTxt;
                                if (checkEdit != clients[clientId].Surname)
                                {
                                    checkFlag = true;
                                    dataChanged.Add("Фамилия");
                                }
                            }

                            checkEdit = clients[clientId].Name;
                            Console.Write("Введите имя: ");
                            editTxt = $"{Console.ReadLine()}";
                            if (editTxt != "")
                            {
                                clients[clientId].Name = editTxt;
                                if (checkEdit != clients[clientId].Name)
                                {
                                    checkFlag = true;
                                    dataChanged.Add("Имя");
                                }
                            }

                            checkEdit = clients[clientId].Patronymic;
                            Console.Write("Введите отчество: ");
                            editTxt = $"{Console.ReadLine()}";
                            if (editTxt != "")
                            {
                                clients[clientId].Patronymic = editTxt;
                                if (checkEdit != clients[clientId].Patronymic)
                                {
                                    checkFlag = true;
                                    dataChanged.Add("Отчество");
                                }
                            }

                            checkEdit = clients[clientId].PhoneNumber;
                            Console.Write("Введите телефонный номер: ");
                            editTxt = $"{Console.ReadLine()}";
                            if (editTxt != "")
                            {
                                clients[clientId].PhoneNumber = editTxt;
                                if (checkEdit != clients[clientId].PhoneNumber)
                                {
                                    checkFlag = true;
                                    dataChanged.Add("Телефонный номер");
                                }
                            }

                            checkEdit = clients[clientId].SeriesPassportNumber;
                            Console.Write("Введите серию и номер паспорта: ");
                            editTxt = $"{Console.ReadLine()}";
                            if (editTxt != "")
                            {
                                clients[clientId].SeriesPassportNumber = editTxt;
                                if (checkEdit != clients[clientId].SeriesPassportNumber)
                                {
                                    checkFlag = true;
                                    dataChanged.Add("Серию и номер паспорта");
                                }
                            }

                            // Если были изменены какие-либо данные.
                            if (checkFlag == true)
                            {
                                // Установить дату и время обновления.
                                clients[clientId].DateTimeModified = DateTime.Now;
                                // Список обновленных полей.
                                clients[clientId].DataChanged = dataChanged;
                                // Тип сотрудника, который внес изменения.
                                clients[clientId].EmployeeChangedData = employeeType;
                                // Установка статуса.
                                clients[clientId].Status = "Update";
                            }
                        }
                        // Обработка некорректных данных.
                        catch (KeyNotFoundException)
                        {
                            Console.WriteLine("Не корректный ClientId.");
                        }
                    }

                    // Выход из меню.
                    if (mode == 6)
                        break;

                    // Обработка некорректных данных.
                    if (mode > 6 || mode < 1)
                        Console.WriteLine("\nОшибка ввода. Попробуйте еще раз.");
                }
            }
        }
    }
}