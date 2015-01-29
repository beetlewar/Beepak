using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beepak.Service
{
    public class DifferentPasswordsException : Exception
    {
        public DifferentPasswordsException(string password, string passwordRpt) :
            base(string.Format("Проверочный пароль '{0}' не совпадает с оригинальным паролем '{1}'", password, passwordRpt))
        {
        }
    }
}
