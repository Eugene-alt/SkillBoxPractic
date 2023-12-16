using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic10ConsoleApp_2
{
    internal class Consultant
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
        protected virtual void WorkWithName(int clientId)
        {
            if (clientId < clients.Count)
            {
                Console.WriteLine(clients[clientId].name);
            }
        }

        protected virtual void WorkWithSurname(int clientId)
        {
            if (clientId < clients.Count)
            {
                Console.WriteLine(clients[clientId].surname);
            }
        }
 
        protected virtual void WorkWithPatronimic(int clientId)
        {
            if (clientId < clients.Count)
            {
                Console.WriteLine(clients[clientId].patronimic);
            }
        }

        protected virtual void WorkWithPassport(int clientId)
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
   
        protected virtual void WorkWithPhoneNumber(int clientId)
        {
            string phoneNumber;

            Console.Write("Введите номер телефона, на который хотите изменить данный номер >>> ");
            phoneNumber = Console.ReadLine();

            if (clientId < clients.Count)
            {
                if (!String.IsNullOrEmpty(phoneNumber))
                {
                    clients[clientId].phoneNumber = phoneNumber;
                }
                else
                {
                    Console.WriteLine("Номер телефона не может быть пустым");
                }
            }

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
                        WorkWithName(clientId);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Вы выбрали ФАМИЛИЯ\n");
                        WorkWithSurname(clientId);
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Вы выбрали ОТЧЕСТВО\n");
                        WorkWithPatronimic(clientId);
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Вы выбрали ПАСПОРТНЫЕ ДАННЫЕ\n");
                        WorkWithPassport(clientId);
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("Вы выбрали НОМЕР ТЕЛЕФОНА\n");
                        WorkWithPhoneNumber(clientId);
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
        #endregion

        // Конструкторы
        public Consultant(bool fromRepository)
        {
            WorkerLife();
        }
        public Consultant() { }
    }
}
