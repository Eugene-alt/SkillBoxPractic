using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic10WpfApp
{
    interface IChangeData
    {
        void ChangeName(int clientId) { }

        void ChangeSurname(int clientId) { }

        void ChangePatronimic(int clientId) { }

        void ChangePassport(int clientId) { }

        void ChangePhoneNumber(int clientId) { }
    }
}
