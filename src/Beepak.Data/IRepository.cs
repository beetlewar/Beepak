using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beepak.Data
{
    public interface IRepository<T> : 
        IDisposable
    {
        void Add(T item);
    }
}
