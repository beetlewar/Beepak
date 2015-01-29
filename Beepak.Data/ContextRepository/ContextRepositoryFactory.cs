using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beepak.Data.ContextRepository
{
    public class ContextRepositoryFactory :
        IRepositoryFactory
    {
        public const string ConnectionString =
            "metadata=" +
            "data source=localhost\\MSSQLSERVER_12;" +
            "initial catalog=Beepak;" +
            "integrated security=True;" +
            "multipleactiveresultsets=True;" +
            "App=EntityFramework";

        public IRepository<T> CreateRepository<T>()
        {
            if(typeof(T) == typeof(User))
            {
                return (IRepository<T>)new UsersRepository(ConnectionString);
            }

            throw new NotImplementedException();
        }
    }
}
