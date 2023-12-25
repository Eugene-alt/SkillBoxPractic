using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace practic10WpfApp
{
    internal class Repository
    {
        // Статические поля
        static private string filePath;
        static public ObservableCollection<Client> clients;
        static public int index;

        // Статический конструктор
        static Repository()
        {
            clients = new ObservableCollection<Client>();
            filePath = @"repository.json";
            index = 0;
        }

        #region Методы
        /// <summary>
        /// Добавляет клиента в массив клиентов
        /// </summary>
        /// <param name="client">Клиент, которого необходимо добавить</param>
        public void AddClient(Client client)
        {
            clients.Add(client);
        }

        /// <summary>
        /// Очистка репозитория
        /// </summary>
        public void ClearRepository()
        {
            clients.Clear();
            Serialize();
        }

        private void Deserialize()
        {
            string json;

            if (File.Exists(filePath))
            {
                json = File.ReadAllText(filePath);
                clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(json);
                index = clients.Count;
            }
            else
            {
                Console.WriteLine("Файл создан");
                File.Create(filePath).Close();
            }
        }

        public static void Serialize()
        {
            string json;

            json = JsonConvert.SerializeObject(clients, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Выводит в консоль данные о всех клиентов
        /// </summary>
        public static void PrintAll()
        {
            Console.WriteLine("Вот все клиенты:");
            if (clients.Count > 0)
            {
                foreach (Client client in clients)
                {
                    Console.WriteLine(client);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Заполняет массив клиентов указанным количеством клиентов
        /// </summary>
        /// <param name="count">Количество необходимых клиентов</param>
        public void Fill(int count)
        {
            for (int i = 0; i < count; i++)
            {
                AddClient(new Client("Zhenya", "Panuev", "Vasilevich", "2435 534534", "8942353246"));
            }
        }
        #endregion

        // Конструктор
        public Repository() 
        {
            Deserialize();
        }
    }
}
