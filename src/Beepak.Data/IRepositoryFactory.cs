using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beepak.Data
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>();
    }
}
