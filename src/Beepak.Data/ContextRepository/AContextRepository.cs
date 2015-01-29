using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beepak.Utils;

namespace Beepak.Data.ContextRepository
{
    public abstract class AContextRepository<T> :
        IRepository<T>
    {
        public BeepakEntities Context { get; private set; }

        public AContextRepository(string connectionString)
        {
            connectionString.BPThrowIfStringIsEmpty("connectionString");
#warning зачем-то надо, разобраться
            var dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            this.Context = new BeepakEntities();
        }

        public abstract void Add(T item);

        public void Dispose()
        {
            if(this.Context != null)
            {
                this.Context.Dispose();
                this.Context = null;
            }
        }
    }
}
