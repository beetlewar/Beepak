using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beepak.Data.Context;
using Beepak.Data.Decl;
using Beepak.Utils;

namespace Beepak.Data.ContextRepository
{
    public abstract class AContextRepository<T> :
        IRepository<T>
    {
        public BeepakContext Context { get; private set; }

        public AContextRepository(string connectionString)
        {
            connectionString.BPThrowIfStringIsEmpty("connectionString");
            this.Context = new BeepakContext(connectionString);
        }

        public abstract void Add(T item);

        public abstract IQueryable<T> QueryAll();

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
