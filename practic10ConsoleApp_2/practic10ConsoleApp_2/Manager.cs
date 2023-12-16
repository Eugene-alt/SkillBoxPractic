using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic10ConsoleApp_2
{
    internal class Manager : Consultant
    {
        #region Методы

            #region Работа с данными клиентов
        protected override void WorkWithName(int clientId)
        {
            if (ReadOrWrite())
            {
                base.WorkWithName(clientId);
            }
            else
            {
                newData(clientId, "name");
                clients[clientId].AddChange(DateTime.Now.ToString(), "name", "Запись", "Менеджер");
            }
        }

        protected override void WorkWithSurname(int clientId)
        {
            if(ReadOrWrite())
            {
                base.WorkWithSurname(clientId);
            }
            else
            {
                newData(clientId, "surname");
                clients[clientId].AddChange(DateTime.Now.ToString(), "surname", "Запись", "Менеджер");
            }
        }

        protected override void WorkWithPatronimic(int clientId)
        {
            if (ReadOrWrite())
            {
                base.WorkWithPatronimic(clientId);
            }
            else 
            { 
                newData(clientId, "patronimic");
                clients[clientId].AddChange(DateTime.Now.ToString(), "patronimic", "Запись", "Менеджер");
            }
        }

        protected override void WorkWithPassport(int clientId)
        {
            if (ReadOrWrite())
            {
                base.WorkWithPassport(clientId);
            }
            else
            {
                newData(clientId, "passport");
                clients[clientId].AddChange(DateTime.Now.ToString(), "passport", "Запись", "Менеджер");
            }
        }

        protected override void WorkWithPhoneNumber(int clientId)
        {
            if (ReadOrWrite())
            {
                base.WorkWithPhoneNumber(clientId);
            }
            else
            {
                newData(clientId, "phoneNumber");
                clients[clientId].AddChange(DateTime.Now.ToString(), "phoneNumber", "Запись", "Менеджер");
            }
        }
            #endregion

        private bool ReadOrWrite()
        {
            Console.WriteLine("Что вы хотите сделать с этими данными?\n" +
                "1 - Просмотреть\n" +
                "2 - Изменить\n");

            switch(Console.ReadKey(true).Key)
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

        private void newData(int clientId, string data)
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
        #endregion

        // Конструктор
        public Manager()
        {
            WorkerLife();
        }
    }
}
