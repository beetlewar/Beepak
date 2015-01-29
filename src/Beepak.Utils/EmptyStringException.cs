using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beepak.Utils
{
    public class EmptyStringException : ArgumentException
    {
        public EmptyStringException(string argumentName) :
            base(string.Format("Строка {0} не может быть пустой", argumentName))
        {
        }
    }
}
