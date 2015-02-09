using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beepak.Service
{
    public class PasswordFailedException : Exception
    {
        public PasswordFailedException(string login, string password) :
            base(string.Format("Не верный пароль '{0}' для пользователя '{1}'", password, login))
        {
        }
    }
}
