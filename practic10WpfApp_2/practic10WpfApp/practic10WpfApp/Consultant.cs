using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic10WpfApp
{
    internal class Consultant : BankWorker, IChangeData
    {
        #region Методы
        public override void ChangePhoneNumber(int clientId, string newDataValue)
        {
            newData(clientId, "phoneNumber", newDataValue);
            clients[clientId].AddChange(DateTime.Now.ToString(), "phoneNumber", "Запись", "Консультант");
        }

        protected void newData(int clientId, string data, string newDataValue)
        {

            if (!String.IsNullOrEmpty(newDataValue))
            {
                switch (data.Trim())
                {
                    case "name":
                        clients[clientId].Name = newDataValue;
                        break;
                    case "surname":
                        clients[clientId].Surname = newDataValue;
                        break;
                    case "patronimic":
                        clients[clientId].Patronimic = newDataValue;
                        break;
                    case "passport":
                        clients[clientId].Passport = newDataValue;
                        break;
                    case "phoneNumber":
                        clients[clientId].PhoneNumber = newDataValue;
                        break;
                }
            }

            Repository.Serialize();
        }
        #endregion

    }
}
