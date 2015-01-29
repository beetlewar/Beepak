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
        IQueryable<T> QueryAll();
        void Add(T item);
    }
}
