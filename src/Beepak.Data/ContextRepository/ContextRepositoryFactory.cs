using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beepak.Data.Context;
using Beepak.Data.Decl;
using System.Configuration;

namespace Beepak.Data.ContextRepository
{
    public class ContextRepositoryFactory :
        IRepositoryFactory
    {
        private static readonly string _connectionString;

        static ContextRepositoryFactory()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }

        public IRepository<T> CreateRepository<T>()
        {
            if(typeof(T) == typeof(User))
            {
                return (IRepository<T>)new UsersRepository(_connectionString);
            }

            throw new NotImplementedException();
        }
    }
}
