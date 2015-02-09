using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beepak.Service
{
    public class LoginAbsentException : Exception
    {
        public LoginAbsentException(string login) :
            base(string.Format("Логин '{0}' не найден", login))
        { }
    }
}
