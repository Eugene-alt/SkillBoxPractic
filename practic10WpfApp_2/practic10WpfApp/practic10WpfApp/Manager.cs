using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic10WpfApp
{
    internal class Manager : Consultant, IChangeData
    {
        #region Методы

        #region Работа с данными клиентов
 

        public override void ChangeName(int clientId, string newDataValue)
        {
            newData(clientId, "name", newDataValue);
            clients[clientId].AddChange(DateTime.Now.ToString(), "name", "Запись", "Менеджер");
        }

        public override void ChangeSurname(int clientId, string newDataValue)
        {
            newData(clientId, "surname", newDataValue);
            clients[clientId].AddChange(DateTime.Now.ToString(), "surname", "Запись", "Менеджер");
        }

        public override void ChangePatronimic(int clientId, string newDataValue)
        {
            newData(clientId, "patronimic", newDataValue);
            clients[clientId].AddChange(DateTime.Now.ToString(), "patronimic", "Запись", "Менеджер");
        }

        public override void ChangePassport(int clientId, string newDataValue)
        {
            newData(clientId, "passport", newDataValue);
            clients[clientId].AddChange(DateTime.Now.ToString(), "passport", "Запись", "Менеджер");
        }

        public override void ChangePhoneNumber(int clientId, string newDataValue)
        {
            newData(clientId, "phoneNumber", newDataValue);
            clients[clientId].AddChange(DateTime.Now.ToString(), "phoneNumber", "Запись", "Менеджер");
        }
            #endregion

        #endregion
    }
}
