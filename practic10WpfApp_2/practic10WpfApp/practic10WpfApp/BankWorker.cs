using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace practic10WpfApp
{
    class BankWorker : IChangeData
    {
        // Статический массив клиентов
        protected static ObservableCollection<Client> clients;

        // Статический конструктор
        static BankWorker()
        {
            clients = Repository.clients;
        }

        public string LookName(int clientId)
        {
            return clients[clientId].Name;
        }

        public string LookSurname(int clientId)
        {
            return clients[clientId].Surname;
        }

        public string LookPatronimic(int clientId)
        {
            return clients[clientId].Patronimic;
        }

        public string LookPassport(int clientId)
        {
            return "**********";
        }

        public string LookPhoneNumber(int clientId)
        {
            return clients[clientId].PhoneNumber;
        }

        public virtual void ChangeName(int clientId, string newData) { }

        public virtual void ChangeSurname(int clientId, string newData) { }

        public virtual void ChangePatronimic(int clientId, string newData) { }

        public virtual void ChangePassport(int clientId, string newData) { }

        public virtual void ChangePhoneNumber(int clientId, string newData) { }

        public virtual void AddNewClient(string name, string surname, string patronimic, string phone, string passport) { }

        public BankWorker()
        {
            clients = Repository.clients;
        }
    }
}
