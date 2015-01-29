using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beepak.Data.ContextRepository
{
    public class UsersRepository : 
        AContextRepository<User>
    {
        public UsersRepository(string connectionString) :
            base(connectionString) { }

        public override void Add(User item)
        {
            this.Context.Users.Add(item);
            this.Context.SaveChanges();
        }

        public override IQueryable<User> QueryAll()
        {
            return this.Context.Users;
        }
    }
}
