using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic10ConsoleApp_2
{
    internal class Manager : Consultant, IChangeData
    {
        #region Методы

            #region Работа с данными клиентов
        protected override void LookName(int clientId)
        {
            if (ReadOrWrite())
            {
                base.LookName(clientId);
            }
            else
            {
                ChangeName(clientId);
            }
        }

        protected override void LookSurname(int clientId)
        {
            if(ReadOrWrite())
            {
                base.LookSurname(clientId);
            }
            else
            {
                ChangeSurname(clientId);
            }
        }

        protected override void LookPatronimic(int clientId)
        {
            if (ReadOrWrite())
            {
                base.LookPatronimic(clientId);
            }
            else 
            {
                ChangePatronimic(clientId);
            }
        }

        protected override void LookPassport(int clientId)
        {
            if (ReadOrWrite())
            {
                base.LookPassport(clientId);
            }
            else
            {
                ChangePassport(clientId);
            }
        }

        protected override void LookPhoneNumber(int clientId)
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

        protected void ChangeName(int clientId)
        {
            newData(clientId, "name");
            clients[clientId].AddChange(DateTime.Now.ToString(), "name", "Запись", "Менеджер");
        }

        protected void ChangeSurname(int clientId)
        {
            newData(clientId, "surname");
            clients[clientId].AddChange(DateTime.Now.ToString(), "surname", "Запись", "Менеджер");
        }

        protected void ChangePatronimic(int clientId)
        {
            newData(clientId, "patronimic");
            clients[clientId].AddChange(DateTime.Now.ToString(), "patronimic", "Запись", "Менеджер");
        }

        protected void ChangePassport(int clientId)
        {
            newData(clientId, "passport");
            clients[clientId].AddChange(DateTime.Now.ToString(), "passport", "Запись", "Менеджер");
        }

        protected override void ChangePhoneNumber(int clientId)
        {
            newData(clientId, "phoneNumber");
            clients[clientId].AddChange(DateTime.Now.ToString(), "phoneNumber", "Запись", "Менеджер");
        }
            #endregion

        #endregion

        // Конструктор
        public Manager()
        {
            WorkerLife();
        }
    }
}
