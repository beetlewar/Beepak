using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace Beepak
{
    public class Service : IService
    {
        public string GetData(int value)
        {
            return string.Format("You printed: {0}", value);
        }
    }
}
