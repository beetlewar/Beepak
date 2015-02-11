using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beepak.Data.Context
{
    public class BeepakContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public BeepakContext(string connectionString) :
            base(connectionString)
        {

        }
    }
}
