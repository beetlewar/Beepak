using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beepak.Utils
{
    public static class Extensions
    {
        public static void BPThrowIfStringIsEmpty(this string str, string argumentName)
        {
            str.BPThrowIfArgIsNull(argumentName);
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new EmptyStringException(argumentName);
            }
        }

        public static void BPThrowIfArgIsNull(this object arg, string argumentName)
        {
            if(arg == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
