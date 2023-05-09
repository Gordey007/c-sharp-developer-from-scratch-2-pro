using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Homework_Theme_10
{
    abstract class Employee
    {
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        protected string occupation;

        /// <summary>
        /// Сотрудник
        /// </summary>
        /// <param name="Occupation">Должность сотрудника</param>
        public Employee(string Occupation)
        { 
            this.occupation = Occupation; 
        }


        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }


        /// <summary>
        /// Приветствие
        /// </summary>
        public virtual void Authorization() 
        { 
            Console.WriteLine("Хорошего рабочего дня!"); 
        }


        /// <summary>
        /// Меню
        /// </summary>
        /// <returns>Выбранное действие</returns>
        public static byte PrintMenu()
        {
            Console.WriteLine("\nВыберите действие.");
            Console.WriteLine
            (
                "\n1 - получить список id клиентов." +
                "\n2 - получить информацию по всем клиентам." +
                "\n3 - получить информацию по клиенту." +
                "\n4 - добавить клиента." +
                "\n5 - изменить информацию у клиента." + 
                "\n6 - поменять сотрудника или выйти."
            );

            byte output;
            Console.Write("\n> ");
            try
            {
                output = (byte)Convert.ToInt16(Console.ReadLine());
            }
            catch (FormatException)
            {
                output = byte.MinValue;
            }
            return output;
        }


        /// <summary>
        /// Метод загрузки клиентов из JSON файла
        /// </summary>
        /// <returns>Словарь клиентов, где key - ClientId, Value объект клиент</returns>
        public static Dictionary<string, Client> GetClients()
        {
            // Загрузка данных о клиентов
            string JSON = File.ReadAllText(@"..\..\..\source\clients.json");

            var clientsFromJSON = JObject.Parse(JSON)["clients"].ToArray();

            Dictionary<string, Client> clients = new();
            foreach (var client in clientsFromJSON)
                clients.Add(client["ClientId"].ToString(), JsonConvert.DeserializeObject<Client>(client.ToString()));
            
            return clients;
        }


        /// <summary>
        /// Метод получения ID клиентов
        /// </summary>
        /// <param name="clients">Словарь клиентов, где key - ClientId, Value объект клиент</param>
        /// <returns>Список ID клиентов</returns>
        public static List<string> GetClientsIds(Dictionary<string, Client> clients)
        {
            List<string> ids = new();
            foreach(var client in clients)
                ids.Add(client.Value.ClientId);

            return ids;
        }


        /// <summary>
        /// Метод получения информации о всех клиентов.
        /// </summary>
        /// <param name="clients">Словарь клиентов, где key - ClientId, Value объект клиент</param>
        /// <param name="occupation"></param>
        public static void PrintAllInfoClient(Dictionary<string, Client> clients, string occupation)
        {
            foreach (var client in clients)
            {
                client.Value.EmployeeType = occupation;
                
                Console.WriteLine
                (
                    $"\nClientId: {client.Value.ClientId}\n" +
                    $"Surname: {client.Value.Surname}\n" +
                    $"Name: {client.Value.Name}\n" +
                    $"Patronymic: {client.Value.Patronymic} \n" +
                    $"PhoneNumber: {client.Value.PhoneNumber} \n" +
                    $"SeriesPassportNumber: {client.Value.SeriesPassportNumber} \n" +
                    $"DateTimeModified: {client.Value.DateTimeModified} \n" +
                    $"DataChanged: {string.Join(", ", client.Value.DataChanged.ToArray())} \n" +
                    $"Status: {client.Value.Status} \n" +
                    $"EmployeeChangedData: {client.Value.EmployeeChangedData} \n"
                );
            }
        }


        /// <summary>
        /// Метод вывода информации о конкретном клиенте
        /// </summary>
        /// <param name="client">Объект клиент</param>
        /// <param name="occupation">Должность сотрудника</param>
        public static void PrintInfoClient(Client client, string occupation)
        {
            client.EmployeeType = occupation;

            Console.WriteLine
            (
                $"\nClientId: {client.ClientId}\n" +
                $"Surname: {client.Surname}\n" +
                $"Name: {client.Name}\n" +
                $"Patronymic: {client.Patronymic} \n" +
                $"PhoneNumber: {client.PhoneNumber} \n" +
                $"SeriesPassportNumber: {client.SeriesPassportNumber} \n" +
                $"DateTimeModified: {client.DateTimeModified} \n" +
                $"DataChanged: {string.Join(", ", client.DataChanged.ToArray())} \n" +
                $"Status: {client.Status} \n" +
                $"EmployeeChangedData: {client.EmployeeChangedData} \n"
            );
        }


        /// <summary>
        /// Метод добавления нового клиента
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="patronymic"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="seriesPassportNumber"></param>
        /// <param name="employeeType"></param>
        /// <returns>Объект клиента</returns>
        public static Client? AddClient(string surname, string name, string patronymic, 
            string phoneNumber, string seriesPassportNumber, string employeeType)
        {
            Client? client = employeeType switch
            {
                "Manager" => new Client(Guid.NewGuid().ToString(), 
                    surname, name, patronymic, phoneNumber,
                seriesPassportNumber, DateTime.Now, new List<string> { }),
                "Consultant" => null,
                _ => null
            };

            return client;
        }
    }
}