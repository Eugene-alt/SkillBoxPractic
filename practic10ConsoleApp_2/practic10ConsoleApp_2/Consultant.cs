using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic10ConsoleApp_2
{
    internal class Consultant : IChangeData
    {
        // Статический массив клиентов
        protected static List<Client> clients;

        // Статический конструктор
        static Consultant()
        {
            clients = Repository.clients;
        }

        #region Методы

            #region Методы работы с данными клиентов
        protected virtual void LookName(int clientId)
        {
            if (clientId < clients.Count)
            {
                Console.WriteLine(clients[clientId].name);
            }
        }

        protected virtual void LookSurname(int clientId)
        {
            if (clientId < clients.Count)
            {
                Console.WriteLine(clients[clientId].surname);
            }
        }
 
        protected virtual void LookPatronimic(int clientId)
        {
            if (clientId < clients.Count)
            {
                Console.WriteLine(clients[clientId].patronimic);
            }
        }

        protected virtual void LookPassport(int clientId)
        {
            if (clientId < clients.Count)
            {
                if (!String.IsNullOrEmpty(clients[clientId].passport))
                {
                    Console.WriteLine("******************");
                }
                else
                {
                    Console.WriteLine("Поле пустое");
                }
            }
        }
   
        protected virtual void LookPhoneNumber(int clientId)
        {
            if (ReadOrWrite())
            {
                if (clientId < clients.Count)
                {
                    Console.WriteLine(clients[clientId].phoneNumber);
                }
            }
            else
            {
                ChangePhoneNumber(clientId);
            }
        }

        protected virtual void ChangePhoneNumber(int clientId)
        {
            newData(clientId, "phoneNumber");
            clients[clientId].AddChange(DateTime.Now.ToString(), "phoneNumber", "Запись", "Консультант");
        }
            #endregion

        protected int ClientChoice()
        {
            int clientId;
            string userAnswer;

            Console.Write("Введи Id пользователя для работы с его данными >>> ");
            userAnswer = Console.ReadLine();
            Console.WriteLine();

            if (!String.IsNullOrEmpty(userAnswer))
            {
                clientId = Convert.ToInt32(userAnswer);
                return clientId;
            }
            else { return -1; }
        }

        protected void DataChoice(int clientId)
        {
            if (clientId == -1)
            {
                Console.WriteLine("Id клиента введен неверно");
            }
            else
            {
                Console.WriteLine($"Выберите данные клиента {clientId}, с которыми хотите работать:\n" +
                    $"1 - Имя\n" +
                    $"2 - Фамилия\n" +
                    $"3 - Отчество\n" +
                    $"4 - Паспортные данные\n" +
                    $"5 - Номер телефона");
                switch(Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Вы выбрали ИМЯ\n");
                        LookName(clientId);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Вы выбрали ФАМИЛИЯ\n");
                        LookSurname(clientId);
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Вы выбрали ОТЧЕСТВО\n");
                        LookPatronimic(clientId);
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Вы выбрали ПАСПОРТНЫЕ ДАННЫЕ\n");
                        LookPassport(clientId);
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("Вы выбрали НОМЕР ТЕЛЕФОНА\n");
                        LookPhoneNumber(clientId);
                        break;
                }
            }
        }

        protected void WorkerLife()
        {
            bool isLife = true;

            while (isLife)
            {
                Console.Clear();
                Repository.PrintAll();

                DataChoice(ClientChoice());
                Repository.Serialize();
                Console.WriteLine();

                Console.WriteLine("Продолжить? Y/N");
                switch(Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Y:
                        break;
                    case ConsoleKey.N:
                        isLife = false;
                        break;
                    default: break;
                }
            }
        }

        protected void newData(int clientId, string data)
        {
            string newData;

            while (true)
            {
                Console.Write("Введите новые данные >>> ");
                newData = Console.ReadLine();

                if (!String.IsNullOrEmpty(newData))
                {
                    switch (data.Trim())
                    {
                        case "name":
                            clients[clientId].name = newData;
                            break;
                        case "surname":
                            clients[clientId].surname = newData;
                            break;
                        case "patronimic":
                            clients[clientId].patronimic = newData;
                            break;
                        case "passport":
                            clients[clientId].passport = newData;
                            break;
                        case "phoneNumber":
                            clients[clientId].phoneNumber = newData;
                            break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Данные не могут быть пустыми");
                }
            }

        }

        protected bool ReadOrWrite()
        {
            Console.WriteLine("Что вы хотите сделать с этими данными?\n" +
                "1 - Просмотреть\n" +
                "2 - Изменить\n");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    return true;
                case ConsoleKey.D2:
                    return false;
                default:
                    Console.WriteLine("Буду считать, что ты хочешь просмотреть данные");
                    return true;
            }
        }
        #endregion

        // Конструкторы
        public Consultant(bool fromRepository)
        {
            WorkerLife();
        }
        public Consultant() { }
    }
}
